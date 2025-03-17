using Leetcode.interview;

namespace Leetcode.Easy;

public record ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

internal class ReverseLinkedList
{
    public static void Test()
    {
        ListNode listNode = new(val: 1, next: new(2, new(2, new(3, new(4, new(5, null))))));
        ListNode reversed = ReverseList(listNode);

        while (reversed != null)
        {
            Console.WriteLine(reversed.val);
            reversed = reversed.next;
        }
    }

    internal static ListNode ReverseList(ListNode head)
    {
        ListNode? prev = null;
        while (head is not null)
        {
            ListNode next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }

        return prev!;
    }
}
