using System;
using System.Collections.Concurrent;
using System.Text;

namespace Develop.Runtime.Extensions
{
    public readonly struct StringBuilderScope : IDisposable
    {
        private static readonly ConcurrentBag<StringBuilder> Pool = new();
        private readonly StringBuilder _item;

        private StringBuilderScope(StringBuilder item)
        {
            _item = item;
        }

        public static StringBuilderScope Create(out StringBuilder item)
        {
            if (!Pool.TryTake(out item))
            {
                item = new StringBuilder();
            }

            return new StringBuilderScope(item);
        }

        void IDisposable.Dispose()
        {
            _item.Clear();
            Pool.Add(_item);
        }
    }
}