using ShopNum1.BusinessLogic;
using ShopNum1.Common;
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
	public class OnLineFootService : BaseWebControl
	{
		private string string_0 = "OnLineFootService.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Repeater repeater_2;
		private Repeater repeater_3;
		private Panel panel_0;
		private Repeater repeater_4;
		private string string_1 = "all";
		private Panel panel_1;
		private Panel panel_2;
		private Panel panel_3;
		private Label label_0;
		[CompilerGenerated]
		private int int_0;
		public int ShowCount
		{
			get;
			set;
		}
		public OnLineFootService()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterQQ");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterMSN");
			this.repeater_2 = (Repeater)skin.FindControl("RepeaterWW");
			this.repeater_3 = (Repeater)skin.FindControl("RepeaterKFT");
			this.repeater_4 = (Repeater)skin.FindControl("RepeaterPhone");
			this.panel_0 = (Panel)skin.FindControl("PanelShowServer");
			this.panel_1 = (Panel)skin.FindControl("PanelQQ");
			this.panel_2 = (Panel)skin.FindControl("PanelWW");
			this.panel_3 = (Panel)skin.FindControl("PanelPhone");
			this.label_0 = (Label)skin.FindControl("Lab_ServerPhone");
			if (this.Page.IsPostBack)
			{
			}
			this.method_1();
			this.method_0();
			this.method_2();
		}
		private void method_0()
		{
			if (this.string_1 == "all")
			{
				string value = ShopSettings.GetValue("ShowCustomer");
				string value2 = ShopSettings.GetValue("IsOpenPhone");
				string value3 = ShopSettings.GetValue("ServerPhone");
				if (value == "1")
				{
					this.panel_0.Visible = true;
				}
				else if (value == "0")
				{
					this.panel_0.Visible = false;
				}
				if (value2 == "1")
				{
					this.panel_3.Visible = true;
					this.label_0.Text = value3;
				}
				else if (value2 == "0")
				{
					this.panel_3.Visible = false;
				}
			}
			else
			{
				string value4 = CitySettings.GetValue("ShowCustomer", this.string_1);
				string value5 = CitySettings.GetValue("IsOpenPhone", this.string_1);
				string value6 = CitySettings.GetValue("ServerPhone", this.string_1);
				if (value4 == "1")
				{
					this.panel_0.Visible = true;
				}
				else if (value4 == "0")
				{
					this.panel_0.Visible = false;
				}
				if (value5 == "1")
				{
					this.panel_3.Visible = true;
					this.label_0.Text = value6;
				}
				else if (value5 == "0")
				{
					this.panel_3.Visible = false;
				}
			}
		}
		private void method_1()
		{
			ShopNum1_OnLineService_Action shopNum1_OnLineService_Action = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
			DataTable dataTable = shopNum1_OnLineService_Action.SearchTypeInfo("QQ", 1, this.ShowCount, this.string_1);
			if (dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
			else
			{
				this.panel_1.Visible = false;
			}
		}
		private void method_2()
		{
			ShopNum1_OnLineService_Action shopNum1_OnLineService_Action = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
			DataTable dataTable = shopNum1_OnLineService_Action.SearchTypeInfo("WW", 1, this.ShowCount, this.string_1);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_2.DataSource = dataTable;
				this.repeater_2.DataBind();
			}
			else
			{
				this.panel_2.Visible = false;
			}
		}
	}
}
