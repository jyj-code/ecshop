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
	public class ShopIsCategoryShowDiff : BaseWebControl
	{
		private string string_0 = "ShopIsCategoryShowDiff.ascx";
		private Repeater repeater_0;
		private HiddenField hiddenField_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string ShowCount
		{
			get;
			set;
		}
		public string ShowType
		{
			get;
			set;
		}
		public ShopIsCategoryShowDiff()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			Image image = (Image)e.Item.FindControl("ImageReputation");
			this.hiddenField_0 = (HiddenField)e.Item.FindControl("HiddenFieldReputation");
			ShopNum1_Reputation_Action shopNum1_Reputation_Action = (ShopNum1_Reputation_Action)LogicFactory.CreateShopNum1_Reputation_Action();
			DataTable dataTable = shopNum1_Reputation_Action.ShopReputationSearch(this.hiddenField_0.Value.ToString(), "0", "1");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				image.ImageUrl = "~/" + dataTable.Rows[0]["Pic"].ToString();
			}
		}
		private void method_0()
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable dataTable = shopNum1_ShopInfoList_Action.SearchEspecialShopList(this.ShowCount, this.ShowType);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
