using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncEnumerable
{
  class Program
  {
    async static IAsyncEnumerable<int> GetNumbers()
    {
      var r = new Random();

      // simulate work
      await Task.Run(() => System.Threading.Thread.Sleep(r.Next(1000, 2000)));
      yield return r.Next(0, 101);

      await Task.Run(() => System.Threading.Thread.Sleep(r.Next(1000, 2000)));
      yield return r.Next(0, 101);

      await Task.Run(() => System.Threading.Thread.Sleep(r.Next(1000, 2000)));
      yield return r.Next(0, 101);
    }

    static async Task Main(string[] args)
    {
      await foreach (int number in GetNumbers())
      {
        WriteLine($"Number: {number}");
      }
    }
  }
}