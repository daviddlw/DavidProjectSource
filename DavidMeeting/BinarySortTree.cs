using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidMeeting
{
    public class BinaryTree
    {
        public void GenerateTree()
        {
            TreeNode resultTree = null;
            int[] testArr = new int[] { 53, 131, 13, 14, 61, 12, 6 };
            for (int i = 0; i < testArr.Length; i++)
            {
                resultTree = InsertNode(resultTree, testArr[i], i);
            }

            Console.WriteLine("删除前：\n");

            LDR_BST(resultTree);

            //SearchNode(buildTree, 13);

            resultTree = DeleteNode(resultTree, 53);

            Console.WriteLine("删除后：\n");
            LDR_BST(resultTree);
        }

        /// <summary>
        /// 查找二叉树节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public TreeNode SearchNode(TreeNode node, int searchKey)
        {
            if (node == null)
                Console.WriteLine("空树！");

            if (node.Data == searchKey)
                Console.WriteLine("Node Address: {0}", node.Address);
            else
            {
                if (searchKey < node.Data)
                {
                    SearchNode(node.LeftNode, searchKey);
                }
                else
                {
                    SearchNode(node.RightNode, searchKey);
                }
            }

            return node;
        }

        /// <summary>
        /// 插入节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="searchKey"></param>
        /// <param name="address"></param>
        public TreeNode InsertNode(TreeNode node, int searchKey, int address)
        {
            if (node == null)
            {
                node = new TreeNode()
                {
                    Data = searchKey,
                    Address = address,
                    ParentNode = null
                };
            }
            else
            {
                if (searchKey == node.Data)
                {
                    Console.WriteLine("二叉排序树不允许中不允许插入重复值！");
                    return null;
                }

                if (searchKey < node.Data)
                {
                    if (node.LeftNode != null)
                    {
                        InsertNode(node.LeftNode, searchKey, address);
                    }
                    else
                    {
                        node.LeftNode = new TreeNode()
                        {
                            Data = searchKey,
                            Address = address,
                            ParentNode = node
                        };
                    }
                }
                else
                {
                    if (node.RightNode != null)
                    {
                        InsertNode(node.RightNode, searchKey, address);
                    }
                    else
                    {
                        node.RightNode = new TreeNode()
                        {
                            Data = searchKey,
                            Address = address,
                            ParentNode = node
                        };
                    }
                }
            }

            return node;
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public TreeNode DeleteNode(TreeNode node, int searchKey)
        {
            if (node == null)
            {
                Console.WriteLine("空树！");
            }
            else
            {
                if (node.Data == searchKey)
                {
                    //如果为叶子节点，不破坏树结构直接删除
                    if (node.LeftNode == null && node.RightNode == null)
                        node = null;
                    //如果被删除的节点含有一个子节点，让指向该节点的指针指向他的儿子节点 
                    else if (node.LeftNode != null && node.RightNode == null)
                    {
                        node = node.LeftNode;
                    }
                    else if (node.RightNode != null && node.LeftNode == null)
                    {
                        node = node.RightNode;
                    }
                    //如果被删除的节点含有两个子节点，找到左子树中（最右边）的最大节点或者有子树中最小的（最左边）并替换该节点
                    else
                    {
                        var rightChildNode = node.RightNode;//被删除节点的右孩子
                        TreeNode lastPnode = node;//用来保存右孩子的最左节点的父节点。
                        //找到右子树中的最左节点
                        while (rightChildNode.LeftNode != null)
                        {
                            lastPnode = rightChildNode;//保存左子树的父节点
                            //遍历它的左子树
                            rightChildNode = rightChildNode.LeftNode;
                        }
                        //替换原有节点
                        node.Data = rightChildNode.Data;

                        if (lastPnode.RightNode == rightChildNode)//删除节点的右节点没有左节点的时候。即上边的while循环没执行。
                        {
                            node.RightNode = rightChildNode.RightNode;
                        }
                        else
                        {
                            if (lastPnode.LeftNode == rightChildNode)//删除节点的右节点有左节点的时候。
                            {
                                lastPnode.LeftNode = rightChildNode.RightNode;
                            }
                        }
                        rightChildNode = null;//将换位到删除节点去的右子树的最左子树赋值为空
                    }
                }
                else if (searchKey < node.Data)
                {
                    node.LeftNode = DeleteNode(node.LeftNode, searchKey);
                }
                else
                {
                    node.RightNode = DeleteNode(node.RightNode, searchKey);
                }
            }

            return node;
        }

        /// <summary>
        /// 中序遍历-就是从小到大输出（因为）
        /// </summary>
        /// <param name="node"></param>
        public void LDR_BST(TreeNode node)
        {
            if (node != null)
            {
                LDR_BST(node.LeftNode);
                Console.WriteLine("Node Address: {0}, Node Data: {1}", node.Address, node.Data);
                LDR_BST(node.RightNode);
            }
        }
    }

    /// <summary>
    /// 树节点
    /// </summary>
    public class TreeNode
    {
        public TreeNode()
        {
            this.Data = 0;
            this.Address = 0;
        }

        /// <summary>
        /// 数据域
        /// </summary>
        public int Data { get; set; }

        /// <summary>
        /// 数据地址
        /// </summary>
        public int Address { get; set; }

        /// <summary>
        /// 双亲节点
        /// </summary>
        public TreeNode ParentNode { get; set; }

        /// <summary>
        /// 左儿子
        /// </summary>
        public TreeNode LeftNode { get; set; }

        /// <summary>
        /// 右儿子
        /// </summary>
        public TreeNode RightNode { get; set; }
    }
}
