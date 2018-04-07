using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
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
	public class S_ThemeList : BaseShopWebControl
	{
		private string string_0 = "S_ThemeList.ascx";
		public static DataTable dt_GroupProduct = null;
		private HtmlGenericControl htmlGenericControl_0;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private Shop_GroupProduct_Action shop_GroupProduct_Action_0 = new Shop_GroupProduct_Action();
		private ShopNum1_Activity_Action shopNum1_Activity_Action_0 = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public S_ThemeList()
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
			string str = string.Empty;
			try
			{
				str = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + this.MemLoginID + "'   ");
			}
			catch (Exception)
			{
			}
			stringBuilder.Append(" AND ( SubstationID='" + str + "' OR   SubstationID='all' )   ");
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
			DataTable dataTable = this.shopNum1_Activity_Action_0.SelectShopThemeActivty(this.PageSize.ToString(), text, " group by A.SubstationID, A.Guid,A.ThemeTitle,A.ThemeDescription,A.ThemeStatus,A.CreateTime,A.StartDate,A.EndDate", "3");
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
			pageList.PageCount = pageList.RecordCount / pageList.PageSize;
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (pageList.PageID > pageList.PageCount)
			{
				pageList.PageID = pageList.PageCount;
			}
			PageListBll pageListBll = new PageListBll("shop/ShopAdmin/S_ThemeList.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			S_ThemeList.dt_GroupProduct = this.shopNum1_Activity_Action_0.SelectShopThemeActivty(this.PageSize.ToString(), pageList.PageID.ToString(), " group by A.SubstationID,A.Guid,A.ThemeTitle,A.ThemeDescription,A.ThemeStatus,A.CreateTime,A.StartDate,A.EndDate", "2");
			if (S_ThemeList.dt_GroupProduct.Rows.Count == 0)
			{
				S_ThemeList.dt_GroupProduct = null;
			}
		}
	}
}
