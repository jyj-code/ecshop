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
	public class ShopIsCategoryShow : BaseWebControl
	{
		private string string_0 = "ShopIsCategoryShow.ascx";
		private Repeater repeater_0;
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
		public ShopIsCategoryShow()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.method_0();
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
