using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Node_
    {
        public string Data { get; set; }
        public Node_ Left { get; set; }
        public Node_ Right { get; set; }


        public Node_()
        {
            
        }


        public Node_(string value)
        {
            Data = value;
            Left = null;
            Right = null;
        }
    }
}
