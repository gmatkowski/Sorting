using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    class HeapSort : Sortable
    {
        private int[] data;

        public HeapSort(int[] data)
        {
            this.data = data;
        }

        public int getLength()
        {
            return this.data.Length;
        }

        public string getTitle()
        {
            return "Heap Sort";
        }

        public int[] Sort()
        {
            int n = this.data.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(this.data, n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = this.data[0];
                this.data[0] = this.data[i];
                this.data[i] = temp;
                Heapify(this.data, i, 0);
            }

            return this.data;
        }

        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                Heapify(arr, n, largest);
            }
        }
    }
}
