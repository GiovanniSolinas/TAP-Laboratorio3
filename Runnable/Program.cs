using EmailSenderInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TinyDependencyInjectionContainer;

namespace Runnable
{
    class Program
    {
        static void Main(string[] args)
        {
            var emaiSender = new InterfaceResolver("TDIC_Configuration.txt").Instantiate<IEmailSender>();
            emaiSender.SendEmail("pippo@gmail.it", "ciao pippo");
            Console.ReadLine();
        }
    }
}
