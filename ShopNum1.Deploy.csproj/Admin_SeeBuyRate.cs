using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_SeeBuyRate : PageBase, IRequiresSessionState
{
	protected const string SeeBuyRate_Report = "SeeBuyRate_Report.aspx";
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected Label LabelBrandGuid;
	protected System.Web.UI.WebControls.DropDownList DropDownListBrandGuid;
	protected Label LabelShopPrice;
	protected System.Web.UI.WebControls.TextBox TextBoxShopPrice1;
	protected RegularExpressionValidator RegularExpressionValidatorShopPrice1;
	protected System.Web.UI.WebControls.TextBox TextBoxShopPrice2;
	protected RegularExpressionValidator RegularExpressionValidatorShopPrice2;
	protected CompareValidator CompareValidatorTextBoxShopPrice2;
	protected Label LabelMarketPrice;
	protected System.Web.UI.WebControls.TextBox TextBoxMarketPrice1;
	protected RegularExpressionValidator RegularExpressionValidatorMarketPrice1;
	protected System.Web.UI.WebControls.TextBox TextBoxMarketPrice2;
	protected RegularExpressionValidator RegularExpressionValidatorMarketPrice2;
	protected CompareValidator CompareValidatorTextBoxMarketPrice2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Label Label1;
	protected System.Web.UI.WebControls.TextBox txtProductName;
	protected Label LabelProductCategoryID;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid1;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid2;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid3;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
	protected System.Web.UI.WebControls.Button Button1;
	protected LinkButton ButtonReport;
	protected LinkButton ButtonHtml;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HtmlForm form1;
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
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
			this.GetSubstationID();
			this.BindProductCategory();
			this.BindBrand();
			this.DropDownListProductGuidBind();
		}
	}
	public string GetSubstationIDname(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		string result;
		if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
		{
			result = dataBySubstationID.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "分站不存在";
		}
		return result;
	}
	public void GetSubstationID()
	{
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void DropDownListProductGuidBind()
	{
		this.DropDownListProductGuid1.Items.Clear();
		this.DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
		DataTable list = shopNum1_ProuductChecked_Action.GetList("0");
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListProductGuid1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
		}
		this.DropDownListProductGuid1_SelectedIndexChanged(null, null);
	}
	protected void DropDownListProductGuid1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListProductGuid2.Items.Clear();
		this.DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable list = shopNum1_ProuductChecked_Action.GetList(this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListProductGuid2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListProductGuid2_SelectedIndexChanged(null, null);
	}
	protected void DropDownListProductGuid2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListProductGuid3.Items.Clear();
		this.DropDownListProductGuid3.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable list = shopNum1_ProuductChecked_Action.GetList(this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListProductGuid3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
	}
	protected void BindProductCategory()
	{
	}
	protected void AddSubProductCategory(DataTable dataTable)
	{
	}
	protected void BindBrand()
	{
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("All");
		listItem.Value = "-1";
		this.DropDownListBrandGuid.Items.Add(listItem);
		ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Brand_Action();
		DataView defaultView = shopNum1_Brand_Action.Search(0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["Guid"].ToString().Trim();
			this.DropDownListBrandGuid.Items.Add(listItem2);
		}
	}
	protected void ButtonReport_Click(object sender, EventArgs e)
	{
		if (this.DropDownListProductGuid3.SelectedValue != "-1")
		{
			this.DropDownListProductGuid3.SelectedValue.Split(new char[]
			{
				'/'
			})[0].Trim();
		}
		else if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[0].Trim();
		}
		else if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[0].Trim();
		}
		base.Response.Redirect(string.Concat(new string[]
		{
			"SeeBuyRate_Report.aspx?Type=xls&name=",
			this.txtProductName.Text,
			"&ProductCategoryCode1=",
			this.DropDownListProductGuid1.SelectedValue,
			"&ProductCategoryCode2=",
			this.DropDownListProductGuid2.SelectedValue,
			"&ProductCategoryCode3=",
			this.DropDownListProductGuid3.SelectedValue,
			"&BrandGuid=",
			this.DropDownListBrandGuid.SelectedValue,
			"&&ShopPrice1=",
			this.TextBoxShopPrice1.Text.Trim(),
			"&&ShopPrice2=",
			this.TextBoxShopPrice2.Text.Trim(),
			"&&MarketPrice1=",
			this.TextBoxMarketPrice1.Text.Trim(),
			"&&MarketPrice2=",
			this.TextBoxMarketPrice2.Text.Trim()
		}));
	}
	protected void ButtonHtml_Click(object sender, EventArgs e)
	{
		if (this.DropDownListProductGuid3.SelectedValue != "-1")
		{
			this.DropDownListProductGuid3.SelectedValue.Split(new char[]
			{
				'/'
			})[0].Trim();
		}
		else if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[0].Trim();
		}
		else if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[0].Trim();
		}
		base.Response.Redirect(string.Concat(new string[]
		{
			"SeeBuyRate_Report.aspx?Type=html&name=",
			this.txtProductName.Text,
			"&ProductCategoryCode1=",
			this.DropDownListProductGuid1.SelectedValue,
			"&ProductCategoryCode2=",
			this.DropDownListProductGuid2.SelectedValue,
			"&ProductCategoryCode3=",
			this.DropDownListProductGuid3.SelectedValue,
			"&BrandGuid=",
			this.DropDownListBrandGuid.SelectedValue,
			"&&ShopPrice1=",
			this.TextBoxShopPrice1.Text.Trim(),
			"&&ShopPrice2=",
			this.TextBoxShopPrice2.Text.Trim(),
			"&&MarketPrice1=",
			this.TextBoxMarketPrice1.Text.Trim(),
			"&&MarketPrice2=",
			this.TextBoxMarketPrice2.Text.Trim()
		}));
	}
}
