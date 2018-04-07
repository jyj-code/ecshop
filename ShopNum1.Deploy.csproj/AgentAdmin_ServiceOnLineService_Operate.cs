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
public class AgentAdmin_ServiceOnLineService_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeType;
	protected DropDownList DropDownListType;
	protected Label Label1;
	protected CompareValidator CompareDropDownListType;
	protected Localize LocalizeName;
	protected TextBox TextBoxName;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxName;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxName;
	protected Localize LocalizeServiceAccount;
	protected TextBox TextBoxServiceAccount;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxServiceAccount;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxServiceAccount;
	protected Localize LocalizeOrderID;
	protected TextBox TextBoxOrderID;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxOrderID;
	protected Localize Localize5;
	protected CheckBox CheckBoxIsShow;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
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
		if (!base.IsPostBack)
		{
			this.method_5();
			this.method_6();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelTitle.Text = "编辑在线客服";
				this.GetEditInfo();
			}
			else
			{
				this.TextBoxOrderID.Text = Convert.ToString(this.method_5() + 1);
			}
		}
	}
	protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListType.SelectedValue == "WW")
		{
			this.LocalizeServiceAccount.Text = "阿里旺旺会员名：";
		}
		else
		{
			this.LocalizeServiceAccount.Text = "在线客服账号：";
		}
	}
	private int method_5()
	{
		return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_OnlineService");
	}
	private void method_6()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-请选择-";
		listItem.Value = "-1";
		this.DropDownListType.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "在线QQ";
		listItem2.Value = "QQ";
		this.DropDownListType.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "在线旺旺";
		listItem3.Value = "WW";
		this.DropDownListType.Items.Add(listItem3);
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
		ShopNum1_OnLineService_Action shopNum1_OnLineService_Action = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
		DataTable editInfo = shopNum1_OnLineService_Action.GetEditInfo(this.hiddenFieldGuid.Value, 0);
		this.TextBoxName.Text = editInfo.Rows[0]["Name"].ToString();
		this.TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
		this.TextBoxServiceAccount.Text = editInfo.Rows[0]["ServiceAccount"].ToString();
		if (editInfo.Rows[0]["IsShow"].ToString() == "1")
		{
			this.CheckBoxIsShow.Checked = true;
		}
		else
		{
			this.CheckBoxIsShow.Checked = false;
		}
		this.DropDownListType.SelectedValue = editInfo.Rows[0]["Type"].ToString();
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
		this.DropDownListType_SelectedIndexChanged(null, null);
	}
	protected void Add()
	{
		if (this.DropDownListType.SelectedValue == "-1")
		{
			MessageBox.Show("请选择客服类型！");
		}
		else
		{
			ShopNum1_OnlineService shopNum1_OnlineService = new ShopNum1_OnlineService();
			shopNum1_OnlineService.Guid = Guid.NewGuid();
			shopNum1_OnlineService.Type = this.DropDownListType.SelectedValue;
			shopNum1_OnlineService.Name = this.TextBoxName.Text.Trim();
			shopNum1_OnlineService.ServiceAccount = this.TextBoxServiceAccount.Text.Trim();
			shopNum1_OnlineService.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
			shopNum1_OnlineService.Location = "-1";
			if (this.CheckBoxIsShow.Checked)
			{
				shopNum1_OnlineService.IsShow = 1;
			}
			else
			{
				shopNum1_OnlineService.IsShow = 0;
			}
			shopNum1_OnlineService.SubstationID = base.SubstationID;
			shopNum1_OnlineService.CreateUser = base.ShopNum1LoginID;
			shopNum1_OnlineService.CreateTime = DateTime.Now;
			shopNum1_OnlineService.ModifyUser = base.ShopNum1LoginID;
			shopNum1_OnlineService.ModifyTime = DateTime.Now;
			shopNum1_OnlineService.IsDeleted = 0;
			ShopNum1_OnLineService_Action shopNum1_OnLineService_Action = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
			int num = shopNum1_OnLineService_Action.Add(shopNum1_OnlineService);
			if (num > 0)
			{
				this.ClearControl();
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void Edit()
	{
		ShopNum1_OnlineService shopNum1_OnlineService = new ShopNum1_OnlineService();
		shopNum1_OnlineService.Type = this.DropDownListType.SelectedValue.ToString();
		shopNum1_OnlineService.Name = this.TextBoxName.Text.Trim();
		shopNum1_OnlineService.ServiceAccount = this.TextBoxServiceAccount.Text.Trim();
		shopNum1_OnlineService.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
		shopNum1_OnlineService.Location = "-1";
		if (this.CheckBoxIsShow.Checked)
		{
			shopNum1_OnlineService.IsShow = 1;
		}
		else
		{
			shopNum1_OnlineService.IsShow = 0;
		}
		shopNum1_OnlineService.ModifyUser = base.ShopNum1LoginID;
		shopNum1_OnlineService.ModifyTime = DateTime.Now;
		shopNum1_OnlineService.IsDeleted = 0;
		ShopNum1_OnLineService_Action shopNum1_OnLineService_Action = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
		int num = shopNum1_OnLineService_Action.Update(this.hiddenFieldGuid.Value, shopNum1_OnlineService);
		if (num > 0)
		{
			base.Response.Redirect("ServiceOnLineService_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ClearControl()
	{
		this.TextBoxServiceAccount.Text = string.Empty;
		this.TextBoxName.Text = string.Empty;
		this.DropDownListType.SelectedValue = "-1";
		this.TextBoxOrderID.Text = Convert.ToString(this.method_5() + 1);
	}
	protected void ButtonReset_Click(object sender, EventArgs e)
	{
		this.ClearControl();
	}
}
