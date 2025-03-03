using System;
using System.Diagnostics;

class PersonalAccount
{
    static Members? loggedInUser = null;

    public static void PersonalAccountLogin(Dlinkedlist personalExpenses, DynamicArray members, AVLTree familyExpensesAVL)
    {
        Console.Clear();
        Console.Write("Enter Username: ");
        string username = Console.ReadLine() ?? "";

        Console.Write("Enter Password: ");
        if (!int.TryParse(Console.ReadLine(), out int password))
        {
            Console.WriteLine("Invalid Password Format! Try again.");
            Console.ReadKey();
            return;
        }

        loggedInUser = members.Authenticate(username, password);
        if (loggedInUser == null)
        {
            Console.WriteLine("Invalid Credentials! Try again.");
            return;
        }

        Console.WriteLine($"Welcome, {loggedInUser.Name}!");
        PersonalAccountMenu(personalExpenses , familyExpensesAVL);
    }

    static void PersonalAccountMenu(Dlinkedlist personalExpenses, AVLTree familyExpensesAVL)
    {
        Stopwatch stopwatch = new Stopwatch();
        while (true)
        {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine($"           ║           Personal Account, {loggedInUser?.Name,-20}              ║");
    Console.WriteLine("           ╠═══════════════════════════════════════════════════════════════╣");
    Console.WriteLine("           ║                1. Add Expense                                 ║");
    Console.WriteLine("           ║                2. View My Expenses                            ║");
    Console.WriteLine("           ║                3. Delete Expense by ID                        ║");
    Console.WriteLine("           ║                4. Edit Expense by ID                          ║");
    Console.WriteLine("           ║                5. Show Overall Expense                        ║");
    Console.WriteLine("           ║                6. Logout                                      ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); 

    Console.Write("Select an option: ");
    string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    stopwatch.Start();
                    AddPersonalExpense(personalExpenses, familyExpensesAVL);
                    stopwatch.Stop();
                    Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                    break;
                case "2":
                    ViewPersonalExpenses(personalExpenses, familyExpensesAVL);
                    break;
                case "3":
                    DeleteExpenseById(personalExpenses, familyExpensesAVL);
                    break;
                case "4":
                    EditExpenseById(familyExpensesAVL,personalExpenses);
                    break;
                case "5":
                    ShowOverallExpense(personalExpenses);
                    break;
                case "6":
                    loggedInUser = null;
                    return;
                default:
                        Console.ForegroundColor = ConsoleColor.Red; // Set color for the header border
                        Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("           ║                  Invalid choice! Try again.                   ║");
                        Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                        Console.ResetColor(); // Reset to default color
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddPersonalExpense(Dlinkedlist personalExpenses , AVLTree familyExpensesAVL)
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
        Expence newExpense = new Expence(personalExpenses.GenerateID(), name, amount, null, loggedInUser);

        personalExpenses.AddFirst(newExpense);
        familyExpensesAVL.Add(newExpense);

        Console.WriteLine("Expense Added Successfully!");
        Console.ReadKey();
    }

    static void ViewPersonalExpenses(Dlinkedlist familyExpenses, AVLTree familyExpensesAVL)
    {
        Stopwatch stopwatch = new Stopwatch();
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the menu border
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                     View Your Expenses                        ║");
    Console.WriteLine("           ╠═══════════════════════════════════════════════════════════════╣");
    Console.WriteLine("           ║                1. By Day (Selection Sort)                     ║");
    Console.WriteLine("           ║                2. By Price                                    ║");
    Console.WriteLine("           ║                3. By Price (Merge Sort)                       ║");
    Console.WriteLine("           ║                4. By Price (Quick Sort)                       ║");
    Console.WriteLine("           ║                5. By Price (Bubble Sort)                      ║");
    Console.WriteLine("           ║                6. By Name (Quick Sort)                        ║");
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
                Console.WriteLine("           ║                  Your Expenses (By Day)                       ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                Console.ResetColor(); // Reset to default color
                stopwatch.Start();
                familyExpenses.SelectionSortById();
                stopwatch.Stop();
                familyExpenses.DisplayExpenses(loggedInUser?.Name);
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;
            case "2":
                // Use the AVL tree to display expenses by price
                                Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the menu border
                Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the header border
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║                  Your Expenses (By Price)                     ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                Console.ResetColor(); // Reset to default color
                stopwatch.Start();
                familyExpensesAVL.DisplayInorder(loggedInUser?.Name); // Display all data (username = null)
                stopwatch.Stop();
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;
            case "3":
                stopwatch.Start();
                familyExpenses.MergeSortBy("Price");
                stopwatch.Stop();
                familyExpenses.DisplayExpenses(loggedInUser?.Name);
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;

            case "4":
                stopwatch.Start();
                familyExpenses.QuickSortByPrice();
                stopwatch.Stop();
                familyExpenses.DisplayExpenses(loggedInUser?.Name);
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;

            case "5":
                stopwatch.Start();
                familyExpenses.BubbleSortByPrice();
                stopwatch.Stop();
                familyExpenses.DisplayExpenses(loggedInUser?.Name);
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                break;

            case "6":
                stopwatch.Start();
                familyExpenses.QuickSortByName();
                stopwatch.Stop();
                familyExpenses.DisplayExpenses(loggedInUser?.Name);
                Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
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


    static void DeleteExpenseById(Dlinkedlist personalExpenses, AVLTree familyExpensesAVL)
    {
        Console.WriteLine("===== Your Expenses =====");
        personalExpenses.DisplayExpenses(loggedInUser?.Name);

        Console.Write("Enter Expense ID to Delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format! Try again.");
            Console.ReadKey();
            return;
        }

        bool isDeleted = personalExpenses.DeleteExpenseById(id, loggedInUser?.Name);
        DeletePersonalAVLExpenseById(familyExpensesAVL, id);
        if (isDeleted)
        {
            Console.WriteLine("Expense Deleted Successfully!\n");
            personalExpenses.DisplayExpenses(loggedInUser?.Name);
        }
        else
        {
            Console.WriteLine("Expense not found or you don't have permission to delete it.");
        }
        Console.ReadKey();
    }

    static void EditExpenseById(AVLTree familyExpensesAVL,Dlinkedlist personalExpenses)
    {
        Console.WriteLine("===== Your Expenses =====");
        personalExpenses.DisplayExpenses(loggedInUser?.Name);

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

        bool isEdited = personalExpenses.EditExpenseById(id, loggedInUser?.Name, newName, newAmount);
        UpdatePersonalAVLExpenseById(familyExpensesAVL, id, newName, newAmount);
        if (isEdited)
        {
            Console.WriteLine("Expense Edited Successfully!");
            Console.WriteLine($"New name: {newName}, New Amount: {newAmount}");

        }
        else
        {
            Console.WriteLine("Expense not found or you don't have permission to edit it.");
        }
        Console.ReadKey();
    }

    static void ShowOverallExpense(Dlinkedlist personalExpenses)
    {
        int totalExpense = personalExpenses.CalculateTotalExpense(loggedInUser?.Name);
Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the menu border
Console.WriteLine($"\n╔════════════════════════════════════════════╗");
Console.WriteLine($"║   Overall Expense for {loggedInUser?.Name,-20} ║");
Console.WriteLine($"╠════════════════════════════════════════════╣");
Console.WriteLine($"║    Total Expense: ${totalExpense,-15}         ║");
Console.WriteLine($"╚════════════════════════════════════════════╝\n");

        Console.ReadKey();
    }

        static void DeletePersonalAVLExpenseById(AVLTree familyExpensesAVL, int id){
    familyExpensesAVL.DeleteById(id);
    }

    static void UpdatePersonalAVLExpenseById(AVLTree familyExpensesAVL, int id, string newName, int newAmount){
        familyExpensesAVL.UpdateById(id, newName, newAmount);
        Console.ReadKey();
    }



}