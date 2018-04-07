using ShopNum1.Common;
using System;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class NetMail
	{
		[CompilerGenerated]
		private string string_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string Subject
		{
			get;
			set;
		}
		public string Body
		{
			get;
			set;
		}
		public string RecipientEmail
		{
			get;
			set;
		}
		protected SmtpClient Mysmtp
		{
			get
			{
				SmtpClient smtpClient = new SmtpClient(ShopSettings.GetValue("SMTP"), Convert.ToInt32(ShopSettings.GetValue("ServerPort")));
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials = new NetworkCredential(ShopSettings.GetValue("EmailAccount"), Encryption.Decrypt(ShopSettings.GetValue("EmailPassword")));
				if (ShopSettings.GetValue("EnableSSL") == "1")
				{
					smtpClient.EnableSsl = true;
				}
				return smtpClient;
			}
		}
		public NetMail()
		{
		}
		public NetMail(string RecipientEmail, string body, string subject)
		{
			this.RecipientEmail = RecipientEmail;
			this.Body = body;
			this.Subject = subject;
		}
		public bool Send()
		{
			bool result;
			try
			{
				MailMessage mailMessage = new MailMessage(ShopSettings.GetValue("EmailAccount"), this.RecipientEmail);
				mailMessage.Subject = this.Subject;
				mailMessage.Body = this.Body;
				mailMessage.Priority = MailPriority.Normal;
				mailMessage.IsBodyHtml = true;
				this.Mysmtp.Send(mailMessage);
				result = true;
			}
			catch (SmtpException)
			{
				result = false;
			}
			return result;
		}
	}
}
