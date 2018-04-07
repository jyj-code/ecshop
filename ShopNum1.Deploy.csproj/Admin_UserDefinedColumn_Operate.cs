using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_UserDefinedColumn_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Localize LocalizeName;
	protected TextBox TextBoxName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Label Label4;
	protected Localize LocalizeLinkAddress;
	protected TextBox TextBoxLinkAddress;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorAddress;
	protected Label Label5;
	protected Localize Localize1;
	protected DropDownList DropDownListIsShop;
	protected CompareValidator CompareValidatorIsShop;
	protected Localize Localize2;
	protected DropDownList DropDownListIsMember;
	protected CompareValidator CompareValidatorIsMember;
	protected Localize Localize3;
	protected DropDownList DropDownListIsSite;
	protected CompareValidator CompareValidatorIsSite;
	protected Localize LocalizeShowLocation;
	protected DropDownList DropDownListShowLocation;
	protected CompareValidator CompareShowLocation;
	protected Localize LocalizeIfOpen;
	protected DropDownList DropDownListIfOpen;
	protected CompareValidator CompareOpen;
	protected Localize LocalizeOrderID;
	protected TextBox TextBoxOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryOrderID;
	protected Localize Localize5;
	protected DropDownList DropDownListIfShow;
	protected Localize LocalizeRemark;
	protected TextBox TextBoxRemark;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorRemark;
	protected RegularExpressionValidator RegularExpressionValidatorRemark;
	protected Button ButtonConfirm;
	protected Button Button1;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!this.Page.IsPostBack)
		{
			this.DropDownListBind(this.DropDownListIfOpen);
			this.DropDownListBind(this.DropDownListIfShow);
			this.DropDownListBind(this.DropDownListIsShop);
			this.DropDownListBind(this.DropDownListIsMember);
			this.DropDownListBind(this.DropDownListIsSite);
			this.ShowLocationBind();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑栏目";
				this.GetEditInfo();
			}
			else
			{
				this.GetOrderID();
			}
		}
	}
	protected void DropDownListBind(DropDownList dropDownList)
	{
		dropDownList.Items.Add(new ListItem("是", "1"));
		dropDownList.Items.Add(new ListItem("否", "0"));
	}
	protected void ShowLocationBind()
	{
		this.DropDownListShowLocation.Items.Add(new ListItem("中部导航", "0"));
		this.DropDownListShowLocation.Items.Add(new ListItem("底部导航", "1"));
	}
	protected void GetOrderID()
	{
		try
		{
			string nameById = Common.GetNameById("max(OrderID)", "ShopNum1_UserDefinedColumn", "   AND  SubstationID='all'    ");
			if (!string.IsNullOrEmpty(nameById))
			{
				this.TextBoxOrderID.Text = (Convert.ToInt32(nameById) + 1).ToString();
			}
			else
			{
				this.TextBoxOrderID.Text = "0";
			}
		}
		catch (Exception)
		{
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
		ShopNum1_UserDefinedColumn_Action shopNum1_UserDefinedColumn_Action = (ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
		DataTable editInfo = shopNum1_UserDefinedColumn_Action.GetEditInfo(this.hiddenFieldGuid.Value.ToString());
		this.TextBoxName.Text = editInfo.Rows[0]["Name"].ToString();
		this.TextBoxLinkAddress.Text = editInfo.Rows[0]["LinkAddress"].ToString();
		this.DropDownListShowLocation.SelectedValue = editInfo.Rows[0]["ShowLocation"].ToString();
		this.DropDownListIfShow.SelectedValue = editInfo.Rows[0]["IfShow"].ToString();
		this.DropDownListIfOpen.SelectedValue = editInfo.Rows[0]["IfOpen"].ToString();
		this.DropDownListIsShop.SelectedValue = editInfo.Rows[0]["IsShop"].ToString();
		this.DropDownListIsMember.SelectedValue = editInfo.Rows[0]["IsMember"].ToString();
		this.DropDownListIsSite.SelectedValue = editInfo.Rows[0]["IsSite"].ToString();
		this.TextBoxRemark.Text = editInfo.Rows[0]["Remark"].ToString();
		this.TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
	}
	protected void Add()
	{
		ShopNum1_UserDefinedColumn shopNum1_UserDefinedColumn = new ShopNum1_UserDefinedColumn();
		shopNum1_UserDefinedColumn.Guid = Guid.NewGuid();
		shopNum1_UserDefinedColumn.Name = this.TextBoxName.Text.Trim();
		shopNum1_UserDefinedColumn.LinkAddress = this.TextBoxLinkAddress.Text.Trim();
		shopNum1_UserDefinedColumn.ShowLocation = this.DropDownListShowLocation.SelectedValue.ToString();
		shopNum1_UserDefinedColumn.IfShow = Convert.ToInt32(this.DropDownListIfShow.SelectedValue.ToString());
		shopNum1_UserDefinedColumn.IfOpen = Convert.ToInt32(this.DropDownListIfOpen.SelectedValue.ToString());
		shopNum1_UserDefinedColumn.Remark = this.TextBoxRemark.Text.Trim();
		shopNum1_UserDefinedColumn.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
		shopNum1_UserDefinedColumn.CreateUser = "admin";
		shopNum1_UserDefinedColumn.CreateTime = DateTime.Now;
		shopNum1_UserDefinedColumn.ModifyUser = "admin";
		shopNum1_UserDefinedColumn.ModifyTime = DateTime.Now;
		shopNum1_UserDefinedColumn.IsShop = Convert.ToInt32(this.DropDownListIsShop.SelectedValue.ToString());
		shopNum1_UserDefinedColumn.IsMember = Convert.ToInt32(this.DropDownListIsMember.SelectedValue.ToString());
		shopNum1_UserDefinedColumn.IsSite = Convert.ToInt32(this.DropDownListIsSite.SelectedValue.ToString());
		shopNum1_UserDefinedColumn.IsDeleted = 0;
		shopNum1_UserDefinedColumn.SubstationID = "all";
		ShopNum1_UserDefinedColumn_Action shopNum1_UserDefinedColumn_Action = (ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
		int num = shopNum1_UserDefinedColumn_Action.Insert(shopNum1_UserDefinedColumn);
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
		ShopNum1_UserDefinedColumn shopNum1_UserDefinedColumn = new ShopNum1_UserDefinedColumn();
		shopNum1_UserDefinedColumn.Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", ""));
		shopNum1_UserDefinedColumn.Name = this.TextBoxName.Text.Trim();
		shopNum1_UserDefinedColumn.LinkAddress = this.TextBoxLinkAddress.Text.Trim();
		shopNum1_UserDefinedColumn.ShowLocation = this.DropDownListShowLocation.SelectedValue.ToString();
		shopNum1_UserDefinedColumn.IfShow = Convert.ToInt32(this.DropDownListIfShow.SelectedValue.ToString());
		shopNum1_UserDefinedColumn.IfOpen = Convert.ToInt32(this.DropDownListIfOpen.SelectedValue.ToString());
		shopNum1_UserDefinedColumn.Remark = this.TextBoxRemark.Text.Trim();
		shopNum1_UserDefinedColumn.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
		shopNum1_UserDefinedColumn.IsShop = Convert.ToInt32(this.DropDownListIsShop.SelectedValue.ToString());
		shopNum1_UserDefinedColumn.IsMember = Convert.ToInt32(this.DropDownListIsMember.SelectedValue.ToString());
		shopNum1_UserDefinedColumn.IsSite = Convert.ToInt32(this.DropDownListIsSite.SelectedValue.ToString());
		shopNum1_UserDefinedColumn.ModifyUser = "admin";
		shopNum1_UserDefinedColumn.ModifyTime = DateTime.Now;
		shopNum1_UserDefinedColumn.IsDeleted = 0;
		ShopNum1_UserDefinedColumn_Action shopNum1_UserDefinedColumn_Action = (ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
		int num = shopNum1_UserDefinedColumn_Action.Update(shopNum1_UserDefinedColumn);
		if (num > 0)
		{
			base.Response.Redirect("UserDefinedColumn_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ClearControl()
	{
		this.TextBoxLinkAddress.Text = string.Empty;
		this.TextBoxRemark.Text = string.Empty;
		this.TextBoxName.Text = string.Empty;
		this.DropDownListIfShow.SelectedValue = "1";
		this.DropDownListIfOpen.SelectedValue = "1";
	}
}
