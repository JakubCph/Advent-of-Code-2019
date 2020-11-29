using System;
using System.Collections.Generic;
using System.Text;

namespace Day6
{
    public class Node
    {
        public string Value { get;}
        public int Depth { get; set; }
        public List<Node> Edges { get; set; }
        public Node(string name)
        {
            Depth = -1;
            Value = name;
            Edges = new List<Node>();
        }
    }
}
