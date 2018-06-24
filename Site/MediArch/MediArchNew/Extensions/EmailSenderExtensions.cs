using System.Threading.Tasks;

namespace MediArch.Services
{
    public static class EmailSenderExtensions
    {
        private const string ConfirmerEmail = "mediarch.noreply@gmail.com";

        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string userName, string link)
        {
            string MessageSunject = "Welcome to MediArch!";
            string MessageBody = "Hey, " + userName + "\r\n\r\n" +
                "Thank you for registering on our website!" + "\r\n" +
                "Hope you will have a pleasant experience here!" + "\r\n" +
                "For further information, contact us!/n " + "\r\n" +
                "Have a wonderful day! " + "\r\n\r\n\r\n" +
                "Best Regards, " + "\r\n" +
                "MediArch Staff" + "\r\n";// +
           /* "Please confirm your account by clicking this link: <a href='{"+HtmlEncoder.Default.Encode(link)+"}'>link</a>";*/
            return emailSender.SendEmailAsync(email, MessageSunject, MessageBody);
        }

        public static Task SendEmailNewConsultAsync(this IEmailSender emailSender, string patientEmail, string patientName, string doctorName)
        {
            string MessageSunject = "You got a new Consult!";
            string MessageBody = "Hey, " + patientName + "\r\n\r\n" +
                "You have a new Consult added by " + doctorName + "!\r\n" +
                "You can go and check it out!" + "\r\n" +
                "\r\n" +
                "Best Regards, " + "\r\n" +
                "MediArch Staff" + "\r\n";
            return emailSender.SendEmailAsync(patientEmail, MessageSunject, MessageBody);
        }

        public static Task SendEmailInactiveAccountAsync(this IEmailSender emailSender, string userEmail, string userFirstName)
        {
            string MessageSunject = "Inactive Account";
            string MessageBody = "Hey, " + userFirstName + "\r\n\r\n" +
                "Your account was set on inactive, due to some issues!\r\n" +
                "You can get in contact with our staff to solve this situation.\r\n" +
                "\r\n\r\n\r\n" +
                "Best Regards, " + "\r\n" +
                "MediArch Staff" + "\r\n";
            return emailSender.SendEmailAsync(userEmail, MessageSunject, MessageBody);
        }

        public static Task SendEmailActiveAccountAsync(this IEmailSender emailSender, string userEmail, string userFirstName)
        {
            string MessageSunject = "Active Account";
            string MessageBody = "Hey, " + userFirstName + "\r\n\r\n" +
                "Your account was just set on active!\r\n" +
                "\r\n" +
                "\r\n\r\n\r\n" +
                "Best Regards, " + "\r\n" +
                "MediArch Staff" + "\r\n";
            return emailSender.SendEmailAsync(userEmail, MessageSunject, MessageBody);
        }

    }
}
