// Resources:
// https://learn.microsoft.com/en-us/dotnet/api/system.array.reverse?view=net-8.0
// https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-8.0
// https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writealllines?view=net-8.0
// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.-ctor?view=net-8.0#system-collections-generic-list-1-ctor(system-int32)

using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Task 1: Creating Variables
        int low, high;

        Console.Write("Enter the low number: ");
        while (!int.TryParse(Console.ReadLine(), out low))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }

        do
        {
            Console.Write("Enter the high number: ");
        } while (!int.TryParse(Console.ReadLine(), out high) || high <= low);

        int difference = high - low;
        Console.WriteLine($"The difference between {low} and {high} is: {difference}");

        // Task 2: Looping and Input Validation
        do
        {
            Console.Write("Enter a positive low number: ");
        } while (!int.TryParse(Console.ReadLine(), out low) || low <= 0);

        do
        {
            Console.Write("Enter a high number greater than the low number: ");
        } while (!int.TryParse(Console.ReadLine(), out high) || high <= low);

        // Task 3: Using Arrays and File I/O
        int[] numbersArray = new int[high - low + 1];
        for (int i = 0; i < numbersArray.Length; i++)
        {
            numbersArray[i] = low + i;
        }

        Array.Reverse(numbersArray);
        File.WriteAllLines("numbers.txt", Array.ConvertAll(numbersArray, element => element.ToString()));
        Console.WriteLine("Numbers written to numbers.txt in reverse order.");

        // Additional Tasks
        if (File.Exists("numbers.txt"))
        {
            string[] lines = File.ReadAllLines("numbers.txt");
            double sum = 0;

            Console.Write("Numbers read from file: ");
            foreach (string line in lines)
            {
                Console.Write($"{line} ");
                sum += Convert.ToDouble(line);
            }

            Console.WriteLine($"\nSum of the numbers: {sum}");
        }
        else
        {
            Console.WriteLine("File numbers.txt not found.");
        }

        List<double> numbersList = new List<double>();
        for (int i = low; i <= high; i++)
        {
            numbersList.Add((double)i);
        }

        Console.Write("Prime numbers between low and high: ");
        foreach (double number in numbersList)
        {
            if (isPrime((int)number))
            {
                Console.Write($"{number} ");
            }
        }
        Console.WriteLine();
    }

    // Method to check if a number is prime
    static bool isPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i <= number/2; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}
