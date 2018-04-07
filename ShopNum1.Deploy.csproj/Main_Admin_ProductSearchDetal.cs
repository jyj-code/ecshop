using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ProductSearchDetal : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected TextBox TextBoxProductCategory;
	protected TextBox TextBoxProductBrand;
	protected TextBox TextBoxShopProductCategory;
	protected TextBox TextBoxProductName;
	protected TextBox TextBoxProductType;
	protected TextBox TextBoxType;
	protected Label LocalizeBuyCount;
	protected TextBox TextBoxBuyCount;
	protected TextBox TextBoxProductNum;
	protected TextBox TextBoxProductUnit;
	protected TextBox TextBoxMarketPrice;
	protected TextBox TextBoxShopPrice;
	protected TextBox TextBoxProfit;
	protected TextBox TextBoxFeeType;
	protected TextBox TextBoxTitle;
	protected TextBox TextBoxKeywords;
	protected TextBox TextBoxDescribe;
	protected TextBox TextBoxPost_fee;
	protected TextBox TextBoxExpress_fee;
	protected TextBox TextBoxEms_fee;
	protected Image ProductImage;
	protected DataList DataListPorductImage;
	protected TextBox FCKeditorDetail;
	protected TextBox FCKeditorInstruction;
	protected Label LocalizePrice;
	protected TextBox TextBoxPrice;
	protected Label LabelPriceName;
	protected Label LocalizeBuyStartTime;
	protected TextBox TextBoxBuyStartTime;
	protected HtmlTableRow TrStartTime;
	protected Label LocalizeBuyEndTime;
	protected TextBox TextBoxBuyEndTime;
	protected HtmlTableRow TrEndTime;
	protected Label LocalizeMemberCount;
	protected TextBox TextBoxSpellMemberCount;
	protected Label LocalizeMemberMM;
	protected Button ButtonAudit;
	protected Button ButtonCancelAudit;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldRegionCode;
	protected HiddenField HiddenFieldMemLoginID;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField hiddenFieldType;
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
		if (!this.Page.IsPostBack)
		{
			this.hiddenFieldGuid.Value = this.Page.Request.QueryString["Guid"].Replace("'", "");
			this.hiddenFieldType.Value = this.Page.Request.QueryString["Type"].ToString();
			this.ViewState["Back"] = this.Page.Request.QueryString["Back"];
		}
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
		DataTable shopInfoByGuid = shopNum1_ProuductChecked_Action.GetShopInfoByGuid("'" + this.hiddenFieldGuid.Value + "'");
		this.TextBoxProductCategory.Text = shopInfoByGuid.Rows[0]["ProductCategoryName"].ToString();
		this.TextBoxProductBrand.Text = shopInfoByGuid.Rows[0]["BrandName"].ToString();
		this.TextBoxShopProductCategory.Text = shopInfoByGuid.Rows[0]["ProductSeriesName"].ToString();
		this.TextBoxProductName.Text = shopInfoByGuid.Rows[0]["Name"].ToString();
		this.TextBoxProductType.Text = ((shopInfoByGuid.Rows[0]["IsReal"].ToString() == "0") ? "虚拟物品" : "实际物品");
		this.TextBoxProductNum.Text = shopInfoByGuid.Rows[0]["ProductNum"].ToString();
		this.TextBoxProductUnit.Text = shopInfoByGuid.Rows[0]["UnitName"].ToString();
		this.TextBoxShopPrice.Text = shopInfoByGuid.Rows[0]["ShopPrice"].ToString();
		this.TextBoxMarketPrice.Text = shopInfoByGuid.Rows[0]["MarketPrice"].ToString();
		this.TextBoxBuyCount.Text = shopInfoByGuid.Rows[0]["repertorycount"].ToString();
		this.TextBoxKeywords.Text = shopInfoByGuid.Rows[0]["Keywords"].ToString();
		this.TextBoxDescribe.Text = shopInfoByGuid.Rows[0]["Description"].ToString();
		this.TextBoxBuyStartTime.Text = shopInfoByGuid.Rows[0]["starttime"].ToString();
		this.TextBoxBuyEndTime.Text = shopInfoByGuid.Rows[0]["endtime"].ToString();
		this.TextBoxFeeType.Text = ((shopInfoByGuid.Rows[0]["FeeType"].ToString() == "0") ? "买家承担" : "卖家承担");
		if (shopInfoByGuid.Rows[0]["FeeType"].ToString() == "0")
		{
			this.TextBoxPost_fee.Text = shopInfoByGuid.Rows[0]["Post_fee"].ToString();
			this.TextBoxExpress_fee.Text = shopInfoByGuid.Rows[0]["Express_fee"].ToString();
			this.TextBoxEms_fee.Text = shopInfoByGuid.Rows[0]["Ems_fee"].ToString();
		}
		this.FCKeditorDetail.Text = this.Page.Server.HtmlDecode(shopInfoByGuid.Rows[0]["Detail"].ToString());
		this.ProductImage.ImageUrl = shopInfoByGuid.Rows[0]["OriginalImage"].ToString();
		this.FCKeditorInstruction.Text = this.Page.Server.HtmlDecode(shopInfoByGuid.Rows[0]["Instruction"].ToString());
		this.BindMultiImageTable(shopInfoByGuid.Rows[0]["MultiImages"].ToString());
		if (this.hiddenFieldType.Value == "Other")
		{
			this.LabelPageTitle.Text = "商品查看页";
			this.LocalizePrice.Text = "商品价：";
			this.LocalizeBuyStartTime.Text = "开始时间：";
			this.LocalizeBuyEndTime.Text = "结束时间：";
			this.LocalizeBuyCount.Text = "商品数量：";
			this.LocalizeMemberCount.Text = "购买人数:";
			this.LocalizeMemberCount.Visible = false;
			this.TextBoxSpellMemberCount.Visible = false;
			this.LocalizeMemberMM.Visible = false;
			this.TrStartTime.Visible = false;
			this.TrEndTime.Visible = false;
		}
		else
		{
			this.hiddenFieldType.Visible = true;
			if (this.hiddenFieldType.Value == "Panic")
			{
				this.LabelPageTitle.Text = "抢购商品查看页";
				this.LocalizePrice.Text = "抢购价：";
				this.LocalizeBuyStartTime.Text = "抢购开始时间：";
				this.LocalizeBuyEndTime.Text = "抢购结束时间：";
				this.LocalizeBuyCount.Text = "抢购商品数量：";
				this.LocalizeMemberCount.Text = "抢购人数：";
				this.LocalizeMemberMM.Text = "最少抢购人数";
				this.LabelPriceName.Text = "抢购价";
			}
			else if (this.hiddenFieldType.Value == "Spell")
			{
				this.LabelPageTitle.Text = "团购商品查看页";
				this.LocalizePrice.Text = "团购价：";
				this.LocalizeBuyStartTime.Text = "团购开始时间：";
				this.LocalizeBuyEndTime.Text = "团购结束时间：";
				this.LocalizeBuyCount.Text = "团购商品数量：";
				this.LocalizeMemberCount.Text = "团购人数：";
				this.LocalizeMemberMM.Text = "最少团购人数";
			}
		}
		if (shopInfoByGuid.Rows[0]["isAudit"].ToString() == "1" || shopInfoByGuid.Rows[0]["isAudit"].ToString() == "2")
		{
			this.ButtonAudit.Visible = false;
			this.ButtonCancelAudit.Visible = false;
		}
	}
	protected void BindMultiImageTable(string srePics)
	{
		string[] array = srePics.Split(new char[]
		{
			','
		});
		DataTable dataTable = new DataTable();
		DataColumn dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.Guid");
		dataColumn.ColumnName = "Guid";
		dataTable.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "OriginalImge";
		dataTable.Columns.Add(dataColumn);
		for (int i = 0; i < array.Length; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["Guid"] = Guid.NewGuid();
			dataRow["OriginalImge"] = array[i];
			dataTable.Rows.Add(dataRow);
		}
		this.DataListPorductImage.DataSource = dataTable.DefaultView;
		this.DataListPorductImage.DataBind();
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
		if (shopNum1_ProuductChecked_Action.Update("'" + this.hiddenFieldGuid.Value + "'", "1") > 0)
		{
			this.MessageShow.ShowMessage("Audit1Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit1No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		object obj = this.hiddenFieldGuid.Value;
		if (obj == "0")
		{
			obj = "null";
		}
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
		if (shopNum1_ProuductChecked_Action.Update("'" + obj.ToString() + "'", "2") > 0)
		{
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (this.ViewState["Back"].ToString() == "1")
		{
			base.Response.Redirect("Prouduct_List.aspx");
		}
		if (this.ViewState["Back"].ToString() == "2")
		{
			base.Response.Redirect("ProuductChecked_List.aspx");
		}
		if (this.ViewState["Back"].ToString() == "3")
		{
			base.Response.Redirect("ProuductPanicBuy_List.aspx");
		}
		if (this.ViewState["Back"].ToString() == "4")
		{
			base.Response.Redirect("Prouduct_PanicChecked_List.aspx");
		}
		if (this.ViewState["Back"].ToString() == "5")
		{
			base.Response.Redirect("ProuductSpellBuy_List.aspx");
		}
		if (this.ViewState["Back"].ToString() == "6")
		{
			base.Response.Redirect("Prouduct_SpellChecked_List.aspx");
		}
	}
}
