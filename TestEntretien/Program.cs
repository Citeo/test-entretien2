using System;

namespace TestEntretien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting..");
            TestLinq.FindCharWithMaxOccurence();
            //TestAlgo.GroupAnagram();
            //TestAlgo.RemoveDuplicate();
            //TestLinq.MergeIndexAndRemoveDuplicate();      

            Console.WriteLine("complete");
            Console.ReadLine();
        }
    }
}
