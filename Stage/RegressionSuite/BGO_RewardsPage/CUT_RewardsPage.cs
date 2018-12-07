using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
namespace CodedUITestProject
{
    
    [CodedUITest]
    public class CUT_RewardsPage:BaseClass
    {
        public CUT_RewardsPage()
        {
        }

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            LoginMethod loginMethod = new LoginMethod();
            loginMethod.InitializeBrowser(BrowserType.HeadlessChrome);
        }

        [ClassCleanup]
        public static void ClassClean()
        {
            TearDown(driver);

        }


        [TestCategory("Full Regression"), TestCategory("Rewards"), TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify The Functionality Of Refer A Friend Page.")]

        public void TC_59586_VerifyFunctionalityOfRegisterAFriendPage()
        {
            Login(TestContext, 94, "Arvact", "", "default");

            Rewards.inviteAFriend("", TestContext);

        }


        [TestCategory("Full Regression"), TestCategory("Rewards")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify The Rewards Tab Options Form Sampler Owner")]

        public void TC_59592_VerifyRewardsTabForSampler()
        {
            Login(TestContext, 95, "Arvact", "", "default");

            Rewards.TabsForSamplerOwner("", TestContext);

        }

    }
}

       
