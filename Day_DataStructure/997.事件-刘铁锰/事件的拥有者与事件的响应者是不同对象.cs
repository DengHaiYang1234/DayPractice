using System;
using System.Windows.Forms;


namespace 事件订阅__1
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form(); //事件拥有者
            Controller controller = new Controller(form); //事件响应者
            form.ShowDialog();
        }
    }

    class Controller
    {
        private Form form;

        public Controller(Form form)
        {
            if (form != null)
            {
                this.form = form;
                //事件
                this.form.Click += this.FormClicked;//事件订阅
            }
        }

        private void FormClicked(object sender, EventArgs e)  //事件处理器
        {
            this.form.Text = DateTime.Now.ToString();
        }
    }
}
