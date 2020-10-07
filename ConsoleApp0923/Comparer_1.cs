using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
    class SingerNameComparer : IComparer
    {
        public int Compare(object x, object y) //IComparer
        {
            //이름가 크면 1 이름가 적으면 -1 이름가 같으면 0
            Singer first = x as Singer;
            Singer second = y as Singer;
            if (first.Name.CompareTo(second.Name)==1) return 1; //역순 -1
            else if (first.Name.CompareTo(second.Name)==-1) return -1; //역순 1
            else return 0;
        }
    }
    class Singer : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int AlbumCnt { get; set; }

        public Singer(string name, int age, int albumCnt)
        {
            Name = name;
            Age = age;
            AlbumCnt = albumCnt;
        }

        public override string ToString()
        {
            return $"{Name} - {Age}세 - {AlbumCnt}집 앨범";
        }

        public int CompareTo(object obj)// IComparable
        {
            //나이가 크면 1 나이가 적으면 -1 나이가 같으면 0
            Singer sing = obj as Singer;
            if (this.Age > sing.Age) return 1; //역순 -1
            else if (this.Age < sing.Age) return -1; //역순 1
            else return 0;
        }
    }

    class Cpmparer_1

    {
        static void Main(string[] args)
        {
            Singer[] singers = new Singer[5] {
                    new Singer("아이유", 28, 8),
                    new Singer("자우림", 40, 5),
                    new Singer("거미", 35, 5),
                    new Singer("이승철", 50, 15),
                    new Singer("태진아", 65, 5)
            };
            
            foreach (Singer sing in singers)
            {
                Console.WriteLine(sing.ToString());
            }

            Console.WriteLine("======================================");
            Console.WriteLine();
            
            Array.Sort(singers); //나이로 정렬
            foreach (Singer sing in singers)
            {
                Console.WriteLine(sing.ToString());
            }
            Console.WriteLine("======================================");
            Console.WriteLine();

            SingerNameComparer nameComparer = new SingerNameComparer();
            Array.Sort(singers, nameComparer);
            foreach (Singer sing in singers)
            {
                Console.WriteLine(sing.ToString());
            }
        }
    }
}
