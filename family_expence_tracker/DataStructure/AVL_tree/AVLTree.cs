

public class AVLTree{
    
    private AVLNode? Root;

    public AVLTree()
    {
        Root = null;
    }

    
    private int GetHeight(AVLNode? node)
    {
        if (node == null)
            return 0;
        return node.Height;
    }

   
    private int GetBalance(AVLNode? node)
    {
        if (node == null)
            return 0;
        return GetHeight(node.Left) - GetHeight(node.Right);
    }

    
    private AVLNode RightRotate(AVLNode y)
    {
        AVLNode x = y.Left;
        AVLNode T2 = x.Right;

        
        x.Right = y;
        y.Left = T2;

        
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x;
    }

 
    private AVLNode LeftRotate(AVLNode x)
    {
        AVLNode y = x.Right;
        AVLNode T2 = y.Left;

        
        y.Left = x;
        x.Right = T2;

        
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y;
    }

    
    public void Add(Expence data)
    {
        Root = Insert(Root, data);
    }

    
    private AVLNode Insert(AVLNode? node, Expence data)
    {
        
        if (node == null)
            return new AVLNode(data);

        if (data.Amount < node.Data.Amount)
            node.Left = Insert(node.Left, data);
        else if (data.Amount > node.Data.Amount)
            node.Right = Insert(node.Right, data);
        else 
            return node;

        
        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        
        int balance = GetBalance(node);

        // Perform rotations if the node is unbalanced
        // Left Left Case
        if (balance > 1 && data.Amount < node.Left.Data.Amount)
            return RightRotate(node);

        // Right Right Case
        if (balance < -1 && data.Amount > node.Right.Data.Amount)
            return LeftRotate(node);

        // Left Right Case
        if (balance > 1 && data.Amount > node.Left.Data.Amount)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        // Right Left Case
        if (balance < -1 && data.Amount < node.Right.Data.Amount)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    public void DisplayInorder(string? username = null)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan; // Set color for the table border
    Console.WriteLine("           ╔═════════════════════════════════════════════════════════════════╗");
    Console.WriteLine("           ║                       Expenses (By Price)                       ║");
    Console.WriteLine("           ╠═════════════════════════════════════════════════════════════════╣");
    Console.WriteLine("           ║ ID       Name                Amount    Member        Date       ║");
    Console.WriteLine("           ╠═════════════════════════════════════════════════════════════════╣");

    Console.ForegroundColor = ConsoleColor.White; // Set color for the table data
    Inorder(Root, username);

    Console.ForegroundColor = ConsoleColor.Cyan; // Reset color for the table footer
    Console.WriteLine("           ╚═════════════════════════════════════════════════════════════════╝");
    Console.ResetColor(); // Reset to default color
}

private void Inorder(AVLNode? node, string? username)
{
    if (node == null)
        return;

    // Recur for the left subtree
    Inorder(node.Left, username);

    // Display data if username is null or matches the expense's member
    if (username == null || node.Data.Member.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
    {
        // Format each row with fixed column widths
        Console.WriteLine($"           ║ {node.Data.ID,-8} {node.Data.Name,-20} ${node.Data.Amount,-8} {node.Data.Member.Name,-12} {node.Data.Date,-10} ║");
    }

    // Recur for the right subtree
    Inorder(node.Right, username);
}

    public void DeleteById(int id)
{
    Root = DeleteNodeById(Root, id);
}

private AVLNode? DeleteNodeById(AVLNode? node, int id)
{
    if (node == null)
        return node;

    // Search for the node with the given ID
    if (id < node.Data.ID)
        node.Left = DeleteNodeById(node.Left, id);
    else if (id > node.Data.ID)
        node.Right = DeleteNodeById(node.Right, id);
    else
    {
        // Node with only one child or no child
        if (node.Left == null || node.Right == null)
        {
            AVLNode? temp = node.Left ?? node.Right;

            // No child case
            if (temp == null)
            {
                temp = node;
                node = null;
            }
            else // One child case
            {
                node = temp; // Copy the contents of the non-empty child
            }
        }
        else
        {
            // Node with two children: Get the inorder successor (smallest in the right subtree)
            AVLNode temp = MinValueNode(node.Right);

            // Copy the inorder successor's data to this node
            node.Data = temp.Data;

            // Delete the inorder successor
            node.Right = DeleteNodeById(node.Right, temp.Data.ID);
        }
    }

    // If the tree had only one node, return
    if (node == null)
        return node;

    // Update the height of the current node
    node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

    // Rebalance the tree
    int balance = GetBalance(node);

    // Left Left Case
    if (balance > 1 && GetBalance(node.Left) >= 0)
        return RightRotate(node);

    // Left Right Case
    if (balance > 1 && GetBalance(node.Left) < 0)
    {
        node.Left = LeftRotate(node.Left);
        return RightRotate(node);
    }

    // Right Right Case
    if (balance < -1 && GetBalance(node.Right) <= 0)
        return LeftRotate(node);

    // Right Left Case
    if (balance < -1 && GetBalance(node.Right) > 0)
    {
        node.Right = RightRotate(node.Right);
        return LeftRotate(node);
    }

    return node;
}

private AVLNode MinValueNode(AVLNode node)
{
    AVLNode current = node;

    // Find the leftmost leaf node
    while (current.Left != null)
        current = current.Left;

    return current;
}

public void UpdateById(int id, string newName, int newAmount){
    // Find the node with the given ID
    AVLNode? node = FindNodeById(Root, id);
    if (node == null)
    {
        
        return;
    }

    // Delete the old node
    DeleteById(id);

    // Create a new expense with the updated details
    Expence updatedExpense = new Expence(id, newName, newAmount, node.Data.Date, node.Data.Member);

    // Insert the new node
    Add(updatedExpense);

    
}


private AVLNode? FindNodeById(AVLNode? node, int id)
{
    if (node == null || node.Data.ID == id)
        return node;

    if (id < node.Data.ID)
        return FindNodeById(node.Left, id);

    return FindNodeById(node.Right, id);
}


  

}