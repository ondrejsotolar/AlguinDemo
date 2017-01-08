using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alguin.TestStructures;
using AlguinDemo.MockForms;

namespace AlguinDemo.MockScenarios
{
    public class CalcAddScenario : CalcBaseScenario
    {
        public CalcAddScenario(CalcTestData testData) : base(testData)
        {
            AddStep(Precondition_OpenCalc);
            AddStep(SwitchMode);
            AddStep(EnterData);
            AddStep(CheckResult);
            AddStep(Postcondition_Close);
        }

        public override IStepResult Precondition_OpenCalc(ITestData data)
        {
            base.Precondition_OpenCalc(null);
            switch (this.TestData.Mode)
            {
                case CalcMode.Statistic:
                    this.MainForm = new CalcStatForm(this.MainWindow);
                    break;
                default:
                    this.MainForm = new CalcStandardForm(this.MainWindow);
                    break;
            }
            
            this.MainForm.InitializeFormControls();
            return null;
        }

        public IStepResult EnterData(ITestData data)
        {
            for (int i = 0; i < this.TestData.Numbers.Count - 1; i++)
            {
                this.MainForm.ClickNumber(this.TestData.Numbers[i]);
                this.MainForm.ClickPlus();
            }
            this.MainForm.ClickNumber(this.TestData.Numbers.Last());
            if (this.TestData.Mode == CalcMode.Statistic)
                this.MainForm.ClickPlus();
            return new StepResult();
        }

        public IStepResult CheckResult(ITestData data)
        {
            this.MainForm.ClickEquals();
            var calcResult = this.MainForm.GetResult();

            var sum = int.Parse(calcResult);
            var expectedSum = this.TestData.Numbers.Sum();
            if (sum != expectedSum)
            {
                var message = string.Format("The sum is different. Expected: {0}, Actual: {1}", expectedSum, sum);
                LogicalFail(message, skipAll: false);
            }
            return null;
        }
    }
}
