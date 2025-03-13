using System;

namespace thirdTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>();
            char selection = ' ';

            do
            {
                Console.WriteLine("P - Print Numbers");
                Console.WriteLine("A - Add a number");
                Console.WriteLine("M - Display mean of the numbers");
                Console.WriteLine("S - Display the smallest number");
                Console.WriteLine("L - Display the largest number");
                Console.WriteLine("F - Search for the number");
                Console.WriteLine("C - Clear the list");
                Console.WriteLine("Q - Quit");
                Console.WriteLine("\n Enter Your Selection: ");

                selection = char.ToUpper(char.Parse(Console.ReadLine()));

                switch (selection)
                {
                    case 'P':
                        string numbersList = GetNumbersList(Numbers);
                        Console.WriteLine(numbersList);
                        break;

                    case 'A':
                        Console.Write("Enter a number to add to list: ");
                        string input = Console.ReadLine();
                        string addMessage = AddNumber(Numbers, input);
                        Console.WriteLine(addMessage);
                        break;

                    case 'M':
                        string meanMessage = GetMean(Numbers);
                        Console.WriteLine(meanMessage);
                        break;

                    case 'S':
                        string smallestMessage = GetSmallest(Numbers);
                        Console.WriteLine(smallestMessage);
                        break;

                    case 'L':
                        string largestMessage = GetLargest(Numbers);
                        Console.WriteLine(largestMessage);
                        break;

                    case 'F':
                        Console.WriteLine("Enter the number you need to search: ");
                        string searchInput = Console.ReadLine();
                        string searchMessage = SearchNumber(Numbers, searchInput);
                        Console.WriteLine(searchMessage);
                        break;

                    case 'C':
                        Console.WriteLine("Are you sure you want to clear the list [Y or N]?");
                        string userOption = Console.ReadLine().ToUpper();
                        if (userOption == "Y")
                        {
                            Numbers.Clear();
                            Console.WriteLine("All numbers have been cleared.");
                        }
                        else
                        {
                            Console.WriteLine("The clearing process has been cancelled.");
                        }
                        break;
                }
            } while (selection != 'Q');

            Console.WriteLine("Good bye");
        }

        static string GetNumbersList(List<int> Numbers)
        {
            if (Numbers.Count == 0)
            {
                return "[ ] - The list is empty!";
            }
            else
            {
                for (int i = 0; i < Numbers.Count - 1; i++)
                {
                    for (int j = 0; j < Numbers.Count - i - 1; j++)
                    {
                        if (Numbers[j] > Numbers[j + 1])  
                        {
                            int temp = Numbers[j];
                            Numbers[j] = Numbers[j + 1];
                            Numbers[j + 1] = temp;
                        }
                    }
                }

                string result = "Numbers in the list: [ ";
                for (int i = 0; i < Numbers.Count; i++)
                {
                    result += Numbers[i] + " ";
                }
                result += "]";
                return result;
            }
        }

        static string AddNumber(List<int> Numbers, string input)
        {
            int number;
            bool isValidNumber = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    isValidNumber = false;
                    break;
                }
            }

            if (isValidNumber)
            {
                number = int.Parse(input);

                bool isNumberInList = false;
                for (int i = 0; i < Numbers.Count; i++)
                {
                    if (Numbers[i] == number)
                    {
                        isNumberInList = true;
                        break;
                    }
                }

                if (!isNumberInList)
                {
                    Numbers.Add(number);
                    return $"Number {number} added successfully.";
                }
                else
                {
                    return "Number already exists in the list.";
                }
            }
            return "Invalid input. Please enter a valid number.";
        }

        static string GetMean(List<int> Numbers)
        {
            if (Numbers.Count == 0)
                return "[ ] - The list is empty!";
            double sum = 0;
            for (int i = 0; i < Numbers.Count; i++)
            {
                sum += Numbers[i];
            }
            return $"The mean of the numbers is {sum / Numbers.Count}";
        }

        static string GetSmallest(List<int> Numbers)
        {
            if (Numbers.Count == 0)
                return "[ ] - The list is empty!";
            int min = Numbers[0];
            for (int i = 0; i < Numbers.Count; i++)
            {
                if (Numbers[i] < min)
                    min = Numbers[i];
            }
            return $"The smallest number is {min}";
        }

        static string GetLargest(List<int> Numbers)
        {
            if (Numbers.Count == 0)
                return "[ ] - The list is empty!";
            int max = Numbers[0];
            for (int i = 0; i < Numbers.Count; i++)
            {
                if (Numbers[i] > max)
                    max = Numbers[i];
            }
            return $"The largest number is {max}";
        }

        static string SearchNumber(List<int> Numbers, string searchInput)
        {
            int searchNumber;
            bool isValidNumber = true;
            for (int i = 0; i < searchInput.Length; i++)
            {
                if (!char.IsDigit(searchInput[i]))
                {
                    isValidNumber = false;
                    break;
                }
            }

            if (isValidNumber)
            {
                searchNumber = Convert.ToInt32(searchInput);
                bool isFound = false;

                for (int i = 0; i < Numbers.Count; i++)
                {
                    if (Numbers[i] == searchNumber)
                    {
                        isFound = true;
                        return $"Number {searchNumber} found in the list at index {i}.";
                    }
                }

                if (!isFound)
                {
                    return $"Number {searchNumber} is not in the list.";
                }
            }
            return "Invalid input. Please enter a valid number.";
        }
    }
}
