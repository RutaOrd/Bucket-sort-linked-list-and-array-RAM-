using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Op
{
    class MyDataArray : DataArray
    {
        int[] data;
        public MyDataArray(int n, int seed)

        {
            data = new int[n];
            length = n;
            Random rand = new Random(seed);
            int min = 100000;
            int max = 1000000;

            for (int i = 0; i < length; i++)
            {
                data[i] = rand.Next(min, max);
            }

        }
        public override int this[int index]

        {
            get { return data[index]; }

        }

        //Rikiavimo metodas
        public void BucketSort1()
        {

            int minValue = data[0];
            int maxValue = data[0];

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxValue)
                    maxValue = data[i];
                if (data[i] < minValue)
                    minValue = data[i];
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }
           
            for (int i = 0; i < data.Length; i++)
            {
                bucket[data[i] - minValue].Add(data[i]);
            }
           
            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        data[k] = bucket[i][j];
                        k++;
                    }
                  
                }
               
            }
           
        }

        //Pakeistas metodas laiko testavimui
        public void BucketSort2_test(ref long count)
        {

            int minValue = data[0];
            int maxValue = data[0];
            count += 2;

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxValue)
                    maxValue = data[i];
                if (data[i] < minValue)
                    minValue = data[i];
            }
            count += 6;

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];
            count += 2;
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }
            count += 2;
            for (int i = 0; i < data.Length; i++)
            {
                bucket[data[i] - minValue].Add(data[i]);
            }
            count += 2;
            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        data[k] = bucket[i][j];
                        k++;
                        count += 2;
                    }
                    count += 3;
                }
                count += 4;
            }
            count += 9;
        }

    }
}
