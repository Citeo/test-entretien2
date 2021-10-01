using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TestEntretien
{
    public class TestAlgo
    {

        /// <summary>
        /// grouper les anagrammes 
        /// 10 min
        /// </summary>
        public static void RemoveDuplicate()
        {
            Console.WriteLine("RemoveDuplicate start");
            List<List<int>> datas = new List<List<int>>()
            {
                new List<int>() { 1,2,3,4,5,6,7,8,9},
                new List<int>() { 6,10,11,8,13,14,15,23},
                new List<int>() { 6,23,7,8},
                new List<int>() { 2,50,100,88},
            };

        }

        public static void GroupAnagram()
        {
            Console.WriteLine("GroupAnagram start");
            string[] input = { "reza", "eat", "tea", "tan", "ate", "nat", "bat", "bta", "azer" };

            var results = new Dictionary<int, List<int>>();
            bool known;

            for (int refIndex = 0; refIndex < input.Length; ++refIndex)
            {
                known = false;
                //  Ne pas traiter 2 fois
                foreach(var pair in results)
                {
                    if (pair.Value != null && pair.Value.Contains(refIndex))
                    {
                        known = true;
                        break;
                    }
                }

                if (!known)
                {
                    results.Add(refIndex, new List<int>());
                    var charCountRef = new Dictionary<char, int>();

                    for (int otherIndex = refIndex + 1; otherIndex < input.Length; ++otherIndex)
                    {
                        charCountRef.Clear();
                        for (int charIndex = 0; charIndex < input[refIndex].Length; ++charIndex)
                        {
                            var charAtIndex = input[refIndex][charIndex];
                            if (charCountRef.ContainsKey(charAtIndex))
                                charCountRef[charAtIndex] += 1;
                            else
                                charCountRef.Add(charAtIndex, 1);
                        }

                        if (input[refIndex].Length == input[otherIndex].Length)
                        {
                            bool isOk = false;
                            for (int charIndexOther = 0; charIndexOther < input[otherIndex].Length; ++charIndexOther)
                            {
                                var charAtIndexOther = input[otherIndex][charIndexOther];
                                if (!charCountRef.ContainsKey(charAtIndexOther))
                                {
                                    break;  // return false
                                }
                                else
                                {
                                    charCountRef[charAtIndexOther] -= 1;
                                    if (charCountRef[charAtIndexOther] < 0)
                                        break;
                                }
                                isOk = true;
                            }

                            if (isOk && charCountRef.Values.All(value => value == 0))
                            {
                                results[refIndex].Add(otherIndex);
                            }
                        }
                    }
                }
            }

            foreach (var pair in results)
            {
                Console.WriteLine($"{input[pair.Key]} {string.Join(' ', pair.Value.Select(val => input[val]))}");
            }
        }




    }
}
