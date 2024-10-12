using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    // Node class definition
    public class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new(value);
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Problem 1: Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    /// <summary>
    /// Problem 2: Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null;
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Problem 3: Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _head && curr == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else if (curr == _head)
                {
                    _head = _head.Next;
                    _head!.Prev = null;
                }
                else if (curr == _tail)
                {
                    _tail = _tail.Prev;
                    _tail!.Next = null;
                }
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 4: Search for all instances of 'oldValue' and replace with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 5: Iterate backward through the Linked List.
    /// </summary>
    public IEnumerable Reverse()
    {
        Node? curr = _tail;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }
}

// Extension methods for converting collections to strings.
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}

// Test cases
public static class TestLinkedList
{
    public static void Main()
    {
        // Insert Tail tests
        var ll = new LinkedList();
        ll.InsertTail(1);
        ll.InsertTail(2);
        ll.InsertTail(3);
        Console.WriteLine(ll.ToString()); // Expected: <LinkedList>{1, 2, 3}

        // Remove Tail tests
        ll.RemoveTail();
        Console.WriteLine(ll.ToString()); // Expected: <LinkedList>{1, 2}

        // Remove tests
        ll.Remove(1);
        Console.WriteLine(ll.ToString()); // Expected: <LinkedList>{2}

        // Replace tests
        ll.Replace(2, 5);
        Console.WriteLine(ll.ToString()); // Expected: <LinkedList>{5}

        // Reverse iterator tests
        ll.InsertTail(6);
        ll.InsertTail(7);
        foreach (var item in ll.Reverse())
        {
            Console.WriteLine(item); // Expected: 7, 6, 5
        }
    }
}
