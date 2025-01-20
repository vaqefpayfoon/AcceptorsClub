using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AcceptorsClub.Application.Responses;
using AcceptorsClub.Core.Models;
using AcceptorsClub.Infrastructure;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AcceptorsClub.Application;
public class SumCustomerScoreQueryHandler : IRequestHandler<SumCustomerScoreQuery, SumCustomerScoreReportResponse>
{
    private readonly ApplicationDbContext _context;

    public SumCustomerScoreQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SumCustomerScoreReportResponse> Handle(SumCustomerScoreQuery request, CancellationToken cancellationToken)
    {
        string query = $@"Select dbo.TotalScore('{request.NationalCode}') As Score";

        var customerScores = await _context.Set<SumCustomerScoreReportEntity>()
                                           .FromSqlRaw(query)
                                           .AsNoTracking()
                                           .ToListAsync(cancellationToken);

        var result = customerScores.FirstOrDefault();
        return new SumCustomerScoreReportResponse
        {
            Score = result.Score
        };
    }
}
