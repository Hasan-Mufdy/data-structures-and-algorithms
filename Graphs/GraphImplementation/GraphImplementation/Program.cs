using System;
using System.Collections.Generic;

namespace GraphDemo
{

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
            Console.WriteLine();
            Console.WriteLine($"Total number of vertices in the graph: {graph.Size}");

            //////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Breadth-First Traversal:");
            var bfsOrder = graph.BreadthFirstTraversal(a);
            foreach (var vertex in bfsOrder)
            {
                Console.Write($"{vertex.Value} ");
            }
            Console.WriteLine();

            //////////////////////////////////////////////////////////////////////////////
            Graph<string> graph2 = new Graph<string>();

            Vertex<string> a2 = graph2.AddVertex("a");
            Vertex<string> b2 = graph2.AddVertex("b");
            Vertex<string> c2 = graph2.AddVertex("c");
            Vertex<string> d2 = graph2.AddVertex("d");
            Vertex<string> e2 = graph2.AddVertex("e");
            Vertex<string> f2 = graph2.AddVertex("f");
            Vertex<string> g2 = graph2.AddVertex("g");
            Vertex<string> h2 = graph2.AddVertex("h");

            graph2.AddEdge(a2, b2);
            graph2.AddEdge(a2, d2);

            graph2.AddEdge(b2, c2);
            graph2.AddEdge(b2, d2);

            graph2.AddEdge(c2, g2);

            graph2.AddEdge(d2, e2);
            graph2.AddEdge(d2, h2);
            graph2.AddEdge(d2, f2);
            // graph2.AddEdge(d2, a2);
            // graph2.AddEdge(d2, b2);

            // graph2.AddEdge(e2, d2);
            // graph2.AddEdge(f2, d2);
            graph2.AddEdge(f2, h2);

            //graph2.AddEdge(g2, h2);
            graph2.AddEdge(h2, f2);
            graph2.AddEdge(h2, d2);


            //////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Depth-First Pre-Order Traversal:");
            var dfPreOrder = graph2.DepthFirstPreOrderTraversal(a2);
            foreach (var vertex in dfPreOrder)
            {
                Console.Write($"{vertex.Value} ");
            }
            Console.WriteLine();



        }
    }


    public class Vertex<T>
    {
        public T Value { get; set; }

        public Vertex(T value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class Edge<T>
    {
        public int Weight { get; set; }
        public Vertex<T> Vertex { get; set; }
    }

    public class Graph<T>
    {
        public ICollection<Vertex<T>> DepthFirstPreOrderTraversal(Vertex<T> startVertex)
        {
            if (!AdjacencyList.ContainsKey(startVertex))
                throw new InvalidOperationException("Start vertex is not in the graph.");

            List<Vertex<T>> visitedNodes = new List<Vertex<T>>();
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();

            DFPO(startVertex, visited, visitedNodes);

            return visitedNodes;
        }

        private void DFPO(Vertex<T> currentVertex, HashSet<Vertex<T>> visited, List<Vertex<T>> visitedNodes)
        {
            visited.Add(currentVertex);
            visitedNodes.Add(currentVertex);

            foreach (var edge in AdjacencyList[currentVertex])
            {
                if (!visited.Contains(edge.Vertex))
                {
                    DFPO(edge.Vertex, visited, visitedNodes);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////
        public ICollection<Vertex<T>> BreadthFirstTraversal(Vertex<T> startVertex)
        {
            if (!AdjacencyList.ContainsKey(startVertex))
                throw new InvalidOperationException("Start vertex is not in the graph.");

            List<Vertex<T>> visitedNodes = new List<Vertex<T>>();
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();

            queue.Enqueue(startVertex);
            visited.Add(startVertex);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                visitedNodes.Add(currentVertex);

                foreach (var edge in AdjacencyList[currentVertex])
                {
                    if (!visited.Contains(edge.Vertex))
                    {
                        visited.Add(edge.Vertex);
                        queue.Enqueue(edge.Vertex);
                    }
                }
            }

            return visitedNodes;
        }

        ////////////////////////////////////////////////////////////////////////////////////
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
}
