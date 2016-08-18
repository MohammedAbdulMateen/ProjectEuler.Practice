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

        /// <summary>
        /// The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
        /// 73167176531330624919225119674426574742355349194934
        /// 96983520312774506326239578318016984801869478851843
        /// 85861560789112949495459501737958331952853208805511
        /// 12540698747158523863050715693290963295227443043557
        /// 66896648950445244523161731856403098711121722383113
        /// 62229893423380308135336276614282806444486645238749
        /// 30358907296290491560440772390713810515859307960866
        /// 70172427121883998797908792274921901699720888093776
        /// 65727333001053367881220235421809751254540594752243
        /// 52584907711670556013604839586446706324415722155397
        /// 53697817977846174064955149290862569321978468622482
        /// 83972241375657056057490261407972968652414535100474
        /// 82166370484403199890008895243450658541227588666881
        /// 16427171479924442928230863465674813919123162824586
        /// 17866458359124566529476545682848912883142607690042
        /// 24219022671055626321111109370544217506941658960408
        /// 07198403850962455444362981230987879927244284909188
        /// 84580156166097919133875499200524063689912560717606
        /// 05886116467109405077541002256983155200055935729725
        /// 71636269561882670428252483600823257530420752963450
        /// Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
        /// </summary>
        [TestMethod]
        public void Largest_Product_In_A_Series()
        {
            // Arrange
            long maxProduct = 0;

            var digitString = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

            var arr = digitString.ToArray();

            // Act
            for (int i = 0; i < arr.Length - 12; i++)
            {
                long product = 1;

                for (int j = i; j < i + 13; j++)
                {
                    var charAt = char.GetNumericValue(arr[j]);
                    product *= Convert.ToInt32(charAt);
                }

                if (product > maxProduct)
                {
                    maxProduct = product;
                }
            }

            // Assert
            Assert.AreEqual(23514624000, maxProduct);
        }

        /// <summary>
        /// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
        /// a2 + b2 = c2
        /// For example, 32 + 42 = 9 + 16 = 25 = 52.
        /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
        /// Find the product abc.
        /// </summary>
        [TestMethod]
        public void Special_Pythagorean_Triplet()
        {
            // Arrange
            var product = 0;

            // Act
            for (var a = 100; a < 500; a++)
            {
                for (var b = 100; b < 500; b++)
                {
                    for (var c = 100; c < 500; c++)
                    {
                        if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) && a + b + c == 1000 && a < b && b < c)
                        {
                            product = a * b * c;
                        }
                    }
                }
            }

            // Assert
            Assert.AreEqual(31875000, product);
        }

        /// <summary>
        /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
        /// Find the sum of all the primes below two million.
        /// </summary>
        [TestMethod]
        public void Summation_Of_Primes()
        {
            // Arrange
            long sum = 0;

            // Act
            for (long i = 2; i < 2000000; i++)
            {
                var isPrime = true;

                var k = Math.Round(Math.Sqrt(i));
                for (long j = 2; j <= k; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    sum += i;
                }
            }

            // Assert
            Assert.AreEqual(142913828922, sum);
        }
    }
}
