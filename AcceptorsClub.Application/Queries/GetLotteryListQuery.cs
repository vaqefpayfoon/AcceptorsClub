using System.Collections.Generic;
using AcceptorsClub.Application.Responses;
using MediatR;

public record GetLotteryListQuery : IRequest<IEnumerable<LotteryResponseModel>>;