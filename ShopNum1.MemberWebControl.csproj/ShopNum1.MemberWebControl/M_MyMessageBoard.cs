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
	public class M_MyMessageBoard : BaseMemberWebControl
	{
		private string string_0 = "M_MyMessageBoard.ascx";
		private DropDownList dropDownList_0;
		private Button button_0;
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private DropDownList dropDownList_1;
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
		public M_MyMessageBoard()
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
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListMessageType");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListIsReply");
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_0();
		}
		public static string GetShopName(string MemLoginID)
		{
			string result = string.Empty;
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("ShopName", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + MemLoginID + "'   ");
				if (!string.IsNullOrEmpty(nameById))
				{
					result = nameById;
				}
			}
			catch (Exception)
			{
			}
			return result;
		}
		public static string GetMessageTypeName(string MessageType)
		{
			string result;
			switch (MessageType)
			{
			case "0":
				result = "售后";
				return result;
			case "1":
				result = "询问";
				return result;
			case "2":
				result = "一般消息";
				return result;
			case "3":
				result = "求购";
				return result;
			case "4":
				result = "留言";
				return result;
			case "5":
				result = "重要消息";
				return result;
			}
			result = "其它";
			return result;
		}
		private void method_0()
		{
			Shop_MessageBoard_Action shop_MessageBoard_Action = (Shop_MessageBoard_Action)LogicFactory.CreateShop_MessageBoard_Action();
			string text = string.Empty;
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				text = text + "  AND  MessageType=  '" + this.dropDownList_0.SelectedValue + "'   ";
			}
			if (this.dropDownList_1.SelectedValue != "-1")
			{
				text = text + "  AND    IsReply=  '" + this.dropDownList_1.SelectedValue + "'   ";
			}
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = string.Concat(new string[]
			{
				"  AND   1=1   ",
				text,
				"     AND    MemLoginID='",
				this.MemLoginID,
				"'  "
			});
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shop_MessageBoard_Action.SelectMyShopMessageBoard_List(commonPageModel);
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
			PageListBll pageListBll = new PageListBll("main/member/M_MyMessageBoard.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shop_MessageBoard_Action.SelectMyShopMessageBoard_List(commonPageModel);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
