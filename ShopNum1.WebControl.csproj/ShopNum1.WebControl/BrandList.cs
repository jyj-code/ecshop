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
	public class BrandList : BaseWebControl
	{
		private string string_0 = "BrandList.ascx";
		private Repeater repeater_0;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string ShowCount
		{
			get;
			set;
		}
		public string BrandCount
		{
			get;
			set;
		}
		public BrandList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterBrandCategory");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterBrandImg");
				Literal literal = (Literal)e.Item.FindControl("LiteralCode");
				if (literal.Text == "" || literal.Text == string.Empty)
				{
					repeater.DataSource = null;
					repeater.DataBind();
				}
				else
				{
					ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
					DataTable brandImgByCode = shopNum1_Brand_Action.GetBrandImgByCode(this.ShowCount, literal.Text.ToString());
					repeater.DataSource = brandImgByCode;
					repeater.DataBind();
				}
			}
		}
		private void method_0()
		{
			ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
			DataTable brandCategory = shopNum1_Brand_Action.GetBrandCategory(this.ShowCount);
			this.repeater_0.DataSource = brandCategory;
			this.repeater_0.DataBind();
		}
	}
}
