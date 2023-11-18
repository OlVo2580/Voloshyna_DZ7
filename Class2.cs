using System;

namespace Builder
{
    class Program
    {
        class Pizza
        {
            string dough;
            string sauce;
            string topping;
            string border;

            public Pizza() { }

            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }
            public void SetBorder(string b) { border = b; }

            public void Info()
            {
                Console.WriteLine("Dough: {0}\nSauce: {1}\nTopping: {2}\nBorder: {3}",
                    dough, sauce, topping, border);
            }
        }

        // Abstract Builder
        abstract class PizzaBuilder
        {
            protected Pizza pizza;

            public PizzaBuilder() { }

            public Pizza GetPizza() { return pizza; }

            public void CreateNewPizza() { pizza = new Pizza(); }

            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
            public abstract void BuildBorder();
        }

        // Concrete Builder
        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping() { pizza.SetTopping("ham+pineapple"); }
            public override void BuildBorder() { pizza.SetBorder("cheese-filled"); }
        }

        // Concrete Builder
        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("pan baked"); }
            public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping() { pizza.SetTopping("pepperoni+salami"); }
            public override void BuildBorder() { pizza.SetBorder("spicy jalapeno"); }
        }

        // Concrete Builder for Margarita Pizza
        class MargaritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("thin"); }
            public override void BuildSauce() { pizza.SetSauce("classic"); }
            public override void BuildTopping() { pizza.SetTopping("mozzarella+tomatoes"); }
            public override void BuildBorder() { pizza.SetBorder("garlic butter"); }
        }

        // "Director"
        class Waiter
        {
            private PizzaBuilder pizzaBuilder;

            public void SetPizzaBuilder(PizzaBuilder pb) { pizzaBuilder = pb; }

            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }

            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
                pizzaBuilder.BuildBorder();
            }
        }

        // A customer ordering a pizza
        class BuilderExample
        {
            public static void Main(String[] args)
            {
                Waiter waiter = new Waiter();
                PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
                PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
                PizzaBuilder margaritaPizzaBuilder = new MargaritaPizzaBuilder();

                waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
                waiter.ConstructPizza();
                Pizza hawaiianPizza = waiter.GetPizza();
                hawaiianPizza.Info();

                waiter.SetPizzaBuilder(spicyPizzaBuilder);
                waiter.ConstructPizza();
                Pizza spicyPizza = waiter.GetPizza();
                spicyPizza.Info();

                waiter.SetPizzaBuilder(margaritaPizzaBuilder);
                waiter.ConstructPizza();
                Pizza margaritaPizza = waiter.GetPizza();
                margaritaPizza.Info();

                Console.ReadKey();
            }
        }
    }
}
