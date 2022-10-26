using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using CSharpGround.FileSystem;

namespace CSharpGround
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            program.Start();
        }

        List<Feature> features;

        private delegate void HandleStart();

        void Start()
        {
            PresentMenu();

            // end of the program
            Console.ReadLine();
        }

        private void PresentMenu()
        {
            features = FindFeatures();

            Console.WriteLine("Choose one:");
            for (int i = 0; i < features.Count; i++)
                Console.WriteLine($"{features[i].Id} - {features[i].Name}");

            DoChoice();
        }

        private List<Feature> FindFeatures()
        {
            //var assembl = Assembly.GetAssembly(typeof(Feature));
            //Console.WriteLine(assembl.GetTypes()[2]);

            return new List<Feature>()
            {
                new DriveExplorer()
            };
        }

        private void DoChoice()
        {
            bool isCorrect = int.TryParse(Console.ReadLine(), out int choice);

            foreach(var feature in features)
            {
                if(feature.Id != choice)
                {
                    Console.WriteLine("The feature not found, restarting...");

                    Thread.Sleep(1000);
                    Console.Clear();
                    Start();
                }

                Console.Clear();
                feature.Show();         
            }
        }
    }
}
