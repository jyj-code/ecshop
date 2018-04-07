using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_GroupProduct : BaseShopWebControl
	{
		private string string_0 = "S_GroupProduct.ascx";
		public static DataTable dt_GroupProduct = null;
		private HtmlGenericControl htmlGenericControl_0;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private Shop_GroupProduct_Action shop_GroupProduct_Action_0 = new Shop_GroupProduct_Action();
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public S_GroupProduct()
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
			if (!this.Page.IsPostBack)
			{
				this.method_0();
				this.method_2();
			}
		}
		private void method_0()
		{
			if (ShopNum1.Common.Common.ReqStr("sign") == "del" && ShopNum1.Common.Common.ReqStr("del") != "")
			{
				this.shop_GroupProduct_Action_0.DeleteGroupProduct(ShopNum1.Common.Common.ReqStr("del"), this.MemLoginID);
			}
		}
		private string method_1()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" AND MemloginId='" + this.MemLoginID + "'");
			return stringBuilder.ToString();
		}
		private void method_2()
		{
			if (this.PageSize.ToString() == "")
			{
				this.PageSize = 10;
			}
			string text = ShopNum1.Common.Common.ReqStr("PageID");
			if (text == "")
			{
				text = "1";
			}
			DataTable dataTable = this.shop_GroupProduct_Action_0.SelectActivity(this.PageSize.ToString(), text, this.method_1(), "0");
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageSize;
			pageList.PageID = Convert.ToInt32(text.ToString());
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("shop/ShopAdmin/S_GroupProduct.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			S_GroupProduct.dt_GroupProduct = this.shop_GroupProduct_Action_0.SelectActivity(this.PageSize.ToString(), text, this.method_1(), "1");
			if (S_GroupProduct.dt_GroupProduct.Rows.Count == 0)
			{
				S_GroupProduct.dt_GroupProduct = null;
			}
		}
	}
}
