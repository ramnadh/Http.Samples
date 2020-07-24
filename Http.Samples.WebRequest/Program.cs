using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.Samples.WebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            QickrNavigator navigator = new QickrNavigator();
            navigator.GetUS_BankEntry();

            Console.ReadLine();
        }
    }
}
