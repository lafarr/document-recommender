 class Counter {
     public Node<string>[] Table
     {
         get; 
         set;
     }

     public Counter() 
     {
        Table = new Node<string>[16];
     }

     public Counter(string str) 
     {
        Table = new Node<string>[16];
        string[] words = str.Split(' ');
        foreach (string word in words) 
        {
            if (word.Equals("")) 
            {
                continue;
            }
            Add(word);
        }
     }

     public void Add(string str) 
     {
        ulong hash = (ulong) str.GetHashCode();
        ulong index = hash & (ulong) Table.Length - 1;
        if (Table[index] == null) 
        {
            Table[index] = new Node<string>(str);
            Table[index].Count = 1;
        } 
        else 
        {
            Node<string> current = Table[index];
            while (current.Next != null) 
            {
                if (current.Value.Equals(str)) 
                {
                    current.Count += 1;
                    return;
                }
                current = current.Next;
            }
            current.Next = new Node<string>(str);
        }
     }

     public int GetCount(string str) 
     {
        ulong hash = (ulong) str.GetHashCode();
        ulong index = hash & (ulong) Table.Length - 1;
        if (Table[index] == null) 
        {
            return 0;
        } 
        else 
        {
            int count = 0;
            Node<string>? current = Table[index];
            while (current != null) 
            {
                if (current.Value == str) 
                {
                    count++;
                }
                current = current.Next;
            }
            return count;
        }
     }

     public void Remove(string str) 
     {
        ulong hash = (ulong) str.GetHashCode();
        ulong index = hash & (ulong) (Table.Length - 1);
        if (Table[index] is null) 
        {
            return;
        } 
        else 
        {
            Node<string> current = Table[index];
            if (current.Value == str) 
            {
                Table[index] = current.Next;
            } 
            else 
            {
                while (current.Next != null) 
                {
                    if (current.Next.Value == str) 
                    {
                        current.Next = current.Next.Next;
                        return;
                    }
                    current = current.Next;
                }
            }
        }
     }

     public override string ToString()
     {
         string str = "{ ";
         int idx = 0;
         foreach (Node<string>? n in this.Table) 
         {
             Node<string>? curr = n;
             while (curr != null)
             {
                 str += $"\"{curr.Value}\": {curr.Count}, ";
                 ++idx;
                 curr = curr.Next;
             }
         }
         return str + " }";
     }
 }
