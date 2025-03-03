

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
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                   Family Expense Tracker                      ║");
    Console.WriteLine("           ╠═══════════════════════════════════════════════════════════════╣");
    Console.WriteLine("           ║                1. Family Account                              ║");
    Console.WriteLine("           ║                2. Personal Account                            ║");
    Console.WriteLine("           ║                3. Exit                                        ║");
    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); 

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
        Members mom = new Members(2, "Mom", 1234);
        Members dad = new Members(3, "Dad", 1234);
        Members brother = new Members(4, "Brother", 1234);
        Members sister = new Members(5, "Sister", 1234);
        
        members.Add(family);
        members.Add(mom);
        members.Add(dad);
        members.Add(brother);
        members.Add(sister);

        familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Electricity", 50, "2025-02-01", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Water", 25, "2025-02-02", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Gas", 35, "2025-02-03", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Monthly Subscription", 15, "2025-02-04", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Transport", 60, "2025-02-05", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Medical Bills", 150, "2025-02-06", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "School Fees", 200, "2025-02-07", brother));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Online Classes", 45, "2025-02-08", sister));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Entertainment", 80, "2025-02-09", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Dining Out", 40, "2025-02-10", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Books and Supplies", 60, "2025-02-11", brother));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Snacks and Drinks", 30, "2025-02-12", sister));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "New Clothes", 120, "2025-02-13", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Home Repair", 200, "2025-02-14", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Pet Care", 50, "2025-02-15", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Vacation Fund", 250, "2025-02-16", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Health Insurance", 175, "2025-02-17", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "HomeCleaning Service", 85, "2025-02-18", sister));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Grocery", 100, "2025-02-19", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Electricity", 55, "2025-02-20", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Water", 40, "2025-02-21", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Gas", 70, "2025-02-22", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Subscription", 22, "2025-02-23", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Transport", 90, "2025-02-24", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Medical Bills", 250, "2025-02-25", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "School Fees", 250, "2025-02-26", brother));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Online Classes", 60, "2025-02-27", sister));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Entertainment", 95, "2025-02-28", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Dining Out", 50, "2025-03-01", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Books and Supplies", 40, "2025-03-02", brother));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Snacks and Drinks", 25, "2025-03-03", sister));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Electricity", 45, "2025-03-04", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Water", 30, "2025-03-05", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Transport", 80, "2025-03-06", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Dining Out", 70, "2025-03-07", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Home Repair", 120, "2025-03-08", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Medical Bills", 250, "2025-03-09", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Books and Supplies", 50, "2025-03-10", brother));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Grocery", 130, "2025-03-11", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Entertainment", 40, "2025-03-12", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "New Clothes", 90, "2025-03-13", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Vacation Fund", 210, "2025-03-14", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Pet Care", 70, "2025-03-15", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Health Insurance", 300, "2025-03-16", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "HomeCleaning Service", 90, "2025-03-17", sister));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Subscription", 55, "2025-03-18", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Electricity", 65, "2025-03-19", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Transport", 110, "2025-03-20", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Water", 75, "2025-03-21", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Medical Bills", 300, "2025-03-22", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Books and Supplies", 110, "2025-03-23", brother));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Gas", 130, "2025-03-24", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Online Classes", 70, "2025-03-25", sister));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Dining Out", 100, "2025-03-26", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Snacks and Drinks", 55, "2025-03-27", sister));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Entertainment", 75, "2025-03-28", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Transport", 120, "2025-03-29", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Grocery", 160, "2025-03-30", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Subscription", 60, "2025-03-31", family));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Vacation Fund", 250, "2025-04-01", dad));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Home Repair", 220, "2025-04-02", mom));
familyExpenses.AddFirst(new Expence(familyExpenses.GenerateID(), "Water", 100, "2025-04-03", family));


 familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Electricity", 50, "2025-02-01", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Water", 25, "2025-02-02", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Gas", 35, "2025-02-03", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Monthly Subscription", 15, "2025-02-04", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Transport", 60, "2025-02-05", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Medical Bills", 150, "2025-02-06", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "School Fees", 200, "2025-02-07", brother));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Online Classes", 45, "2025-02-08", sister));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Entertainment", 80, "2025-02-09", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Dining Out", 40, "2025-02-10", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Books and Supplies", 60, "2025-02-11", brother));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Snacks and Drinks", 30, "2025-02-12", sister));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "New Clothes", 120, "2025-02-13", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Home Repair", 200, "2025-02-14", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Pet Care", 50, "2025-02-15", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Vacation Fund", 250, "2025-02-16", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Health Insurance", 175, "2025-02-17", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "HomeCleaning Service", 85, "2025-02-18", sister));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Grocery", 100, "2025-02-19", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Electricity", 55, "2025-02-20", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Water", 40, "2025-02-21", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Gas", 70, "2025-02-22", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Subscription", 22, "2025-02-23", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Transport", 90, "2025-02-24", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Medical Bills", 250, "2025-02-25", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "School Fees", 250, "2025-02-26", brother));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Online Classes", 60, "2025-02-27", sister));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Entertainment", 95, "2025-02-28", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Dining Out", 50, "2025-03-01", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Books and Supplies", 40, "2025-03-02", brother));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Snacks and Drinks", 25, "2025-03-03", sister));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Electricity", 45, "2025-03-04", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Water", 30, "2025-03-05", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Transport", 80, "2025-03-06", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Dining Out", 70, "2025-03-07", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Home Repair", 120, "2025-03-08", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Medical Bills", 250, "2025-03-09", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Books and Supplies", 50, "2025-03-10", brother));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Grocery", 130, "2025-03-11", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Entertainment", 40, "2025-03-12", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "New Clothes", 90, "2025-03-13", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Vacation Fund", 210, "2025-03-14", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Pet Care", 70, "2025-03-15", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Health Insurance", 300, "2025-03-16", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "HomeCleaning Service", 90, "2025-03-17", sister));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Subscription", 55, "2025-03-18", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Electricity", 65, "2025-03-19", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Transport", 110, "2025-03-20", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Water", 75, "2025-03-21", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Medical Bills", 300, "2025-03-22", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Books and Supplies", 110, "2025-03-23", brother));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Gas", 130, "2025-03-24", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Online Classes", 70, "2025-03-25", sister));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Dining Out", 100, "2025-03-26", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Snacks and Drinks", 55, "2025-03-27", sister));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Entertainment", 75, "2025-03-28", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Transport", 120, "2025-03-29", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Grocery", 160, "2025-03-30", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Subscription", 60, "2025-03-31", family));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Vacation Fund", 250, "2025-04-01", dad));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Home Repair", 220, "2025-04-02", mom));
familyExpensesAVL.Add(new Expence(familyExpenses.GenerateID(), "Water", 100, "2025-04-03", family));



    }

}
