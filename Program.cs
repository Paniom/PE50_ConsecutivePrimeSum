using System;
using System.Collections.Generic;

namespace Consecutive_Prime_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> fullPrimesList = new List<int>() {2};
            List<int> printingList = new List<int>() {};

            int limitNumber = 10000;
            var limitCheck = Math.Sqrt(limitNumber);
            int limitIndex;
            int sumOfConsecutiveElements;
            int currentMaxElementCount = 1;
            int largestSummedPrime = 0;

            //for loop to find all primes under a million
            for (int i = 3; i < limitNumber; i += 2)
            {
                var limitLoop = Math.Sqrt(i);

                for (int j = 0; j < fullPrimesList.Count; j++)
                {
                    var entry = fullPrimesList[j];

                    if (i % entry == 0)
                    {
                        break;
                    }
                    if (i % entry != 0 && j == (fullPrimesList.Count - 1))
                    {
                        fullPrimesList.Add(i);
                    }
                }
            }

            Console.WriteLine("The number of primes under " + limitNumber.ToString() + " is " + (fullPrimesList.Count).ToString());
            Console.WriteLine();

            for (int i = 0; i < limitNumber; i++)
            {
                sumOfConsecutiveElements = 0;
                List<int> consecutiveElements = new List<int>() {};
                for (int index = i; index < fullPrimesList.Count; index++)
                {
                    sumOfConsecutiveElements += fullPrimesList[index];
                    consecutiveElements.Add(fullPrimesList[index]);

                    if (fullPrimesList.Contains(sumOfConsecutiveElements))
                    {
                        if (consecutiveElements.Count >= currentMaxElementCount)
                        {
                            currentMaxElementCount = consecutiveElements.Count;
                            Console.WriteLine("Most consecutive primes so far is " + (currentMaxElementCount).ToString() + " which sums to " + sumOfConsecutiveElements.ToString());
                            largestSummedPrime = sumOfConsecutiveElements;
                            printingList.Clear();
                            printingList.AddRange(consecutiveElements);
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("The prime under " + limitNumber.ToString() + " that is a sum of the most consecutive primes is " + largestSummedPrime.ToString() + " - which is the sum of " + (currentMaxElementCount).ToString() + " consecutive prime numbers.");
            Console.WriteLine();
            Console.Write(largestSummedPrime.ToString() + " = ");
            foreach (int i in printingList)
            {
                Console.Write(i.ToString() + " + ");
            }
            Console.WriteLine();
        }
    }
}
