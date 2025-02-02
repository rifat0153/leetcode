namespace Leetcode.Sorting;

internal class Sort
{
    public static void Test()
    {
        int[] arr = [5, 9, 2, 1, 7, 12, -5];
        int[] arr2 = [5];
        int[] arr3 = [];

        Func<int[], int[]> SortingAlgo = HeapSort;

        Console.WriteLine(string.Join(" ,", SortingAlgo(arr)));
        Console.WriteLine(string.Join(" ,", SortingAlgo(arr2)));
        Console.WriteLine(string.Join(" ,", SortingAlgo(arr3)));

        //int[] l = [2, 8];
        //int[] r = [-6, 3, 5, 6];
        //Console.WriteLine(string.Join(" ,", Merge(l, r)));
    }

    public static Func<int[], int[]> HeapSort =>
        (int[] arr) =>
        {
            HeapSortImpl(arr);
            return arr;
        };

    public static void HeapSortImpl(int[] arr)
    {
        BuildMaxHeap(arr);

        for (int i = arr.Length - 1; i > 0; i--)
        {
            // Swap the root (maximum value) with the last element
            (arr[0], arr[i]) = (arr[i], arr[0]);

            // Re-heapify the reduced heap
            MaxHeapify(arr, i, 0);
        }

        static void BuildMaxHeap(int[] arr)
        {
            var heapSize = arr.Length;
            var start = (heapSize / 2) - 1; // Start from the last non-leaf node

            for (int i = start; i >= 0; i--)
            {
                MaxHeapify(arr, heapSize, i);
            }
        }

        static void MaxHeapify(int[] arr, int heapSize, int i)
        {
            int left = 2 * i + 1; // left child
            int right = 2 * i + 2; // right child

            int max = i;

            if (left < heapSize && arr[left] > arr[i])
                max = left;

            if (right < heapSize && arr[right] > arr[max])
                max = right;

            if (max != i)
            {
                (arr[max], arr[i]) = (arr[i], arr[max]);
                MaxHeapify(arr, heapSize, max);
            }
        }
    }

    public static int[] SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int minimum = i;
            for (int curr = i; curr < arr.Length; curr++)
            {
                if (arr[curr] < arr[minimum])
                {
                    minimum = curr;
                }
            }
            // swap i with minimum value
            (arr[i], arr[minimum]) = (arr[minimum], arr[i]);
        }

        return arr;
    }

    public static int[] InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            for (int curr = i; curr > 0 && arr[curr] < arr[curr - 1]; curr--)
            {
                (arr[curr], arr[curr - 1]) = (arr[curr - 1], arr[curr]);
            }
        }

        return arr;
    }

    public static int[] QuickSortImpl(int[] arr)
    {
        if (arr is null or [])
            return [];
        if (arr is [_])
            return arr;

        QuickSort(arr, 0, arr.Length);

        static void QuickSort(int[] arr, int l, int r)
        {
            if (l < r - 1) // Ensure at least two elements to sort
            {
                var pivot = Partition(arr, l, r);

                QuickSort(arr, l, pivot);
                QuickSort(arr, pivot + 1, r);
            }
        }

        static int Partition(int[] arr, int l, int r)
        {
            int pivot = (l + r) / 2; // Choose the pivot index
            Swap(arr, pivot, r - 1); // Move pivot to the end
            pivot = r - 1; // Update pivot position
            int low = l;
            int high = r - 2; // Start one position before the pivot

            while (low <= high)
            {
                // Move `low` to the right until an element > pivot is found
                while (low <= high && arr[low] <= arr[pivot])
                    low++;

                // Move `high` to the left until an element < pivot is found
                while (low <= high && arr[high] >= arr[pivot])
                    high--;

                // Swap elements if valid indices
                if (low < high)
                {
                    Swap(arr, low, high);
                }
            }

            // Finally, swap pivot into its correct location
            Swap(arr, low, pivot);
            return low; // Return the final pivot index
        }

        static void Swap(int[] arr, int low, int high)
        {
            (arr[low], arr[high]) = (arr[high], arr[low]);
        }

        return arr;
    }

    public static int[] BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (var j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }
        }

        return arr;
    }

    public static int[] MergeSortImpl(int[] arr)
    {
        if (arr is null or [])
            return [];

        if (arr is [_])
            return arr;

        int mid = arr.Length / 2;
        var left = arr[0..mid];
        var right = arr[mid..arr.Length];

        var mergedLeft = MergeSortImpl(left);
        var mergedRight = MergeSortImpl(right);

        return Merge(mergedLeft, mergedRight);

        static int[] Merge(int[] arr1, int[] arr2)
        {
            List<int> result = [];

            int i = 0;
            int j = 0;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] < arr2[j])
                    result.Add(arr1[i++]);
                else
                    result.Add(arr2[j++]);
            }

            while (i < arr1.Length)
                result.Add(arr1[i++]);
            while (j < arr2.Length)
                result.Add(arr2[j++]);

            return [.. result];
        }
    }
}
