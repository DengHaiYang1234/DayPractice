﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Node<T>
    {
        public int Data;
        
        public Node<T> Left;

        public Node<T> Right;

        public Node(int x)
        {
            Data = x;
        }

        public Node()
        {
            Data = 0;
            Left = null;
            Right = null;
        }
    }
}
