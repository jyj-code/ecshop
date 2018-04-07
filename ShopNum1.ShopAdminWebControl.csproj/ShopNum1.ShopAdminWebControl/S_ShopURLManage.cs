using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopURLManage : BaseShopWebControl
	{
		private string string_0 = "S_ShopURLManage.aspx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlAnchor htmlAnchor_0;
		private HtmlTable htmlTable_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string pageid
		{
			get;
			set;
		}
		public string PageSize
		{
			get;
			set;
		}
		public S_ShopURLManage()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.pageid = ((ShopNum1.Common.Common.ReqStr("PageID") == "") ? "1" : ShopNum1.Common.Common.ReqStr("PageID"));
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("wyss");
			this.htmlTable_0 = (HtmlTable)skin.FindControl("showTable");
			this.method_0();
		}
		public static string GetState(string value)
		{
			string result;
			if (value == "0")
			{
				result = "未审核";
			}
			else if (value == "1")
			{
				result = "审核通过";
			}
			else if (value == "2")
			{
				result = "审核未通过";
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string GetLongUrl(string string_3, string strMemLoginID)
		{
			string str = string.Empty;
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   and  MemLoginID='" + strMemLoginID + "'   ");
				string nameById2 = ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "   and    SubstationID='" + nameById + "'   ");
				if (!string.IsNullOrEmpty(nameById2))
				{
					str = "." + nameById2;
				}
			}
			catch (Exception)
			{
			}
			return string_3 + str + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'));
		}
		private void method_0()
		{
			Shop_URLManage_Action shop_URLManage_Action = (Shop_URLManage_Action)LogicFactory.CreateShop_URLManage_Action();
			string empty = string.Empty;
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = string.Concat(new string[]
			{
				"  AND   1=1   ",
				empty,
				"     AND  MemLoginID='",
				this.MemLoginID,
				"'  "
			});
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shop_URLManage_Action.Select_List(commonPageModel);
			PageList1 pageList = new PageList1();
			pageList.PageSize = Convert.ToInt32(this.PageSize);
			pageList.PageID = Convert.ToInt32(this.pageid.ToString());
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("Shop/ShopAdmin/S_ShopURLManage.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shop_URLManage_Action.Select_List(commonPageModel);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				this.htmlAnchor_0.Visible = false;
				this.htmlTable_0.Visible = false;
			}
		}
	}
}
