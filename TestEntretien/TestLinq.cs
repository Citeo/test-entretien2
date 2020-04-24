using System;
using System.Collections.Generic;
using System.Linq;

namespace TestEntretien
{
    public class TestLinq
    {
        public static void FindCharWithMaxOccurence()
        {
            List<string> input = new List<string>()
            {
                "aabccccc",
                "ddflfccccc"
            };

            var result = input.SelectMany(s => s.Select(c => new { Character = c, Count = s.Where(item => item == c).Count() })).OrderByDescending(item => item.Count).First().Character;
            Console.WriteLine(result);
        }
        public static void MergeIndexAndRemoveDuplicate()
        {
            /* RESULTAT ATTENDU
            * 
            * Dictionary<string, List<int>> c = new Dictionary<string, List<int>>()
           {

               {"a", {1} },{"b", {45}, {"c",{45,22,30} }
           };
           */

            List<Dictionary<string, int>> input = new List<Dictionary<string, int>>()
            {
                new Dictionary<string, int>()
                {
                    {"a",1 },{"b",20},{"c",45}
                },
                new Dictionary<string, int>()
                {
                    {"a",10 },{"c",22},{"b",45}
                },
                new Dictionary<string, int>()
                {
                    {"a",10 },{"c",30},{"b",20}
                }
            };

            var result = input.SelectMany(dico => dico).GroupBy(pair => pair.Key, pair => pair.Value).Select(group => group);
            //.Select(group => group.GroupBy(item => item.Value).Where(item => item.Count() < 2));
        }



    }
}
