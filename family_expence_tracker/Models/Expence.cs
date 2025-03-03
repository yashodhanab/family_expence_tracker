using System;

public class Expence
{
    public int ID{ get; set; }
    public string Name{ get; set; }
    public int Amount{ get; set; }
    public string Date{ get; set; }
    public Members Member{ get; set; }

  

    public Expence(int id, string name, int amount, string? date, Members member)
    {
        Date = date ?? DateTime.Now.ToString("yyyy-MM-dd");
        ID = id;
        Name = name;
        Amount = amount;
        Member = member;
    }
}
