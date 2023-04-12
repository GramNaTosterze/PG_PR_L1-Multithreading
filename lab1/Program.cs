using System;
using System.Collections.Generic;
using System.Threading;


namespace lab1
{
    class MainClass
    {
        static public List<int> list = new List<int>() { 1, 2, 4, 5, 6 };
        public static void Main(string[] args)
        {


            Thread t1 = new Thread(() => Add_some("t1"));
            Thread t2 = new Thread(() => Add_some("t2"));
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();


        }
        static public void Try_add(List<int> list, int element, string thread)
        {
            lock (list)
            {
                int idx = list.IndexOf(element);
                if (idx >= 0)
                {
                    Console.WriteLine("F " + element +" "+ thread);
                    return;

                }
                list.Add(element);
                Console.WriteLine("T " + element +" "+ thread);
                return;

            }
        }
        static public void Add_some(string t)
        {
            for (int i = 0; i < 1000; i++)
                Try_add(list, i, t);
        }

    }
}
