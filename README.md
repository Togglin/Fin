# Fin
Fin is a functional programming extension for C#

## Usage
### Curried Functions
Fin has extension methods defined for funcs with 2-6 params with a result.  This is important for implementing partial application.
```csharp
using Fin;

Func<int,int,int> Add = (v1, v2) => v1 + v2;

var add1 = Add.Curry()(1);
var result = add1(2);
// result is 3
```
### Actions to Functions
When action doesn't return a result it's hard to chain functions together. The extension method `ToFunc()` is defined for actions. Add `using Fin;` to access these extension methods.
```csharp
using Fin;

Action<string> printToAction = (toPrintToConsole) => Console.WriteLine(toPrintToConsole)
Func<string,unit> printToFunc = printToAction.ToFunc();
```
### References
**Books**
[Functional Programming in C#](https://www.manning.com/books/functional-programming-in-c-sharp)
How to write better C# code
