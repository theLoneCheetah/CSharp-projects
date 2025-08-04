using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class Program
{
    /*
    6
    1 2 7
    1 3 10
    1 4 6
    2 5 7
    3 6 7
    3 7 3
    1
    */
    private static void DFS(ref Dictionary<string, GraphVertex> vertices)
    {
        Console.Write("Enter starting vertex: ");
        string start = Console.ReadLine();

        Dictionary<string, bool> visited = new Dictionary<string, bool>();
        foreach (var vertex in vertices)
            visited[vertex.Key] = false;

        Console.WriteLine("Depth-First Search:");
        vertices[start].DFS(ref visited);
    }

    private static void BFS(ref Dictionary<string, GraphVertex> vertices)
    {
        Console.Write("Enter starting vertex: ");
        string start = Console.ReadLine();

        Dictionary<string, bool> visited = new Dictionary<string, bool>();
        foreach (var vertex in vertices)
            visited[vertex.Key] = false;
        visited[start] = true;

        Queue<string> to_visit = new Queue<string>();
        to_visit.Enqueue(start);

        Console.WriteLine("Breadth-First Search:");
        string cur;
        while (to_visit.Count > 0)
        {
            cur = to_visit.Dequeue();
            vertices[cur].BFS(ref visited, ref to_visit);
        }
    }

    /*
    9
    1 2 7
    1 3 9
    2 3 10
    2 4 15
    3 4 11
    1 6 14
    3 6 2
    6 5 9
    4 5 6
    1
    */
    private static void DijkstraAlgorithm(ref Dictionary<string, GraphVertex> vertices)
    {
        Console.Write("Enter starting vertex: ");
        string start = Console.ReadLine();

        Dictionary<string, int> shortest_path = new Dictionary<string, int>();
        foreach (string value in vertices.Keys)
            shortest_path[value] = int.MaxValue;
        shortest_path[start] = 0;

        PriorityQueue<string, int> nearest = new PriorityQueue<string, int>();
        nearest.Enqueue(start, 0);

        while (nearest.Count > 0)
        {
            nearest.TryDequeue(out string vertex, out int path);
            if (shortest_path[vertex] < path)
                continue;   // if this vertex was already used with less path

            vertices[vertex].ShortestAdjacentPaths(ref shortest_path, ref nearest);
        }

        Console.WriteLine("Shortest paths:");
        foreach (var elem in shortest_path)
        {
            Console.WriteLine("{0}: {1}", elem.Key, elem.Value);
        }
    }

    /*
    12
    1 2 2
    1 5 5
    2 3 10
    5 3 2
    1 4 3
    4 6 8
    5 6 7
    6 8 3
    3 8 5
    3 9 6
    6 7 4
    7 9 11
    */
    public static void KruskalAlgorithm(ref PriorityQueue<HashSet<string>, int> edges, int n)
    {
        DisjointSet ds = new DisjointSet(n);
        int prev_size;
        string[] arr;
        Console.WriteLine("Minimum spanning forest:");

        while (edges.Count > 0)
        {
            edges.TryDequeue(out var two_vertices, out var edge);
            arr = two_vertices.ToArray();

            if (!ds.SameSet(int.Parse(arr[0]), int.Parse(arr[1])))
            {
                ds.Union(int.Parse(arr[0]), int.Parse(arr[1]));
                Console.WriteLine("{0} ({1}-{2})", edge, arr[0], arr[1]);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of edges: ");
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, GraphVertex> vertices = new Dictionary<string, GraphVertex>();
        PriorityQueue<HashSet<string>, int> edges = new PriorityQueue<HashSet<string>, int>();

        string[] temp;
        string a, b;
        int edge_value;
        Console.WriteLine("Enter edges in the form \"vertex1 vertex2 edge_value\":");

        for (int i = 0; i < n; ++i)
        {
            temp = Console.ReadLine().Split(' ');
            a = temp[0];
            b = temp[1];
            edge_value = int.Parse(temp[2]);

            edges.Enqueue(new HashSet<string> { a, b }, edge_value);

            if (!vertices.ContainsKey(a))
                vertices.Add(a, new GraphVertex(a));
            if (!vertices.ContainsKey(b))
                vertices.Add(b, new GraphVertex(b));

            vertices[a].AddAdjacentVertex(vertices[b], edge_value);
            vertices[b].AddAdjacentVertex(vertices[a], edge_value);
        }

        Console.WriteLine("\nDetailed view of vertices:");
        foreach (GraphVertex vertex in vertices.Values)
            vertex.PrintVertex();
        Console.WriteLine();

        Console.Write("Enter 0 to use DFS, 1 to use BFS, 2 to try Dijkstra's, 3 to try Kruskal's algorithm: ");
        int mode = int.Parse(Console.ReadLine());
        Console.WriteLine();

        switch (mode)
        {
            case 0:
                DFS(ref vertices);
                break;
            case 1:
                BFS(ref vertices);
                break;
            case 2:
                DijkstraAlgorithm(ref vertices);
                break;
            case 3:
                KruskalAlgorithm(ref edges, n);
                break;
        }
    }
}