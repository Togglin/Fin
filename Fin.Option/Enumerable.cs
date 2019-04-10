using System;
using System.Collections.Generic;
using System.Linq;
using Unit = System.ValueTuple;
namespace Fin
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Find for IEnumerable will return an Option&lt;T&gt; if item is found or None if it's not.
        /// </summary>
        /// <param name="predicate">The predicate to find item.</param>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <returns>The optional item.</returns>
        public static Option<T> Find<T>(this IEnumerable<T> @this
            , Func<T, bool> predicate)
            => @this.FirstOrDefault(predicate);
    }
}