using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
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

namespace SMTP_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MailAddress FromAdress { get; set; }

        public MailAddress ToAddress { get; set; }

        public SmtpClient SmtpClient { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            FromAdress = new MailAddress("memmedovhuseyn667@gmail.com", "huseyn mammadov");

            SmtpClient = new SmtpClient("smtp.gmail.com", 587);

            SmtpClient.Credentials = new NetworkCredential("memmedovhuseyn667@gmail.com", "zxzxdgrslfdbujqv");
            SmtpClient.EnableSsl = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ToAddress = new MailAddress(Send_tb.Text);
            var subject = Subject_tb.Text;
            var body = Body_tb.Text;
            Task.Run(() =>
            {
                MailMessage mailMessage = new MailMessage(FromAdress, ToAddress);
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                SmtpClient.Send(mailMessage);
                MessageBox.Show($"Message sent to {ToAddress}"!);


                Dispatcher.BeginInvoke(() =>
                {
                    Subject_tb.Clear();
                    Body_tb.Clear();
                    Send_tb.Clear();
                });
            });
        }
    }
}
