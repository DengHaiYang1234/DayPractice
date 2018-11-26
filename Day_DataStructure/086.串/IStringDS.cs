using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public interface IStringDS<T>
    {
        int IndexOf(T str);
        int[] GetIndex(T str);
        T Remove(int startIndex);
        T Remove(int startIndex, int count);
        T[] Split(char separator);
        T Substring(int startIndex);
        T Substring(int startIndex, int count);
    }
}
