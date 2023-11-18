using System;
using System.Collections.Generic;

namespace CompositePattern
{
    // Component
    abstract class Car
    {
        public abstract void Info();
    }

    // Leaf
    class SingleCar : Car
    {
        private string _name;

        public SingleCar(string name)
        {
            _name = name;
        }

        public override void Info()
        {
            Console.WriteLine(_name);
        }
    }

    // Composite
    class CompositeCar : Car
    {
        private List<Car> _cars = new List<Car>();

        public override void Info()
        {
            foreach (var car in _cars)
            {
                car.Info();
            }
        }

        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public void RemoveCar(Car car)
        {
            _cars.Remove(car);
        }
    }

    // AbstractProductA
    abstract class Engine
    {
        public virtual void GetPower()
        {
        }
    }

    // ConcreteProductB1
    class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine 4.4");
        }
    }

    // ConcreteProductB2
    class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine 3.2");
        }
    }

    // ConcreteProductB3
    class MercedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mercedes Engine 5.0");
        }
    }

    // AbstractFactory
    interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
    }

    // ConcreteFactory1
    class FordFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new SingleCar("Ford");
        }

        public Engine CreateEngine()
        {
            return new FordEngine();
        }
    }

    // ConcreteFactory2
    class ToyotaFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new SingleCar("Toyota");
        }

        public Engine CreateEngine()
        {
            return new ToyotaEngine();
        }
    }

    // ConcreteFactory3
    class MercedesFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new SingleCar("Mercedes");
        }

        public Engine CreateEngine()
        {
            return new MercedesEngine();
        }
    }

    static class Program
    {
        static void Main()
        {
            // Creating composite cars
            CompositeCar compositeCar1 = new CompositeCar();
            compositeCar1.AddCar(new SingleCar("Ford"));
            compositeCar1.AddCar(new SingleCar("Toyota"));

            CompositeCar compositeCar2 = new CompositeCar();
            compositeCar2.AddCar(new SingleCar("Mercedes"));
            compositeCar2.AddCar(compositeCar1);

            // Creating engines
            FordEngine fordEngine = new FordEngine();
            ToyotaEngine toyotaEngine = new ToyotaEngine();
            MercedesEngine mercedesEngine = new MercedesEngine();

            // Displaying information
            Console.WriteLine("Composite Car 1:");
            compositeCar1.Info();
            Console.WriteLine("\nComposite Car 2:");
            compositeCar2.Info();

            Console.WriteLine("\nEngine Info:");
            fordEngine.GetPower();
            toyotaEngine.GetPower();
            mercedesEngine.GetPower();

            Console.ReadKey();
        }
    }
}
