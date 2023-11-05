using SortierAlgorythmus;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        
        Algorythmus algorythmus = new Algorythmus();
        algorythmus.MainMenu();
        //ListSpeedTest(1024);
        Console.ReadLine();

    }   

    static void ListSpeedTest(int listSize)
    {
        Stopwatch s = new Stopwatch();

        s.Start();
        List<int> numbers = new List<int>();
        for (int i = 0; i < listSize; i++)
        {
            numbers.Add(i * 2);
        }

        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        s.Stop();
        Console.WriteLine("List Speed: " + s.ElapsedMilliseconds);
    }
}