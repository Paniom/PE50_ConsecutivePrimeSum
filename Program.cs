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

            int limitNumber = 1000;
            var limitCheck = Math.Sqrt(limitNumber);
            int sumOfConsecutiveElements;
            int currentMaxElementCount = 1;
            int largestSummedPrime = 0;

            for (int integerCheck = 3; integerCheck < limitNumber; integerCheck += 2)
            {

                for (int index = 0; index < fullPrimesList.Count; index++)
                {
                    var provenPrime = fullPrimesList[index];

                    if (integerCheck % provenPrime == 0)
                    {
                        break;
                    }
                    if (integerCheck % provenPrime != 0 && index == (fullPrimesList.Count - 1))
                    {
                        fullPrimesList.Add(integerCheck);
                    }
                }
            }

            Console.WriteLine("The number of primes under " + limitNumber.ToString() + " is " + (fullPrimesList.Count).ToString());
            Console.WriteLine();
            foreach (var i in fullPrimesList)
            {
                Console.Write(i.ToString() + " , ");
            }

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
                        if (consecutiveElements.Count > currentMaxElementCount)
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
            Console.WriteLine("The prime under " + limitNumber.ToString() + " that is a sum of the most consecutive primes is " + largestSummedPrime.ToString() + " - which is the sum of " + (currentMaxElementCount).ToString() + " consecutive prime numbers:");
            Console.WriteLine();
            Console.Write(largestSummedPrime.ToString() + " = ");


            int totalPrintCount = printingList.Count;

            for (int count = 0; count < totalPrintCount; count++)
            {
                if (count != (totalPrintCount - 1))
                {
                    Console.Write(printingList[count].ToString() + " + ");
                }
                else
                {
                    Console.Write(printingList[count].ToString());
                }
            }
            Console.WriteLine();

        }
    }
}
