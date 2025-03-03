using System.Diagnostics;

class FamilyAccount
{

    
    public static void FamilyAccountMenu(Dlinkedlist familyExpenses, DynamicArray members, AVLTree familyExpensesAVL){
        Stopwatch stopwatch = new Stopwatch();

        while (true){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan; 
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
            Console.ResetColor(); 

            Console.Write("Select an option: ");
            string choice = Console.ReadLine() ?? "";

                    switch (choice)
                    {
                        case "1":
                            stopwatch.Start();
                            AddFamilyExpense(familyExpenses, members, familyExpensesAVL);
                            stopwatch.Stop();
                            Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");

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
                                Console.ForegroundColor = ConsoleColor.Red; 
                                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                Console.WriteLine("           ║                  Invalid choice! Try again.                   ║");
                                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                                Console.ResetColor(); 
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

    static void ViewFamilyExpenses(Dlinkedlist familyExpenses, AVLTree familyExpensesAVL){

    Stopwatch stopwatch = new Stopwatch();
    Console.Clear(); 

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                     View Family Expenses                      ║");
    Console.WriteLine("           ╠═══════════════════════════════════════════════════════════════╣");
    Console.WriteLine("           ║                1. By Day (Selection Sort)                     ║");
    Console.WriteLine("           ║                2. By Price                                    ║");
    Console.WriteLine("           ║                3. By Price (Merge Sort)                       ║");
    Console.WriteLine("           ║                4. By Price (Quick Sort)                       ║");
    Console.WriteLine("           ║                5. By Price (Bubble Sort)                      ║");
    Console.WriteLine("           ║                6. By Name (Quick Sort)                        ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); 



        Console.Write("Select an option: ");

        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                
    Console.ForegroundColor = ConsoleColor.Cyan; 
    Console.ForegroundColor = ConsoleColor.Cyan; 
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                  Family Expenses (By Day)                     ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); 
                stopwatch.Start();
                familyExpenses.SelectionSortById();
                stopwatch.Stop();
                familyExpenses.DisplayExpenses();
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;
            case "2":
            
                
                 Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                  Family Expenses (By Price)                   ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); 
                stopwatch.Start();
                familyExpensesAVL.DisplayInorder(); 
                stopwatch.Stop();
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;
            case "3":
                stopwatch.Start();
                familyExpenses.MergeSortBy("Price");
                stopwatch.Stop();
                familyExpenses.DisplayExpenses();
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;

            case "4":
                stopwatch.Start();
                familyExpenses.QuickSortByPrice();
                stopwatch.Stop();
                familyExpenses.DisplayExpenses();
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;
            
            case "5":
                stopwatch.Start();
                familyExpenses.BubbleSortByPrice();
                stopwatch.Stop();
                familyExpenses.DisplayExpenses();
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;
            
            case "6":
                stopwatch.Start();
                familyExpenses.QuickSortByName();
                stopwatch.Stop();
                familyExpenses.DisplayExpenses();
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;
            default:
                 Console.ForegroundColor = ConsoleColor.Red; 
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                  Invalid choice! Try again.                   ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); 
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