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
public class LotteryQueryHandler : IRequestHandler<GetLotteryListQuery, IEnumerable<LotteryResponseModel>>
{
    private readonly ApplicationDbContext _context;

    public LotteryQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LotteryResponseModel>> Handle(GetLotteryListQuery request, CancellationToken cancellationToken)
    {

        
        var lottery = await _context.Lottery.Where(x => x.FromDate <= DateTime.Now.Date && x.ToDate >= DateTime.Now.Date).ToListAsync();

        var winners = await _context.CustomerWinnerLottery.OrderByDescending(x => x.CreatedAt).Take(100).Join(
            _context.Customer,
            winner => winner.CustomerId,
            customer => customer.Id,
            (winner, customer) => new CustomerWinnerResponse
            {
                FullName = customer.FirstName.Trim() + customer.LastName.Trim(),
                NationalCode = customer.NationalCode,
                Mobile = customer.Mobile,
            }
        ).ToListAsync();

        var result = lottery.Select(x => new LotteryResponseModel
        {
            Id = x.Id,
            Key = x.Key,
            Title = x.Title,
            Description = x.Description,
            FromDate = x.FromDate,
            ToDate = x.ToDate,
            BaseScore = x.BaseScore,
            FileName = x.FileName,
            CustomerWinners = winners
        });
        return result;
    }
}
