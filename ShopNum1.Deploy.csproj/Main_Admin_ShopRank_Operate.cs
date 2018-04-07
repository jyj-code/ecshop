using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopRank_Operate : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label Label8;
	protected TextBox TextBoxRankValue;
	protected Label Label9;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Label LabelMaxProduct;
	protected TextBox TextBoxMaxProduct;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxMinScore;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMinScore;
	protected Label Label6;
	protected HiddenField HiddenFieldPic;
	protected HtmlImage image;
	protected Label Label7;
	protected DropDownList DropDownListIsSetSEO;
	protected CompareValidator CompareValidator1;
	protected Label LabelStartTime;
	protected TextBox TextBoxStartTime;
	protected CalendarExtender CalendarExtender4;
	protected Label LabelPrice;
	protected TextBox TextBoxPrice;
	protected RegularExpressionValidator RegularExpressionValidatorCostPrice1;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxPrice;
	protected Label LabelMaxArticleCout;
	protected TextBox TextBoxMaxArticleCout;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxMaxArticleCout;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMaxArticleCout;
	protected Label LabelMaxVedioCount;
	protected TextBox TextBoxMaxVedioCount;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxMaxVedioCount;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMaxVedioCount;
	protected Label LabelshopTemplate;
	protected Repeater RepeatershopTemplate;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldGuid;
	protected HiddenField HiddenFieldIsDefault;
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
		if (!base.IsPostBack)
		{
			this.BindGrid();
			this.HiddenFieldGuid.Value = ((this.Page.Request.QueryString["guid"] == null) ? "0" : ("'" + base.Request.QueryString["guid"] + "'"));
			if (this.HiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "修改店铺等级";
				this.method_5();
				this.ButtonConfirm.Text = "更新";
			}
		}
	}
	private void method_5()
	{
		Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
		DataTable dataTable = shop_Rank_Action.Search(this.HiddenFieldGuid.Value, 0);
		this.TextBoxName.Text = dataTable.Rows[0]["name"].ToString();
		this.TextBoxMaxProduct.Text = dataTable.Rows[0]["MaxProductCount"].ToString();
		this.TextBoxStartTime.Text = dataTable.Rows[0]["StartTime"].ToString();
		this.HiddenFieldPic.Value = dataTable.Rows[0]["Pic"].ToString();
		this.image.Src = dataTable.Rows[0]["Pic"].ToString();
		this.TextBoxPrice.Text = dataTable.Rows[0]["price"].ToString();
		this.CheckGuid.Value = dataTable.Rows[0]["shopTemplate"].ToString();
		this.DropDownListIsSetSEO.SelectedValue = dataTable.Rows[0]["IsSetSEO"].ToString();
		this.TextBoxMaxArticleCout.Text = dataTable.Rows[0]["MaxArticleCout"].ToString();
		this.TextBoxMaxVedioCount.Text = dataTable.Rows[0]["MaxVedioCount"].ToString();
		this.TextBoxRankValue.Text = dataTable.Rows[0]["RankValue"].ToString();
		this.HiddenFieldIsDefault.Value = dataTable.Rows[0]["IsDefault"].ToString();
		foreach (RepeaterItem repeaterItem in this.RepeatershopTemplate.Items)
		{
			HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)repeaterItem.FindControl("checkboxItem");
			string[] array = this.CheckGuid.Value.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (htmlInputCheckBox.Value == array[i])
				{
					htmlInputCheckBox.Checked = true;
				}
			}
		}
	}
	protected void BindGrid()
	{
		ShopNum1_ShopTemplate_Action shopNum1_ShopTemplate_Action = (ShopNum1_ShopTemplate_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopTemplate_Action();
		DataTable dataSource = shopNum1_ShopTemplate_Action.Search();
		this.RepeatershopTemplate.DataSource = dataSource;
		this.RepeatershopTemplate.DataBind();
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.HiddenFieldGuid.Value == "0")
		{
			this.method_7();
		}
		else
		{
			this.method_6();
		}
	}
	private void method_6()
	{
		ShopNum1_ShopRank shopNum1_ShopRank = new ShopNum1_ShopRank();
		shopNum1_ShopRank.Name = this.TextBoxName.Text;
		shopNum1_ShopRank.MaxProductCount = new int?(int.Parse(this.TextBoxMaxProduct.Text.Trim()));
		shopNum1_ShopRank.MaxFileCount = new int?(99999);
		shopNum1_ShopRank.StartTime = new DateTime?(Convert.ToDateTime("1900-1-1"));
		shopNum1_ShopRank.validityDate = "";
		shopNum1_ShopRank.price = new decimal?(Convert.ToDecimal(this.TextBoxPrice.Text.Trim()));
		string value = this.HiddenFieldPic.Value;
		shopNum1_ShopRank.Pic = value;
		shopNum1_ShopRank.IsSetSEO = int.Parse(this.DropDownListIsSetSEO.SelectedValue);
		shopNum1_ShopRank.shopTemplate = this.CheckGuid.Value.Replace("'", "");
		shopNum1_ShopRank.IsOverrideDomain = new int?(1);
		shopNum1_ShopRank.MaxPanicBuyCount = new int?(99999);
		shopNum1_ShopRank.MaxSpellBuyCount = new int?(99999);
		shopNum1_ShopRank.MaxArticleCout = new int?(int.Parse(this.TextBoxMaxArticleCout.Text.Trim()));
		shopNum1_ShopRank.MaxVedioCount = new int?(int.Parse(this.TextBoxMaxVedioCount.Text.Trim()));
		if (this.HiddenFieldIsDefault.Value == "0")
		{
			shopNum1_ShopRank.IsDefault = 0;
		}
		else
		{
			shopNum1_ShopRank.IsDefault = 1;
		}
		shopNum1_ShopRank.ModifyTime = new DateTime?(DateTime.Now);
		shopNum1_ShopRank.ModifyUser = "admin";
		shopNum1_ShopRank.RankValue = new int?(Convert.ToInt32(this.TextBoxRankValue.Text.Trim()));
		shopNum1_ShopRank.Guid = new Guid(this.HiddenFieldGuid.Value.Replace("'", ""));
		Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
		int num = shop_Rank_Action.Update(shopNum1_ShopRank);
		if (num == 1)
		{
			base.Response.Redirect("ShopRank_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	private void method_7()
	{
		ShopNum1_ShopRank shopNum1_ShopRank = new ShopNum1_ShopRank();
		shopNum1_ShopRank.Name = this.TextBoxName.Text;
		shopNum1_ShopRank.MaxProductCount = new int?(int.Parse(this.TextBoxMaxProduct.Text.Trim()));
		shopNum1_ShopRank.MaxFileCount = new int?(999);
		shopNum1_ShopRank.StartTime = new DateTime?(DateTime.Now);
		shopNum1_ShopRank.validityDate = "";
		shopNum1_ShopRank.price = new decimal?(Convert.ToDecimal(this.TextBoxPrice.Text.Trim()));
		string text = this.HiddenFieldPic.Value;
		if (text != "" && text.IndexOf("20x20") == -1)
		{
			string text2 = "/ImgUpload/Main/Rank/";
			if (!Directory.Exists(HttpContext.Current.Server.MapPath(text2)))
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath(text2));
			}
			text2 = text2 + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg_20x20.jpg";
			try
			{
				ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(text), HttpContext.Current.Server.MapPath(text2), 20, 20);
			}
			catch
			{
			}
			text = text2;
		}
		shopNum1_ShopRank.Pic = text;
		shopNum1_ShopRank.IsSetSEO = int.Parse(this.DropDownListIsSetSEO.SelectedValue);
		shopNum1_ShopRank.shopTemplate = this.CheckGuid.Value.Replace("'", "");
		shopNum1_ShopRank.IsOverrideDomain = new int?(1);
		shopNum1_ShopRank.MaxPanicBuyCount = new int?(99999);
		shopNum1_ShopRank.MaxSpellBuyCount = new int?(99999);
		shopNum1_ShopRank.MaxArticleCout = new int?(int.Parse(this.TextBoxMaxArticleCout.Text.Trim()));
		shopNum1_ShopRank.MaxVedioCount = new int?(int.Parse(this.TextBoxMaxVedioCount.Text.Trim()));
		shopNum1_ShopRank.IsDefault = 1;
		shopNum1_ShopRank.CreateTime = new DateTime?(DateTime.Now);
		shopNum1_ShopRank.CreateUser = "admin";
		shopNum1_ShopRank.Guid = Guid.NewGuid();
		shopNum1_ShopRank.RankValue = new int?(Convert.ToInt32(this.TextBoxRankValue.Text.Trim()));
		Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
		int num = shop_Rank_Action.Add(shopNum1_ShopRank);
		if (num > 0)
		{
			this.method_8();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	private void method_8()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxMaxProduct.Text = string.Empty;
		this.TextBoxStartTime.Text = string.Empty;
		this.HiddenFieldPic.Value = string.Empty;
		this.TextBoxPrice.Text = string.Empty;
		this.TextBoxMaxArticleCout.Text = string.Empty;
		this.TextBoxMaxVedioCount.Text = string.Empty;
		this.DropDownListIsSetSEO.SelectedValue = "-1";
	}
}
