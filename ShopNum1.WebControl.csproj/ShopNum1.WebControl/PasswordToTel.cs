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
	public class PasswordToTel : BaseWebControl
	{
		private string string_0 = "PasswordToTel.ascx";
		private LinkButton linkButton_0;
		private Button button_0;
		private string string_1;
		private string string_2;
		public PasswordToTel()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonTel");
			this.button_0 = (Button)skin.FindControl("ButtonReturnSend");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (!this.Page.IsPostBack)
			{
				this.linkButton_0.PostBackUrl = GetPageName.RetDomainUrl("index").ToString();
				if (this.Page.Request.QueryString["tel"] != null)
				{
					if (this.Page.Request.QueryString["tel"] == "")
					{
						if (ShopSettings.IsOverrideUrl)
						{
							this.Page.Response.Redirect("~/PasswordToTelErr.html");
						}
						else
						{
							this.Page.Response.Redirect("~/PasswordToTelErr.aspx");
						}
					}
					this.string_1 = this.Page.Request.QueryString["tel"].ToString();
					DataTable dataTable = this.ExistMobiles(this.Page.Request.QueryString["tel"].ToString());
					if (dataTable == null || dataTable.Rows.Count <= 0)
					{
						if (ShopSettings.IsOverrideUrl)
						{
							this.Page.Response.Redirect("~/PasswordToTelErr.html");
						}
						else
						{
							this.Page.Response.Redirect("~/PasswordToTelErr.aspx");
						}
					}
				}
				else if (ShopSettings.IsOverrideUrl)
				{
					this.Page.Response.Redirect("~/PasswordToTelErr.html");
				}
				else
				{
					this.Page.Response.Redirect("~/PasswordToTelErr.aspx");
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
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["tel"] != null)
			{
				this.string_2 = this.Page.Request.QueryString["tel"].ToString();
			}
			DataTable dataTable = this.ExistMobiles(this.string_2);
			if (dataTable.Rows.Count <= 0)
			{
				MessageBox.Show("手机号码不存在!");
			}
			else
			{
				string text = dataTable.Rows[0]["MemLoginID"].ToString();
				string text2 = this.SetNewPwd(text);
				string text3 = text2;
				string text4 = string.Concat(new string[]
				{
					"亲爱的",
					text,
					",您的多用户登录密码是：",
					text3,
					",请立即修改密码,本条短信请勿回复！"
				});
				string a = "";
				SMS sMS = new SMS();
				sMS.Send(this.string_2, text4, out a);
				this.InsertData(text + "-" + this.string_2, text4);
				if (a == "发送成功")
				{
					if (ShopSettings.IsOverrideUrl)
					{
						this.Page.Response.Redirect("~/FindPasswordFinalTel.html?tel=" + this.string_2);
					}
					else
					{
						this.Page.Response.Redirect("~/FindPasswordFinalTel.aspx?tel=" + this.string_2);
					}
				}
			}
		}
	}
}
