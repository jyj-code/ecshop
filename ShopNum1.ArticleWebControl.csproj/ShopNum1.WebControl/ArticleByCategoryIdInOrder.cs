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
	public class ArticleByCategoryIdInOrder : BaseWebControl
	{
		private string string_0 = "ArticleByCategoryIdInOrder.ascx";
		private Repeater repeater_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private string string_2;
		public int ArticleCategoryID
		{
			get;
			set;
		}
		public int ShowCount
		{
			get;
			set;
		}
		public string Sort
		{
			get;
			set;
		}
		public ArticleByCategoryIdInOrder()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterArticleFirst");
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable dataTable = shopNum1_Article_Action.SearchByCategoryIDFrist(this.ArticleCategoryID, this.string_1);
			if (dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
				foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
				{
					HiddenField hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldGuid");
					Repeater repeater = (Repeater)repeaterItem.FindControl("RepeaterArticleNew");
					DataTable dataTable2 = shopNum1_Article_Action.SearchByCategoryIDOther(this.ArticleCategoryID, hiddenField.Value, this.ShowCount.ToString(), this.string_1);
					if (dataTable2.Rows.Count > 0)
					{
						repeater.DataSource = dataTable2.DefaultView;
						repeater.DataBind();
					}
				}
			}
		}
	}
}
