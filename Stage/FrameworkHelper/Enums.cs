namespace Utilities
{
    public enum Timeout
    {
        // 
        LongwaitInSecond = 60,
        ShortwaitInSecond = 25,
        PageLoadTimeInSecond = 100,
        ImplicitWaitInSecond = 1,
        VeryShortWaitInSecond = 15,
        TimeoutInMilSecond = 5000
    }

    public enum BrowserType
    {
        Firefox,
        Chrome,
        Ie,
        PhantomJs,
        HeadlessChrome
    }


    public enum ACHpaymentOption
    {
        CheckingAccount,
        SavingsAccount

    }

    public enum GuestRelationship
    {
        Family,
        Friend,
        Renter,
        Other
    }

    public enum GuestType
    {
        Owner,
        Guest,
        AddNewGuest
    }

    public enum OwnerType
    {
        NonVC_SingleAssociation,
        PastDue_TPexpired,
        SamplerOrSampler24
    }









}




