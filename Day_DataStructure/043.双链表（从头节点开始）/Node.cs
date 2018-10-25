using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Node
    {
        public int Data { get; set; }
        public Node PreNode { get; set; }
        public Node NextNode { get; set; }

        public Node(int value)
        {
            Data = value;
            PreNode = null;
            NextNode = null;
        }

        public Node(int value,Node pre,Node next)
        {
            Data = value;
            PreNode = pre;
            NextNode = next;
        }
    }
}
