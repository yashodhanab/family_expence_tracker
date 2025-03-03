


class FamilyAccount
{

    public static void FamilyAccountMenu(Dlinkedlist familyExpenses, DynamicArray members, AVLTree familyExpensesAVL)
    {
        while (true)
        {
            Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkCyan; // Set color for the menu border
    Console.WriteLine("           ╔══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                     Family Account Menu                      ║");
    Console.WriteLine("           ╠══════════════════════════════════════════════════════════════╣");
    Console.WriteLine("           ║                1. Add Expense                                ║");
    Console.WriteLine("           ║                2. View Expenses                              ║");
    Console.WriteLine("           ║                3. Add Member                                 ║");
    Console.WriteLine("           ║                4. View Members                               ║");
    Console.WriteLine("           ║                5. Delete Expense by ID                       ║");
    Console.WriteLine("           ║                6. Edit Expense by ID                         ║");
    Console.WriteLine("           ║                7. Show All Members and Their Data            ║");
    Console.WriteLine("           ║                8. Logout                                     ║");
    Console.WriteLine("           ╚══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); // Reset to default color

    Console.Write("Select an option: ");
    string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddFamilyExpense(familyExpenses, members, familyExpensesAVL);
                    break;
                case "2":
                    ViewFamilyExpenses(familyExpenses,familyExpensesAVL);
                    break;
                case "3":
                    AddMember(members);
                    break;
                case "4":
                    ViewMembers(members);
                    break;
                case "5":
                    DeleteFamilyExpenseById(familyExpenses,familyExpensesAVL);
                    break;
                case "6":
                    EditFamilyExpenseById(familyExpenses, familyExpensesAVL);
                    break;
                case "7":
                    ShowAllMembersAndData(members,familyExpenses);
                    break;
                case "8":
                    return;
                default:
                        Console.ForegroundColor = ConsoleColor.Red; // Set color for the header border
                        Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("           ║                  Invalid choice! Try again.                   ║");
                        Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                        Console.ResetColor(); // Reset to default color
                    break;
                    Console.ReadKey();
                    break;
            }
        }
    }

static void AddFamilyExpense(Dlinkedlist familyExpenses, DynamicArray members, AVLTree familyExpensesAVL)
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

    // Display all members for selection
    Console.WriteLine("===== Select a Member =====");
    members.DisplayMembers();
    Console.Write("Enter Member ID: ");
    if (!int.TryParse(Console.ReadLine(), out int memberId))
    {
        Console.WriteLine("Invalid member ID!");
        Console.ReadKey();
        return;
    }

    Members? selectedMember = members.GetMemberById(memberId);
    if (selectedMember == null)
    {
        Console.WriteLine("Member not found!");
        Console.ReadKey();
        return;
    }

    // Create the expense
    Expence newExpense = new Expence(familyExpenses.GenerateID(), name, amount, null, selectedMember);

    // Add expense to both the linked list and the AVL tree
    familyExpenses.AddFirst(newExpense);
    familyExpensesAVL.Add(newExpense);

    Console.WriteLine("Expense Added Successfully!");
    Console.ReadKey();
}

    static void ViewFamilyExpenses(Dlinkedlist familyExpenses, AVLTree familyExpensesAVL)
    {
        Console.Clear(); 

    Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the menu border
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                     View Family Expenses                      ║");
    Console.WriteLine("           ╠═══════════════════════════════════════════════════════════════╣");
    Console.WriteLine("           ║                1. By Day                                      ║");
    Console.WriteLine("           ║                2. By Price                                    ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); // Reset to default color



        Console.Write("Select an option: ");

        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                // Use the previous method (linked list) to display expenses by day
                Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the menu border
    Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the header border
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                  Family Expenses (By Day)                    ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); // Reset to default color
                familyExpenses.DisplayExpenses();
                break;
            case "2":
                // Use the AVL tree to display expenses by price
                 Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the header border
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                  Family Expenses (By Price)                   ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); // Reset to default color
                familyExpensesAVL.DisplayInorder(); // Display all data (username = null)
                break;
            default:
                 Console.ForegroundColor = ConsoleColor.Red; // Set color for the header border
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                  Invalid choice! Try again.                   ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); // Reset to default color
                break;
        }

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

    static void DeleteFamilyExpenseById(Dlinkedlist familyExpenses ,AVLTree familyExpensesAVL)
    {
        Console.WriteLine("===== Family Expenses =====");
        familyExpenses.DisplayExpenses();

        Console.Write("Enter Expense ID to Delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format! Try again.");
            Console.ReadKey();
            return;
        }

        bool isDeleted = familyExpenses.DeleteExpenseById(id);
        DeleteFamilyExpenseById(familyExpensesAVL, id);
        if (isDeleted)
        {
            Console.WriteLine("Expense Deleted Successfully!");
        }
        else
        {
            Console.WriteLine("Expense not found!");
        }
        Console.ReadKey();
    }

    static void EditFamilyExpenseById(Dlinkedlist familyExpenses, AVLTree familyExpensesAVL)
    {
        Console.WriteLine("===== Family Expenses =====");
        familyExpenses.DisplayExpenses();

        Console.Write("Enter Expense ID to Edit: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format! Try again.");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter New Expense Name: ");
        string newName = Console.ReadLine() ?? "";

        Console.Write("Enter New Amount: ");
        if (!int.TryParse(Console.ReadLine(), out int newAmount))
        {
            Console.WriteLine("Invalid amount! Try again.");
            Console.ReadKey();
            return;
        }

        bool isEdited = familyExpenses.EditExpenseById(id,null, newName, newAmount);
        UpdateFamilyExpenseById(familyExpensesAVL, id, newName, newAmount);
        if (isEdited)
        {
            Console.WriteLine("Expense Edited Successfully!");
        }
        else
        {
            Console.WriteLine("Expense not found!");
        }
        Console.ReadKey();
    }



    static void ShowAllMembersAndData(DynamicArray members, Dlinkedlist familyExpenses){
        Console.WriteLine("===== All Members and Their Data =====");
        members.DisplayMembersWithExpenses(familyExpenses);
        Console.ReadKey();
    }
    static void DeleteFamilyExpenseById(AVLTree familyExpensesAVL, int id){
    familyExpensesAVL.DeleteById(id);
    }

    static void UpdateFamilyExpenseById(AVLTree familyExpensesAVL, int id, string newName, int newAmount){
        familyExpensesAVL.UpdateById(id, newName, newAmount);
        Console.ReadKey();
    }


}