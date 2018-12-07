using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utilities
{
    public class TestOutcome
    {
        public DateTime Date { get; set; }
        public string TestName { get; set; }
        public UnitTestOutcome TestResult { get; set; }
    }

    public class TestsExecutionResult
    {
        public static List<TestOutcome> TestsExecutionResultList
        {
            get => _testsExecutionResultList ?? (_testsExecutionResultList = new List<TestOutcome>());
            set => _testsExecutionResultList = value;
        }

       private static List<TestOutcome> _testsExecutionResultList;
    }

}
