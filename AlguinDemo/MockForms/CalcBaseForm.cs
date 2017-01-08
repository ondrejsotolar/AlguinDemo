using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowStripControls;
using Alguin.FormStructures;
using Alguin.Utilities;
using TestStack.White.UIItems.Finders;
using TestStack.White.WindowsAPI;

namespace AlguinDemo.MockForms
{
    public enum CalcMode
    {
        Standard = 1,
        Scientific = 2,
        Programmer = 3,
        Statistic = 4
    }

    public abstract class CalcBaseForm : GenericForm
    {
        protected List<Button> Numbers { get; set; }
        protected IUIItem Result { get; set; }
        protected MenuBar MenuBar { get; set; }
        
        public CalcBaseForm(UIItemContainer mainWindow) : base(mainWindow) {}

        public virtual void InitializeFormControls()
        {
            this.MenuBar = this.MainWindow.Get<MenuBar>(SearchCriteria.ByAutomationId("MenuBar"));
        }

        public virtual void InitializeMisc()
        {
            this.Numbers = new List<Button>(10);
            Numbers.Add(this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("130")));
            Numbers.Add(this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("131")));
            Numbers.Add(this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("132")));
            Numbers.Add(this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("133")));
            Numbers.Add(this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("134")));
            Numbers.Add(this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("135")));
            Numbers.Add(this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("136")));
            Numbers.Add(this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("137")));
            Numbers.Add(this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("138")));
            Numbers.Add(this.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("139")));
        }

        public void SwitchMode(CalcMode mode)
        {
            this.MainWindow.Focus();
            this.MainWindow.Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            this.MainWindow.Keyboard.Enter(((int)mode).ToString());
            this.MainWindow.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            InteractionTimeout.Wait(1000);
            this.InitializeMisc();
        }

        public void ClickNumber(int number)
        {
            var digits = new List<int>();
            if (number == 0)
            {
                digits.Add(number);
                return;
            }
            while (number > 0)
            {
                digits.Add(number % 10);
                number = number / 10;
            }
            digits.Reverse();
            for (int i = 0; i < digits.Count; i++)
            {
                this.Numbers[digits[i]].ClickAndWait(50);
            }
        }

        public string GetResult()
        {
            return this.Result.Name;
        }

        public abstract void ClickPlus();
        public abstract void ClickEquals();
    }
}
