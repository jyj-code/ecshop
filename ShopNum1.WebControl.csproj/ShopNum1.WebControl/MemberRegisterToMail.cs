using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class MemberRegisterToMail : BaseWebControl, ICallbackEventHandler
	{
		private string string_0 = "MemberRegisterToMail.ascx";
		public MemberRegisterToMail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (!this.Page.IsPostBack)
			{
				this.YZemail();
			}
			if (this.Page.Request.QueryString["code"] != null && this.Page.Request.QueryString["userID"] != null && this.Page.Request.QueryString["email"] != null)
			{
				this.method_0(this.Page.Request.QueryString["code"].ToString(), this.Page.Request.QueryString["userID"].ToString(), this.Page.Request.QueryString["email"].ToString());
			}
		}
		public void YZemail()
		{
			ShopNum1_MemberEmailExec_Action shopNum1_MemberEmailExec_Action = (ShopNum1_MemberEmailExec_Action)LogicFactory.CreateShopNum1_MemberEmailExec_Action();
			DataTable dataTable = shopNum1_MemberEmailExec_Action.CheckLink(this.Page.Request.QueryString["code"].ToString(), this.Page.Request.QueryString["type"].ToString());
			if (dataTable.Rows.Count <= 0)
			{
				this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "memlogin", "window.location.href='" + GetPageName.RetDomainUrl("MemberRegisterSuccess") + "?type=0'", true);
			}
		}
		private void method_0(string string_1, string string_2, string string_3)
		{
			ShopNum1_MemberEmailExec_Action shopNum1_MemberEmailExec_Action = (ShopNum1_MemberEmailExec_Action)LogicFactory.CreateShopNum1_MemberEmailExec_Action();
			int num = shopNum1_MemberEmailExec_Action.MemberEmailExec(string_1, "0");
			if (num > 0)
			{
				ShopNum1.Common.Common.UpdateInfo("   isemailactivation=1", "ShopNum1_Member", " and memloginid='" + string_2 + "'");
				string value = ShopSettings.GetValue("RegIsEmail");
				if (value == "1")
				{
					string value2 = ShopSettings.GetValue("Name");
					string text = "4a12724c-5154-4928-b867-d5bd180e80e6";
					string text2 = string.Empty;
					string strTitle = string.Empty;
					ShopNum1_Email_Action shopNum1_Email_Action = new ShopNum1_Email_Action();
					DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text + "'", 0);
					if (editInfo.Rows.Count > 0)
					{
						text2 = editInfo.Rows[0]["Remark"].ToString();
						strTitle = editInfo.Rows[0]["Title"].ToString();
					}
					text2 = text2.Replace("{$Name}", string_2);
					text2 = text2.Replace("{$ShopName}", value2);
					text2 = text2.Replace("{$SysSendTime}", DateTime.Now.ToString());
					this.SendMailForRegister(string_2, string_3, Guid.NewGuid().ToString(), "", strTitle, text, text2);
				}
				this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "memlogin", "window.location.href='" + GetPageName.RetDomainUrl("MemberRegisterSuccess") + "?type=1'", true);
			}
			else
			{
				this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "memlogin", "window.location.href='" + GetPageName.RetDomainUrl("MemberRegisterSuccess") + "?type=0'", true);
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
			}
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
