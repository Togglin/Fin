using Unit = System.ValueTuple;

namespace Fin
{
    public static partial class Core
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
        public static Unit Unit() => default(Unit);
    }
}