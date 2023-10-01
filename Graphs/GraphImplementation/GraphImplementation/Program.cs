using System;
using System.Collections.Generic;

namespace GraphDemo
{
    public class Vertex<T>
    {
        public T Value { get; set; }

        public Vertex(T value)
        {
            Value = value;
        }
    }

    public class Edge<T>
    {
        public int Weight { get; set; }
        public Vertex<T> Vertex { get; set; }
    }

    public class Graph<T>
    {
        public Dictionary<Vertex<T>, List<Edge<T>>> AdjacencyList { get; private set; }
        public int Size { get; private set; }

        public Graph()
        {
            AdjacencyList = new Dictionary<Vertex<T>, List<Edge<T>>>();
            Size = 0;
        }

        public Vertex<T> AddVertex(T value)
        {
            Vertex<T> vertex = new Vertex<T>(value);
            AdjacencyList[vertex] = new List<Edge<T>>();
            Size++;
            return vertex;
        }

        public void AddEdge(Vertex<T> fromVertex, Vertex<T> toVertex, int weight = 0)
        {
            if (!AdjacencyList.ContainsKey(fromVertex) || !AdjacencyList.ContainsKey(toVertex))
            {
                throw new InvalidOperationException("Both vertices should already be in the graph.");
            }

            AdjacencyList[fromVertex].Add(new Edge<T>
            {
                Weight = weight,
                Vertex = toVertex
            });

            AdjacencyList[toVertex].Add(new Edge<T>
            {
                Weight = weight,
                Vertex = fromVertex
            });
        }

        public ICollection<Vertex<T>> GetVertices()
        {
            return AdjacencyList.Keys;
        }

        public ICollection<Edge<T>> GetNeighbors(Vertex<T> vertex)
        {
            if (!AdjacencyList.ContainsKey(vertex))
                return new List<Edge<T>>();

            return AdjacencyList[vertex];
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();

            Vertex<string> a = graph.AddVertex("1");
            Vertex<string> b = graph.AddVertex("2");
            Vertex<string> c = graph.AddVertex("3");

            graph.AddEdge(a, b);
            graph.AddEdge(b, c);
            graph.AddEdge(c, a);

            Console.WriteLine("Vertices in the graph:");
            foreach (var vertex in graph.GetVertices())
            {
                Console.WriteLine(vertex.Value);
            }

            Console.WriteLine("\nNeighbors of each vertex:");
            foreach (var vertex in graph.GetVertices())
            {
                Console.Write($"Neighbors of {vertex.Value}: ");
                foreach (var edge in graph.GetNeighbors(vertex))
                {
                    Console.Write($"{edge.Vertex.Value} (Weight: {edge.Weight}) ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nTotal number of vertices in the graph: {graph.Size}");
        }
    }
}
