using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDC.DataStructure.Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test01
            //MyAdjacencyListTest();
            // Test02
            //MyAdjacencyListTraverseTest();
            // Test03
            //PrimTest();
            // Test04
            //KruskalTest();
            // Test05
            //DijkstraTest();
            // Test06
            FloydTest();

            Console.ReadKey();
        }

        #region Test01:图的邻接表存储基本测试
        static void MyAdjacencyListTest()
        {
            Console.WriteLine("------------无向图------------");
            MyAdjacencyList<string> adjList = new MyAdjacencyList<string>();
            // 添加顶点
            adjList.AddVertex("A");
            adjList.AddVertex("B");
            adjList.AddVertex("C");
            adjList.AddVertex("D");
            //adjList.AddVertex("D"); // 会报异常：添加了重复的节点
            // 添加无向边
            adjList.AddEdge("A", "B");
            adjList.AddEdge("A", "C");
            adjList.AddEdge("A", "D");
            adjList.AddEdge("B", "D");
            //adjList.AddEdge("B", "D"); // 会报异常：添加了重复的边

            Console.Write(adjList.GetGraphInfo());

            Console.WriteLine("------------有向图------------");
            MyAdjacencyList<string> dirAdjList = new MyAdjacencyList<string>();
            // 添加顶点
            dirAdjList.AddVertex("A");
            dirAdjList.AddVertex("B");
            dirAdjList.AddVertex("C");
            dirAdjList.AddVertex("D");
            // 添加有向边
            dirAdjList.AddDirectedEdge("A", "B");
            dirAdjList.AddDirectedEdge("A", "C");
            dirAdjList.AddDirectedEdge("A", "D");
            dirAdjList.AddDirectedEdge("B", "D");

            Console.Write(dirAdjList.GetGraphInfo(true));
        }
        #endregion

        #region Test02:图的邻接表遍历算法测试
        static void MyAdjacencyListTraverseTest()
        {
            Console.WriteLine("------------连通图的遍历------------");
            Console.Write("深度优先遍历：");
            MyAdjacencyList<string> adjList = new MyAdjacencyList<string>();
            // 添加顶点
            adjList.AddVertex("V1");
            adjList.AddVertex("V2");
            adjList.AddVertex("V3");
            adjList.AddVertex("V4");
            adjList.AddVertex("V5");
            adjList.AddVertex("V6");
            adjList.AddVertex("V7");
            adjList.AddVertex("V8");
            // 添加边
            adjList.AddEdge("V1", "V2");
            adjList.AddEdge("V1", "V3");
            adjList.AddEdge("V2", "V4");
            adjList.AddEdge("V2", "V5");
            adjList.AddEdge("V3", "V6");
            adjList.AddEdge("V3", "V7");
            adjList.AddEdge("V4", "V8");
            adjList.AddEdge("V5", "V8");
            adjList.AddEdge("V6", "V8");
            adjList.AddEdge("V7", "V8");
            // DFS遍历
            adjList.DFSTraverse();
            Console.WriteLine();
            Console.Write("广度优先遍历：");
            // BFS遍历
            adjList.BFSTraverse();
            Console.WriteLine();

            Console.WriteLine("------------非连通图的遍历------------");
            MyAdjacencyList<string> numAdjList = new MyAdjacencyList<string>();
            // 添加顶点
            numAdjList.AddVertex("V1");
            numAdjList.AddVertex("V2");
            numAdjList.AddVertex("V3");
            numAdjList.AddVertex("V4");
            numAdjList.AddVertex("V5");
            numAdjList.AddVertex("V6");
            numAdjList.AddVertex("V7");
            numAdjList.AddVertex("V8");
            // 添加边
            numAdjList.AddEdge("V1", "V2");
            numAdjList.AddEdge("V1", "V4");
            numAdjList.AddEdge("V2", "V3");
            numAdjList.AddEdge("V2", "V5");
            numAdjList.AddEdge("V4", "V5");
            numAdjList.AddEdge("V6", "V7");
            numAdjList.AddEdge("V6", "V8");
            Console.Write("深度优先遍历：");
            // DFS遍历
            numAdjList.DFSTraverse4NUG();
            Console.WriteLine();
            Console.Write("广度优先遍历：");
            // BFS遍历
            numAdjList.BFSTraverse4NUG();
        }
        #endregion

        #region Test03:最小生成树算法之Prim算法测试:基于邻接矩阵
        static void PrimTest()
        {
            int[,] cost = new int[6, 6];
            // 模拟图的邻接矩阵初始化
            cost[0, 1] = cost[1, 0] = 6;
            cost[0, 2] = cost[2, 0] = 6;
            cost[0, 3] = cost[3, 0] = 1;
            cost[1, 3] = cost[3, 1] = 5;
            cost[2, 3] = cost[3, 2] = 5;
            cost[1, 4] = cost[4, 1] = 3;
            cost[3, 4] = cost[4, 3] = 6;
            cost[3, 5] = cost[5, 3] = 4;
            cost[4, 5] = cost[5, 4] = 6;
            cost[2, 5] = cost[5, 2] = 2;
            // Prim算法构造最小生成树:从顶点0开始
            Console.WriteLine("Prim算法构造最小生成树：（从顶点0开始）");
            double sum = 0;
            Prim(cost, 0, ref sum);
            Console.WriteLine("最小生成树权值和为：{0}", sum);
        }

        static void Prim(int[,] V, int vertex, ref double sum)
        {
            int length = V.GetLength(1);  // 获取元素个数
            int[] lowcost = new int[length]; // 待选边的权值集合V
            int[] U = new int[length]; // 最终生成树值集合U

            for (int i = 0; i < length; i++)
            {
                lowcost[i] = V[vertex, i]; // 将邻接矩阵起始点矩阵中所在行的值加入V
                U[i] = vertex; // U集合中的值全为起始顶点
            }

            lowcost[vertex] = -1; // 起始节点标记为已使用:-1代表已使用，后续不再判断

            for (int i = 1; i < length; i++)
            {
                int k = 0;  // k标识V集合中最小值索引
                int min = int.MaxValue; // 辅助变量：记录最小权值
                // 下面for循环中寻找V集合中权值最小的与顶点i邻接的顶点j
                for (int j = 0; j < length; j++)
                {
                    if (lowcost[j] > 0 && lowcost[j] < min) // 寻找范围不包括0、-1以及无穷大值
                    {
                        min = lowcost[j];
                        k = j; // k记录最小权值索引
                    }
                }
                // 找到了并进行打印输出
                Console.WriteLine("找到边({0},{1})权为：{2}", U[k], k, min);
                lowcost[k] = -1;  // 标志为已使用
                sum += min; // 累加权值

                for (int j = 0; j < length; j++)
                {
                    // 如果集合U中有多个顶点与集合V中某一顶点存在边
                    // 则选取最小权值边加入lowcost集合中
                    if (V[k, j] != 0 && (lowcost[j] == 0 || V[k, j] < lowcost[j]))
                    {
                        lowcost[j] = V[k, j]; // 更新集合lowcost
                        U[j] = k; // 更新集合U
                    }
                }
            }
        }
        #endregion

        #region Test04:最小生成树算法之Kruskal算法测试：基于邻接矩阵
        static void KruskalTest()
        {
            int[,] cost = new int[6, 6];
            // 模拟图的邻接矩阵初始化
            cost[0, 1] = cost[1, 0] = 6;
            cost[0, 2] = cost[2, 0] = 6;
            cost[0, 3] = cost[3, 0] = 1;
            cost[1, 3] = cost[3, 1] = 5;
            cost[2, 3] = cost[3, 2] = 5;
            cost[1, 4] = cost[4, 1] = 3;
            cost[3, 4] = cost[4, 3] = 6;
            cost[3, 5] = cost[5, 3] = 4;
            cost[4, 5] = cost[5, 4] = 6;
            cost[2, 5] = cost[5, 2] = 2;
            // Kruskal算法构造最小生成树:从顶点0开始
            Console.WriteLine("Kruskal算法构造最小生成树：（从顶点0开始）");
            double sum = 0;
            Kruskal(cost, 0, ref sum);
            Console.WriteLine("最小生成树权值和为：{0}", sum);
        }

        static void Kruskal(int[,] cost, int vertex, ref double sum)
        {
            int length = cost.GetLength(1);
            List<Edge> edgeList = BuildEdgeList(cost); // 获取边的有序集合
            int[] groups = new int[length]; // 存放分组号的辅助数组

            for (int i = 0; i < length; i++)
            {
                // 辅助数组的初始化：每个顶点配置一个唯一的分组号
                groups[i] = i;
            }

            for (int k = 1, j = 0; k < length; j++)
            {
                int begin = edgeList[j].Begin; // 边的起始顶点
                int end = edgeList[j].End; // 边的结束顶点
                int groupBegin = groups[begin]; // 起始顶点所属分组号
                int groupEnd = groups[end]; // 结束顶点所属分组号
                // 判断是否存在回路：通过分组号来判断->不是一个分组即不存在回路
                if (groupBegin != groupEnd)
                {
                    // 打印最小生成树边的信息
                    Console.WriteLine("找到边（{0},{1}）权值为：{2}", begin, end, edgeList[j].Weight);
                    sum += edgeList[j].Weight; // 权值之和累加
                    k++;
                    for (int i = 0; i < length; i++)
                    {
                        // 两棵树合并为一课后，将树的所有顶点所属分组号设为一致
                        if (groups[i] == groupEnd)
                        {
                            groups[i] = groupBegin;
                        }
                    }
                }
            }
        }

        // 创建按权值排序的边的集合
        static List<Edge> BuildEdgeList(int[,] cost)
        {
            int length = cost.GetLength(1);
            List<Edge> edgeList = new List<Edge>(); // 边集合
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (cost[i, j] > 0)
                    {
                        if (i < j) // 将序号较小的顶点放在前面
                        {
                            Edge newEdge = new Edge(i, j, cost[i, j]);
                            edgeList.Add(newEdge);
                        }
                        else
                        {
                            Edge newEdge = new Edge(j, i, cost[i, j]);
                            edgeList.Add(newEdge);
                        }
                    }
                }
            }
            edgeList.Sort(); // 让各边按权值从小到大排序
            return edgeList;
        }

        // 存放边信息的结构体
        struct Edge : IComparable
        {
            public int Begin;  // 边的起点
            public int End;    // 边的重点
            public int Weight; // 边的权值

            public Edge(int begin, int end, int weight)
            {
                this.Begin = begin;
                this.End = end;
                this.Weight = weight;
            }

            public int CompareTo(object obj)
            {
                Edge edge = (Edge)obj;
                return this.Weight.CompareTo(edge.Weight);
            }
        }
        #endregion

        #region Test05:最短路径算法之Dijkstra算法测试：基于邻接矩阵
        static void DijkstraTest()
        {
            int[,] cost = new int[5, 5];
            // 初始化邻接矩阵
            cost[0, 1] = 10;
            cost[0, 3] = 30;
            cost[0, 4] = 90;
            cost[1, 2] = 50;
            cost[2, 4] = 10;
            cost[3, 2] = 20;
            cost[3, 4] = 60;
            // 使用Dijkstra算法计算最短路径
            Dijkstra(cost, 0);
        }

        static void Dijkstra(int[,] cost, int v)
        {
            int n = cost.GetLength(1); // 计算顶点个数
            int[] s = new int[n];      // 集合S
            int[] dist = new int[n];   // 结果集
            int[] path = new int[n];   // 路径集

            for (int i = 0; i < n; i++)
            {
                // 初始化结果集
                dist[i] = cost[v, i];
                // 初始化路径集
                if (cost[v, i] > 0)
                {
                    // 如果源点与顶点存在边
                    path[i] = v;
                }
                else
                {
                    // 如果源点与顶点不存在边
                    path[i] = -1;
                }
            }

            s[v] = 1;   // 将源点加入集合S
            path[v] = 0;

            for (int i = 0; i < n; i++)
            {
                int u = 0;  // 指示剩余顶点在dist集合中的最小值的索引号
                int minDis = int.MaxValue; // 指示剩余顶点在dist集合中的最小值大小

                // 01.计算dist集合中的最小值
                for (int j = 0; j < n; j++)
                {
                    if (s[j] == 0 && dist[j] > 0 && dist[j] < minDis)
                    {
                        u = j;
                        minDis = dist[j];
                    }
                }

                s[u] = 1; // 将抽出的顶点放入集合S中

                // 02.计算源点经过顶点u到其余顶点的距离
                for (int j = 0; j < n; j++)
                {
                    // 如果顶点不在集合S中
                    if (s[j] == 0)
                    {
                        // 加入的顶点如与其余顶点存在边，并且重新计算的值小于原值
                        if (cost[u, j] > 0 && (dist[j] == 0 || dist[u] + cost[u, j] < dist[j]))
                        {
                            // 计算更小的值代替原值
                            dist[j] = dist[u] + cost[u, j];
                            path[j] = u;
                        }
                    }
                }
            }


            // 打印源点到各顶点的路径及距离
            for (int i = 0; i < n; i++)
            {
                if (s[i] == 1)
                {
                    Console.Write("从{0}到{1}的最短路径为：", v, i);
                    Console.Write(v + "→");
                    // 使用递归获取指定顶点在路径上的前一顶点
                    GetPath(path, i, v);
                    Console.Write(i + Environment.NewLine + "SUM:");
                    Console.WriteLine("路径长度为：{0}", dist[i]);
                }
            }
        }

        static void GetPath(int[] path, int i, int v)
        {
            int k = path[i];
            if (k == v)
            {
                return;
            }

            GetPath(path, k, v);
            Console.Write(k + "→");
        }
        #endregion

        #region Test06:最短路径算法之Floyd算法测试：基于邻接矩阵
        static void FloydTest()
        {
            int[,] cost = new int[5, 5];
            // 初始化邻接矩阵
            cost[0, 1] = 10;
            cost[0, 3] = 30;
            cost[0, 4] = 90;
            cost[1, 2] = 50;
            cost[2, 4] = 10;
            cost[3, 2] = 20;
            cost[3, 4] = 60;
            // 使用Flyod算法计算最短路径
            Floyd(cost, 0);
        }

        static void Floyd(int[,] cost, int v)
        {
            int n = cost.GetLength(1);  // 获取顶点个数
            int[,] A = new int[n, n];   // 存放最短路径长度
            int[,] path = new int[n, n];// 存放最短路径信息

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // 辅助数组A和path的初始化
                    A[i, j] = cost[i, j];
                    path[i, j] = -1;
                }
            }

            // Flyod算法核心代码部分
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        // 如果存在中间顶点K的路径
                        if (i != j && A[i, k] != 0 && A[k, j] != 0)
                        {
                            // 如果加入中间顶点k后的路径更短
                            if (A[i, j] == 0 || A[i, j] > A[i, k] + A[k, j])
                            {
                                // 使用新路径代替原路径
                                A[i, j] = A[i, k] + A[k, j];
                                path[i, j] = k;
                            }
                        }
                    }
                }
            }

            // 打印最短路径及路径长度
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (A[i, j] == 0)
                    {
                        if (i != j)
                        {
                            Console.WriteLine("从{0}到{1}没有路径!", i, j);
                        }
                    }
                    else
                    {
                        Console.Write("从{0}到{1}的路径为：", i, j);
                        Console.Write(i + "→");
                        // 使用递归获取指定顶点的路径
                        GetPath(path, i, j);
                        Console.Write(j + "     ");
                        Console.WriteLine("路径长度为：{0}", A[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        static void GetPath(int[,] path, int i, int j)
        {
            int k = path[i, j];
            if (k == -1)
            {
                return;
            }

            GetPath(path, i, k);
            Console.Write(k + "→");
            GetPath(path, k, j);
        }
        #endregion
    }
}
