using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alguin.TestStructures;
using AlguinDemo.MockForms;

namespace AlguinDemo.MockScenarios
{
    public class CalcTestData : ITestData
    {
        public string AppPath { get; set; }
        public string MainWindowTitle { get; set; }
        public List<int> Numbers { get; set; }
        public CalcMode Mode { get; set; }
    }
}
