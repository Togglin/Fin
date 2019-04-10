using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Fin
{
    [DebuggerDisplay("{ToString()}")]
    public struct Option<T> : IMayHaveSome, IEquatable<Option<T>>
    {
        public static Option<T> None => default(Option<T>);

        private readonly T value;

        public bool HasSome { get; }

        private Option(T value)
        {
            HasSome = value != null ? true : false;
            this.value = value;
        }

        public R Match<R> (Func<R> None, Func<T,R> Some)
        {
            if (Some == null) throw new ArgumentNullException(nameof(Some));
            if (None == null) throw new ArgumentNullException(nameof(None));
            return !HasSome
                ? None()
                : Some(value);
        }

        public IEnumerable<T> ToEnumerable()
        {
            if(HasSome) yield return value;
        }

        public static implicit operator Option<T>(None none) => None;

        public static implicit operator Option<T>(T value) => new Option<T>(value);

        public static explicit operator T(Option<T> optionalValue)
        {
            if (!optionalValue.HasSome) throw new InvalidCastException("None");
            return optionalValue.value;
        }

        public static bool operator ==(Option<T> optionalValue1, Option<T> optionalValue2) =>
            optionalValue1.Equals(optionalValue2);

        public static bool operator !=(Option<T> optionalValue1, Option<T> optionalValue2) =>
            !optionalValue1.Equals(optionalValue2);

        public static bool operator ==(Option<T> optionalValue1, IMayHaveSome optionalValue2) =>
            optionalValue1.Equals(optionalValue2);

        public static bool operator !=(Option<T> optionalValue1, IMayHaveSome optionalValue2) =>
            !optionalValue1.Equals(optionalValue2);

        public static T operator |(Option<T> optionalValue1, Func<Option<T>,T> func) =>
            func(optionalValue1);

        public bool Equals(IMayHaveSome other) =>
            other is Option<T>
            ? Equals((Option<T>)other)
            : other != null && !HasSome && !other.HasSome;

        public bool Equals(Option<T> other) =>
            other.HasSome == HasSome
            && !HasSome
            || Equals(value, other.value);

        public override bool Equals(object obj) =>
            obj is Option<T>
            ? Equals((Option<T>)obj)
            : Equals(obj as IMayHaveSome);

        public override int GetHashCode() =>
            !HasSome
            ? 0
            : ReferenceEquals(value, null) ? -1
            : value.GetHashCode();

        public override string ToString() =>
            HasSome
            ? $"Some({value})"
            : "None";
    }
}