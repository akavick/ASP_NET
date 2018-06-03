namespace Test_007.Services
{
    public class CounterService
    {
        public ICounter Counter { get; }

        public CounterService(ICounter counter) => Counter = counter;
    }
}