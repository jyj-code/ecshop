using ShopNum1.BusinessLogic;
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
	public class SupplyDemandAds : BaseWebControl
	{
		private string string_0 = "SupplyDemandAds.ascx";
		private Repeater repeater_0;
		private HtmlImage htmlImage_0;
		[CompilerGenerated]
		private string string_1;
		public string AdvID
		{
			get;
			set;
		}
		public SupplyDemandAds()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterContent");
			if (!this.Page.IsPostBack)
			{
				ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
				DataTable dataTable = shopNum1_Advertisement_Action.ShowADByDivID(this.AdvID);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					this.htmlImage_0 = (HtmlImage)skin.FindControl("ImgAdv");
					this.htmlImage_0.Src = this.Page.ResolveUrl("/" + dataTable.Rows[0]["content"].ToString());
					this.repeater_0.DataSource = dataTable.DefaultView;
					this.repeater_0.DataBind();
				}
			}
		}
	}
}
