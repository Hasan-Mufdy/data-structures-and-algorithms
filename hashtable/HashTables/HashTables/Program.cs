using System;
using System.Collections.Generic;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable<string, string> hashtable = new Hashtable<string, string>();

            hashtable.Set("name", "Hasan");
            hashtable.Set("age", "25");
            hashtable.Set("country", "Jordan");

            Console.WriteLine("Name: " + hashtable.Get("name"));
            Console.WriteLine("Has age: " + hashtable.Has("age"));

            Console.WriteLine("Hash index of 'name': " + hashtable.HashIndex("name"));


            Console.WriteLine("Keys in the hashtable:");
            foreach (var key in hashtable.Keys())
            {
                Console.WriteLine(key);
            }
            ///////////////////////////////////////////////////////////////////////////////
            string input = "hello hello kdjsfl kdsjfl kkajeio idsjfo rr rr";
            string firstRepeatedWord = hashtable.FindFirstRepeatedWord(input);
            Console.WriteLine("First repeated word: " + firstRepeatedWord);
        }
    }

    public class HashNode<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public HashNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    public class Hashtable<TKey, TValue>
    {
        private const int DefaultSize = 100;
        private LinkedList<HashNode<TKey, TValue>>[] Map { get; set; }

        public Hashtable() : this(DefaultSize) { }

        public Hashtable(int size)
        {
            Map = new LinkedList<HashNode<TKey, TValue>>[size];
        }


        ////////////////////////////////////////////////////////////////////////
        public string FindFirstRepeatedWord(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            string[] words = input.Split(' ');

            HashSet<string> seenWords = new HashSet<string>();

            foreach (string word in words)
            {
                string cleanedWord = word;
                if (!string.IsNullOrWhiteSpace(cleanedWord))
                {
                    if (seenWords.Contains(cleanedWord))
                        return cleanedWord;

                    seenWords.Add(cleanedWord);
                }
            }

            return null;
        }
        ////////////////////////////////////////////////////////////////////////
        private int Hash(TKey key)
        {
            int hashValue = 0;

            char[] letters = key.ToString().ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                hashValue += letters[i];
            }

            return hashValue % Map.Length;
        }

        public void Set(TKey key, TValue value)
        {
            int hashKey = Hash(key);

            if (Map[hashKey] == null)
            {
                Map[hashKey] = new LinkedList<HashNode<TKey, TValue>>();
            }

            foreach (var entry in Map[hashKey])
            {
                if (entry.Key.Equals(key))
                {
                    entry.Value = value;
                    return;
                }
            }

            Map[hashKey].AddLast(new HashNode<TKey, TValue>(key, value));
        }

        

        public bool Has(TKey key)
        {
            int hashKey = Hash(key);

            if (Map[hashKey] != null)
            {
                foreach (var entry in Map[hashKey])
                {
                    if (entry.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public TValue Get(TKey key)
        {
            int hashKey = Hash(key);

            if (Map[hashKey] != null)
            {
                foreach (var entry in Map[hashKey])
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }
                }
            }

            throw new KeyNotFoundException($"Key '{key}' not found in the hashtable.");
        }

        public IEnumerable<TKey> Keys()
        {
            List<TKey> keys = new List<TKey>();

            foreach (var bucket in Map)
            {
                if (bucket != null)
                {
                    foreach (var entry in bucket)
                    {
                        keys.Add(entry.Key);
                    }
                }
            }

            return keys;
        }


        public int HashIndex(TKey key)
        {
            return Hash(key);
        }
    }
}
