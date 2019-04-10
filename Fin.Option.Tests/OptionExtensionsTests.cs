using System;
using Xunit;

namespace Fin.Tests
{
    using static Option;
    using static Assert;

    public class OptionExtensionsTests
    {
        [Fact]
        public void Should_map_curry_first_function_with_5_params()
        {
            Func<int, int, int, int, int, int, int> add = (t1, t2, t3, t4, t5, t6) => t1 + t2 + t3 + t4 + t5 + t6;
            var partialApplicationAdd = Some(1).Map(add);
            var result = partialApplicationAdd.Apply(1).Apply(1).Apply(1).Apply(1).Apply(1);
            Equal(Some(6), result);
        }

        [Fact]
        public void Should_map_curry_first_function_with_6_params()
        {
            Func<int, int, int, int, int, int, int, int> add = (t1, t2, t3, t4, t5, t6, t7) => t1 + t2 + t3 + t4 + t5 + t6 + t7;
            var partialApplicationAdd = Some(1).Map(add);
            var result = partialApplicationAdd.Apply(1).Apply(1).Apply(1).Apply(1).Apply(1).Apply(1);
            Equal(Some(7), result);
        }

        [Fact]
        public void Should_be_none_if_value_is_null()
        {
            string value = null;
            var result = Some(value);
            Equal(None, result);
        }

        [Fact]
        public void Should_create_option_none() =>
            Equal(None, Option<int>.None);

        [Fact]
        public void Int_should_implicitly_cast_to_option()
        {
            Option<int> result = 1;
            Equal(Some(1), result);
        }

        [Fact]
        public void String_should_implicitly_cast_to_option()
        {
            var input = "input";
            Option<string> result = input;
            Equal(Some("input"), result);
        }

        [Fact]
        public void Should_cast_to_int_type_from_option() =>
            Equal(1, (int)1.ToOption());

        [Fact]
        public void Should_cast_to_string_type_from_option() =>
            Equal("input", (string)"input".ToOption());

        [Fact]
        public void Some_should_box_int_in_option() =>
            Equal(1, 1.ToOption().ValueUnsafe());

        [Fact]
        public void Some_should_box_string_in_option() =>
            Equal("input", "input".ToOption().ValueUnsafe());

        [Fact]
        public void None_should_equal_none() =>
            True(None.Equals(None));

        [Fact]
        public void Strings_should_be_equal()
        {
            var input = "input";
            Option<string> value1 = input;
            var value2 = Some(input);

            True(value1.Equals(value2));
        }

        [Fact]
        public void Ints_should_be_equal()
        {
            var input = 1;
            Option<int> value1 = input;
            var value2 = Some(input);

            True(value1.Equals(value2));
        }

        [Fact]
        public void Option_match_int() =>
            True(1.ToOption().Match(
                Some: (_) => true,
                None: () => false));

        [Fact]
        public void Option_match_int_flipped() =>
            True(1.ToOption().Match(
                () => false,
                (_) => true));

        [Fact]
        public void Option_match_none() =>
            True(Option<int>.None.Match(
                Some: (_) => false,
                None: () => true));

        [Fact]
        public void Option_match_none_flipped() =>
            True(Option<int>.None.Match(
                () => true,
                (_) => false));

        [Fact]
        public void Option_map_func_with_two_params()
        {
            Func<string,string,string> AddTwoStrings = (one, two) => one + two;
            Func<Func<string,string>,string> AddTest = f => f("test");
            Option<string> toAdd = "one";
            var result = toAdd.Map(AddTwoStrings)
                              .Map(AddTest);
            Equal(Some("onetest"), result);
        }

        [Fact]
        public void Option_map_func_with_three_params()
        {
            Func<string,string,string,string> AddThreeStrings = (one, two, three) => one + two + three;
            Option<string> toAdd = "one";
            var result = toAdd.Map(AddThreeStrings)
                              .Map(f => f("test","test"));
            Equal(Some("onetesttest"), result);
        }

        [Fact]
        public void Option_map_func_with_four_params()
        {
            Func<string,string,string,string,string> AddStrings = (one, two, three, four) => one + two + three + four;
            Option<string> toAdd = "one";
            var result = toAdd.Map(AddStrings)
                              .Map(f => f("test","test","test"));
            Equal(Some("onetesttesttest"), result);
        }

        [Fact]
        public void Option_map_func_with_five_params()
        {
            Func<string,string,string,string,string,string> AddStrings = (one, two, three, four, five) =>
                one + two + three + four + five;
            Option<string> toAdd = "one";
            var result = toAdd.Map(AddStrings)
                              .Map(f => f("test","test","test","test"));
            Equal(Some("onetesttesttesttest"), result);
        }

        [Fact]
        public void Option_map_func_with_six_params()
        {
            Func<string,string,string,string,string,string,string> AddStrings = (one, two, three, four, five, six) =>
                one + two + three + four + five + six;
            Option<string> toAdd = "one";
            var result = toAdd.Map(AddStrings)
                              .Map(f => f("test","test","test","test","test"));
            Equal(Some("onetesttesttesttesttest"), result);
        }

        [Fact]
        public void Option_map_func_with_seven_params()
        {
            Func<string,string,string,string,string,string,string,string> AddStrings = (one, two, three, four, five, six, seven) =>
                one + two + three + four + five + six + seven;
            Option<string> toAdd = "one";
            var result = toAdd.Map(AddStrings)
                              .Map(f => f("test","test","test","test","test","test"));
            Equal(Some("onetesttesttesttesttesttest"), result);
        }

        [Fact]
        public void Should_map_curry_first_function_with_2_params()
        {
            Func<int, int, int, int> add = (t1, t2, t3) => t1 + t2 + t3;
            var partialApplicationAdd = Some(1).Map(add);
            var result = partialApplicationAdd.Apply(1).Apply(1);
            Equal(Some(3), result);
        }

        [Fact]
        public void Should_map_curry_first_function_with_3_params()
        {
            Func<int, int, int, int, int> add = (t1, t2, t3, t4) => t1 + t2 + t3 + t4;
            var partialApplicationAdd = Some(1).Map(add);
            var result = partialApplicationAdd.Apply(1).Apply(1).Apply(1);
            Equal(Some(4), result);
        }

        [Fact]
        public void Should_map_curry_first_function_with_4_params()
        {
            Func<int, int, int, int, int, int> add = (t1, t2, t3, t4, t5) => t1 + t2 + t3 + t4 + t5;
            var partialApplicationAdd = Some(1).Map(add);
            var result = partialApplicationAdd.Apply(1).Apply(1).Apply(1).Apply(1);
            Equal(Some(5), result);
        }
    }
}