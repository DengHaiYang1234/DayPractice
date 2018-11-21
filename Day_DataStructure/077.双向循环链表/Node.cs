using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Node
    {
        public int Data { set; get; }
        public Node PreNode { set; get; }
        public Node NextNode { set; get; }

        public Node(int item,Node pre,Node next)
        {
            Data = item;
            PreNode = pre;
            NextNode = next;
        }
    }
}
