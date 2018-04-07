using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class addGroup : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelAddName;
	protected TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorLoginID;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Label LabelAddShortName;
	protected TextBox TextBoxShortName;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidatorLoginID0;
	protected RegularExpressionValidator RegularExpressionValidatorShortName;
	protected Label LabelControlPage;
	protected ListBox ListBoxPageLeft;
	protected Label LabelPageName;
	protected Label LabelPageGuid;
	protected CheckBoxList CheckBoxListControl;
	protected Label Label1;
	protected HtmlTextArea TextBoxRemarks;
	protected Label LabelGroupUser;
	protected ListBox ListBoxLeftUser;
	protected Button ButtonAddAllUser;
	protected ListBox ListBoxUserRight;
	protected Button ButtonConfirm;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected HiddenField hiddenGuid;
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
		if (!this.Page.IsPostBack)
		{
			this.ButtonConfirm.ToolTip = "Update";
			if (base.Request.QueryString["id"] != null)
			{
				this.ButtonConfirm.ToolTip = "Update";
				this.ButtonConfirm.Text = "更新";
				string strGuid = base.Request.QueryString["id"].ToString();
				DataTable group = this.GetGroup(strGuid);
				if (group.Rows.Count > 0)
				{
					this.hiddenGuid.Value = group.Rows[0]["Guid"].ToString();
					this.TextBoxName.Text = group.Rows[0]["Name"].ToString();
					this.TextBoxShortName.Text = group.Rows[0]["ShortName"].ToString();
					this.TextBoxRemarks.Value = group.Rows[0]["Remarks"].ToString();
					this.TextBoxName.Enabled = false;
				}
			}
			else
			{
				this.ButtonConfirm.ToolTip = "Submit";
			}
		}
	}
	protected DataTable GetGroup(string strGuid)
	{
		ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
		return shopNum1_Group_Action.GetGroupByGuid(strGuid, 0);
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Submit")
		{
			ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
			int num = shopNum1_Group_Action.CheckShotName(this.TextBoxShortName.Text.Trim());
			if (num > 0)
			{
				MessageBox.Show("用户组标志不能重复！");
			}
			else
			{
				ShopNum1_Group shopNum1_Group = new ShopNum1_Group();
				shopNum1_Group.Guid = Guid.NewGuid();
				shopNum1_Group.Name = this.TextBoxName.Text.Trim();
				shopNum1_Group.ShortName = this.TextBoxShortName.Text.Trim();
				shopNum1_Group.CreateUser = "admin";
				shopNum1_Group.CreateTime = DateTime.Now;
				shopNum1_Group.ModifyUser = "admin";
				shopNum1_Group.ModifyTime = DateTime.Now;
				shopNum1_Group.IsDeleted = 0;
				shopNum1_Group.SubstationID = "all";
				shopNum1_Group.Remarks = this.TextBoxRemarks.Value.Trim();
				List<string> userList = new List<string>();
				ShopNum1_Group_Action shopNum1_Group_Action2 = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
				List<ShopNum1_GroupPageWebControl> groupPageWebControlList = new List<ShopNum1_GroupPageWebControl>();
				int num2 = shopNum1_Group_Action2.Add(shopNum1_Group);
				if (num2 > 0)
				{
					this.BindGrid();
					this.ClearControl();
					this.MessageShow.ShowMessage("AddYes");
					this.MessageShow.Visible = true;
					this.Page.RegisterStartupScript("script", "<script>alert('添加成功！');window.parent.location.reload();</script>");
				}
				else
				{
					this.MessageShow.ShowMessage("AddNo");
					this.MessageShow.Visible = true;
				}
			}
		}
		else if (this.ButtonConfirm.ToolTip == "Update")
		{
			ShopNum1_Group_Action shopNum1_Group_Action2 = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
			ShopNum1_Group shopNum1_Group = new ShopNum1_Group();
			shopNum1_Group.Guid = new Guid(this.hiddenGuid.Value);
			shopNum1_Group.Name = this.TextBoxName.Text.Trim();
			shopNum1_Group.ShortName = this.TextBoxShortName.Text.Trim();
			shopNum1_Group.ModifyUser = "admin";
			shopNum1_Group.ModifyTime = DateTime.Now;
			shopNum1_Group.CreateTime = DateTime.Now;
			shopNum1_Group.IsDeleted = 0;
			shopNum1_Group.Remarks = this.TextBoxRemarks.Value.Trim();
			List<string> pageList = new List<string>();
			List<string> userList = new List<string>();
			List<ShopNum1_GroupPageWebControl> groupPageWebControlList = new List<ShopNum1_GroupPageWebControl>();
			int num2 = shopNum1_Group_Action2.Update(shopNum1_Group, pageList, userList, groupPageWebControlList);
			if (num2 > 0)
			{
				this.Page.RegisterStartupScript("script", "<script>window.parent.location.reload();</script>");
				this.BindGrid();
				this.ClearControl();
			}
			else
			{
				this.MessageShow.ShowMessage("EditNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected new int OperateLog(ShopNum1_OperateLog operateLog)
	{
		ShopNum1_OperateLog_Action shopNum1_OperateLog_Action = (ShopNum1_OperateLog_Action)LogicFactory.CreateShopNum1_OperateLog_Action();
		return shopNum1_OperateLog_Action.Add(operateLog);
	}
	protected void BindGrid()
	{
	}
	protected void ClearControl()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxShortName.Text = string.Empty;
		this.TextBoxRemarks.Value = string.Empty;
	}
}
