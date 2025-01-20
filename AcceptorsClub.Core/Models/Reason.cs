using System.ComponentModel;

namespace AcceptorsClub.Core.Models
{
    public enum Reason
    {
        [Description("همه موارد")]
        NoFilter = -1,
        [Description("شارژ موتور امتیازی")]
        CustomerEvaluationFormInformation = 0,
        [Description("تکمیل پروفایل")]
        CompleteProfile = 1,
        [Description("اولین لاگین")]
        FirstLogin = 2,
        [Description("سالروز تولد")]
        BirthDate = 3,
        [Description("دعوت از دوستان")]
        InviteFriends = 4,
        [Description("شرکت در قرعه کشی")]
        Lottery = 5,
        [Description("شارژ کیف پول")]
        CreditWallet = 6,
        [Description("استفاده از کد تخفیف")]
        DiscountCode = 7,
        [Description("گردونه شانس")]
        Carrousel = 8,
        [Description("نظرسنجی / مسابقه")]
        SurveyAnswer=9,
        [Description("انتقال امتیاز")]
        TransferScore = 10,
        [Description("باشگاه پذیرندگان")]
        AcceptorsClub = 11
    }
}
