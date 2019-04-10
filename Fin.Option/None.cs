using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Fin
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerDisplay("{ToString()}")]
    public struct None : IMayHaveSome
    {
        public bool HasSome => false;

        public bool Equals(IMayHaveSome other) => other != null && !other.HasSome;

        public override bool Equals(object obj) => Equals(obj as IMayHaveSome);

        public static bool operator ==(None none, None other) => true;

        public static bool operator !=(None none, None other) => false;

        public override int GetHashCode() => 0;

        public override string ToString() => "None";
    }
}
