using System.Collections.Generic;
using AcceptorsClub.Application.Responses;
using MediatR;

public record GetALLScorePlanQuery : IRequest<IEnumerable<ScorePlanResponseModel>>;