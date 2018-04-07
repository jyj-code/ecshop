using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ComplaintsReplyDetail : BaseWebControl
	{
		private string string_0 = "ComplaintsReplyDetail.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string strGuid
		{
			get;
			set;
		}
		public ComplaintsReplyDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				this.Page.Response.Write("<script> window.alert(\"对不起，请重新登陆！\");  window.location.href='Login.aspx'</script>");
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.strGuid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"]);
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ComplaintsManagement_Action shopNum1_ComplaintsManagement_Action = (ShopNum1_ComplaintsManagement_Action)LogicFactory.CreateShopNum1_ComplaintsManagement_Action();
			DataSet complaintsManagementDetail = shopNum1_ComplaintsManagement_Action.GetComplaintsManagementDetail(this.strGuid);
			if (complaintsManagementDetail.Tables[0].Rows.Count > 0)
			{
				this.repeater_0.DataSource = complaintsManagementDetail.Tables[0];
				this.repeater_0.DataBind();
				if (complaintsManagementDetail.Tables[1].Rows.Count > 0)
				{
					foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
					{
						Repeater repeater = (Repeater)repeaterItem.FindControl("RepeaterShow");
						repeater.DataSource = complaintsManagementDetail.Tables[1];
						repeater.DataBind();
					}
				}
			}
		}
	}
}
