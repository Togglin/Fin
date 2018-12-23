using System;
using Xunit;

namespace Fin.Tests
{
    using static Assert;

    public class CurryTests
    {
        [Fact]
        public void Should_curry_function_with_2_params()
        {
            Func<int, int, int> add = (t1, t2) => t1 + t2;
            var curriedAdd = add.Curry();
            var result = curriedAdd(1)(1);
            Equal(2, result);
        }

        [Fact]
        public void Should_curry_first_function_with_2_params()
        {
            Func<int, int, int, int> add = (t1, t2, t3) => t1 + t2 + t3;
            var curriedAdd = add.CurryFirst();
            var result = curriedAdd(1)(1, 1);
            Equal(3, result);
        }

        [Fact]
        public void Should_curry_function_with_3_params()
        {
            Func<int, int, int, int> add = (t1, t2, t3) => t1 + t2 + t3;
            var curriedAdd = add.Curry();
            var result = curriedAdd(1)(1)(1);
            Equal(3, result);
        }

        [Fact]
        public void Should_curry_first_function_with_3_params()
        {
            Func<int, int, int, int, int> add = (t1, t2, t3, t4) => t1 + t2 + t3 + t4;
            var curriedAdd = add.CurryFirst();
            var result = curriedAdd(1)(1, 1, 1);
            Equal(4, result);
        }

        [Fact]
        public void Should_curry_function_with_4_params()
        {
            Func<int, int, int, int, int> add = (t1, t2, t3, t4) => t1 + t2 + t3 + t4;
            var curriedAdd = add.Curry();
            var result = curriedAdd(1)(1)(1)(1);
            Equal(4, result);
        }

        [Fact]
        public void Should_curry_first_function_with_4_params()
        {
            Func<int, int, int, int, int, int> add = (t1, t2, t3, t4, t5) => t1 + t2 + t3 + t4 + t5;
            var curriedAdd = add.CurryFirst();
            var result = curriedAdd(1)(1, 1, 1, 1);
            Equal(5, result);
        }

        [Fact]
        public void Should_curry_function_with_5_params()
        {
            Func<int, int, int, int, int, int> add = (t1, t2, t3, t4, t5) => t1 + t2 + t3 + t4 + t5;
            var curriedAdd = add.Curry();
            var result = curriedAdd(1)(1)(1)(1)(1);
            Equal(5, result);
        }

        [Fact]
        public void Should_curry_first_function_with_5_params()
        {
            Func<int, int, int, int, int, int, int> add = (t1, t2, t3, t4, t5, t6) => t1 + t2 + t3 + t4 + t5 + t6;
            var curriedAdd = add.CurryFirst();
            var result = curriedAdd(1)(1, 1, 1, 1, 1);
            Equal(6, result);
        }

        [Fact]
        public void Should_curry_function_with_6_params()
        {
            Func<int, int, int, int, int, int, int> add = (t1, t2, t3, t4, t5, t6) => t1 + t2 + t3 + t4 + t5 + t6;
            var curriedAdd = add.Curry();
            var result = curriedAdd(1)(1)(1)(1)(1)(1);
            Equal(6, result);
        }

        [Fact]
        public void Should_curry_first_function_with_6_params()
        {
            Func<int, int, int, int, int, int, int, int> add = (t1, t2, t3, t4, t5, t6, t7) => t1 + t2 + t3 + t4 + t5 + t6 + t7;
            var curriedAdd = add.CurryFirst();
            var result = curriedAdd(1)(1, 1, 1, 1, 1, 1);
            Equal(7, result);
        }
    }
}
