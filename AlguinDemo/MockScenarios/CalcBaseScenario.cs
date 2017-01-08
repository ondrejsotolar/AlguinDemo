using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlguinDemo.MockForms;
using Alguin.TestStructures;
using TestStack.White.UIItems.WindowItems;
using Alguin.AppWrapper;
using Alguin.Utilities;

namespace AlguinDemo.MockScenarios
{
    public class CalcBaseScenario : GenericScenario
    {
        #region Attributes

        protected CalcBaseForm MainForm { get; set; }
        protected Window MainWindow { get; set; }
        public CalcTestData TestData { get; set; }

        #endregion

        public CalcBaseScenario(CalcTestData testData) : base()
        {
            this.TestData = testData;
        }

        public virtual IStepResult Precondition_OpenCalc(ITestData data)
        {
            base.AppWrapper = new ApplicationWrapper(this.TestData.AppPath);
            this.MainWindow = this.AppWrapper.GetWindow(title: this.TestData.MainWindowTitle);

            var result = new StepResult();
            if (this.MainWindow == null)
            {
                LogicalFail("Window didn't open in specified time.", true);
                return result;
            }
            InteractionTimeout.Wait(1000);
            return result;
        }

        public IStepResult SwitchMode(ITestData data)
        {
            this.MainForm.SwitchMode(this.TestData.Mode);
            return null;
        }

        public IStepResult Postcondition_Close(ITestData data)
        {
            this.AppWrapper.Dispose();
            WrapperPool.ClearWrapperPool();
            return null;
        }
    }
}
