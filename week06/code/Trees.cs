public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // TODO Start Problem 5

        // Base case: no values left in this range
        if (first > last)
            return;

        // Find the middle index
        int mid = (first + last) / 2;

        // Insert middle value first (creates balanced tree)
        bst.Insert(sortedNumbers[mid]);

        // Recursively build left half
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recursively build right half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
