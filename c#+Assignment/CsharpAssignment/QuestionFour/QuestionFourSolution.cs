using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace QuestionFour.CsharpAssignment
{
    public static class QuestionFourSolution
    {
        /// <summary>
        /// CheckConsecutiveNumbers: Checks if numbers entered that are seperated by hyphens are consecutive
        /// <returns>Returns null, but displays consecutive or not consecutive</returns>
        /// </summary>
        public static void CheckConsecutiveNumbers()
        {
            Console.Write("Enter numbers separated by hyphens: ");
            var input = Console.ReadLine();
            var numbers = input.Split('-').Select(int.Parse).ToList();
            
            for(int i = 0; i < numbers.Count; i++)
            {
                //For out of index problem
                if (i == numbers.Count - 1)
                    break;

                if (numbers[i] + 1 != numbers[i + 1])
                {
                    Console.WriteLine("Not consecutive");
                    return;
                }
            }
            Console.WriteLine("Consecutive");
        }

        /// <summary>
        /// CheckDuplicates: Checks if numbers entered that are seperated by hyphens have duplicates
        /// <returns>Returns null, but displays Duplicate or No Duplicates</returns>
        /// </summary>
        public static void CheckDuplicates()
        {
            Console.Write("Enter numbers separated by hyphens: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return;
            var numbers = input.Split('-').Select(int.Parse).ToList();
            Console.WriteLine(numbers.Count != numbers.Distinct().Count() ? "Duplicate" : "No Duplicates");
        }

        /// <summary>
        /// ValidateTime: Checks if time value entered by user is a valid time
        /// <returns>Returns null, but displays Ok or Invalid time</returns>
        /// </summary>
        public static void ValidateTime()
        {
            Console.Write("Enter time in 24-hour format (HH:MM): ");
            var input = Console.ReadLine();
            if (TimeSpan.TryParse(input, out TimeSpan time) && time.TotalMinutes < 1440)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Invalid Time");
        }

        /// <summary>
        /// ConvertToPascalCase: Converts words entered to variable name with pascalCase
        /// <returns>Returns null, but displays Pascalcase representation of words entered</returns>
        /// </summary>
        public static void ConvertToPascalCase()
        {
            Console.Write("Enter words separated by space: ");
            var words = Console.ReadLine().ToLower().Split(' ');
            var pascalCase = string.Join("", words.Select(w => char.ToUpper(w[0]) + w.Substring(1)));
            Console.WriteLine(pascalCase);
        }

        /// <summary>
        /// CountVowels: Counts vowels in users name
        /// <returns>Returns null, but displays vowel count</returns>
        /// </summary>
        public static void CountVowels()
        {
            Console.Write("Enter an English word: ");
            var word = Console.ReadLine().ToLower();
            int count = word.Count(c => "aeiou".Contains(c));
            Console.WriteLine($"Vowel count: {count}");
        }
    }
}
