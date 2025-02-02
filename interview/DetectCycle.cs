namespace Leetcode.interview;

// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public class DetectCycle
{
    public static void Test()
    {
        // Test Case 1: Linked list with a cycle
        ListNode node1 = new ListNode(3);
        ListNode node2 = new ListNode(2);
        ListNode node3 = new ListNode(0);
        ListNode node4 = new ListNode(-4);
        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node2; // Creates a cycle

        Console.WriteLine("Test Case 1: Linked list with a cycle");
        bool hasCycle1 = Invoke(node1);
        Console.WriteLine("Expected: True");
        Console.WriteLine("Output: " + hasCycle1);
        Console.WriteLine("------------------------");

        // Test Case 2: Linked list without a cycle
        ListNode nodeA = new ListNode(1);
        ListNode nodeB = new ListNode(2);
        nodeA.next = nodeB;

        Console.WriteLine("Test Case 2: Linked list without a cycle");
        bool hasCycle2 = Invoke(nodeA);
        Console.WriteLine("Expected: False");
        Console.WriteLine("Output: " + hasCycle2);
        Console.WriteLine("------------------------");

        // Add more test cases as needed.
    }

    public static bool Invoke(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (true)
        {
            slow = slow?.next;
            fast = fast?.next?.next;

            if (fast is null)
            {
                return false;
            }

            if (fast == slow)
            {
                return true;
            }
        }
    }
}
