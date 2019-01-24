using System;
using System.Windows.Forms;

namespace 事件的拥有者与事件的响应者是同一个对象
{
    class Program
    {
        static void Main(string[] args)
        {
            MyForm form = new MyForm(); // 事件拥有者  事件响应者
            //事件         
            form.Click += form.Action; //事件订阅
            form.ShowDialog();
        }
    }

    class MyForm : Form
    {
        internal void Action(object sender, EventArgs e)//事件处理器
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
