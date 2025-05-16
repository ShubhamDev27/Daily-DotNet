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
            Console.WriteLine($"{x},{y}");
        }
    }
    class Myclass
    {
        public static void Main(string[] args)
        {
            demo2 demo = new demo2(); 
            demo2 d1 = new demo2(30,20);
            d1.display();
            demo.display();

        }


    }
}
