using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace QuestionFive.CsharpAssignment
{
    public static class QuestionFiveSolution
    {
        /// <summary>
        /// CountWordsInFile: Counts vwords in a file
        /// <returns>Returns null, but displays word count</returns>
        /// </summary>
        public static void CountWordsInFile()
        {
            Console.Write("Enter file path: ");
            var filePath = Console.ReadLine();
            if (File.Exists(filePath))
            {
                var words = File.ReadAllText(filePath).Split(' ', '\n', '\t').Length;
                Console.WriteLine($"Word count: {words}");
            }
            else
                Console.WriteLine("File not found");
        }
        /// <summary>
        /// FindLongestWordInFile: Find longest word in file
        /// <returns>Returns null, display longest word</returns>
        /// </summary>
        public static void FindLongestWordInFile()
        {
            Console.Write("Enter file path: ");
            var filePath = Console.ReadLine();
            if (File.Exists(filePath))
            {
                var longestWord = File.ReadAllText(filePath).Split(' ', '\n', '\t').OrderByDescending(w => w.Length).First();
                Console.WriteLine($"Longest word: {longestWord}");
            }
            else
                Console.WriteLine("File not found");
        }
    }
}
