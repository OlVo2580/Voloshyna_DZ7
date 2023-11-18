using System;

namespace FactoryMethod
{
    public class FactoryMethod
    {
        // AbstractProductA
        abstract class Car
        {
            public abstract void Info();
        }

        // ConcreteProductA1
        class Ford : Car
        {
            public override void Info()
            {
                Console.WriteLine("Ford");
            }
        }

        // ConcreteProductA2
        class Toyota : Car
        {
            public override void Info()
            {
                Console.WriteLine("Toyota");
            }
        }

        // ConcreteProductA3
        class Mercedes : Car
        {
            public override void Info()
            {
                Console.WriteLine("Mercedes");
            }
        }

        // AbstractProductB
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

        // AbstractCreator
        abstract class CarFactory
        {
            public abstract Car CreateCar();
            public abstract Engine CreateEngine();
        }

        // ConcreteCreator1
        class FordCarFactory : CarFactory
        {
            public override Car CreateCar()
            {
                return new Ford();
            }

            public override Engine CreateEngine()
            {
                return new FordEngine();
            }
        }

        // ConcreteCreator2
        class ToyotaCarFactory : CarFactory
        {
            public override Car CreateCar()
            {
                return new Toyota();
            }

            public override Engine CreateEngine()
            {
                return new ToyotaEngine();
            }
        }

        // ConcreteCreator3
        class MercedesCarFactory : CarFactory
        {
            public override Car CreateCar()
            {
                return new Mercedes();
            }

            public override Engine CreateEngine()
            {
                return new MercedesEngine();
            }
        }

        static void Main(string[] args)
        {
            CarFactory carFactory = new ToyotaCarFactory();
            Car myCar = carFactory.CreateCar();
            myCar.Info();
            Engine myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            carFactory = new FordCarFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            carFactory = new MercedesCarFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            Console.ReadKey();
        }
    }
}
