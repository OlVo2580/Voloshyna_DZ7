using System;

// Component interface
interface IChristmasTree
{
    void Display();
}

// Concrete Component
class SimpleChristmasTree : IChristmasTree
{
    public void Display()
    {
        Console.WriteLine("Simple Christmas Tree");
    }
}

// Decorator base class
abstract class ChristmasTreeDecorator : IChristmasTree
{
    protected IChristmasTree decoratedTree;

    public ChristmasTreeDecorator(IChristmasTree tree)
    {
        decoratedTree = tree;
    }

    public virtual void Display()
    {
        decoratedTree.Display();
    }
}

// Concrete Decorator for decorations
class ChristmasTreeWithDecorations : ChristmasTreeDecorator
{
    public ChristmasTreeWithDecorations(IChristmasTree tree) : base(tree)
    {
    }

    public override void Display()
    {
        base.Display();
        AddDecorations();
    }

    private void AddDecorations()
    {
        Console.WriteLine("Adding decorations to the Christmas tree");
    }
}

// Concrete Decorator for lights
class ChristmasTreeWithLights : ChristmasTreeDecorator
{
    public ChristmasTreeWithLights(IChristmasTree tree) : base(tree)
    {
    }

    public override void Display()
    {
        base.Display();
        AddLights();
    }

    private void AddLights()
    {
        Console.WriteLine("Adding lights to the Christmas tree");
    }
}

class Program
{
    static void Main()
    {
        // Create a simple Christmas tree
        IChristmasTree simpleTree = new SimpleChristmasTree();
        Console.WriteLine("Simple Christmas Tree:");
        simpleTree.Display();
        Console.WriteLine();

        // Decorate the tree with decorations
        IChristmasTree treeWithDecorations = new ChristmasTreeWithDecorations(simpleTree);
        Console.WriteLine("Christmas Tree with Decorations:");
        treeWithDecorations.Display();
        Console.WriteLine();

        // Decorate the tree with lights
        IChristmasTree treeWithLights = new ChristmasTreeWithLights(simpleTree);
        Console.WriteLine("Christmas Tree with Lights:");
        treeWithLights.Display();
        Console.WriteLine();

        // Decorate the tree with both decorations and lights
        IChristmasTree treeWithDecorationsAndLights = new ChristmasTreeWithDecorations(new ChristmasTreeWithLights(simpleTree));
        Console.WriteLine("Christmas Tree with Decorations and Lights:");
        treeWithDecorationsAndLights.Display();
    }
}
