using System;


  
namespace AbstractFactoryPattern
{
    // Интерфейс для кнопки
    public interface IButton
    {
        string GetColor();
    }

    // Интерфейс для окна
    public interface IWindow
    {
        string GetColor();
    }

    // Кнопка для тёмной темы
    public class DarkButton : IButton
    {
        public string GetColor() => "Тёмная кнопка.";
    }

    // Окно для тёмной темы
    public class DarkWindow : IWindow
    {
        public string GetColor() => "Тёмное окно.";
    }

    // Кнопка для светлой темы
    public class LightButton : IButton
    {
        public string GetColor() => "Светлая кнопка.";
    }

    // Окно для светлой темы
    public class LightWindow : IWindow
    {
        public string GetColor() => "Светлое окно.";
    }

    // Интерфейс фабрики
    public interface IThemeFactory
    {
        IButton CreateButton();
        IWindow CreateWindow();
    }

    // Фабрика тёмной темы
    public class DarkThemeFactory : IThemeFactory
    {
        public IButton CreateButton() => new DarkButton();
        public IWindow CreateWindow() => new DarkWindow();
    }

    // Фабрика светлой темы
    public class LightThemeFactory : IThemeFactory
    {
        public IButton CreateButton() => new LightButton();
        public IWindow CreateWindow() => new LightWindow();
    }

    // Класс Компьютер
    public class Computer
    {
        public string Processor { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set; }

        public override string ToString()
        {
            return $"Процессор: {Processor}\n" +
                   $"Оперативная память: {RAM}\n" +
                   $"Жёсткий диск: {Storage}\n" +
                   $"Видеокарта: {GraphicsCard}\n";
        }
    }

    // Интерфейс Построителя
    public interface IComputerBuilder
    {
        void BuildProcessor();
        void BuildRAM();
        void BuildStorage();
        void BuildGraphicsCard();
        Computer GetComputer();
    }

    // Строитель для игрового компьютера
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void BuildProcessor() => _computer.Processor = "Intel Core i9";
        public void BuildRAM() => _computer.RAM = "32 ГБ";
        public void BuildStorage() => _computer.Storage = "2 ТБ SSD";
        public void BuildGraphicsCard() => _computer.GraphicsCard = "NVIDIA RTX 3080";

        public Computer GetComputer() => _computer;
    }

    // Строитель для офисного компьютера
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void BuildProcessor() => _computer.Processor = "AMD Ryzen 5";
        public void BuildRAM() => _computer.RAM = "16 ГБ";
        public void BuildStorage() => _computer.Storage = "1 ТБ HDD";
        public void BuildGraphicsCard() => _computer.GraphicsCard = "Встроенная видеокарта";

        public Computer GetComputer() => _computer;
    }

    // Директор, который управляет процессом строительства
    public class ComputerDirector
    {
        private readonly IComputerBuilder _builder;

        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public Computer Construct()
        {
            _builder.BuildProcessor();
            _builder.BuildRAM();
            _builder.BuildStorage();
            _builder.BuildGraphicsCard();
            return _builder.GetComputer();
        }
    }

    // Клиентский код для выбора темы
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем игровую сборку
            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            ComputerDirector gamingDirector = new ComputerDirector(gamingBuilder);
            Computer gamingComputer = gamingDirector.Construct();

            Console.WriteLine("Игровой компьютер:\n");
            Console.WriteLine(gamingComputer);

            // Создаем офисную сборку
            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            ComputerDirector officeDirector = new ComputerDirector(officeBuilder);
            Computer officeComputer = officeDirector.Construct();

            Console.WriteLine("Офисный компьютер:\n");
            Console.WriteLine(officeComputer);
            Console.WriteLine("Выберите тему: 1 - Тёмная, 2 - Светлая");
            string choice = Console.ReadLine();
            IThemeFactory themeFactory;

            if (choice == "1")
            {
                themeFactory = new DarkThemeFactory();
            }
            else
            {
                themeFactory = new LightThemeFactory();
            }

            IWindow window = themeFactory.CreateWindow();
            IButton button = themeFactory.CreateButton();

            Console.WriteLine(window.GetColor());
            Console.WriteLine(button.GetColor());
        }
    }
}