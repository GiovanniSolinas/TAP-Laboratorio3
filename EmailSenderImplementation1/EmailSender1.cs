using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSenderInterfaces;

namespace EmailSenderImplementation1
{
    public class EmailSenderImplementationOne : IEmailSender
    {
        public bool SendEmail(string to, string body)
        {
            if (to != null && body != null)
            {
                Console.WriteLine("IMPLEMENTAZIONE 1");
                Console.WriteLine($"Messaggio inviato a: {to}");
                Console.WriteLine($"Testo messaggio: {body}");
                return true;
            }
            return false;
        }
    }
}
