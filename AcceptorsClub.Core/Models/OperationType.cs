using System.ComponentModel;

namespace AcceptorsClub.Core.Models
{
    public enum OperationType
    {
        [Description("شارژ")]
        Charge = 0,
        [Description("خرج کرد")]
        SpentScore = 1
    }
}
