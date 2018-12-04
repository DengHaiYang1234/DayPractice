﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Node<T>
    {
        public int Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(int item)
        {
            Data = item;
            Next = null;
        }
    }
}
