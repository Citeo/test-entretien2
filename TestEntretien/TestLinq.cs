using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEntretien
{
    public class TestLinq
    {        
        public static void FindCharWithMaxOccurence()
        {
            int count = 0;
            List<string> input = new List<string>()
            {
                "aabccccc",
                "ddflfccccc"
            };
            for(int i = 0; i<input.Count; i++)
            {
                if(input[i] == input[i+1])
                {
                    
                }
            }
                    
        }
        public static void Test2()
        {
            string input = "aabacccz";
            /* RESULTAT ATTENDU
            /*
            3 : a,c
            *********
            1 : b,z
            */
            //            
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
        }
            
        

        }
    }
