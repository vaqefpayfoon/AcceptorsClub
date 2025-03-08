using System.Collections.Generic;
using AcceptorsClub.Application.Responses;
using MediatR;

namespace AcceptorsClub.Application;
public class CheckCustomerExistQuery : IRequest<CheckCustomerExistResponse>
{
    public string NationalCode { get; set; }

    public CheckCustomerExistQuery(string nationalCode)
    {
        NationalCode = nationalCode;
    }
}