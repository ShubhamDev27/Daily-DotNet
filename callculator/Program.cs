using System;

namespace Calculator
{
    internal class cal
    {
        public double square(double num)
        {
            return num * num;
        }
        public double cube(double num)
        {
            return num * num * num;
        }
        public double round(double num)
        {
            return Math.Floor(num); ;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            cal c1 = new cal();
            Console.Write("Enter the Number for Square,Cube and round : ");
            double d1 = double.Parse(Console.ReadLine());

            double square = c1.square(d1);
            Console.WriteLine($"Square = {square}");

            double cube = c1.cube(d1);
            Console.WriteLine($"Cube = {cube}");

            double round = c1.round(d1);
            Console.WriteLine($"Round = {round}");
        }
    }
}
