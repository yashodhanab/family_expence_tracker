DynamicArray dynamicArray = new DynamicArray();
dynamicArray.Add(new Member(1, "John", 1234));
dynamicArray.Add(new Member(2, "Doe", 1234));

dynamicArray.Print();

Dlinkedlist dlinkedlist = new Dlinkedlist();
dlinkedlist.AddFirst(new Expence(1, "Bread", 100, null, dynamicArray.array[0]));
dlinkedlist.AddFirst(new Expence(2, "Butter", 200, null, dynamicArray.array[1]));

dlinkedlist.PrintFromStart();