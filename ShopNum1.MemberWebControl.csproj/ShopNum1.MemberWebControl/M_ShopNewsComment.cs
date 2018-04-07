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
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_ShopNewsComment : BaseMemberWebControl
	{
		private string string_0 = "M_ShopNewsComment.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private DropDownList dropDownList_0;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private Button button_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string type
		{
			get;
			set;
		}
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
		public M_ShopNewsComment()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListIsAudit");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.pageid = ((ShopNum1.Common.Common.ReqStr("PageID") == "") ? "1" : ShopNum1.Common.Common.ReqStr("PageID"));
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxSRegDate1");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxSRegDate2");
			this.button_0 = (Button)skin.FindControl("ButtonGet");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.type = ((ShopNum1.Common.Common.ReqStr("type") == "") ? "0" : ShopNum1.Common.Common.ReqStr("type"));
			this.method_0();
		}
		public static string GetTitle(string guid)
		{
			string result = string.Empty;
			Shop_News_Action shop_News_Action = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
			DataTable titleByGuid = shop_News_Action.GetTitleByGuid(guid);
			if (titleByGuid != null && titleByGuid.Rows.Count > 0)
			{
				result = titleByGuid.Rows[0][0].ToString();
			}
			return result;
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_0();
		}
		private void method_0()
		{
			Shop_News_Action shop_News_Action = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
			string text = string.Empty;
			if (!string.IsNullOrEmpty(this.textBox_0.Text.Trim()))
			{
				text = text + "  AND  CommentTime>'" + this.textBox_0.Text.Trim() + "'   ";
			}
			if (!string.IsNullOrEmpty(this.textBox_1.Text.Trim()))
			{
				text = text + "   AND  CommentTime<'" + this.textBox_1.Text.Trim() + "'  ";
			}
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				text = text + "   AND  IsAudit = '" + this.dropDownList_0.SelectedValue + "'  ";
			}
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = string.Concat(new string[]
			{
				" and 0=0    ",
				text,
				"   AND  MemLoginID='",
				this.MemLoginID,
				"'  "
			});
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shop_News_Action.Select_List(commonPageModel);
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
			PageListBll pageListBll = new PageListBll("main/member/M_Comment.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shop_News_Action.Select_List(commonPageModel);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
