using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListClass
{
    class Program
    {
        static void printCount(SingleLinkListInt list)
        {
            Console.WriteLine("count : {0}",list.Count());
        }

        static void printContains(SingleLinkListInt list , int val)
        {
            Console.WriteLine("contains {0} : {1}", val , list.Contains(val));
        }

        static void Main(string[] args)
        {
            checkAddandCount();

            checkRemove();

            Console.ReadLine();
        }

        private static void checkRemove()
        {
            Console.WriteLine("\ncheck Remove ****** \n");

            SingleLinkListInt list = new SingleLinkListInt();
            list.Add(1);
            list.Remove(1);
            list.DebugPrint();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(3);
            list.DebugPrint();


        }

        private static void checkAddandCount()
        {
            Console.WriteLine("\ncheck Add and Count ****** \n");
            SingleLinkListInt list = new SingleLinkListInt();
            list.DebugPrint();
            printCount(list);
            printContains(list, 2);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(2);
            list.DebugPrint();
            printContains(list, 2);
            printCount(list);
        }
    }
}
