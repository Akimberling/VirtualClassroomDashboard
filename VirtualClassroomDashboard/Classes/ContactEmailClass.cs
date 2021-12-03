using System;
using System.Net.Mail;
using System.Net;
namespace VirtualClassroomDashboard.Classes
{
    public class ContactEmailClass
    {
        public static void sendEmail(string name, string email, string message)
        {

            MailAddress To = new MailAddress("virtualclassroomdashboard.info@gmail.com");
            MailAddress From = new MailAddress(email);

            MailMessage Body = new MailMessage(From, To);
            Body.Subject = "Questions, Comments, or Concerns From VCD Application. User: " + email;
            Body.Body = "From: " + name + "\nEmail: " + email + "\n Message: " + message;

            SmtpClient client = new SmtpClient("smtp.google.com", 587)
            {
                Credentials = new NetworkCredential("virtualclassroomdashboard.info@gmail.com", "JtdXcu3@1996$$"),
                EnableSsl = true
            };


            try
            {
                client.Send(Body);
            }
            catch(SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void reponseEmail(string name, string email)
        {

            MailAddress To = new MailAddress("virtualclassroomdashboard.info@gmail.com");
            MailAddress From = new MailAddress(email);

            MailMessage Body = new MailMessage(To, From);
            Body.Subject = "Questions, Comments, or Concerns From VCD Application. User: " + email;
            Body.Body = "Hello " + name + ",\n\tWe appreciate your feedback and can assure you that one of our top priorities is customer service. If there is anything we can do to make your experience more gratifying please do not hesitate to contact us at virtualclassroomdashboard.info@gmail.com.\nThank you so much,\nVirtual Classroom Dashboard";

            SmtpClient client = new SmtpClient("smtp.google.com", 587)
            {
                Credentials = new NetworkCredential("virtualclassroomdashboard.info@gmail.com", "JtdXcu3@1996$$"),
                EnableSsl = true
            };


            try
            {
                client.Send(Body);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //string reciever = "virtualclassroomdashboard.info@gmail.com";
            //SmtpClient smtpClient = new SmtpClient(reciever);
            //smtpClient.UseDefaultCredentials = true;

            //var credentials = new System.Net.NetworkCredential
            //{
            //    UserName = reciever,
            //    Password = "JtdXcu3@1996$$"
            //};

            //smtpClient.Credentials = credentials;
            //smtpClient.Host = "smtp.google.com";
            //smtpClient.Port = 465;
            //smtpClient.EnableSsl = true;
            //string emailSubject = "Thank Your For Your Feedback - Virtual Classroom Dashboard";
            //string body = "Hello " + name + ",\n\tWe appreciate your feedback and can assure you that one of our top priorities is customer service. If there is anything we can do to make your experience more gratifying please do not hesitate to contact us st " + reciever + ".\nThank you so much,\nVirtual Classroom Dashboard";

            //try
            //{
            //    smtpClient.Send(reciever, email, emailSubject, body);
            //}
            //catch(Exception ex)
            //{

            //}
        }

    }
}
