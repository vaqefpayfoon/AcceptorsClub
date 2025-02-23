namespace AcceptorsClub.Core.Models
{
    public class Survey : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SurveyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FileName { get; set; }
    }
}
