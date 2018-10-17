using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoForkedTree tree = new TwoForkedTree();
            Node_ newTree = tree.CreatFakeTree();
            tree.ProSort(newTree);
        }
    }
}
