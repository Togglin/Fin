using System;

namespace Fin
{
    public static partial class FuncExtensions
    {
        /// <summary>
        /// Curry a function with 2 params to implement partial application
        /// </summary>
        /// <param name="@this">Func&lt;T1,T2,R&gt;</param>
        /// <typeparam name="T1">First param type.</typeparam>
        /// <typeparam name="T2">Second param type</typeparam>
        /// <typeparam name="R">Return type.</typeparam>
        /// <returns>Func(t1)(t2)</returns>
        public static Func<T1, Func<T2, R>> Curry<T1, T2, R>(this Func<T1, T2, R> @this)
            => t1 => t2 => @this(t1, t2);

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
            => t1 => (t2, t3) => @this(t1, t2, t3);

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
            => t1 => t2 => t3 => @this(t1, t2, t3);

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
            => t1 => (t2, t3, t4) => @this(t1, t2, t3, t4);

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
            => t1 => t2 => t3 => t4 => @this(t1, t2, t3, t4);

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
            => t1 => (t2, t3, t4, t5) => @this(t1, t2, t3, t4, t5);

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
            => t1 => t2 => t3 => t4 => t5 => @this(t1, t2, t3, t4, t5);

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
            => t1 => (t2, t3, t4, t5, t6) => @this(t1, t2, t3, t4, t5, t6);

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
            => t1 => t2 => t3 => t4 => t5 => t6 => @this(t1, t2, t3, t4, t5, t6);

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
            => t1 => (t2, t3, t4, t5, t6, t7) => @this(t1, t2, t3, t4, t5, t6, t7);
    }
}
