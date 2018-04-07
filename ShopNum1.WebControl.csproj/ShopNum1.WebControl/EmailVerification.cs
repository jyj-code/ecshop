using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class EmailVerification : BaseWebControl, ICallbackEventHandler
	{
		private string string_0 = "E-mailVerification.ascx";
		private Label label_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		public EmailVerification()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelEmail");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonEmail");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonSend");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			if (this.Page.Request.QueryString["email"] != null && this.Page.Request.QueryString["id"] != null)
			{
				this.string_1 = this.Page.Request.QueryString["email"].ToString();
				this.string_2 = this.Page.Request.QueryString["id"].ToString();
				this.label_0.Text = this.string_1;
				this.GetUrl(this.string_1);
			}
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			ShopSettings.GetValue("RegIsEmail");
			string value = ShopSettings.GetValue("RegIsActivationEmail");
			ShopSettings.GetValue("RegIsMMS");
			string value2 = ShopSettings.GetValue("Name");
			if (value == "1")
			{
				string text = Guid.NewGuid().ToString();
				RegIsActivationEmail regIsActivationEmail = new RegIsActivationEmail();
				regIsActivationEmail.Email = this.string_1;
				regIsActivationEmail.Name = this.string_2;
				regIsActivationEmail.link = string.Concat(new string[]
				{
					GetPageName.RetDomainUrl("MemberRegisterToMail"),
					"?code=",
					text,
					"&type=0&email=",
					regIsActivationEmail.Email,
					"&userID=",
					this.string_2
				});
				regIsActivationEmail.ShopName = value2;
				regIsActivationEmail.SysSendTime = DateTime.Now.ToString();
				string text2 = string.Empty;
				string strTitle = string.Empty;
				string emailTemplentGuid = "7790bcf5-f88a-46bd-8ead-959118481c02";
				string emailBody = string.Empty;
				new ShopNum1_Email_Action();
				text2 = "<p>尊敬的{$Name}：你已经在本站注册，这是您的用户名和邮箱地址，用户名：{$Name}，邮箱：{$Email}，请牢记。</p><p>\t接下来您只需通过点击以下链接进行验证。</p><p><a href={$CheckUrl} target=_blank>{$CheckUrl}</a>(如果无法点击，请复制到地址栏进行验证。)</p><p>\t感谢您对的{$ShopName}关注。</p><p>\t祝您购物愉快！&nbsp;</p><p>\t请勿回复{$ShopName}   {$SysSendTime}</p>";
				text2 = text2.Replace("{$Name}", regIsActivationEmail.Name);
				text2 = text2.Replace("{$Email}", regIsActivationEmail.Email);
				text2 = text2.Replace("{$CheckUrl}", regIsActivationEmail.link);
				text2 = text2.Replace("{$ShopName}", "ShopNum1多用户商城");
				text2 = text2.Replace("{$SysSendTime}", regIsActivationEmail.SysSendTime);
				strTitle = "ShopNum1多用户商城-注册时邮件提醒";
				emailBody = regIsActivationEmail.ChangeRegister(this.Page.Server.HtmlDecode(text2));
				this.SendMailForRegister(this.string_2, this.string_1, text, "", strTitle, emailTemplentGuid, emailBody);
			}
		}
		public void SendMailForRegister(string MemLoginID, string Email, string Emailkey, string Phone, string strTitle, string emailTemplentGuid, string emailBody)
		{
			ShopNum1_MemberEmailExec_Action shopNum1_MemberEmailExec_Action = (ShopNum1_MemberEmailExec_Action)LogicFactory.CreateShopNum1_MemberEmailExec_Action();
			int num = shopNum1_MemberEmailExec_Action.MemberEmailInsert(new ShopNum1_MemberEmailExec
			{
				ExtireTime = new DateTime?(DateTime.Now.AddHours(24.0)),
				Email = Email,
				Emailkey = Emailkey,
				Guid = new Guid?(Guid.NewGuid()),
				Isinvalid = new byte?(0),
				MemberID = MemLoginID,
				Phone = Phone,
				Type = 0
			});
			if (num > 0)
			{
				SendEmail sendEmail = new SendEmail();
				sendEmail.Emails(Email, MemLoginID, strTitle, emailTemplentGuid, emailBody);
				MessageBox.Show("发送成功，请前往登录邮箱");
			}
		}
		public void GetUrl(string email)
		{
			int num = Convert.ToInt32(email.LastIndexOf(".")) - Convert.ToInt32(email.LastIndexOf("@"));
			string b = email.Substring(email.LastIndexOf("@") + 1, num - 1);
			DataTable xmlDataTable = this.GetXmlDataTable();
			if (xmlDataTable != null && xmlDataTable.Rows.Count > 0)
			{
				for (int i = 0; i < xmlDataTable.Rows.Count; i++)
				{
					if (xmlDataTable.Rows[i]["sign"].ToString() == b)
					{
						if (xmlDataTable.Rows[i]["url"].ToString().Contains("http://") || xmlDataTable.Rows[i]["url"].ToString().Contains("https://"))
						{
							this.linkButton_0.PostBackUrl = xmlDataTable.Rows[i]["url"].ToString();
						}
						else
						{
							this.linkButton_0.PostBackUrl = "http://" + xmlDataTable.Rows[i]["url"].ToString();
						}
					}
				}
			}
		}
		public DataTable GetXmlDataTable()
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.Page.Server.MapPath("~/Settings/email.xml"));
			DataTable result;
			if (dataSet == null || dataSet.Tables.Count == 0)
			{
				result = null;
			}
			else
			{
				result = dataSet.Tables[0];
			}
			return result;
		}
		public string GetCallbackResult()
		{
			throw new NotImplementedException();
		}
		public void RaiseCallbackEvent(string eventArgument)
		{
			throw new NotImplementedException();
		}
	}
}
