using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DiscuzHelper;
using ShopNum1.DiscuzToolkit;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
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
	public class MemberRegister : BaseWebControl
	{
		private string string_0 = "MemberRegister.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private HtmlTableRow htmlTableRow_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private Label label_0;
		private TextBox textBox_5;
		private Button button_0;
		private CheckBox checkBox_0;
		public static bool EnableRegister = true;
		public MemberRegister()
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
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxPwd");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxRePwd");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxEmail");
			this.textBox_5 = (TextBox)skin.FindControl("TextBoxMobile");
			this.checkBox_0 = (CheckBox)skin.FindControl("CheckBoxIfAgree");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxCode");
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("VerifyCode");
			this.button_0.Click += new EventHandler(this.ButtonConfirm_Click);
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				this.htmlGenericControl_0.Visible = false;
				this.htmlGenericControl_1.Visible = true;
				this.Page.Response.Expires = 0;
				this.Page.Response.Buffer = true;
				this.Page.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1.0);
				this.Page.Response.AddHeader("pragma", "no-cache");
				this.Page.Response.CacheControl = "no-cache";
			}
			else
			{
				HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.label_0.Text = httpCookie.Values["MemLoginID"].ToString();
				this.htmlGenericControl_0.Visible = true;
				this.htmlGenericControl_1.Visible = false;
			}
			if (ShopSettings.GetValue("MemLoginVerifyCode") == "1")
			{
				this.htmlTableRow_0.Visible = true;
			}
			else
			{
				this.htmlTableRow_0.Visible = false;
			}
		}
		public void ButtonConfirm_Click(object sender, EventArgs e)
		{
			string value = ShopSettings.GetValue("RegIsEmail");
			string value2 = ShopSettings.GetValue("RegIsActivationEmail");
			string value3 = ShopSettings.GetValue("RegistOrderIsMMS");
			string value4 = ShopSettings.GetValue("Name");
			ShopNum1_Member shopNum1_Member = new ShopNum1_Member();
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			if (!string.IsNullOrEmpty(this.textBox_0.Text.Trim().ToString()))
			{
				this.textBox_4.Text = string.Empty;
				this.textBox_5.Text = string.Empty;
				if (shopNum1_Member_Action.CheckmemLoginID(this.textBox_0.Text.Trim()) > 0)
				{
					MessageBox.Show("用户名已经被注册过了,请换一个用户名!");
					return;
				}
				shopNum1_Member.MemLoginID = this.textBox_0.Text;
			}
			if (!string.IsNullOrEmpty(this.textBox_5.Text.Trim().ToString()))
			{
				this.textBox_0.Text = string.Empty;
				this.textBox_4.Text = string.Empty;
				if (shopNum1_Member_Action.CheckMemMobileByMobile(this.textBox_5.Text.Trim()).Rows.Count > 0)
				{
					MessageBox.Show("手机号码已经被使用了,请换一个手机号码!");
					return;
				}
				shopNum1_Member.MemLoginID = this.textBox_5.Text.Trim();
			}
			if (!string.IsNullOrEmpty(this.textBox_4.Text.Trim().ToString()))
			{
				this.textBox_0.Text = string.Empty;
				this.textBox_5.Text = string.Empty;
				if (shopNum1_Member_Action.CheckmemEmail(this.textBox_4.Text.Trim()) > 0)
				{
					MessageBox.Show("邮箱已经被使用了,请换一个邮箱!");
					return;
				}
				shopNum1_Member.MemLoginID = this.textBox_4.Text.Trim();
			}
			if (!string.IsNullOrEmpty(this.textBox_4.Text.Trim()) && value2.Equals("1"))
			{
				shopNum1_Member.IsForbid = new int?(1);
			}
			else
			{
				shopNum1_Member.IsForbid = new int?(0);
			}
			shopNum1_Member.MemberType = new int?(1);
			shopNum1_Member.Name = "";
			shopNum1_Member.Pwd = Encryption.GetMd5Hash(this.textBox_1.Text);
			shopNum1_Member.Email = this.textBox_4.Text;
			shopNum1_Member.Guid = Guid.NewGuid();
			shopNum1_Member.Mobile = this.textBox_5.Text;
			shopNum1_Member.AdvancePayment = new decimal?(0m);
			shopNum1_Member.AddressValue = "";
			shopNum1_Member.AddressCode = "";
			shopNum1_Member.RegeDate = new DateTime?(DateTime.Now);
			shopNum1_Member.LoginDate = null;
			shopNum1_Member.IsMobileActivation = 0;
			shopNum1_Member.IsEmailActivation = "0";
			if (this.Page.Request.QueryString["memberid"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["memberid"].ToString()))
			{
				string nameById = ShopNum1.Common.Common.GetNameById("Guid", "ShopNum1_Member", "   AND  MemLoginID='" + HttpUtility.HtmlDecode(this.Page.Request.QueryString["memberid"].ToString()) + "'");
				if (!string.IsNullOrEmpty(nameById))
				{
					shopNum1_Member.PromotionMemLoginID = HttpUtility.HtmlDecode(this.Page.Request.QueryString["memberid"].ToString());
				}
				else
				{
					shopNum1_Member.PromotionMemLoginID = "";
				}
			}
			else
			{
				shopNum1_Member.PromotionMemLoginID = "";
			}
			if (value2 == "0")
			{
				shopNum1_Member.IsMailActivation = new int?(1);
			}
			else
			{
				shopNum1_Member.IsMailActivation = new int?(0);
			}
			string value5 = ShopSettings.GetValue("RegPresentRankScore");
			if (value5 == "" || value5 == null)
			{
				shopNum1_Member.MemberRank = new int?(0);
			}
			else
			{
				shopNum1_Member.MemberRank = new int?(int.Parse(value5));
			}
			ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_MemberRank_Action();
			DataTable defaultMemberRank = shopNum1_MemberRank_Action.GetDefaultMemberRank();
			Guid memberRankGuid = Guid.NewGuid();
			try
			{
				if (defaultMemberRank != null && defaultMemberRank.Rows.Count > 0)
				{
					memberRankGuid = new Guid(defaultMemberRank.Rows[0]["Guid"].ToString());
				}
				else
				{
					memberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
				}
			}
			catch (Exception ex)
			{
				memberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
			}
			shopNum1_Member.MemberRankGuid = memberRankGuid;
			string value6 = ShopSettings.GetValue("RegPresentScore");
			if (value6 == "" || value6 == null)
			{
				shopNum1_Member.Score = 0;
			}
			else
			{
				shopNum1_Member.Score = int.Parse(value6);
			}
			shopNum1_Member.LastLoginIP = null;
			shopNum1_Member.LoginTime = new int?(1);
			shopNum1_Member.AdvancePayment = new decimal?(0m);
			shopNum1_Member.LockAdvancePayment = new decimal?(0m);
			shopNum1_Member.LockSocre = new int?(0);
			shopNum1_Member.CostMoney = new decimal?(0m);
			if (shopNum1_Member_Action.Add(shopNum1_Member) == 1)
			{
				if (this.Page.Request.Cookies["Visitor_LoginCookie"] != null)
				{
					try
					{
						string oldUser = string.Empty;
						HttpCookie httpCookie = this.Page.Request.Cookies["Visitor_LoginCookie"];
						HttpCookie httpCookie2 = HttpSecureCookie.Decode(httpCookie);
						oldUser = httpCookie2.Values["MemLoginID"].ToString();
						Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
						shop_Product_Action.ChangeCarByCook(oldUser, this.textBox_0.Text.Trim());
						httpCookie.Values.Clear();
					}
					catch (Exception ex)
					{
					}
				}
				string a = ConfigurationManager.AppSettings["IsIntergrationUCenter"].ToString();
				if (a == "1")
				{
					try
					{
						string email = shopNum1_Member.Email;
						if (shopNum1_Member.Email == "")
						{
							email = shopNum1_Member.MemLoginID + "@163.com";
						}
						else
						{
							email = shopNum1_Member.Email;
						}
						int num = Func.uc_user_register(shopNum1_Member.MemLoginID, this.textBox_1.Text.Trim(), email);
						if (num > 0)
						{
							RTN_UserLogin rTN_UserLogin = Func.uc_user_login(shopNum1_Member.MemLoginID, this.textBox_1.Text.Trim());
							string script = Func.uc_user_synlogin(rTN_UserLogin.Uid);
							HttpContext.Current.Response.AddHeader("P3P", "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
							this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "msgok", script, false);
						}
					}
					catch (Exception ex)
					{
						File.AppendAllText(this.Page.Server.MapPath("/log/uc.txt"), ex.Message);
					}
				}
				string text = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
				if (text.Trim().ToString() == "1")
				{
					DiscuzSession session = DiscuzSessionHelper.GetSession();
					try
					{
						string email2 = shopNum1_Member.Email;
						if (shopNum1_Member.Email == "")
						{
							email2 = shopNum1_Member.MemLoginID + "@163.com";
						}
						else
						{
							email2 = shopNum1_Member.Email;
						}
						if (session.Register(shopNum1_Member.MemLoginID, this.textBox_1.Text.Trim(), email2, false) > 0)
						{
							int userID = session.GetUserID(shopNum1_Member.MemLoginID);
							session.Login(userID, this.textBox_1.Text.Trim(), false, 100, ConfigurationManager.AppSettings["DiscuzCookieDomain"]);
						}
					}
					catch (Exception ex)
					{
					}
				}
				string a2 = ConfigurationManager.AppSettings["IsIntergrationTg"].ToString();
				if (a2 == "1")
				{
					Configuration configuration = WebConfigurationManager.OpenWebConfiguration(this.Page.Request.ApplicationPath);
					AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
					string value7 = appSettingsSection.Settings["TgPostUrl"].Value;
					string value8 = appSettingsSection.Settings["TgSourceKey"].Value;
					string a3 = this.method_0(string.Concat(new object[]
					{
						value7,
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
						"&Photo=",
						shopNum1_Member.Photo,
						"&RealName=",
						shopNum1_Member.RealName,
						"&Area=",
						shopNum1_Member.Address,
						"&Vocation=",
						shopNum1_Member.Vocation,
						"&Address=",
						shopNum1_Member.Address,
						"&Postalcode=",
						shopNum1_Member.Postalcode,
						"&Fax=",
						shopNum1_Member.Fax,
						"&QQ=",
						shopNum1_Member.QQ,
						"&WebSite=",
						shopNum1_Member.WebSite,
						"&Question=",
						shopNum1_Member.Question,
						"&Answer=",
						shopNum1_Member.Answer,
						"&RegDate=",
						Convert.ToDateTime(shopNum1_Member.RegeDate).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"),
						"&LastLoginDate=",
						shopNum1_Member.LastLoginDate,
						"&LastLoginIP=",
						shopNum1_Member.LastLoginIP,
						"&LoginTime=",
						DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"),
						"&AdvancePayment=",
						shopNum1_Member.AdvancePayment,
						"&Score=",
						shopNum1_Member.Score,
						"&RankScore=0&LockAdvancePayment=",
						shopNum1_Member.LockAdvancePayment,
						"&LockSocre=",
						shopNum1_Member.LockSocre,
						"&MemberRankGuid=",
						Guid.Empty,
						"&TradeCount=0&CreateUser=  &CreateTime=",
						DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"),
						"&ModifyUser= &ModifyTime=",
						DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"),
						"&TgSourceKey=",
						value8
					}));
					if (a3 != string.Empty)
					{
						string arg = string.Concat(new object[]
						{
							value7,
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
					if (this.textBox_4.Text == "")
					{
						HttpCookie httpCookie3 = new HttpCookie("MemberLoginCookie");
						httpCookie3.Values.Add("MemLoginID", shopNum1_Member.MemLoginID);
						httpCookie3.Values.Add("Name", shopNum1_Member.Name);
						httpCookie3.Values.Add("IsMailActivation", shopNum1_Member.IsMailActivation.ToString());
						httpCookie3.Values.Add("MemberType", shopNum1_Member.MemberType.ToString());
						if (shopNum1_Member.MemberType.ToString() == "2")
						{
							Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
							DataTable shopRankByMemLoginID = shop_ShopInfo_Action.GetShopRankByMemLoginID(shopNum1_Member.MemLoginID);
							if (shopRankByMemLoginID != null && shopRankByMemLoginID.Rows.Count > 0)
							{
								httpCookie3.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
							}
						}
						httpCookie3.Values.Add("UID", "-1");
						HttpCookie httpCookie4 = HttpSecureCookie.Encode(httpCookie3);
						httpCookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
						this.Page.Response.AppendCookie(httpCookie4);
						if (this.textBox_0.Text != "")
						{
							ShopNum1.Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member", "  and MemLoginID='" + this.textBox_0.Text + "'");
							this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "memlogin", string.Concat(new string[]
							{
								"window.location.href='",
								GetPageName.RetDomainUrl("MemberRegisterSuccess"),
								"?type=2&MemLoginID=",
								this.textBox_0.Text.Trim(),
								"'"
							}), true);
						}
						else if (this.textBox_5.Text != "")
						{
							ShopNum1.Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member", " and Mobile='" + this.textBox_5.Text + "'");
							this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "memlogin", string.Concat(new string[]
							{
								"window.location.href='",
								GetPageName.RetDomainUrl("MemberRegisterSuccess"),
								"?type=2&MemLoginID=",
								this.textBox_5.Text.Trim(),
								"'"
							}), true);
						}
					}
					try
					{
						string text3 = Guid.NewGuid().ToString();
						RegIsActivationEmail regIsActivationEmail = new RegIsActivationEmail();
						regIsActivationEmail.Email = this.textBox_4.Text.Trim();
						regIsActivationEmail.Name = this.textBox_4.Text.Trim();
						regIsActivationEmail.link = string.Concat(new string[]
						{
							GetPageName.RetDomainUrl("MemberRegisterToMail"),
							"?code=",
							text3,
							"&type=0&email=",
							regIsActivationEmail.Email,
							"&userID=",
							this.textBox_4.Text.Trim()
						});
						regIsActivationEmail.ShopName = value4;
						regIsActivationEmail.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
						string text4 = string.Empty;
						string text5 = string.Empty;
						string text6 = "7790bcf5-f88a-46bd-8ead-959118481c02";
						string emailBody = string.Empty;
						ShopNum1_Email_Action shopNum1_Email_Action = new ShopNum1_Email_Action();
						DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text6 + "'", 0);
						if (editInfo.Rows.Count > 0)
						{
							text4 = editInfo.Rows[0]["Remark"].ToString();
							text5 = editInfo.Rows[0]["Title"].ToString();
						}
						text4 = text4.Replace("{$Name}", regIsActivationEmail.Name);
						text4 = text4.Replace("{$PassWord}", this.textBox_1.Text);
						text4 = text4.Replace("{$ShopName}", regIsActivationEmail.ShopName);
						text4 = text4.Replace("{$CheckUrl}", regIsActivationEmail.link);
						text4 = text4.Replace("{$SysSendTime}", regIsActivationEmail.SysSendTime);
						emailBody = regIsActivationEmail.ChangeRegister(this.Page.Server.HtmlDecode(text4));
						this.SendMailForRegister(this.textBox_4.Text.Trim(), this.textBox_4.Text.Trim(), text3, "", text5, text6, emailBody);
					}
					catch (Exception ex)
					{
						this.Context.Response.Write(ex.Message);
					}
				}
				if (value == "1" && value2 == "0")
				{
					Register register = new Register();
					register.Email = this.textBox_4.Text.Trim();
					register.Name = this.textBox_0.Text.Trim();
					register.Password = this.textBox_1.Text.Trim();
					register.ShopName = value4;
					register.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					string text4 = string.Empty;
					string text5 = string.Empty;
					string text6 = "4a12724c-5154-4928-b867-d5bd180e80e6";
					string emailBody = string.Empty;
					ShopNum1_Email_Action shopNum1_Email_Action = new ShopNum1_Email_Action();
					DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text6 + "'", 0);
					string text3 = Guid.NewGuid().ToString();
					if (editInfo.Rows.Count > 0)
					{
						text4 = editInfo.Rows[0]["Remark"].ToString();
						text5 = editInfo.Rows[0]["Title"].ToString();
					}
					emailBody = register.ChangeRegister(this.Page.Server.HtmlDecode(text4));
					SendEmail sendEmail = new SendEmail();
					sendEmail.Emails(this.textBox_4.Text.Trim(), this.textBox_0.Text.Trim(), text5, text6, emailBody);
				}
				if (value3 == "1" && this.textBox_5.Text.Trim() != "")
				{
					string text7 = this.textBox_5.Text.Trim();
					Register register = new Register();
					register.Email = this.textBox_5.Text.Trim();
					register.Name = this.textBox_0.Text.Trim();
					register.Password = this.textBox_1.Text.Trim();
					register.ShopName = value4;
					register.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					string text8 = string.Empty;
					string mMsTitle = string.Empty;
					IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
					DataTable editInfo2 = shopNum1_MMS_Action.GetEditInfo("'7790bcf5-f88a-46bd-8ead-959118481c02'", 0);
					if (editInfo2.Rows.Count > 0)
					{
						text8 = editInfo2.Rows[0]["Remark"].ToString();
						mMsTitle = editInfo2.Rows[0]["Title"].ToString();
					}
					SMS sMS = new SMS();
					string text9 = "";
					text8 = text8.Replace("{$Name}", text7);
					text8 = text8.Replace("{$PassWord}", this.textBox_1.Text);
					text8 = text8.Replace("{$ShopName}", ShopSettings.GetValue("Name"));
					text8 = text8.Replace("{$SysSendTime}", DateTime.Now.ToString());
					text8 = register.ChangeRegister(this.Page.Server.HtmlDecode(text8));
					sMS.Send(text7.Trim(), text8, out text9);
					if (text9.IndexOf("发送成功") != -1)
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(this.textBox_0.Text.Trim(), text7.Trim(), mMsTitle, text8, 2, "7790bcf5-f88a-46bd-8ead-959118481c02");
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
					else
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(this.textBox_0.Text.Trim(), text7.Trim(), mMsTitle, text8, 0, "7790bcf5-f88a-46bd-8ead-959118481c02");
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
				}
				this.AddScroll();
				if (value2 == "0")
				{
					HttpCookie httpCookie3 = new HttpCookie("MemberLoginCookie");
					httpCookie3.Values.Add("MemLoginID", shopNum1_Member.MemLoginID);
					httpCookie3.Values.Add("Name", shopNum1_Member.Name);
					httpCookie3.Values.Add("IsMailActivation", shopNum1_Member.IsMailActivation.ToString());
					httpCookie3.Values.Add("MemberType", shopNum1_Member.MemberType.ToString());
					if (shopNum1_Member.MemberType.ToString() == "2")
					{
						Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
						DataTable shopRankByMemLoginID = shop_ShopInfo_Action.GetShopRankByMemLoginID(shopNum1_Member.MemLoginID);
						if (shopRankByMemLoginID != null && shopRankByMemLoginID.Rows.Count > 0)
						{
							httpCookie3.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
						}
					}
					httpCookie3.Values.Add("UID", "-1");
					HttpCookie httpCookie4 = HttpSecureCookie.Encode(httpCookie3);
					httpCookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
					this.Page.Response.AppendCookie(httpCookie4);
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
					this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "memlogin", string.Concat(new string[]
					{
						"window.location.href='",
						GetPageName.RetDomainUrl("E-mailVerification"),
						"?email=",
						this.textBox_4.Text.Trim(),
						"&id=",
						this.textBox_4.Text.Trim(),
						"'"
					}), true);
				}
			}
			else
			{
				MessageBox.Show("注册失败!请重新注册");
			}
		}
		public void SendMailForRegister(string MemLoginID, string Email, string Emailkey, string Phone, string strTitle, string emailTemplentGuid, string emailBody)
		{
			ShopNum1_MemberEmailExec_Action shopNum1_MemberEmailExec_Action = (ShopNum1_MemberEmailExec_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_MemberEmailExec_Action();
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
		protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, string strContent, int state, string mmsGuid)
		{
			return new ShopNum1_MMSGroupSend
			{
				Guid = Guid.NewGuid(),
				MMSTitle = MMsTitle,
				CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
				MMSGuid = new Guid(mmsGuid),
				SendObjectMMS = strContent,
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
		public void AddScroll()
		{
			string value = ShopSettings.GetValue("RegPresentScore");
			string value2 = ShopSettings.GetValue("RegPresentRankScore");
			if (int.Parse(value) > 0)
			{
				ShopNum1_ScoreModifyLog shopNum1_ScoreModifyLog = new ShopNum1_ScoreModifyLog();
				shopNum1_ScoreModifyLog.Guid = Guid.NewGuid();
				shopNum1_ScoreModifyLog.OperateType = 1;
				shopNum1_ScoreModifyLog.CurrentScore = 0;
				shopNum1_ScoreModifyLog.OperateScore = int.Parse(value);
				shopNum1_ScoreModifyLog.LastOperateScore = int.Parse(value);
				shopNum1_ScoreModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				shopNum1_ScoreModifyLog.Memo = "注册赠送消费积分";
				shopNum1_ScoreModifyLog.MemLoginID = this.textBox_0.Text;
				shopNum1_ScoreModifyLog.CreateUser = this.textBox_0.Text;
				shopNum1_ScoreModifyLog.CreateTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
				shopNum1_ScoreModifyLog.IsDeleted = 0;
				ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
				shopNum1_ScoreModifyLog_Action.OperateScore(shopNum1_ScoreModifyLog);
			}
			if (int.Parse(value2) > 0)
			{
				ShopNum1_RankScoreModifyLog shopNum1_RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
				shopNum1_RankScoreModifyLog.Guid = Guid.NewGuid();
				shopNum1_RankScoreModifyLog.OperateType = 1;
				shopNum1_RankScoreModifyLog.CurrentScore = 0;
				shopNum1_RankScoreModifyLog.OperateScore = int.Parse(value2);
				shopNum1_RankScoreModifyLog.LastOperateScore = int.Parse(value2);
				shopNum1_RankScoreModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				shopNum1_RankScoreModifyLog.Memo = "注册赠送等级积分";
				shopNum1_RankScoreModifyLog.MemLoginID = this.textBox_0.Text;
				shopNum1_RankScoreModifyLog.CreateUser = this.textBox_0.Text;
				shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
				shopNum1_RankScoreModifyLog.IsDeleted = 0;
				ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
				shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
			}
		}
	}
}
