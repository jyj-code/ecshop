using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class W_ShopMember : BaseShopWebControl
	{
		private string string_0 = "W_ShopMember.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private LinkButton linkButton_0;
		private HiddenField hiddenField_0;
		private int int_0 = 10;
		public W_ShopMember()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("rep_WeiXinUser");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkDelete");
			this.hiddenField_0 = (HiddenField)skin.FindControl("hid_SelectVip");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.method_0();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			IShopNum1_Weixin_ShopMember_Active shopNum1_Weixin_ShopMember_Active = new ShopNum1_Weixin_ShopMember_Active();
			shopNum1_Weixin_ShopMember_Active.ChangeVipGroup(this.MemLoginID, this.hiddenField_0.Value, 1);
			this.method_0();
		}
		private void method_0()
		{
			if (this.int_0.ToString() == "")
			{
				this.int_0 = 10;
			}
            string text = ShopNum1.Common.Common.ReqStr("PageID");
			if (text == "")
			{
				text = "1";
			}
			IShopNum1_Weixin_ShopMember_Active shopNum1_Weixin_ShopMember_Active = new ShopNum1_Weixin_ShopMember_Active();
			DataTable dataTable = shopNum1_Weixin_ShopMember_Active.SelectActivity(this.int_0.ToString(), text, this.method_1(), "0");
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.int_0;
			pageList.PageID = Convert.ToInt32(text.ToString());
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("shop/ShopAdmin/W_ShopMember.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			DataTable dataSource = shopNum1_Weixin_ShopMember_Active.SelectActivity(this.int_0.ToString(), text, this.method_1(), "1");
			this.repeater_0.DataSource = dataSource;
			this.repeater_0.DataBind();
		}
		private string method_1()
		{
			return string.Format(" AND ShopMemLoginId = '{0}'", this.MemLoginID);
		}
	}
}
