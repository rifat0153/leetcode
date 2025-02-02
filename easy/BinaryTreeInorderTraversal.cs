using System;
using System.Collections.Generic;

namespace Leetcode.Easy;

// Definition for a binary tree node.
public class TreeNode(int x)
{
    public int val = x;
    public TreeNode? left;
    public TreeNode? right;
}

public class BinaryTreeInorderTraversal
{
    public static void Test()
    {
        // Test cases
        TreeNode root1 = new TreeNode(1) { right = new TreeNode(2) { left = new TreeNode(3) } };

        TreeNode root2 = null;

        TreeNode root3 = new TreeNode(1);

        // Call your method to perform inorder traversal
        var result1 = InorderTraversal(root1);
        Console.WriteLine($"Inorder Traversal for Test Case 1: {string.Join(", ", result1)}");

        var result2 = InorderTraversal(root2);
        Console.WriteLine($"Inorder Traversal for Test Case 2: {string.Join(", ", result2)}");

        var result3 = InorderTraversal(root3);
        Console.WriteLine($"Inorder Traversal for Test Case 3: {string.Join(", ", result3)}");
    }

    public static IList<int?> InorderTraversal(TreeNode? root)
    {
        List<int?> result = new();
        InorderTraversal(root, result);
        return result;
    }

    private static void InorderTraversal(TreeNode? node, List<int?> result)
    {
        if (node is not null)
        {
            InorderTraversal(node.left, result);
            result.Add(node.val);
            InorderTraversal(node.right, result);
        }
    }
}
