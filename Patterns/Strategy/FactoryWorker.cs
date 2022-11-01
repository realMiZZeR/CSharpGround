using System;

namespace CSharpGround.Patterns.Strategy
{
    public class FactoryWorker : IWork
    {
        public void Work()
        {
            Console.WriteLine("Работает заводчанин.");
        }
    }
}
