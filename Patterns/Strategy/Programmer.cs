using System;

namespace CSharpGround.Patterns.Strategy
{
    public class Programmer : IWork
    {
        public void Work()
        {
            Console.WriteLine("Работает прыщавый");
        }
    }
}
