using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class ProductIsSpellDetail : BaseWebControl
	{
		private string string_0 = string.Empty;
		private string string_1 = "ProductIsSpellDetailNew.ascx";
		private Repeater repeater_0;
		private Button button_0 = new Button();
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Literal literal_0;
		private string string_2;
		private HtmlInputHidden htmlInputHidden_0;
		public static int int_0 = 0;
		public static int finished = 0;
		private string string_3 = string.Empty;
		[CompilerGenerated]
		private static string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		[CompilerGenerated]
		private static string string_7;
		public static string MemLoginID
		{
			get;
			set;
		}
		public string MemberType
		{
			get;
			set;
		}
		public string MemberLoginID
		{
			get;
			set;
		}
		public static string Isfinished
		{
			get;
			set;
		}
		public ProductIsSpellDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidProductGuId");
			this.string_2 = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"].ToString());
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
				string shopid = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
				ProductIsSpellDetail.MemLoginID = shop_ShopInfo_Action.GetMemberLoginidByShopid(shopid).ToString();
				if (ProductIsSpellDetail.MemLoginID != this.MemberLoginID)
				{
					string url = string.Concat(new string[]
					{
						"http://",
						this.Page.Request.Url.Host,
						"/ProductDetail/",
						this.htmlInputHidden_0.Value,
						".html?type=tg&"
					});
					this.Page.Response.Redirect(url);
				}
				else
				{
					MessageBox.Show("您不能购买自己的商品！");
				}
			}
			else
			{
				GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再购买！");
			}
		}
		private void method_0()
		{
			Shop_GroupProduct_Action shop_GroupProduct_Action = new Shop_GroupProduct_Action();
			DataTable groupProductDetial = shop_GroupProduct_Action.GetGroupProductDetial(this.string_2);
			if (groupProductDetial.Rows.Count > 0)
			{
				this.repeater_0.DataSource = groupProductDetial;
				this.repeater_0.DataBind();
				this.htmlInputHidden_0.Value = groupProductDetial.Rows[0]["GuiD"].ToString();
				decimal value = Convert.ToDecimal(groupProductDetial.Rows[0]["GroupPrice"]);
				decimal value2 = Convert.ToDecimal(groupProductDetial.Rows[0]["ShopPrice"]);
				string value3 = (Convert.ToDouble(value) / Convert.ToDouble(value2)).ToString("F2");
				string text = (Convert.ToDecimal(value3) * 10m).ToString("F1");
				foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
				{
					new Button();
					this.button_0 = (Button)repeaterItem.FindControl("ButtonShopCar");
					this.button_0.Click += new EventHandler(this.button_0_Click);
					this.label_0 = (Label)repeaterItem.FindControl("LabelName");
					this.label_1 = (Label)repeaterItem.FindControl("LabelShopPrice");
					this.label_2 = (Label)repeaterItem.FindControl("LabelDiscount");
					this.label_2.Text = text;
					Repeater arg_19B_0 = (Repeater)repeaterItem.FindControl("RepeaterDateImage");
					this.literal_0 = (Literal)repeaterItem.FindControl("LiteralMemLoginID");
				}
				if (DateTime.Parse(groupProductDetial.Rows[0]["StartTime"].ToString()) > DateTime.Now)
				{
					this.button_0.Text = "即将开始";
					this.button_0.Enabled = false;
				}
				if (DateTime.Parse(groupProductDetial.Rows[0]["EndTime"].ToString()) < DateTime.Now)
				{
					this.button_0.Enabled = false;
					this.button_0.Text = "已结束";
					ProductIsSpellDetail.finished = 1;
					ProductIsSpellDetail.Isfinished = "1";
				}
				if (!string.IsNullOrEmpty(groupProductDetial.Rows[0]["groupcount"].ToString()) && int.Parse(groupProductDetial.Rows[0]["groupstock"].ToString()) <= int.Parse(groupProductDetial.Rows[0]["groupcount"].ToString()))
				{
					this.button_0.Enabled = false;
					this.button_0.Text = "已结束";
					ProductIsSpellDetail.finished = 1;
					ProductIsSpellDetail.Isfinished = "1";
				}
			}
			else
			{
				string url = "http://" + HttpContext.Current.Request.Url.Host + "/NoFind.aspx";
				this.Page.Response.Redirect(url);
			}
		}
		public static string IsBegin(object begin, object object_0)
		{
			string result;
			if (DateTime.Parse(object_0.ToString()) < DateTime.Now)
			{
				result = begin.ToString();
			}
			else if (ProductIsSpellDetail.Isfinished == "1")
			{
				result = "1900-1-1";
			}
			else
			{
				result = object_0.ToString();
			}
			return result;
		}
		public static string IsShow(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "0")
			{
				result = "否";
			}
			else if (a == "1")
			{
				result = "是";
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static int GetCount(object PanicBuyCount, object SaledNum)
		{
			int result;
			if (!string.IsNullOrEmpty(SaledNum.ToString()))
			{
				int num = int.Parse(PanicBuyCount.ToString()) - int.Parse(SaledNum.ToString());
				if (num > 0)
				{
					result = num;
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = int.Parse(PanicBuyCount.ToString());
			}
			return result;
		}
		public static string SetNotNull(object JoinMemNum)
		{
			string result;
			if (!string.IsNullOrEmpty(JoinMemNum.ToString()))
			{
				result = JoinMemNum.ToString();
			}
			else
			{
				result = "0";
			}
			return result;
		}
		public static string returnImagePath(object object_0)
		{
			string newValue = "http://" + ProductIsSpellDetail.MemLoginID + ConfigurationManager.AppSettings["Domain"];
			return object_0.ToString().Replace("~/", newValue);
		}
	}
}
