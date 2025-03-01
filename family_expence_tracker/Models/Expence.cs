using System;

class Expence{

    public int ID;
    public string Name;
    public int Amount;
    public string Date;
    public Member Member;





    public Expence(int id, string name, int amount, string date, Member member){
        DateTime currentDate = DateTime.Now;  
        if (date == null){
            date = currentDate.ToString("yyyy-MM-dd");
        }
        
        this.ID = id;
        this.Name = name;
        this.Amount = amount;
        this.Date = date;
        this.Member = member;
    }

}