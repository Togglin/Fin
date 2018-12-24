using System;
using Unit = System.ValueTuple;

namespace Fin
{
    using static Core;

    /// <summary>
    /// To use these extensions add:
    /// using Fin;
    /// </summary>
    public static partial class ActionToFunc
    {
        /// <summary>
        /// The Action.ToFunc() creates a function which when called will
        /// runs the action and returns unit.
        /// </summary>
        /// <param name="action">Any action with no params.</param>
        /// <returns>Func&lt;out Unit&gt;()</returns>
        public static Func<Unit> ToFunc(this Action action)
            => () => { action(); return Unit(); };

        /// <summary>
        /// The Action(value).ToFunc() creates a function which when called will
        /// runs the action and returns unit.
        /// </summary>
        /// <param name="action">Any action with 1 param</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>Func&lt;T,Unit&gt;()</returns>
        public static Func<T, Unit> ToFunc<T>(this Action<T> action)
            => t => { action(t); return Unit(); };

        /// <summary>
        /// The Action(value).ToFunc() creates a function which when called will
        /// runs the action and returns unit.
        /// </summary>
        /// <param name="action">Any action with 2 param</param>
        /// <typeparam name="T1">The type of first value.</typeparam>
        /// <typeparam name="T2">The type of second value.</typeparam>
        /// <returns>Func&lt;T1,T2,Unit&gt;()</returns>
        public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> action)
            => (T1 t1, T2 t2) => { action(t1, t2); return Unit(); };
    }
}