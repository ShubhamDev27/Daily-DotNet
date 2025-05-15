using System;


namespace MyMathLib1
{

    struct demo2
    {
        public int x;
        public int y;
        public demo2(int a, int b)
        {
            x = a;
            y = b;
        }
        public void display()
        {
            Console.WriteLine($"{ x},{ y}");
        }
    }
    class Myclass
    {
        public void Main(string[] args)
        {
            demo2 d1 = new demo2();
            d1.display();

        }


    }
}
