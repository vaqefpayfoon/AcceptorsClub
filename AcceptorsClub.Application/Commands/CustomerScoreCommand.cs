using AcceptorsClub.Application.Responses;
using AcceptorsClub.Core.Models;
using MediatR;

namespace AcceptorsClub.Application.Commands
{
    public class CustomerScoreCommand : IRequest<CustomerScore>
    {
        public string NationalCode { get; set; }
        public int Score { get; set; }
        public Reason Reason { get; set; }
        public OperationType OperationType { get; set; }
    }
}