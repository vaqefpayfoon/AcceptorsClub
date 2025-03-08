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
public class CheckCustomerExistQueryHandler : IRequestHandler<CheckCustomerExistQuery, CheckCustomerExistResponse>
{
    private readonly ApplicationDbContext _context;

    public CheckCustomerExistQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CheckCustomerExistResponse> Handle(CheckCustomerExistQuery request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customer.FirstOrDefaultAsync(x => x.NationalCode == request.NationalCode);
        if(customer == null)
        {
            throw new Exception("not found");
        }
        CheckCustomerExistResponse response = new ()
        {
            Id = customer.Id,
            Key = customer.Key,
            BirthDate = customer.BirthDate,
            CustomerNo = customer.CustomerNo,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Gender = customer.Gender,
            Mobile = customer.Mobile,
            NationalCode = customer.NationalCode,
            IsActive = customer.IsActive,
            IsFirstTime = customer.IsFirstTime,
        };
        return response;
    }
}
