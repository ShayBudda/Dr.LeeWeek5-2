using System;
using System.IO;
using System.Diagnostics;

namespace CSC205Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "numbers.txt"; // Name of the file to write/read numbers
            Stopwatch stopwatch = new Stopwatch(); // Timer to measure execution time

            // Generate random numbers and write to the file
            Method01(fileName, 1000, 1, 1001);

            // Read all lines from the file and convert them to an array of integers
            string[] lines = File.ReadAllLines(fileName);
            int[] values = new int[lines.Length];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Convert.ToInt32(lines[i]);
            }

            // Start the stopwatch and sort the array
            stopwatch.Start();
            Console.WriteLine("starting ... ");
            Method02(values);
            Console.WriteLine("done! ... ");
            stopwatch.Stop();

            // Display the elapsed time
            Console.WriteLine("time measured: {0} ms", stopwatch.ElapsedMilliseconds);

            // Print the sorted array
            foreach (int value in values)
                Console.Write(value + " ");
            Console.WriteLine();
        }

        // Generates 'total' random numbers within the specified range and writes them to a file
        static void Method01(string fileName, int total, int lowerRange, int upperRange)
        {
            using (var writer = new StreamWriter(fileName))
            {
                Random r = new Random();
                int number = 0;
                for (int i = 1; i < total; i++)
                {
                    // Generate a random number within the specified range
                    number = r.Next(lowerRange, upperRange);
                    // Write the random number to the file
                    writer.WriteLine(number);
                }
            }
        }

        // Sorts an array of integers using the selection sort algorithm
        static void Method02(int[] arr)
        {
            for (int start = 0; start < arr.Length - 1; start++)
            {
                int posMin = start;
                // Find the smallest element in the unsorted portion of the array
                for (int i = start + 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[posMin])
                    {
                        posMin = i;
                    }
                }
                // Swap the found minimum element with the first unsorted element
                int tmp = arr[start];
                arr[start] = arr[posMin];
                arr[posMin] = tmp;
            }
        }
    }
}
// 1) Method01 generates random numbers and writes them to a file named numbers.txt.
// It takes four parameters: fileName, total, lowerRange, and upperRange. It creates
// a file and writes a specified number of random integers within a given range to that file.

// 2) Method02 sorts an array of integers using the selection sort algorithm. It iterates through
// the array, finding the smallest element in the unsorted portion and swapping it with the first
// unsorted element.

// 3) string[] lines = File.ReadAllLines(fileName);
//int[] values = new int[lines.Length];
//for (int i = 0; i < values.Length; i++)
//{
//    values[i] = Convert.ToInt32(lines[i]);
//}
// This code reads all lines from the file numbers.txt, converts them to integers, and stores them in an array values.

//4) The file numbers.txt will be located in the same directory as the executable or the project's root directory, depending on how the program is run.