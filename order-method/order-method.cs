using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("=== Sorting Numbers Application ===");
            Console.WriteLine("1. Enter numbers");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                List<int> numbers = GetNumbers();
                Console.WriteLine("\nOriginal numbers: " + string.Join(", ", numbers));

                // Apply sorting methods
                List<int> bubbleSorted = BubbleSort(new List<int>(numbers));
                List<int> shellSorted = ShellSort(new List<int>(numbers));
                List<int> selectionSorted = SelectionSort(new List<int>(numbers));
                List<int> insertionSorted = InsertionSort(new List<int>(numbers));

                // Display results
                Console.WriteLine("\n=== Sorted Results ===");
                Console.WriteLine("Bubble Sort: " + string.Join(", ", bubbleSorted));
                Console.WriteLine("Shell Sort: " + string.Join(", ", shellSorted));
                Console.WriteLine("Selection Sort: " + string.Join(", ", selectionSorted));
                Console.WriteLine("Insertion Sort: " + string.Join(", ", insertionSorted));

                // Write to file on desktop
                SaveToDesktop(numbers, bubbleSorted, shellSorted, selectionSorted, insertionSorted);
                Console.WriteLine("\nResults have been saved to your Desktop in 'SortedNumbers.txt'.");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Exiting.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static List<int> GetNumbers()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("\nEnter 10 unique numbers:");
        while (numbers.Count < 10)
        {
            Console.Write($"Number {numbers.Count + 1}: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                if (!numbers.Contains(num))
                {
                    numbers.Add(num);
                }
                else
                {
                    Console.WriteLine("Number already entered. Try a different one.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }
        return numbers;
    }

    static List<int> BubbleSort(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            for (int j = 0; j < numbers.Count - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    // Swap
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }
        return numbers;
    }

    static List<int> ShellSort(List<int> numbers)
    {
        int n = numbers.Count;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = numbers[i];
                int j;
                for (j = i; j >= gap && numbers[j - gap] > temp; j -= gap)
                {
                    numbers[j] = numbers[j - gap];
                }
                numbers[j] = temp;
            }
        }
        return numbers;
    }

    static List<int> SelectionSort(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[j] < numbers[minIdx])
                {
                    minIdx = j;
                }
            }
            // Swap
            int temp = numbers[minIdx];
            numbers[minIdx] = numbers[i];
            numbers[i] = temp;
        }
        return numbers;
    }

    static List<int> InsertionSort(List<int> numbers)
    {
        for (int i = 1; i < numbers.Count; i++)
        {
            int key = numbers[i];
            int j = i - 1;
            while (j >= 0 && numbers[j] > key)
            {
                numbers[j + 1] = numbers[j];
                j--;
            }
            numbers[j + 1] = key;
        }
        return numbers;
    }

    static void SaveToDesktop(List<int> original, List<int> bubble, List<int> shell, List<int> selection, List<int> insertion)
    {
        // Get Desktop path
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "SortedNumbers.txt");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Original numbers: " + string.Join(", ", original));
            writer.WriteLine("Bubble Sort: " + string.Join(", ", bubble));
            writer.WriteLine("Shell Sort: " + string.Join(", ", shell));
            writer.WriteLine("Selection Sort: " + string.Join(", ", selection));
            writer.WriteLine("Insertion Sort: " + string.Join(", ", insertion));
        }
    }
}
