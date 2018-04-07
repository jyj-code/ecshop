using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Second;
using System;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class Welcome : BaseWebControl
	{
		private string string_0 = "Weblcome.ascx";
		private Label label_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private Label label_1;
		private HtmlGenericControl htmlGenericControl_4;
		private HtmlGenericControl htmlGenericControl_5;
		private Repeater repeater_0;
		private Literal literal_0;
		[CompilerGenerated]
		private static Func<string, bool> func_0;
		public Welcome()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			try
			{
				this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("login");
				this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("loginOut");
				this.label_0 = (Label)skin.FindControl("MemLoginID");
				this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("loginTwo");
				this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("loginOutTwo");
				this.label_1 = (Label)skin.FindControl("LabelMemLoginID");
				this.htmlGenericControl_4 = (HtmlGenericControl)skin.FindControl("shopcart1");
				this.htmlGenericControl_5 = (HtmlGenericControl)skin.FindControl("shopcart2");
				this.literal_0 = (Literal)skin.FindControl("LiteralCartCount");
				if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
				{
					HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					this.htmlGenericControl_0.Visible = false;
					this.htmlGenericControl_1.Visible = true;
					this.htmlGenericControl_2.Visible = false;
					this.htmlGenericControl_3.Visible = true;
					this.htmlGenericControl_4.Visible = false;
					this.htmlGenericControl_5.Visible = true;
					this.label_0.Text = httpCookie.Values["MemLoginID"].ToString();
					this.method_0(this.label_0.Text.Trim());
					if (this.Page.IsPostBack && this.Page.Request.Form["secondEVENTTARGET"] != null && this.Page.Request.Form["secondEVENTTARGET"].ToString() != "" && this.Page.Request.Form["secondEVENTTARGET"].ToString() == "cartClick")
					{
						this.Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
					}
				}
				else
				{
					string string_ = string.Empty;
					if (this.Page.Request.Cookies["Visitor_LoginCookie"] != null)
					{
						HttpCookie cookie2 = this.Page.Request.Cookies["Visitor_LoginCookie"];
						HttpCookie httpCookie2 = HttpSecureCookie.Decode(cookie2);
						string_ = httpCookie2.Values["MemLoginID"].ToString();
						this.method_0(string_);
						this.htmlGenericControl_4.Visible = false;
						this.htmlGenericControl_5.Visible = true;
					}
					else
					{
						this.htmlGenericControl_4.Visible = true;
						this.htmlGenericControl_5.Visible = false;
					}
					this.repeater_0 = (Repeater)skin.FindControl("RepeaterSecondLogin");
					this.htmlGenericControl_0.Visible = true;
					this.htmlGenericControl_1.Visible = false;
					this.htmlGenericControl_2.Visible = true;
					this.htmlGenericControl_3.Visible = false;
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
							GetUrl.RedirectLoginGoBack();
						}
						else
						{
							this.RaisePostBackEvent();
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
		private void method_0(string string_1)
		{
			if (this.literal_0 != null)
			{
				IShopNum1_Cart_Action shopNum1_Cart_Action = LogicFactory.CreateShopNum1_Cart_Action();
				this.literal_0.Text = shopNum1_Cart_Action.GetMemCartCount(string_1).ToString();
			}
		}
		public void Logout(string domain)
		{
			if (HttpContext.Current.Request.Cookies["dnt"] != null)
			{
				HttpCookie httpCookie = new HttpCookie("dnt");
				httpCookie.Expires = DateTime.Now.AddYears(-1);
				httpCookie.Domain = domain;
				httpCookie.Secure = false;
				HttpContext.Current.Response.AppendCookie(httpCookie);
			}
		}
		public void RaisePostBackEvent()
		{
			string arg = this.Page.Request.Form["secondEVENTTARGET"];
			if (Welcome.func_0 == null)
			{
				Welcome.func_0 = new Func<string, bool>(Welcome.smethod_0);
			}
			Func<string, bool> func = Welcome.func_0;
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
