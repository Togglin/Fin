using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace Fin.Tests
{
    using static Core;
    using static Option;
    using static Collection;
    using static Assert;

    public class EnumerableTests
    {
        [Fact]
        public void Should_create_factory_function_returning_a_list_from_single_value()
        {
            var factory = Return<int>();
            var result = factory(1);
            Equal(1, result.First());
        }

        [Fact]
        public void Should_append_values_to_list()
        {
            var result = Enumerable.Range(0, 5).Append(6, 7, 8);
            Equal(8, result.Last());
        }

        [Fact]
        public void Should_prepend_value_to_list()
        {
            var result = Enumerable.Range(0, 5).Prepend(8);
            Equal(8, result.First());
        }

        [Fact]
        public void Should_find_and_elevate_value_to_option()
        {
            var result = Enumerable.Range(0, 5).Find((v) => v == 3);
            Assert.Equal(Some(3), result);
        }

        [Fact]
        public void Should_not_find_and_should_return_option_default()
        {
            var result = Enumerable.Range(0, 5).Find((v) => v == 6);
            Assert.Equal(Some(0), result);
        }

        [Fact]
        public void Should_not_find_and_should_return_none()
        {
            var result = Fin.Collection.List("1","2","3").Find((v) => v == "6");
            Assert.Equal(None, result);
        }

        [Fact]
        public void Should_return_first_value_not_or()
        {
            var result = List("1").FirstOr("Default");
            Equal("1", result);
        }

        [Fact]
        public void Should_return_or_default_value_not_null()
        {
            var result = new string[0].FirstOr("Default");
            Equal("Default", result);
        }

        [Fact]
        public void Should_run_foreach_number()
        {
            var result = Enumerable.Range(0, 3).ForEach(Console.WriteLine);
            Equals(List(Unit()), result);
        }

        [Fact]
        public void Should_map_a_func_on_each_value()
        {
            var result = Enumerable.Range(1, 3).Map(n => n * 10);
            Equal(30, result.Last());
        }

        [Fact]
        public void Head_should_return_the_head_value_elevated_to_option()
        {
            var result = List("1", "2", "3").Head();
            Equal(Some("1"), result);
        }

        [Fact]
        public void Head_should_return_none_value_with_null_list()
        {
            IEnumerable<string> nullList = null;
            var result = nullList.Head();
            Equal(None, result);
        }

        [Fact]
        public void Head_should_return_none_with_empty_list()
        {
            var result = new string[0].Head();
            Equal(None, result);
        }

        [Fact]
        public void Should_map_a_func_on_each_value_and_return_a_list_of_curried_funcs_with_one_param()
        {
            var result = Enumerable.Range(1, 3).Map<int, int, int>((n1,n2) => n1 * 10 + n2);
            Equal(31, result.Last()(1));
        }

        [Fact]
        public void Should_map_a_func_on_each_value_and_return_a_list_of_curried_funcs_with_two_params()
        {
            var result = Enumerable.Range(1, 3).Map<int, int, int, int>((n1, n2, n3) => n1 * 10 + n2 - n3);
            Equal(30, result.Last()(1)(1));
        }

        [Fact]
        public void Flatten_list_of_list_of_ints()
        {
            var listToFlatten = new List<IEnumerable<int>>() { Enumerable.Range(0,3), Enumerable.Range(3,3) };
            var result = listToFlatten.Flatten();
            Equal(6, result.Count());
        }

        [Fact]
        public void Should_bind_the_to_string_func_to_list()
        {
            Func<int, Option<string>> toString = (t) => t.ToString();
            var listToBind = Enumerable.Range(0,3);
            var result = listToBind.Bind(toString);
            Equal(new string[]{"0","1","2"}, result);
        }

        [Fact]
        public void Run_select_many()
        {
            Func<int, Option<string>> toString = (t) => t.ToString();
            Func<int, string, int> toNumber = (i,s) => int.Parse(s);
            var listToBind = Enumerable.Range(0,3);
            var result = listToBind.SelectMany(toString, toNumber);
            Equal(new int[]{0,1,2}, result);
        }

        [Fact]
        public void Run_take_while() =>
            Equal(new int[]{2},
            Enumerable.Range(2, 3).TakeWhile((t) => t % 2 == 0));

        [Fact]
        public void Run_drop_while() =>
            Equal(new int[]{2},
            Enumerable.Range(0, 3).DropWhile((t) => t < 2));
    }
}