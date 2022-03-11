using System;
using System.Collections;

namespace DataStructures.Binary
{
    public class BinaryTree
    {
        public Node Root { get; set; }

        private Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Data)
                    return parent;

                if (value < parent.Data)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }
            return null;
        }

        private int MinValue(Node node)
        {
            int minv = node.Data;
            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }
            return minv;
        }

        private Node Remove(Node parent, int key)
        {
            if (parent == null)
                return parent;

            if (key < parent.Data)
                parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        public Node Find(int value)
        {
            return this.Find(value, this.Root);
        }

        public bool Add(int value)
        {
            Node before = null, after = this.Root;
            while(after != null)
            {
                before = after;
                if (value < after.Data) // Is this lower - needs to go left
                    after = after.LeftNode;
                else if (value > after.Data) // is this higher - needs to go right
                    after = after.RightNode;
                else
                    return false; // value already exist
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                if (value < before.Data)
                {
                    before.LeftNode = newNode;
                }
                else
                {
                    before.RightNode = newNode;
                }
            }

            return true;
        }
    }
}
