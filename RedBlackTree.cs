using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Op
{
    public enum Color
    {
        red,
        black
    }
    class Node
    {
        public int key;
        public Node left;
        public Node right;
        public Color color;
        public Node parent;
        public Node(int item, Color color)
        {
            key = item;
            left = null;
            right = null;
            this.color = color;
        }
        public override string ToString()
        {
            return key + "(" + color.ToString() + ")";
        }
    }
    class RedBlackTree
    {
        public Node rootnode;

        public void Insert(int item)
        {
            if (rootnode == null)
            {
                rootnode = new Node(item, Color.black);
            }
            else
            {
                var newNode = Insert2(item);
                Fixup(newNode);
            }

        }
        public Node Insert2(int item)
        {
            var node = rootnode;
            var newNode = new Node(item, Color.red);
            while (true)
            {
                if (item > node.key)
                {
                    if (node.right == null)
                    {
                        newNode.parent = node;
                        node.right = newNode;
                        break;
                    }
                    node = node.right;
                }
                else if (item < node.key)
                {
                    if (node.left == null)
                    {
                        newNode.parent = node;
                        node.left = newNode;
                        break;
                    }
                    node = node.left;
                }

            }
            return newNode;

        }
        private void Rightrotate(Node node)
        {
            var temp = node.left;
            node.left = temp.right;
            if (temp.right != null)
            {
                temp.right.parent = node;
            }
            temp.parent = node.parent;
            if (node.parent == null)
            {
                rootnode = temp;
            }
            else
            {
                if (node == node.parent.left)
                {
                    node.parent.left = temp;
                }
                else if (node == node.parent.right)
                {
                    node.parent.right = temp;
                }
            }
            temp.right = node;
            node.parent = temp;
        }
        private void LeftRotate(Node node)
        {
            var temp = node.right;
            node.right = temp.left;
            if (temp.left != null)
            {
                temp.left.parent = node;
            }
            temp.parent = node.parent;
            if (node.parent == null)
            {
                rootnode = temp;
            }
            else
            {
                if (node == node.parent.left)
                {
                    node.parent.left = temp;
                }
                else
                {
                    node.parent.right = temp;
                }
            }
            temp.left = node;
            node.parent = temp;
        }


        public void setBlack(Node node)
        {
            node.color = Color.black;
        }
        public void setRed(Node node)
        {
            node.color = Color.red;
        }

        public void Fixup(Node node)
        {
            var parentnode = node.parent;
            if (parentnode != null && parentnode.color == Color.red)
            {
                var grandparent = parentnode.parent;

                if (parentnode == grandparent.left)
                {
                    var unode = grandparent.right;
                    if (unode != null && unode.color == Color.red)
                    {
                        setRed(grandparent);
                    }
                 
                   if (node == parentnode.left)
                   {
                            setBlack(parentnode);
                            setRed(grandparent);
                            Rightrotate(grandparent);

                    }
                   else if (node == parentnode.right)
                   {
                            LeftRotate(parentnode);
                            Fixup(parentnode);
                   }

                    else
                    { 
            
                        if (node == parentnode.right)
                        {
                            setBlack(parentnode);
                            setRed(grandparent);
                            LeftRotate(grandparent);
                        }
                        else if (node == parentnode.left)
                        {
                            Rightrotate(parentnode);
                            Fixup(parentnode);
                        }
                    }
                }

            }

            setBlack(rootnode);

        }

     


        public void Print()
        {
            Print(this.rootnode);
            Console.WriteLine();
        }
        private void Print(Node x)
        {
            if (x == null)
            {
                return;
            }
            else
            {
                Print(x.left);
                Console.WriteLine("{0}", x.key);
                Print(x.right);
            }
        }

        public bool Contains(int x)
        {
            return Contains(x, this.rootnode);
        }

        //Patikrinimas
        private bool Contains(int x, Node n)
        {
            while( n != null)
            {
              
                if(x < n.key)
                {
                    n = n.left;
                }
                else if (x > n.key)
                {
                    n = n.right;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

    }


}