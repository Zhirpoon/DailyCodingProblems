using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #37
    The power set of a set is the set of all its subsets. Write a function that, given a set, generates its power set.

    For example, given the set {1, 2, 3}, it should return {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}}.

    You may also use a list or array to represent a set.
*/
namespace DCP37
{
    public class DCP37
    {
        public static void Main(string[] args)
        {
            List<int> set = new List<int>() { 1, 2, 3 };
            var sb = new StringBuilder($"The subsets of set {{{string.Join(", ", set)}}} is: ");

            //var result = GetAllSubsets(set);

            var result = SubSetsOf(set);

            sb.Append("{");
            foreach (var sub in result)
            {
                sb.Append($"{{{string.Join(", ", sub)}}} ");
            }
            sb.Append("}");

            Console.WriteLine(sb.ToString());
        }

        public static List<List<int>> GetAllSubsets(List<int> set)
        {
            return GetSubsets(set, new List<List<int>>());
        }

        // recursively the regular way
        public static List<List<int>> GetSubsets(List<int> set, List<List<int>> subsets)
        {
            if(set.Count == 0)
            {
                return subsets;
            }

            var subs = new List<List<int>>();

            if(subsets.Count == 0)
            {
                subs.Add(new List<int>());
                subs.Add(new List<int> { set[0] });
            }
            else
            {
                foreach(var sub in subsets)
                {
                    List<int> newSubset = sub.ToList();
                    newSubset.Add(set[0]);
                    subs.Add(newSubset);
                }
            }

            set.RemoveAt(0);
            subsets.AddRange(subs);
            return GetSubsets(set, subsets);
        }

        // recursively done with LINQ
        public static IEnumerable<IEnumerable<int>> SubSetsOf(IEnumerable<int> source)
        {
            if (!source.Any())
            {
                return Enumerable.Repeat(Enumerable.Empty<int>(), 1);
            }

            var value = source.Take(1);

            var notAdded = SubSetsOf(source.Skip(1));

            var added = notAdded.Select(set => value.Concat(set));

            return added.Concat(notAdded).OrderBy(m => m.Count());
        }
    }
}
