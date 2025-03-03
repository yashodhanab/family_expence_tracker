using System;

class DynamicArray
{
    private Members[] members;
    public int Count { get; private set; }

    public DynamicArray()
    {
        members = new Members[10];
        Count = 0;
    }

    public void Add(Members member)
    {
        if (Count >= members.Length)
        {
            Array.Resize(ref members, members.Length * 2);
        }
        members[Count++] = member;
    }

public void DisplayMembers()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the table border
    Console.WriteLine("           ╔══════════════════════════╗");
    Console.WriteLine("           ║        Family Members    ║");
    Console.WriteLine("           ╠══════════════════════════╣");
    Console.WriteLine("           ║ ID     Name              ║");
    Console.WriteLine("           ╠══════════════════════════╣");

    // Table data
    Console.ForegroundColor = ConsoleColor.White;
    for (int i = 0; i < Count; i++)
    {
        Console.WriteLine($"           ║ {members[i].ID,-6} {members[i].Name,-18}║");
    }

    // Table footer
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("           ╚══════════════════════════╝");
    Console.ResetColor(); // Reset to default color
}


    public Members? GetMemberById(int id)
    {
        for (int i = 0; i < Count; i++)
        {
            if (members[i].ID == id)
                return members[i];
        }
        return null;
    }

    public Members? Authenticate(string username, int password)
    {
        for (int i = 0; i < Count; i++)
        {
            if (members[i].Name == username && members[i].Password == password)
                return members[i];
        }
        return null;
    }


public void DisplayMembersWithExpenses(Dlinkedlist familyExpenses)
{
    if (Count == 0)
    {
        Console.WriteLine("\nNo members found.");
        return;
    }

    Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the table border
    Console.WriteLine("\n ╔══════════╦════════════════════╦════════════╗");
    Console.WriteLine(" ║    ID    ║        Name        ║   Total    ║");
    Console.WriteLine(" ╠══════════╬════════════════════╬════════════╣");

    for (int i = 0; i < Count; i++)
    {
        Members member = GetMemberById(i + 1); // Assuming IDs start from 1
        int totalExpense = familyExpenses.CalculateTotalExpense(member.Name);

    Console.WriteLine($" ║ {member.ID,-8} ║ {member.Name,-18} ║ ${totalExpense,-8}  ║");
    }

    Console.WriteLine(" ╚══════════╩════════════════════╩════════════╝\n");
}




}

