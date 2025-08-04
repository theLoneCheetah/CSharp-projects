using System;
using System.Collections.Generic;

class Program
{
    private static void Find_Equal()
    {
        Console.Write("Enter number of strings: ");
        int n = int.Parse(Console.ReadLine());

        string temp;
        int hash;
        SortedDictionary<int, List<string>> hashes = new SortedDictionary<int, List<string>>();

        Console.WriteLine("Enter strings:");

        for (int i = 0; i < n; ++i)
        {
            temp = Console.ReadLine();
            hash = HashSum.Calculate_Hash(temp);

            if (hashes.ContainsKey(hash))
                hashes[hash].Add(temp);
            else
                hashes[hash] = new List<string>() { temp };
        }

        int count = 0;

        foreach (var i in hashes.Keys)
        {
            hashes[i].Sort();
            Console.Write("Group {0} (hash = {1}):", count, i);

            foreach (var j in hashes[i])
                Console.Write(" {0}", j);

            ++count;
            Console.WriteLine();
        }

    }

    private static void Rabin_Karp()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        Console.Write("Enter substring: ");
        string substr = Console.ReadLine();
        int needed_hash = HashSum.Calculate_Hash(substr);

        Console.Write("Indices of substring occurences:");

        for (int i = 0; i < text.Length - substr.Length + 1; ++i)
        {
            if (HashSum.Calculate_Hash(text.Substring(i, substr.Length)) == needed_hash)
            {
                bool equal = true;

                for (int j = 0; j < substr.Length; ++j)
                {
                    if (substr[j] != text[i + j])
                    {
                        equal = false;
                        break;
                    }
                }

                if (equal)
                    Console.Write(" {0}", i);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter 0 to group equal strings, 1 to try Rabin-Karp: ");
        bool mode = Console.ReadLine() == "1";

        if (mode)
            Rabin_Karp();
        else
            Find_Equal();
        
        Console.ReadLine();
    }
}
