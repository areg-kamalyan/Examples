using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    delegate void PrintDel(string data);

    interface IEventsEX
    {
        public event PrintDel PrintEv;
    }

    internal class EventsEX
    {

        public static void Run()
        {
            var ex = new PrintMsg();

            ex.printDel+= ex.Print;
            ex.printDel.Invoke("delegate test");

            ex.PrintEv += ex.Print;
            ex.PrintClick();

        }
    }

    internal class PrintMsg : IEventsEX
    {
        public PrintDel? printDel;
        public event PrintDel PrintEv;

        public void PrintClick()
        {
            PrintEv.Invoke("event test");
        }

        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
