using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Op
{
    class Data
    {
        public int first { get; private set; }
        public int second { get; private set; }

        public Data(int number1, int number2)
        {
            first = number1;
            second = number2;
        }

        //užklotas operatorius
        public static bool operator <(Data a1, Data a2)
        {
            return a1.first < a2.first ||
                (a1.first == a2.first && a1.second < a2.second);
        }
        public static bool operator >(Data a1, Data a2)
        {
            return a1.first > a2.first ||
                (a1.first == a2.first && a1.second > a2.second);
        }
        public override string ToString()
        {
            return string.Format("{0}\t{1}\n", first, second);
        }
    }
}

