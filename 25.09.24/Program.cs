using System;
using System.Collections.Generic;

namespace HouseBuilding
{
    public interface IPart
    {
        string Name { get; }
        bool IsBuilt { get; set; }
    }

    public class Basement : IPart
    {
        public string Name => "Фундамент";
        public bool IsBuilt { get; set; }
    }

    public class Wall : IPart
    {
        public string Name => "Стена";
        public bool IsBuilt { get; set; }
    }

    public class Door : IPart
    {
        public string Name => "Дверь";
        public bool IsBuilt { get; set; }
    }

    public class Window : IPart
    {
        public string Name => "Окно";
        public bool IsBuilt { get; set; }
    }

    public class Roof : IPart
    {
        public string Name => "Крыша";
        public bool IsBuilt { get; set; }
    }

    public interface IWorker
    {
        void Work(House house);
    }

    public class Worker : IWorker
    {
        public string Name { get; }

        public Worker(string name)
        {
            Name = name;
        }

        public void Work(House house)
        {
            foreach (var part in house.Parts)
            {
                if (!part.IsBuilt)
                {
                    part.IsBuilt = true;
                    Console.WriteLine($"{Name} построил: {part.Name}");
                    break;
                }
            }
        }
    }

    public class TeamLeader : IWorker
    {
        public string Name { get; }

        public TeamLeader(string name)
        {
            Name = name;
        }

        public void Work(House house)
        {
            Console.WriteLine($"{Name} проверяет прогресс строительства:");
            foreach (var part in house.Parts)
            {
                Console.WriteLine($"{part.Name}: {(part.IsBuilt ? "Построено" : "Не построено")}");
            }
        }
    }

    public class Team
    {
        public List<IWorker> Workers { get; }

        public Team(List<IWorker> workers)
        {
            Workers = workers;
        }

        public void Build(House house)
        {
            while (!house.IsBuilt)
            {
                foreach (var worker in Workers)
                {
                    worker.Work(house);
                    if (house.IsBuilt)
                        break;
                }
            }
        }
    }

    public class House
    {
        public List<IPart> Parts { get; }

        public House()
        {
            Parts = new List<IPart>
            {
                new Basement(),
                new Wall(), new Wall(), new Wall(), new Wall(),
                new Door(),
                new Window(), new Window(), new Window(), new Window(),
                new Roof()
            };
        }

        public bool IsBuilt => Parts.TrueForAll(p => p.IsBuilt);

        public void Draw()
        {
            Console.WriteLine("       _____ ");
            Console.WriteLine("      /     \\");
            Console.WriteLine("     /_______\\");
            Console.WriteLine("    |   _ _   |");
            Console.WriteLine("    |  |   |  |");
            Console.WriteLine("   _|__|___|__|_");
            Console.WriteLine("  |            |");
            Console.WriteLine("  |            |");
            Console.WriteLine("  |____________|");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team(new List<IWorker>
            {
                new Worker("Строитель 1"),
                new Worker("Строитель 2"),
                new Worker("Строитель 3"),
                new TeamLeader("Бригадир")
            });

            House house = new House();

            team.Build(house);

            if (house.IsBuilt)
            {
                Console.WriteLine("Строительство дома завершено!");
                house.Draw();
            }
        }
    }
}
