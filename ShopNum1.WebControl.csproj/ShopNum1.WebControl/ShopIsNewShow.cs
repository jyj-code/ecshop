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
	public class ShopIsNewShow : BaseWebControl
	{
		private string string_0 = "ShopIsNewShow.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string ShowCount
		{
			get;
			set;
		}
		public ShopIsNewShow()
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
			DataTable newShopInfoByShowCount = shopNum1_ShopInfoList_Action.GetNewShopInfoByShowCount(this.ShowCount);
			if (newShopInfoByShowCount != null && newShopInfoByShowCount.Rows.Count > 0)
			{
				this.repeater_0.DataSource = newShopInfoByShowCount.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
