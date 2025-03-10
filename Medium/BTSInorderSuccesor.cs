using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Medium;

public class Node
{
    public int Key;
    public Node Left;
    public Node Right;
    public Node Parent; // Added Parent reference

    public Node(int key)
    {
        Key = key;
        Left = null;
        Right = null;
        Parent = null;
    }
}

public class BSTSuccessor
{
    public static Node FindInOrderSuccessor(Node inputNode)
    {
        // if node.right exists, we return left most node of right node
        Node right = inputNode.Right;
        if (right is not null)
        {
            Node left = right.Left;
            if (left is null)
                return right;

            while (left.Left is not null)
            {
                left = left.Left;
            }
            return left;
        }

        // if node.right is null, we need to go up until we hit a node which is a left child of a parent, return the parent
        Node parent = inputNode.Parent;
        Node curr = inputNode;
        while (parent is not null)
        {
            if (parent.Left == curr)
            {
                return parent;
            }
            curr = parent;
            parent = parent.Parent;
        }

        return null;
    }

    // Helper function to find the minimum node in a subtree (if needed)
    private static Node FindMinimum(Node node)
    {
        if (node == null)
        {
            return null;
        }

        while (node.Left != null)
        {
            node = node.Left;
        }

        return node;
    }

    // Helper functions for building and searching the BST (for testing)
    public static Node BuildBST(int[] keys)
    {
        Node root = null;
        foreach (int key in keys)
        {
            root = Insert(root, key, null);
        }
        return root;
    }

    private static Node Insert(Node root, int key, Node parent)
    {
        if (root == null)
        {
            Node newNode = new Node(key);
            newNode.Parent = parent;
            return newNode;
        }

        if (key < root.Key)
        {
            root.Left = Insert(root.Left, key, root);
        }
        else if (key > root.Key)
        {
            root.Right = Insert(root.Right, key, root);
        }

        return root;
    }

    public static Node FindNodeByKey(Node root, int key)
    {
        if (root == null)
        {
            return null;
        }

        if (key == root.Key)
        {
            return root;
        }

        if (key < root.Key)
        {
            return FindNodeByKey(root.Left, key);
        }
        else
        {
            return FindNodeByKey(root.Right, key);
        }
    }

    public static void Test()
    {
        // Test Cases (add more as needed)
        int[] keys = { 20, 9, 25, 5, 12, 11, 14 };
        Node root = BuildBST(keys);

        // Example test:
        Node targetNode = FindNodeByKey(root, 12);
        Node inOrderSuccessor = FindInOrderSuccessor(targetNode);
        Console.WriteLine(
            $"Successor of {targetNode.Key}: {(inOrderSuccessor != null ? inOrderSuccessor.Key.ToString() : "null")}"
        );

        // Add more test cases here
    }
}
