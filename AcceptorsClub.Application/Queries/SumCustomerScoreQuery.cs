using System.Collections.Generic;
using AcceptorsClub.Application.Responses;
using MediatR;

namespace AcceptorsClub.Application;
public class SumCustomerScoreQuery : IRequest<SumCustomerScoreReportResponse>
{
    public string NationalCode { get; set; }

    public SumCustomerScoreQuery(string nationalCode)
    {
        NationalCode = nationalCode;
    }
}