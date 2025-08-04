using System;
using System.Collections.Generic;

class DisjointSet
{
    private int[] parent;
    private int[] rank;

    public DisjointSet(int size)   // in the beginning, all vertices are separated
    {
        parent = new int[size];
        rank = new int[size];

        for (int i = 0; i < size; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    public int Find(int item)   // find the first added parent
    {
        if (parent[item] != item)
            parent[item] = Find(parent[item]);

        return parent[item];
    }

    public void Union(int set1, int set2)   // add new edge by vertices
    {
        int root1 = Find(set1);
        int root2 = Find(set2);

        if (root1 != root2)
        {
            if (rank[root1] > rank[root2])   // rank is the priority of union
                parent[root2] = root1;
            else if (rank[root1] < rank[root2])
                parent[root1] = root2;
            else
            {
                parent[root2] = root1;
                rank[root1]++;
            }
        }
    }

    public bool SameSet(int set1, int set2)   // compare parents to check cycle
    {
        return Find(set1) == Find(set2);
    }
}
