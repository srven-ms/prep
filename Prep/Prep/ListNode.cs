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


    // Leet code #141 https://leetcode.com/problems/linked-list-cycle/ 
    public bool HasCycle(ListNode head)
    {

        if (head == null)
        {
            return false;
        }

        ListNode f = head;
        ListNode s = head;

        while (f != null && f.Next != null)
        {

            f = f.Next;

            if (f != null)
            {
                f = f.Next;
            }

            s = s.Next;

            if (s == f)
            {
                return true;
            }
        }

        return false;
    }


    // Leet code #160 https://leetcode.com/problems/intersection-of-two-linked-lists/
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        int aListLength = 0;
        int bListLength = 0;

        ListNode tmp1 = headA;
        ListNode tmp2 = headB;

        // Find the length of both lists
        while (tmp1 != null)
        {
            tmp1 = tmp1.Next;
            aListLength++;
        }

        while (tmp2 != null)
        {
            tmp2 = tmp2.Next;
            bListLength++;
        }

        // Find the lengthier list
        bool moveA = false;
        bool moveB = false;
        int diff = 0;

        if (aListLength > bListLength)
        {
            moveA = true;
            diff = aListLength - bListLength;
        }
        else if (bListLength > aListLength)
        {
            moveB = true;
            diff = bListLength - aListLength;
        }

        // Now, move the head of the longer list to match the difference
        if (moveA)
        {
            while (diff > 0)
            {
                headA = headA.Next;
                diff--;
            }
        }
        else if (moveB)
        {
            while (diff > 0)
            {
                headB = headB.Next;
                diff--;
            }
        }

        // Move both list one node at a time.
        // When they meet, it will be the intersection
        while (headA != null && headB != null)
        {
            if (headA == headB)
            {
                return headA;
            }

            headA = headA.Next;
            headB = headB.Next;
        }

        return null;
    }
}