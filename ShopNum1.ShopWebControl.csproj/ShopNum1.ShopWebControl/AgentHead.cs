using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class AgentHead : BaseWebControl
	{
		private string string_0 = "AgentHead.ascx";
		private Literal literal_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private Label label_0;
		private Literal literal_1;
		private HtmlGenericControl htmlGenericControl_4;
		private HtmlGenericControl htmlGenericControl_5;
		private Label label_1;
		private HtmlImage htmlImage_0;
		private Image image_0;
		private string string_1;
		private string string_2;
		[CompilerGenerated]
		private static string string_3;
		public static string staticShopId
		{
			get;
			set;
		}
		public AgentHead()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			AgentHead.staticShopId = this.Page.Request.Url.Host;
			this.label_0 = (Label)skin.FindControl("LabelMemLoginID");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("islogin");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("unlogin");
			this.literal_0 = (Literal)skin.FindControl("AgnetAddress");
			this.literal_1 = (Literal)skin.FindControl("LiteralCartCount");
			this.htmlGenericControl_4 = (HtmlGenericControl)skin.FindControl("shopcart1");
			this.htmlGenericControl_5 = (HtmlGenericControl)skin.FindControl("shopcart2");
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("loginTwo");
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("loginOutTwo");
			this.label_1 = (Label)skin.FindControl("LabelMemLoginIDTwo");
			this.htmlImage_0 = (HtmlImage)skin.FindControl("ImageOriginalImge");
			this.image_0 = (Image)skin.FindControl("ImageShopLogo");
			this.GetShopLogo();
			string value = ShopSettings.GetValue("Logo");
			try
			{
				this.htmlImage_0.Src = this.Page.ResolveUrl(value);
			}
			catch
			{
			}
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.label_0.Text = (this.label_1.Text = httpCookie.Values["MemLoginID"].ToString());
				httpCookie.Values["MemberType"].ToString();
				this.method_0(this.label_0.Text.Trim());
				this.htmlGenericControl_0.Visible = true;
				this.htmlGenericControl_1.Visible = false;
				this.htmlGenericControl_4.Visible = false;
				this.htmlGenericControl_5.Visible = true;
				this.htmlGenericControl_2.Visible = false;
				this.htmlGenericControl_3.Visible = true;
			}
			else
			{
				this.htmlGenericControl_0.Visible = false;
				this.htmlGenericControl_1.Visible = true;
				this.htmlGenericControl_2.Visible = true;
				this.htmlGenericControl_3.Visible = false;
				this.htmlGenericControl_4.Visible = true;
				this.htmlGenericControl_5.Visible = false;
			}
			if (this.Page.IsPostBack && this.Page.Request.Form["secondEVENTTARGET"] != null && this.Page.Request.Form["secondEVENTTARGET"].ToString() != "" && this.Page.Request.Form["secondEVENTTARGET"].ToString() == "cartClick")
			{
				this.Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
			}
		}
		public void GetShopLogo()
		{
			try
			{
				string a = string.Empty;
				string path = string.Empty;
				string text = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
				a = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(text).ToString();
				if (!(a == ""))
				{
					this.string_1 = text;
					this.string_2 = shopNum1_ShopInfoList_Action.GetShopOpenTimeByShopID(text);
					if (this.string_2 != "")
					{
						this.string_2 = DateTime.Parse(this.string_2).ToString("yyyy-MM-dd");
					}
					path = string.Concat(new string[]
					{
						"~/Shop/Shop/",
						this.string_2.Replace("-", "/"),
						"/",
						ShopSettings.GetValue("PersonShopUrl"),
						this.string_1,
						"/Site_Settings.xml"
					});
					DataSet dataSet = new DataSet();
					dataSet.ReadXml(this.Page.Server.MapPath(path));
					DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
					this.image_0.ImageUrl = dataRow["ShopLogo"].ToString();
				}
			}
			catch (Exception ex)
			{
				this.Page.Response.Write(ex.Message);
			}
		}
		private void method_0(string string_4)
		{
			if (this.literal_1 != null)
			{
				IShopNum1_Cart_Action shopNum1_Cart_Action = LogicFactory.CreateShopNum1_Cart_Action();
				this.literal_1.Text = shopNum1_Cart_Action.GetMemCartCount(string_4).ToString();
			}
		}
		public static string RenderControl(Control control)
		{
			StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
			HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
			control.RenderControl(htmlTextWriter);
			htmlTextWriter.Flush();
			htmlTextWriter.Close();
			return stringWriter.ToString();
		}
		public static string SetUrl(object object_0)
		{
			string result;
			if (object_0.ToString() == "LoginExit")
			{
				result = AgentHead.staticShopId;
			}
			else if (object_0.ToString() == "")
			{
				result = "http://" + ShopSettings.siteDomain;
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					ShopSettings.siteDomain,
					"/",
					object_0.ToString(),
					ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
				});
			}
			return result;
		}
		public static string SetAgentUrl()
		{
			return "http://" + AgentHead.staticShopId;
		}
	}
}
