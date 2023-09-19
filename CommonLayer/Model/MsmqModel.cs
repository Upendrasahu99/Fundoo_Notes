using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer.Model
{
    public class MsmqModel
    {
        private string email;
        public MsmqModel(string email)
        {
            this.email = email;
        }
        MessageQueue messageQueue = new MessageQueue();

        public void MessageSender(string token)
        {
            messageQueue.Path = @".\private$\MyPrivateQueue";
            if (!MessageQueue.Exists(messageQueue.Path))
            {
                MessageQueue.Create(messageQueue.Path);
            }

            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string)});
            messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;

            messageQueue.Send(token);
            messageQueue.BeginReceive();
            messageQueue.Close();
        }

        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                var msg = messageQueue.EndReceive(e.AsyncResult);
                string subject = "Fundoo Notes Reset Password JWT Token";
                string body = msg.Body.ToString();

                var SMTP = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("usahu898@gmail.com", "qahsjtcjpfvfxajl"),
                    EnableSsl = true
                };

                SMTP.Send("usahu898@gmail.com", email, subject, body);
                messageQueue.BeginReceive();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
