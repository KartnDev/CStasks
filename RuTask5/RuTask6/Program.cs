using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuTask6
{
    class Program
    {
        public class TreeNode
        {
            public List<TreeNode> leftNextNodes, RightNextNodes;
            public int AvaliableCapacity;
            public int value;
        }

        public static void expandTree(TreeNode leaf)
        {
            leaf.leftNextNodes = new List<TreeNode>();
            invokeLeftFiller(leaf.leftNextNodes, leaf.value, leaf.AvaliableCapacity);
            invokeRightFiller(leaf.RightNextNodes, leaf.value, leaf.AvaliableCapacity);
        }

   
        public static void invokeLeftFiller(List<TreeNode> nodes, int maxBorder, int capacity)
        {
            for(int i = 1; i < maxBorder; i++)
            {
                nodes.Add(new TreeNode() { value = i, AvaliableCapacity = capacity - i, RightNextNodes = new List<TreeNode>() });
                
            }
            foreach(var item in nodes)
            {
                if (item.AvaliableCapacity != 0)
                {
                    invokeRightFiller(item.RightNextNodes, item.value, item.AvaliableCapacity);
                }

            }
        }

        public static void invokeRightFiller(List<TreeNode> nodes, int lowerBorder, int higherBorder)
        {
            for (int i = lowerBorder; i < higherBorder; i++)
            {
                nodes.Add(new TreeNode() { value = i, AvaliableCapacity = higherBorder - i, leftNextNodes = new List<TreeNode>() });
            }
            foreach (var item in nodes)
            {
                if (item.AvaliableCapacity != 0)
                {
                    invokeLeftFiller(nodes, lowerBorder, higherBorder);
                }
            }
        }


        static void Main(string[] args)
        {

            TreeNode leaf = new TreeNode();
            leaf.value = 2;
            leaf.AvaliableCapacity = 6;
            expandTree(leaf);


            Console.ReadLine();

        }
    }
}
