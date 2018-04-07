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
	public class DeShopEspecial : BaseWebControl
	{
		private string string_0 = "DeShopEspecial.ascx";
		private Repeater repeater_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string ShopType
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public DeShopEspecial()
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
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable dataTable;
			if (this.string_1 == "all")
			{
				dataTable = shopNum1_ShopInfoList_Action.SearchEspecialShop(this.ShowCount, this.ShopType);
			}
			else
			{
				dataTable = shopNum1_ShopInfoList_Action.SearchEspecialShop(this.ShowCount, this.ShopType, this.string_1);
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
