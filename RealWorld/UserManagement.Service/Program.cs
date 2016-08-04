using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace UserManagement.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start UserManagement service...");
            var server = new UserManagementServiceServer();
            server.Start();

            Console.ReadLine();
        }
    }
}
