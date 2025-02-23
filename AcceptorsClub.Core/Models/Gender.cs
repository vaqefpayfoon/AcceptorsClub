using System.ComponentModel;

namespace AcceptorsClub.Core.Models
{
    public enum Gender
    {
        //1 Male ,2 Female , 0 Others From Dataware House
        [Description("نامشخص")]
        Other = 0,
        [Description("مرد")]
        Male,
        [Description("زن")]
        Female
    }
}
