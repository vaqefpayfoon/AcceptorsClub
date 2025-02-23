using System;

namespace AcceptorsClub.Application.Responses
{
    public class ScorePlanResponseModel
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summery { get; set; }
        public string FileName { get; set; }
        public string FileURL
        {
            get { return $"{AcceptorsClub.Core.Models.Settings.StartFileRoute}/{AcceptorsClub.Core.Models.FileGroup.ScorePlan}/{FileName}"; }
        }
    }
}