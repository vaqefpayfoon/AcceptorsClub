
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AcceptorsClub.Application.Commands;
using AcceptorsClub.Application.Responses;
using AcceptorsClub.Core.Models;
using AcceptorsClub.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcceptorsClub.Application;
public class CustomerScoreCommandHandler : IRequestHandler<CustomerScoreCommand, CustomerScore>
{
    private readonly ApplicationDbContext _context;

    public CustomerScoreCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerScore> Handle(CustomerScoreCommand request, CancellationToken cancellationToken)
    {
        CustomerScore customer = new()
        {
            CreatedAt = DateTime.Now,
            CreatedBy = 1,
            IsProfile = false,
            Reason = request.Reason,
            RelatedKey = -1,
            Score = request.Score,
            NationalCode = request.NationalCode,
            OperationType = request.OperationType,
            Key = Guid.NewGuid()
        };
        await _context.CustomerScore.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
}
