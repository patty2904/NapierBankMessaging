using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankMessaging
{
     public class SMS
    {
        public String SMSSender;
        public String SMSText;

        //public String ParsedSMSText;

        // Constructor Declaration of Class
        public SMS(String SMSSender, String SMSText)
        {
            this.SMSSender = SMSSender;
            this.SMSText = SMSText;
        }

        // Property 1
        public String GetSMSSender()
        {
            return SMSSender;
        }

        // Property 2
        public String GetSMSText()
        {
            return SMSText;
        }

        //Function
        //loop through csv file at line 1, if match
    }
}
