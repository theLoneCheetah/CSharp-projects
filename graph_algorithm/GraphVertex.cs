using System;
using System.Collections.Generic;

class GraphVertex
{
    private string value;
    private Dictionary<GraphVertex, int> adjacent = new Dictionary<GraphVertex, int>();

    public GraphVertex(string value)
    {
        this.value = value;
    }

    public void AddAdjacentVertex(GraphVertex vertex, int edge_value)
    {
        this.adjacent.Add(vertex, edge_value);
    }

    public void PrintVertex()
    {
        Console.Write("Vertex: {0}, adjacent:", this.value);
        foreach (var vertex in this.adjacent)
        {
            Console.Write(" {0} ({1})", vertex.Key.value, vertex.Value);
        }
        Console.WriteLine();
    }

    public void DFS(ref Dictionary<string, bool> visited)
    {
        Console.WriteLine(this.value);
        visited[this.value] = true;

        foreach (var vertex in this.adjacent)
        {
            if (!visited[vertex.Key.value])
                vertex.Key.DFS(ref visited);
        }
    }

    public void BFS(ref Dictionary<string, bool> visited, ref Queue<string> to_visit)
    {
        Console.WriteLine(this.value);

        foreach (var vertex in this.adjacent)
        {
            if (!visited[vertex.Key.value])
            {
                to_visit.Enqueue(vertex.Key.value);
                visited[vertex.Key.value] = true;
            }
        }
    }

    public void ShortestAdjacentPaths(ref Dictionary<string, int> shortest_path, ref PriorityQueue<string, int> nearest)
    {
        int dist;
        foreach (var adj in this.adjacent)
        {
            dist = shortest_path[this.value] + adj.Value;
            if (dist < shortest_path[adj.Key.value])
            {
                shortest_path[adj.Key.value] = dist;
                nearest.Enqueue(adj.Key.value, dist);
            }
        }
    }
}
