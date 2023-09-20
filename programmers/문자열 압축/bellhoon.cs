https://school.programmers.co.kr/learn/courses/30/lessons/60057
using System;
using System.Diagnostics;

namespace 문자열압축
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            string[] testCases = { "aabbaccc", "ababcdcdababcdcd", "abcabcdede", "abcabcabcabcdededededede", "xababcdcdababcdcd" };
            int[] expectedResults = { 7, 9, 8, 14, 17 };

            for (int i = 0; i < testCases.Length; i++)
            {
                long beforeMemory = GC.GetTotalMemory(true);

                Stopwatch sw = new Stopwatch();
                sw.Start();

                int result = program.solution(testCases[i]);

                sw.Stop();

                long afterMemory = GC.GetTotalMemory(true);

                Console.WriteLine($"Test Case {i + 1}:");
                Console.WriteLine($"Input: \"{testCases[i]}\", Expected Result: {expectedResults[i]}, Actual Result: {result}");
                Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds} ms");
                Console.WriteLine($"Memory Used: {afterMemory - beforeMemory} bytes");
                Console.WriteLine("-----------------------------");
            }
        }
        public int solution(string s)
        {
            int minCompressedLength = s.Length;

            for (int sliceLength = 1; sliceLength <= s.Length / 2; sliceLength++)
            {
                string compressedString = "";
                string previousSlice = s.Substring(0, sliceLength);
                int count = 1;

                for (int j = sliceLength; j < s.Length; j += sliceLength)
                {
                    if (j + sliceLength > s.Length)
                    {
                        compressedString += s.Substring(j);
                        break;
                    }

                    string currentSlice = s.Substring(j, sliceLength);

                    if (previousSlice == currentSlice)
                    {
                        count++;
                    }
                    else
                    {
                        compressedString += (count > 1 ? count.ToString() : "") + previousSlice;
                        previousSlice = currentSlice;
                        count = 1;
                    }
                }

                compressedString += (count > 1 ? count.ToString() : "") + previousSlice;
                minCompressedLength = Math.Min(minCompressedLength, compressedString.Length);
            }

            return minCompressedLength;
        }
    }
}
