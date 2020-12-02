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
            Root = CreateNodeIfNotExists(root);
            ConnectNodes(null,root);
        }
        public Node CreateNodeIfNotExists(string newNode)
        {
            var node = adjacencyList.Find(n => n.Value == newNode);
            if(node is null)
            {
                var createdNode = new Node(newNode);
                adjacencyList.Add(createdNode);
                return createdNode;
            }
            return node;
        }
        /// <summary>
        /// Undirected graph. Each node has child nodes and Only one parent node.
        /// </summary>
        /// <param name="nodeName1">Parent node</param>
        /// <param name="nodeName2">CHild node</param>
        public void ConnectNodes(string nodeName1, string nodeName2)
        {
            var node1 = adjacencyList.Find(n => n.Value == nodeName1);
            var node2 = adjacencyList.Find(n => n.Value == nodeName2);

            node1?.Children.Add(node2);
            node2.Parent = node1;
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
                foreach (var node in current.Children)
                {
                    node.Depth = current.Depth + 1;
                    processQueue.Enqueue(node);
                } 
            }
            return sum;
        }

        /// <summary>
        /// Calculate minimum number of orbital transfers given two objects.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinimumOrbitalTransfers(string start, string target)
        {
            var startNode = CreateNodeIfNotExists(start);
            var targetNode = CreateNodeIfNotExists(target);
            Node parent = findCommonParent(startNode, targetNode);
            var diff = startNode.Parent.Depth - parent.Depth;
            var diff2 = targetNode.Parent.Depth - parent.Depth;

            return diff + diff2;
        }

        /// <summary>
        /// Finds the common Node for two given Nodes
        /// </summary>
        /// <returns></returns>
        private Node findCommonParent(Node startNode, Node targetNode)
        {
            // base case
            if (object.ReferenceEquals(startNode,targetNode))
                return startNode;

            // recursivelly find the parent by orbit transfer for the object with higher Depth in Tree
            return startNode.Depth > targetNode.Depth ?
                findCommonParent(startNode.Parent, targetNode) :
                findCommonParent(startNode, targetNode.Parent);

        }
    }
}
