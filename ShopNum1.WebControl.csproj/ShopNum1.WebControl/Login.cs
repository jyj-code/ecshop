using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DiscuzHelper;
using ShopNum1.DiscuzToolkit;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Second;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.Ucenter.Request;
using ShopNum1MultiEntity;
using System;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class Login : BaseWebControl
	{
		private string string_0 = "Login.ascx";
		private Label label_0;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private HtmlTableRow htmlTableRow_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private Button button_0;
		private Button button_1;
		private DropDownList dropDownList_0;
		private Repeater repeater_0;
		private Label label_1;
		private HiddenField hiddenField_0;
		[CompilerGenerated]
		private static Func<string, bool> func_0;
		public Login()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("divlogin");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("divAgainLogin");
			this.label_1 = (Label)skin.FindControl("LabelMemLoginID");
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				this.Page.Response.Expires = 0;
				this.Page.Response.Buffer = true;
				this.Page.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1.0);
				this.Page.Response.AddHeader("pragma", "no-cache");
				this.Page.Response.CacheControl = "no-cache";
				this.htmlGenericControl_0.Visible = true;
				this.htmlGenericControl_1.Visible = false;
				this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
				this.textBox_1 = (TextBox)skin.FindControl("TextBoxPwd");
				this.textBox_2 = (TextBox)skin.FindControl("TextBoxCode");
				this.label_0 = (Label)skin.FindControl("LabelLoginInfo");
				this.button_0 = (Button)skin.FindControl("ButtonLogin");
				this.button_1 = (Button)skin.FindControl("ButtonCancelLogin");
				this.button_0.Click += new EventHandler(this.button_0_Click);
				this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("VerifyCode");
				this.dropDownList_0 = (DropDownList)skin.FindControl("LoginValidity");
				this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldLoginType");
				this.repeater_0 = (Repeater)skin.FindControl("RepeaterSecondLogin");
				if (this.repeater_0 != null)
				{
					ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness = new ShopNum1_SecondTypeBussiness();
					DataTable secondByCount = shopNum1_SecondTypeBussiness.GetSecondByCount("10", "1");
					if (secondByCount != null && secondByCount.Rows.Count > 0)
					{
						this.repeater_0.DataSource = secondByCount;
						this.repeater_0.DataBind();
					}
				}
				if (this.Page.IsPostBack && this.Page.Request.Form["secondEVENTTARGET"] != null && this.Page.Request.Form["secondEVENTTARGET"].ToString() != "")
				{
					if (this.Page.Request.Form["secondEVENTTARGET"].ToString() == "cartClick")
					{
						this.Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
						return;
					}
					this.RaisePostBackEvent();
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
			else
			{
				if (this.Page.IsPostBack && this.Page.Request.Form["secondEVENTTARGET"] != null && this.Page.Request.Form["secondEVENTTARGET"].ToString() != "")
				{
					if (this.Page.Request.Form["secondEVENTTARGET"].ToString() == "cartClick")
					{
						GetUrl.RedirectLoginGoBack();
						return;
					}
					this.RaisePostBackEvent();
				}
				HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.label_1.Text = httpCookie.Values["MemLoginID"].ToString();
				this.htmlGenericControl_0.Visible = false;
				this.htmlGenericControl_1.Visible = true;
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			DataTable memberPassWord = shopNum1_Member_Action.GetMemberPassWord(this.textBox_0.Text.Trim(), Encryption.GetMd5Hash(this.textBox_1.Text.Trim()));
			if (memberPassWord != null && memberPassWord.Rows.Count > 0)
			{
				string str = string.Empty;
				if (memberPassWord.Rows[0]["IsForbid"].ToString() == "1")
				{
					this.label_0.Text = "对不起，您的账户已被禁用！";
				}
				else
				{
					HttpCookie httpCookie = new HttpCookie("MemberLoginCookie");
					httpCookie.Values.Add("MemLoginID", memberPassWord.Rows[0]["MemLoginID"].ToString());
					httpCookie.Values.Add("Name", memberPassWord.Rows[0]["Name"].ToString());
					httpCookie.Values.Add("IsMailActivation", memberPassWord.Rows[0]["IsMailActivation"].ToString());
					httpCookie.Values.Add("MemberType", memberPassWord.Rows[0]["MemberType"].ToString());
					if (memberPassWord.Rows[0]["MemberType"].ToString() == "2")
					{
						ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
						DataTable shopRankByMemLoginID = shopNum1_ShopInfoList_Action.GetShopRankByMemLoginID(memberPassWord.Rows[0]["MemLoginID"].ToString());
						if (shopRankByMemLoginID != null && shopRankByMemLoginID.Rows.Count > 0)
						{
							httpCookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
							httpCookie.Values.Add("shopid", shopRankByMemLoginID.Rows[0]["shopid"].ToString());
						}
					}
					HttpCookie httpCookie2 = HttpSecureCookie.Encode(httpCookie);
					httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
					httpCookie.Values.Add("UID", "-1");
					this.dropDownList_0.SelectedValue = "0";
					string selectedValue = this.dropDownList_0.SelectedValue;
					if (selectedValue != null)
					{
						if (!(selectedValue == "1d"))
						{
							if (!(selectedValue == "1h"))
							{
								if (!(selectedValue == "1y"))
								{
									if (!(selectedValue == "1m"))
									{
										if (selectedValue == "1w")
										{
											httpCookie2.Expires = DateTime.Now.AddDays(7.0);
										}
									}
									else
									{
										httpCookie2.Expires = DateTime.Now.AddMonths(1);
									}
								}
								else
								{
									httpCookie2.Expires = DateTime.Now.AddYears(1);
								}
							}
							else
							{
								httpCookie2.Expires = DateTime.Now.AddHours(1.0);
							}
						}
						else
						{
							httpCookie2.Expires = DateTime.Now.AddDays(1.0);
						}
					}
					string a = ConfigurationManager.AppSettings["IsIntergrationUCenter"].ToString();
					if (a == "1")
					{
						RTN_UserLogin rTN_UserLogin = new RTN_UserLogin();
						try
						{
							rTN_UserLogin = Func.uc_user_login(this.textBox_0.Text.Trim(), this.textBox_1.Text.Trim().ToLower());
						}
						catch
						{
						}
						int num = shopNum1_Member_Action.CheckmemLoginID(this.textBox_0.Text.Trim());
						if (rTN_UserLogin.Uid < 0)
						{
							this.label_0.Text = "用户名或密码有误！";
						}
						else
						{
							if (rTN_UserLogin.Uid > 0 && num > 0)
							{
								shopNum1_Member_Action.UpdatePwd(rTN_UserLogin.UserName, Encryption.GetMd5Hash(rTN_UserLogin.PassWord));
							}
							rTN_UserLogin.Uid.ToString();
							try
							{
								string script = Func.uc_user_synlogin(rTN_UserLogin.Uid);
								HttpContext.Current.Response.AddHeader("P3P", "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
								this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "ucenter", script, false);
							}
							catch
							{
							}
						}
					}
					string a2 = ConfigurationManager.AppSettings["IsIntergrationTg"].ToString();
					if (a2 == "1")
					{
						Configuration configuration = WebConfigurationManager.OpenWebConfiguration(this.Page.Request.ApplicationPath);
						AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
						string value = appSettingsSection.Settings["TgPostUrl"].Value;
						string value2 = appSettingsSection.Settings["TgSourceKey"].Value;
						string arg = string.Concat(new object[]
						{
							value,
							"IntergrationMemberLogin.aspx?MemLoginID=",
							this.textBox_0.Text.Trim(),
							"&MemberRankGuid=",
							Guid.NewGuid(),
							"&Pwd=",
							this.textBox_1.Text.Trim().ToLower(),
							"&TgSourceKey=",
							value2
						});
						string text = "<script src='{0}'></script>";
						text = string.Format(text, arg);
						this.Page.Response.Write(text);
					}
					string text2 = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
					if (text2.Trim().ToString() == "1" && this.Page.Request.Cookies["dnt"] == null)
					{
						DiscuzSession session = DiscuzSessionHelper.GetSession();
						try
						{
							int userID = session.GetUserID(this.textBox_0.Text.Trim());
							session.Login(userID, this.textBox_1.Text.Trim().ToLower(), false, 100, ConfigurationManager.AppSettings["CookieDomain"]);
						}
						catch
						{
						}
					}
					this.Page.Response.AppendCookie(httpCookie2);
					shopNum1_Member_Action.UpdateLoginTime(this.textBox_0.Text.Trim(), this.Page.Request.UserHostAddress);
					if (this.Page.Request.Cookies["Visitor_LoginCookie"] != null)
					{
						try
						{
							string oldUser = string.Empty;
							HttpCookie httpCookie3 = this.Page.Request.Cookies["Visitor_LoginCookie"];
							HttpCookie httpCookie4 = HttpSecureCookie.Decode(httpCookie3);
							oldUser = httpCookie4.Values["MemLoginID"].ToString();
							Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
							shop_Product_Action.ChangeCarByCook(oldUser, this.textBox_0.Text.Trim());
							httpCookie3.Values.Clear();
						}
						catch (Exception)
						{
						}
					}
					if (ShopNum1.Common.Common.ReqStr("goback") != "")
					{
						str = ShopNum1.Common.Common.ReqStr("goback").Replace("%2f", "/");
					}
					else
					{
						str = "/main/member/m_index.aspx";
					}
					this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "redirecturl", "window.location.href='" + str + "'", true);
				}
			}
			else
			{
				string str = string.Empty;
				if (this.Page.Request.QueryString["goback"] != null)
				{
					str = this.Page.Request.QueryString["goback"].ToString();
				}
				else
				{
					str = "/main/member/m_index.aspx";
				}
				string a = ConfigurationManager.AppSettings["IsIntergrationUCenter"].ToString();
				if (a == "1")
				{
					RTN_UserLogin rTN_UserLogin = new RTN_UserLogin();
					try
					{
						rTN_UserLogin = Func.uc_user_login(this.textBox_0.Text.Trim(), this.textBox_1.Text.Trim().ToLower());
					}
					catch
					{
					}
					if (rTN_UserLogin.Uid < 0)
					{
						this.label_0.Text = "用户名或密码有误！";
					}
					else
					{
						int num = shopNum1_Member_Action.CheckmemLoginID(this.textBox_0.Text.Trim());
						if (num <= 0)
						{
							ShopNum1_Member shopNum1_Member = new ShopNum1_Member();
							shopNum1_Member.MemLoginID = rTN_UserLogin.UserName;
							shopNum1_Member.MemberType = new int?(1);
							shopNum1_Member.Name = "";
							shopNum1_Member.Pwd = Encryption.GetMd5Hash(this.textBox_1.Text.Trim().ToLower());
							shopNum1_Member.IsForbid = new int?(0);
							shopNum1_Member.Email = rTN_UserLogin.Email;
							shopNum1_Member.Guid = Guid.NewGuid();
							shopNum1_Member.Tel = "";
							shopNum1_Member.AdvancePayment = new decimal?(0m);
							shopNum1_Member.AddressValue = "";
							shopNum1_Member.AddressCode = "";
							shopNum1_Member.RegeDate = new DateTime?(DateTime.Now);
							shopNum1_Member.LoginDate = new DateTime?(DateTime.Now);
							string value3 = ShopSettings.GetValue("RegPresentRankScore");
							if (value3 == "" || value3 == null)
							{
								shopNum1_Member.MemberRank = new int?(0);
							}
							else
							{
								shopNum1_Member.MemberRank = new int?(int.Parse(value3));
							}
							string value4 = ShopSettings.GetValue("RegPresentScore");
							if (value4 == "" || value4 == null)
							{
								shopNum1_Member.Score = 0;
							}
							else
							{
								shopNum1_Member.Score = int.Parse(value4);
							}
							shopNum1_Member.LastLoginIP = null;
							shopNum1_Member.LoginTime = new int?(0);
							shopNum1_Member.AdvancePayment = new decimal?(0m);
							shopNum1_Member.LockAdvancePayment = new decimal?(0m);
							shopNum1_Member.LockSocre = new int?(0);
							shopNum1_Member.CostMoney = new decimal?(0m);
							shopNum1_Member.IsMailActivation = new int?(1);
							shopNum1_Member.PayPwd = Encryption.GetMd5SecondHash(this.textBox_1.Text.Trim().ToLower());
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
							catch (Exception)
							{
								memberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
							}
							shopNum1_Member.MemberRankGuid = memberRankGuid;
							shopNum1_Member_Action.Add(shopNum1_Member);
						}
						else if (rTN_UserLogin.Uid > 0 && num > 0)
						{
							shopNum1_Member_Action.UpdatePwd(rTN_UserLogin.UserName, Encryption.GetMd5Hash(rTN_UserLogin.PassWord));
						}
						rTN_UserLogin.Uid.ToString();
						try
						{
							string script = Func.uc_user_synlogin(rTN_UserLogin.Uid);
							HttpContext.Current.Response.AddHeader("P3P", "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
							this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "ucenter", script, false);
							HttpCookie httpCookie2 = HttpSecureCookie.Encode(new HttpCookie("MemberLoginCookie")
							{
								Values = 
								{

									{
										"MemLoginID",
										rTN_UserLogin.UserName
									},

									{
										"Name",
										""
									},

									{
										"IsMailActivation",
										"1"
									},

									{
										"MemberType",
										"1"
									}
								}
							});
							httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
							this.Page.Response.AppendCookie(httpCookie2);
							shopNum1_Member_Action.UpdateLoginTime(rTN_UserLogin.UserName, this.Page.Request.UserHostAddress);
							this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "redirecturl", "window.location.href='" + str + "'", true);
						}
						catch
						{
						}
					}
				}
				this.label_0.Text = "用户名或密码有误！";
			}
		}
		public void RaisePostBackEvent()
		{
			string arg = this.Page.Request.Form["secondEVENTTARGET"];
			if (Login.func_0 == null)
			{
				Login.func_0 = new Func<string, bool>(Login.smethod_0);
			}
			Func<string, bool> func = Login.func_0;
			func(arg);
		}
		[CompilerGenerated]
		private static bool smethod_0(string string_1)
		{
			ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness = new ShopNum1_SecondTypeBussiness();
			if (string_1 != null)
			{
				if (!(string_1 == "1"))
				{
					if (!(string_1 == "2"))
					{
						if (!(string_1 == "3"))
						{
							if (!(string_1 == "4"))
							{
								if (string_1 == "5")
								{
									DataTable model = shopNum1_SecondTypeBussiness.GetModel(5);
									new ShopNum1_TaobaoOAuthClient().GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(), "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Taobao/TaobaoReturn.aspx");
								}
							}
							else
							{
								ShopNum1_Alipay_config alipay_config = new ShopNum1_Alipay_config();
								new ShopNum1_AlipayOAuthClient(alipay_config).GetAuthorizationUrl();
							}
						}
						else
						{
							DataTable model = shopNum1_SecondTypeBussiness.GetModel(3);
							if (model != null && model.Rows.Count != 0)
							{
								new ShopNum1_XinlanOAuthClient().GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(), "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Xinlan/XinlanReturn.aspx");
							}
						}
					}
					else
					{
						DataTable model = shopNum1_SecondTypeBussiness.GetModel(2);
						if (model != null && model.Rows.Count != 0)
						{
							new ShopNum1_BaiduOAuthClient().GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(), "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Baidu/BaiduReturn.aspx");
						}
					}
				}
				else
				{
					DataTable model = shopNum1_SecondTypeBussiness.GetModel(1);
					if (model != null && model.Rows.Count != 0)
					{
						ShopNum1_QzoneCommonClient.GetAuthorizationUrl(model.Rows[0]["AppID"].ToString(), "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Qzone/QzoneReturn.aspx");
					}
				}
			}
			return true;
		}
	}
}
