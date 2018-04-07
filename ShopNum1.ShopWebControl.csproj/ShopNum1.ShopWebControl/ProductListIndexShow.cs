using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductListIndexShow : BaseWebControl
	{
		private string string_0 = "ProductListIndexShow.ascx";
		private Label label_0;
		private Repeater repeater_0;
		private LinkButton linkButton_0;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private int int_1;
		public int ShowType
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public int ShowCount
		{
			get;
			set;
		}
		public ProductListIndexShow()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelTitle");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonURL");
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			if (this.Page.IsPostBack)
			{
			}
			this.linkButton_0.PostBackUrl = string.Concat(new string[]
			{
				"http://",
				this.Page.Request.Url.Host,
				"/ProductListIndexShowMore.html?type=",
				this.ShowType.ToString(),
				"&select=1"
			});
			switch (this.ShowType)
			{
			case 1:
				this.label_0.Text = "热卖";
				this.method_1();
				break;
			case 2:
				this.label_0.Text = "新品";
				this.method_0();
				break;
			case 3:
				this.label_0.Text = "促销";
				this.method_3();
				break;
			case 4:
				this.label_0.Text = "推荐";
				this.method_2();
				break;
			}
		}
		private void method_0()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			DataTable isProductAndRecommend = shop_Product_Action.GetIsProductAndRecommend("1", "-1", "-1", "-1", "0", "0", this.ShowCount.ToString(), "Modifytime", this.MemLoginID);
			this.repeater_0.DataSource = isProductAndRecommend;
			this.repeater_0.DataBind();
		}
		private void method_1()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			DataTable isProductAndRecommend = shop_Product_Action.GetIsProductAndRecommend("-1", "1", "-1", "-1", "0", "0", this.ShowCount.ToString(), "Modifytime", this.MemLoginID);
			this.repeater_0.DataSource = isProductAndRecommend;
			this.repeater_0.DataBind();
		}
		private void method_2()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			DataTable isProductAndRecommend = shop_Product_Action.GetIsProductAndRecommend("-1", "-1", "-1", "1", "0", "0", this.ShowCount.ToString(), "Modifytime", this.MemLoginID);
			this.repeater_0.DataSource = isProductAndRecommend;
			this.repeater_0.DataBind();
		}
		private void method_3()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			DataTable isProductAndRecommend = shop_Product_Action.GetIsProductAndRecommend("-1", "-1", "1", "-1", "0", "0", this.ShowCount.ToString(), "Modifytime", this.MemLoginID);
			this.repeater_0.DataSource = isProductAndRecommend;
			this.repeater_0.DataBind();
		}
	}
}
