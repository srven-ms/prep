using System;

public class ListNode
{
    public int Value { get; set; }
    public ListNode Next { get; set; }

    public ListNode(int value = 0, ListNode next = null)
    {
        Value = value;
        Next = next;
    }
}

public class List
{
    private ListNode head;

    public void Add(int value)
    {
        if (head == null)
        {
            head = new ListNode(value);
        }
        else
        {
            ListNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new ListNode(value);
        }
    }

    public void Print()
    {
        if (head != null)
        {
            ListNode current = this.head;
            while (current != null)
            {
                Console.Write(current.Value + "->");
                current = current.Next;
            }
        }
        else
        {
            Console.WriteLine("List is empty.");
        }
    }

    // Method to reverse the linked list iteratively
    public void Reverse()
    {
        ListNode prev = null;
        ListNode current = head;
        ListNode next = null;

        while (current != null)
        {
            next = current.Next; // Store next node
            current.Next = prev; // Reverse current node's pointer
            prev = current; // Move pointers one position ahead
            current = next;
        }

        head = prev;
    }

    // Leet code #83. Remove Duplicates from Sorted List
    public ListNode DeleteDuplicates(ListNode head)
    {

        if (head == null)
        {
            return null;
        }

        ListNode curr = head;
        ListNode temp = curr.Next;

        while (temp != null)
        {
            if (temp.Value == curr.Value)
            {
                temp = temp.Next;
            }
            else
            {
                curr.Next = temp;
                curr = temp;

                temp = temp.Next;
            }
        }

        curr.Next = temp;

        return head;
    }
}