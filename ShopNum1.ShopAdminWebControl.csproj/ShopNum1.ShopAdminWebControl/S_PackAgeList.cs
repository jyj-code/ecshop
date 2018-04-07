using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_PackAgeList : BaseShopWebControl
	{
		private string string_0 = "S_PackAgeList.ascx";
		private HtmlGenericControl htmlGenericControl_0;
		public static DataTable dt_PackAgeList = null;
		private Repeater repeater_0;
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public S_PackAgeList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.repeater_0 = (Repeater)skin.FindControl("repPackAge");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
				this.method_1();
			}
		}
		private void method_0()
		{
			if (ShopNum1.Common.Common.ReqStr("del") != "" && ShopNum1.Common.Common.ReqStr("sign") != "")
			{
				Shop_PackAge_Action shop_PackAge_Action = (Shop_PackAge_Action)LogicFactory.CreateShop_PackAge_Action();
				shop_PackAge_Action.DeletePackAge(ShopNum1.Common.Common.ReqStr("del"), this.MemLoginID);
			}
		}
		private void method_1()
		{
			Shop_PackAge_Action shop_PackAge_Action = (Shop_PackAge_Action)LogicFactory.CreateShop_PackAge_Action();
			int pageID = 1;
			if (ShopNum1.Common.Common.ReqStr("pageid") != "")
			{
				pageID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			DataTable dataTable = shop_PackAge_Action.SelectPackAgeProduct(this.PageSize.ToString(), pageID.ToString(), " and memloginid='" + this.MemLoginID + "'", "0", "desc", "createtime", "*", "ShopNum1_PackAge t");
			int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			PageListBll pageListBll = new PageListBll("shop/ShopAdmin/S_PackAgeList.aspx", true);
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageSize;
			pageList.PageID = pageID;
			pageList.RecordCount = recordCount;
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			S_PackAgeList.dt_PackAgeList = shop_PackAge_Action.SelectPackAgeProduct(this.PageSize.ToString(), pageID.ToString(), " and memloginid='" + this.MemLoginID + "'", "1", "desc", "createtime", "id,memloginid,name,price,saleprice,pic,(case state when '0' then '未开启' else '已开启' end)statetxt,(select count(*) from ShopNum1_PackAgeRalate where PackAgeId=t.id)pcount", "ShopNum1_PackAge t");
			this.repeater_0.DataSource = S_PackAgeList.dt_PackAgeList.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
