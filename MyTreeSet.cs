using System;
using System.Collections.Generic;
using System.Linq;

public class MyTreeSet<E> where E : IComparable<E>
{
    private readonly MyTreeMap<E, int> map = new MyTreeMap<E, int>();

    public MyTreeSet() { }

    public MyTreeSet(MyTreeMap<E, int> map)
    {
        this.map = map;
    }

    public MyTreeSet(IComparer<E> Comparator)
    {
        map = new MyTreeMap<E, int>(Comparator);
    }

    public MyTreeSet(E[] array)
    {
        foreach (var element in array) map.Put(element, default);
    }

    public MyTreeSet(SortedSet<E> s)
    {
        foreach (var element in s) map.Put(element, default);
    }

    public void Add(E element) => map.Put(element, default);

    public void AddAll(E[] array)
    {
        foreach (var element in array) map.Put(element, default);
    }

    public void Clear() => map.Clear();

    public bool Contains(E element) => map.ContainsKey(element);

    public bool ContainsAll(E[] array)
    {
        foreach (var element in array)
        {
            if (!map.ContainsKey(element)) return false;
        }

        return true;
    }

    public bool IsEmpty() => map.IsEmpty();

    public E Remove(E element) => map.Remove(element).Key;

    public void RemoveAll(E[] array)
    {
        foreach (var element in array) map.Remove(element);
    }

    public void RetainAll(E[] array)
    {
        foreach (var element in map.KeySet())
        {
            if (Array.IndexOf(array, element) == -1) map.Remove(element);
        }
    }

    public int Size() => map.Size();

    public E[] ToArray() => map.KeySet().ToArray();

    public E[] ToArray(ref E[] array)
    {
        E[] keys = ToArray();

        if (array == null) return keys;

        for (int index = 0; index < keys.Length; index++) array[index] = keys[index];

        return array;
    }

    public E First() => map.FirstKey();

    public E Last() => map.LastKey();

    public MyTreeSet<E> SubSet(E fromElement, E toElement) => new MyTreeSet<E>(map.SubMap(fromElement, toElement));

    public MyTreeSet<E> HeadSet(E toElement) => new MyTreeSet<E>(map.HeadMap(toElement));

    public MyTreeSet<E> TailSet(E fromElement) => new MyTreeSet<E>(map.TailMap(fromElement));

    public E Ceiling(E fromElement) => map.CeilingKey(fromElement);

    public E Floor(E fromElement) => map.FloorKey(fromElement);

    public E Higher(E fromElement) => map.HigherKey(fromElement);

    public E Lower(E fromElement) => map.LowerKey(fromElement);

    public MyTreeSet<E> HeadSet(E upperBound, bool include) => new MyTreeSet<E>(map.HeadMap(upperBound, include));

    public MyTreeSet<E> SubSet(E lowerBound, bool lowInclude, E upperBound, bool hightInclude) => new MyTreeSet<E>(map.SubMap(lowerBound, upperBound, lowInclude, hightInclude));

    public MyTreeSet<E> TailSet(E lowerBound, bool include) => new MyTreeSet<E>(map.TailMap(lowerBound, include));

    public E PollLast() => map.PollLastEntry().Key;

    public E PollFirst() => map.PollFirstEntry().Key;

    public IEnumerable<E> DescendingIterator()
    {
        IEnumerable<KeyValuePair<E, int>> nodes = map.EntrySet();

        foreach (KeyValuePair<E, int> node in nodes.Reverse()) yield return node.Key;
    }
    public MyTreeSet<E> DescendingSet()
    {
        // Сравнение наоборот
        MyTreeSet<E> set = new MyTreeSet<E>(Comparer<E>.Create((a, b) => b.CompareTo(a)));

        foreach (var element in map.EntrySet()) set.Add(element.Key);

        return set;
    }
}

