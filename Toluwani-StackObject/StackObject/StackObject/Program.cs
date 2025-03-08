namespace StackObject
{
    class Container
    {
        static void Main(string[] args)
        {
            IStack stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //Console.WriteLine(stack.Pop()); // 3
            //Console.WriteLine(stack.Pop()); // 2
            //Console.WriteLine(stack.Pop()); // 1

            stack.DisplayArray();
        }
    }
}