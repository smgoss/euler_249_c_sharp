using System;
using System.Collections.Generic;
using System.Linq;

namespace euler_249_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string k_string = Console.ReadLine();
            string n_string = Console.ReadLine();
            int k = 0;
            Int32.TryParse(k_string, out k);
            List<string> n_strings = n_string.Split().ToList();
            List<int> n_list = new List<int>();
            for (int i = 0; i < k; i ++)
            {
                int out_int;
                Int32.TryParse(n_strings[i], out out_int);
                n_list.Add(out_int);
            }
            bool first = true;
            foreach(int n in n_list)
            {
                SubSets all_sets = new SubSets();
                if (!first)
                    Console.Write(" ");
                else
                    first = false;
                HashSet<int> n_set = new HashSet<int>(all_sets.FindAllPrimes(n));
                all_sets.FindSubsets(n_set);
                all_sets.PrimeSets();
                all_sets.PrintCount();
                // find all primes
                // find all prime subsets
                // count result and print
            }
        }
        
    }

    class SubSets
    {
        private HashSet<HashSet<int>> subsets;

        private SetEqualityComparer comp = new SetEqualityComparer();
        public SubSets ()
        {
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

        public void PrintSubSets()
        {
           
            foreach (HashSet<int> a in subsets)
            {
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
        public void PrimeSets()
        {
            HashSet<HashSet<int>> prime_sets = new HashSet<HashSet<int>>();
            foreach(HashSet<int> a in subsets)
            {
                int sum = 0;
                foreach (int b in a)
                {
                    sum += b;
                }
                if (IsPrime(sum))
                {
                    prime_sets.Add(a);
                }
            }
            subsets = prime_sets;
        }
        public void PrintCount()
        {
            Console.Write(subsets.Count);
        }
        public HashSet<int> FindAllPrimes(int n)
        {
            HashSet<int> n_primes = new HashSet<int>();
            for(int i = 0; i < n; i ++)
            {
                if (IsPrime(i))
                {
                    n_primes.Add(i);
                }
            }
            return n_primes;
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

