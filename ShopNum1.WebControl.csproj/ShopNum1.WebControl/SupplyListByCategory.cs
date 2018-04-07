using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SupplyListByCategory : BaseWebControl
	{
		private string string_0 = "all";
		private string string_1 = "SupplyListByCategory.ascx";
		private HtmlAnchor htmlAnchor_0;
		private Repeater repeater_0;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		public string ShowCount
		{
			get;
			set;
		}
		public string CategoryCode
		{
			get;
			set;
		}
		public string Titel
		{
			get;
			set;
		}
		public SupplyListByCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_0 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("Href");
			this.literal_0 = (Literal)skin.FindControl("LiteralTitel");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterSupplyFirst");
			if (!string.IsNullOrEmpty(this.CategoryCode))
			{
				this.htmlAnchor_0.HRef = GetPageName.RetUrl("SupplyDemandListSearch", this.CategoryCode, "code");
			}
			else
			{
				this.htmlAnchor_0.HRef = GetPageName.RetUrl("SupplyDemandListSearch");
			}
			this.BindData();
		}
		protected void BindData()
		{
			this.literal_0.Text = this.Titel;
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			DataTable dataTable = shopNum1_SupplyDemandCheck_Action.SearchByCategoryIDFrist(this.CategoryCode, this.string_0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
				foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
				{
					HiddenField hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldGuid");
					Repeater repeater = (Repeater)repeaterItem.FindControl("RepeaterData");
					DataTable dataTable2 = shopNum1_SupplyDemandCheck_Action.SearchByCategoryIDOther(this.CategoryCode, hiddenField.Value, this.ShowCount.ToString(), this.string_0);
					if (dataTable2.Rows.Count > 0)
					{
						repeater.DataSource = dataTable2.DefaultView;
						repeater.DataBind();
					}
				}
			}
		}
	}
}
