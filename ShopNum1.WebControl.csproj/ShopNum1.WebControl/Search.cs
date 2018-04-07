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
	public class Search : BaseWebControl
	{
		private string string_0 = "Search.ascx";
		private ImageButton imageButton_0;
		private DropDownList dropDownList_0;
		private TextBox textBox_0;
		public Search()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.imageButton_0 = (ImageButton)skin.FindControl("ImageButtonSearch");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListType");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxKeywords");
			this.imageButton_0.Click += new ImageClickEventHandler(this.imageButton_0_Click);
			if (!this.Page.IsPostBack && ShopNum1.Common.Common.ReqStr("pv") != "")
			{
				this.dropDownList_0.SelectedValue = ShopNum1.Common.Common.ReqStr("pv");
			}
		}
		private void imageButton_0_Click(object sender, ImageClickEventArgs e)
		{
			this.Check(this.textBox_0.Text, Convert.ToInt32(this.dropDownList_0.SelectedValue));
		}
		public void Check(string name, int type)
		{
			ShopNum1_KeyWords_Action shopNum1_KeyWords_Action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
			DataTable dataTable = shopNum1_KeyWords_Action.CheckIsExist(name, type);
			int count = dataTable.Rows.Count;
			if (count > 0)
			{
				if (this.dropDownList_0.SelectedValue == "0")
				{
					this.method_1(this.textBox_0.Text, 0, Convert.ToInt32(dataTable.Rows[0]["Count"].ToString()) + 1);
					this.Page.Response.Redirect(GetPageName.RetUrl("ProductListSearch", Operator.FilterString(this.textBox_0.Text.Trim()), "search") + "&pv=0");
				}
				else if (this.dropDownList_0.SelectedValue == "1")
				{
					this.method_1(this.textBox_0.Text, 1, Convert.ToInt32(dataTable.Rows[0]["Count"].ToString()) + 1);
					this.Page.Response.Redirect(GetPageName.RetUrl("ShopList", Operator.FilterString(this.textBox_0.Text.Trim()), "search") + "&pv=1");
				}
				else if (this.dropDownList_0.SelectedValue == "2")
				{
					this.method_1(this.textBox_0.Text, 2, Convert.ToInt32(dataTable.Rows[0]["Count"].ToString()) + 1);
					this.Page.Response.Redirect(GetPageName.RetUrl("ArticleListSearch", Operator.FilterString(this.textBox_0.Text.Trim()), "title") + "&pv=2");
				}
				else if (this.dropDownList_0.SelectedValue == "3")
				{
					this.method_1(this.textBox_0.Text, 3, Convert.ToInt32(dataTable.Rows[0]["Count"].ToString()) + 1);
					this.Page.Response.Redirect(GetPageName.RetUrl("Default", Operator.FilterString(this.textBox_0.Text.Trim()), "") + "&pv=3");
				}
				else if (this.dropDownList_0.SelectedValue == "4")
				{
					this.method_1(this.textBox_0.Text, 4, Convert.ToInt32(dataTable.Rows[0]["Count"].ToString()) + 1);
					this.Page.Response.Redirect(GetPageName.RetUrl("SupplyDemandListSearch", Operator.FilterString(this.textBox_0.Text.Trim()), "search") + "&pv=4");
				}
			}
			else if (this.dropDownList_0.SelectedValue == "0")
			{
				this.method_0(this.textBox_0.Text, 0);
				this.Page.Response.Redirect(GetPageName.RetUrl("ProductListSearch", Operator.FilterString(this.textBox_0.Text.Trim()), "search") + "&pv=0");
			}
			else if (this.dropDownList_0.SelectedValue == "1")
			{
				this.method_0(this.textBox_0.Text, 1);
				this.Page.Response.Redirect(GetPageName.RetUrl("ShopList", Operator.FilterString(this.textBox_0.Text.Trim()), "search") + "&pv=1");
			}
			else if (this.dropDownList_0.SelectedValue == "2")
			{
				this.method_0(this.textBox_0.Text, 2);
				this.Page.Response.Redirect(GetPageName.RetUrl("ArticleListSearch", Operator.FilterString(this.textBox_0.Text.Trim()), "title") + "&pv=2");
			}
			else if (this.dropDownList_0.SelectedValue == "3")
			{
				this.method_0(this.textBox_0.Text, 3);
				this.Page.Response.Redirect(GetPageName.RetUrl("Default", Operator.FilterString(this.textBox_0.Text.Trim()), "") + "&pv=3");
			}
			else if (this.dropDownList_0.SelectedValue == "4")
			{
				this.method_0(this.textBox_0.Text, 4);
				this.Page.Response.Redirect(GetPageName.RetUrl("SupplyDemandListSearch", Operator.FilterString(this.textBox_0.Text.Trim()), "search") + "&pv=4");
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
