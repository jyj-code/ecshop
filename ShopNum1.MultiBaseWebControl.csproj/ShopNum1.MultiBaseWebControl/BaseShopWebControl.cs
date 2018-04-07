using ShopNum1.Common;
using ShopNum1.ExtendedCommon;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MultiBaseWebControl
{
	[ParseChildren(true)]
	public abstract class BaseShopWebControl : WebControl, INamingContainer
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		public string MemLoginID = string.Empty;
		public string SkinFilename
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		protected string SkinName
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		protected override void CreateChildControls()
		{
			if (this.CheckShopLogin())
			{
				Control control = this.LoadSkin();
				this.InitializeSkin(control);
				this.Controls.Add(control);
			}
		}
		private string method_0(string string_2)
		{
			Encoding encoding = Encoding.GetEncoding("utf-8");
			WebRequest webRequest = WebRequest.Create(string_2);
			string result;
			try
			{
				StreamReader streamReader = new StreamReader(webRequest.GetResponse().GetResponseStream(), encoding);
				result = streamReader.ReadToEnd();
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		public void FK()
		{
			ControlCheck controlCheck = new ControlCheck();
			string a = HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
			string text = ConfigurationManager.AppSettings["DoMain"].ToString().ToLower();
			if (a != text)
			{
				this.FKPost();
				return;
			}
			if (controlCheck.CheckCertificationModificate(text) != 2)
			{
				this.FKPost();
				return;
			}
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (controlCheck.CheckCetificationA(out empty, out empty2) != 2)
			{
				this.FKPost();
				return;
			}
			if (!controlCheck.CheckFirstMd5(empty, text, empty2.ToLower()))
			{
				this.FKPost();
				return;
			}
			if (!controlCheck.CheckSecondDes(empty2.ToLower()))
			{
				this.FKPost();
			}
		}
		protected void FKPost()
		{
			HttpContext current = HttpContext.Current;
			string text = ConfigurationManager.AppSettings["DoMain"].ToString();
			if (text != "localhost")
			{
				string a;
				if ((a = this.method_1("http://www.shopnum1.com/ShopNum1MallDomainVerfiy/ShopNum1Verfify.aspx?shopnum1verfify=FKshopnum1verfify&&FkDomin=" + text)) != null)
				{
					if (a == "YES")
					{
						return;
					}
					if (a == "FKENDDATE")
					{
						current.Response.Redirect("http://www.shopnum1.com/Mallbuy.html");
						return;
					}
				}
				current.Response.Redirect("http://www.shopnum1.com/Mallshouldbuy.html");
			}
		}
		private string method_1(string string_2)
		{
			Encoding encoding = Encoding.GetEncoding("utf-8");
			WebRequest webRequest = WebRequest.Create(string_2);
			string result;
			try
			{
				StreamReader streamReader = new StreamReader(webRequest.GetResponse().GetResponseStream(), encoding);
				result = streamReader.ReadToEnd();
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		protected abstract void InitializeSkin(Control skin);
		protected Control LoadSkin()
		{
			if (this.SkinFilename == null)
			{
				this.SkinFilename = this.string_0;
			}
			string text = this.SkinFilename.TrimStart(new char[]
			{
				'/'
			});
			Control result;
			try
			{
				this.Page.Error += new EventHandler(this.PageBase_Error);
				result = this.Page.LoadControl(text);
			}
			catch (FileNotFoundException)
			{
				throw new Exception(text + "用户控件文件未找到");
			}
			return result;
		}
		protected void PageBase_Error(object sender, EventArgs e)
		{
			HttpContext current = HttpContext.Current;
			Exception lastError = current.Server.GetLastError();
			string text = current.Request.Url.ToString();
			string source = lastError.Source;
			string message = lastError.Message;
			string stackTrace = lastError.StackTrace;
			string text2 = current.Request.ServerVariables["SERVER_NAME"].ToString();
			this.method_0(string.Concat(new string[]
			{
				"http://www.shopnum1.com/ShopNum1ErrorGetMall/ErrorEet.aspx?FKshopnum1ERRORABC=FKshopnum1ERROR&&OffendingUrl=",
				text,
				"&&ErrorSouce= ",
				source,
				" &&Message=",
				message,
				"&&StackTrace= ",
				stackTrace,
				"&&MainDomain=",
				text2
			}));
			current.Server.ClearError();
			current.Response.Redirect("~/404.aspx");
		}
		public bool CheckShopLogin()
		{
			if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectTopLogin();
				return false;
			}
			HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			if (httpCookie.Values["MemberType"].ToString() != "2")
			{
				HttpContext.Current.Response.Redirect("S_WelcomeOpenShop.aspx");
			}
			this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
			return true;
		}
	}
}
