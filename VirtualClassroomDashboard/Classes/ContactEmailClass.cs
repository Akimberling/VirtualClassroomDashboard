using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;

namespace VirtualClassroomDashboard.Classes
{
    public class ContactEmailClass
    {
        public static void sendEmail(string name, string email, string message)
        {
            
            string reciever = "virtualclassroomdashboard.info@gmail.com";
            SmtpClient smtpClient = new SmtpClient(reciever);
            smtpClient.UseDefaultCredentials = true;

            var credentials = new System.Net.NetworkCredential
            {
                UserName = reciever,
                Password = "JtdXcu3@1996$$"
            };

            smtpClient.Credentials = credentials;
            smtpClient.Host = "smtp.google.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            string emailSubject = "Questions, Comments, or Concerns From VCD Application. User: " + email;
            string body = "From: " + name + "\nEmail: " + email + "\n Message: " + message;

            try
            {
                smtpClient.Send(reciever, reciever, emailSubject, body);
            }
            catch (Exception ex)
            {

            }
        }

        public static void reponseEmail(string name, string email)
        {
            string reciever = "virtualclassroomdashboard.info@gmail.com";
            SmtpClient smtpClient = new SmtpClient(reciever);
            smtpClient.UseDefaultCredentials = true;

            var credentials = new System.Net.NetworkCredential
            {
                UserName = reciever,
                Password = "JtdXcu3@1996$$"
            };

            smtpClient.Credentials = credentials;
            smtpClient.Host = "smtp.google.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            string emailSubject = "Thank Your For Your Feedback - Virtual Classroom Dashboard";
            string body = "Hello " + name + ",\n\tWe appreciate your feedback and can assure you that one of our top priorities is customer service. If there is anything we can do to make your experience more gratifying please do not hesitate to contact us st " + reciever + ".\nThank you so much,\nVirtual Classroom Dashboard";

            try
            {
                smtpClient.Send(reciever, email, emailSubject, body);
            }
            catch(Exception ex)
            {

            }
        }

    }
}
