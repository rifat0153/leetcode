namespace ConsoleApp1.DataStructures;

internal class CustomQueue<T>
{
    private readonly List<T> values;

    public CustomQueue() => values = [];

    public int Count => values.Count;

    public void Enqueue(T value) => values.Add(value);

    public T Dequeue()
    {
        if (values.Count == 0)
            throw new InvalidOperationException("Queue is empty");
        var value = values[0];
        values.RemoveAt(0);
        return value;
    }
}

internal static class CustomQueueTest { }
