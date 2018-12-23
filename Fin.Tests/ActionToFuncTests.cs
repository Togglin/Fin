using Fin;
using System;
using Xunit;

namespace Fin.Tests
{
    using static Assert;
    using static Core;

    public class ActionToFuncTests
    {
        Action action = ()
            => Console.WriteLine("Test");

        Action<string> actionWithParam = (value)
            => Console.WriteLine(value);

        Action<string,string> actionWith2Params = (value1, value2)
            => Console.WriteLine(value1+value2);

        [Fact]
        public void Should_convert_action_to_func_returning_unit()
            => Equal(Unit(), action.ToFunc()());

        [Fact]
        public void Should_convert_action_with_param_to_func_returning_unit()
            => Equal(Unit(), actionWithParam.ToFunc()("Test"));

        [Fact]
        public void Should_convert_action_with_2_params_to_func_returning_unit()
            => Equal(Unit(), actionWith2Params.ToFunc()("Test1","Test2"));
    }
}