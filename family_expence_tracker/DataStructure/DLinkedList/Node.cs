
using System.Diagnostics.Contracts;

class Node{

    public Expence Data;
    public Node? Next;
    public Node? Prev;

    public Node(Expence val){
        Data = val;
        Next=null;
        Prev = null;
    }
}