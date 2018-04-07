using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopNewsEdit : BaseShopWebControl
	{
		private string string_0 = "S_ShopNewsEdit.ascx";
		private Label label_0;
		private TextBox textBox_0;
		private DropDownList dropDownList_0;
		private TextBox textBox_1;
		private CheckBox checkBox_0;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private Button button_0;
		private Button button_1;
		private HiddenField hiddenField_0;
		private Shop_News_Action shop_News_Action_0 = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
		public S_ShopNewsEdit()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelTitle");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxTitle");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListNewsCategory");
			this.textBox_1 = (TextBox)skin.FindControl("TexteditorContent");
			this.checkBox_0 = (CheckBox)skin.FindControl("CheckBoxIsShow");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxSEOTitle");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxKeywords");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxDescription");
			this.button_0 = (Button)skin.FindControl("ButtonSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGuid");
			this.GetShopNewsCategory();
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.hiddenField_0.Value = this.Page.Request.QueryString["guid"].ToString();
				this.label_0.Text = "编辑资讯";
				this.GetDataInfo();
			}
			else
			{
				this.label_0.Text = "添加资讯";
			}
		}
		public void GetDataInfo()
		{
			DataTable newsByGuidAndMemLoginID = this.shop_News_Action_0.GetNewsByGuidAndMemLoginID(this.Page.Request.QueryString["guid"].ToString(), this.MemLoginID);
			if (newsByGuidAndMemLoginID != null && newsByGuidAndMemLoginID.Rows.Count > 0)
			{
				this.textBox_0.Text = newsByGuidAndMemLoginID.Rows[0]["Title"].ToString();
				this.dropDownList_0.SelectedValue = newsByGuidAndMemLoginID.Rows[0]["NewsCategoryGuid"].ToString();
				this.textBox_1.Text = newsByGuidAndMemLoginID.Rows[0]["Content"].ToString();
				if (newsByGuidAndMemLoginID.Rows[0]["IsShow"].ToString() == "1")
				{
					this.checkBox_0.Checked = true;
				}
				else
				{
					this.checkBox_0.Checked = false;
				}
				this.textBox_2.Text = newsByGuidAndMemLoginID.Rows[0]["SEOTitle"].ToString();
				this.textBox_3.Text = newsByGuidAndMemLoginID.Rows[0]["Keywords"].ToString();
				this.textBox_4.Text = newsByGuidAndMemLoginID.Rows[0]["Description"].ToString();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ShopNews.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.method_0();
			}
			else
			{
				this.method_1();
			}
		}
		private void method_0()
		{
			ShopNum1_Shop_News shopNum1_Shop_News = new ShopNum1_Shop_News();
			shopNum1_Shop_News.Content = this.textBox_1.Text.Trim();
			shopNum1_Shop_News.Description = this.textBox_4.Text.Trim();
			shopNum1_Shop_News.Guid = new Guid(this.Page.Request.QueryString["guid"].ToString());
			if (this.checkBox_0.Checked)
			{
				shopNum1_Shop_News.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_News.IsShow = 0;
			}
			shopNum1_Shop_News.Keywords = this.textBox_3.Text.Trim();
			shopNum1_Shop_News.NewsCategoryGuid = this.dropDownList_0.SelectedValue;
			shopNum1_Shop_News.SEOTitle = this.textBox_2.Text.Trim();
			shopNum1_Shop_News.Title = this.textBox_0.Text.Trim();
			try
			{
				int num = this.shop_News_Action_0.UpdateNews(shopNum1_Shop_News);
				if (num > 0)
				{
					MessageBox.Show("修改成功！");
					this.GetDataInfo();
				}
				else
				{
					MessageBox.Show("修改失败！");
				}
			}
			catch (Exception)
			{
				MessageBox.Show("修改失败！");
			}
		}
		private void method_1()
		{
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("ShopRank", "ShopNum1_ShopInfo", "   AND  MemLoginID ='" + this.MemLoginID + "'  ");
				if (!string.IsNullOrEmpty(nameById))
				{
					int num = 0;
					string nameById2 = ShopNum1.Common.Common.GetNameById("MaxArticleCout", "ShopNum1_ShopRank", "   AND   Guid ='" + nameById + "'  ");
					if (!string.IsNullOrEmpty(nameById2))
					{
						num = Convert.ToInt32(nameById2);
					}
					int num2 = 0;
					string nameById3 = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_News", "   AND    MemLoginID ='" + this.MemLoginID + "'  ");
					if (!string.IsNullOrEmpty(nameById3))
					{
						num2 = Convert.ToInt32(nameById3);
					}
					if (num2 >= num)
					{
						MessageBox.Show("店铺添加资讯数量已经达到最大值，如要添加更多资讯，请及时升级店铺等级！");
						return;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			ShopNum1_Shop_News shopNum1_Shop_News = new ShopNum1_Shop_News();
			shopNum1_Shop_News.ClickCount = 0;
			shopNum1_Shop_News.Content = this.textBox_1.Text.Trim();
			shopNum1_Shop_News.CreateTime = DateTime.Now;
			shopNum1_Shop_News.Description = this.textBox_4.Text.Trim();
			shopNum1_Shop_News.Guid = Guid.NewGuid();
			shopNum1_Shop_News.IsAudit = new int?(0);
			shopNum1_Shop_News.IsDeleted = new int?(0);
			if (this.checkBox_0.Checked)
			{
				shopNum1_Shop_News.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_News.IsShow = 0;
			}
			shopNum1_Shop_News.Keywords = this.textBox_3.Text.Trim();
			shopNum1_Shop_News.MemLoginID = this.MemLoginID;
			shopNum1_Shop_News.NewsCategoryGuid = this.dropDownList_0.SelectedValue;
			shopNum1_Shop_News.OrderID = 0;
			shopNum1_Shop_News.SEOTitle = this.textBox_2.Text.Trim();
			shopNum1_Shop_News.Title = this.textBox_0.Text.Trim();
			try
			{
				int num3 = this.shop_News_Action_0.AddNews(shopNum1_Shop_News);
				if (num3 > 0)
				{
					MessageBox.Show("添加成功");
					this.textBox_1.Text = "";
					this.textBox_4.Text = "";
					this.textBox_3.Text = "";
					this.dropDownList_0.SelectedValue = "-1";
					this.textBox_2.Text = "";
					this.textBox_0.Text = "";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("添加失败！");
			}
		}
		public void GetShopNewsCategory()
		{
			Shop_NewsCategory_Action shop_NewsCategory_Action = (Shop_NewsCategory_Action)LogicFactory.CreateShop_NewsCategory_Action();
			DataTable newsCategoryList = shop_NewsCategory_Action.GetNewsCategoryList(this.MemLoginID, "1");
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-全部-", "-1"));
			if (newsCategoryList != null && newsCategoryList.Rows.Count > 0)
			{
				foreach (DataRow dataRow in newsCategoryList.Rows)
				{
					this.dropDownList_0.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["Guid"].ToString()));
				}
			}
		}
	}
}
