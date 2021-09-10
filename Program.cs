using System;
using System.Collections.Generic;
using System.Linq;

namespace euler_249_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> base_sets = new HashSet<int> { 2, 3, 5};

            SubSets all_sets = new SubSets(base_sets);

            all_sets.FindSubsets(base_sets);
            all_sets.PrintSubSets();
        }
    }

    class SubSets
    {
        private HashSet<int> base_set;

        private HashSet<HashSet<int>> subsets;

        private HashSet<int> cleaned_sums;

        private SetEqualityComparer comp = new SetEqualityComparer();
        public SubSets (HashSet<int> base_set)
        {
            this.base_set = base_set;
            subsets = new HashSet<HashSet<int>> (comp);
        }

        public void FindSubsets(HashSet<int> current_set)
        {   if(current_set.Count > 0)
            {
                subsets.Add(current_set);
            }

            foreach(int a in current_set)
            {
                HashSet<int> next_set = new HashSet<int>(current_set);
                next_set.Remove(a);
                FindSubsets(next_set);
            }
        }

        public void PrintHashSet(HashSet<int> the_set)
        {
            foreach (int a in the_set)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }

        public void PrintSubSets()
        {
           
            foreach (HashSet<int> a in subsets)
            {
                //SummedSets();
                Console.Write("{");
                foreach (int b in a)
                {
                    Console.Write(" " + b + ",");
                }
                Console.Write("} ");
            }
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
            cleaned_sums = new HashSet<int>();
            foreach(HashSet<int> a in subsets)
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

class SetEqualityComparer : IEqualityComparer<HashSet<int>>
{
    public bool Equals(HashSet<int> a, HashSet<int> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }
        HashSet<int> resultSet = new HashSet<int>();
        foreach(int x in a)
        {
            if (b.Contains(x))
            {
                resultSet.Add(x);
            }
        }
        return resultSet.Count == a.Count;
    }

    public int GetHashCode(HashSet<int> set)
    {
        int sum = 0;
        foreach(int a in set)
        {
            sum+= a;
        }
        return sum.GetHashCode();
    }
}

