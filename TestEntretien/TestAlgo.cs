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
            string[] input = { "reza","eat", "tea", "tan", "ate", "nat", "bat", "bta", "azer","btae"};
            Dictionary<string, List<string>> output =new Dictionary<string, List<string>>();

            for (int i = 0; i < input.Length; i++)
            {
                string result = input[i];
                var x = result.OrderBy(s => s).ToArray();
                result = String.Concat(x);
                if (output.ContainsKey(result))
                {
                    output[result].Add(input[i]);
                }else
                {
                    output.Add(result,new List<string> { input[i] });
                }
                //output.Add(input[i], result);
            }

            //var distinctOutput = output.Distinct();
            //foreach (var word in distinctOutput)
            //{
            //    Console.WriteLine(word);
            //}
        }
    }
}
