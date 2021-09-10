﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace euler_249_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> base_sets = new List<int> { 2, 3, 5 };

            SubSets all_sets = new SubSets(base_sets);

            all_sets.FindSubsets(base_sets);
            all_sets.PrintSubSets();
        }
    }

    class SubSets
    {
        private List<int> base_set;

        private List<List<int>> subsets;

        private List<List<int>> cleaned_subsets;
        public SubSets (List<int> base_set)
        {
            this.base_set = base_set;
            subsets = new List<List<int>> ();
        }

        public void FindSubsets(List<int> current_set)
        {   if(current_set.Count > 0)
            {
                subsets.Add(current_set);
            }
            foreach(int a in current_set)
            {
                List<int> next_set = new List<int>(current_set);
                next_set.Remove(a);
                FindSubsets(next_set);
            }
        }

        public void PrintList(List<int> the_set)
        {
            foreach (int a in the_set)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }

        public void PrintSubSets()
        {
            foreach (List<int> a in subsets)
            {
                Console.Write("{");
                foreach (int b in a)
                {
                    
                    Console.Write(" " + b + ",");
                }
                Console.Write("} ");
            }
        }

        public void cleanSubSets()
        {
            List<List<int>> cleanedSet = new List<List<int>>();
            for(int i = 0; i < subsets.Count; i++)
            {
                for(int j = i + 1; j < subsets.Count; j++)
                {
                 //   if( )
                }
            }
        }
    }
}
