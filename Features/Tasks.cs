using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpGround.Features
{
    internal class Tasks : Feature
    {
        public override int Id => 3;

        public override string Name => "Tasks";

        public override void Show()
        {
            ContinuousTask();
        }

        private void NestedTasks()
        {
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task is starting...");

                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inner task is starting...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Inner task finished...");
                }, TaskCreationOptions.AttachedToParent); // или можно передать такой параметр и будет то же самое

                Console.WriteLine("Outer task finished.");
                // inner.Wait(); // если убрать, то вызов консоли с End будет быстрее
            });

            outer.Wait();
            Console.WriteLine("End");
        }

        private void ArrayTask()
        {
            Task[] tasks = new Task[3];

            for(var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Task{i} finished");
                });
                tasks[i].Start();
            }

            Console.WriteLine("Main ended");

            Task.WaitAll(tasks);
        }

        private void TaskResult()
        {
            Task<Person> defaultPersonTask = new Task<Person>(() => new Person("Max", 20));
            defaultPersonTask.Start();

            Person defaultPerson = defaultPersonTask.Result;
            Console.WriteLine($"{defaultPerson.Name} - {defaultPerson.Age}");
        }

        class Person
        {
            public string Name;
            public int Age;

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        private void ContinuousTask()
        {
            Task task1 = new Task(() => Console.WriteLine($"Current Task: {Task.CurrentId}"));

            Task task2 = task1.ContinueWith(PrintTask);
            Task task3 = task2.ContinueWith(task => PrintTask(task));
            Task task4 = task3.ContinueWith(task => PrintTask(task));

            task1.Start();
            task4.Wait();

            Console.Write("Enter X value: ");
            bool hasX = int.TryParse(Console.ReadLine(), out int x);
            Console.Write("Enter Y value: ");
            bool hasY = int.TryParse(Console.ReadLine(), out int y);

            Task<int> task5 = new Task<int>(() => x + y);
            Task task6 = task5.ContinueWith(task => Console.WriteLine($"{x} + {y} = {task5.Result}"));

            task5.Start();
            task6.Wait();

            Console.WriteLine("Main ended");
        }

        private void PrintTask(Task t)
        {
            Console.WriteLine($"ID задачи: {Task.CurrentId}");
            Console.WriteLine($"ID предыдущей задачи: {t.Id}");

            Thread.Sleep(1000);
        }
    }
}
