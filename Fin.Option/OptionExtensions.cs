using System;
using System.Collections.Generic;

namespace Fin
{
    public static class Option
    {
        /// <summary>
        /// None represents the lack of value instead of using null.
        /// </summary>
        /// <returns>None value.</returns>
        public static None None => default(None);

        /// <summary>
        /// Some will lift any value to an Option.
        /// </summary>
        /// <param name="value">Value to be lifted.</param>
        /// <typeparam name="T">The type of the value being lifted.</typeparam>
        /// <returns>The value in an Option.</returns>
        public static Option<T> Some<T>(T value) => value;

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
            => @this.Match(
              () => None,
              (func) => arg.Match(
                 None: () => None,
                 Some: (val) => Some(func(val))));

        public static Option<Func<T2, R>> Apply<T1, T2, R>
           (this Option<Func<T1, T2, R>> @this, Option<T1> arg)
            => Apply(@this.Map(FuncExtensions.Curry), arg);

        public static Option<Func<T2, T3, R>> Apply<T1, T2, T3, R>
           (this Option<Func<T1, T2, T3, R>> @this, Option<T1> arg)
            => Apply(@this.Map(FuncExtensions.CurryFirst), arg);

        public static Option<Func<T2, T3, T4, R>> Apply<T1, T2, T3, T4, R>
           (this Option<Func<T1, T2, T3, T4, R>> @this, Option<T1> arg)
            => Apply(@this.Map(FuncExtensions.CurryFirst), arg);

        public static Option<Func<T2, T3, T4, T5, R>> Apply<T1, T2, T3, T4, T5, R>
           (this Option<Func<T1, T2, T3, T4, T5, R>> @this, Option<T1> arg)
            => Apply(@this.Map(FuncExtensions.CurryFirst), arg);

        public static Option<Func<T2, T3, T4, T5, T6, R>> Apply<T1, T2, T3, T4, T5, T6, R>
           (this Option<Func<T1, T2, T3, T4, T5, T6, R>> @this, Option<T1> arg)
            => Apply(@this.Map(FuncExtensions.CurryFirst), arg);

        public static Option<Func<T2, T3, T4, T5, T6, T7, R>> Apply<T1, T2, T3, T4, T5, T6, T7, R>
           (this Option<Func<T1, T2, T3, T4, T5, T6, T7, R>> @this, Option<T1> arg)
            => Apply(@this.Map(FuncExtensions.CurryFirst), arg);

        /// <summary>
        /// Signature : Option&lt;(T)&gt; -> Func&lt;T,Option&lt;(T)&gt;&gt; -> Option&lt;(R)&gt;
        /// </summary>
        /// <param name="@this"></param>
        /// <param name="projection"></param>
        /// <typeparam name="T">In type parameter.</typeparam>
        /// <typeparam name="R">Out type parameter.</typeparam>
        /// <returns></returns>
        public static Option<R> Bind<T,R>(this Option<T> @this, Func<T, Option<R>> projection)
            => @this.Match(Some: projection, None: () => None);

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
            => @this.Match(
              () => None,
              (t) => Some(projection(t)));

        public static Option<Func<T2, R>> Map<T1, T2, R>(this Option<T1> @this
            , Func<T1, T2, R> func)
            => @this.Map(func.Curry());

        public static Option<Func<T2, T3, R>> Map<T1, T2, T3, R>(this Option<T1> @this
            , Func<T1, T2, T3, R> func)
            => @this.Map(func.CurryFirst());

        public static Option<Func<T2, T3, T4, R>> Map<T1, T2, T3, T4, R>(this Option<T1> @this
            , Func<T1, T2, T3, T4, R> func)
            => @this.Map(func.CurryFirst());

        public static Option<Func<T2, T3, T4, T5, R>> Map<T1, T2, T3, T4, T5, R>(this Option<T1> @this
            , Func<T1, T2, T3, T4, T5, R> func)
            => @this.Map(func.CurryFirst());

        public static Option<Func<T2, T3, T4, T5, T6, R>> Map<T1, T2, T3, T4, T5, T6, R>(this Option<T1> @this
            , Func<T1, T2, T3, T4, T5, T6, R> func)
            => @this.Map(func.CurryFirst());

        public static Option<Func<T2, T3, T4, T5, T6, T7, R>> Map<T1, T2, T3, T4, T5, T6, T7, R>(this Option<T1> @this
            , Func<T1, T2, T3, T4, T5, T6, T7, R> func)
            => @this.Map(func.CurryFirst());

        public static T Else<T>(this Option<T> @this, Func<T> alternative)
            => @this.Match(Some: v => v, None: alternative);

        public static T Else<T>(this Option<T> @this, T alternative)
            => @this.Else(() => alternative);

        public static Option<T> Else<T>(this Option<T> @this, Func<Option<T>> alternative)
            => @this.Else(alternative);

        public static Option<T> Else<T>(this Option<T> @this, Option<T> alternative)
            => @this.Else(alternative);

        public static Option<T> Unwrap<T>(this Option<Option<T>> @this)
            => @this.Bind(v => v);

        public static Option<R> Select<T,R>(this None @this, Func<T,R> projection) => None;

        public static Option<R> Select<T,R>(this Option<T> @this, Func<T,R> projection)
            => @this.Map(v => projection(v));

        public static Option<T> Where<T>(this Option<T> @this, Func<T,bool> predicate)
            => @this.Bind(v => predicate(v) ? Some(v) : None);

        public static Option<R> SelectMany<T1,T2,R>(
            this Option<T1> @this,
            Func<T1, Option<T2>> selector,
            Func<T1, T2, R> result)
            => @this.Bind(s => selector(s).Select(m => result(s,m)));

        public static T GetOrDefault<T>(this Option<T> @this)
            => @this.Match(
                Some: v => v,
                None: () => default(T));

        public static T ValueUnsafe<T>(this Option<T> @this)
            => @this.Match(
                Some: v => v,
                None: () => { throw new InvalidOperationException("None"); });
    }
}
