namespace Leetcode.Easy;

internal class MergeTwoLists
{
    public static void Test()
    {
        // Create test cases
        ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
        ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

        // Merge lists
        ListNode mergedList = MergeTwoListsImpl(list1, list2);

        // Print merged list
        PrintList(mergedList);
    }

    private static void PrintList(ListNode node)
    {
        while (node != null)
        {
            Console.Write(node.val + " ");
            node = node.next;
        }
        Console.WriteLine();
    }

    public static ListNode MergeTwoListsImpl(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }

        if (list1 != null)
        {
            current.next = list1;
        }
        else
        {
            current.next = list2;
        }

        return dummy.next;
    }
}
