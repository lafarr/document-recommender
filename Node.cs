class Node<T> {
    public T Value  
    {
        get; set;
    }

    public int Count
    {
        get;
        set;
    }

    public Node<T>? Next
    {
        get; set;
    }

    public Node(T value) {
        Value = value;
        Count = 1;
        Next = null;
    }
}
