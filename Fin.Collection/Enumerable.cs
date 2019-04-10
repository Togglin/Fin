using System;
using System.Collections.Generic;
using System.Linq;
using Unit = System.ValueTuple;

namespace Fin
{
    using static Collection.Core;
    public static partial class EnumerableExtensions
    {
        public static Func<T, IEnumerable<T>> Return<T>() => t => List(t);

        public static IEnumerable<T> Append<T>(this IEnumerable<T> @this
           , params T[] ts) => @this.Concat(ts);

        static IEnumerable<T> Prepend<T>(this IEnumerable<T> @this, T val)
        {
            yield return val;
            foreach (T t in @this) yield return t;
        }

        // public static IEnumerable<Unit> ForEach<T>
        //    (this IEnumerable<T> @this, Action<T> action)
        //     => @this.Map(action.ToFunc()).ToImmutableList();

        // public static IEnumerable<Func<T2, R>> Map<T1, T2, R>(this IEnumerable<T1> @this
        //     , Func<T1, T2, R> func)
        //     => @this.Map(func.Curry());

        // public static IEnumerable<Func<T2, Func<T3, R>>> Map<T1, T2, T3, R>(this IEnumerable<T1> @this
        //     , Func<T1, T2, T3, R> func)
        //     => @this.Map(func.Curry());

        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> @this, Func<T, IEnumerable<R>> func)
            => @this.SelectMany(func);

        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> @this)
            => @this.SelectMany(x => x);

        // public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> @this, Func<T, Option<R>> func)
        //     => @this.Bind(t => func(t).AsEnumerable());

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> @this, Func<T, bool> pred)
        {
            foreach (var item in @this)
            {
                if (pred(item)) yield return item;
                else yield break;
            }
        }

        public static IEnumerable<T> DropWhile<T>(this IEnumerable<T> @this, Func<T, bool> pred)
        {
            bool clean = true;
            foreach (var item in @this)
            {
                if (!clean || !pred(item))
                {
                    yield return item;
                    clean = false;
                }
            }
        }
    }
}