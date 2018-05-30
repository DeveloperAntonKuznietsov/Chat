using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static ChattingService server;

        static void Main(string[] args)
        {
            server = new ChattingService();

            using(ServiceHost host = new ServiceHost(server))
            {
                host.Open();


                Console.WriteLine("Server started...");
                Console.ReadLine();
           
            }
        }
    }
}
