using System;

namespace AcceptorsClub.Application.Responses
{
    public class LotteryResponseModel
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int BaseScore { get; set; }
        public string FileName { get; set; }
        // public List<CustomerWinnerLottery> CustomerWinners { get; set; }
        public string FileURL
        {
            get { return $"{AcceptorsClub.Core.Models.Settings.StartFileRoute}/{AcceptorsClub.Core.Models.FileGroup.Lottery}/{FileName}"; }
        }
    }
}