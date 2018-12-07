using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace BlueGreenOwner
{
    public class CancelReservationsPage
    {

		public CancelReservationsPage()
		{

		}
      public CancelReservationsPage(IWebDriver driver)
		{

			PageFactory.InitElements(driver, this);

		}
		[FindsBy(How = How.XPath, Using = "//*[@id='home-page-errors']//p[text()='You have Points that need to be saved.']")]
            public IWebElement BacktoMyReservation;
            public By locatorforBacktoMyReservation = By.XPath("//*[@id='save-points-form']//p[@class='callout']");

            [FindsBy(How = How.Id, Using = "txtCreditCardName")]
            public IWebElement CreditCardName;
            public By locatorforCreditCardName = By.Id("txtCreditCardName");

            [FindsBy(How = How.Id, Using = "txtbxCcnum")]
            public IWebElement CreditCardNum;
            public By locatorforCreditCardNum = By.Id("txtbxCcnum");


            [FindsBy(How = How.Id, Using = "CardType")]
            public IWebElement CardType;
            public By locatorforCardType = By.Id("CardType");

            [FindsBy(How = How.Id, Using = "ddlCcmonth")]
            public IWebElement ddlcMonth;
            public By locatorforddlcMonth = By.Id("ddlCcmonth");

            [FindsBy(How = How.Id, Using = "ddlCcyear")]
            public IWebElement ddlcYear;
            public By locatorforddlcYear = By.Id("ddlCcyear");


            [FindsBy(How = How.Id, Using = "txtCCZipcode")]
            public IWebElement ZipCode;
            public By locatorforZipCode = By.Id("txtCCZipcode");

            [FindsBy(How = How.Id, Using = "FeeAmount")]
            public IWebElement FeeAmount;
            public By locatorforFeeAmount = By.Id("FeeAmount");

            [FindsBy(How = How.Id, Using = "imgbtnSubmit")]
            public IWebElement SubmitPayment;
            public By locatorforSubmitPayment = By.Id("imgbtnSubmit");

            [FindsBy(How = How.Id, Using = "btnCancel")]
            public IWebElement BtnCancelReservation;
            public By locatorforBtnCancelReservation = By.Id("btnCancel");


            [FindsBy(How = How.XPath, Using = ".//*[@id='message']//child::b[text()]")]
            public IWebElement MsgCancelConfirmation;
            public By locatorforMsgCancelConfirmation = By.XPath(".//*[@id='message']//child::b[text()]");

            [FindsBy(How = How.Id, Using = "lblScenaries")]
            public IWebElement MsgCancelationInfo;
            public By locatorforMsgCancelationInfo = By.Id("lblScenaries");

            [FindsBy(How = How.Id, Using = "lblConfNum")]
            public IWebElement reservationConfirmationNumber;
            public By locatorforreservationConfirmationNumber = By.Id("lblConfNum");


            [FindsBy(How = How.XPath, Using = "((.//*[@id='Panel2']//table[@class='text'])[2])//a[@href='myReservations.aspx']")]
            public IWebElement BtnBacktoReservationInCancellationConfirmedPage;
            public By locatorforBtnBacktoReservationInCancellationConfirmedPage = By.XPath("((.//*[@id='Panel2']//table[@class='text'])[2])//a[@href='myReservations.aspx']");


            [FindsBy(How = How.Id, Using = "lblReservation")]
            public IWebElement CancelPageConfirmationNumber;
            public By locatorforCancelPageConfirmationNumber = By.Id("lblReservation");

            [FindsBy(How = How.Id, Using = "lblDateCancelled")]
            public IWebElement CancelPageCancelledDate;
            public By locatorforCancelPageCancelledDate = By.Id("lblReservation");


            [FindsBy(How = How.Id, Using = "lblResortName")]
            public IWebElement CancelPageResortName;
            public By locatorforCancelPageResortName = By.Id("lblResortName");


            [FindsBy(How = How.Id, Using = "lblResType")]
            public IWebElement CancelPageType;
            public By locatorforCancelPageType = By.Id("lblResType");

            [FindsBy(How = How.Id, Using = "lblPoints")]
            public IWebElement CancelPagePoints;
            public By locatorforCancelPagePoints = By.Id("lblPoints");

         //   public string UrlMyPointsPage = "";
        }
    }

