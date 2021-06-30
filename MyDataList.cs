using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Op
{
    class MyDataList : DataList
    {
        class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }
            public int data { get; set; }
            public MyLinkedListNode(int data)
            {
                this.data = data;
            }
        }
        MyLinkedListNode headNode;
        MyLinkedListNode prevNode;
        MyLinkedListNode currentNode;
        public MyDataList(int n, int seed)
        {
            length = n;
            int min = 100000;
            int max = 1000000;
            Random rand = new Random(seed);
            headNode = new MyLinkedListNode(rand.Next(min, max));
            currentNode = headNode;
            for (int i = 1; i < length; i++)
            {
                prevNode = currentNode;
                currentNode.nextNode = new MyLinkedListNode(rand.Next(min, max));
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = null;
        }


        public override int Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }
        public override int Next()
        {
            prevNode = currentNode;
            currentNode = currentNode.nextNode;
            return currentNode.data;
        }

        public void BucketSort2(MyDataList list)
        {
            int maxValue = list.Next();  //start with first element
            int minValue = headNode.data;
            for (int i = 1; i < Length; i++)
            {
                if (currentNode.data > maxValue)
                    maxValue = currentNode.data;

                if (currentNode.data < minValue)
                    minValue = currentNode.data;
            }
            LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];

            for (int i = 0; i < Length; i++)
            {
                if (bucket[currentNode.data - minValue] == null)
                {
                    //bucket[integers[i] - minValue] = new List<int>();
                    bucket[currentNode.data - minValue] = new LinkedList<int>();
                }


                bucket[currentNode.data - minValue].AddLast(currentNode.data);
            }

            int k = 0;  //index for original array
            for (int i = 0; i < Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<int> node = bucket[i].First; //start add head of linked list

                    while (node != null)
                    {
                        currentNode.data = node.Value; //get value of current linked node
                        node = node.Next; //move to next linked node
                        k++;
                    }
                }
            }

        }
    }
}
