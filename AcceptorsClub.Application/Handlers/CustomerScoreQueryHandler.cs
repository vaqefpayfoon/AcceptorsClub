using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AcceptorsClub.Application.Responses;
using AcceptorsClub.Core.Models;
using AcceptorsClub.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcceptorsClub.Application;
public class CustomerScoreQueryHandler : IRequestHandler<CustomerScoreQuery, IEnumerable<CustomerScoreReportResponse>>
{
    private readonly ApplicationDbContext _context;

    public CustomerScoreQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CustomerScoreReportResponse>> Handle(CustomerScoreQuery request, CancellationToken cancellationToken)
    {
        string query = $@"
            SELECT 
                [dbo].[CustomerScore].[NationalCode],
                [dbo].[CustomerScore].CreatedAt,
                [dbo].[Customer].[Mobile],
                dbo.TotalScore([dbo].[CustomerScore].[NationalCode]) AS Score,
                TRIM([dbo].[Customer].FirstName) + ' ' + TRIM(dbo.Customer.LastName) AS FullName,
                [dbo].[Customer].[CustomerNo]
            FROM 
                [dbo].[CustomerScore]
            INNER JOIN 
                [dbo].[Customer] ON [dbo].[CustomerScore].NationalCode = [dbo].[Customer].NationalCode
            LEFT JOIN 
                CustomerEvaluationFormInformation ON CustomerEvaluationFormInformation.NationalCode = [dbo].[Customer].NationalCode
                WHERE [CustomerScore].[IsDeleted] = 0 AND [CustomerScore].NationalCode = '{request.NationalCode}'
            GROUP BY 
                [dbo].[CustomerScore].[NationalCode],
                [dbo].[Customer].FirstName,
                dbo.Customer.LastName,
                [dbo].[Customer].[Mobile],
                [dbo].[Customer].[CustomerNo],
                [dbo].[CustomerScore].CreatedAt";

        var customerScores = await _context.Set<CustomerScoreReportEntity>()
                                           .FromSqlRaw(query)
                                           .AsNoTracking()
                                           .ToListAsync(cancellationToken);

        var result = customerScores.Select(x => new CustomerScoreReportResponse
        {
            Score = x.Score,
            CreatedAt = x.CreatedAt,
            CustomerNo = x.CustomerNo,
            FullName = x.FullName,
            Mobile = x.Mobile,
            NationalCode = x.NationalCode,
        });
        return result;
    }
}
