using System;

class FamilyAccount
{
    static Dlinkedlist familyExpenses = new Dlinkedlist(); // Use Linked List for expenses

    public static void FamilyAccountMenu(DynamicArray members)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Family Account Menu =====");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. Add Member");
            Console.WriteLine("4. View Members");
            Console.WriteLine("5. Logout");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddFamilyExpense(members);
                    break;
                case "2":
                    ViewFamilyExpenses();
                    break;
                case "3":
                    AddMember(members);
                    break;
                case "4":
                    ViewMembers(members);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddFamilyExpense(DynamicArray members)
    {
        Console.Write("Enter Expense Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter Amount: ");
        if (!int.TryParse(Console.ReadLine(), out int amount))
        {
            Console.WriteLine("Invalid amount! Try again.");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter Member ID who added this expense: ");
        if (!int.TryParse(Console.ReadLine(), out int memberId))
        {
            Console.WriteLine("Invalid ID! Try again.");
            Console.ReadKey();
            return;
        }

        Members? member = members.GetMemberById(memberId);
        if (member == null)
        {
            Console.WriteLine("Member not found! Try again.");
            Console.ReadKey();
            return;
        }

        familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), name, amount, null, member));
        Console.WriteLine("Expense Added Successfully!");
        Console.ReadKey();
    }

    static void ViewFamilyExpenses()
    {
        Console.WriteLine("===== Family Expenses =====");
        familyExpenses.PrintFromStart();
        Console.ReadKey();
    }

    static void AddMember(DynamicArray members)
    {
        Console.Write("Enter Member Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter Password (Numeric Only): ");
        if (!int.TryParse(Console.ReadLine(), out int password))
        {
            Console.WriteLine("Invalid password format!");
            Console.ReadKey();
            return;
        }

        members.Add(new Members(members.Count + 1, name, password));
        Console.WriteLine($"Member '{name}' added successfully!");
        Console.ReadKey();
    }

    static void ViewMembers(DynamicArray members)
    {
        Console.WriteLine("===== Family Members =====");
        members.DisplayMembers();
        Console.ReadKey();
    }
}
