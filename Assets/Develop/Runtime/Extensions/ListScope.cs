using System;
using System.Collections.Generic;

namespace BlackHole.Extensions
{
    public readonly struct ListScope<T> : IDisposable
    {
        private readonly List<T> _item;

        private ListScope(List<T> item)
        {
            _item = item;
        }

        public static ListScope<T> Create(out List<T> item)
        {
            item = ListPool<T>.Spawn();

            return new ListScope<T>(item);
        }

        void IDisposable.Dispose()
        {
            _item.Clear();

            ListPool<T>.Despawn(_item);
        }
    }
    
    public static class ListPool<T>
    {
        private static readonly Stack<List<T>> Pool = new();

        public static List<T> Spawn()
        {
            return Pool.Count > 0 ? Pool.Pop() : new List<T>();
        }

        public static void Despawn(List<T> list)
        {
            list.Clear();
            Pool.Push(list);
        }
    }
}