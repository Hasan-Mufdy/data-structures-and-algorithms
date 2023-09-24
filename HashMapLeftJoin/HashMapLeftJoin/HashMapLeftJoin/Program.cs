using System;
using System.Collections.Generic;

public class LeftJoinExample
{

    public static void Main(string[] args)
    {
        // Example input data
        Dictionary<string, string> synonymsHashTable = new Dictionary<string, string>
        {
            { "diligent", "employed" },
            { "fond", "enamored" },
            { "guide", "usher" },
            { "outfit", "garb" },
            { "wrath", "anger" }
        };

        Dictionary<string, string> antonymsHashTable = new Dictionary<string, string>
        {
            { "diligent", "idle" },
            { "fond", "averse" },
            { "guide", "follow" },
            { "flow", "jam" },
            { "wrath", "delight" }
        };

        // Perform left join
        List<List<string>> result = LeftJoin(synonymsHashTable, antonymsHashTable);

        // Print the result
        Console.WriteLine("Result:");
        foreach (var row in result)
        {
            Console.WriteLine($"[{string.Join(", ", row)}]");
        }
    }


    public static List<List<string>> LeftJoin(Dictionary<string, string> synonyms, Dictionary<string, string> antonyms)
    {
        List<List<string>> result = new List<List<string>>();

        foreach (var key in synonyms.Keys)
        {
            string synonymValue = synonyms[key];
            string antonymValue = antonyms.ContainsKey(key) ? antonyms[key] : null;

            List<string> row = new List<string> { key, synonymValue, antonymValue };
            result.Add(row);
        }

        return result;
    }

   
}
