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
	public class DeProductOrder : BaseWebControl
	{
		private string string_0 = "DeProductOrder.ascx";
		private Repeater repeater_0;
		private Literal literal_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		public string OrderType
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public string Title
		{
			get;
			set;
		}
		public DeProductOrder()
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
			if (this.Page.IsPostBack)
			{
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.literal_0 = (Literal)skin.FindControl("LiteralTitle");
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable dataTable;
			if (this.string_1 == "all")
			{
				dataTable = shopNum1_ProuductChecked_Action.SearchProductOrder(this.ShowCount, this.OrderType);
			}
			else
			{
				dataTable = shopNum1_ProuductChecked_Action.SearchProductOrder(this.ShowCount, this.OrderType, this.string_1);
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
			this.literal_0.Text = this.Title;
		}
	}
}
