using System;
using System.Collections.Generic;
using System.Linq;

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

            for (var firstIndex = 0; firstIndex < datas.Count - 1; firstIndex++)
            {
                var listDoobloons = new List<int>();
                for (var secondIndex = firstIndex + 1; secondIndex < datas.Count; secondIndex++)
                {
                    var doobloons = datas[firstIndex].Intersect(datas[secondIndex]);
                    datas[secondIndex] = datas[secondIndex].Except(doobloons).ToList();
                    listDoobloons.AddRange(doobloons);
                }

                datas[firstIndex] = datas[firstIndex].Except(listDoobloons.Distinct()).ToList();
            }

            foreach (var list in datas)
            {
                Console.WriteLine("List content");
                Console.WriteLine(string.Join(", ", list));
            }
        }
    }
}
