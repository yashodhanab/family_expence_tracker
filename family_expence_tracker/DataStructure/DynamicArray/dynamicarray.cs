using System.Runtime.InteropServices;
using Microsoft.VisualBasic.FileIO;

class DynamicArray
{

    private int count;
    private int capacity;
    public Member[] array;

    public DynamicArray(){
        capacity=2;
        count=0;
        array = new Member[capacity];
    }


    public void Add(Member data){
        if(count==capacity)
            ExtendArray();
        
        array[count] = data;
        count++;
    }

    public void ExtendArray()
    {
        Member[] newarray = new Member[capacity*2];
        for(int i=0; i<count; i++)
            newarray[i] = array[i];
        
        capacity *= 2;
        array = newarray;
        
        Console.WriteLine("Array is extended and new Capacity is "+capacity);
    }

    public void addAt(int index, Member data){
        if(count==capacity)
            ExtendArray();
        
        for(int i=count; i>=index; i--){
            array[i+1] = array[i];
        }

        array[index] = data;
        count++;
    }

    public void DeleteAt(int index){

        if(index>=0 && index<=count){

            for(int i=index; i<count-1; i++)
                array[i] = array[i+1];
            count--;

            Console.WriteLine("Delete successfull at "+index);
        } 

        if(this.count==capacity/4)
            Shrink();
    }

    public void DeleteLast(){
        if(count==0) return;
        count--;
    }

    private void Shrink(){
        capacity =  capacity/2;
        Member[] newarray = new Member[capacity];

        for(int i=0; i<count; i++)
            newarray[i]=array[i];

    }

    public void Print(){
        for(int i=0; i<count; i++)
            Console.WriteLine(array[i].ID+" "+array[i].Name+" "+array[i].Password);
    }

}