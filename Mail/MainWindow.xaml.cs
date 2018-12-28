﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace Mail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

          

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_send_Click(object sender, RoutedEventArgs e)
        {


            try
            {

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
              //  client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("dmetrosk2@gmail.com","metro17008");
                
                MailMessage msg = new MailMessage("DmetroSK", txt_to.Text, txt_sub.Text, txt_msg.Text);
               
               
                client.Send(msg);
                MessageBox.Show("Message Sent Successfully");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void Btn_cls_Click(object sender, RoutedEventArgs e)
        {
            txt_to.Text = "";
            txt_cc.Text = "";
            txt_sub.Text = "";
            txt_msg.Text = "";
        }
    }
}
