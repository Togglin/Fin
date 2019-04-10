using System;
using Xunit;

namespace Fin.Tests
{
    using static Core;
    using static Option;
    using static Assert;
    public class OptionTests
    {
        [Fact]
        public void How_does_Apply_work()
        {
            Func<int, string> fromIntToString = (v) => v.ToString();
            // Function enclosed in an Option with the return function Some().
            var optionFunc = Some(fromIntToString);
            // The apply will lift the enclosed function so Option<Func<int,string>> -> Option<int> -> Option<string>.
            var result = optionFunc.Apply(3);

            Equal(Some("3"), result);
        }

        [Fact]
        public void Map_a_func_over_an_option()
        {
            // Map Option<int> => (int) => int => Option<int>
            Func<int, int> add1 = (t) => t + 1;
            Option<int> one = 1;
            var result = one.Map(add1);
            Equal(Some(2), result);
        }

        [Fact]
        public void Bind_a_func_over_an_option()
        {
            Func<int, Option<int>> add1 = (t) => Some(t + 1);
            Option<int> one = 1;
            var result = one.Bind(add1);
            Equal(Some(2), result);
        }
    }
}