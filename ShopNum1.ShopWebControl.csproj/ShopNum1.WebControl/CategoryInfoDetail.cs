using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	public class CategoryInfoDetail : BaseWebControl
	{
		private string string_0 = "CategoryInfoDetail.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string StrGuid
		{
			get;
			set;
		}
		public CategoryInfoDetail()
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
			Shop_CategoryInfo_Action shop_CategoryInfo_Action = (Shop_CategoryInfo_Action)LogicFactory.CreateShop_CategoryInfo_Action();
			DataTable dataSource = shop_CategoryInfo_Action.CategoryInfoDetail(this.StrGuid);
			this.repeater_0.DataSource = dataSource;
			this.repeater_0.DataBind();
		}
	}
}
