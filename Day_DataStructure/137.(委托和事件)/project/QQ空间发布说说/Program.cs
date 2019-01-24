using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQ空间发布说说
{
    public delegate void ReveiveMessageEventHandler(object sender, ReceiveMssageEnventArgs e);

    class Program
    {
        static void Main(string[] args)
        {
            Users user1 = new Users("dhy", new QQ(1, new List<Users>()));
            Users user2 = new Users("dhy1", new QQ(2, new List<Users>()));
            Users user3 = new Users("dhy2", new QQ(3, new List<Users>()));

            Users currentUser = new Users("cm", new QQ(4, new List<Users> {user1, user2, user3}));
            currentUser.SendMsg("Hello!");

            foreach (var user in currentUser.qqInfos.user)
            {
                user.Receive(user,);
            }
        }
    }

    public class ReceiveMssageEnventArgs : EventArgs
    {
        public string msg { get; set; }

        public ReceiveMssageEnventArgs(string msg)
        {
            this.msg = msg;
        }
    }

    class Users
    {
        public string Name { get; set; }

        public QQ qqInfos;

        public Users(string name,QQ qq)
        {
            Name = name;
            qqInfos = qq;
        }

        private event ReveiveMessageEventHandler handler;
        public void Receive(object o, ReceiveMssageEnventArgs e)
        {
            Console.WriteLine("{0}接收到消息:{1}", Name,e.msg);
            if (handler != null)
            {
                handler(o, e);
            }
        }

        //发布说说
        public void SendMsg(string msg)
        {
            Console.WriteLine("Name:{0},发送一条信息：{1}",Name,msg);
            Receive(this, new ReceiveMssageEnventArgs(msg));
        }
    }

    class QQ
    {
        public int ID { get; set; }
        public List<Users> user;

        public QQ()
        {
            
        }

        public QQ(int id,List<Users> list)
        {
            ID = id;
            user = list;
        }
    }


}
