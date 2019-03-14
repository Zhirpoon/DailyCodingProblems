using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #11
    Implement an autocomplete system. That is, given a query string s and a set of all possible query strings, return all strings in the set that have s as a prefix.

    For example, given the query string de and the set of strings [dog, deer, deal], return [deer, deal].

    Hint: Try preprocessing the dictionary into a more efficient data structure to speed up queries.
*/
namespace DCP11
{
    public class DCP11
    {
        // fast and easy, but not an efficient data structure
        public static string[] FastAndEasy(string query, string[] words)
        {
            return words
                .Where(
                    w => w.Length >= query.Length && 
                    w.Substring(0, query.Length) == query
                ).ToArray();
        }

        public class Trie
        {
            private class Node
            {
                public Node()
                {
                    Children = new Dictionary<char, Node>();
                }

                public Node(char c)
                    : this()
                {
                    Character = c;
                }

                public char? Character;
                public IDictionary<char, Node> Children;
                public string Value;

                
            }

            private Node root = new Node();

            public void Add(string word)
            {
                var current = root;

                for (int i = 0; i < word.Length; i++)
                {
                    var letter = word[i];

                    if (!current.Children.ContainsKey(letter))
                    {
                        var node = new Node(letter);

                        current.Children.Add(letter, node);
                    }

                    current = current.Children[letter];
                }

                current.Value = word;
            }

            public ICollection<string> Autocomplete(string query)
            {
                var node = GetNode(query);

                var results = GetWords(node);

                return results;
            }

            private ICollection<string> GetWords(Node node)
            {
                var results = new List<string>();

                if (node == null)
                {
                    return results;
                }

                if (!string.IsNullOrEmpty(node.Value))
                {
                    results.Add(node.Value);
                }

                foreach (var k in node.Children)
                {
                    results.AddRange(GetWords(k.Value));
                }

                return results;
            }

            private Node GetNode(string query)
            {
                var current = root;

                for (int i = 0; i < query.Length; i++)
                {
                    var letter = query[i];

                    if (current.Children.ContainsKey(letter))
                    {
                        current = current.Children[letter];
                    }
                    else
                    {
                        return null;
                    }
                }

                return current;
            }
        }
        


        public static void Main(string[] args)
        {

            var words = new string[] { "dog", "deer", "deal" };

            var query = Console.ReadLine();

            // calling fast and easy, not using the hint of efficient data structure
            var fastEasyResults = FastAndEasy(query, words);
            Console.WriteLine($"Fast and easy results: \n[{string.Join(",", fastEasyResults)}]");

            // store them in a trie to remove unnecessary storage and for faster searching
            Trie trie = new Trie();

            foreach(var word in words)
            {
                trie.Add(word);
            }

            var trieStoreResults = trie.Autocomplete(query);
            Console.WriteLine($"Trie store results: \n[{string.Join(",", trieStoreResults)}]");
        }
    }
}
