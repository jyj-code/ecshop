using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_EmailGroupSend_List : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected System.Web.UI.WebControls.DropDownList DropDownListState;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsTime;
	protected System.Web.UI.WebControls.TextBox TextBoxSendObject;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateTime1;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateTime2;
	protected RegularExpressionValidator RegularExpressionValidatorEndDate;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonSend;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldXmlPath;
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
		this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
		this.GetEmailSetting();
		if (!this.Page.IsPostBack)
		{
			this.method_5();
			this.BindGrid();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
		int num = shopNum1_Email_Action.Deleted(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "EmailGroupSend_List.aspx",
				Date = DateTime.Now
			});
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
	protected void ButtonSend_Click(object sender, EventArgs e)
	{
		if (this.string_10 == "")
		{
			MessageBox.Show("请到商城设置中配置邮件发送账号及邮件回复账号！");
		}
		else
		{
			NetMail netMail = new NetMail();
			ShopNum1_Email_Action shopNum1_Email_Action = new ShopNum1_Email_Action();
			DataTable emailGroupSendInfo = shopNum1_Email_Action.GetEmailGroupSendInfo(this.CheckGuid.Value.Replace("'", ""));
			if (emailGroupSendInfo != null && emailGroupSendInfo.Rows.Count > 0)
			{
				netMail.Subject = emailGroupSendInfo.Rows[0]["EmailTitle"].ToString();
				netMail.Body = emailGroupSendInfo.Rows[0]["SendObjectEmail"].ToString();
				string recipientEmail = emailGroupSendInfo.Rows[0]["SendObject"].ToString().Split(new char[]
				{
					'-'
				})[1];
				netMail.RecipientEmail = recipientEmail;
				if (!netMail.Send())
				{
					this.MessageShow.ShowMessage("SendNoteNo");
					this.MessageShow.Visible = true;
				}
				else
				{
					int num = shopNum1_Email_Action.Update(new ShopNum1_EmailGroupSend
					{
						State = 2,
						Guid = new Guid(this.CheckGuid.Value.ToString().Replace("'", ""))
					});
					if (num > 0)
					{
						this.BindGrid();
						this.MessageShow.ShowMessage("SendNoteYes");
						this.MessageShow.Visible = true;
					}
					else
					{
						this.MessageShow.ShowMessage("SendNoteNo");
						this.MessageShow.Visible = true;
					}
				}
			}
			else
			{
				this.MessageShow.ShowMessage("SendNoteNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	private void method_5()
	{
		try
		{
			ListItem listItem = new ListItem();
			listItem.Text = LocalizationUtil.GetCommonMessage("All");
			listItem.Value = "-1";
			this.DropDownListIsTime.Items.Add(listItem);
			ListItem listItem2 = new ListItem();
			listItem2.Text = LocalizationUtil.GetCommonMessage("All");
			listItem2.Value = "-1";
			this.DropDownListState.Items.Add(listItem2);
			ListItem listItem3 = new ListItem();
			listItem3.Text = LocalizationUtil.GetCommonMessage("State0");
			listItem3.Value = "0";
			this.DropDownListState.Items.Add(listItem3);
			ListItem listItem4 = new ListItem();
			listItem4.Text = LocalizationUtil.GetCommonMessage("State1");
			listItem4.Value = "1";
			this.DropDownListState.Items.Add(listItem4);
			ListItem listItem5 = new ListItem();
			listItem5.Text = LocalizationUtil.GetCommonMessage("State2");
			listItem5.Value = "2";
			this.DropDownListState.Items.Add(listItem5);
			ListItem listItem6 = new ListItem();
			listItem6.Text = LocalizationUtil.GetCommonMessage("IsTime0");
			listItem6.Value = "0";
			this.DropDownListIsTime.Items.Add(listItem6);
			ListItem listItem7 = new ListItem();
			listItem7.Text = LocalizationUtil.GetCommonMessage("IsTime1");
			listItem7.Value = "1";
			this.DropDownListIsTime.Items.Add(listItem7);
		}
		catch
		{
			throw;
		}
	}
	protected void GetEmailSetting()
	{
		ShopSettings shopSettings = new ShopSettings();
		this.string_5 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.HiddenFieldXmlPath.Value, "EmailServer"));
		this.string_6 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.HiddenFieldXmlPath.Value, "SMTP"));
		this.string_8 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.HiddenFieldXmlPath.Value, "ServerPort"));
		this.string_7 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.HiddenFieldXmlPath.Value, "EmailAccount"));
		this.string_9 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.HiddenFieldXmlPath.Value, "EmailPassword"));
		this.string_10 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.HiddenFieldXmlPath.Value, "RestoreEmail"));
		this.string_11 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.HiddenFieldXmlPath.Value, "EmailCode"));
	}
	public string ChangeState(string strState)
	{
		string result;
		if (strState == "0")
		{
			result = LocalizationUtil.GetChangeMessage("EmailGroupSend", "State", "0");
		}
		else if (strState == "1")
		{
			result = LocalizationUtil.GetChangeMessage("EmailGroupSend", "State", "1");
		}
		else if (strState == "2")
		{
			result = LocalizationUtil.GetChangeMessage("EmailGroupSend", "State", "2");
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeisTime(string isTime)
	{
		string result;
		if (isTime == "0")
		{
			result = "不定时";
		}
		else if (isTime == "1")
		{
			result = "定时";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
		int num = shopNum1_Email_Action.Deleted("'" + commandArgument + "'");
		if (num > 0)
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
}
