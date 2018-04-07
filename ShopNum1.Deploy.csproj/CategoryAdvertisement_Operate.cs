using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class CategoryAdvertisement_Operate : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxPageName;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxOrderID;
	protected System.Web.UI.WebControls.DropDownList DropDownListAdPageName;
	protected System.Web.UI.WebControls.DropDownList DropDownListAdID;
	protected CompareValidator CompareValidator1;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
	protected System.Web.UI.WebControls.TextBox TextBoxCategoryAdID;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxCategoryAdID;
	protected System.Web.UI.UpdatePanel UpdatePanel3;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategory1;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategory2;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategory3;
	protected CompareValidator CompareDdl;
	protected System.Web.UI.UpdatePanel UpdatePanel2;
	protected System.Web.UI.WebControls.TextBox TextBoxDefaultPic;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected HtmlImage ImageOriginalImge2;
	protected ShopNum1.Control.TextBox TextBoxDefaultLikeAddress;
	protected System.Web.UI.WebControls.TextBox TextBoxAdPrice;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected RegularExpressionValidator RegularExpressionValidatorRepertory;
	protected System.Web.UI.WebControls.TextBox TextBoxAdvertisementflow;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected RequiredFieldValidator RequiredFieldValidator3;
	protected System.Web.UI.WebControls.TextBox TextBoxAdIntroduce;
	protected CheckBox CheckBoxIsShow;
	protected System.Web.UI.WebControls.Button ButtonConfirm;
	protected System.Web.UI.WebControls.Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldCategoryCode;
	protected HtmlForm form1;
	private ShopNum1_Advertisement_Action shopNum1_Advertisement_Action_0 = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["ID"] == null) ? "0" : base.Request.QueryString["ID"].Replace("'", ""));
		if (!this.Page.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.LabelPageTitle.Text = "编辑分类广告";
			this.GetEditInfo();
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		this.returnCategoryCode();
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.Edit();
		}
		else
		{
			this.Add();
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CategoryAdvertisement_List.aspx");
	}
	public void Add()
	{
		ShopNum1_CategoryAdvertisement shopNum1_CategoryAdvertisement = new ShopNum1_CategoryAdvertisement();
		shopNum1_CategoryAdvertisement.AdvertisementName = this.TextBoxPageName.Text.Trim();
		shopNum1_CategoryAdvertisement.Width = new int?(0);
		shopNum1_CategoryAdvertisement.Height = new int?(0);
		shopNum1_CategoryAdvertisement.AdvertisementDPic = this.TextBoxDefaultPic.Text.Trim();
		shopNum1_CategoryAdvertisement.CategoryAdID = int.Parse(this.TextBoxCategoryAdID.Text);
		shopNum1_CategoryAdvertisement.CategoryType = this.DropDownListAdPageName.SelectedValue;
		shopNum1_CategoryAdvertisement.CategoryCode = this.HiddenFieldCategoryCode.Value;
		shopNum1_CategoryAdvertisement.CategoryName = this.returnCategoryName();
		shopNum1_CategoryAdvertisement.AdIntroduce = "";
		shopNum1_CategoryAdvertisement.AdDefaultLike = "http://" + this.TextBoxDefaultLikeAddress.Text.Trim().ToLower().Replace("http://", "");
		shopNum1_CategoryAdvertisement.AdvertisementPrice = Convert.ToDecimal(this.TextBoxAdPrice.Text.Trim());
		shopNum1_CategoryAdvertisement.AdIntroduce = this.TextBoxAdIntroduce.Text.Trim();
		shopNum1_CategoryAdvertisement.Advertisementflow = new int?(int.Parse(this.TextBoxAdvertisementflow.Text.Trim()));
		shopNum1_CategoryAdvertisement.IsEnabled = 1;
		shopNum1_CategoryAdvertisement.IsShow = (this.CheckBoxIsShow.Checked ? 1 : 0);
		shopNum1_CategoryAdvertisement.IsBuy = 0;
		shopNum1_CategoryAdvertisement.CreateTime = new DateTime?(DateTime.Now);
		ShopNum1_CategoryAdvertisement_Action shopNum1_CategoryAdvertisement_Action = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
		int num = shopNum1_CategoryAdvertisement_Action.Add(shopNum1_CategoryAdvertisement);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	public void Edit()
	{
		ShopNum1_CategoryAdvertisement shopNum1_CategoryAdvertisement = new ShopNum1_CategoryAdvertisement();
		shopNum1_CategoryAdvertisement.AdvertisementName = this.TextBoxPageName.Text.Trim();
		shopNum1_CategoryAdvertisement.Width = new int?(0);
		shopNum1_CategoryAdvertisement.Height = new int?(0);
		shopNum1_CategoryAdvertisement.AdvertisementDPic = this.TextBoxDefaultPic.Text.Trim();
		shopNum1_CategoryAdvertisement.CategoryAdID = int.Parse(this.TextBoxCategoryAdID.Text);
		shopNum1_CategoryAdvertisement.CategoryType = this.DropDownListAdPageName.SelectedValue;
		shopNum1_CategoryAdvertisement.CategoryCode = this.HiddenFieldCategoryCode.Value;
		shopNum1_CategoryAdvertisement.CategoryName = this.returnCategoryName();
		shopNum1_CategoryAdvertisement.AdIntroduce = "";
		shopNum1_CategoryAdvertisement.AdDefaultLike = "http://" + this.TextBoxDefaultLikeAddress.Text.Trim().ToLower().Replace("http://", "");
		shopNum1_CategoryAdvertisement.AdvertisementPrice = Convert.ToDecimal(this.TextBoxAdPrice.Text.Trim());
		shopNum1_CategoryAdvertisement.AdIntroduce = this.TextBoxAdIntroduce.Text.Trim();
		shopNum1_CategoryAdvertisement.Advertisementflow = new int?(0);
		shopNum1_CategoryAdvertisement.IsEnabled = 1;
		shopNum1_CategoryAdvertisement.IsShow = (this.CheckBoxIsShow.Checked ? 1 : 0);
		shopNum1_CategoryAdvertisement.IsBuy = 0;
		shopNum1_CategoryAdvertisement.ID = int.Parse(this.hiddenFieldGuid.Value);
		ShopNum1_CategoryAdvertisement_Action shopNum1_CategoryAdvertisement_Action = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
		int num = shopNum1_CategoryAdvertisement_Action.Updata(shopNum1_CategoryAdvertisement);
		if (num > 0)
		{
			base.Response.Redirect("CategoryAdvertisement_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	public void GetEditInfo()
	{
		string text = string.Empty;
		ShopNum1_CategoryAdvertisement_Action shopNum1_CategoryAdvertisement_Action = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
		DataTable dataTable = shopNum1_CategoryAdvertisement_Action.Search(this.hiddenFieldGuid.Value);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.TextBoxPageName.Text = dataTable.Rows[0]["AdvertisementName"].ToString();
			this.DropDownListAdPageName.SelectedValue = dataTable.Rows[0]["CategoryType"].ToString();
			this.DropDownListAdPageName_SelectedIndexChanged(null, null);
			this.DropDownListAdID.SelectedValue = dataTable.Rows[0]["CategoryAdID"].ToString();
			this.TextBoxCategoryAdID.Text = dataTable.Rows[0]["CategoryAdID"].ToString();
			this.TextBoxDefaultPic.Text = dataTable.Rows[0]["AdvertisementDPic"].ToString();
			this.ImageOriginalImge2.Src = this.Page.ResolveUrl("~/ImgUpload/" + dataTable.Rows[0]["AdvertisementDPic"].ToString());
			this.TextBoxDefaultLikeAddress.Text = dataTable.Rows[0]["AdDefaultLike"].ToString();
			this.TextBoxAdPrice.Text = dataTable.Rows[0]["AdvertisementPrice"].ToString();
			this.TextBoxAdIntroduce.Text = dataTable.Rows[0]["AdIntroduce"].ToString();
			this.TextBoxAdvertisementflow.Text = dataTable.Rows[0]["Advertisementflow"].ToString();
			if (dataTable.Rows[0]["IsShow"].ToString() == "0")
			{
				this.CheckBoxIsShow.Checked = false;
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
						IL_2D1:
						this.DropDownListCategory1_SelectedIndexChanged(null, null);
						goto IL_2D9;
					}
				}
                ////goto IL_2D1;
			}
			IL_2D9:
			if (text.Length >= 6)
			{
				for (int i = 0; i < this.DropDownListCategory2.Items.Count; i++)
				{
					if (this.DropDownListCategory2.Items[i].Value.ToString().StartsWith(text.Substring(0, 6) + "/"))
					{
						this.DropDownListCategory2.SelectedValue = this.DropDownListCategory2.Items[i].Value.ToString();
                        //IL_363:
						this.DropDownListCategory2_SelectedIndexChanged(null, null);
						goto IL_36B;
					}
				}
                //goto IL_363;
			}
			IL_36B:
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
	public string returnCategoryName()
	{
		string result;
		if (this.DropDownListAdPageName.SelectedValue != "5")
		{
			if (this.DropDownListCategory3.SelectedValue != "-1")
			{
				result = string.Concat(new string[]
				{
					this.DropDownListCategory1.SelectedItem.Text,
					"/",
					this.DropDownListCategory2.SelectedItem.Text,
					"/",
					this.DropDownListCategory3.SelectedItem.Text
				});
			}
			else if (this.DropDownListCategory2.SelectedValue != "-1")
			{
				result = this.DropDownListCategory1.SelectedItem.Text + "/" + this.DropDownListCategory2.SelectedItem.Text;
			}
			else if (this.DropDownListCategory1.SelectedValue != "-1")
			{
				result = this.DropDownListCategory1.SelectedItem.Text;
			}
			else
			{
				result = "";
			}
		}
		else if (this.DropDownListCategory3.SelectedValue != "-1")
		{
			result = string.Concat(new string[]
			{
				this.DropDownListCategory1.SelectedItem.Text,
				"/",
				this.DropDownListCategory2.SelectedItem.Text,
				"/",
				this.DropDownListCategory3.SelectedItem.Text
			});
		}
		else if (this.DropDownListCategory2.SelectedValue != "-1")
		{
			result = this.DropDownListCategory1.SelectedItem.Text + "/" + this.DropDownListCategory2.SelectedItem.Text;
		}
		else if (this.DropDownListCategory1.SelectedValue != "-1")
		{
			result = this.DropDownListCategory1.SelectedItem.Text;
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void DropDownListAdID_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListAdID.SelectedValue != "-1")
		{
			this.TextBoxCategoryAdID.Text = this.DropDownListAdID.SelectedValue;
		}
	}
}
