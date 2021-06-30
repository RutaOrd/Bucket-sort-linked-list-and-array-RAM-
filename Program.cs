using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab1.Op
{
    class Program
    {
        static Random rand;
        static long count;
        static int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
         
        static void Main(string[] args)
        {
 
            Test_Array_List(seed);
            //Search();
            Search2();
            //Test_TimePrint();

        }


        public static void Test_Array_List(int seed)
        {
            int n = 12;
            MyDataArray myarray = new MyDataArray(n, seed);
            Console.WriteLine("\n ARRAY \n");
            Console.WriteLine("\nPradinis masyvas: \n");
            myarray.Print(n);
            myarray.BucketSort1();
            Console.WriteLine("Surikiuotas masyvas: \n");
            myarray.Print(n);
            //MyDataList mylist = new MyDataList(n, seed);
            //Console.WriteLine("\n LIST \n");
            //Console.WriteLine("\nPradinis sąrašas\n");
            //mylist.Print(n);
            ////mylist.BucketSort2();
            //mylist.Print(n);
            //--------------------------
            LinkedList list = new LinkedList(n, seed);
            Console.WriteLine("\n LIST \n");
            Console.WriteLine("\nPradinis sąrašas\n");
            list.Print(n);
            list.BucketSort2();
            Console.WriteLine("\nSurikiuotas\n");
            list.Print(n);


           
        }

        public static void Test_Time_Array(int n)
        {
            //Su masyvu
            MyDataArray array = new MyDataArray(n, seed);
            long s0 = DateTime.Now.Ticks;
            array.BucketSort2_test(ref count);
            long s1 = DateTime.Now.Ticks;
            Console.WriteLine("{0,15} {1,30} {2,20}", n, TimeSpan.FromTicks(s1 - s0).ToString("g"), count);

            //int n4 = 8000;
            //Console.WriteLine("Elementų skaičius                   Laikas                 Operacijos");
            //for (int i = 0; i < 7; i++)
            //{

            //    long count = 0;
            //    LinkedList list3 = new LinkedList(n4, seed);
            //    Stopwatch stopwatch = new Stopwatch();
            //    stopwatch.Start();
            //    list3.BucketSort_test(ref count);
            //    stopwatch.Stop();

            //    Console.WriteLine("{0,15} {1,30} {2,20}", n4, stopwatch.Elapsed, count);
            //    n4 *= 2;

            //}



        }

        public static void Test_Time_List(int n)
        {
            //Su sąrašu
            LinkedList list = new LinkedList(n, seed);
            long s2 = DateTime.Now.Ticks;
            list.BucketSort_test(ref count);
            long s3 = DateTime.Now.Ticks;
            Console.WriteLine("{0,15} {1,30} {2,20}", n, TimeSpan.FromTicks(s3 - s2).ToString("g"), count);
        }

        public static void Test_TimePrint()
        {
            Console.WriteLine("Laiko testavimas masyve:");
            int n = 500;
            Console.WriteLine("Elementų skaičius                   Laikas                 Operacijos");
            for (int i = 0; i < 7; i++)
            {
                count = 0;
                Test_Time_Array(n * (int)Math.Pow(2, i));
            }

            Console.WriteLine("Laiko testavimas sąraše:");
            Console.WriteLine("Elementų skaičius                   Laikas                 Operacijos");
            for (int i = 0; i < 7; i++)
            {
                count = 0;
                Test_Time_List(n * (int)Math.Pow(2, i));
            }

            //------------------
            //MyDataArray myarray2 = new MyDataArray(n3, seed);
            //Console.WriteLine("Elementų skaičius                   Laikas                 Operacijos");
            //for (int i = 0; i < 7; i++)
            //{
            //    long count = 0;
            //    MyDataArray array2 = new MyDataArray(n3, seed);
            //    Stopwatch stopwatch = new Stopwatch();
            //    stopwatch.Start();
            //    array2.BucketSort2_test(ref count);
            //    stopwatch.Stop();

            //    Console.WriteLine("{0,15} {1,30} {2,20}", n3, stopwatch.Elapsed, count);
            //    n3 *= 2;

            //}


        }

        //Red Black tree paieška
        public static void Search()
        {
            int rasta = 0, nerasta = 0;
            RedBlackTree tree = new RedBlackTree();
            
            List<int> list = new List<int>();
            rand = new Random(seed);
            int n = 60;
            for (int i = 0; i < n; i++)
            {
                int se = rand.Next();
                list.Add(se);
                if (i % 3 == 0)
                    tree.Insert(se);

            }
            for (int i = 0; i < n / 6; i++)
            {
                int s = rand.Next();
                list.Add(s);

            }
            Console.WriteLine("Raudonai juodas medis testas: \n");
            tree.Print();
            foreach (int i in list)
            {
                if (tree.Contains(i))
                {
                    Console.WriteLine("true");
                    rasta++;
                }
                else
                {
                    Console.WriteLine("false");
                    nerasta++;
                }

            }
            Console.WriteLine("Rasta elementų: {0}", rasta);
            Console.WriteLine("Nerasta: {0}", nerasta);


        }

        //Paieška su dviem elementais
        public static void Search2()
        {
            int rasta = 0, nerasta = 0;
            RedBlackTree2 t = new RedBlackTree2();

            List<Data> list = new List<Data>();

            rand = new Random(seed);
            int n = 50;
            for (int i = 0; i < n; i++)
            {
                Data s = new Data(rand.Next(), rand.Next());
                list.Add(s);
                if (i % 3 == 0)
                    t.Insert2(s);

            }
            for (int i = 0; i < n / 6; i++)
            {
                Data s = new Data(rand.Next(), rand.Next());
                list.Add(s);

            }
            Console.WriteLine("Medis: ");
            t.Print2();
            foreach (Data i in list)
            {
                if (t.Contains(i))
                {
                    Console.WriteLine("true");
                    rasta++;
                }
                else
                {
                    Console.WriteLine("false");
                    nerasta++;
                }

            }
            Console.WriteLine("Rasta elementų: {0}", rasta);
            Console.WriteLine("Nerasta: {0}", nerasta);


        }



    }
    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract int this[int index] { get; }

        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0} \n", this[i]);
            Console.WriteLine();
        }
    }
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract int Head();
        public abstract int Next();
        public void Print(int n)
        {
            Console.Write(" {0} \n", Head());
            for (int i = 1; i < n; i++)
                Console.Write(" {0} \n", Next());
            Console.WriteLine();
        }

    }

    abstract class List
    {
        public abstract int this[int index] { get; }
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0} \n", this[i]);
            Console.WriteLine();
        }

    }

}

