using System.Collections.Generic;
using AcceptorsClub.Application.Responses;
using MediatR;

namespace AcceptorsClub.Application;
public class CustomerScoreQuery : IRequest<IEnumerable<CustomerScoreReportResponse>>
{
    public string NationalCode { get; set; }

    public CustomerScoreQuery(string nationalCode)
    {
        NationalCode = nationalCode;
    }
}