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
        Console.WriteLine("ID\tName");
        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine($"{members[i].ID}\t{members[i].Name}");
        }
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
}
