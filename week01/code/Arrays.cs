public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        //create an empty array of doubles
        //create a for loop to fill the array
        //for each position calculate the value as number * (1 + i)
        //store each result in the array
        //return the completed array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // If data is null or has 0 or 1 elements, nothing to do — return early.
        // Normalize amount: amount could equal data.Count; rotating by data.Count gives the same list.
        //    Use modulo to reduce amount into range 0..data.Count-1: amount = amount % data.Count.
        // If after normalization amount == 0, the rotation is a no-op; return.
        // Otherwise:
        //    a. Take the last 'amount' items using GetRange(startIndex, count).
        //       startIndex = data.Count - amount, count = amount.
        //    b. Insert that 'tail' range at the front of the list using InsertRange(0, tail).
        //    c. Remove the old tail (which is now located after the newly inserted block).
        //       Because we inserted 'amount' items at the front, the original tail starts at index 'amount'.
        //       Use RemoveRange(amount, amount) to remove those duplicated old tail elements.
        // This modifies the list in-place (no new list is returned), matching the assignment requirements.
        //
        // Note: This approach is simple and easy to read. It uses O(amount) extra memory for the temporary tail
        //       and performs the reordering with a couple of list operations.

        // Implementation:
        if (data == null)
        {
            return; // nothing to do for a null list
        }

        int n = data.Count;
        if (n <= 1)
        {
            return; // 0 or 1 elements; rotation has no effect
        }

        // Normalize amount so it's in the range 0 .. n-1
        amount = amount % n;
        if (amount == 0)
        {
            return; // rotating by n or 0 does nothing
        }

        // Get the last 'amount' elements (the tail)
        List<int> tail = data.GetRange(n - amount, amount);

        // Insert the tail at the front
        data.InsertRange(0, tail);

        // Remove the old tail (now duplicated after the inserted block).
        // The old tail begins at index 'amount' after insertion and has 'amount' items.
        data.RemoveRange(n, amount);
    }
}