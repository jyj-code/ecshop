using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_CategoryAdBuy_SearchDetail : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeName;
	protected System.Web.UI.WebControls.TextBox TextBoxPageName;
	protected Localize Localizereplacement;
	protected System.Web.UI.WebControls.DropDownList DropDownListAdPageName;
	protected System.Web.UI.WebControls.DropDownList DropDownListAdID;
	protected Localize Localize2;
	protected System.Web.UI.WebControls.TextBox TextBoxCategoryAdID;
	protected Localize Localize1;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategory1;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategory2;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategory3;
	protected Localize Localize3;
	protected HtmlImage ImgNowPic;
	protected Localize Localize4;
	protected HtmlAnchor ALikeAddress;
	protected Localize Localize5;
	protected System.Web.UI.WebControls.TextBox TextBoxAdPrice;
	protected Localize Localize6;
	protected System.Web.UI.WebControls.TextBox TextBoxAdIntroduce;
	protected Localize Localize7;
	protected System.Web.UI.WebControls.TextBox TextBoxPayMent;
	protected Localize Localize8;
	protected System.Web.UI.WebControls.TextBox TextBoxIsPayMent;
	protected Localize Localize9;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected Literal LiteralFailCause;
	protected ShopNum1.Control.TextBox TextBoxFailCause;
	protected System.Web.UI.WebControls.Button ButtonUpdata;
	protected System.Web.UI.WebControls.Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldCategoryCode;
	protected HiddenField HiddenFieldMemLoginID;
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
		this.hiddenFieldGuid.Value = this.Page.Request.QueryString["Guid"].Replace("'", "");
		this.GetEditInfo();
	}
	public void GetEditInfo()
	{
		string text = string.Empty;
		ShopNum1_CategoryAdPayMent_Action shopNum1_CategoryAdPayMent_Action = (ShopNum1_CategoryAdPayMent_Action)LogicFactory.CreateShopNum1_CategoryAdPayMent_Action();
		DataTable dataTable = shopNum1_CategoryAdPayMent_Action.Search(this.hiddenFieldGuid.Value);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.TextBoxPageName.Text = dataTable.Rows[0]["AdvertisementName"].ToString();
			this.DropDownListAdPageName.SelectedValue = dataTable.Rows[0]["CategoryType"].ToString();
			this.DropDownListAdPageName_SelectedIndexChanged(null, null);
			this.DropDownListAdID.SelectedValue = dataTable.Rows[0]["CategoryAdID"].ToString();
			this.TextBoxCategoryAdID.Text = dataTable.Rows[0]["CategoryAdID"].ToString();
			this.ImgNowPic.Src = this.Page.ResolveUrl("~/ImgUpload/MemberImg/CategoryAdImg/" + dataTable.Rows[0]["AdvertisementPic"].ToString());
			this.ALikeAddress.HRef = dataTable.Rows[0]["AdvertisementLike"].ToString();
			this.ALikeAddress.InnerHtml = dataTable.Rows[0]["AdvertisementLike"].ToString();
			this.TextBoxAdPrice.Text = dataTable.Rows[0]["ShowPayMentPrice"].ToString();
			this.HiddenFieldMemLoginID.Value = dataTable.Rows[0]["MemLoginID"].ToString();
			this.HiddenFieldCategoryCode.Value = dataTable.Rows[0]["CategoryCode"].ToString();
			this.TextBoxAdIntroduce.Text = dataTable.Rows[0]["AdvertisementContent"].ToString();
			this.TextBoxPayMent.Text = dataTable.Rows[0]["PayMentName"].ToString();
			this.TextBoxIsPayMent.Text = ((dataTable.Rows[0]["IsPayMent"].ToString() == "1") ? "已支付" : "未支付");
			if (dataTable.Rows[0]["IsAudit"].ToString() == "1")
			{
				this.DropDownListIsAudit.SelectedValue = "1";
				this.DropDownListIsAudit.Enabled = false;
			}
			else if (dataTable.Rows[0]["IsAudit"].ToString() == "2")
			{
				this.DropDownListIsAudit.SelectedValue = "2";
				this.DropDownListIsAudit.Enabled = false;
				this.LiteralFailCause.Visible = true;
				this.TextBoxFailCause.Visible = true;
			}
			text = dataTable.Rows[0]["CategoryCode"].ToString();
		}
		if (this.DropDownListAdPageName.SelectedValue != "5")
		{
			if (text.Length >= 3)
			{
				for (int i = 0; i < this.DropDownListCategory1.Items.Count; i++)
				{
					if (this.DropDownListCategory1.Items[i].Value.ToString().StartsWith(text.Substring(0, 3) + "/"))
					{
						this.DropDownListCategory1.SelectedValue = this.DropDownListCategory1.Items[i].Value.ToString();
                        //IL_3CB:
						this.DropDownListCategory1_SelectedIndexChanged(null, null);
						goto IL_3D3;
					}
				}
                //goto IL_3CB;
			}
			IL_3D3:
			if (text.Length >= 6)
			{
				for (int i = 0; i < this.DropDownListCategory2.Items.Count; i++)
				{
					if (this.DropDownListCategory2.Items[i].Value.ToString().StartsWith(text.Substring(0, 6) + "/"))
					{
						this.DropDownListCategory2.SelectedValue = this.DropDownListCategory2.Items[i].Value.ToString();
						IL_45D:
						this.DropDownListCategory2_SelectedIndexChanged(null, null);
						goto IL_465;
					}
				}
                //goto IL_45D;
			}
			IL_465:
			if (text.Length >= 9)
			{
				for (int i = 0; i < this.DropDownListCategory3.Items.Count; i++)
				{
					if (this.DropDownListCategory3.Items[i].Value.ToString().StartsWith(text.Substring(0, 9) + "/"))
					{
						this.DropDownListCategory3.SelectedValue = this.DropDownListCategory3.Items[i].Value.ToString();
						break;
					}
				}
			}
		}
		else
		{
			string text2 = string.Empty;
			string text3 = string.Empty;
			ShopNum1_CategoryAdvertisement_Action shopNum1_CategoryAdvertisement_Action = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
			text2 = shopNum1_CategoryAdvertisement_Action.GetFatherIDByID(text);
			if (text2 != null && text2 != string.Empty && text2 != "0")
			{
				text3 = shopNum1_CategoryAdvertisement_Action.GetFatherIDByID(text2);
				if (text3 != null && text3 != string.Empty && text3 != "0")
				{
					this.DropDownListCategory1.SelectedValue = text3;
					this.DropDownListCategory2.SelectedValue = text2;
					this.DropDownListCategory3.SelectedValue = text;
				}
				else
				{
					this.DropDownListCategory1.SelectedValue = text2;
					this.DropDownListCategory2.SelectedValue = text;
				}
			}
			else
			{
				this.DropDownListCategory1.SelectedValue = text;
			}
		}
	}
	protected void DropDownListCategory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListCategory1.SelectedValue == "-1")
		{
			this.DropDownListCategory2.Items.Clear();
			this.DropDownListCategory3.Items.Clear();
			this.DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
			this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
		}
		else if (this.DropDownListAdPageName.SelectedValue != "5")
		{
			this.method_5(this.DropDownListCategory1.SelectedValue.Split(new char[]
			{
				'/'
			})[1], this.DropDownListCategory2);
		}
		else
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			DataTable dataTable = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(this.DropDownListCategory1.SelectedValue), 0);
			this.DropDownListCategory2.Items.Clear();
			this.DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
			foreach (DataRow dataRow in dataTable.Rows)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataRow["Name"].ToString();
				listItem.Value = dataRow["ID"].ToString().Trim();
				this.DropDownListCategory2.Items.Add(listItem);
			}
		}
	}
	protected void DropDownListCategory2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListCategory2.SelectedValue == "-1")
		{
			this.DropDownListCategory3.Items.Clear();
			this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
		}
		else if (this.DropDownListAdPageName.SelectedValue != "5")
		{
			this.method_5(this.DropDownListCategory2.SelectedValue.Split(new char[]
			{
				'/'
			})[1], this.DropDownListCategory3);
		}
		else
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			DataTable dataTable = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(this.DropDownListCategory2.SelectedValue), 0);
			this.DropDownListCategory3.Items.Clear();
			this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
			foreach (DataRow dataRow in dataTable.Rows)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataRow["Name"].ToString();
				listItem.Value = dataRow["ID"].ToString().Trim();
				this.DropDownListCategory3.Items.Add(listItem);
			}
		}
	}
	protected void DropDownListAdPageName_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListAdID.Items.Clear();
		this.DropDownListAdID.Items.Add(new ListItem("-请选择-", "-1"));
		this.DropDownListCategory1.Items.Clear();
		this.DropDownListCategory2.Items.Clear();
		this.DropDownListCategory3.Items.Clear();
		this.DropDownListCategory1.Items.Add(new ListItem("-请选择-", "-1"));
		this.DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
		this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
		if (!(this.DropDownListAdPageName.SelectedValue == "-1"))
		{
			ShopNum1_CategoryAdID_Action shopNum1_CategoryAdID_Action = (ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action();
			DataTable dataTable = shopNum1_CategoryAdID_Action.Search(this.DropDownListAdPageName.SelectedValue, "-1");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.DropDownListAdID.Items.Clear();
				this.DropDownListAdID.Items.Add(new ListItem("-请选择-", "-1"));
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					ListItem listItem = new ListItem();
					listItem.Text = dataTable.Rows[i]["CategoryAdName"].ToString();
					listItem.Value = dataTable.Rows[i]["ID"].ToString();
					this.DropDownListAdID.Items.Add(listItem);
				}
			}
			ShopNum1_CategoryAdvertisement_Action arg_1D3_0 = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
			if (this.DropDownListAdPageName.SelectedValue == "1")
			{
				this.method_5("0", this.DropDownListCategory1);
			}
			if (this.DropDownListAdPageName.SelectedValue == "2")
			{
				this.method_5("0", this.DropDownListCategory1);
			}
			if (this.DropDownListAdPageName.SelectedValue == "3")
			{
				this.method_5("0", this.DropDownListCategory1);
			}
			if (this.DropDownListAdPageName.SelectedValue == "4")
			{
				this.method_5("0", this.DropDownListCategory1);
			}
			if (this.DropDownListAdPageName.SelectedValue == "6")
			{
				this.method_5("0", this.DropDownListCategory1);
			}
			if (this.DropDownListAdPageName.SelectedValue == "5")
			{
				this.DropDownListCategory1.Items.Clear();
				this.DropDownListCategory1.Items.Clear();
				this.DropDownListCategory1.Items.Add(new ListItem("-请选择-", "-1"));
				ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
				DataTable dataTable2 = shopNum1_ArticleCategory_Action.Search(0, 0);
				if (dataTable2 != null && dataTable2.Rows.Count > 0)
				{
					foreach (DataRow dataRow in dataTable2.Rows)
					{
						ListItem listItem2 = new ListItem();
						listItem2.Text = dataRow["Name"].ToString();
						listItem2.Value = dataRow["ID"].ToString();
						this.DropDownListCategory1.Items.Add(listItem2);
					}
				}
			}
		}
	}
	public string CategoryType(object object_0)
	{
		string a = object_0.ToString();
		string result;
		if (a == "1")
		{
			result = "商品分类";
		}
		else if (a == "2")
		{
			result = "分类信息分类";
		}
		else if (a == "3")
		{
			result = "供求分类";
		}
		else if (a == "4")
		{
			result = "店铺分类";
		}
		else if (a == "5")
		{
			result = "资讯分类";
		}
		else if (a == "6")
		{
			result = "品牌分类";
		}
		else
		{
			result = "非法页面";
		}
		return result;
	}
	private void method_5(string string_5, System.Web.UI.WebControls.DropDownList dropDownList_0)
	{
		string tableName = string.Empty;
		if (this.DropDownListAdPageName.SelectedValue == "1")
		{
			tableName = "ShopNum1_ProductCategory";
		}
		if (this.DropDownListAdPageName.SelectedValue == "2")
		{
			tableName = "ShopNum1_Category";
		}
		if (this.DropDownListAdPageName.SelectedValue == "3")
		{
			tableName = "ShopNum1_SupplyDemandCategory";
		}
		if (this.DropDownListAdPageName.SelectedValue == "4")
		{
			tableName = "ShopNum1_ShopCategory";
		}
		if (this.DropDownListAdPageName.SelectedValue == "6")
		{
			tableName = "ShopNum1_ProductCategory";
		}
		ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		shopNum1_Brand_Action.TableName = tableName;
		DataTable productCategoryCode = shopNum1_Brand_Action.GetProductCategoryCode(string_5);
		dropDownList_0.Items.Clear();
		dropDownList_0.Items.Add(new ListItem("-请选择-", "-1"));
		if (productCategoryCode != null && productCategoryCode.Rows.Count > 0)
		{
			for (int i = 0; i < productCategoryCode.Rows.Count; i++)
			{
				dropDownList_0.Items.Add(new ListItem(productCategoryCode.Rows[i]["Name"].ToString(), productCategoryCode.Rows[i]["Code"].ToString() + "/" + productCategoryCode.Rows[i]["ID"].ToString()));
			}
		}
	}
	public void returnCategoryCode()
	{
		if (this.DropDownListAdPageName.SelectedValue != "5")
		{
			if (this.DropDownListCategory3.SelectedValue != "-1")
			{
				this.HiddenFieldCategoryCode.Value = this.DropDownListCategory3.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.DropDownListCategory2.SelectedValue != "-1")
			{
				this.HiddenFieldCategoryCode.Value = this.DropDownListCategory2.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.DropDownListCategory1.SelectedValue != "-1")
			{
				this.HiddenFieldCategoryCode.Value = this.DropDownListCategory1.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else
			{
				this.HiddenFieldCategoryCode.Value = "-1";
			}
		}
		else if (this.DropDownListCategory3.SelectedValue != "-1")
		{
			this.HiddenFieldCategoryCode.Value = this.DropDownListCategory3.SelectedValue;
		}
		else if (this.DropDownListCategory2.SelectedValue != "-1")
		{
			this.HiddenFieldCategoryCode.Value = this.DropDownListCategory2.SelectedValue;
		}
		else if (this.DropDownListCategory1.SelectedValue != "-1")
		{
			this.HiddenFieldCategoryCode.Value = this.DropDownListCategory1.SelectedValue;
		}
		else
		{
			this.HiddenFieldCategoryCode.Value = "-1";
		}
	}
	protected void DropDownListAdID_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListAdID.SelectedValue != "-1")
		{
			this.TextBoxCategoryAdID.Text = this.DropDownListAdID.SelectedValue;
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CategoryAdBuy_List.aspx");
	}
	protected void DropDownListIsAudit_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListIsAudit.SelectedValue == "2")
		{
			this.LiteralFailCause.Visible = true;
			this.TextBoxFailCause.Visible = true;
		}
		else
		{
			this.LiteralFailCause.Visible = false;
			this.TextBoxFailCause.Text = string.Empty;
			this.TextBoxFailCause.Visible = false;
		}
	}
	protected void ButtonUpdata_Click(object sender, EventArgs e)
	{
		ShopNum1_CategoryAdPayMent_Action shopNum1_CategoryAdPayMent_Action = (ShopNum1_CategoryAdPayMent_Action)LogicFactory.CreateShopNum1_CategoryAdPayMent_Action();
		int num = shopNum1_CategoryAdPayMent_Action.UpdataCategoryAdInfo(this.HiddenFieldMemLoginID.Value, this.hiddenFieldGuid.Value, this.DropDownListIsAudit.SelectedValue, this.TextBoxFailCause.Text.Trim());
		if (num > 0)
		{
			this.Page.Response.Redirect("CategoryAdBuyAudit_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("Audit1No");
			this.MessageShow.Visible = true;
		}
	}
}
