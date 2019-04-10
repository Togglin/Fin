using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Fin
{
    public static partial class Collection
    {
        public static KeyValuePair<K, T> Pair<K, T>(K key, T value)
            => new KeyValuePair<K, T>(key, value);

        public static IEnumerable<T> List<T>(params T[] items)
            => items.ToImmutableList();

        public static Func<T, IEnumerable<T>> SingletonList<T>()
            => (item) => ImmutableList.Create(item);

        public static IEnumerable<T> Cons<T>(this T t, IEnumerable<T> ts)
            => List(t).Concat(ts);

        public static Func<T, IEnumerable<T>, IEnumerable<T>> Cons<T>()
            => (t, ts) => t.Cons(ts);

        public static IDictionary<K, T> Map<K, T>(params KeyValuePair<K, T>[] pairs)
            => pairs.ToImmutableDictionary();
    }
}