using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShipperList : BaseShopWebControl
	{
		private HiddenField hiddenField_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private Repeater repeater_0;
		private IShopNum1_Shipper_Action ishopNum1_Shipper_Action_0 = new ShopNum1_Shipper_Action();
		public string shopid
		{
			get
			{
				HttpCookie httpCookie = HttpSecureCookie.Decode(this.Page.Request.Cookies["MemberLoginCookie"]);
				return httpCookie.Values["shopid"].ToString();
			}
		}
		public S_ShipperList()
		{
			if (string.IsNullOrEmpty(base.SkinFilename))
			{
				base.SkinFilename = "S_ShipperList.ascx";
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("rlist");
			this.hiddenField_0 = (HiddenField)skin.FindControl("CheckGuid");
			this.linkButton_0 = (LinkButton)skin.FindControl("ButtonAdd");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("ButtonEdit");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2 = (LinkButton)skin.FindControl("ButtonDelete");
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			DataTable dataTable = this.ishopNum1_Shipper_Action_0.Search("And ShopId='" + this.shopid + "'");
			this.repeater_0.DataSource = dataTable.DefaultView;
			this.repeater_0.DataBind();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_OrderShipper_Operate.aspx");
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_OrderShipper_Operate.aspx?Guid=" + this.hiddenField_0.Value);
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			int num = this.ishopNum1_Shipper_Action_0.Delete(this.hiddenField_0.Value.ToString());
			if (num > 0)
			{
				this.method_0();
			}
			else
			{
				MessageBox.Show("删除失败!");
			}
		}
	}
}
