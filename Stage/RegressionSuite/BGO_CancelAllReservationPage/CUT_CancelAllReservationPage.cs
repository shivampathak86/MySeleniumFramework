using BlueGreenOwner;
using BlueGreenOwner.TestCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CodedUITestProject
{

	[CodedUITest]
	public class CUT_CancelAllReservationPage : BaseClass_BGOLogin
	{
		public CUT_CancelAllReservationPage()
		{
		}



		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\stg-data.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'", "DATA_TestCase01_TaskId98721$", DataAccessMethod.Sequential), TestMethod]
		[TestProperty("TestDescription", "TestCase01_Task98721 _Cancel all Reservations in My Reservation page ")]

		public void TestCase01_Task98721_CancelAllReservations()
		{
			ChoicePrivileges.ValidateCancelAllReservations(TestContext);

		}


		public TestContext testContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		private TestContext testContextInstance;


	}


}
