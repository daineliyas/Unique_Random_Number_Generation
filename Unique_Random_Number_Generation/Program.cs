using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> uniqueRandomNumbers = GenerateUniqueRandomNumbers(1, 10000, 10000);

        // Printing the random unique numbers
        foreach (int number in uniqueRandomNumbers)
        {
            Console.WriteLine(number);
        }
    }

    #region Generate Unique Random Numbers
    static List<int> GenerateUniqueRandomNumbers(int minNumber, int maxNumber, int count)
    {
        //checking count
        if (count > (maxNumber - minNumber + 1) || count < minNumber)
        {
            throw new ArgumentOutOfRangeException("Count must be between min and max.");
        }

        List<int> numbers = new List<int>();

        // Adding consecutive numbers to the list from minNumber to maxNumber
        for (int i = minNumber; i <= maxNumber; i++)
        {
            numbers.Add(i);
        }

        // Initialize the random class for generating shuffled numbers
        Random random = new Random();

        // Shuffling numbers
        for (int i = maxNumber; i > minNumber; i--)
        {
            int j = random.Next(minNumber, count);

            // Swaping numbers
            int temp = numbers[i - minNumber];
            numbers[i - minNumber] = numbers[j - minNumber];
            numbers[j - minNumber] = temp;
        }

        // Take the first 'count' elements from the shuffled list
        List<int> result = numbers.GetRange(0, count);

        return result;
    }
    #endregion
}
