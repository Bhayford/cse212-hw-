public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Inserts a value uniquely in the tree
    /// </summary>
    public void Insert(int value)
    {
        if (value == Data) return; // Prevent duplicates

        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) // Only insert if value is greater
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Checks if a value exists in the tree
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else if (value < Data && Left != null)
            return Left.Contains(value);
        else if (value > Data && Right != null)
            return Right.Contains(value);

        return false;
    }

    /// <summary>
    /// Calculates the height of the tree
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
