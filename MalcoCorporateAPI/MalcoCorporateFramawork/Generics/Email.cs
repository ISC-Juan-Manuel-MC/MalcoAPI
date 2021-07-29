using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;

namespace MalcoCorporateFramawork.Generics
{
    public class Email
    {

        public class Configuration
        {
            private readonly string Server = null;
            private readonly int Port = 0;
            private readonly bool SecureConnection = false;
            private readonly string Email = null;
            private readonly string EmailPassword = null;
            private readonly string EmailAlias = null;

            public Configuration(string server, int port, bool secureConnection, string email, string emailPassword, string emailAlias)
            {
                Server = server;
                Port = port;
                SecureConnection = secureConnection;
                Email = email;
                EmailPassword = emailPassword;
                EmailAlias = emailAlias;
            }

            public string GetServer() { return this.Server; }
            public int GetPort() { return this.Port; }
            public bool GetSecureConnection() { return this.SecureConnection; }
            public string GetEmail() { return this.Email; }
            public string GetEmailPassword() { return this.EmailPassword; }
            public string GetEmailAlias() { return this.EmailAlias; }
        }

        private readonly Configuration EmailConfiguration = null;
        private readonly MimeMessage Message = null;

        public Email(Configuration Config)
        {
            this.EmailConfiguration = Config;
            this.Message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(this.EmailConfiguration.GetEmailAlias(), 
                                                     this.EmailConfiguration.GetEmail());
            Message.From.Add(from);
        }

        private void SendEmail(string ReceptorEmailAlias, string ReceptorEmail)
        {
            MailboxAddress to = new MailboxAddress(ReceptorEmailAlias, ReceptorEmail);
            Message.To.Add(to);

            SmtpClient client = new SmtpClient();
            client.Connect(this.EmailConfiguration.GetServer(),
                           this.EmailConfiguration.GetPort(),
                           this.EmailConfiguration.GetSecureConnection());

            client.Authenticate(this.EmailConfiguration.GetEmail(), 
                                this.EmailConfiguration.GetEmailPassword());

            client.Send(this.Message);
            client.Disconnect(true);
            client.Dispose();
        }

        private void SetSubject(string Subject)
        {
            Message.Subject = Subject;
        }

        private void SetBody(string Body,bool IsHTML=false)
        {
            BodyBuilder bodyBuilder = new BodyBuilder();
            if (IsHTML)
            {
                bodyBuilder.HtmlBody = Body;
            }
            else
            {
                bodyBuilder.TextBody = Body;
            }

            this.Message.Body = bodyBuilder.ToMessageBody();
        }      

        public void SendEmail(string ReceptorEmailAlias, string ReceptorEmail, string Subject, string Body)
        {
            SetBody(Body);
            SetSubject(Subject);
            SendEmail(ReceptorEmailAlias,ReceptorEmail);
        }




        private const string EMAIL_WELCOME_SUBJECT = "Bienvenido a la comunidad Malco";
        private const string EMAIL_RECOVER_SUBJECT = "Recuperación de contraseña";
        private const string EMAIL_PASSWORD_CHANGED_SUBJECT = "Cambio de contraseña";

        private static void SendPreConfigureEmail(Configuration Config, string ReceptorEmailAlias, string ReceptorEmail, string Subject, string Body)
        {
            Email WelcomeEmail = new Email(Config);
            WelcomeEmail.SetSubject(Subject);
            WelcomeEmail.SetBody(Body, true);
            WelcomeEmail.SendEmail(ReceptorEmailAlias, ReceptorEmail);
        }

        public static void SendWelcomeEmail(Configuration Config, string ReceptorEmailAlias, string ReceptorEmail)
        {
            string Body = Properties.Resources.Welcome;
            Body = GenericFunctions.ReplaceText(Body, "#PersonName#", ReceptorEmailAlias);
            SendPreConfigureEmail(Config, ReceptorEmailAlias, ReceptorEmail, EMAIL_WELCOME_SUBJECT, Body);
        }

        public static void SendRecoverEmail(Configuration Config, string ReceptorEmailAlias, string ReceptorEmail)
        {
            string Body = Properties.Resources.Recover;
            Body = GenericFunctions.ReplaceText(Body, "#VerificationCode#", "1234");
            SendPreConfigureEmail(Config, ReceptorEmailAlias, ReceptorEmail, EMAIL_RECOVER_SUBJECT, Body);
        }

        public static void SendPasswordNotificationEmail(Configuration Config, string ReceptorEmailAlias, string ReceptorEmail)
        {
            string Body = Properties.Resources.PasswordNotification;
            SendPreConfigureEmail(Config, ReceptorEmailAlias, ReceptorEmail, EMAIL_PASSWORD_CHANGED_SUBJECT, Body);
        }

    }
}
