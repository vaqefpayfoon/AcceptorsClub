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
        [Description("باشگاه پذیرندگان /ثبت نام")]
        AcceptorsClubSignUp = 100,

        [Description("باشگاه پذیرندگان /دعوت از دوستان")]
        AcceptorsClubInvitation = 101,
        [Description("باشگاه پذیرندگان /روز تولد")]
        AcceptorsClubBirthDate = 102,
        [Description("باشگاه پذیرندگان /شرکت در نظرسنجی دوره ای	")]
        AcceptorsClubSurvey = 103,
        [Description("باشگاه پذیرندگان /شرکت نظر سنجی امتیازی")]
        AcceptorsClubSurveyScore = 104,
        [Description("باشگاه پذیرندگان /ثبت تیکت")]
        AcceptorsClubTicket = 105,
        [Description("باشگاه پذیرندگان /انتقادات و پیشنهادات	")]
        AcceptorsClubSuggestion = 106,
        [Description("باشگاه پذیرندگان /ثبت درخواست پایانه فروشگاهی-درگاه اینترنتی")]
        AcceptorsClubTerminal = 108,
        [Description("باشگاه پذیرندگان /تکمیل پروفایل")]
        AcceptorsClubProfile = 109,
    }
}
