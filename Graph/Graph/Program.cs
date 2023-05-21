using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {

        static void Main(string[] args)
        {
            var g = new Graph();

            //добавление вершин
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");
            g.AddVertex("E");

            //добавление ребер
            g.AddEdge("A", "B", 22);
            g.AddEdge("B", "C", 47);
            g.AddEdge("A", "D", 61);
            g.AddEdge("D", "E", 41);
            g.BFS("A");
            Console.WriteLine();
            g.DFS("A");
            Console.ReadKey();
        }
    }
}
