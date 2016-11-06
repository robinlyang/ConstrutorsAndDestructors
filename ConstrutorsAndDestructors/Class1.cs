using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConstrutorsAndDestructors
{
    class worker:IDisposable
    {
        public string name;
        public double salary;
        public worker() //empty or default constructor (called by new)
        {//may want to get values from CSV or XML file
            //or open connections to files/databases
            //or write a note to a log file
            name = "";
            salary = 0;
            Console.WriteLine("in basic constructor");
        }
        public worker(string newname, double newsalary) //named constructor
        {
            this.name = newname;
            this.salary = newsalary;
            Console.WriteLine("in named constructor");
        }
        public worker(double newsalary, string newname)
            : this(newname, newsalary) //also a named constructor that calls another constructor
        {
        }

        ~worker() //destructor (runs when program closes)
        {//use for closing files/databases connections and writing logs
            Console.WriteLine("In destructor");
            Console.WriteLine("In destructor");
            Console.WriteLine("In destructor");
            Console.WriteLine("In destructor");
            Console.WriteLine("In destructor");
            Console.ReadLine();
        }

        public void Dispose()
        {
            //remove the throw
        }
    }
    class Program
    {
        static void Main(String[] args)
        {
            worker w = new worker("Bob", 80000.00);
            w = null; //removes memory eventually
            { worker w2 = new worker();
                w2.name = "Bobby";
            }//local scope - memory is removed eventually
            System.GC.Collect(); //use after above techniques to release the memory [GC stands for Garbage Collection]
            //automatic class garbage collector
            using (worker w3 = new worker())
            {
                w3.name = "bob";
            }//memory is removed immediately after use

                Console.ReadLine();
        }
    }
}
