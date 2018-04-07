using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductListIsRecommend : BaseWebControl
	{
		private string string_0 = "ProductListIsRecommend.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private int int_0;
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
		public ProductListIsRecommend()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemCommand += new RepeaterCommandEventHandler(this.RepeaterData_ItemCommand);
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			DataTable isProductAndRecommend = shop_Product_Action.GetIsProductAndRecommend("-1", "-1", "-1", "1", "0", "0", this.ShowCount.ToString(), "CreateTime", this.MemLoginID);
			this.repeater_0.DataSource = isProductAndRecommend;
			this.repeater_0.DataBind();
		}
		protected void RepeaterData_ItemCommand(object sender, RepeaterCommandEventArgs e)
		{
			if (e.CommandName == "BtnProductCollect")
			{
				Literal literal = (Literal)e.Item.FindControl("LiteralMemLoginID");
				Literal literal2 = (Literal)e.Item.FindControl("LiteralGroupPrice");
				string text = literal2.Text;
				Literal literal3 = (Literal)e.Item.FindControl("LiteralProductName");
				string text2 = literal3.Text;
				Literal literal4 = (Literal)e.Item.FindControl("LiteralShopName");
				string text3 = literal4.Text;
				Literal literal5 = (Literal)e.Item.FindControl("LiteralProductGuid");
				string text4 = literal5.Text;
				string isAttention = "0";
				if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
				{
					HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					string text5 = httpCookie.Values["MemLoginID"].ToString();
					Shop_Collect_Action shop_Collect_Action = (Shop_Collect_Action)LogicFactory.CreateShop_Collect_Action();
					if (literal.Text == text5)
					{
						MessageBox.Show("您不能收藏自己的商品！");
					}
					else if (shop_Collect_Action.AddProductCollect(text5, text4, text3, isAttention, text, text2, literal.Text) > 0)
					{
						MessageBox.Show("收藏成功!");
						shop_Collect_Action.ProductCollectNum(text4);
					}
					else
					{
						MessageBox.Show("已收藏过该商品!");
					}
				}
				else
				{
					GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再收藏！");
				}
			}
		}
	}
}
