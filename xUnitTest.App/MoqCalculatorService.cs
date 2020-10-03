namespace xUnitTest.App
{
    public class MoqCalculatorService : IMoqCalculatorService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Exception(int a, int b)
        {
            return a + b;
        }
    }
}
