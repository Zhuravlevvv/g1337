using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    /// <summary>
    /// Граф
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// Список вершин графа
        /// </summary>
        public List<GraphVertex> Vertices { get; }
        Queue<GraphVertex> qVertex = new Queue<GraphVertex>();
        Stack<GraphVertex> sVertex = new Stack<GraphVertex>();

        /// <summary>
        /// Конструктор
        /// </summary>
        public Graph()
        {
            Vertices = new List<GraphVertex>();
        }

        /// <summary>
        /// Добавление вершины
        /// </summary>
        /// <param name="vertexName">Имя вершины</param>
        public void AddVertex(string vertexName)
        {
            Vertices.Add(new GraphVertex(vertexName));
        }

        /// <summary>
        /// Поиск вершины
        /// </summary>
        /// <param name="vertexName">Название вершины</param>
        /// <returns>Найденная вершина</returns>
        public GraphVertex FindVertex(string vertexName)
        {
            foreach (var v in Vertices)
            {
                if (v.Name.Equals(vertexName))
                {
                    return v;
                }
            }

            return null;
        }

        /// <summary>
        /// Добавление ребра
        /// </summary>
        /// <param name="firstName">Имя первой вершины</param>
        /// <param name="secondName">Имя второй вершины</param>
        /// <param name="weight">Вес ребра соединяющего вершины</param>
        public void AddEdge(string firstName, string secondName, int weight)
        {
            var v1 = FindVertex(firstName);
            var v2 = FindVertex(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
            }
        }

        public void BFS(string vName)
        {
            var v0 = FindVertex(vName);
            v0.wasVisited = true;
            qVertex.Enqueue(v0);
            Console.Write(v0.ToString());

            var v2 = FindVertex(vName);
            while (qVertex.Count > 0)
            {
                var v1 = qVertex.Dequeue();
                while ((v2 = getAdjUnvisitedVertex(v1.Edges)) != null)
                {
                    v2.wasVisited = true;
                    Console.Write(v2.ToString());
                    qVertex.Enqueue(v2);
                }
            }

            foreach (GraphVertex v in Vertices) //Обнуляем посещение вершин, чтобы можно было использовать алгоритм повторно
                v.wasVisited = false;
        }

        public void DFS(string vName)
        {
            var v0 = FindVertex(vName);
            v0.wasVisited = true;
            sVertex.Push(v0);
            Console.Write(v0.ToString());

            while (sVertex.Count > 0)
            {
                var v1 = getAdjUnvisitedVertex(sVertex.Peek().Edges);
                if (v1 == null)
                {
                    sVertex.Pop();
                }
                else
                {
                    v1.wasVisited = true;
                    Console.Write(v1.ToString());
                    sVertex.Push(v1);
                }
            }     

            foreach (GraphVertex v in Vertices) //Обнуляем посещение вершин, чтобы можно было использовать алгоритм повторно
                v.wasVisited = false;
        }

        public GraphVertex getAdjUnvisitedVertex(List<GraphEdge> v)
        {
            foreach (GraphEdge edges in v)
            {
                if (!edges.ConnectedVertex.wasVisited) {
                    return edges.ConnectedVertex;
                } 
            }
            return null;
        }
    }
}
