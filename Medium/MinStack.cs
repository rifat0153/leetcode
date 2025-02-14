namespace Leetcode.Medium;

class MinStack
{
    private Stack<(int Val, int Min)> stack = [];

    public MinStack() { }

    public void Push(int val)
    {
        if (stack.TryPeek(out var p))
        {
            stack.Push((val, Math.Min(val, p.Min)));
        }
        else
        {
            stack.Push((val, val));
        }
    }

    public void Pop()
    {
        stack.TryPop(out var _);
    }

    public int Top()
    {
        stack.TryPeek(out var v);
        return v.Val;
    }

    public int GetMin()
    {
        stack.TryPeek(out var v);
        return v.Min;
    }
}
