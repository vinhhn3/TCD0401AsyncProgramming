using System;
using System.Threading;

namespace TCD0401AsyncProgramming
{
  internal class Program
  {
    static void Main(string[] args)

    {
      Thread mainThread = Thread.CurrentThread;
      mainThread.Name = "Main Thread";
      lock (Console.Out)
      {
        Console.WriteLine(mainThread.Name);
      }
      Thread thread1 = new Thread(() =>
      {
        CountDown("Timer 1...");
      });
      Thread thread2 = new Thread(() =>
      {
        CountUp("Timer 2...");
      });

      thread1.Start();
      thread2.Start();

    }

    public static void CountDown(string message)
    {
      for (int i = 10; i >= 0; i--)
      {
        lock (Console.Out)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"{message}: {i} seconds");
        }
        Thread.Sleep(1000);
        lock (Console.Out)
        {
          Console.ResetColor();

        }
      }
    }

    public static void CountUp(string message)
    {
      for (int i = 0; i <= 10; i++)
      {
        lock (Console.Out)
        {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine($"{message}: {i} seconds");
        }
        Thread.Sleep(1000);
        lock (Console.Out)
        {
          Console.ResetColor();

        }
      }
    }
  }
}
