using Xunit;
using Unit = System.ValueTuple;

namespace Fin.Tests
{
    using static Assert;
    public class CoreTests
    {
        [Fact]
        public void Should_return_unit()
            => Equal(default(Unit), Core.Unit());
    }
}