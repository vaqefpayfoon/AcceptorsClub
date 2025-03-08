using System;
using AcceptorsClub.Core.Models;

namespace AcceptorsClub.Application.Responses
{
    public class CheckCustomerExistResponse
    {
        public int Id { get; set; }
        public Guid Key { get; set;}
        public Gender Gender { get; set; }
        public long CustomerNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsFirstTime { get; set; }
        public string? Mobile { get; set; }
        public DateTime BirthDate { get; set; }
    }
}