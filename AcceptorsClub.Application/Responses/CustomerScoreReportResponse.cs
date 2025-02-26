using System;

namespace AcceptorsClub.Application.Responses
{
    public class CustomerScoreReportResponse
    {
        public string? NationalCode { get; set; }
        public string? Mobile { get; set; }
        public long? CustomerNo { get; set; }
        public string? FullName { get; set; }
        public int? Score { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Reason { get; set; }
    }
}