using System.Net;
using System.Net.Mail;

namespace MapOfTheProblematque.Utilities
{
    public class Email
    {
        public string To { get; set; }
        public string CC { get; set; } = "";
        public string Subject { get; set; }
        public string Body { get; set; }

        public Email(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
         public Email(string to, string subject, string body, string cc)
        {
            To = to;
            Subject = subject;
            Body = body;
            CC = cc;
        }

        public bool Send()
        {
            bool isSent = false;
            var message = new MailMessage();
            message.From= new MailAddress("plunderer9955@gmail.com");
            message.To.Add(new MailAddress(To));
            if (!string.IsNullOrWhiteSpace(CC))
            {
                message.CC.Add(new MailAddress(CC));
            }
            message.Subject = Subject;
            message.Body = Body;
            message.IsBodyHtml = true;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("plunderer9955@gmail.com", "tvcv gixz tfat vgfg")
            };
            try
            {
                smtp.Send(message);
                isSent = true;
            }
            catch (Exception ex)
            {

                isSent = false;
            }



            return isSent;
        }


    }
}
