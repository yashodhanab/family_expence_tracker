using System;

class Program
{
    static DynamicArray members = new DynamicArray();

    static void Main()
    {
        // Adding sample members for testing
        members.Add(new Members(1, "sayuru", 1234));
        members.Add(new Members(2, "test", 1234));
        members.Add(new Members(3, "Charlie", 9101));

        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Family Expense Tracker =====");
            Console.WriteLine("1. Family Account");
            Console.WriteLine("2. Personal Account");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    FamilyAccount.FamilyAccountMenu(members);
                    break;
                case "2":
                    PersonalAccount.PersonalAccountLogin(members);
                    break;
                case "3":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
