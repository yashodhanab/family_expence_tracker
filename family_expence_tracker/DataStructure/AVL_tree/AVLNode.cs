class AVLNode
{
    public Expence Data { get; set; }
    public AVLNode Left { get; set; }
    public AVLNode Right { get; set; }
    public int Height { get; set; }

    public AVLNode(Expence data)
    {
        Data = data;
        Left = null;
        Right = null;
        Height = 1;
    }
}