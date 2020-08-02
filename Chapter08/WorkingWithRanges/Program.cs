using System;
using static System.Console;

namespace WorkingWithRanges
{
  class Program
  {
    static void Main(string[] args)
    {
      // Defining indexes

      // two ways to define the same index, 3 in from the start
      var i1 = new Index(value: 3); // counts from the start
      Index i2 = 3; // using implicit int conversion operator

      // two ways to define the same index, 5 in from the end
      var i3 = new Index(value: 5, fromEnd: true);
      var i4 = ^5; // using the C# 8.0 caret operator

      // Identifying ranges with the Range type

      Range r1 = new Range(start: new Index(3), end: new Index(7));
      Range r2 = new Range(start: 3, end: 7); // using implicit int conversion
      Range r3 = 3..7; // using C# 8.0 syntax
      Range r4 = Range.StartAt(3); // from index 3 to last index
      Range r5 = 3..; // from index 3 to last index
      Range r6 = Range.EndAt(3); // from index 0 to index 3
      Range r7 = ..3; // from index 0 to index 3

      // Using indexes with string variables

      string name = "Samantha Jones";

      int lengthOfFirst = name.IndexOf(' ');
      int lengthOfLast = name.Length - name.IndexOf(' ') - 1;

      string firstName = name.Substring(
        startIndex: 0, 
        length: lengthOfFirst);

      string lastName = name.Substring(
        startIndex: name.Length - lengthOfLast,
        length: lengthOfLast);

      WriteLine($"First name: {firstName}, Last name: {lastName}");

      ReadOnlySpan<char> nameAsSpan = name.AsSpan();

      var firstNameSpan = nameAsSpan[0..lengthOfFirst];

      var lastNameSpan = nameAsSpan[^lengthOfLast..^0]; 

      WriteLine("First name: {0}, Last name: {1}",
        arg0: firstNameSpan.ToString(),
        arg1: lastNameSpan.ToString());
    }
  }
}