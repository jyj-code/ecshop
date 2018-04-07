using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
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
	public class S_ProductBookingList : BaseShopWebControl
	{
		private string string_0 = "S_ProductBookingList.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private HtmlGenericControl htmlGenericControl_0;
		private LinkButton linkButton_0;
		private HiddenField hiddenField_0;
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
		public S_ProductBookingList()
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
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkDelete");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.hiddenField_0 = (HiddenField)skin.FindControl("hid_SelectGuid");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.repeater_0.ItemCommand += new RepeaterCommandEventHandler(this.repeater_0_ItemCommand);
			this.repeater_1 = (Repeater)skin.FindControl("Rep_NoValue");
			this.method_0();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			string value = this.hiddenField_0.Value;
			Shop_ProductBooking_Action shop_ProductBooking_Action = (Shop_ProductBooking_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductBooking_Action();
			if (shop_ProductBooking_Action.DeleteProductBooking(value) > 0)
			{
				MessageBox.Show("删除成功！");
				this.method_0();
			}
		}
		private void repeater_0_ItemCommand(object sender, RepeaterCommandEventArgs e)
		{
		}
		private void method_0()
		{
			Shop_ProductBooking_Action shop_ProductBooking_Action = (Shop_ProductBooking_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductBooking_Action();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			string str = shopNum1_ShopInfoList_Action.GetShopIDByMemLoginID(this.MemLoginID).Rows[0]["ShopID"].ToString();
			string text = string.Empty;
			if (!string.IsNullOrEmpty(this.MemLoginID))
			{
				text = text + "  AND  shopid=  '" + str + "'  ";
			}
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = "   " + text + "  ";
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Tablename = "ShopNum1_Shop_ProductBooking";
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shop_ProductBooking_Action.SelectProductBook_List(commonPageModel);
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
			PageListBll pageListBll = new PageListBll("/Shop/ShopAdmin/S_ProductBookingList.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shop_ProductBooking_Action.SelectProductBook_List(commonPageModel);
			if (dataTable2.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable2;
				this.repeater_0.DataBind();
			}
			else
			{
				this.repeater_1.Visible = true;
				DataTable dataTable3 = new DataTable();
				dataTable3.Columns.Add("NoValue", typeof(string));
				DataRow dataRow = dataTable3.NewRow();
				dataRow["NoValue"] = "暂无数据";
				dataTable3.Rows.Add(dataRow);
				this.repeater_1.DataSource = dataTable3;
				this.repeater_1.DataBind();
			}
		}
		public static string IsOrNo(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "1")
			{
				result = "已预约";
			}
			else
			{
				result = "未预约";
			}
			return result;
		}
	}
}
