//data tree structure - recursive implementation

class Program
{
    static void Main(string[] args)
    {
        var tree = new Tree<string>()
            .Begin("Food")
            .Begin("Pizza")
                .Add("Hawaii")
                .Add("Vezuvio")
            .End()
            .Begin("Burger")
                .Add("Chili cheese")
                .Add("Cheese burger")
                .Add("Chicken burger")
            .End()
           .End();

        tree.Nodes.ForEach(p => PrintNode(p, 0));
        Console.ReadKey();
    }

    static void PrintNode<T>(TreeNode<T> node, int level)
        {
            Console.WriteLine("{0}{1}", new string(' ', level * 3), node.Value);
            level++;
            node.Children.ForEach(p => PrintNode(p, level));
        }

    }

public partial class Tree<T>
{
    private Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
    public List<TreeNode<T>> Nodes { get; } = new List<TreeNode<T>>();

    public Tree<T> Begin(T val)
    {
        if(stack.Count == 0)
        {
            var node = new TreeNode<T>(val, null);
            Nodes.Add(node);
            stack.Push(node);
        }
        else
        {
            var node = stack.Peek().Add(val);
            stack.Push(node);
        }

        return this;
    }

    public Tree<T> Add(T val)
    {
        stack.Peek().Add(val);
        return this;
    }

    public Tree<T> End()
    {
        stack.Pop();
        return this;
    }


}

