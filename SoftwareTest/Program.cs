using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text; 

namespace SoftwareTest
{
    /**
     * Welcome to the Software Test. Please make sure you
     * read the instructions carefully.
     *
     * FAQ:
     * Can I use linq? Yes.
     * Can I cheat and look things up on Stack Overflow? Yes.
     * Can I use a database? No.
     */

    /// There are two challenges in this file
    /// The first one should takes ~10 mins with the
    /// second taking between ~30-40 mins.
    public interface IChallenge
    {
        /// Are you a winner?
        bool Winner();
    }

    /// Lets find out
    public class Program
    {
        /// <summary>
        /// Challenge Uno - NumberCalculator
        ///
        /// Fill out the TODOs with your own code and make any
        /// other appropriate improvements to this class.
        /// </summary>
        public class NumberCalculator : IChallenge
        {
            /// <summary>
            /// Finds the highest number
            /// </summary>
            /// <param name="numbers">The array of numbers</param>
            /// <returns>The highest number</returns>
            public int FindMax(int[] numbers)
            {
                return numbers.Max();
            }

            /// <summary>
            /// Find the 'n' highest numbers
            /// </summary>
            /// <param name="numbers">The array of numbers</param>
            /// <param name="n">Count of numbers to return</param>
            /// <returns>The highest number</returns>
            public int[] FindMax(int[] numbers, int n)
            {
                //  return numbers.OrderByDescending(num => num).TakeWhile((num, h) => h < n).ToArray();
                return numbers.OrderByDescending(num => num)
                    .Take(n).ToArray();
            }

            /// <summary>
            /// Sorts the numbers
            /// </summary>
            /// <param name="numbers">The array of numbers</param>
            /// <returns>The array of numbers sorted.</returns>
            public int[] Sort(int[] numbers)
            {
                return numbers.OrderBy(i => i).ToArray();
            }

            public bool Winner()
            {
                var numbers = new[] { 5, 7, 5, 3, 6, 7, 7 };
                var sorted = Sort(numbers);
                var maxes = FindMax(numbers, 2);

                // TODO: Are the following test cases sufficient, to prove your code works
                // as expected? If not either write more test cases and/or describe what
                // other tests cases would be needed.

                //##### Some cases will need to be written for bad data params
                //##### var willFailFindMax = FindMax(null, -1);
                //##### Need to check for bad params within the above methods 

                return sorted.First() == 3
                       && sorted.Last() == 7
                       && FindMax(numbers) == 7
                       && maxes[0] == 7
                       && maxes[1] == 7;
            }
        }

        /// <summary>
        /// Challenge Due - Run Length Encoding
        ///
        /// RLE is a simple compression scheme that encodes runs of data into
        /// a single data value and a count. It's useful for data that has lots
        /// of contiguous values (for example it was used in fax machines), but
        /// also has lots of downsides.
        ///
        /// For example, aaaaaaabbbbccccddddd would be encoded as
        ///
        /// 7a4b4c5d
        ///
        /// You can find out more about RLE here...
        /// http://en.wikipedia.org/wiki/Run-length_encoding
        ///
        /// In this exercise you will need to write an RLE **Encoder** which will take
        /// a byte array and return an RLE encoded byte array.
        /// </summary>
        public class RunLengthEncodingChallenge : IChallenge
        {
            /// <summary>
            /// Encodes a byte array using the 'RLE model'
            /// </summary>
            /// <param name="original">The byte array to be encoded</param>
            /// <returns>The encoded array</returns>
            public byte[] Encode(byte[] original)
            {
                //TODO this is not good code and needs to be refactored...
                if (original == null)
                    throw new ArgumentNullException("original");

                IEnumerator<byte> byteEnumerator = ((IEnumerable<byte>)original).GetEnumerator();
                if (!byteEnumerator.MoveNext())
                    return null;

                List<byte> results = new List<byte>();
                byte valueCount = 1;
                byte valueInArray = byteEnumerator.Current;

                while (byteEnumerator.MoveNext())
                {
                    if (byteEnumerator.Current != valueInArray)
                    {
                        results.Add(valueCount);
                        results.Add(valueInArray);
                        valueInArray = byteEnumerator.Current;
                        valueCount = 1;
                    }
                    else
                        valueCount += 1;
                }

                results.Add(valueCount);
                results.Add(valueInArray);

                return results.ToArray();
            }

            public bool Winner()
            {
                // TODO: Are the following test cases sufficient, to prove your code works
                // as expected? If not either write more test cases and/or describe what
                // other tests cases would be needed.

                var testCases = new[]
                {
                    new Tuple<byte[], byte[]>(new byte[]{0x01, 0x02, 0x03, 0x04}, new byte[]{0x01, 0x01, 0x01, 0x02, 0x01, 0x03, 0x01, 0x04}),
                    new Tuple<byte[], byte[]>(new byte[]{0x01, 0x01, 0x01, 0x01}, new byte[]{0x04, 0x01}),
                    new Tuple<byte[], byte[]>(new byte[]{0x01, 0x01, 0x02, 0x02}, new byte[]{0x02, 0x01, 0x02, 0x02})
                };

                // TODO: What limitations does your algorithm have (if any)?
                //##### I'm failing DRY when adding to the results list
                //##### Theres a lot of lines in the algorithm
                //##### To deal with the first and last values im working 'outside the loop'. 
                //##### The method could have been written 'Generically' to deal with other data types.

                // TODO: What do you think about the efficiency of this algorithm for encoding data?
                //##### Im sure there's much more efficient ways but I'd have to spend more time researching, What Im trying to say is the above code will suffice unless execution time is of the upmost importance.

                foreach (var testCase in testCases)
                {
                    var encoded = Encode(testCase.Item1);
                    var isCorrect = encoded.SequenceEqual(testCase.Item2);

                    if (!isCorrect)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public static void Main(string[] args)
        {
            var challenges = new IChallenge[]
            {
                new NumberCalculator(),
                new RunLengthEncodingChallenge()
            };

            foreach (var challenge in challenges)
            {
                var challengeName = challenge.GetType().Name;

                var result = challenge.Winner()
                    ? string.Format("You win at challenge {0}", challengeName)
                    : string.Format("You lose at challenge {0}", challengeName);

                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}