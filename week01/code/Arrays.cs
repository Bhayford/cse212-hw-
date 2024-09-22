using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. 
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan for MultiplesOf function:
        // Step 1: Create an array to hold the multiples of the given number.
        // Step 2: Use a loop that iterates from 0 to length - 1.
        // Step 3: For each index i, calculate the value as number * (i + 1).
        // Step 4: Store this calculated value in the array at index i.
        // Step 5: After filling the array, return it.

        double[] multiples = new double[length]; // Step 1

        for (int i = 0; i < length; i++) // Step 2
        {
            multiples[i] = number * (i + 1); // Step 3 and 4
        }

        return multiples; // Step 5
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. 
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 
    /// then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. 
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan for RotateListRight function:
        // Step 1: Calculate the effective rotation amount as amount % data.Count to handle cases 
        // where amount exceeds the size of the list.
        // Step 2: If the effective amount is zero, return immediately since no rotation is needed.
        // Step 3: Get the last 'effectiveAmount' elements from the list.
        // Step 4: Get the first part of the list up to data.Count - effectiveAmount.
        // Step 5: Clear the original list and add the last part followed by the first part.

        int count = data.Count; // Step 1
        int effectiveAmount = amount % count;

        if (effectiveAmount == 0) return; // Step 2

        List<int> lastPart = data.GetRange(count - effectiveAmount, effectiveAmount); // Step 3
        List<int> firstPart = data.GetRange(0, count - effectiveAmount); // Step 4

        data.Clear(); // Step 5
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
