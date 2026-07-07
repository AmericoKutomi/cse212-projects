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

        // Declare a List to receive the result
        List<double> multiples = new List<double>();

        // Start with "number" which is the first element of multiples list
        double multiple = number;
        multiples.Add(multiple);

        // a loop to obtain the list of multiples of a number
        //  starting with the second element
        for (var element = 2; element <= length; ++element)
        {
            // calculate the multiple
            multiple = number * element;
            // add multiple to multiples list
            multiples.Add(multiple);
        }

        return multiples.ToArray(); // replace this return statement with your own
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // To rotate the list right, split the list in two parts
        //   - the first part is the last amount of elements
        //   - the second part is the first elements until the amount to be rotaded
        // The result will be the first part concatenated to the second part

        // declare the two parts
        List<int> part1 = new List<int>();
        List<int> part2 = new List<int>();

        // the first part is the last amount of elements
        part1 = data.GetRange(data.Count - amount, amount);

        // the second part is the first elements until the amount to be rotaded
        part2 = data.GetRange(0, data.Count - amount);

        // The result will be the first part concatenated to the second part
        data.Clear();
        data.AddRange(part1);
        data.AddRange(part2);
    }
}
