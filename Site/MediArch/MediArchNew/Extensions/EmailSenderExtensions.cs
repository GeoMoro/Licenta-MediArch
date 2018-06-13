using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MediArch.Services;

namespace MediArch.Services
{
    public static class EmailSenderExtensions
    {
        private const string ConfirmerEmail = "mediarch.noreply@gmail.com";

        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            string MessageSunject = "Welcome to MediArch";
            string MessageBody = "Hey, " + email + "\r\n\r\n" +
                "Thank you for registering on our website!" + "\r\n" +
                "Hope you will have an pleasant experience here!" + "\r\n" +
                "For further information, contact us!/n " + "\r\n" +
                "Have a wonderful day! " + "\r\n\r\n\r\n" +
                "Best Regards, " + "\r\n" +
                "MeriArch Staff" + "\r\n";// +
           /* "Please confirm your account by clicking this link: <a href='{"+HtmlEncoder.Default.Encode(link)+"}'>link</a>";*/
            return emailSender.SendEmailAsync(email, MessageSunject, MessageBody);
        }
        
       
    }
}
