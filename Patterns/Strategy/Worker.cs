namespace CSharpGround.Patterns.Strategy
{
    public class Worker
    {
        public void StartWork()
        {
            DoWork(new FactoryWorker());
            DoWork(new Programmer());
        }

        public void DoWork(IWork worker)
        {
            worker.Work();
        }
    }
}
