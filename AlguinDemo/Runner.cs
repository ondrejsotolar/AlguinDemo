using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlguinDemo.MockScenarios;
using AlguinDemo.MockForms;

namespace AlguinDemo
{
    public class Runner
    {
        private string appPath = @"C:\Windows\System32\calc.exe";
        private string title = "Calculator";
        private List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public void Run()
        {
            TestAdd_Standard_en();
            TestAdd_Scientific_en();
            TestAdd_Programmer_en();
            TestAdd_Statistic_en();
        }

        private void TestAdd_Standard_en()
        {
            var testData = GetTestData(CalcMode.Standard);
            var calcScenar = new CalcAddScenario(testData);
            calcScenar.RunAllSteps();
        }

        private void TestAdd_Scientific_en()
        {
            var testData = GetTestData(CalcMode.Scientific);
            var calcScenar = new CalcAddScenario(testData);
            calcScenar.RunAllSteps();
        }

        private void TestAdd_Programmer_en()
        {
            var testData = GetTestData(CalcMode.Programmer);
            var calcScenar = new CalcAddScenario(testData);
            calcScenar.RunAllSteps();
        }

        private void TestAdd_Statistic_en()
        {
            var testData = GetTestData(CalcMode.Statistic);
            var calcScenar = new CalcAddScenario(testData);
            calcScenar.RunAllSteps();
        }

        private CalcTestData GetTestData(CalcMode mode)
        {
            return new CalcTestData()
            {
                AppPath = appPath,
                MainWindowTitle = title,
                Numbers = numbers,
                Mode = mode,
            };
        }
    }
}
