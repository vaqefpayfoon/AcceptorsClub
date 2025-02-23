namespace AcceptorsClub.Core.Models
{
    public class ScorePlan : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summery { get; set; }
        public string FileName { get; set; }
    }
}
