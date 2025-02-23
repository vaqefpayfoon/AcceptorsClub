namespace AcceptorsClub.Core.Models;
public class Lottery : BaseEntity<int>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? FileName { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public int BaseScore { get; set; }
    // [NotMapped]
    // public List<CustomerWinnerLottery> LotteryWinners { get; set; }
}