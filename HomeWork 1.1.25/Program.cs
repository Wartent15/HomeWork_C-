using System;

namespace FoodDelivery
{
    public interface IDelivery
    {
        void Prepare();
        void Pack();
        void Deliver();
    }

    public class PizzaDelivery : IDelivery
    {
        public void Prepare() 
        { 
            Console.WriteLine("Готовим пиццу...");
        }
        public void Pack() 
        {
            Console.WriteLine("Пицца упаковывается в коробку.");
        }
        public void Deliver()
        {
            Console.WriteLine("Пицца доставляется в коробке.");
        }
    }

    public class SushiDelivery : IDelivery
    {
        public void Prepare()  
        {
            Console.WriteLine("Готовим суши..."); 
        }
        public void Pack() 
        { 
            Console.WriteLine("Суши упаковываются в контейнер."); 
        }
        public void Deliver()  
        {
            Console.WriteLine("Суши доставляются в контейнере.");
        }
    }

    public class BurgerDelivery : IDelivery
    {
        public void Prepare()
        {
            Console.WriteLine("Готовим бургер...");
        }
        public void Pack() 
        {
            Console.WriteLine("Бургер упаковывается в упаковку на вынос."); 
        }
        public void Deliver()  
        {
            Console.WriteLine("Бургер доставляется в упаковке на вынос."); 
        }
    }

    public abstract class DeliveryFactory
    {
        public abstract IDelivery CreateDelivery();
    }

    public class PizzaDeliveryFactory : DeliveryFactory
    {
        public override IDelivery CreateDelivery() 
        { 
            return new PizzaDelivery();
        }
    }

    public class SushiDeliveryFactory : DeliveryFactory
    {
        public override IDelivery CreateDelivery()
        {
            return new SushiDelivery();
        }
    }

    public class BurgerDeliveryFactory : DeliveryFactory
    {
        public override IDelivery CreateDelivery()  
        { 
            return new BurgerDelivery();
        }
    }


    public interface IOrderSetPrototype
    {
        IOrderSetPrototype Clone();
    }

    public class OrderSet : IOrderSetPrototype
    {
        public string Name { get; }
        private List<string> items;

        public OrderSet(string name, List<string> items)
        {
            Name = name;
            this.items = new List<string>(items);
        }

        public void ShowItems()
        {
            Console.WriteLine($"Набор '{Name}': {string.Join(", ", items)}");
        }

        public IOrderSetPrototype Clone()
        {
            return new OrderSet(Name, items);
        }

        public void ModifyItems(Action<List<string>> modifyAction)
        {
            modifyAction(items);
        }
    }

    class Program
    {
        static void Main()
        {
            DeliveryFactory pizzaFactory = new PizzaDeliveryFactory();
            IDelivery pizza = pizzaFactory.CreateDelivery();
            pizza.Prepare();
            pizza.Pack();
            pizza.Deliver();

            Console.WriteLine();

            DeliveryFactory sushiFactory = new SushiDeliveryFactory();
            IDelivery sushi = sushiFactory.CreateDelivery();
            sushi.Prepare();
            sushi.Pack();
            sushi.Deliver();

            Console.WriteLine();

            DeliveryFactory burgerFactory = new BurgerDeliveryFactory();
            IDelivery burger = burgerFactory.CreateDelivery();
            burger.Prepare();
            burger.Pack();
            burger.Deliver();

            var festiveSet = new OrderSet("Праздничный", new List<string> { "Пицца", "Суши", "Бургер" });
            festiveSet.ShowItems();

            var officeSet = (OrderSet)festiveSet.Clone();
            officeSet.ModifyItems(items => items.Remove("Суши"));
            officeSet.ShowItems();

            officeSet.ModifyItems(items => items.Add("Бургер"));
            officeSet.ShowItems();
        }
    }
}


