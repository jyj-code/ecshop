using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Web;
namespace ShopNum1.Email
{
	public class SendEmail
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private string string_5 = string.Empty;
		private string string_6 = string.Empty;
		public int Emails(string email, string MemLoginID, string emailTitle, string emailTemplentGuid, string emailBody)
		{
			email = email.Trim();
			int result;
			if (email == "" || email == null)
			{
				result = 0;
			}
			else
			{
				NetMail netMail = new NetMail(email, HttpContext.Current.Server.HtmlDecode(emailBody), emailTitle);
				ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
				if (!netMail.Send())
				{
					ShopNum1_EmailGroupSend emailGroupSend = this.Add(MemLoginID, email, 0, emailBody, emailTemplentGuid, emailTitle);
					shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
					result = 0;
				}
				else
				{
					ShopNum1_EmailGroupSend emailGroupSend = this.Add(MemLoginID, email, 2, emailBody, emailTemplentGuid, emailTitle);
					shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
					result = 1;
				}
			}
			return result;
		}
		protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string scont, string emailTemplentGuid, string emailTitle)
		{
			return new ShopNum1_EmailGroupSend
			{
				Guid = Guid.NewGuid(),
				EmailTitle = emailTitle,
				CreateTime = DateTime.Now,
				EmailGuid = new Guid(emailTemplentGuid),
				SendObjectEmail = scont,
				SendObject = memLoginID + "-" + email,
				State = state
			};
		}
	}
}
