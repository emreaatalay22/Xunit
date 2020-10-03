using System;
using System.Collections.Generic;
using System.Text;

namespace xUnitTest.App
{
    public class MoqCalculator
    {
        private readonly IMoqCalculatorService _calculatorService;

        public MoqCalculator(IMoqCalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public int Add(int a, int b)
        {
            return _calculatorService.Add(a, b);
        }

        public int Exception(int a, int b)
        {
            if (a == 0)
            {
                throw new Exception("a cannot be zero");
            }

            return _calculatorService.Exception(a, b);
        }
    }
}
