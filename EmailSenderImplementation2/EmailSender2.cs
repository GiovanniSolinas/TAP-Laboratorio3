using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSenderInterfaces;

namespace EmailSenderImplementation2
{
    public class EmailSenderImplementationTwo : IEmailSender
    {
        public bool SendEmail(string to, string body)
        {
            if (to != null && body != null)
            {
                Console.WriteLine("IMPLEMENTAZIONE 2");
                Console.WriteLine($"Messaggio inviato a: {to}");
                Console.WriteLine($"Testo messaggio: {body}");
                return true;
            }
            return false;
        }
    }
}
