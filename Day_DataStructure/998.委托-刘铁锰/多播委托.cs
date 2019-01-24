using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student() {ID = 1, PenColor = ConsoleColor.Yellow};
            Student s2 = new Student() { ID = 2, PenColor = ConsoleColor.Blue };
            Student s3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };

            Task task1 = new Task(new Action(s1.DoHomeWork));
            Task task2 = new Task(new Action(s2.DoHomeWork));
            Task task3 = new Task(new Action(s3.DoHomeWork));

            task1.Start();
            task2.Start();
            task3.Start();



            //Action a1 = new Action(s1.DoHomeWork);
            //Action a2 = new Action(s2.DoHomeWork);
            //Action a3 = new Action(s3.DoHomeWork);

            //Thread thread1 = new Thread(new ThreadStart(s1.DoHomeWork));
            //Thread thread2 = new Thread(new ThreadStart(s2.DoHomeWork));
            //Thread thread3 = new Thread(new ThreadStart(s3.DoHomeWork));

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();

            //会发送冲突(多线程)
            //a1.BeginInvoke(null, null);
            //a2.BeginInvoke(null, null);
            //a3.BeginInvoke(null, null);

            //a1();
            //a2();
            //a3();

            //a1 += a2;
            //a1 += a3;
            //a1();

            //s1.DoHomeWork();
            //s2.DoHomeWork();
            //s3.DoHomeWork();


            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main Thred {0}",i);
                Thread.Sleep(1000);
            }
        }
    }

    class Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }

        public void DoHomeWork()
        {
            for(int i =0 ;i < 5;i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine("Student {0},doing homework {1} hour",this.ID,i);
                Thread.Sleep(1000);
            }
        }
    }


}
