using System;
using System.Collections.Generic;
using System.Linq;

namespace Question3.CsharpAssignment
{
    public static class Question3
    {
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

        public static void ReverseName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            char[] nameArray = name.ToCharArray();
            Array.Reverse(nameArray);
            string reversedName = new string(nameArray);
            Console.WriteLine($"Reversed name: {reversedName}");
        }

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

        public static void ThreeSmallestNumbers()
        {
            while (true)
            {
                Console.Write("Enter a list of comma-separated numbers: ");
                var input = Console.ReadLine();
                var numbers = input.Split(',').Select(x => int.TryParse(x.Trim(), out int num) ? num : (int?)null).Where(x => x.HasValue).Select(x => x.Value).ToList();

                if (numbers.Count < 5)
                {
                    Console.WriteLine("Invalid List. Please enter at least 5 numbers.");
                }
                else
                {
                    var smallestNumbers = numbers.OrderBy(n => n).Take(3);
                    Console.WriteLine("Three smallest numbers: " + string.Join(", ", smallestNumbers));
                    break;
                }
            }
        }
    }
}
