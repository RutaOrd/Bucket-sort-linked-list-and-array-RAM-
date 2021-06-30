using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Op
{
    class LinkedList : List
    {
        int[] data;

        public LinkedList (int n, int seed)
        {
            data = new int[n];
            Random rand = new Random(seed);
            int min = 100000;
            int max = 1000000;

            for (int i = 0; i < n; i++)
            {
                data[i] = rand.Next(min, max);
            }

        }
        public override int this[int index]

        {
            get { return data[index]; }

        }

        public void BucketSort2()
        {
           
            int maxValue = data[0]; 
            int minValue = data[0];

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxValue)
                    maxValue = data[i];

                if (data[i] < minValue)
                    minValue = data[i];
            }

            LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];

            for (int i = 0; i < data.Length; i++)
            {
                if (bucket[data[i] - minValue] == null)
                {
                    bucket[data[i] - minValue] = new LinkedList<int>();
                }
               
                bucket[data[i] - minValue].AddLast(data[i]);
            }

            int k = 0;  


            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<int> node = bucket[i].First; 

                    while (node != null)
                    {
                        data[k] = node.Value; 
                        node = node.Next; 
                        k++;
                    }
                }
            }

        }


        //-----------------------------------------------


        public void BucketSort_test(ref long count)
        {

            int maxValue = data[0];
            int minValue = data[0];
            count += 2;

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxValue)
                    maxValue = data[i];

                if (data[i] < minValue)
                    minValue = data[i];
                count += 6;
            }

            LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];

            for (int i = 0; i < data.Length; i++)
            {
                if (bucket[data[i] - minValue] == null)
                {
                    bucket[data[i] - minValue] = new LinkedList<int>();
                }

                bucket[data[i] - minValue].AddLast(data[i]);
                count += 3;
            }
            count += 4;

            int k = 0;


            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<int> node = bucket[i].First;

                    while (node != null)
                    {
                        data[k] = node.Value;
                        node = node.Next;
                        k++;
                        count += 3; 
                    }
                    count += 4;
                }
                count += 3;
            }
            count += 10;
        }


    }
}
