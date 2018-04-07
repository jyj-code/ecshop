using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Article_Operate : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
	protected string strLine = " --- ";
	protected HtmlHead Head1;
	protected Label tab01;
	protected Label tab02;
	protected Label LabelTitle;
	protected TextBox TextBoxTitle;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorTitle;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label LabelArticleCatogory;
	protected DropDownList DropDownListArticleCategory;
	protected Label Label2;
	protected CompareValidator CompareValidatorArticleCatogory;
	protected Label LabelPublisher;
	protected TextBox TextBoxPublisher;
	protected RegularExpressionValidator RegularExpressionValidatorTitle0;
	protected Label LabelSource;
	protected TextBox TextBoxSource;
	protected RegularExpressionValidator RegularExpressionValidatorTitle1;
	protected Label LabelKeyWord;
	protected TextBox TextBoxKeyWord;
	protected RegularExpressionValidator RegularExpressionValidatorTitle2;
	protected Label LabelRemark;
	protected TextBox TextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorTitle3;
	protected Label LabelIfShow;
	protected DropDownList DropDownListIfShow;
	protected Label Label3;
	protected CompareValidator CompareValidatorIfShow;
	protected Label LabelIfAllowComment;
	protected DropDownList DropDownListIfAllowComment;
	protected Label Label4;
	protected CompareValidator CompareValidatorIfAllowComment;
	protected Label LabelOrderID;
	protected TextBox TextBoxOrderID;
	protected Label Label5;
	protected RegularExpressionValidator RegularExpressionValidatorOrderID;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected Label LabelProperty;
	protected CheckBox CheckBoxIsHot;
	protected CheckBox CheckBoxIsRecommend;
	protected CheckBox CheckBoxIsHead;
	protected Label LabelContent;
	protected TextBox FCKeditorRemark;
	protected Label Label10;
	protected RequiredFieldValidator RequiredFieldValidatorContent;
	protected HtmlGenericControl content1;
	protected Admin_UserControl_ArticleRelateArticleSelect ArticleRelateArticleSelect1;
	protected HtmlGenericControl content2;
	protected HtmlGenericControl content3;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
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
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			this.ClearControl();
			this.TextBoxPublisher.Text = base.ShopNum1LoginID;
			this.GetOrderID();
			this.BindStatus();
			this.method_5();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.GetEditInfo();
			}
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Update")
		{
			this.Edit();
		}
		else if (this.ButtonConfirm.ToolTip == "Submit")
		{
			this.Add();
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
		DataTable editInfo = shopNum1_Article_Action.GetEditInfo(this.hiddenFieldGuid.Value);
		this.TextBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
		this.DropDownListArticleCategory.SelectedValue = editInfo.Rows[0]["ArticleCategoryID"].ToString();
		this.TextBoxPublisher.Text = editInfo.Rows[0]["Publisher"].ToString();
		this.TextBoxPublisher.ReadOnly = true;
		this.TextBoxSource.Text = editInfo.Rows[0]["Source"].ToString();
		this.TextBoxKeyWord.Text = editInfo.Rows[0]["Keywords"].ToString();
		this.TextBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
		this.DropDownListIfShow.SelectedValue = editInfo.Rows[0]["IsShow"].ToString();
		this.DropDownListIfAllowComment.SelectedValue = editInfo.Rows[0]["IsAllowComment"].ToString();
		this.TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
		if (Convert.ToInt32(editInfo.Rows[0]["IsHot"].ToString()) == 1)
		{
			this.CheckBoxIsHot.Checked = true;
		}
		else
		{
			this.CheckBoxIsHot.Checked = false;
		}
		if (Convert.ToInt32(editInfo.Rows[0]["IsRecommend"].ToString()) == 1)
		{
			this.CheckBoxIsRecommend.Checked = true;
		}
		else
		{
			this.CheckBoxIsRecommend.Checked = false;
		}
		if (Convert.ToInt32(editInfo.Rows[0]["IsHead"].ToString()) == 1)
		{
			this.CheckBoxIsHead.Checked = true;
		}
		else
		{
			this.CheckBoxIsHead.Checked = false;
		}
		this.FCKeditorRemark.Text = base.Server.HtmlDecode(editInfo.Rows[0]["Content"].ToString());
		DataTable relatedArticleInfo = shopNum1_Article_Action.GetRelatedArticleInfo(this.hiddenFieldGuid.Value);
		ListBox listBox = (ListBox)this.ArticleRelateArticleSelect1.FindControl("ListBoxRightArticleArticle");
		DropDownList arg_2B4_0 = (DropDownList)this.ArticleRelateArticleSelect1.FindControl("DropDownListRelatedArticleIsBoth");
		for (int i = 0; i < relatedArticleInfo.Rows.Count; i++)
		{
			ListItem listItem = new ListItem();
			listItem.Value = relatedArticleInfo.Rows[i]["SubArticleGuid"].ToString();
			ShopNum1_Article_Action shopNum1_Article_Action2 = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			listItem.Text = shopNum1_Article_Action2.GetNameByGuid(relatedArticleInfo.Rows[i]["SubArticleGuid"].ToString());
			listItem.Value = relatedArticleInfo.Rows[i]["SubArticleGuid"].ToString() + ";" + relatedArticleInfo.Rows[i]["IsBoth"].ToString();
			listBox.Items.Add(listItem);
		}
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
	}
	protected void Add()
	{
		ShopNum1_Article shopNum1_Article = new ShopNum1_Article();
		shopNum1_Article.Guid = Guid.NewGuid();
		shopNum1_Article.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_Article.ArticleCategoryID = Convert.ToInt32(this.DropDownListArticleCategory.SelectedValue.ToString());
		shopNum1_Article.Publisher = this.TextBoxPublisher.Text.Trim();
		shopNum1_Article.Source = this.TextBoxSource.Text.Trim();
		shopNum1_Article.Keywords = this.TextBoxKeyWord.Text.Trim();
		shopNum1_Article.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_Article.IsShow = Convert.ToInt32(this.DropDownListIfShow.SelectedValue.ToString());
		shopNum1_Article.IsAllowComment = Convert.ToInt32(this.DropDownListIfAllowComment.SelectedValue.ToString());
		shopNum1_Article.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
		if (this.CheckBoxIsHot.Checked)
		{
			shopNum1_Article.IsHot = 1;
		}
		else
		{
			shopNum1_Article.IsHot = 0;
		}
		if (this.CheckBoxIsRecommend.Checked)
		{
			shopNum1_Article.IsRecommend = 1;
		}
		else
		{
			shopNum1_Article.IsRecommend = 0;
		}
		if (this.CheckBoxIsHead.Checked)
		{
			shopNum1_Article.IsHead = 1;
		}
		else
		{
			shopNum1_Article.IsHead = 0;
		}
		shopNum1_Article.Content = base.Server.HtmlEncode(this.FCKeditorRemark.Text.Replace("'", "''"));
		shopNum1_Article.CreateUser = base.ShopNum1LoginID;
		shopNum1_Article.CreateTime = DateTime.Now;
		shopNum1_Article.ModifyUser = base.ShopNum1LoginID;
		shopNum1_Article.ModifyTime = DateTime.Now;
		shopNum1_Article.IsDeleted = 0;
		shopNum1_Article.IsAudit = new int?(1);
		shopNum1_Article.SubstationID = base.SubstationID;
		shopNum1_Article.ClickCount = new int?(0);
		List<string> list = new List<string>();
		ListBox listBox = (ListBox)this.ArticleRelateArticleSelect1.FindControl("ListBoxRightArticleArticle");
		foreach (ListItem listItem in listBox.Items)
		{
			list.Add(listItem.Value);
		}
		List<string> strRelateProductList = new List<string>();
		ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
		int num = shopNum1_Article_Action.Add(shopNum1_Article, list, strRelateProductList);
		if (num > 0)
		{
			this.ClearControl();
			this.GetOrderID();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Edit()
	{
		ShopNum1_Article shopNum1_Article = new ShopNum1_Article();
		shopNum1_Article.Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", ""));
		shopNum1_Article.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_Article.ArticleCategoryID = Convert.ToInt32(this.DropDownListArticleCategory.SelectedValue.ToString());
		shopNum1_Article.Publisher = this.TextBoxPublisher.Text.Trim();
		shopNum1_Article.Source = this.TextBoxSource.Text.Trim();
		shopNum1_Article.Keywords = this.TextBoxKeyWord.Text.Trim();
		shopNum1_Article.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_Article.IsShow = Convert.ToInt32(this.DropDownListIfShow.SelectedValue.ToString());
		shopNum1_Article.IsAllowComment = Convert.ToInt32(this.DropDownListIfAllowComment.SelectedValue.ToString());
		shopNum1_Article.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
		if (this.CheckBoxIsHot.Checked)
		{
			shopNum1_Article.IsHot = 1;
		}
		else
		{
			shopNum1_Article.IsHot = 0;
		}
		if (this.CheckBoxIsRecommend.Checked)
		{
			shopNum1_Article.IsRecommend = 1;
		}
		else
		{
			shopNum1_Article.IsRecommend = 0;
		}
		if (this.CheckBoxIsHead.Checked)
		{
			shopNum1_Article.IsHead = 1;
		}
		else
		{
			shopNum1_Article.IsHead = 0;
		}
		shopNum1_Article.Content = base.Server.HtmlEncode(this.FCKeditorRemark.Text.Replace("'", "''"));
		shopNum1_Article.ModifyUser = base.ShopNum1LoginID;
		shopNum1_Article.ModifyTime = DateTime.Now;
		shopNum1_Article.IsDeleted = 0;
		List<string> list = new List<string>();
		ListBox listBox = (ListBox)this.ArticleRelateArticleSelect1.FindControl("ListBoxRightArticleArticle");
		foreach (ListItem listItem in listBox.Items)
		{
			list.Add(listItem.Value);
		}
		List<string> strRelateProductList = new List<string>();
		ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
		int num = shopNum1_Article_Action.Update(shopNum1_Article, list, strRelateProductList);
		if (num > 0)
		{
			base.Response.Redirect("Article_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void GetOrderID()
	{
		string columnName = "OrderID";
		string tableName = "ShopNum1_Article";
		this.TextBoxOrderID.Text = Convert.ToString(1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
	}
	protected void BindStatus()
	{
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("Select");
		listItem.Value = "-1";
		this.DropDownListIfShow.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = LocalizationUtil.GetCommonMessage("Select");
		listItem2.Value = "-1";
		this.DropDownListIfAllowComment.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = LocalizationUtil.GetCommonMessage("Select");
		listItem3.Value = "-1";
		this.DropDownListArticleCategory.Items.Add(listItem3);
		ListItem listItem4 = new ListItem();
		listItem4.Text = LocalizationUtil.GetCommonMessage("No");
		listItem4.Value = "0";
		this.DropDownListIfShow.Items.Add(listItem4);
		ListItem listItem5 = new ListItem();
		listItem5.Text = LocalizationUtil.GetCommonMessage("No");
		listItem5.Value = "0";
		this.DropDownListIfAllowComment.Items.Add(listItem5);
		ListItem listItem6 = new ListItem();
		listItem6.Text = LocalizationUtil.GetCommonMessage("Yes");
		listItem6.Value = "1";
		this.DropDownListIfShow.Items.Add(listItem6);
		ListItem listItem7 = new ListItem();
		listItem7.Text = LocalizationUtil.GetCommonMessage("Yes");
		listItem7.Value = "1";
		this.DropDownListIfAllowComment.Items.Add(listItem7);
	}
	private void method_5()
	{
		this.DropDownListArticleCategory.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("Select");
		listItem.Value = "0";
		this.DropDownListArticleCategory.Items.Add(listItem);
		ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
		DataView defaultView = shopNum1_ArticleCategory_Action.Search(0, 0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListArticleCategory.Items.Add(listItem2);
			DataTable dataTable = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.method_6(dataTable);
			}
		}
	}
	private void method_6(DataTable dt)
	{
		ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
		foreach (DataRow dataRow in dt.Rows)
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
			this.DropDownListArticleCategory.Items.Add(listItem);
			DataTable dataTable = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.method_6(dataTable);
			}
		}
	}
	protected void ClearControl()
	{
		this.TextBoxTitle.Text = string.Empty;
		this.DropDownListArticleCategory.SelectedIndex = -1;
		this.TextBoxPublisher.Text = string.Empty;
		this.TextBoxSource.Text = string.Empty;
		this.TextBoxKeyWord.Text = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
		this.DropDownListIfShow.SelectedIndex = -1;
		this.DropDownListIfAllowComment.SelectedIndex = -1;
		this.TextBoxOrderID.Text = string.Empty;
		this.CheckBoxIsHot.Checked = false;
		this.CheckBoxIsRecommend.Checked = false;
		this.CheckBoxIsHead.Checked = false;
		this.FCKeditorRemark.Text = string.Empty;
	}
}
