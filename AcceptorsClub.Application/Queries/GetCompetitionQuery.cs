using System.Collections.Generic;
using AcceptorsClub.Application.Responses;
using MediatR;

public record GetCompetitionQuery : IRequest<IEnumerable<CompetitionResponseModel>>;