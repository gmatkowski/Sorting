using System;
using System.Diagnostics;
using System.Linq;
using System.IO;

namespace Sorting
{
    class Program
    {
        const int tableWidth = 90;

        static void Main(string[] args)
        {
            int basePartition = 10000;
            int interval = 10000;
            int[] partitions = new int[5];
            for (int i = 0; i < partitions.Length; i++)
            {
                partitions[i] = basePartition + interval * (i + 1);
            }

            foreach (int partition in partitions)
            {

                Console.WriteLine("Partition: {0} elements", partition.ToString());
                PrintRow("Algorithm", "Time");

                using (StreamWriter stream = File.CreateText(String.Format("sort_{0}.csv", partition.ToString())))
                {
                    stream.WriteLine("Algorithm;Elements;Time");
 
                    ShowResults(new InsertSort(GenerateRandomData(partition)), stream);
                    ShowResults(new SelectionSort(GenerateRandomData(partition)), stream);
                    ShowResults(new HeapSort(GenerateRandomData(partition)), stream);
                    ShowResults(new CoctailSort(GenerateRandomData(partition)), stream);

                    PrintLine();

                    
                }
                Console.WriteLine();
            }

            Console.WriteLine("Test zakończony");
            Console.ReadKey();
        }

        private static Random generator = new Random(Guid.NewGuid().GetHashCode());

        public static int[] GenerateRandomData(int size)
        {
            int[] data = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = generator.Next(1000000000);
            }

            return data;
        }

        public static void ShowResults(Sortable sortable, StreamWriter stream)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int[] results = sortable.Sort();
            watch.Stop();

            PrintRow(sortable.getTitle(), watch.Elapsed.TotalMilliseconds.ToString() + "ms");

            string row = string.Format("{0};{1};{2}", sortable.getTitle(), sortable.getLength(), watch.Elapsed.TotalMilliseconds.ToString());
            stream.WriteLine(row);
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

    }
}
