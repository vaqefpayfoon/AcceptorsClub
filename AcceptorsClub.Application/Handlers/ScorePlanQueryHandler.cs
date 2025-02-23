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
public class ScorePlanQueryHandler : IRequestHandler<GetALLScorePlanQuery, IEnumerable<ScorePlanResponseModel>>
{
    private readonly ApplicationDbContext _context;

    public ScorePlanQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ScorePlanResponseModel>> Handle(GetALLScorePlanQuery request, CancellationToken cancellationToken)
    {

        var scorePlan = await _context.ScorePlan.ToListAsync();

        var result = scorePlan.Select(x => new ScorePlanResponseModel
        {
            Id = x.Id,
            Key = x.Key,
            Title = x.Title,
            Description = x.Description,
            Summery = x.Summery,
            FileName = x.FileName
        });
        return result;
    }
}
