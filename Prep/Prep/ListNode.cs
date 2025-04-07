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

    // Leet code #83. Remove Duplicates from Sorted List
    public ListNode DeleteDuplicates(ListNode head)
    {

        if (head == null)
        {
            return null;
        }

        ListNode curr = head;
        ListNode temp = curr.next;

        while (temp != null)
        {
            if (temp.val == curr.val)
            {
                temp = temp.next;
            }
            else
            {
                curr.next = temp;
                curr = temp;

                temp = temp.next;
            }
        }

        curr.next = temp;

        return head;
    }
}