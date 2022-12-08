using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;


namespace NapierBankMessaging
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ExpandAbbreviations(String message)
        {
            Regex re = new Regex(@"\$(\w+)\$", RegexOptions.Compiled);

            String line = "";
            char split = ',';
            //string[] seperatedString = message.Split(' ');
            var list = new Dictionary<string, string>();
            String path = @"C:\Users\Patrycja\Desktop\textwords.csv";

            StreamReader sr = new StreamReader(path);
            while ((line = sr.ReadLine()) != null)
            {
                String[] abbreviatonFile = line.Split(split);

                //load the read data into the dictionary
                list.Add(abbreviatonFile[0], abbreviatonFile[1]);
            }

            //var output = new StringBuilder(message);

            MessageBox.Show(message);

            //“Saw your message ROFL”
            //“Saw your message ROFL<Rolls on the floor laughing>"

            //var output = new StringBuilder(fruitString);

            var output = new StringBuilder(message);

            foreach (var kvp in list)
                output.Replace(kvp.Key, kvp.Value);

            var result = output.ToString();

            //var result = string.Join(" ", message.Split(' ').Select(i => list.ContainsKey(i) ? list[i] : i));

            MessageBox.Show(result);


            return result;
        }
    

        public string RandomDigits()
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 9; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        public MainWindow()
        {
            InitializeComponent();


        }

        private void addMessage_Click(object sender, RoutedEventArgs e)
        {
            int numericValue = 123;

            //Email
            if (MessageID.Text.Contains("@") && MessageID.Text.Contains("."))
            {
                if (MessageBody.Text.Length < 1029 && MessageBody.Text.Length > 0)
                {
                    Email email = new Email(MessageID.Text, MessageBody.Text.Substring(0, 20), MessageBody.Text.Substring(20));
                    string jsonString = JsonConvert.SerializeObject(email);
                    ProcessedMessageID.Text = "E" + RandomDigits();
                    ProcessedMessageBody.Text = jsonString;
                }
                else
                {
                    MessageBox.Show("The message is out of range. Make sure it is at least 1 character long, and less than 1028 characters long.", "Invalid Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            //Tweet
            else if (MessageID.Text.StartsWith("@"))
            {
                if (MessageID.Text.Length < 16 && MessageID.Text.Length > 0 && MessageBody.Text.Length < 141 && MessageBody.Text.Length > 0)
                {
                    Tweet tweet = new Tweet(MessageID.Text, MessageBody.Text);
                    string jsonString = JsonConvert.SerializeObject(tweet);
                    ProcessedMessageID.Text = "T" + RandomDigits();
                    ProcessedMessageBody.Text = jsonString;
                }
                else
                {
                    MessageBox.Show("The message is out of range. Make sure it is at least 1 character long, and less than 140 characters long.", "Invalid Message", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }

            //SMS
            else if (MessageID.Text.Contains("+") && int.TryParse(MessageID.Text, out numericValue))
            {
                if (MessageBody.Text.Length < 141 && MessageBody.Text.Length > 0)
                {
                    SMS sms = new SMS(MessageID.Text, ExpandAbbreviations(MessageBody.Text));
                    string jsonString = JsonConvert.SerializeObject(sms);
                    ProcessedMessageID.Text = "S" + RandomDigits();
                    ProcessedMessageBody.Text = jsonString;
                }
                else
                {
                    MessageBox.Show("The message is out of range. Make sure it is at least 1 character long, and less than 140 characters long.", "Invalid Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("The message type is invalid", "Invalid Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }



    }
}
