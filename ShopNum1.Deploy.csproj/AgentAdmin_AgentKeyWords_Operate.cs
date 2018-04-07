using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_AgentKeyWords_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelKeyWords;
	protected TextBox TextBoxKeyWords;
	protected Label Label5;
	protected RequiredFieldValidator RequiredFieldValidatorKeyWords;
	protected RegularExpressionValidator RegularExpressionValidatorKeyWords;
	protected Label LabelCount;
	protected TextBox TextBoxCount;
	protected Label Label8;
	protected RequiredFieldValidator RequiredFieldValidatorCount;
	protected RegularExpressionValidator RegularExpressionValidatorCount;
	protected Label LabelType;
	protected DropDownList DropDownListType;
	protected Label Label6;
	protected CompareValidator CompareValidatorType;
	protected Label LabelIfShow;
	protected DropDownList DropDownListIfShow;
	protected Label Label7;
	protected CompareValidator CompareValidatorIfShow;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldAgentID;
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
		this.hiddenFieldGuid.Value = ((this.Page.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!this.Page.IsPostBack)
		{
			this.BindStatus();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "【 编辑关键字 】";
				this.GetEditInfo();
			}
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_KeyWords_Action shopNum1_KeyWords_Action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
		DataTable editInfo = shopNum1_KeyWords_Action.GetEditInfo(this.hiddenFieldGuid.Value);
		this.TextBoxKeyWords.Text = editInfo.Rows[0]["Name"].ToString();
		this.TextBoxCount.Text = editInfo.Rows[0]["Count"].ToString();
		this.DropDownListIfShow.SelectedValue = editInfo.Rows[0]["IfShow"].ToString();
		this.DropDownListType.SelectedValue = editInfo.Rows[0]["Type"].ToString();
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
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
	protected void Add()
	{
		ShopNum1_KeyWords shopNum1_KeyWords = new ShopNum1_KeyWords();
		shopNum1_KeyWords.Guid = Guid.NewGuid();
		shopNum1_KeyWords.Name = this.TextBoxKeyWords.Text.Trim();
		shopNum1_KeyWords.Type = Convert.ToInt32(this.DropDownListType.SelectedValue);
		shopNum1_KeyWords.Count = Convert.ToInt32(this.TextBoxCount.Text.Trim());
		shopNum1_KeyWords.IfShow = Convert.ToInt32(this.DropDownListIfShow.SelectedValue);
		shopNum1_KeyWords.CreateUser = "admin";
		shopNum1_KeyWords.CreateTime = DateTime.Now;
		shopNum1_KeyWords.ModifyUser = "admin";
		shopNum1_KeyWords.ModifyTime = DateTime.Now;
		shopNum1_KeyWords.IsDeleted = 0;
		shopNum1_KeyWords.SubstationID = base.SubstationID;
		ShopNum1_KeyWords_Action shopNum1_KeyWords_Action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
		int num = shopNum1_KeyWords_Action.Add(shopNum1_KeyWords);
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
	protected void Edit()
	{
		ShopNum1_KeyWords shopNum1_KeyWords = new ShopNum1_KeyWords();
		shopNum1_KeyWords.Name = this.TextBoxKeyWords.Text.Trim();
		shopNum1_KeyWords.Type = Convert.ToInt32(this.DropDownListType.SelectedValue);
		shopNum1_KeyWords.Count = Convert.ToInt32(this.TextBoxCount.Text.Trim());
		shopNum1_KeyWords.IfShow = Convert.ToInt32(this.DropDownListIfShow.SelectedValue);
		shopNum1_KeyWords.ModifyUser = "admin";
		shopNum1_KeyWords.ModifyTime = DateTime.Now;
		shopNum1_KeyWords.IsDeleted = 0;
		ShopNum1_KeyWords_Action shopNum1_KeyWords_Action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
		int num = shopNum1_KeyWords_Action.Update(this.hiddenFieldGuid.Value, shopNum1_KeyWords);
		if (num > 0)
		{
			base.Response.Redirect("KeyWords_Manage.aspx");
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void BindStatus()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-请选择-";
		listItem.Value = "-1";
		ListItem listItem2 = new ListItem();
		listItem2.Text = "商品";
		listItem2.Value = "0";
		ListItem listItem3 = new ListItem();
		listItem3.Text = "资讯";
		listItem3.Value = "1";
		ListItem listItem4 = new ListItem();
		listItem4.Text = "显示";
		listItem4.Value = "1";
		this.DropDownListIfShow.Items.Add(listItem4);
		ListItem listItem5 = new ListItem();
		listItem5.Text = "不显示";
		listItem5.Value = "0";
		this.DropDownListIfShow.Items.Add(listItem5);
	}
	protected void ClearControl()
	{
		this.TextBoxKeyWords.Text = string.Empty;
		this.TextBoxCount.Text = string.Empty;
		this.DropDownListType.SelectedValue = "-1";
		this.DropDownListIfShow.SelectedValue = "1";
		this.ButtonConfirm.Text = "确定";
		this.ButtonConfirm.ToolTip = "Submit";
	}
}
