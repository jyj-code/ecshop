using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_FeedBack : BaseMemberWebControl
	{
		private string string_0 = "M_FeedBack.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private DataTable dataTable_0 = null;
		public M_FeedBack()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("divPage");
			this.repeater_0 = (Repeater)skin.FindControl("repBingComment");
			Shop_ProductComment_Action arg_36_0 = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			string text = " and memloginid='" + this.MemLoginID + "'";
			if (ShopNum1.Common.Common.ReqStr("type") == "1")
			{
				text += " and reply!=''";
			}
			int pageSize = 10;
			Shop_ProductComment_Action shop_ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
			int pageID = 1;
			if (ShopNum1.Common.Common.ReqStr("pageid") != "")
			{
				pageID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			DataTable dataTable = shop_ProductComment_Action.SelectShopComment(pageSize.ToString(), pageID.ToString(), text, "0");
			int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			PageListBll pageListBll = new PageListBll("main/member/M_FeedBack.aspx", true);
			PageList1 pageList = new PageList1();
			pageList.PageSize = pageSize;
			pageList.PageID = pageID;
			pageList.RecordCount = recordCount;
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			this.dataTable_0 = shop_ProductComment_Action.SelectShopComment(pageSize.ToString(), pageID.ToString(), text, "1");
			this.repeater_0.DataSource = this.dataTable_0.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
