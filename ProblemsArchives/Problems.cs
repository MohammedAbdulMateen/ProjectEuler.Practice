﻿namespace ProblemsArchives
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class Problems
    {
        /// <summary>
        /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        /// Find the sum of all the multiples of 3 or 5 below 1000.
        /// </summary>
        [TestMethod]
        public void Multiples_of_3_and_5()
        {
            // Arrange
            var sum = 0;

            // Act
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            // Assert
            Assert.AreEqual(233168, sum);
        }

        /// <summary>
        /// Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        /// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
        /// </summary>
        [TestMethod]
        public void Even_Fibonacci_numbers()
        {
            // Arrange
            var sum = 0;
            var current = 0;
            var next = 1;

            // Act
            while (next < 4000000)
            {
                var temp = next;
                next = current + next;
                current = temp;
                if (next % 2 == 0)
                {
                    sum += next;
                }
            }

            // Assert
            Assert.AreEqual(4613732, sum);
        }

        /// <summary>
        /// The prime factors of 13195 are 5, 7, 13 and 29.
        /// What is the largest prime factor of the number 600851475143 ?
        /// </summary>
        [TestMethod]
        public void Largest_Prime_Factor()
        {
            // Arrange
            var factor = default(long);
            var number = 600851475143;
            var factorsBoundary = Math.Round(Math.Sqrt(number) / 2);

            // Act
            for (long i = 2; i < factorsBoundary; i++)
            {
                if (number % i == 0)
                {
                    // i is a factor
                    var isPrimeFactor = true;
                    var boundary = i - 1;
                    for (long j = 2; j < boundary; j++)
                    {
                        if (i % j == 0)
                        {
                            // i is not a prime
                            isPrimeFactor = false;
                            break;
                        }
                    }

                    if (isPrimeFactor)
                    {
                        factor = i;
                    }
                }
            }

            // Assert
            Assert.AreEqual(6857, factor);
        }

        /// <summary>
        /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
        /// Find the largest palindrome made from the product of two 3-digit numbers.
        /// </summary>
        [TestMethod]
        public void Largest_Palindrome_Product()
        {
            // Arrange
            var palindrome = 0;
            var limit = 999 / 2;

            // Act
            for (int i = 999; i > limit; i--)
            {
                for (int j = 999; j > limit; j--)
                {
                    var mul = i * j;
                    var mulStr = mul.ToString();
                    var reverse = new string(mulStr.Reverse().ToArray());
                    if (mulStr == reverse && palindrome < mul)
                    {
                        palindrome = mul;
                    }
                }
            }

            // Assert
            Assert.AreEqual(906609, palindrome);
        }

        /// <summary>
        /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        /// </summary>
        [TestMethod]
        public void Smallest_Multiple()
        {
            // Arrange
            var result = 0;

            // Act
            for (int i = 2520; ; i++)
            {
                var divisibleByAll = true;
                for (int j = 2; j <= 20; j++)
                {
                    if (i % j != 0)
                    {
                        divisibleByAll = false;
                        break;
                    }
                }

                if (divisibleByAll)
                {
                    result = i;
                    break;
                }
            }

            // Assert
            Assert.AreEqual(232792560, result);
        }

        /// <summary>
        /// The sum of the squares of the first ten natural numbers is,
        /// 12 + 22 + ... + 102 = 385
        /// The square of the sum of the first ten natural numbers is,
        /// (1 + 2 + ... + 10)2 = 552 = 3025
        /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
        /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
        /// </summary>
        [TestMethod]
        public void Sum_Square_Difference()
        {
            // Arrange
            double sumOfSquares = 0D;
            double squareOfSum = 0D;
            double result = 0D;

            // Act
            for (int i = 1; i <= 100; i++)
            {
                sumOfSquares += Math.Pow(i, 2);
                squareOfSum += i;
            }

            squareOfSum = Math.Pow(squareOfSum, 2);
            result = squareOfSum - sumOfSquares;

            // Assert
            Assert.AreEqual(25164150, result);
        }

        /// <summary>
        /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
        /// What is the 10001st prime number?
        /// </summary>
        [TestMethod]
        public void What_Is_10001st_PrimeNumber()
        {
            // Arrange
            var prime = 0;
            var primeNumberCount = 0;

            // Act            
            for (int i = 2; ; i++)
            {
                var boundary = i - 1;
                var isPrime = true;
                for (int j = 2; j <= boundary; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    prime = i;
                    primeNumberCount++;
                }

                if (primeNumberCount == 10001)
                {
                    break;
                }
            }

            // Assert
            Assert.AreEqual(104743, prime);
        }
    }
}
