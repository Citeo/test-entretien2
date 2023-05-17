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
        public static void Test1()
        {            
            List<List<int>> datas = new List<List<int>>()
            {
                new List<int>() { 1,2,3,4,5,6,7,8,9},
                new List<int>() { 6,10,11,8,13,14,15,23},
                new List<int>() { 6,23,7,8},
                new List<int>() { 2,50,100,88},
            };             
        }

        public static void Test2()
        {
            List<string> input = new List<string>() { "reza", "eat", "tea", "tan", "ate", "nat", "bat", "bta", "azer" };
           
            for(int i =0; i< input.Count; i++)
            {
                if(input[i].Length == input[i+1].Length)
                {
                    input[i]

                }
                else
                {
                    
                }
            }
            
        }



        public void Test3()
        {
            var input = new [] {1, 2, 7, 8, 11, 7};
            var sum = 20;
        }
    }
}
