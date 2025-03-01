
using System.Data.Common;
using System.Runtime.InteropServices.Marshalling;

class Dlinkedlist{

    private int count;
    private Node? Head;
    private Node? Tail;

    public Dlinkedlist(){
        count = 0;
        Head = null;
        Tail = null;
    }

    public void AddFirst(Expence val){
         Node temp = new Node(val);
        if(Head==null){
            Head = temp;
            Tail = Head;
            count++;
        }else{
            temp.Next = Head;
            Head.Prev = temp;
            Head = temp;
            count++;
        }
    }


    public void AddLast(Expence val){
         Node temp = new Node(val);
         if(Head==null){
            Head = temp;
            Tail = Head;
            count++;
         }else{
            Tail.Next = temp;
            temp.Prev= Tail;
            Tail = temp;
            count++;
         }  
    }

    public void PrintFromStart(){
        Node current;
        current = Head;
        while(current!=null){
            Console.WriteLine("ID:"+current.Data.ID + " Amount:"+current.Data.Amount+" Name:"+current.Data.Name+" Date:"+current.Data.Date + " Member:"+ current.Data.Member.Name);
            current = current.Next;
        }
    }

    public void PrintFromEnd(){
        Node current;
        current = Tail;
        while(current!=null){
            Console.WriteLine(current.Data);
            current = current.Prev;
        }
    }

    public void AddAt(int index, Expence val){

        if(index==0)
            AddFirst(val);
        else if(index==count)
            AddLast(val);
        else{
            Node temp = new Node(val);
            Node current = Head;

            for(int i=0; i<index-1; i++)
                current = current.Next;
            temp.Next=current.Next;
            current.Next.Prev = temp;
            temp.Prev = current;
            current.Next=temp;
            count++;
        }  
    }

    public void Delete(int index){

        if(index==0){
            Head = Head.Next;
            Head.Prev = null;
            count--;
        }

        else if(index ==count-1){
            Tail = Tail.Prev;
            Tail.Next= null;
            count--;
        } else{
            Node current = Head;
            for(int i=0; i<index-1; i++)
                current = current.Next;
            current.Next=current.Next.Next;
            current.Next.Prev = current;
            count--;

        }

        
        
    }


}