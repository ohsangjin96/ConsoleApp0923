using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
    struct Print3D
    {
        public int x,y,z;
        public Print3D(int x, int y,int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString() //구조체도 오버라이드 가능하다.
        {
            return $"(x,y,z)=({x},{y},{z})";
        }
    }
    class MyStruct_1
    {
        static void Main()
        {
            Print3D point; // 클래스와 차이점은 new를 굳이 안써도 된다.
            point.x = 20;
            point.y = 10;
            point.z = 5;
            Console.WriteLine(point.ToString());


            Print3D point1 = new Print3D(); // 클래스와 차이점은 new를 굳이 안써도 된다.
            point1.x = 70;
            point1.y = 50;
            point1.z = 40;
            Console.WriteLine(point1.ToString());

            Print3D point2 = new Print3D(90,30,1); // 구조체에서 new를 쓰는 이유는 간단히 하기위해서      
            Console.WriteLine(point2.ToString());

            Print3D point3 = point2;
            point3.z = 900;
            Console.WriteLine(point2.ToString());
            Console.WriteLine(point3.ToString());;
        }
    }
}
