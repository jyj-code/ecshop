using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	public class SupplyDetail : BaseWebControl
	{
		private string string_0 = "SupplyDetail.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string StrGuid
		{
			get;
			set;
		}
		public SupplyDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.StrGuid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"].ToString());
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterCommentList");
			this.method_0();
		}
		private void method_0()
		{
			Shop_SupplyDemand_Action shop_SupplyDemand_Action = (Shop_SupplyDemand_Action)LogicFactory.CreateShop_SupplyDemand_Action();
			DataTable dataSource = shop_SupplyDemand_Action.SupplyDemandDetail(this.StrGuid);
			this.repeater_0.DataSource = dataSource;
			this.repeater_0.DataBind();
		}
	}
}
