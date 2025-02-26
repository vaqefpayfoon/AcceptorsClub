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
                dbo.CustomerScore.Score,
                TRIM([dbo].[Customer].FirstName) + ' ' + TRIM(dbo.Customer.LastName) AS FullName,
                [dbo].[Customer].[CustomerNo],
                CASE WHEN Reason = 1 THEN N'تکمیل پروفایل'
                WHEN Reason = 2 THEN N'اولین لاگین'
                WHEN Reason = 3 THEN N'سالروز تولد'
                WHEN Reason = 4 THEN N'دعوت از دوستان'
                WHEN Reason = 5 THEN N'شرکت در قرعه کشی'
                WHEN Reason = 6 THEN N'شارژ کیف پول'
                WHEN Reason = 7 THEN N'استفاده از کد تخفیف'
                WHEN Reason = 8 THEN N'گردونه شانس'
                WHEN Reason = 9 THEN N'نظرسنجی / مسابقه'
                WHEN Reason = 10 THEN N'انتقال امتیاز'
                WHEN Reason = 11 THEN N'باشگاه پذیرندگان'
                ELSE N'موتور امتیازی' END AS Reason
            FROM 
                [dbo].[CustomerScore]
            INNER JOIN 
                [dbo].[Customer] ON [dbo].[CustomerScore].NationalCode = [dbo].[Customer].NationalCode
            LEFT JOIN 
                CustomerEvaluationFormInformation ON CustomerEvaluationFormInformation.NationalCode = [dbo].[Customer].NationalCode
                WHERE [CustomerScore].[IsDeleted] = 0 AND [CustomerScore].NationalCode = '0013741594'
            GROUP BY 
                [dbo].[CustomerScore].[NationalCode],
                [dbo].[Customer].FirstName,
                [dbo].[Customer].LastName,
                [dbo].[Customer].[Mobile],
                [dbo].[Customer].[CustomerNo],
                [dbo].[CustomerScore].CreatedAt,
                [dbo].[CustomerScore].Reason,
				[dbo].[CustomerScore].Score";

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
            Reason = x.Reason,
        });
        return result;
    }
}
