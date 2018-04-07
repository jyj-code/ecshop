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
public class Admin_ShopDoMain_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Label LabelShopName;
	protected TextBox TextBoxShopName;
	protected Label Label6;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxShopName;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxShopName;
	protected Label LabelGoUrl;
	protected TextBox TextBoxGoUrl;
	protected Label Label5;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxGoUrl;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxGoUrl;
	protected Label Label2;
	protected TextBox TextBoxSiteNumber;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Button ButtonConfirm;
	protected HtmlInputReset inputReset;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!this.Page.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.ViewState["DoMain"] = "";
			this.GetEditInfo();
		}
	}
	public void BindShopLoginID()
	{
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)LogicFactory.CreateShopNum1_ShopURLManage_Action();
		DataTable shopLoginID = shopNum1_ShopURLManage_Action.GetShopLoginID(base.Request.QueryString["MemLoginID"].ToString().Replace("'", ""));
		this.HiddenFieldAgentID.Value = shopLoginID.Rows[0]["MemLoginID"].ToString();
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
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)LogicFactory.CreateShopNum1_ShopURLManage_Action();
		DataTable editInfo = shopNum1_ShopURLManage_Action.GetEditInfo(this.hiddenFieldGuid.Value.Replace("'", ""));
		this.TextBoxName.Text = editInfo.Rows[0]["DoMain"].ToString();
		this.TextBoxSiteNumber.Text = editInfo.Rows[0]["SiteNumber"].ToString();
		this.TextBoxShopName.Text = editInfo.Rows[0]["MemLoginID"].ToString();
		this.TextBoxGoUrl.Text = editInfo.Rows[0]["GoUrl"].ToString();
		this.ViewState["DoMain"] = editInfo.Rows[0]["DoMain"].ToString();
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
		this.LabelPageTitle.Text = "【 编辑域名 】";
	}
	protected void Add()
	{
		ShopNum1_ShopURLManage shopNum1_ShopURLManage = new ShopNum1_ShopURLManage();
		shopNum1_ShopURLManage.DoMain = this.TextBoxName.Text;
		shopNum1_ShopURLManage.MemLoginID = this.TextBoxShopName.Text;
		shopNum1_ShopURLManage.SiteNumber = this.TextBoxSiteNumber.Text;
		shopNum1_ShopURLManage.GoUrl = this.TextBoxGoUrl.Text;
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)LogicFactory.CreateShopNum1_ShopURLManage_Action();
		DataTable dataTable = shopNum1_ShopURLManage_Action.CheckDoMain(this.TextBoxName.Text);
		if (dataTable.Rows.Count > 0)
		{
			MessageBox.Show("域名已存在!");
		}
		else
		{
			int num = shopNum1_ShopURLManage_Action.Add(shopNum1_ShopURLManage);
			if (num > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "新增" + this.TextBoxName.Text.Trim() + "成功",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "AgentDoMain_Operate.aspx",
					Date = DateTime.Now
				});
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
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)LogicFactory.CreateShopNum1_ShopURLManage_Action();
		DataTable dataTable = new DataTable();
		if (this.ViewState["DoMain"].ToString() != this.TextBoxName.Text)
		{
			dataTable = shopNum1_ShopURLManage_Action.CheckDoMain(this.TextBoxName.Text);
		}
		if (dataTable.Rows.Count > 0)
		{
			MessageBox.Show("域名已存在!");
		}
		else
		{
			int num = shopNum1_ShopURLManage_Action.Update(this.hiddenFieldGuid.Value.Replace("'", ""), this.TextBoxName.Text, this.TextBoxSiteNumber.Text);
			if (num > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "编辑" + this.TextBoxName.Text.Trim() + "成功",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "AgentDoMain_Operate.aspx",
					Date = DateTime.Now
				});
				base.Response.Redirect("ShopDoMain_List.aspx");
			}
			else
			{
				this.MessageShow.ShowMessage("EditNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void ClearControl()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxSiteNumber.Text = string.Empty;
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopDoMain_List.aspx");
	}
}
