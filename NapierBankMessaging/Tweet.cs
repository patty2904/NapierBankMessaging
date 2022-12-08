using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankMessaging
{
    public class Tweet
    {
        public String TweetSender;
        public String TweetText;

        //public String ParsedTweetText;

        // Constructor Declaration of Class
        public Tweet(String TweetSender, String TweetText)
        {
            this.TweetSender = TweetSender;
            this.TweetText = TweetText;
        }

        // Property 1
        public String GetTweetSender()
        {
            return TweetSender;
        }

        // Property 2
        public String GetTweetText()
        {
            return TweetText;
        }
    }
}
