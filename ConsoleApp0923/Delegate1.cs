using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp0923
{
    class MyClass
    {
        private int number;

        public int Number { get => number; set => number = value; }

        public void Plus(int val=0)
        {
            number += val;
        }
        public void Minus(int val = 0)
        {
            number -= val;
        }
        public void Add(int num1, int num2)
        {
            Console.WriteLine(num1+num2);
        }
        public static void PrintHello(int val)
        {
            for(int i=0; i < val; i++)
            {
                Console.WriteLine("hello");
            }
        }
    }

    delegate void sample(int value);
    class Delegate1
    {
        static void Main()
        {
            MyClass c1 = new MyClass();

            //c1.Plus(100); //100
            //c1.Minus(10); //90
            //c1.Add(10,20); //30출력
            //Console.WriteLine(c1.Number); //90출력

            sample s1 = new sample(c1.Plus);//이제 s1을 통해서 c1.Plus 함수를 부른다.

            s1 += new sample(c1.Minus);
            s1(100);
            Console.WriteLine(c1.Number);
            s1 -= new sample(c1.Minus); //C# 1.0문법
            s1(100);
            Console.WriteLine(c1.Number);

            s1 = c1.Minus; //C# 2.0문법
            s1 += c1.Plus;
            s1 += c1.Plus;
            s1(200);//minus(200),plus(200),Plus(200)
            Console.WriteLine(c1.Number);

            s1 += MyClass.PrintHello;//static 메서드도 가능
            s1(5);
            Console.WriteLine(c1.Number);
        }
    }
}
