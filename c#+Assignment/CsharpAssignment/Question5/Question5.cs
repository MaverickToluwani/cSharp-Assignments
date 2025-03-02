using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Question3.CsharpAssignment
{
    public static class Question5
    {
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
