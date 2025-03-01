using System;

class PersonalAccount
{
    static Dlinkedlist personalExpenses = new Dlinkedlist();
    static Members? loggedInUser = null;

    public static void PersonalAccountLogin(DynamicArray members)
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
        
        PersonalAccountMenu();
    }

    static void PersonalAccountMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"===== Personal Account ({loggedInUser?.Name}) =====");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View My Expenses");
            Console.WriteLine("3. Logout");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddPersonalExpense();
                    break;
                case "2":
                    ViewPersonalExpenses();
                    break;
                case "3":
                    loggedInUser = null;
                    return;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddPersonalExpense()
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

        personalExpenses.AddFirst(new Expence(personalExpenses.GenerateID(), name, amount, null, loggedInUser));
        Console.WriteLine("Expense Added Successfully!");
        Console.ReadKey();
    }

    static void ViewPersonalExpenses()
    {
        Console.WriteLine("===== Your Expenses =====");
        personalExpenses.DisplayExpenses();
        Console.ReadKey();
    }
}
