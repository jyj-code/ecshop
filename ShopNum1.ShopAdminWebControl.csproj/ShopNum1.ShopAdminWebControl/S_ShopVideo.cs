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
	public class S_ShopVideo : BaseShopWebControl
	{
		private string string_0 = "S_ShopVideo.ascx";
		private DropDownList dropDownList_0;
		private Button button_0;
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private DropDownList dropDownList_1;
		private TextBox textBox_0;
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
		public S_ShopVideo()
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
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListIsAudit");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxTitle");
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListIsRecommend");
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_0();
		}
		public static string GetCategoryName(string Guid)
		{
			Shop_VideoCategory_Action shop_VideoCategory_Action = (Shop_VideoCategory_Action)LogicFactory.CreateShop_VideoCategory_Action();
			DataTable videoCategory = shop_VideoCategory_Action.GetVideoCategory(Guid);
			string result;
			if (videoCategory != null && videoCategory.Rows.Count > 0)
			{
				result = videoCategory.Rows[0]["Name"].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string GetIsAudit(string IsAudit)
		{
			string result;
			if (IsAudit == "0")
			{
				result = "未审核";
			}
			else if (IsAudit == "1")
			{
				result = "审核通过";
			}
			else if (IsAudit == "2")
			{
				result = "审核未通过";
			}
			else
			{
				result = "";
			}
			return result;
		}
		private void method_0()
		{
			Shop_Video_Action shop_Video_Action = (Shop_Video_Action)LogicFactory.CreateShop_Video_Action();
			string text = string.Empty;
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				text = text + "  AND  IsAudit=  '" + this.dropDownList_0.SelectedValue + "'   ";
			}
			if (!string.IsNullOrEmpty(this.textBox_0.Text))
			{
				text = text + "  AND  Title LIKE   '%" + this.textBox_0.Text.Trim() + "%'   ";
			}
			if (this.dropDownList_1.SelectedValue != "-1")
			{
				text = text + "  AND  IsRecommend=  '" + this.dropDownList_1.SelectedValue + "'   ";
			}
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = string.Concat(new string[]
			{
				"  AND   1=1   ",
				text,
				"     AND  MemLoginID='",
				this.MemLoginID,
				"'  "
			});
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shop_Video_Action.Select_List(commonPageModel);
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
			PageListBll pageListBll = new PageListBll("Shop/ShopAdmin/S_ShopVideo.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shop_Video_Action.Select_List(commonPageModel);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
