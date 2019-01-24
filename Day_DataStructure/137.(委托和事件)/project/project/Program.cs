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
            A a = new A();
            B b = new B(a);
            C c = new C(a);

            //a.Raise("右");
            a.Fall();
        }
    }

    internal delegate void RaiseEventHandler(string hand);

    internal delegate void FallEventHandler();


    class A
    {
        public event RaiseEventHandler RaiseEvent;

        public event FallEventHandler FallEvent;

        public void Raise(string hand)
        {
            Console.WriteLine("A 举起{0}手",hand);
            if (RaiseEvent != null)
            {
                RaiseEvent(hand);
            }
        }

        public void Fall()
        {
            Console.WriteLine("A  开始摔杯");
            if (FallEvent != null)
            {
                FallEvent();
            }
        }
    }

    class B : Base
    {
        public B(A a) : base(a)
        {

        }
        
        public override void RaiseEvent(string hand)
        {
            if (hand.Equals("左"))
            {
                Attack();
            }
        }

        public override void FallEvent()
        {
            base.FallEvent();
        }

        public override void Attack()
        {
            Console.WriteLine("B 抄起家伙 开始攻击");
        }
    }

    class C : Base
    {
        public C(A a) : base(a)
        {
            
        }

        public override void RaiseEvent(string hand)
        {
            if (hand.Equals("右"))
            {
                Attack();
            }
        }

        public override void FallEvent()
        {
            base.FallEvent();
        }

        public override void Attack()
        {
            Console.WriteLine("C 揭竿而起 开始攻击");
        }
    }

    abstract class Base
    {
        private A a;

        public Base(A a)
        {
            this.a = a;
            a.RaiseEvent += new RaiseEventHandler(RaiseEvent);
            a.FallEvent += new FallEventHandler(FallEvent);
        }

        public virtual void RaiseEvent(string hand)
        {
            
        }

        public virtual void FallEvent()
        {
            Attack();
        }

        public abstract void Attack();
    }


}
