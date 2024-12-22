using System;

namespace KASDLab24
{
    internal class Program
    {
        static void Main()
        {
            MyTreeSet<int> treeSet = new MyTreeSet<int>();
            Console.WriteLine("Добавление элементов 6, 1, 8, 11, 13, 17, 15, 25, 22, 27");
            treeSet.Add(6);
            treeSet.Add(1);
            treeSet.Add(8);
            treeSet.Add(11);
            treeSet.Add(13);
            treeSet.Add(17);
            treeSet.Add(15);
            treeSet.Add(25);
            treeSet.Add(22);
            treeSet.Add(27);

            foreach (var value in treeSet.ToArray())
            {
                Console.WriteLine("Value: {0}", value);
            }

            Console.WriteLine("Contains(15): {0}", treeSet.Contains(15));

            Console.WriteLine("IsEmpty(): {0}", treeSet.IsEmpty());

            Console.WriteLine("Remove(27): {0}", treeSet.Remove(27));

            Console.WriteLine("Size(): {0}", treeSet.Size());

            Console.WriteLine("First(): {0}", treeSet.First());

            Console.WriteLine("treeSet(): {0}", treeSet.Last());

            foreach (var value in treeSet.SubSet(3, 24).ToArray())
            {
                Console.WriteLine("SubSet(3, 24): {0}", value);
            }

            foreach (var value in treeSet.TailSet(15).ToArray())
            {
                Console.WriteLine("TailSet(15): {0}", value);
            }

            foreach (var value in treeSet.HeadSet(15).ToArray())
            {
                Console.WriteLine("headSet(15): {0}", value);
            }

            Console.WriteLine("Ceiling(15): {0}", treeSet.Ceiling(15));

            Console.WriteLine("Floor(15): {0}", treeSet.Floor(15));

            Console.WriteLine("Higher(15): {0}", treeSet.Higher(15));

            Console.WriteLine("Lower(15): {0}", treeSet.Lower(15));

            foreach (var value in treeSet.DescendingIterator())
            {
                Console.WriteLine("DescendingIterator(): {0}", value);
            }

            foreach (var value in treeSet.DescendingSet().ToArray())
            {
                Console.WriteLine("DescendingSet(): {0}", value);
            }

            Console.ReadKey();
        }
    }
}
