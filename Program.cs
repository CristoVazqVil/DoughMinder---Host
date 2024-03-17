using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DoughMinder___Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Clases.Servicio)))
            {
                host.Open();
                Console.WriteLine("DoughMinder is running");

                Console.ReadLine();

            }

        }
    }
}
