using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_CouponList_Search : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected Label LabelTitle;
	protected Label Label3;
	protected TextBox TextBoxSaleTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label LabelWebSite;
	protected TextBox TextBoxCouponType;
	protected Label LabelOrderID;
	protected TextBox TextBoxStartTime;
	protected Label LabelLogo;
	protected TextBox TextBoxEndTime;
	protected Label Label1;
	protected TextBox TextBoxAdressName;
	protected Label Label2;
	protected Image ImageCoupon;
	protected HtmlAnchor ACoupon;
	protected Label LabelKeywords;
	protected TextBox FCKeditorContent;
	protected Button ButtonBack;
	protected HiddenField hiddenField1;
	protected HiddenField HiddenFieldCode;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	[CompilerGenerated]
	private string string_5;
	protected string Type
	{
		get;
		set;
	}
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		this.Type = ((base.Request.QueryString["Type"] == null) ? "0" : base.Request.QueryString["Type"]);
		if (!this.Page.IsPostBack)
		{
			this.GetCouponInfo();
		}
	}
	protected void GetCouponInfo()
	{
		Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)LogicFactory.CreateShop_Coupon_Action();
		DataTable couponInfoById = shop_Coupon_Action.GetCouponInfoById(this.hiddenFieldGuid.Value.Replace("'", ""));
		if (couponInfoById != null && couponInfoById.Rows.Count > 0)
		{
			this.TextBoxSaleTitle.Text = couponInfoById.Rows[0]["SaleTitle"].ToString();
			this.TextBoxName.Text = couponInfoById.Rows[0]["CouponName"].ToString();
			this.TextBoxCouponType.Text = couponInfoById.Rows[0]["Name"].ToString();
			this.TextBoxStartTime.Text = couponInfoById.Rows[0]["StartTime"].ToString();
			this.TextBoxEndTime.Text = couponInfoById.Rows[0]["EndTime"].ToString();
			string relativeUrl = couponInfoById.Rows[0]["ImgPath"].ToString();
			this.ACoupon.HRef = this.Page.ResolveUrl(relativeUrl);
			this.ImageCoupon.ImageUrl = this.Page.ResolveUrl(relativeUrl);
			this.TextBoxAdressName.Text = couponInfoById.Rows[0]["AdressName"].ToString();
			this.FCKeditorContent.Text = base.Server.HtmlDecode(couponInfoById.Rows[0]["Content"].ToString());
		}
	}
	public string GetWebFilePath(string MemloginID)
	{
		Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
		DataTable shopIDAndOpenTimeByMemLoginID = shop_ShopInfo_Action.GetShopIDAndOpenTimeByMemLoginID(MemloginID);
		string text = shopIDAndOpenTimeByMemLoginID.Rows[0]["ShopID"].ToString();
		string text2 = DateTime.Parse(shopIDAndOpenTimeByMemLoginID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
		string text3 = string.Concat(new string[]
		{
			"/ImgUpload/",
			text2.Replace("-", "/"),
			"/shop",
			text,
			"/Coupon/"
		});
		if (!Directory.Exists(HttpContext.Current.Server.MapPath(text3)))
		{
			Directory.CreateDirectory(HttpContext.Current.Server.MapPath(text3));
		}
		return text3;
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (this.Type == "List")
		{
			base.Response.Redirect("CouponList.aspx");
		}
		else if (this.Type == "Audit")
		{
			base.Response.Redirect("CouponList_Audit.aspx");
		}
	}
}
