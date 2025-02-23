using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AcceptorsClub.Application.Responses;
using AcceptorsClub.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcceptorsClub.Application;
public class CompetitionQueryHandler : IRequestHandler<GetCompetitionQuery, IEnumerable<CompetitionResponseModel>>
{
    private readonly ApplicationDbContext _context;

    public CompetitionQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CompetitionResponseModel>> Handle(GetCompetitionQuery request, CancellationToken cancellationToken)
    {
        var lottery = await _context.Survey.Where(x => x.SurveyType == 2 && DateTime.Now.Date >= x.StartDate.Date && DateTime.Now.Date <= x.EndDate.Date).ToListAsync();

        var result = lottery.Select(x => new CompetitionResponseModel
        {
            Id = x.Id,
            Key = x.Key,
            Title = x.Title,
            Description = x.Description,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            SurveyType = x.SurveyType,
            FileName = x.FileName
        });
        return result;
    }
}
