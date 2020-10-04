using System;
using static System.Console;

namespace DotNetCoreEverywhere
{
  class Program
  {
    static void Main(string[] args)
    {
      WriteLine("I can run everywhere!");

      WriteLine($"OS Version is {Environment.OSVersion}");

      if (OperatingSystem.IsMacOS())
      {
        WriteLine("macOS");
      }
      else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10))
      {
        WriteLine("Windows 10");
      }
    }
  }
}
