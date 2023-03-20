using System.Collections;
using System.Collections.Concurrent;

/// <summary>
/// Stack represents a simple last-in-first-out (LIFO) non-generic collection of objects.
/// Stack<T> represents a variable size last-in-first-out (LIFO) collection of instances of the same specified type.
/// ConcurrentStack<T> represents a thread-safe last-in-first-out (LIFO) collection.
/// </summary>
public class StackExample
{
    public Stack StackEx { get; set; }  // For new code, you shouldn't use non-generic collections: Error prone & Less performant

    /// <summary>
    /// Three main operations: push (insert at the top), pop (remove from the top), and peek (returns element at the top, but does not remove it)
    /// </summary>
    public Stack<string> GStackEx { get; set; }  // You should use generic instead.
    public ConcurrentStack<string> CGStackEx { get; set; }
    public StackExample()
    {
        this.StackEx = new Stack();
        this.GStackEx = new Stack<string>();
        this.CGStackEx = new ConcurrentStack<string>();
    }
    public void addToGStackEx(string msg)
    {
        this.GStackEx.Push(msg);
    }
    public string peekFromGStackEx()
    {
        return this.GStackEx.Peek();
    }
    public string popFromGStackEx()
    {
        return this.GStackEx.Pop();
    }
    public void displayGStackEx()
    {
        if (GStackEx.Count > 0)
        {
            foreach (string item in GStackEx)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("GStackEx is empty");
        }

    }
    public Stack<string> copyFromGStackEx()
    {
        return new Stack<string>(GStackEx.ToArray());
    }
    public void clearFromGStackEx()
    {
        this.GStackEx.Clear();
    }
}