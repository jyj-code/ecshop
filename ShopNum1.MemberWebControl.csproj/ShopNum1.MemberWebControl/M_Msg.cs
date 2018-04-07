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
	public class M_Msg : BaseMemberWebControl
	{
		private string string_0 = "M_Msg.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private string string_1;
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string PageSize
		{
			get;
			set;
		}
		public M_Msg()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepMsg");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.string_1 = ((ShopNum1.Common.Common.ReqStr("PageID") == "") ? "1" : ShopNum1.Common.Common.ReqStr("PageID"));
			this.string_2 = ((ShopNum1.Common.Common.ReqStr("IsRead") == "") ? "0" : ShopNum1.Common.Common.ReqStr("IsRead"));
			this.repeater_0 = (Repeater)skin.FindControl("RepMsg");
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_MemberMessage shopNum1_MemberMessage = new ShopNum1_MemberMessage();
			shopNum1_MemberMessage.IsRead = new int?((int)Convert.ToByte(this.string_2));
			ShopNum1_MemberMessage_Action shopNum1_MemberMessage_Action = (ShopNum1_MemberMessage_Action)LogicFactory.CreateShopNum1_MemberMessage_Action();
			CommonPageModel commonPageModel = new CommonPageModel();
			if (ShopNum1.Common.Common.ReqStr("isread") == "2")
			{
				commonPageModel.Condition = " and isdeleted=0  AND  SendLoginID='" + this.MemLoginID + "'";
			}
			else
			{
				commonPageModel.Condition = string.Concat(new string[]
				{
					" and isdeleted=0 and isread=",
					this.string_2,
					" AND   ReLoginID='",
					this.MemLoginID,
					"'   "
				});
			}
			commonPageModel.Currentpage = this.string_1.ToString();
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shopNum1_MemberMessage_Action.SelectMsg_List(commonPageModel);
			PageList1 pageList = new PageList1();
			pageList.PageSize = Convert.ToInt32(this.PageSize);
			pageList.PageID = Convert.ToInt32(this.string_1.ToString());
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("main/member/M_Msg.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shopNum1_MemberMessage_Action.SelectMsg_List(commonPageModel);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
