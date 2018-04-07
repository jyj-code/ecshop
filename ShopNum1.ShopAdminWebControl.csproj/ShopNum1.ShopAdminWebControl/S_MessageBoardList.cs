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
	public class S_MessageBoardList : BaseShopWebControl
	{
		private string string_0 = "S_MessageBoardList.ascx";
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
		public S_MessageBoardList()
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
			this.repeater_0.ItemCommand += new RepeaterCommandEventHandler(this.repeater_0_ItemCommand);
			this.repeater_1 = (Repeater)skin.FindControl("Rep_NoValue");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkDelete");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.hiddenField_0 = (HiddenField)skin.FindControl("hid_SelectGuid");
			this.method_0();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			string value = this.hiddenField_0.Value;
			Shop_MessageBoard_Action shop_MessageBoard_Action = (Shop_MessageBoard_Action)LogicFactory.CreateShop_MessageBoard_Action();
			if (shop_MessageBoard_Action.DeleteMessageBoard(value) > 0)
			{
				MessageBox.Show("删除成功！");
				this.Page.Response.Redirect("S_MessageBoardList.aspx");
			}
		}
		private void repeater_0_ItemCommand(object sender, RepeaterCommandEventArgs e)
		{
			HtmlInputHidden htmlInputHidden = (HtmlInputHidden)e.Item.FindControl("hid_Guid");
			string value = htmlInputHidden.Value;
			if (e.CommandName == "delete")
			{
				Shop_MessageBoard_Action shop_MessageBoard_Action = (Shop_MessageBoard_Action)LogicFactory.CreateShop_MessageBoard_Action();
				if (shop_MessageBoard_Action.DeleteMessageBoard("'" + value + "'") > 0)
				{
					MessageBox.Show("删除成功！");
					this.Page.Response.Redirect("S_MessageBoardList.aspx");
				}
			}
		}
		private void method_0()
		{
			Shop_MessageBoard_Action shop_MessageBoard_Action = (Shop_MessageBoard_Action)LogicFactory.CreateShop_MessageBoard_Action();
			string text = string.Empty;
			if (!string.IsNullOrEmpty(this.MemLoginID))
			{
				text = text + "  AND  ReplyUser=  '" + this.MemLoginID + "'  ";
			}
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = "   " + text + "  ";
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Tablename = "ShopNum1_Shop_MessageBoard";
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shop_MessageBoard_Action.SelectMessageBoard_List(commonPageModel);
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
			PageListBll pageListBll = new PageListBll("/Shop/ShopAdmin/S_MessageBoardList.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shop_MessageBoard_Action.SelectMessageBoard_List(commonPageModel);
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
		public static string IsShow(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "0")
			{
				result = "否";
			}
			else if (a == "1")
			{
				result = "是";
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string IsType(object object_0)
		{
			string text = object_0.ToString();
			string text2 = text;
			string result;
			if (text2 != null)
			{
				if (text2 == "0")
				{
					result = "询问";
					return result;
				}
				if (text2 == "1")
				{
					result = "求购";
					return result;
				}
				if (text2 == "2")
				{
					result = "售后";
					return result;
				}
				if (text2 == "3")
				{
					result = "其它";
					return result;
				}
			}
			result = "其它";
			return result;
		}
	}
}
