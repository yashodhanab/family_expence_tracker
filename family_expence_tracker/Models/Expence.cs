using System;

class Expence
{
    public int ID;
    public string Name;
    public int Amount;
    public string Date;
    public Members Member;

    public Expence(int id, string name, int amount, string? date, Members member)
    {
        Date = date ?? DateTime.Now.ToString("yyyy-MM-dd");
        ID = id;
        Name = name;
        Amount = amount;
        Member = member;
    }
}
