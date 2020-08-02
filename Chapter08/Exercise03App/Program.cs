using static System.Console;
using Packt.Shared;

namespace Exercise03App
{
  class Program
  {
    static void Main(string[] args)
    {
      Write("Enter a number: ");
      string input = ReadLine();

      int number = int.Parse(input);

      WriteLine($"{number:N0} in words is {number.ToWords()}.");
    }
  }
}