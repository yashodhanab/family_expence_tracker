class Dlinkedlist
{
    private int count;
    private Node? Head;
    private Node? Tail;
    private int idCounter = 1;

    public Dlinkedlist()
    {
        count = 0;
        Head = null;
        Tail = null;
    }


    public void AddFirst(Expence val)
    {
        Node temp = new Node(val);
        if (Head == null)
        {
            Head = temp;
            Tail = Head;
            count++;
        }
        else
        {
            temp.Next = Head;
            Head.Prev = temp;
            Head = temp;
            count++;
        }
    }

    public void AddLast(Expence val)
    {
        Node temp = new Node(val);
        if (Head == null)
        {
            Head = temp;
            Tail = Head;
            count++;
        }
        else
        {
            Tail.Next = temp;
            temp.Prev = Tail;
            Tail = temp;
            count++;
        }
    }

    ///////////////////////////////
    // public void Sort()
    //     {
    //         Head = MergeSort.Sort(Head);
    //     }
    ///////////////////////////////
    public int GenerateID()
    {
        return idCounter++;
    }
public void DisplayExpenses(string? name = null)
{
    Node? current = Head;
    bool found = false;

    if (current == null)
    {
        Console.ForegroundColor = ConsoleColor.Red; // Set color for the error message
        Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("           ║                      No Expenses Found                        ║");
        Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
        Console.ResetColor(); // Reset to default color
        return;
    }

    Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the table border
    Console.WriteLine("           ╔═════════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                      Family Expenses                            ║");
    Console.WriteLine("           ╠═════════════════════════════════════════════════════════════════╣");
    Console.WriteLine("           ║ ID       Name                Amount    Member        Date       ║");
    Console.WriteLine("           ╠═════════════════════════════════════════════════════════════════╣");

    Console.ForegroundColor = ConsoleColor.White; // Set color for the table data
    while (current != null)
    {
        if (string.IsNullOrEmpty(name) || current.Data.Member.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        {
            // Format each row with fixed column widths
            Console.WriteLine($"           ║ {current.Data.ID,-8} {current.Data.Name,-20} ${current.Data.Amount,-8} {current.Data.Member.Name,-12} {current.Data.Date,-10} ║");
            found = true;
        }
        current = current.Next;
    }

    if (!found)
    {
        Console.ForegroundColor = ConsoleColor.Red; // Set color for the no data message
        Console.WriteLine($"           ║ No expenses found for member: {name,-30} ║");
    }

    Console.ForegroundColor = ConsoleColor.Cyan; // Reset color for the table footer
    Console.WriteLine("           ╚═════════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); // Reset to default color
}

    public void PrintFromStart()
    {
        Node current;
        current = Head;
        while (current != null)
        {
            Console.WriteLine("ID:" + current.Data.ID + " Amount:" + current.Data.Amount + " Name:" + current.Data.Name + " Date:" + current.Data.Date + " Member:" + current.Data.Member.Name);
            current = current.Next;
        }
    }

    public void PrintFromEnd()
    {
        Node current;
        current = Tail;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Prev;
        }
    }

    public void AddAt(int index, Expence val)
    {
        if (index == 0)
            AddFirst(val);
        else if (index == count)
            AddLast(val);
        else
        {
            Node temp = new Node(val);
            Node current = Head;

            for (int i = 0; i < index - 1; i++)
                current = current.Next;
            temp.Next = current.Next;
            current.Next.Prev = temp;
            temp.Prev = current;
            current.Next = temp;
            count++;
        }
    }

    public void Delete(int index)
    {
        if (index == 0)
        {
            Head = Head.Next;
            if (Head != null)
                Head.Prev = null;
            else
                Tail = null; // If the list becomes empty
            count--;
        }
        else if (index == count - 1)
        {
            Tail = Tail.Prev;
            if (Tail != null)
                Tail.Next = null;
            else
                Head = null; // If the list becomes empty
            count--;
        }
        else
        {
            Node current = Head;
            for (int i = 0; i < index - 1; i++)
                current = current.Next;
            current.Next = current.Next.Next;
            if (current.Next != null)
                current.Next.Prev = current;
            count--;
        }
    }

        public bool DeleteExpenseById(int id, string? username = null)
        {
            Node? current = Head;

            while (current != null)
            {
                // Check if the expense ID matches
                if (current.Data.ID == id)
                {
                    // If username is null or matches the expense's member
                    if (username == null || current.Data.Member.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
                    {
                        // If the node to delete is the head
                        if (current == Head)
                        {
                            Head = Head.Next;
                            if (Head != null)
                                Head.Prev = null;
                            else
                                Tail = null; // If the list becomes empty
                        }
                        // If the node to delete is the tail
                        else if (current == Tail)
                        {
                            Tail = Tail.Prev;
                            if (Tail != null)
                                Tail.Next = null;
                            else
                                Head = null; // If the list becomes empty
                        }
                        // If the node to delete is in the middle
                        else
                        {
                            current.Prev.Next = current.Next;
                            current.Next.Prev = current.Prev;
                        }

                        count--;
                        return true; // Expense deleted successfully
                    }
                }

                current = current.Next;
            }

            return false; // Expense not found or user doesn't have permission
        }

        public bool EditExpenseById(int id, string? username, string newName, int newAmount)
        {
            Node? current = Head;

            while (current != null)
            {
                // Check if the expense ID matches
                if (current.Data.ID == id)
                {
                    // If username is null or matches the expense's member
                    if (username == null || current.Data.Member.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
                    {
                        // Update the expense details
                        current.Data.Name = newName;
                        current.Data.Amount = newAmount;
                        return true; // Expense edited successfully
                    }
                }

                current = current.Next;
            }

            return false; // Expense not found or user doesn't have permission
        }

    public int CalculateTotalExpense(string username)

    {
        Node? current = Head;
        int totalExpense = 0;

        while (current != null)
        {
            if (current.Data.Member.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                totalExpense += current.Data.Amount;
            }

            current = current.Next;
        }

        return totalExpense;
    }

        // MergeSort Entry Point
    public void MergeSortBy(string filter)
    {
        Head = MergeSort(Head, filter);

        // Update the Tail pointer
        Node? temp = Head;
        while (temp?.Next != null)
        {
            temp = temp.Next;
        }
        Tail = temp;
    }

    // Recursive Merge Sort
    private Node? MergeSort(Node? head, string filter)
    {
        if (head == null || head.Next == null)
            return head;

        // Split the list into two halves
        Node? middle = GetMiddle(head);
        Node? nextToMiddle = middle?.Next;

        if (middle != null)
            middle.Next = null; // Split the list

        // Recursively sort both halves
        Node? left = MergeSort(head, filter);
        Node? right = MergeSort(nextToMiddle, filter);

        // Merge sorted halves
        return MergeSortedLists(left, right, filter);
    }

    // Find Middle Node
    private Node? GetMiddle(Node? head)
    {
        if (head == null) return null;

        Node? slow = head, fast = head;
        while (fast?.Next != null && fast.Next.Next != null)
        {
            slow = slow?.Next;
            fast = fast.Next.Next;
        }
        return slow;
    }

    // Merge two sorted lists
    private Node? MergeSortedLists(Node? left, Node? right, string filter)
    {
        if (left == null) return right;
        if (right == null) return left;
        
        
            if (filter=="Price" && left.Data.Amount <= right.Data.Amount)
            {
                left.Next = MergeSortedLists(left.Next, right , filter);
                left.Next.Prev = left;
                left.Prev = null;
                return left;
            }
            else
            {
                right.Next = MergeSortedLists(left, right.Next, filter);
                right.Next.Prev = right;
                right.Prev = null;
                return right;
            }


             if (filter=="Id" && left.Data.ID <= right.Data.ID)
            {
                left.Next = MergeSortedLists(left.Next, right , filter);
                left.Next.Prev = left;
                left.Prev = null;
                return left;
            }
            else
            {
                right.Next = MergeSortedLists(left, right.Next, filter);
                right.Next.Prev = right;
                right.Prev = null;
                return right;
            }


       

        


    }
}

