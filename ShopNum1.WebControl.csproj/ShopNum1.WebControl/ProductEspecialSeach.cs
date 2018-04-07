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
	public class ProductEspecialSeach : BaseWebControl
	{
		private string string_0 = "ProductEspecialSeach.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string ShowCount
		{
			get;
			set;
		}
		public string ProductType
		{
			get;
			set;
		}
		public string Title
		{
			get;
			set;
		}
		public ProductEspecialSeach()
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
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable dataTable = shopNum1_ProuductChecked_Action.SearchEspecialProduct(this.ShowCount, this.ProductType);
			if (dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
		}
	}
}
