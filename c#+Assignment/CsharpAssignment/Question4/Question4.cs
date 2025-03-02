using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Question3.CsharpAssignment
{
    public static class Question4
    {
        public static void CheckConsecutiveNumbers()
        {
            Console.Write("Enter numbers separated by hyphens: ");
            var input = Console.ReadLine();
            var numbers = input.Split('-').Select(int.Parse).ToList();
            bool isConsecutive = numbers.Zip(numbers.Skip(1), (a, b) => b - a).Distinct().Count() == 1;
            Console.WriteLine(isConsecutive ? "Consecutive" : "Not Consecutive");
        }

        public static void CheckDuplicates()
        {
            Console.Write("Enter numbers separated by hyphens: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return;
            var numbers = input.Split('-').Select(int.Parse).ToList();
            Console.WriteLine(numbers.Count != numbers.Distinct().Count() ? "Duplicate" : "No Duplicates");
        }

        public static void ValidateTime()
        {
            Console.Write("Enter time in 24-hour format (HH:MM): ");
            var input = Console.ReadLine();
            if (TimeSpan.TryParse(input, out TimeSpan time) && time.TotalMinutes < 1440)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Invalid Time");
        }

        public static void ConvertToPascalCase()
        {
            Console.Write("Enter words separated by space: ");
            var words = Console.ReadLine().ToLower().Split(' ');
            var pascalCase = string.Join("", words.Select(w => char.ToUpper(w[0]) + w.Substring(1)));
            Console.WriteLine(pascalCase);
        }

        public static void CountVowels()
        {
            Console.Write("Enter an English word: ");
            var word = Console.ReadLine().ToLower();
            int count = word.Count(c => "aeiou".Contains(c));
            Console.WriteLine($"Vowel count: {count}");
        }
    }
}
