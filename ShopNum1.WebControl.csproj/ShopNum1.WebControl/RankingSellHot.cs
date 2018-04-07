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
	public class RankingSellHot : BaseWebControl
	{
		private string string_0 = "RankingSellHot.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string ShowCount
		{
			get;
			set;
		}
		public RankingSellHot()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
			DataTable dataTable = shopNum1_OrderProduct_Action.SearchRankingSellHot(this.ShowCount);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
