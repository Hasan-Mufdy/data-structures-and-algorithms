using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        string[] n1 = { "Metroville", "Pandora" };
        Console.WriteLine("Cost:" + BusinessTripCost(CreateGraph(), n1));

        string[] n2 = { "Arendelle", "Monstropolis", "Naboo" };
        Console.WriteLine("Cost:" + BusinessTripCost(CreateGraph(), n2));

        string[] n3 = { "Naboo", "Pandora" };
        Console.WriteLine("Cost:" + BusinessTripCost(CreateGraph(), n3));

        string[] n4 = { "Narnia", "Arendelle", "Naboo" };
        Console.WriteLine("Cost:" + BusinessTripCost(CreateGraph(), n4));
    }


    public static Dictionary<string, Dictionary<string, int>> CreateGraph()
    {
        var graph = new Dictionary<string, Dictionary<string, int>>();



        graph["Metroville"] = new Dictionary<string, int>
        {
            { "Pandora", 82 },
            { "Narnia", 37 }
        };

        graph["Pandora"] = new Dictionary<string, int>
        {
            { "Metroville", 82 },
            { "Arendelle", 150 }
        };

        graph["Arendelle"] = new Dictionary<string, int>
        {
            { "Pandora", 150 },
            { "Monstropolis", 42 },
            { "Metroville", 99 }
        };

        graph["Monstropolis"] = new Dictionary<string, int>
        {
            { "Arendelle", 42 },
            { "Metroville", 105 },
            { "Naboo", 73 }
        };

        graph["Naboo"] = new Dictionary<string, int>
        {
            { "Monstropolis", 73 },
            { "Metroville", 26 },
            { "Narnia", 250 }
        };

        graph["Narnia"] = new Dictionary<string, int>
        {
            { "Metroville", 37 },
            { "Naboo", 250 }
        };

        return graph;
    }

    public static int? BusinessTripCost(Dictionary<string, Dictionary<string, int>> graph, string[] n)
    {
        int totalCost = 0;

        for (int i = 0; i < n.Length - 1; i++)
        {
            string source = n[i];
            string destination = n[i + 1];

            if (graph.ContainsKey(source) && graph[source].ContainsKey(destination))
            {
                totalCost += graph[source][destination];
            }
            else
            {
                return null;
            }
        }


        return totalCost;
    }
}
