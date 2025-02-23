using System;

namespace AcceptorsClub.Application.Responses
{
    public class CompetitionResponseModel
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SurveyType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string FileName { get; set; }
        public string FileURL
        {
            get { return $"{AcceptorsClub.Core.Models.Settings.StartFileRoute}/{AcceptorsClub.Core.Models.FileGroup.Survey}/{FileName}"; }
        }
    }
}
