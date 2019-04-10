using System;
using System.ComponentModel;

namespace Fin
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMayHaveSome : IEquatable<IMayHaveSome>
    {
        bool HasSome { get; }
    }
}