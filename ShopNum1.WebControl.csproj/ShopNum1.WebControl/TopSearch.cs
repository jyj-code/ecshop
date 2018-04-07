using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class TopSearch : BaseWebControl
	{
		private string string_0 = "TopSearch.ascx";
		private HiddenField hiddenField_0;
		private Button button_0;
		public TopSearch()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenSwitchType");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Check(this.Page.Request.Form["textfield"].ToString().Trim().Replace("/", ""), Convert.ToInt32(this.hiddenField_0.Value));
		}
		protected void Check(string name, int type)
		{
			ShopNum1_KeyWords_Action shopNum1_KeyWords_Action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
			DataTable dataTable = shopNum1_KeyWords_Action.CheckIsExist(name, type);
			int count = dataTable.Rows.Count;
			if (count > 0)
			{
				if (type == 1)
				{
					this.method_1(name, 1, Convert.ToInt32(dataTable.Rows[0]["Count"].ToString()) + 1);
					this.Page.Response.Redirect(GetPageName.RetUrl("ProductListSearch", Operator.FilterString(name), "search") + "&pv=1");
				}
				else if (type == 2)
				{
					this.method_1(name, 2, Convert.ToInt32(dataTable.Rows[0]["Count"].ToString()) + 1);
					this.Page.Response.Redirect(GetPageName.RetUrl("ShopListSearch", Operator.FilterString(name), "search") + "&pv=2");
				}
				else if (type == 3)
				{
					this.method_1(name, 3, Convert.ToInt32(dataTable.Rows[0]["Count"].ToString()) + 1);
					this.Page.Response.Redirect(GetPageName.RetUrl("ArticleListSearch", Operator.FilterString(name), "search") + "&pv=3");
				}
				else if (type == 4)
				{
					this.method_1(name, 4, Convert.ToInt32(dataTable.Rows[0]["Count"].ToString()) + 1);
					this.Page.Response.Redirect(GetPageName.RetUrl("CategoryListSearch", Operator.FilterString(name), "search") + "&pv=4");
				}
				else if (type == 5)
				{
					this.method_1(name, 5, Convert.ToInt32(dataTable.Rows[0]["Count"].ToString()) + 1);
					this.Page.Response.Redirect(GetPageName.RetUrl("SupplyDemandListSearch", Operator.FilterString(name), "search") + "&pv=5");
				}
			}
			else if (type == 1)
			{
				this.method_0(name, 1);
				this.Page.Response.Redirect(GetPageName.RetUrl("ProductListSearch", Operator.FilterString(name), "search") + "&pv=1");
			}
			else if (type == 2)
			{
				this.method_0(name, 2);
				this.Page.Response.Redirect(GetPageName.RetUrl("ShopListSearch", Operator.FilterString(name), "search") + "&pv=2");
			}
			else if (type == 3)
			{
				this.method_0(name, 3);
				this.Page.Response.Redirect(GetPageName.RetUrl("ArticleListSearch", Operator.FilterString(name), "search") + "&pv=3");
			}
			else if (type == 4)
			{
				this.method_0(name, 4);
				this.Page.Response.Redirect(GetPageName.RetUrl("CategoryListSearch", Operator.FilterString(name), "search") + "&pv=4");
			}
			else if (type == 5)
			{
				this.method_0(name, 5);
				this.Page.Response.Redirect(GetPageName.RetUrl("SupplyDemandListSearch", Operator.FilterString(name), "search") + "&pv=5");
			}
		}
		private void method_0(string string_1, int int_0)
		{
			ShopNum1_KeyWords shopNum1_KeyWords = new ShopNum1_KeyWords();
			shopNum1_KeyWords.Guid = Guid.NewGuid();
			shopNum1_KeyWords.Name = string_1;
			shopNum1_KeyWords.Type = int_0;
			shopNum1_KeyWords.IfShow = 0;
			shopNum1_KeyWords.Count = 1;
			shopNum1_KeyWords.CreateTime = DateTime.Now;
			shopNum1_KeyWords.CreateUser = string.Empty;
			shopNum1_KeyWords.ModifyTime = DateTime.Now;
			shopNum1_KeyWords.ModifyUser = string.Empty;
			shopNum1_KeyWords.IsDeleted = 0;
			ShopNum1_KeyWords_Action shopNum1_KeyWords_Action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
			shopNum1_KeyWords_Action.Add(shopNum1_KeyWords);
		}
		private void method_1(string string_1, int int_0, int int_1)
		{
			ShopNum1_KeyWords_Action shopNum1_KeyWords_Action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
			shopNum1_KeyWords_Action.UpdateCount(string_1, int_0, int_1);
		}
	}
}
