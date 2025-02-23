using System.ComponentModel.DataAnnotations.Schema;

namespace AcceptorsClub.Core.Models;
public class CustomerWinnerLottery : BaseEntity<int>
    {
        public string? WinTitle { get; set; }
        public decimal ScoreSpend { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [NotMapped]
        public Customer Customer { get; set; }
        public int LotteryId { get; set; }
        [ForeignKey("LotteryId")]
        [NotMapped]
        public Lottery Lottery { get; set; }
    }