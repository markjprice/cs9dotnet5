using System;
using SharpPad;
using System.Threading.Tasks;
using static System.Console;

namespace Dumping
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var complexObject = new
      {
        FirstName = "Petr",
        BirthDate = new DateTime(
          year: 1972, month: 12, day: 25),
        Friends = new[] { "Amir", "Geoff", "Sal" }
      };

      WriteLine(
        $"Dumping {nameof(complexObject)} to SharpPad.");

      await complexObject.Dump();
    }
  }
}