// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {
        List list = new List();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Console.WriteLine("The elements in the list are:");
        list.Print();

        Console.WriteLine();

        list.Reverse();
        list.Print();
    }
}