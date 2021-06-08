using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

            var allDatta = new List<int>();

            datas.ForEach(item =>
            {
                allDatta.AddRange(item);
            });

            var duplicatedElement = new Dictionary<int, int>();
            foreach (int item in allDatta)
            {
                if (duplicatedElement.ContainsKey(item))
                {
                    var val = duplicatedElement[item] + 1;
                    duplicatedElement[item] = val;
                }
                else
                {
                    duplicatedElement.Add(item, 1);
                }
            }

            duplicatedElement.Where(x => x.Value > 1).Select(y => y.Key).ToList().ForEach(key =>
           {
               datas.ForEach(item =>
               {
                   item.Remove(key) ;
               });
           } );

            datas.ForEach(item =>
            {
            item.ForEach(elem => { Console.Write(elem); Console.Write(" "); });
                Console.WriteLine("****");
            });
        }
        
        public static void GroupAnagram()
        {
            Console.WriteLine("GroupAnagram start");
            string[] input = { "reza","eat", "tea", "tan", "ate", "nat", "bat", "bta", "azer" };

           
        }

       


    }
}
