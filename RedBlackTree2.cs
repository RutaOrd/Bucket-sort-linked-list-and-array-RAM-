using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Op
{
    public enum Color2
    {
        red,
        black
    }
    class Node2
    {
        public Data key;
        public Node2 left;
        public Node2 right;
        public Color color;
        public Node2 parent;
        public Node2(Data item, Color color)
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
    class RedBlackTree2
    {
        public Node2 rootnode;

        public void Insert2(Data item)
        {
            if (rootnode == null)
            {
                rootnode = new Node2(item, Color.black);
            }
            else
            {
                var newNode = Inserts(item);
                Fixup(newNode);
            }

        }
        public Node2 Inserts(Data item)
        {
            var node = rootnode;
            var newNode = new Node2(item, Color.red);
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
        public void Fixup(Node2 node)
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



        public void setBlack(Node2 node)
        {
            node.color = Color.black;
        }
        public void setRed(Node2 node)
        {
            node.color = Color.red;
        }

        private void Rightrotate(Node2 node)
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
        private void LeftRotate(Node2 node)
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

        public void Print2()
        {
            Print2(this.rootnode);
            Console.WriteLine();
        }
        private void Print2(Node2 x)
        {
            if (x == null)
            {
                return;
            }
            else
            {
                Print2(x.left);
                Console.WriteLine("{0}", x.key);
                Print2(x.right);
            }
        }

        public bool Contains(Data x)
        {
            return Contains(x, this.rootnode);
        }

        //Patikrinimas
        private bool Contains(Data x, Node2 n)
        {
            while (n != null)
            {

                if (x < n.key)
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

