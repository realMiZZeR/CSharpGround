using System;
using System.Collections.Generic;
using System.Threading;
using CSharpGround.Features;

namespace CSharpGround
{
    /// Паттерны
    /// Шаблон Adapter - шаблон, где есть родительский класс, который реализует какой-то метод и, например, нужно
    /// поиметь его функционал, но также нужно применить интерфейс.
    /// Для этого создаётся дочерний класс этого родителя, там реализуется интерфейс, а также через base вызывается
    /// необходимый метод.
    /// 
    /// Шаблон Fabric - суть в том, что есть какой-то самый главный класс, который запускает, например, игру (класс Game).
    /// В самом классе Game реализована сама логика игры, расстановка персонажей/объектов(IPlaceable), установка сложности(IGameDifficult).
    /// И получается так, что всё самое необходимое находится в одном месте в классе Game, но вся реалзиация уже разбита по интерфейсам
    /// и реализуюзим их классами.
    /// 
    /// Шаблон Strategy - инкапсулирует алгоритмы и методы, и делает их взаимозаменяемыми. Проще говоря, много классов, реализующие интерфейсы, к примеру
    /// и их последующий апкаст/даункаст в методы.

    /// Типы отношений:
    /// Ассоциация - связывание объектов друг с другом, например, есть класс Team и есть класс Player, в котором есть ссылка на Team team;
    /// Композиция - один объект может принадлежать только другому объекту и никому больше. Основной объект при этом контроллирует весь жизненный цикл объектов.
    /// Агрегация - один объект может являться частью другого
    /// Наследование
    /// Реализация - создание интерфейсов, которые должен реализовывать класс
     
    /// обобщения
    /// инвариантность обязует использовать только тот тип, который был указан в обобщении
    /// ковариантность позволяет использовать в обобщённых интерфейсах более конкретные типы (IEnumerable)
    /// контрвариантность позволяет использовать общие типы взамен конкретных (IComparable) 
    
    /// модификаторы доступа
    /// internal - доступен в любом участке кода, но только в этой сборке
    /// protected internal - доступен из любого места в текущей сборке и из производных классов, которые могут распологаться в других сборках
    /// private protected - доступен в текущем классе и производном
    /// 
    /// sealed - запрещает наследовать и создавать производные классы
    /// volatile - позволяет изменять значения поля одновременно из нескольких потоков
    internal class Program
    {
        List<Feature> features;

        static void Main(string[] args)
        {
            Program program = new Program();

            program.Start();
        }

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
            return new List<Feature>()
            {
                new DriveExplorer(),
                new HTMLParser(),
                new Tasks(),

            };
        }

        private void DoChoice()
        {
            bool isCorrect = int.TryParse(Console.ReadLine(), out int choice);

            foreach(var feature in features)
            {
                if(feature.Id == choice)
                {
                    Console.Clear();
                    feature.Show();
                    return;
                }
            }

            Console.WriteLine("The feature not found, restarting...");
            Restart();
        }

        private void Restart()
        {
            Thread.Sleep(1000);
            Console.Clear();
            Start();
        }
    }
}
