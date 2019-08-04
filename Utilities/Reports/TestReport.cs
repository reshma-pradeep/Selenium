using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWeb.Utilities.Reports
{
    class TestReport
    {
        public List<TestReportSteps> TestReportSteps;

        public TestReport(List<TestReportSteps> testReportSteps)
        {
            TestReportSteps = testReportSteps;
        }

        public List<TestReportSteps> getTestReportSteps()
        {
            return TestReportSteps;
        }
    }
}
