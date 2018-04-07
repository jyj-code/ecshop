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
public class Admin_InfoControl_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelTitle;
	protected TextBox TextBoxPageName;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidatorTitle;
	protected RegularExpressionValidator RegularExpressionValidatorT;
	protected Label Label5;
	protected TextBox TextBoxPageFileName;
	protected Label Label6;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Label Label3;
	protected TextBox TextBoxControlName;
	protected Label Label7;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected RegularExpressionValidator RegularExpressionValidator3;
	protected Label Label8;
	protected TextBox TextBoxControlFileName;
	protected Label Label9;
	protected RequiredFieldValidator RequiredFieldValidator3;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Label Label1;
	protected TextBox TextBoxControlKey;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidator4;
	protected RegularExpressionValidator RegularExpressionValidator4;
	protected Label Label10;
	protected TextBox TextBoxControlImg;
	protected Label Label15;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected HtmlImage ImgControlImg;
	protected Label Label11;
	protected DropDownList DropDownListIsShow;
	protected Button BottonConfirm;
	protected Button BottonBack;
	protected Button ButtonSeeData;
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
			this.ClearControl();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑模块";
				this.GetEditInfo();
				this.ButtonSeeData.Visible = true;
			}
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.BottonConfirm.ToolTip == "Update")
		{
			this.Edit();
		}
		else if (this.BottonConfirm.ToolTip == "Submit")
		{
			this.Add();
		}
	}
	protected void Add()
	{
		ShopNum1_Control shopNum1_Control = new ShopNum1_Control();
		shopNum1_Control.Guid = Guid.NewGuid();
		shopNum1_Control.PageName = this.TextBoxPageName.Text;
		shopNum1_Control.PageFileName = this.TextBoxPageFileName.Text;
		shopNum1_Control.ControlName = this.TextBoxControlName.Text;
		shopNum1_Control.ControlFileName = this.TextBoxControlFileName.Text;
		shopNum1_Control.ControlKey = this.TextBoxControlKey.Text;
		shopNum1_Control.ControlImg = this.TextBoxControlImg.Text;
		shopNum1_Control.CreateUser = base.ShopNum1LoginID;
		shopNum1_Control.CreateTime = DateTime.Now;
		shopNum1_Control.ModifyUser = base.ShopNum1LoginID;
		shopNum1_Control.ModifyTime = DateTime.Now;
		shopNum1_Control.IsShow = int.Parse(this.DropDownListIsShow.SelectedValue);
		ShopNum1_Control_Action shopNum1_Control_Action = (ShopNum1_Control_Action)LogicFactory.CreateShopNum1_Control_Action();
		int num = shopNum1_Control_Action.Insert(shopNum1_Control);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "新增" + this.TextBoxPageFileName.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "InfoControl_Operate.aspx",
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
	protected void Edit()
	{
		ShopNum1_Control shopNum1_Control = new ShopNum1_Control();
		shopNum1_Control.Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", ""));
		shopNum1_Control.PageName = this.TextBoxPageName.Text;
		shopNum1_Control.PageFileName = this.TextBoxPageFileName.Text;
		shopNum1_Control.ControlName = this.TextBoxControlName.Text;
		shopNum1_Control.ControlFileName = this.TextBoxControlFileName.Text;
		shopNum1_Control.ControlKey = this.TextBoxControlKey.Text;
		shopNum1_Control.ControlImg = this.TextBoxControlImg.Text;
		shopNum1_Control.ModifyUser = base.ShopNum1LoginID;
		shopNum1_Control.ModifyTime = DateTime.Now;
		shopNum1_Control.IsShow = int.Parse(this.DropDownListIsShow.SelectedValue);
		ShopNum1_Control_Action shopNum1_Control_Action = (ShopNum1_Control_Action)LogicFactory.CreateShopNum1_Control_Action();
		int num = shopNum1_Control_Action.Update(shopNum1_Control);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "编辑" + this.TextBoxPageFileName.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "InfoControl_Operate.aspx",
				Date = DateTime.Now
			});
			base.Response.Redirect("InfoControl_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_Control_Action shopNum1_Control_Action = (ShopNum1_Control_Action)LogicFactory.CreateShopNum1_Control_Action();
		DataTable editInfo = shopNum1_Control_Action.GetEditInfo(this.hiddenFieldGuid.Value);
		this.TextBoxPageName.Text = editInfo.Rows[0]["PageName"].ToString();
		this.TextBoxPageFileName.Text = editInfo.Rows[0]["PageFileName"].ToString();
		this.TextBoxControlName.Text = editInfo.Rows[0]["ControlName"].ToString();
		this.TextBoxControlFileName.Text = editInfo.Rows[0]["ControlFileName"].ToString();
		this.TextBoxControlKey.Text = editInfo.Rows[0]["ControlKey"].ToString();
		this.TextBoxControlImg.Text = editInfo.Rows[0]["ControlImg"].ToString();
		this.ImgControlImg.Src = "~/ImgUpload/" + editInfo.Rows[0]["ControlImg"].ToString();
		this.DropDownListIsShow.SelectedValue = editInfo.Rows[0]["IsShow"].ToString();
		this.BottonConfirm.Text = "更新";
		this.BottonConfirm.ToolTip = "Update";
	}
	protected void ClearControl()
	{
		this.TextBoxPageName.Text = string.Empty;
		this.TextBoxPageFileName.Text = string.Empty;
		this.TextBoxControlName.Text = string.Empty;
		this.TextBoxControlFileName.Text = string.Empty;
		this.TextBoxControlKey.Text = string.Empty;
		this.TextBoxControlImg.Text = string.Empty;
	}
	protected void ButtonSeeData_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ControlData_List.aspx?guid=" + this.hiddenFieldGuid.Value);
	}
	protected void BottonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("InfoControl_List.aspx");
	}
}
