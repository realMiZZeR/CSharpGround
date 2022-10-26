using System;
using LearnCSharp.Drives;

namespace LearnCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            program.Start();
        }

        void Start()
        {
            // explorer
            DriveExplorer explorer = new DriveExplorer();
            explorer.Show();

            Console.ReadLine();
        }
    }
}
