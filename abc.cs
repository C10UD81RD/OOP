using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Linq; using System.Text; 
using System.Threading.Tasks;
 namespace ConsoleApplication1 { 
    public interface IPrint { 
    void Print();
     } 
     class Program 
     {
        abstract class shape : IComparable {
            protected double x, y, pi = Math.PI; 
            public virtual double area() { 
                return (x * y); } 
                 public virtual string ToString() {
                    return ("Side 1: " + x + "\nSide 2: " + y + "\nArea: " + area() + "\n");
                } 
                public shape() { 

                }
                public shape(double x, double y) { 
                    this.x = x; 
                    this.y = y; 
                    }
                    public int CompareTo(object y) { 
                        shape x = (shape)y;  
                        if (this.area() < x.area()) return -1;
                        if (this.area() == x.area()) return 0;
                        else
                        return 1;
                    } 
                } 
            class rectangle : shape, IPrint {
                public rectangle(double x, double y) : base(x, y) { } 
                public void Print() { 
                     Console.WriteLine(ToString());
                     } 
            } 
            class square : rectangle, IPrint {
                public square(double x) : base(x, x) { } 
                public void Print() {
                    Console.WriteLine(ToString());
                } 
            } 
            class circle : shape, IPrint {
                public circle(double r) : base(r, 0) { } 
                public override double area(){
                    return (pi * this.x * this.x);  
                } 
                public override string ToString(){
                    return ("R: " + x + "\nArea: " + area() + "\n");
                } 
                public void Print() {
                    Console.WriteLine(ToString());
                } 
            }
            static void Main(string[] args) { 
                ArrayList lo = new ArrayList(); 
                lo.Add(new square(10)); 
                lo.Add(new rectangle(100, 200));
                lo.Add(new circle(1));  
                Console.WriteLine("До сортировки ArrayList:");
                foreach (var x in lo) Console.WriteLine(x); 
                lo.Sort(); 
                Console.WriteLine("\n"); 
                Console.WriteLine("После сортировки ArrayList:"); 
                foreach (var x in lo) Console.WriteLine(x); 
                Console.WriteLine("\n"); 
                Console.WriteLine("-----------------------------"); 
                List<shape> lo2 = new List<shape>(); 
                lo2.Add(new square(10)); 
                lo2.Add(new rectangle(100, 200)); 
                o2.Add(new circle(1)); 
                Console.WriteLine("До сортировки List:\n"); 
                for (int i = 0; i < lo2.Count; i++) { 
                    Console.WriteLine(lo2[i].ToString()); 
                } 
                lo2.Sort();
                Console.WriteLine("после сортировки List:\n");
                for (int i = 0; i < lo2.Count; i++) { 
                    Console.WriteLine(lo2[i].ToString()); 
                } 
                Console.WriteLine("-----------------------------\n"); 
                Stack<shape> st = new Stack<shape>(); 
                st.Push(new square(10)); 
                st.Push(new rectangle(100, 200)); 
                st.Push(new circle(1)); 
                while(st.Count>0) { 
                    shape p = st.Pop(); 
                Console.WriteLine(p); 
                } 
                Console.ReadLine(); 
            } 
    }
}