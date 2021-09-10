using System;
using System.Collections.Generic;
using System.Linq;

namespace euler_249_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> base_sets = new List<int> { 2, 3, 5, 7};

            SubSets all_sets = new SubSets(base_sets);

            all_sets.FindSubsets(base_sets);
            all_sets.PrintSubSets();
        }
    }

    class SubSets
    {
        private List<int> base_set;

        private List<List<int>> subsets;

        private List<int> cleaned_sums;
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
            
            //foreach (List<int> a in subsets)
            //{
                SummedSets();
                Console.Write("{");
                foreach (int b in cleaned_sums)
                {
                    Console.Write(" " + b + ",");
                }
                Console.Write("} ");
            //}
        }

        public bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            else if (number == 2)
            {
                return true;
            }
            else if (number % 2 == 0)
            {
                return false;
            }
            for(int i = 3; i < number/2; i ++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void SummedSets()
        {
            cleaned_sums = new List<int>();
            foreach(List<int> a in subsets)
            {
                int sum = 0;
                foreach(int b in a)
                {
                    sum += b;
                }
                //if (!cleaned_sums.Contains(sum))
                //{
                    if (IsPrime(sum))
                    {
                        cleaned_sums.Add(sum);
                    }
                //}
            }
        }
    }
}
