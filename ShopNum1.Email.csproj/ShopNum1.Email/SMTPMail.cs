using System;
using System.Net;
using System.Net.Mail;
using System.Text;
namespace ShopNum1.Email
{
	public class SMTPMail
	{
		private string string_0;
		private string string_1;
		private string string_2;
		private string string_3;
		private string string_4;
		private string string_5;
		public string SmtpServer
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		public string SmtpUser
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public string SmtpPwd
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public string UserEmail
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public string Title
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public string Body
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public bool SendEmail()
		{
			bool result;
			try
			{
				using (MailMessage mailMessage = new MailMessage(this.string_1, this.string_3))
				{
					mailMessage.Subject = this.string_4;
					mailMessage.Body = this.string_5;
					mailMessage.SubjectEncoding = Encoding.UTF8;
					mailMessage.BodyEncoding = Encoding.UTF8;
					mailMessage.IsBodyHtml = true;
					mailMessage.Priority = MailPriority.Normal;
					new SmtpClient(this.string_0)
					{
						UseDefaultCredentials = false,
						DeliveryMethod = SmtpDeliveryMethod.Network,
						Credentials = new NetworkCredential(this.string_1, this.string_2)
					}.Send(mailMessage);
					result = true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
	}
}
