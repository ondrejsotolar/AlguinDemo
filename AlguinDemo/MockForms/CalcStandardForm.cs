using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TestStack.White.UIItems;
using Alguin.Utilities;
using TestStack.White.UIItems.Finders;


namespace AlguinDemo.MockForms
{
    public class CalcStandardForm : CalcBaseForm
    {
        private Button plus, equals;
        private TextBox result;

        public CalcStandardForm(UIItemContainer mainWindow) : base(mainWindow) {}

        public override void InitializeMisc()
        {
            base.InitializeMisc();
            this.plus = this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("93"));
            this.equals = this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("121"));
            this.Result = this.MainWindow.Get(SearchCriteria.ByAutomationId("158"));
        }

        public override void ClickPlus()
        {
            this.plus.ClickAndWait(50);
        }

        public override void ClickEquals()
        {
            this.equals.ClickAndWait();
        }

    }
}
