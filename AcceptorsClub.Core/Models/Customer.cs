using System.ComponentModel.DataAnnotations.Schema;

namespace AcceptorsClub.Core.Models;
public class Customer : BaseEntity<int>
{
    public string? Password { get; set; }
    public Gender Gender { get; set; }
    public long CustomerNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public bool IsActive { get; set; }
    public bool IsFirstTime { get; set; }
    public string? Mobile { get; set; }
    public DateTime BirthDate { get; set; }
    [NotMapped]
    public List<CustomerWinnerLottery> LotteryWinners { get; set; }
    [NotMapped]
    public List<Lottery> Lotteries { get; set; }
}