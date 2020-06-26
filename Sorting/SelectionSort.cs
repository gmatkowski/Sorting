using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    class SelectionSort : Sortable
    {
        private int[] data;

        public SelectionSort(int[] data)
        {
            this.data = data;
        }

        public int getLength()
        {
            return this.data.Length;
        }

        public string getTitle()
        {
            return "Selection Sort";
        }

        public int[] Sort()
        {
            int smallest;
            for (int i = 0; i < this.data.Length - 1; i++)
            {
                smallest = i;

                for (int index = i + 1; index < this.data.Length; index++)
                {
                    if (this.data[index] < this.data[smallest])
                    {
                        smallest = index;
                    }
                }
                Swap(i, smallest);
            }

            return this.data;
        }

        public void Swap(int first, int second)
        {
            int temporary = this.data[first];
            this.data[first] = this.data[second];
            this.data[second] = temporary;
        }
    }
}
