using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day6
{
    public class Tree
    {
        public Node Root { get; private set; }
        private List<Node> adjacencyList;

        public Tree(string root)
        {
            adjacencyList = new List<Node>();
            Root = new Node(root) { Depth = 0};
            adjacencyList.Add(Root);
        }
        public bool CreateNodeIfNotExists(string newNode)
        {
            if(adjacencyList.Any(n => n.Value == newNode))
            {
                return false;
            }
            adjacencyList.Add(new Node(newNode));
            return true;
        }
        /// <summary>
        /// Directed graph. node2 orbits around node1 therefore only ass to node1's edges.
        /// </summary>
        public void ConnectNodes(string nodeName1, string nodeName2)
        {
            var node1 = adjacencyList.Find(n => n.Value == nodeName1);
            var node2 = adjacencyList.Find(n => n.Value == nodeName2);

            node1.Edges.Add(node2);
        }

        private Queue<Node> processQueue;

        /// <summary>
        /// Sets the depth of each Node relative to the Root Node using BFS traversal strategy.
        /// Sums teh depth of each Node as it traverses the tree.
        /// No cycles in the tree. Therefore no need for checking if a Node was already visited.
        /// </summary>
        public int CalculateTotalOrbits()
        {
            processQueue = new Queue<Node>();
            processQueue.Enqueue(Root);
            Root.Depth = 0;
            var sum = Root.Depth;
            while (processQueue.Count > 0)
            {
                var current = processQueue.Dequeue();
                sum += current.Depth;
                foreach (var node in current.Edges)
                {
                    node.Depth = current.Depth + 1;
                    processQueue.Enqueue(node);
                } 
            }
            return sum;
        }
    }
}
