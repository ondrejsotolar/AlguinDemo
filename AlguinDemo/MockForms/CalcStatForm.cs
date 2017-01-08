using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White.UIItems;
using Alguin.Utilities;
using TestStack.White.UIItems.Finders;

namespace AlguinDemo.MockForms
{
    public class CalcStatForm : CalcBaseForm
    {
        private Button plus, equals;

        public CalcStatForm(UIItemContainer mainWindow) : base(mainWindow)
        {
            this.MainWindow = mainWindow;
        }

        public override void InitializeMisc()
        {
            base.InitializeMisc();
            this.plus = this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("168"));
            this.equals = this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("173"));
            this.Result = this.MainWindow.Get(SearchCriteria.ByAutomationId("150"));
        }

        public override void ClickPlus()
        {
            this.plus.ClickAndWait(50);
        }

        public override void ClickEquals()
        {
            this.equals.ClickAndWait(50);
        }
    }
}
