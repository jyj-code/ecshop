using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Agent_AgentAdmin_AgentProuductChecked_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelTitle;
	protected Localize LocalizeName;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected Localize LocalizeShopName;
	protected System.Web.UI.WebControls.TextBox TextBoxShopName;
	protected Localize LocalizeProductGuid;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid1;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid2;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid3;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
	protected Localize LocalizeRepertoryNumber;
	protected System.Web.UI.WebControls.TextBox TextBoxRepertoryNumber;
	protected Localize Localize1;
	protected System.Web.UI.WebControls.TextBox TextBoxShopID;
	protected Localize LocalizeIsAudit;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected Localize LocalizePrice;
	protected System.Web.UI.WebControls.TextBox TextBoxPrice1;
	protected RegularExpressionValidator RegularExpressionValidatorCostPrice1;
	protected System.Web.UI.WebControls.TextBox TextBoxPrice2;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Localize LocalizesSName;
	protected System.Web.UI.WebControls.TextBox TextBoxSName;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsShopNew;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsShopGood;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected System.Web.UI.WebControls.Button Button1;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsSaled;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsSell;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsShopHot;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsShopRecommend;
	protected LinkButton ButtonSearchDetail;
	protected LinkButton ButtonAudit;
	protected LinkButton ButtonCancelAudit;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldCode;
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
			this.GetSubstationID();
			this.DropDownListProductGuidBind();
			this.method_6();
			this.method_5();
			this.BindGrid();
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
	private void method_5()
	{
		this.DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
	}
	protected void BindGrid()
	{
		this.SetCode();
		this.Num1GridViewShow.DataBind();
	}
	private void method_6()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-1";
		this.DropDownListIsSaled.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "否";
		listItem2.Value = "0";
		this.DropDownListIsSaled.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "是";
		listItem3.Value = "1";
		this.DropDownListIsSaled.Items.Add(listItem3);
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.SetCode();
		this.BindGrid();
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
		if (shopNum1_ProuductChecked_Action.Update(this.CheckGuid.Value, "1") > 0)
		{
			this.BindGrid();
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
		object obj = this.CheckGuid.Value;
		if (obj == "0")
		{
			obj = "null";
		}
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
		if (shopNum1_ProuductChecked_Action.Update(obj.ToString(), "2") > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
		if (shopNum1_ProuductChecked_Action.Delete(this.CheckGuid.Value.ToString()) > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void LinkDelte_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
		if (shopNum1_ProuductChecked_Action.Delete("'" + commandArgument + "'") > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonSearchDetail_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProductSearchDetal.aspx?guid=" + this.CheckGuid.Value.Replace("'", "") + "&Type=Other&Back=2");
	}
	protected void ButtonSearchBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string str = "'" + linkButton.CommandArgument + "'";
		base.Response.Redirect("ProductSearchDetal.aspx?guid=" + str + "&Type=Other&Back=2");
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
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
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "已审核";
		}
		else if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	public void SetCode()
	{
		if (this.DropDownListProductGuid3.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid3.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.HiddenFieldCode.Value = "-1";
		}
	}
}
