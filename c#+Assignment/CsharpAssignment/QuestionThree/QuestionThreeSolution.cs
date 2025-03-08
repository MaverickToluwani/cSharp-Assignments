using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionThree.CsharpAssignment
{
    public static class QuestionThreeSolution
    {
        /// <summary>
        /// FacebookLikes: Prompts user to enter names, once user enters a whitespace It Displays 
        ///                 names in the form or the facebook likes sequence
        /// <returns>Returns null, but displays names entered in the facebooks likes sequence</returns>
        /// </summary>
        public static void FacebookLikes()
        {
            List<string> names = new List<string>();
            while (true)
            {
                Console.Write("Enter a name (or press Enter to finish): ");
                var name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                    break;
                names.Add(name);
            }

            if (names.Count == 1)
                Console.WriteLine($"{names[0]} likes your post.");
            else if (names.Count == 2)
                Console.WriteLine($"{names[0]} and {names[1]} like your post.");
            else if (names.Count > 2)
                Console.WriteLine($"{names[0]}, {names[1]} and {names.Count - 2} others like your post.");
        }

        /// <summary>
        /// ReverseName: Prompts user to enter names, once user enters a whitespace It Displays 
        ///                 names in the form or the facebook likes sequence
        /// <returns>Returns null, but displays reverse name</returns>
        /// </summary>
        public static void ReverseName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            char[] nameArray = name.ToCharArray();
            Array.Reverse(nameArray);
            string reversedName = new string(nameArray);
            Console.WriteLine($"Reversed name: {reversedName}");
        }

        /// <summary>
        /// UniqueSortedNumbers: Sorts and displays 5 unique numbers entered by the user
        /// <returns>Returns null, but displays sorted number list</returns>
        /// </summary>
        public static void UniqueSortedNumbers()
        {
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < 5)
            {
                Console.Write("Enter a unique number: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (!numbers.Add(num))
                        Console.WriteLine("Number already entered. Try again.");
                }
                else
                    Console.WriteLine("Invalid input. Try again.");
            }
            Console.WriteLine("Sorted numbers: " + string.Join(", ", numbers.OrderBy(n => n)));
        }

        /// <summary>
        /// UniqueSortedNumbers: Stores all numbers entered by user but only displays unique numbers
        /// <returns>Returns null, but displays unique numbers entered</returns>
        /// </summary>
        public static void UniqueNumbers()
        {
            HashSet<int> numbers = new HashSet<int>();
            while (true)
            {
                Console.Write("Enter a number (or type 'Quit' to stop): ");
                var input = Console.ReadLine();
                if (input.Equals("Quit", StringComparison.OrdinalIgnoreCase))
                    break;
                if (int.TryParse(input, out int num))
                    numbers.Add(num);
            }
            Console.WriteLine("Unique numbers: " + string.Join(", ", numbers));
        }

        /// <summary>
        /// ThreeSmallestNumbers: Displays three smallest numbers from numbers entered by users 
        ///                         once number are up to five numbers
        /// <returns>Returns null, but displays three smallest numbers entered by users</returns>
        /// </summary>

        public static void ThreeSmallestNumbers()
        {
            while (true)
            {
                Console.Write("Enter at least 5 numbers separated by commas: ");
                string input = Console.ReadLine();

                List<int> numbers = new List<int>();
                foreach (var item in input.Split(','))
                {
                    if (int.TryParse(item.Trim(), out int num))
                    {
                        numbers.Add(num);
                    }
                }

                if (numbers.Count < 5)
                {
                    Console.WriteLine("Invalid input. Please enter at least 5 numbers.");
                }
                else
                {
                    numbers.Sort();
                    Console.WriteLine("Three smallest numbers: " + string.Join(", ", numbers.Take(3)));
                    break;
                }
            }
        }

    }
}
