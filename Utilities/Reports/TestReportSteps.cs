using System;

namespace SampleWeb.Utilities.Reports
{
    class TestReportSteps
    {
        public string testObjective;
        public string stepName;
        public string stepDescription;
        public string expectedResult;
        public string actualResultPass;
        public string actualResultFail;

        /**
     * Retrieve test objective 
     */
        public string getTestObjective()
        {
            return testObjective;
        }

        /**
        * Set test objective
        */
        public void setTestObjective(string testObjective)
        {
            this.testObjective = testObjective;
        }

        /**
        * Retrieve step name
        */
        public string getStepName()
        {
            return stepName;
        }

        /**
        * Set step name
        */
        public void setStepName(string stepName)
        {
            this.stepName = stepName;
        }

        /**
        * Retrieve step description
        */
        public string getStepDescription()
        {
            return stepDescription;
        }

        /**
        * Set step description
        */
        public void setStepDescription(string stepDescription)
        {
            this.stepDescription = stepDescription;
        }

        /**
        * Retrieve expected result
        */
        public string getExpectedResult()
        {
            return expectedResult;
        }

        /**
        * Set expected result
        */
        public void setExpectedResult(string expectedResult)
        {
            this.expectedResult = expectedResult;
        }

        /**
        * Retrieve actual result for test pass 
        */
        public string getActualResultPass()
        {
            return actualResultPass;
        }

        /**
        * Set actual result for test pass 
        */
        public void setActualResultPass(string actualResultPass)
        {
            this.actualResultPass = actualResultPass;
        }

        /**
        * Generate actual result for test fail 
        */
        public string getActualResultFail()
        {
            return actualResultFail;
        }

        /**
        * Set actual result for test fail
        */
        public void setActualResultFail(string actualResultFail)
        {
            this.actualResultFail = actualResultFail;
        }
    }
}
