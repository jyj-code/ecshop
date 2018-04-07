using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class DeArticleCategoryDetail : BaseWebControl
	{
		private string string_0 = "DeArticleCategoryDetail.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Repeater repeater_2;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
		public int CategoryID
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public DeArticleCategoryDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData1");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterData2");
			this.repeater_2 = (Repeater)skin.FindControl("RepeaterData3");
			this.ViewState["IDAll"] = this.GetAll(this.CategoryID).ToString();
			this.BindData1();
			this.BindData2();
			this.BindData3();
		}
		protected void BindData1()
		{
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable titleByID = shopNum1_Article_Action.GetTitleByID(this.ViewState["IDAll"].ToString(), "IsHead", this.ShowCount);
			if (titleByID != null && titleByID.Rows.Count > 0)
			{
				this.repeater_0.DataSource = titleByID.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		protected void BindData2()
		{
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable titleByID = shopNum1_Article_Action.GetTitleByID(this.ViewState["IDAll"].ToString(), "IsHot", this.ShowCount);
			if (titleByID != null && titleByID.Rows.Count > 0)
			{
				this.repeater_1.DataSource = titleByID.DefaultView;
				this.repeater_1.DataBind();
			}
		}
		protected void BindData3()
		{
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable titleByID = shopNum1_Article_Action.GetTitleByID(this.ViewState["IDAll"].ToString(), "IsRecommend", this.ShowCount);
			if (titleByID != null && titleByID.Rows.Count > 0)
			{
				this.repeater_2.DataSource = titleByID.DefaultView;
				this.repeater_2.DataBind();
			}
		}
		protected string GetAll(int CategoryID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("(" + CategoryID);
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			DataView defaultView = shopNum1_ArticleCategory_Action.SearchID(CategoryID).DefaultView;
			if (defaultView != null && defaultView.Count > 0)
			{
				foreach (DataRow dataRow in defaultView.Table.Rows)
				{
					int num = Convert.ToInt32(dataRow["ID"].ToString().Trim());
					stringBuilder.Append("," + num);
					DataView defaultView2 = shopNum1_ArticleCategory_Action.SearchID(num).DefaultView;
					if (defaultView2 != null && defaultView2.Count > 0)
					{
						foreach (DataRow dataRow2 in defaultView2.Table.Rows)
						{
							stringBuilder.Append("," + Convert.ToInt32(dataRow2["ID"].ToString().Trim()));
						}
					}
				}
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
	}
}
