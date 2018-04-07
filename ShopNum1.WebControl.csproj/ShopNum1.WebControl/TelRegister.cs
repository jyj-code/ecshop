using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DiscuzHelper;
using ShopNum1.DiscuzToolkit;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Standard;
using ShopNum1.Ucenter.Request;
using ShopNum1MultiEntity;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class TelRegister : BaseWebControl
	{
		private string string_0 = "TelRegister.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private Label label_0;
		private Button button_0;
		private CheckBox checkBox_0;
		public static bool EnableRegister = true;
		public TelRegister()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("divAgainregester");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("divregester");
			this.label_0 = (Label)skin.FindControl("LabelMemLoginID");
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				try
				{
					this.Page.Form.DefaultButton = "TelRegister$ctl00$ButtonConfirm";
				}
				catch
				{
				}
				this.htmlGenericControl_0.Visible = false;
				this.htmlGenericControl_1.Visible = true;
				this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
				this.textBox_1 = (TextBox)skin.FindControl("TextBoxPwd");
				this.textBox_2 = (TextBox)skin.FindControl("TextBoxRePwd");
				this.checkBox_0 = (CheckBox)skin.FindControl("CheckBoxIfAgree");
				this.button_0 = (Button)skin.FindControl("ButtonConfirm");
				this.button_0.Click += new EventHandler(this.ButtonConfirm_Click);
			}
			else
			{
				HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.label_0.Text = httpCookie.Values["MemLoginID"].ToString();
				this.htmlGenericControl_0.Visible = true;
				this.htmlGenericControl_1.Visible = false;
			}
		}
		public void ButtonConfirm_Click(object sender, EventArgs e)
		{
			ShopSettings.GetValue("RegIsEmail");
			string value = ShopSettings.GetValue("RegIsActivationEmail");
			string value2 = ShopSettings.GetValue("RegistOrderIsMMS");
			string value3 = ShopSettings.GetValue("Name");
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			if (shopNum1_Member_Action.CheckmemLoginID(this.textBox_0.Text.Trim()) > 0)
			{
				MessageBox.Show("用户名已经被注册过了,请换一个用户名!");
			}
			else
			{
				ShopNum1_Member shopNum1_Member = new ShopNum1_Member();
				shopNum1_Member.MemLoginID = this.textBox_0.Text;
				shopNum1_Member.MemberType = new int?(1);
				shopNum1_Member.Name = "";
				shopNum1_Member.Pwd = Encryption.GetMd5Hash(this.textBox_1.Text);
				shopNum1_Member.IsForbid = new int?(0);
				shopNum1_Member.Email = "";
				shopNum1_Member.Guid = Guid.NewGuid();
				shopNum1_Member.Mobile = this.textBox_0.Text;
				shopNum1_Member.AdvancePayment = new decimal?(0m);
				shopNum1_Member.AddressValue = "";
				shopNum1_Member.AddressCode = "";
				shopNum1_Member.RegeDate = new DateTime?(DateTime.Now);
				shopNum1_Member.LoginDate = new DateTime?(DateTime.Now);
				shopNum1_Member.IsMailActivation = new int?(1);
				shopNum1_Member.IsMobileActivation = 1;
				if (value == "0")
				{
					shopNum1_Member.IsMailActivation = new int?(1);
				}
				else
				{
					shopNum1_Member.IsMailActivation = new int?(0);
				}
				string value4 = ShopSettings.GetValue("RegPresentRankScore");
				if (value4 == "" || value4 == null)
				{
					shopNum1_Member.MemberRank = new int?(0);
				}
				else
				{
					shopNum1_Member.MemberRank = new int?(int.Parse(value4));
				}
				string value5 = ShopSettings.GetValue("RegPresentScore");
				if (value5 == "" || value5 == null)
				{
					shopNum1_Member.Score = 0;
				}
				else
				{
					shopNum1_Member.Score = int.Parse(value5);
				}
				shopNum1_Member.LastLoginIP = null;
				shopNum1_Member.LoginTime = new int?(0);
				shopNum1_Member.AdvancePayment = new decimal?(0m);
				shopNum1_Member.LockAdvancePayment = new decimal?(0m);
				shopNum1_Member.LockSocre = new int?(0);
				shopNum1_Member.CostMoney = new decimal?(0m);
				shopNum1_Member.PayPwd = Encryption.GetMd5SecondHash(this.textBox_1.Text);
				shopNum1_Member.IsMailActivation = new int?(0);
				shopNum1_Member.IsMobileActivation = 0;
				shopNum1_Member.PromotionMemLoginID = "";
				if (shopNum1_Member_Action.Add(shopNum1_Member) == 1)
				{
					string a = ConfigurationManager.AppSettings["IsIntergrationUCenter"].ToString();
					if (a == "1")
					{
						try
						{
							int num = Func.uc_user_register(shopNum1_Member.MemLoginID, this.textBox_1.Text.Trim(), shopNum1_Member.Email);
							if (num > 0)
							{
								RTN_UserLogin rTN_UserLogin = Func.uc_user_login(shopNum1_Member.MemLoginID, this.textBox_1.Text.Trim());
								string script = Func.uc_user_synlogin(rTN_UserLogin.Uid);
								HttpContext.Current.Response.AddHeader("P3P", "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
								this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "msgok", script, false);
							}
						}
						catch
						{
						}
					}
					string text = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
					if (text.Trim().ToString() == "1")
					{
						DiscuzSession session = DiscuzSessionHelper.GetSession();
						try
						{
							if (session.Register(shopNum1_Member.MemLoginID, this.textBox_1.Text.Trim(), "", false) > 0)
							{
								int userID = session.GetUserID(shopNum1_Member.MemLoginID);
								session.Login(userID, this.textBox_1.Text.Trim(), false, 100, ConfigurationManager.AppSettings["CookieDomain"]);
							}
						}
						catch (Exception)
						{
						}
					}
					string a2 = ConfigurationManager.AppSettings["IsIntergrationTg"].ToString();
					if (a2 == "1")
					{
						Configuration configuration = WebConfigurationManager.OpenWebConfiguration(this.Page.Request.ApplicationPath);
						AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
						string value6 = appSettingsSection.Settings["TgPostUrl"].Value;
						string value7 = appSettingsSection.Settings["TgSourceKey"].Value;
						string a3 = this.method_0(string.Concat(new object[]
						{
							value6,
							"IntergrationMemberRegist.aspx?MemLoginID=",
							shopNum1_Member.MemLoginID,
							"&Email=",
							shopNum1_Member.Email,
							"&Pwd=",
							shopNum1_Member.Pwd,
							"&PayPwd=",
							shopNum1_Member.PayPwd,
							"&Sex=",
							shopNum1_Member.Sex,
							"&Birthday=",
							shopNum1_Member.Birthday,
							"&CreditMoney=",
							shopNum1_Member.CreditMoney,
							"&Photo=",
							shopNum1_Member.Photo,
							"&RealName=",
							shopNum1_Member.RealName,
							"&Area=",
							shopNum1_Member.Area,
							"&Vocation=",
							shopNum1_Member.Vocation,
							"&Address=",
							shopNum1_Member.Address,
							"&Postalcode=",
							shopNum1_Member.Postalcode,
							"&Mobile=",
							shopNum1_Member.Mobile,
							"&Fax=",
							shopNum1_Member.Fax,
							"&QQ=",
							shopNum1_Member.QQ,
							"&Msn=",
							shopNum1_Member.Msn,
							"&WebSite=",
							shopNum1_Member.WebSite,
							"&Question=",
							shopNum1_Member.Question,
							"&Answer=",
							shopNum1_Member.Answer,
							"&RegDate=",
							shopNum1_Member.RegeDate,
							"&LastLoginDate=",
							shopNum1_Member.LastLoginDate,
							"&LastLoginIP=",
							shopNum1_Member.LastLoginIP,
							"&LoginTime=",
							DateTime.Now.ToString(),
							"&AdvancePayment=",
							shopNum1_Member.AdvancePayment,
							"&Score=",
							shopNum1_Member.Score,
							"&RankScore=0&LockAdvancePayment=",
							shopNum1_Member.LockAdvancePayment,
							"&LockSocre=",
							shopNum1_Member.LockSocre,
							"&CostMoney=",
							shopNum1_Member.CostMoney,
							"&MemberRankGuid=",
							Guid.Empty,
							"&TradeCount=0&CreateUser=admin&CreateTime=",
							DateTime.Now.ToString(),
							"&ModifyUser=admin&ModifyTime=",
							DateTime.Now.ToString(),
							"&TgSourceKey=",
							value7
						}));
						if (a3 != string.Empty)
						{
							string arg = string.Concat(new object[]
							{
								value6,
								"IntergrationMemberLogin.aspx?MemLoginID=",
								shopNum1_Member.MemLoginID,
								"&MemberRankGuid=",
								Guid.NewGuid(),
								"&Pwd=",
								shopNum1_Member.Pwd,
								"&TgSourceKey=",
								appSettingsSection.Settings["TgSourceKey"].Value
							});
							string text2 = "<script src='{0}'></script>";
							text2 = string.Format(text2, arg);
							this.Page.Response.Write(text2);
						}
					}
					if (value2 == "1")
					{
						Register register = new Register();
						register.Email = "";
						register.Name = this.textBox_0.Text.Trim();
						register.Password = this.textBox_1.Text.Trim();
						register.ShopName = value3;
						register.SysSendTime = DateTime.Now.ToString();
						string text3 = string.Empty;
						string mMsTitle = string.Empty;
						string text4 = "4A12724C-5154-4928-B867-D5BD180E80E6";
						IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
						DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'" + text4 + "'", 0);
						Guid.NewGuid().ToString();
						if (editInfo.Rows.Count > 0)
						{
							text3 = editInfo.Rows[0]["Remark"].ToString();
							mMsTitle = editInfo.Rows[0]["Title"].ToString();
						}
						text3 = register.ChangeRegister(this.Page.Server.HtmlDecode(text3));
						SMS sMS = new SMS();
						text3 = text3.Replace("{$Name}", this.textBox_0.Text);
						text3 = text3.Replace("{$ShopName}", value3);
						text3 = text3.Replace("{$Password} ", shopNum1_Member.Pwd);
						text3 = text3.Replace("{$Email}", "");
						text3 = text3.Replace("{$SysSendTime}", DateTime.Now.ToString());
						string text5 = "";
						sMS.Send(shopNum1_Member.MemLoginID, text3, out text5);
						if (text5.IndexOf("发送成功") != -1)
						{
							ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(shopNum1_Member.MemLoginID, shopNum1_Member.MemLoginID, mMsTitle, 2, text4);
							shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
						}
						else
						{
							ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(this.textBox_0.Text.Trim(), shopNum1_Member.MemLoginID, mMsTitle, 0, "4a12724c-5154-4928-b867-d5bd180e80e6");
							shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
						}
					}
					this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "memlogin", string.Concat(new string[]
					{
						"window.location.href='",
						GetPageName.RetDomainUrl("MemberRegisterSuccess"),
						"?type=2&MemLoginID=",
						this.textBox_0.Text.Trim(),
						"'"
					}), true);
				}
				else
				{
					MessageBox.Show("注册失败!请重新注册");
				}
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
		protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state, string mmsGuid)
		{
			return new ShopNum1_MMSGroupSend
			{
				Guid = Guid.NewGuid(),
				MMSTitle = MMsTitle,
				CreateTime = DateTime.Now,
				MMSGuid = new Guid(mmsGuid),
				SendObjectMMS = mobile,
				SendObject = memLoginID + "-" + mobile,
				State = state
			};
		}
		private string method_0(string string_1)
		{
			string result = string.Empty;
			Encoding encoding = Encoding.GetEncoding("utf-8");
			WebRequest webRequest = WebRequest.Create(string_1);
			try
			{
				webRequest.Timeout = 3000;
				WebResponse response = webRequest.GetResponse();
				StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
				result = streamReader.ReadToEnd();
			}
			catch (Exception)
			{
				result = string.Empty;
			}
			return result;
		}
	}
}
