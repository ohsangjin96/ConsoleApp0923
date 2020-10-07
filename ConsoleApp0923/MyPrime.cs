using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
    delegate void FindDelegate(int prime);
    class MyPrime
    {
        //public event 델리게이트명 이벤트명;(이벤트 문법)

        public event FindDelegate FindPrime;
        public void checknum(int MaxNum)
        {
            int count = 0;
            for(int i=2; i<=MaxNum; i++)//1
            {
                bool Bprime = true; //초기화
                for(int k=2; k<i; k++)//2
                {
                    if (i % k == 0) 
                    {
                        Bprime = false;
                        break;
                    }
                    
                }
                if(Bprime)
                {
                    //Console.Write(i+" ");
                    FindPrime(i);//event 발생 // 이벤트명(전달할 값)
                }
                //break가 되서 내려온 경우

            }
            
        }
    }


    class MyPrimeTest
    {
        static void Main()
        {
            Console.Write("소수를 구하고 싶은 범위의 최대값을 입력:");
            int MaxNum = int.Parse(Console.ReadLine());

            MyPrime pi = new MyPrime();
            pi.FindPrime += new FindDelegate(PrintPrime);//이벤트핸들러 등록(C# 1.0)
            //pi.FindPrime+=PrintPrime //C#2.0

            pi.checknum(MaxNum);

        }
        public static void PrintPrime(int prime)
        {
            Console.WriteLine("이벤트 발생: "+prime);
        }
    }
}
