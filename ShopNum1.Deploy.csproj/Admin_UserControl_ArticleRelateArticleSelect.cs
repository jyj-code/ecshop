using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
public class Admin_UserControl_ArticleRelateArticleSelect : UserControl
{
	protected ScriptManager ScriptManager1;
	protected DropDownList DropDownListSArticleCategory;
	protected TextBox TextBoxSArticleTitle;
	protected Button ButtonSearch;
	protected ListBox ListBoxLeftArticleArticle;
	protected DropDownList DropDownListRelatedArticleIsBoth;
	protected Button ButtonArticleAddAll;
	protected Button ButtonAddArticle;
	protected Button ButtonDeleteArticle;
	protected Button ButtonArticleDeleteAll;
	protected ListBox ListBoxRightArticleArticle;
	protected UpdatePanel UpdatePanel1;
	protected string strSapce = "\u3000\u3000";
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.Page.IsPostBack)
		{
			this.BindArticleCategory();
			this.DropDownListRelatedArticleIsBothStatus();
		}
	}
	protected void ButtonAddArticle_Click(object sender, EventArgs e)
	{
		foreach (ListItem listItem in this.ListBoxLeftArticleArticle.Items)
		{
			if (listItem.Selected && this.method_0(listItem.Value))
			{
				if (this.DropDownListRelatedArticleIsBoth.SelectedValue == "1")
				{
					listItem.Value += ";1";
				}
				else
				{
					listItem.Value += ";0";
				}
				this.ListBoxRightArticleArticle.Items.Add(listItem);
			}
		}
	}
	protected void ButtonArticleAddAll_Click(object sender, EventArgs e)
	{
		this.ListBoxRightArticleArticle.Items.Clear();
		foreach (ListItem listItem in this.ListBoxLeftArticleArticle.Items)
		{
			if (this.method_0(listItem.Value))
			{
				if (this.DropDownListRelatedArticleIsBoth.SelectedValue == "1")
				{
					listItem.Value += ";1";
				}
				else
				{
					listItem.Value += ";0";
				}
				this.ListBoxRightArticleArticle.Items.Add(listItem);
			}
		}
	}
	private bool method_0(string string_0)
	{
		string[] array = string_0.Split(new char[]
		{
			';'
		});
		bool result = true;
		for (int i = 0; i < this.ListBoxRightArticleArticle.Items.Count; i++)
		{
			string text = this.ListBoxRightArticleArticle.Items[i].Value.Trim();
			string[] array2 = text.Split(new char[]
			{
				';'
			});
			if (array2[0] == array[0])
			{
				result = false;
				return result;
			}
		}
		return result;
	}
	protected void ButtonDeleteArticle_Click(object sender, EventArgs e)
	{
		int count = this.ListBoxRightArticleArticle.Items.Count;
		if (count != -1)
		{
			for (int i = this.ListBoxRightArticleArticle.Items.Count - 1; i >= 0; i--)
			{
				if (this.ListBoxRightArticleArticle.Items[i].Selected)
				{
					this.ListBoxRightArticleArticle.Items.Remove(this.ListBoxRightArticleArticle.Items[i]);
				}
			}
		}
	}
	protected void ButtonArticleDeleteAll_Click(object sender, EventArgs e)
	{
		this.ListBoxRightArticleArticle.Items.Clear();
	}
	protected void BindListBoxLeftArticleArticle()
	{
		this.ListBoxLeftArticleArticle.Items.Clear();
		string title = this.TextBoxSArticleTitle.Text.Trim();
		int articleCategoryID = Convert.ToInt32(this.DropDownListSArticleCategory.SelectedValue);
		ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
		DataView defaultView = shopNum1_Article_Action.Search(title, articleCategoryID).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem = new ListItem();
			listItem.Text = dataRow["Title"].ToString().Trim();
			listItem.Value = dataRow["Guid"].ToString().Trim();
			this.ListBoxLeftArticleArticle.Items.Add(listItem);
		}
	}
	protected void BindArticleCategory()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-1";
		this.DropDownListSArticleCategory.Items.Add(listItem);
		ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
		DataView defaultView = shopNum1_ArticleCategory_Action.Search(0, 0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListSArticleCategory.Items.Add(listItem2);
			DataTable dataTable = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 1);
			if (dataTable.Rows.Count > 0)
			{
				this.AddSubAriticleCategory(dataTable);
			}
		}
	}
	protected void AddSubAriticleCategory(DataTable dataTable)
	{
		ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
		foreach (DataRow dataRow in dataTable.Rows)
		{
			ListItem listItem = new ListItem();
			string text = string.Empty;
			for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
			{
				text += this.strSapce;
			}
			text += dataRow["Name"].ToString().Trim();
			listItem.Text = text;
			listItem.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListSArticleCategory.Items.Add(listItem);
			DataTable dataTable2 = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 1);
			if (dataTable2.Rows.Count > 0)
			{
				this.AddSubAriticleCategory(dataTable2);
			}
		}
	}
	protected void DropDownListRelatedArticleIsBothStatus()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "单项关联";
		listItem.Value = "0";
		this.DropDownListRelatedArticleIsBoth.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "双向关联";
		listItem2.Value = "1";
		this.DropDownListRelatedArticleIsBoth.Items.Add(listItem2);
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindListBoxLeftArticleArticle();
	}
}
