using System;

namespace AcceptorsClub.Core.Models
{
    public class CustomerScoreReportEntity
    {
        public string? NationalCode { get; set; }
        public string? Mobile { get; set; }
        public long? CustomerNo { get; set; }
        public string? FullName { get; set; }
        public long? Score { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}