using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;


namespace NapierBankMessaging
{
    public class Email
    {
        public String EmailSender;
        public String EmailSubject;
        public String EmailText;

        //public String ParsedEmailText;

        // Constructor Declaration of Class
        public Email(String EmailSender, String EmailSubject, String EmailText)
        {
            this.EmailSender = EmailSender;
            this.EmailSubject = EmailSubject;
            this.EmailText = EmailText;
        }

        // Property 1
        public String GetEmailSender()
        {
            return EmailSender;
        }

        // Property 2
        public String GetEmailText()
        {
            return EmailText;
        }

        // Property 3
        public String GetEmailSubject()
        {
            return EmailSubject;
        }
        /*
        // Method 1
        public String ToString()
        {
            return ("Hi my name is " + this.GetName()
                    + ".\nMy breed, age and color are " + this.GetBreed()
                    + ", " + this.GetAge() + ", " + this.GetColor());
        }
        */

    
    }
}
