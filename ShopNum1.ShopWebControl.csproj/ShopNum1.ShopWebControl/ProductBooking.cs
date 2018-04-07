using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductBooking : BaseWebControl
	{
		private string string_0 = "ProductBooking.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private TextBox textBox_6;
		private TextBox textBox_7;
		private Button button_0;
		private HtmlInputReset htmlInputReset_0;
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		public string ShopID
		{
			get;
			set;
		}
		public string Guid
		{
			get;
			set;
		}
		public string ProductName
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public string ShopName
		{
			get;
			set;
		}
		public ProductBooking()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectLogin();
			}
			this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			this.Guid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"]);
			this.ProductName = ((this.Page.Request.QueryString["productName"] == null) ? "0" : this.Page.Request.QueryString["productName"]);
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemLoginID = ((httpCookie.Values["MemLoginID"].ToString() == null) ? "" : httpCookie.Values["MemLoginID"].ToString());
				this.string_1 = ((httpCookie.Values["Name"].ToString() == null) ? "" : httpCookie.Values["Name"].ToString());
			}
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable shopInfo = shop_ShopInfo_Action.GetShopInfo(this.ShopID);
			try
			{
				this.ShopName = shopInfo.Rows[0]["ShopName"].ToString();
			}
			catch
			{
			}
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxName");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxEmail");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxAddress");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxPostalcode");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxTel");
			this.textBox_5 = (TextBox)skin.FindControl("TextBoxMobile");
			this.textBox_7 = (TextBox)skin.FindControl("TextBoxRank");
			this.textBox_6 = (TextBox)skin.FindControl("TextBoxSendDate");
			this.htmlInputReset_0 = (HtmlInputReset)skin.FindControl("inputReset");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Shop_ProductBooking shopNum1_Shop_ProductBooking = new ShopNum1_Shop_ProductBooking();
			shopNum1_Shop_ProductBooking.Name = this.textBox_0.Text.Trim();
			shopNum1_Shop_ProductBooking.ProductGuid = this.Guid;
			shopNum1_Shop_ProductBooking.ProductName = this.ProductName;
			shopNum1_Shop_ProductBooking.Email = this.textBox_1.Text.Trim();
			shopNum1_Shop_ProductBooking.Address = this.textBox_2.Text.Trim();
			shopNum1_Shop_ProductBooking.Postalcode = this.textBox_3.Text.Trim();
			shopNum1_Shop_ProductBooking.Tel = this.textBox_4.Text.Trim();
			shopNum1_Shop_ProductBooking.Mobile = this.textBox_5.Text.Trim();
			shopNum1_Shop_ProductBooking.SendDate = Convert.ToDateTime(this.textBox_6.Text.Trim());
			shopNum1_Shop_ProductBooking.Rank = this.textBox_7.Text.Trim();
			shopNum1_Shop_ProductBooking.IsAudit = 0;
			shopNum1_Shop_ProductBooking.MemLoginID = this.MemLoginID;
			shopNum1_Shop_ProductBooking.ShopID = this.ShopID;
			Shop_ProductBooking_Action shop_ProductBooking_Action = (Shop_ProductBooking_Action)LogicFactory.CreateShop_ProductBooking_Action();
			int num = shop_ProductBooking_Action.AddProductBooking(shopNum1_Shop_ProductBooking);
			if (num > 0)
			{
				MessageBox.Show("预约成功");
				this.ClearControl();
			}
			else
			{
				MessageBox.Show("预约失败！");
			}
		}
		protected void ClearControl()
		{
			this.textBox_0.Text = string.Empty;
			this.textBox_1.Text = string.Empty;
			this.textBox_2.Text = string.Empty;
			this.textBox_3.Text = string.Empty;
			this.textBox_4.Text = string.Empty;
			this.textBox_5.Text = string.Empty;
			this.textBox_6.Text = string.Empty;
			this.textBox_7.Text = string.Empty;
		}
	}
}
