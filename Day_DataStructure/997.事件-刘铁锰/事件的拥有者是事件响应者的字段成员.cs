using System;
using System.Windows.Forms;

namespace 事件的拥有者是事件响应者的字段成员
{
    class Program
    {
        static void Main(string[] args)
        {
            MyForm myForm = new MyForm(); //事件响应者
            myForm.ShowDialog();
        }
    }

    class MyForm : Form
    {
        private TextBox textBox;
        private Button button; //事件的拥有者
        
        public MyForm()
        {
            this.textBox = new TextBox();
            this.button = new Button();
            this.Controls.Add(this.button);
            this.Controls.Add(this.textBox);
            //事件  
            this.button.Click += (sender, e) =>//会自动推断出其中的参数类型
            {
                this.textBox.Text = "Hello World11!!!!!!!!!!!!!!!!!!!";
                Console.WriteLine(sender.ToString());
            };//订阅

            this.button.Text = "Say Hello";
            this.button.Top = 50;
        }

        private void Button_Clicked(object sender, EventArgs e) //事件处理器
        {
            this.textBox.Text = "Hello World!!!!!!!!!!!!!!!!!!!";
        }
    }
}
