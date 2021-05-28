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
            string reciever = "info@virtualclassroomdashboard.azurewebsites.net";
            SmtpClient smtpClient = new SmtpClient(reciever);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            string emailSubject = "Questions, Comments, or Concerns";
            string body = "From: " + name + "\nEmail: " + email + "\n Message: " + message;

            try
            {
                smtpClient.Send(email, reciever, emailSubject, body);
            }
            catch (Exception ex)
            {

            }
        }

        public static void reponseEmail(string name, string email)
        {
            string sender = "info@virtualclassroomdashboard.azurewebsites.net";
            SmtpClient smtpClient = new SmtpClient(sender);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            string emailSubject = "Thank Your For Your Feedback - Virtual Classroom Dashboard";
            string body = "Hello " + name + ",\n\tWe appreciate your feedback and can assure you that one of our top priorities is customer service. If there is anything we can do to make your experience more gratifying please do not hesitate to contact us st " + sender + ".\nThank you so much,\nVirtual Classroom Dashboard";

            try
            {
                smtpClient.Send(sender, email, emailSubject, body);
            }
            catch(Exception ex)
            {

            }
        }

    }
}
