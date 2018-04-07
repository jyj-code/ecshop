using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_UnAuditProduct : BaseShopWebControl
	{
		private string string_0 = "S_UnAuditProduct.ascx";
		public static DataTable dt_ShowProduct;
		private HtmlGenericControl htmlGenericControl_0;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private string string_5 = string.Empty;
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public S_UnAuditProduct()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.string_1 = ShopNum1.Common.Common.ReqStr("pn");
			this.string_2 = ShopNum1.Common.Common.ReqStr("no");
			this.string_3 = ShopNum1.Common.Common.ReqStr("sname");
			this.string_4 = ShopNum1.Common.Common.ReqStr("stype");
			this.string_5 = ShopNum1.Common.Common.ReqStr("shopct");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
				this.method_2();
			}
		}
		private void method_0()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			if (ShopNum1.Common.Common.ReqStr("sign") == "del" && ShopNum1.Common.Common.ReqStr("del") != "")
			{
				shop_Product_Action.DeleteShopProduct(ShopNum1.Common.Common.ReqStr("del"), this.MemLoginID);
			}
		}
		private string method_1()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" and memloginid='" + this.MemLoginID + "' and  isaudit in(0,2) ");
			if (this.string_5 != "")
			{
				stringBuilder.Append(" and productseriescode like '%" + HttpUtility.HtmlDecode(this.string_5) + "%' ");
			}
			if (this.string_1 != "")
			{
				stringBuilder.Append(" and name like '%" + HttpUtility.HtmlDecode(this.string_1).Replace(" ", "").Trim() + "%' ");
			}
			if (this.string_2 != "")
			{
				stringBuilder.Append(" and productnum like '%" + HttpUtility.HtmlDecode(this.string_2).Replace(" ", "").Trim() + "%' ");
			}
			return stringBuilder.ToString();
		}
		private void method_2()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			if (this.PageSize.ToString() == "")
			{
				this.PageSize = 10;
			}
			string text = ShopNum1.Common.Common.ReqStr("PageID");
			if (text == "")
			{
				text = "1";
			}
			DataTable productList = shop_Product_Action.GetProductList(this.PageSize.ToString(), text, this.method_1(), "0");
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageSize;
			pageList.PageID = Convert.ToInt32(text.ToString());
			if (productList != null && productList.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(productList.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("shop/ShopAdmin/S_UnAuditProduct.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			S_UnAuditProduct.dt_ShowProduct = shop_Product_Action.GetProductList(this.PageSize.ToString(), text, this.method_1(), "1");
			if (S_UnAuditProduct.dt_ShowProduct.Rows.Count == 0)
			{
				S_UnAuditProduct.dt_ShowProduct = null;
			}
		}
	}
}
