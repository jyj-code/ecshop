using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
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
	public class M_SysMsg : BaseMemberWebControl
	{
		private string string_0 = "M_SysMsg.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private string string_1;
		private string string_2;
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public M_SysMsg()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepMsg");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.string_1 = ((ShopNum1.Common.Common.ReqStr("PageID") == "") ? "1" : ShopNum1.Common.Common.ReqStr("PageID"));
			this.string_2 = ((ShopNum1.Common.Common.ReqStr("IsRead") == "") ? "0" : ShopNum1.Common.Common.ReqStr("IsRead"));
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label label = (Label)e.Item.FindControl("LabelMessageInfoGuid");
				ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
				DataTable dataTable = shopNum1_MessageInfo_Action.Get_SysMsgTitle(label.Text);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					label.Text = dataTable.Rows[0][0].ToString();
				}
			}
		}
		private void method_0()
		{
			ShopNum1_MessageInfo shopNum1_MessageInfo = new ShopNum1_MessageInfo();
			shopNum1_MessageInfo.IsRead = Convert.ToByte(this.string_2);
			ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = string.Concat(new string[]
			{
				" and IsDeleted=0  AND   ReceiveID='",
				this.MemLoginID,
				"'    AND  IsRead='",
				this.string_2,
				"'  "
			});
			commonPageModel.Currentpage = this.string_1.ToString();
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shopNum1_MessageInfo_Action.SelectSysUserMsg_List(commonPageModel);
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageSize;
			pageList.PageID = Convert.ToInt32(this.string_1.ToString());
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("main/member/M_sysMsg.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shopNum1_MessageInfo_Action.SelectSysUserMsg_List(commonPageModel);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
