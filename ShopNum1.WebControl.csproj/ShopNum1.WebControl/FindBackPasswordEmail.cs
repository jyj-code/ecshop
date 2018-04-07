using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class FindBackPasswordEmail : BaseWebControl, ICallbackEventHandler
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private string string_5 = string.Empty;
		private string string_6 = string.Empty;
		private string string_7 = string.Empty;
		private string string_8 = "FindBackPasswordEmail.ascx";
		private string string_9;
		public FindBackPasswordEmail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_8;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			string text = "function existemail(inputcontrol) {\n";
			text += "var context = document.getElementById(\"spanEmail\");\n";
			text += "var arg = \"ExistEmail|\" + inputcontrol.value;\n";
			text += "if(inputcontrol.value != \"\") {\n";
			text += "var reg = new RegExp(\"\\\\w+([-+.']\\\\w+)*@\\\\w+([-.]\\\\w+)*\\\\.\\\\w+([-.]\\\\w+)*\");\n";
			text += "if(reg.test(inputcontrol.value)) {\n";
			text += "context.innerHTML = \"数据查询中..\"; ";
			text = text + this.Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context") + "; }\n";
			text += "else { context.innerHTML = \"电子邮箱格式不正确\"; }\n}\n";
			text += "else { context.innerHTML = \"电子邮箱不能为空\"; }\n}\n";
			this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "checkEmail", text, true);
			if (this.Page.IsPostBack && this.Page.Request.Form["__EVENTTARGET"] == "ButtonFindPwdSubmit")
			{
				this.ButtonConfirm_Click(null, null);
			}
		}
		public string ExistEmail(string email)
		{
			IShopNum1_Member_Action shopNum1_Member_Action = LogicFactory.CreateShopNum1_Member_Action();
			int num = shopNum1_Member_Action.CheckmemEmail(email);
			string result;
			if (num > 0)
			{
				result = "1";
			}
			else
			{
				result = "0";
			}
			return result;
		}
		public void ButtonConfirm_Click(object sender, EventArgs e)
		{
			this.Page.Server.HtmlDecode(ShopSettings.GetValue("Name"));
			string text = this.Page.Request.Form["TextBoxEmail"];
			string arg_50_0 = this.Page.Request.Form["TextBoxPwd"];
			IShopNum1_Member_Action shopNum1_Member_Action = LogicFactory.CreateShopNum1_Member_Action();
			IShopNum1_MemberPwd_Action shopNum1_MemberPwd_Action = LogicFactory.CreateShopNum1_MemberPwd_Action();
			DataTable dataTable = shopNum1_Member_Action.MemberFindPwdPro(text);
			if (dataTable != null && dataTable.Rows.Count != 0 && dataTable.Rows.Count > 0)
			{
				this.GetEmailSetting();
				NetMail netMail = new NetMail();
				string text2 = string.Empty;
				text2 = dataTable.Rows[0]["MemLoginID"].ToString();
				ShopNum1_MemberPwd shopNum1_MemberPwd = new ShopNum1_MemberPwd();
				shopNum1_MemberPwd.MemberID = text2;
				shopNum1_MemberPwd.pwd = "";
				shopNum1_MemberPwd.pwdkey = Encryption.GetMd5SecondHash(DateTime.Now.AddDays(1.0).ToString() + new Random().Next().ToString()).Substring(0, 8);
				shopNum1_MemberPwd.type = 0;
				shopNum1_MemberPwd.extireTime = DateTime.Now.AddDays(1.0);
				shopNum1_MemberPwd.Email = text;
				shopNum1_MemberPwd_Action.MemberPwdInsert(shopNum1_MemberPwd);
				netMail.RecipientEmail = text;
				PasswordEmailReset passwordEmailReset = new PasswordEmailReset();
				string text3 = ShopSettings.IsOverrideUrl ? ("FindPasswordOperate" + ShopSettings.overrideUrlName) : "FindPasswordOperate.aspx";
				passwordEmailReset.ChangePwdUrl = string.Concat(new string[]
				{
					"http://",
					ConfigurationManager.AppSettings["DoMain"].ToString(),
					"/",
					text3,
					"?type=0&key=",
					shopNum1_MemberPwd.pwdkey
				});
				passwordEmailReset.ShopName = ShopSettings.GetValue("Name");
				passwordEmailReset.SysSendTime = DateTime.Now.ToString();
				passwordEmailReset.ExtireTime = shopNum1_MemberPwd.extireTime.ToString();
				passwordEmailReset.MemloginID = text2;
				passwordEmailReset.Hour = "24";
				string s = string.Empty;
				ShopNum1_Email_Action shopNum1_Email_Action = new ShopNum1_Email_Action();
				DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'9d7b9b03-dfe5-4bd5-9eee-e0a1a86e347b'", 0);
				if (editInfo.Rows.Count > 0)
				{
					s = editInfo.Rows[0]["Remark"].ToString();
					this.string_7 = editInfo.Rows[0]["Title"].ToString();
				}
				netMail.Subject = this.string_7;
				netMail.Body = passwordEmailReset.ChangePasswordEmailReset(this.Page.Server.HtmlDecode(s));
				if (!netMail.Send())
				{
					ShopNum1_EmailGroupSend emailGroupSend = this.Add(text2, text, 0, netMail.Body);
					int num = shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
					if (num > 0)
					{
						MessageBox.Show("Send Email Error");
					}
				}
				else
				{
					ShopNum1_EmailGroupSend emailGroupSend = this.Add(text2, text, 2, netMail.Body);
					int num = shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
					if (ShopSettings.IsOverrideUrl)
					{
						this.Page.Response.Redirect("~/FindPasswordFinal.html?email=" + text + "&type=findPwd");
					}
					else
					{
						this.Page.Response.Redirect("~/FindPasswordFinal.aspx?email=" + text + "&type=findPwd");
					}
				}
			}
		}
		protected void GetEmailSetting()
		{
			this.string_0 = this.Page.Server.HtmlDecode(ShopSettings.GetValue("EmailServer"));
			this.string_1 = this.Page.Server.HtmlDecode(ShopSettings.GetValue("SMTP"));
			this.string_3 = this.Page.Server.HtmlDecode(ShopSettings.GetValue("ServerPort"));
			this.string_2 = this.Page.Server.HtmlDecode(ShopSettings.GetValue("EmailAccount"));
			this.string_4 = this.Page.Server.HtmlDecode(ShopSettings.GetValue("EmailPassword"));
			this.string_5 = this.Page.Server.HtmlDecode(ShopSettings.GetValue("RestoreEmail"));
			this.string_6 = this.Page.Server.HtmlDecode(ShopSettings.GetValue("EmailCode"));
		}
		protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string sconts)
		{
			return new ShopNum1_EmailGroupSend
			{
				Guid = Guid.NewGuid(),
				EmailTitle = this.string_7,
				CreateTime = DateTime.Now,
				EmailGuid = new Guid("9d7b9b03-dfe5-4bd5-9eee-e0a1a86e347b"),
				SendObjectEmail = sconts,
				SendObject = memLoginID + "-" + email,
				State = state
			};
		}
		public string GetCallbackResult()
		{
			string[] array = this.string_9.Split(new char[]
			{
				'|'
			});
			return (string)base.GetType().GetMethod(array[0]).Invoke(this, new object[]
			{
				array[1]
			});
		}
		public void RaiseCallbackEvent(string eventArgument)
		{
			this.string_9 = eventArgument;
		}
	}
}
