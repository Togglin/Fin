using System;
using System.Collections.Generic;
using Unit = System.ValueTuple;

namespace Fin
{
    public static class F
    {
        /// <summary>
        /// Unit is a ValueTuple that represents no value.
        /// </summary>
        /// <example>
        /// To define Unit use the following code:
        /// <code>
        /// using Unit = System.ValueTuple;
        /// </code>
        /// </example>
        /// <returns>Unit (ValueTuple)</returns>
        public static Unit Unit() => Core.Unit();

        #region ActionToFunc

        /// <summary>
        /// The Action.ToFunc() creates a function which when called will
        /// runs the action and returns unit.
        /// </summary>
        /// <param name="action">Any action with no params.</param>
        /// <returns>Func&lt;out Unit&gt;()</returns>
        public static Func<Unit> ToFunc(this Action action)
            => ActionToFunc.ToFunc(action);

        /// <summary>
        /// The Action(value).ToFunc() creates a function which when called will
        /// runs the action and returns unit.
        /// </summary>
        /// <param name="action">Any action with 1 param</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>Func&lt;T,Unit&gt;()</returns>
        public static Func<T, Unit> ToFunc<T>(this Action<T> action)
            => ActionToFunc.ToFunc(action);

        /// <summary>
        /// The Action(value).ToFunc() creates a function which when called will
        /// runs the action and returns unit.
        /// </summary>
        /// <param name="action">Any action with 2 param</param>
        /// <typeparam name="T1">The type of first value.</typeparam>
        /// <typeparam name="T2">The type of second value.</typeparam>
        /// <returns>Func&lt;T1,T2,Unit&gt;()</returns>
        public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> action)
            => ActionToFunc.ToFunc(action);

        #endregion // ActionToFunc

        #region FuncExtensions

        /// <summary>
        /// Curry a function with 2 params to implement partial application
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2)</returns>
        public static Func<T1, Func<T2, R>> Curry<T1, T2, R>(this Func<T1, T2, R> @this)
            => FuncExtensions.Curry(@this);

        /// <summary>
        /// Curry the first param so the whole func deosn't get curried. This is helpful with
        /// partial appliction when you just need the first param set.
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,T3,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="T3">Third param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2,t3)</returns>
        public static Func<T1, Func<T2, T3, R>> CurryFirst<T1, T2, T3, R>(this Func<T1, T2, T3, R> @this)
            => FuncExtensions.CurryFirst(@this);

        /// <summary>
        /// Curry a function with 3 params to implement partial application
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,T3,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="T3">Third param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2)(t3)</returns>
        public static Func<T1, Func<T2, Func<T3, R>>> Curry<T1, T2, T3, R>(this Func<T1, T2, T3, R> @this)
            => FuncExtensions.Curry(@this);

        /// <summary>
        /// Curry the first param so the whole func deosn't get curried. This is helpful with
        /// partial appliction when you just need the first param set.
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,T3,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="T3">Third param type</typeparam>
        /// <typeparam name="T4">Fourth param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2,t3,t4)</returns>
        public static Func<T1, Func<T2, T3, T4, R>> CurryFirst<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> @this)
            => FuncExtensions.CurryFirst(@this);

        /// <summary>
        /// Curry a function with 4 params to implement partial application
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,T3,T4,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="T3">Third param type</typeparam>
        /// <typeparam name="T4">Fourth param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2)(t3)(t4)</returns>
        public static Func<T1, Func<T2, Func<T3, Func<T4, R>>>> Curry<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> @this)
            => FuncExtensions.Curry(@this);

        /// <summary>
        /// Curry the first param so the whole func deosn't get curried. This is helpful with
        /// partial appliction when you just need the first param set.
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,T3,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="T3">Third param type</typeparam>
        /// <typeparam name="T4">Fourth param type</typeparam>
        /// <typeparam name="T5">Fifth param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2,t3,t4,t5)</returns>
        public static Func<T1, Func<T2, T3, T4, T5, R>> CurryFirst<T1, T2, T3, T4, T5, R>(this Func<T1, T2, T3, T4, T5, R> @this)
            => FuncExtensions.CurryFirst(@this);

        /// <summary>
        /// Curry a function with 5 params to implement partial application
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,T3,T4,T5,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="T3">Third param type</typeparam>
        /// <typeparam name="T4">Fourth param type</typeparam>
        /// <typeparam name="T5">Fifth param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2)(t3)(t4)(t5)</returns>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, R>>>>> Curry<T1, T2, T3, T4, T5, R>(this Func<T1, T2, T3, T4, T5, R> @this)
            => FuncExtensions.Curry(@this);

        /// <summary>
        /// Curry the first param so the whole func deosn't get curried. This is helpful with
        /// partial appliction when you just need the first param set.
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,T3,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="T3">Third param type</typeparam>
        /// <typeparam name="T4">Fourth param type</typeparam>
        /// <typeparam name="T5">Fifth param type</typeparam>
        /// <typeparam name="T6">Sixth param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2,t3,t4,t5,t6)</returns>
        public static Func<T1, Func<T2, T3, T4, T5, T6, R>> CurryFirst<T1, T2, T3, T4, T5, T6, R>(this Func<T1, T2, T3, T4, T5, T6, R> @this)
            => FuncExtensions.CurryFirst(@this);

        /// <summary>
        /// Curry a function with 6 params to be to implement partial application
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,T3,T4,T5,T6,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="T3">Third param type</typeparam>
        /// <typeparam name="T4">Fourth param type</typeparam>
        /// <typeparam name="T5">Fifth param type</typeparam>
        /// <typeparam name="T6">Sixth param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2)(t3)(t4)(t5)(t6)</returns>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, R>>>>>> Curry<T1, T2, T3, T4, T5, T6, R>(this Func<T1, T2, T3, T4, T5, T6, R> @this)
            => FuncExtensions.Curry(@this);

        /// <summary>
        /// Curry the first param so the whole func deosn't get curried. This is helpful with
        /// partial appliction when you just need the first param set.
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,T3,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="T3">Third param type</typeparam>
        /// <typeparam name="T4">Fourth param type</typeparam>
        /// <typeparam name="T5">Fifth param type</typeparam>
        /// <typeparam name="T6">Sixth param type</typeparam>
        /// <typeparam name="T7">Seventh param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2,t3,t4,t5,t6,t7)</returns>
        public static Func<T1, Func<T2, T3, T4, T5, T6, T7, R>> CurryFirst<T1, T2, T3, T4, T5, T6, T7, R>(this Func<T1, T2, T3, T4, T5, T6, T7, R> @this)
            => FuncExtensions.CurryFirst(@this);

        #endregion // FuncExtensions

        #region Option

        /// <summary>
        /// None represents the lack of value instead of using null.
        /// </summary>
        /// <returns>None value.</returns>
        public static None None => Option.None;

        /// <summary>
        /// Some will lift any value to an Option.
        /// </summary>
        /// <param name="value">Value to be lifted.</param>
        /// <typeparam name="T">The type of the value being lifted.</typeparam>
        /// <returns>The value in an Option.</returns>
        public static Option<T> Some<T>(T value) => Option.Some(value);

        /// <summary>
        /// ToOption will lift any value to an Option.
        /// </summary>
        /// <param name="@this">Value to be lifted.</param>
        /// <typeparam name="T">The type of the value being lifted.</typeparam>
        /// <returns>The value in an Option.</returns>
        public static Option<T> ToOption<T>(this T @this) => @this;

        /// <summary>
        /// Apply unpacks function wrapped inside Option value into a lifted function.
        /// Signature : Option&lt;T,R&gt; -> Option&lt;T&gt; -> Option&lt;R&gt;
        /// </summary>
        /// <returns>The lifted result Option&lt;R&gt;.</returns>
        /// <param name="@this">Function wrapped in an Option.</param>
        /// <param name="arg">Argument for the lifted function.</param>
        /// <typeparam name="T">In type parameter.</typeparam>
        /// <typeparam name="R">Out type parameter.</typeparam>
        public static Option<R> Apply<T, R>(this Option<Func<T, R>> @this, Option<T> arg)
            => Option.Apply(@this, arg);

        public static Option<Func<T2, R>> Apply<T1, T2, R>
           (this Option<Func<T1, T2, R>> @this, Option<T1> arg)
            => Option.Apply(@this, arg);

        public static Option<Func<T2, T3, R>> Apply<T1, T2, T3, R>
           (this Option<Func<T1, T2, T3, R>> @this, Option<T1> arg)
            => Option.Apply(@this, arg);

        public static Option<Func<T2, T3, T4, R>> Apply<T1, T2, T3, T4, R>
           (this Option<Func<T1, T2, T3, T4, R>> @this, Option<T1> arg)
            => Option.Apply(@this, arg);

        public static Option<Func<T2, T3, T4, T5, R>> Apply<T1, T2, T3, T4, T5, R>
           (this Option<Func<T1, T2, T3, T4, T5, R>> @this, Option<T1> arg)
            => Option.Apply(@this, arg);

        public static Option<Func<T2, T3, T4, T5, T6, R>> Apply<T1, T2, T3, T4, T5, T6, R>
           (this Option<Func<T1, T2, T3, T4, T5, T6, R>> @this, Option<T1> arg)
            => Option.Apply(@this, arg);

        public static Option<Func<T2, T3, T4, T5, T6, T7, R>> Apply<T1, T2, T3, T4, T5, T6, T7, R>
           (this Option<Func<T1, T2, T3, T4, T5, T6, T7, R>> @this, Option<T1> arg)
            => Option.Apply(@this, arg);

        /// <summary>
        /// Signature : Option&lt;(T)&gt; -> Func&lt;T,Option&lt;(T)&gt;&gt; -> Option&lt;(R)&gt;
        /// </summary>
        /// <param name="@this"></param>
        /// <param name="projection"></param>
        /// <typeparam name="T">In type parameter.</typeparam>
        /// <typeparam name="R">Out type parameter.</typeparam>
        /// <returns></returns>
        public static Option<R> Bind<T, R>(this Option<T> @this, Func<T, Option<R>> projection)
            => Option.Bind(@this, projection);

        public static Option<R> Map<T, R>(this None _, Func<T, R> projection) => None;

        /// <summary>
        /// Signature : Option&lt;(T)&gt; -> Func&lt;T,R&gt; -> Option&lt;(R)&gt;
        /// </summary>
        /// <param name="@this"></param>
        /// <param name="projection"></param>
        /// <typeparam name="T">In type parameter.</typeparam>
        /// <typeparam name="R">Out type parameter.</typeparam>
        /// <returns></returns>
        public static Option<R> Map<T, R>(this Option<T> @this, Func<T, R> projection)
            => Option.Map(@this, projection);

        public static Option<Func<T2, R>> Map<T1, T2, R>(this Option<T1> @this
            , Func<T1, T2, R> func)
            => Option.Map(@this, func);

        public static Option<Func<T2, T3, R>> Map<T1, T2, T3, R>(this Option<T1> @this
            , Func<T1, T2, T3, R> func)
            => Option.Map(@this, func);

        public static Option<Func<T2, T3, T4, R>> Map<T1, T2, T3, T4, R>(this Option<T1> @this
            , Func<T1, T2, T3, T4, R> func)
            => Option.Map(@this, func);

        public static Option<Func<T2, T3, T4, T5, R>> Map<T1, T2, T3, T4, T5, R>(this Option<T1> @this
            , Func<T1, T2, T3, T4, T5, R> func)
            => Option.Map(@this, func);

        public static Option<Func<T2, T3, T4, T5, T6, R>> Map<T1, T2, T3, T4, T5, T6, R>(this Option<T1> @this
            , Func<T1, T2, T3, T4, T5, T6, R> func)
            => Option.Map(@this, func);

        public static Option<Func<T2, T3, T4, T5, T6, T7, R>> Map<T1, T2, T3, T4, T5, T6, T7, R>(this Option<T1> @this
            , Func<T1, T2, T3, T4, T5, T6, T7, R> func)
            => Option.Map(@this, func);

        public static T Else<T>(this Option<T> @this, Func<T> alternative)
            => Option.Else(@this, alternative);

        public static T Else<T>(this Option<T> @this, T alternative)
            => Option.Else(@this, alternative);

        public static Option<T> Else<T>(this Option<T> @this, Func<Option<T>> alternative)
            => Option.Else(@this, alternative);

        public static Option<T> Else<T>(this Option<T> @this, Option<T> alternative)
            => Option.Else(@this, alternative);

        public static Option<T> Unwrap<T>(this Option<Option<T>> @this)
            => Option.Unwrap(@this);

        public static Option<R> Select<T, R>(this None @this, Func<T, R> projection) => None;

        public static Option<R> Select<T, R>(this Option<T> @this, Func<T, R> projection)
            => Option.Select(@this, projection);

        public static Option<T> Where<T>(this Option<T> @this, Func<T, bool> predicate)
            => Option.Where(@this, predicate);

        public static Option<R> SelectMany<T1, T2, R>(
            this Option<T1> @this,
            Func<T1, Option<T2>> selector,
            Func<T1, T2, R> result)
            => Option.SelectMany(@this, selector, result);

        public static T GetOrDefault<T>(this Option<T> @this)
            => Option.GetOrDefault(@this);

        public static T ValueUnsafe<T>(this Option<T> @this)
            => Option.ValueUnsafe(@this);

        /// <summary>
        /// Find for IEnumerable will return an Option&lt;T&gt; if item is found or None if it's not.
        /// </summary>
        /// <param name="predicate">The predicate to find item.</param>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <returns>The optional item.</returns>
        public static Option<T> Find<T>(this IEnumerable<T> @this
            , Func<T, bool> predicate)
            => EnumerableExtensions.Find(@this, predicate);

        #endregion // Option

        #region Collection

        public static KeyValuePair<K, T> Pair<K, T>(K key, T value)
            => Collection.Pair(key, value);

        public static IEnumerable<T> List<T>(params T[] items)
            => Collection.List(items);

        public static Func<T, IEnumerable<T>> SingletonList<T>()
            => Collection.SingletonList<T>();

        public static IEnumerable<T> Cons<T>(this T t, IEnumerable<T> ts)
            => Collection.Cons(t, ts);

        public static Func<T, IEnumerable<T>, IEnumerable<T>> Cons<T>()
            => Collection.Cons<T>();

        public static IDictionary<K, T> Map<K, T>(params KeyValuePair<K, T>[] pairs)
            => Collection.Map(pairs);

        public static Func<T, IEnumerable<T>> Return<T>() => t => List(t);

        public static IEnumerable<T> Append<T>(this IEnumerable<T> @this
           , params T[] ts) => Collection.Append(@this, ts);

        public static Option<T> Head<T>(this IEnumerable<T> @this)
            => Collection.Head(@this);

        public static T FirstOr<T>(this IEnumerable<T> @this, T defaultValue)
            => Collection.FirstOr(@this, defaultValue);

        public static IEnumerable<Unit> ForEach<T>
           (this IEnumerable<T> @this, Action<T> action)
            => Collection.ForEach(@this, action);

        public static IEnumerable<R> Map<T, R>
           (this IEnumerable<T> @this, Func<T, R> func)
            => Collection.Map(@this, func);

        public static IEnumerable<Func<T2, R>> Map<T1, T2, R>(this IEnumerable<T1> @this
            , Func<T1, T2, R> func)
            => Collection.Map(@this, func);

        public static IEnumerable<Func<T2, Func<T3, R>>> Map<T1, T2, T3, R>(this IEnumerable<T1> @this
            , Func<T1, T2, T3, R> func)
            => Collection.Map(@this, func);

        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> @this, Func<T, IEnumerable<R>> func)
            => Collection.Bind(@this, func);

        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> @this)
            => Collection.Flatten(@this);

        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> @this, Func<T, Option<R>> func)
            => Collection.Bind(@this, func);

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> @this, Func<T, bool> pred)
            => Collection.TakeWhile(@this, pred);

        public static IEnumerable<T> DropWhile<T>(this IEnumerable<T> @this, Func<T, bool> pred)
            => Collection.DropWhile(@this, pred);

        public static IEnumerable<RR> SelectMany<T, R, RR>
           (this IEnumerable<T> @this
            , Func<T, Option<R>> bind
            , Func<T, R, RR> project)
            => Collection.SelectMany(@this, bind, project);
               
        #endregion // Collection
    }
}
