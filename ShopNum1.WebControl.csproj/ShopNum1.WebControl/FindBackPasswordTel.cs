using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class FindBackPasswordTel : BaseWebControl, ICallbackEventHandler
	{
		private string string_0 = "FindBackPasswordTel.ascx";
		private TextBox textBox_0;
		private Button button_0;
		private string string_1;
		public FindBackPasswordTel()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMobile");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.button_0.Click += new EventHandler(this.ButtonConfirm_Click);
			string text = "function existmobile(inputcontrol) {\n";
			text += "var context = document.getElementById(\"spanMobile\");\n";
			text += "var arg = \"ExistMobile|\" + inputcontrol.value;\n";
			text += "var reg = /^(1[3|5|8][0-9])\\d{8}$/";
			text += "\n if(inputcontrol.value != \"\") {\n";
			text += "if(reg.test(inputcontrol.value)) {context.innerHTML = \"数据查询中..\";";
			text = text + this.Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerMobileData", "context") + "; }\n";
			text += "else { context.innerHTML = \"手机格式不正确\";}\n}\n";
			text += "else { context.innerHTML = \"手机号码不能为空\";}\n}\n";
			this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "checkemobile", text, true);
			if (this.Page.IsPostBack)
			{
			}
		}
		public void ButtonConfirm_Click(object sender, EventArgs e)
		{
			DataTable dataTable = this.ExistMobiles(this.textBox_0.Text.Trim());
			if (dataTable.Rows.Count <= 0)
			{
				MessageBox.Show("手机号码不存在!");
			}
			else
			{
				string text = dataTable.Rows[0]["MemLoginID"].ToString();
				string text2 = this.SetNewPwd(text);
				string text3 = text2;
				string content = string.Concat(new string[]
				{
					"亲爱的",
					text,
					",您的多用户登录密码是：",
					text3,
					",请立即修改密码,本条短信请勿回复！"
				});
				string sendObjectMMS = "亲爱的" + text + ",您的多用户登录密码是： ******* ,请立即修改密码,本条短信请勿回复！";
				string a = "";
				SMS sMS = new SMS();
				sMS.Send(this.textBox_0.Text.Trim(), content, out a);
				this.InsertData(text + "-" + this.textBox_0.Text.Trim(), sendObjectMMS);
				if (a == "发送成功")
				{
					if (ShopSettings.IsOverrideUrl)
					{
						this.Page.Response.Redirect("~/FindPasswordFinalTel.html?tel=" + this.textBox_0.Text.Trim());
					}
					else
					{
						this.Page.Response.Redirect("~/FindPasswordFinalTel.aspx?tel=" + this.textBox_0.Text.Trim());
					}
				}
			}
		}
		public void InsertData(string sendObject, string sendObjectMMS)
		{
			ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = new ShopNum1_MMSGroupSend();
			shopNum1_MMSGroupSend.CreateTime = DateTime.Now;
			shopNum1_MMSGroupSend.Guid = Guid.NewGuid();
			shopNum1_MMSGroupSend.IsTime = 0;
			shopNum1_MMSGroupSend.MMSGuid = new Guid("464595bb-4e2a-4240-9b5e-03871e8b1409");
			shopNum1_MMSGroupSend.MMSTitle = "重设(找回)密码";
			shopNum1_MMSGroupSend.SendObject = sendObject;
			shopNum1_MMSGroupSend.SendObjectMMS = sendObjectMMS;
			shopNum1_MMSGroupSend.State = 0;
			shopNum1_MMSGroupSend.TimeSendTime = new DateTime?(DateTime.Now);
			IShopNum1_MMSGroupSend_Action shopNum1_MMSGroupSend_Action = LogicFactory.CreateShopNum1_MMSGroupSend_Action();
			shopNum1_MMSGroupSend_Action.Add(shopNum1_MMSGroupSend);
		}
		public string SetNewPwd(string MemLoginID)
		{
			string text = string.Empty;
			Random random = new Random();
			for (int i = 0; i < 7; i++)
			{
				text += random.Next(0, 9).ToString();
			}
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			shopNum1_Member_Action.UpdatePwd(MemLoginID, Encryption.GetMd5Hash(text));
			return text;
		}
		public DataTable ExistMobiles(string Mobile)
		{
			IShopNum1_Member_Action shopNum1_Member_Action = LogicFactory.CreateShopNum1_Member_Action();
			DataTable dataTable = shopNum1_Member_Action.CheckMemMobileByMobile(Mobile);
			DataTable result;
			if (dataTable != null)
			{
				result = dataTable;
			}
			else
			{
				result = null;
			}
			return result;
		}
		public string ExistMobile(string Mobile)
		{
			IShopNum1_Member_Action shopNum1_Member_Action = LogicFactory.CreateShopNum1_Member_Action();
			return shopNum1_Member_Action.CheckMemMobileByMobile1(Mobile).ToString();
		}
		public string GetCallbackResult()
		{
			string[] array = this.string_1.Split(new char[]
			{
				'|'
			});
			string result;
			if (array.Length == 2)
			{
				result = (string)base.GetType().GetMethod(array[0]).Invoke(this, new object[]
				{
					array[1]
				});
			}
			else
			{
				result = (string)base.GetType().GetMethod(array[0]).Invoke(this, new object[]
				{
					array[1],
					array[2]
				});
			}
			return result;
		}
		public void RaiseCallbackEvent(string eventArgument)
		{
			this.string_1 = eventArgument;
		}
	}
}
