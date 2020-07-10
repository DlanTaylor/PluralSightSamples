using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestCSharp
{
    class Program
    {

        static void getQuery(int[] scores, int? minScore = null)
        {
            IEnumerable<int> scoreQuery = 
                from score in scores
                // where score >= (minScore ??= 0)
                where score == 80
                orderby score descending
                select score;

            foreach (int testScore in scoreQuery)
            {
                Console.WriteLine(testScore);
            }
        }
        
        static void Main(string[] args)
        {
            int[] scores = { 99, 80, 93, 71, 65, 50, 83, 88 };

            getQuery(scores, 70);
        }
    }
}
