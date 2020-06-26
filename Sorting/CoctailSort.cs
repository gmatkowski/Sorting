using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    class CoctailSort : Sortable
    {
        private int[] data;

        public CoctailSort(int[] data)
        {
            this.data = data;
        }

        public int[] Sort()
        {
            bool swapped = true;
            int start = 0;
            int end = this.data.Length;

            while (swapped == true)
            {

                swapped = false;

                for (int i = start; i < end - 1; ++i)
                {
                    if (this.data[i] > this.data[i + 1])
                    {
                        int temp = this.data[i];
                        this.data[i] = this.data[i + 1];
                        this.data[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false) { 
                    break;
                }

                swapped = false;

                end = end - 1;

                for (int i = end - 1; i >= start; i--)
                {
                    if (this.data[i] > this.data[i + 1])
                    {
                        int temp = this.data[i];
                        this.data[i] = this.data[i + 1];
                        this.data[i + 1] = temp;
                        swapped = true;
                    }
                }

                start = start + 1;
            }

            return this.data;
        }

        public int getLength()
        {
            return this.data.Length;
        }

        public string getTitle()
        {
            return "Coctail sort";
        }
    }
}
