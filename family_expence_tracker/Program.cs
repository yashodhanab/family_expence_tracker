
class Program
{
    static DynamicArray members = new DynamicArray();
    static Dlinkedlist familyExpenses = new Dlinkedlist();
    static AVLTree familyExpensesAVL = new AVLTree();

    static void Main()
    {
        
        LoadDummyData();
       

        while (true)
        {
            Console.Clear();
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the menu border
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                   Family Expense Tracker                      ║");
    Console.WriteLine("           ╠═══════════════════════════════════════════════════════════════╣");
    Console.WriteLine("           ║                1. Family Account                              ║");
    Console.WriteLine("           ║                2. Personal Account                            ║");
    Console.WriteLine("           ║                3. Exit                                        ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); // Reset to default color

    Console.Write("Select an option: ");
    string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    FamilyAccount.FamilyAccountMenu(familyExpenses, members, familyExpensesAVL);
                    break;
                case "2":
                    PersonalAccount.PersonalAccountLogin(familyExpenses,members, familyExpensesAVL);
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


    static void LoadDummyData(){
        Members family = new Members(1, "Family", 1234);
        Members sayuru = new Members(2, "sayuru", 1234);
        Members test = new Members(3, "test", 1234);
        Members charlie = new Members(4, "Charlie", 1234);
        
        members.Add(family);
        members.Add(sayuru);
        members.Add(test);
        members.Add(charlie);

        familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Grocery", 100,null, family));
        familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Electricity", 50, null, sayuru));
        familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Water", 20, null, test));
        familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Gas", 30, null, family));

        familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Grocery", 100, null, family));
        familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Electricity", 50, null, sayuru));   
        familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Water", 20, null, test));
        familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Gas", 30, null, family));

    }

}
