using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sobey.DataStructure.Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyBinaryTreeBasicTest();
            //MyBinarySearchTreeTest();
            MyBinaryExpressionTreeTest();

            Console.ReadKey();
        }

        #region Test01:二叉树基本测试
        static void MyBinaryTreeBasicTest()
        {
            // 构造一颗二叉树，根节点为"A"
            MyBinaryTree<string> bTree = new MyBinaryTree<string>("A");
            Node<string> rootNode = bTree.Root;
            // 向根节点"A"插入左孩子节点"B"和右孩子节点"C"
            bTree.InsertLeft(rootNode, "B");
            bTree.InsertRight(rootNode, "C");
            // 向节点"B"插入左孩子节点"D"和右孩子节点"E"
            Node<string> nodeB = rootNode.lchild;
            bTree.InsertLeft(nodeB, "D");
            bTree.InsertRight(nodeB, "E");
            // 向节点"C"插入右孩子节点"F"
            Node<string> nodeC = rootNode.rchild;
            bTree.InsertRight(nodeC, "F");
            // 计算二叉树目前的深度
            Console.WriteLine("The depth of the tree : {0}", bTree.GetDepth(bTree.Root));

            // 前序遍历
            Console.WriteLine("---------PreOrder---------");
            bTree.PreOrder(bTree.Root);
            // 中序遍历
            Console.WriteLine();
            Console.WriteLine("---------MidOrder---------");
            bTree.MidOrder(bTree.Root);
            // 后序遍历
            Console.WriteLine();
            Console.WriteLine("---------PostOrder---------");
            bTree.PostOrder(bTree.Root);
            Console.WriteLine();
            // 前序遍历（非递归）
            Console.WriteLine("---------PreOrderNoRecurise---------");
            bTree.PreOrderNoRecurise(bTree.Root);
            // 中序遍历（非递归）
            Console.WriteLine();
            Console.WriteLine("---------MidOrderNoRecurise---------");
            bTree.MidOrderNoRecurise(bTree.Root);
            // 后序遍历（非递归）
            Console.WriteLine();
            Console.WriteLine("---------PostOrderNoRecurise---------");
            bTree.PostOrderNoRecurise(bTree.Root);
            Console.WriteLine();
            // 层次遍历
            Console.WriteLine("---------LevelOrderNoRecurise---------");
            bTree.LevelOrder(bTree.Root);
        }
        #endregion

        #region Test02:二叉查找树基本测试
        static void MyBinarySearchTreeTest()
        {
            MyBinarySearchTree bst = new MyBinarySearchTree(8);
            bst.InsertNode(3);
            bst.InsertNode(10);
            bst.InsertNode(1);
            bst.InsertNode(6);
            bst.InsertNode(14);
            bst.InsertNode(4);
            bst.InsertNode(7);
            bst.InsertNode(13);

            Console.WriteLine("----------First LevelOrder----------");
            bst.LevelOrder(bst.Root);
            Console.WriteLine();

            bst.RemoveNode(6);
            Console.WriteLine("----------LevelOrder Again----------");
            bst.LevelOrder(bst.Root);
            Console.WriteLine();
        } 
        #endregion

        #region Test03:二叉表达式树求解四则运算
        static void MyBinaryExpressionTreeTest()
        {
            Console.WriteLine("请输入四则运算表达式（暂不支持带括号）：");
            string expression = Console.ReadLine();

            MyBinaryExprTree exprTree = new MyBinaryExprTree(expression);
            int result = exprTree.GetResult();
            Console.WriteLine("{0}={1}", expression, result);
        }
        #endregion
    }
}
