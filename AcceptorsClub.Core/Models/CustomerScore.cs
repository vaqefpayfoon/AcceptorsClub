
namespace AcceptorsClub.Core.Models
{
    public class CustomerScore : BaseEntity<int>
    {
        public string NationalCode { get; set; }
        public Reason Reason { get; set; }
        public OperationType OperationType { get; set; }
        public int Score { get; set; }
        public bool IsProfile { get; set; }
        public int? RelatedKey { get; set; }
    }
}
