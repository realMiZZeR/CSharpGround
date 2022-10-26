using System;
using CSharpGround.Drives;

namespace CSharpGround
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
