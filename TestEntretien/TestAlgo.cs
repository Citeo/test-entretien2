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

            var result = new List<List<int>>();

            datas.Select((list, listIndex) => new { Index = listIndex, Value=list })
                 .ToList()
                 .ForEach(item =>
                 {
                     result.Add(new List<int>());
                     foreach(var number in item.Value)
                     {
                         var count = datas.SelectMany(s => s).Where(n => n == number).Count();
                         if (count == 1)
                         {
                             result[item.Index].Add(number);
                         }
                     }
                 });
        }

       


    }
}
