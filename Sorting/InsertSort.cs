using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    class InsertSort : Sortable
    {
        private int[] data;

        public InsertSort(int[] data)
        {
            this.data = data;
        }

        public int getLength()
        {
            return this.data.Length;
        }

        public string getTitle()
        {
            return "Insert Sort";
        }

        public int[] Sort()
        {
            for (int i = 0; i < this.data.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (this.data[j - 1] > this.data[j])
                    {
                        int temp = this.data[j - 1];
                        this.data[j - 1] = this.data[j];
                        this.data[j] = temp;
                    }
                }
            }

            return this.data;
        }
    }
}
