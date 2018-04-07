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
	public class MemberRegisterWelcome : BaseWebControl, ICallbackEventHandler
	{
		private string string_0 = "MemberRegisterWelcome.ascx";
		private Label label_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		public MemberRegisterWelcome()
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
					"&type=0&userID=",
					this.string_2
				});
				regIsActivationEmail.ShopName = value2;
				regIsActivationEmail.SysSendTime = DateTime.Now.ToString();
				string s = string.Empty;
				string strTitle = string.Empty;
				string text2 = "27815f7e-8f56-4f6d-afcb-edb099f16f60";
				string emailBody = string.Empty;
				ShopNum1_Email_Action shopNum1_Email_Action = new ShopNum1_Email_Action();
				DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
				if (editInfo.Rows.Count > 0)
				{
					s = editInfo.Rows[0]["Remark"].ToString();
					strTitle = editInfo.Rows[0]["Title"].ToString();
				}
				emailBody = regIsActivationEmail.ChangeRegister(this.Page.Server.HtmlDecode(s));
				this.SendMailForRegister(this.string_2, this.string_1, text, "", strTitle, text2, emailBody);
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
