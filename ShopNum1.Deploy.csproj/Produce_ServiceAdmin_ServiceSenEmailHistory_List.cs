using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Produce_ServiceAdmin_ServiceSenEmailHistory_List : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelTitle;
	protected Localize LocalizeTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTitle;
	protected Localize LocalizeState;
	protected System.Web.UI.WebControls.DropDownList DropDownListState;
	protected Localize LocalizeSendObject;
	protected System.Web.UI.WebControls.TextBox TextBoxSendObject;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxSendObject;
	protected Localize LocalizeReplyTime;
	protected System.Web.UI.WebControls.TextBox TextBoxTime1;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxTime2;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime2;
	protected Localize LocalizeIsTime;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsTime;
	protected System.Web.UI.WebControls.Button Button1;
	protected Num1GridView Num1GridView;
	protected System.Web.UI.WebControls.Button ButtonSend;
	protected System.Web.UI.WebControls.Button ButtonDelete;
	protected MessageShow MessageShow;
	protected ObjectDataSource ObjectDataSourceDate;
	protected HiddenField HiddenFieldXmlPath;
	protected HiddenField HiddenFieldproduceMemLoginID;
	protected HiddenField CheckGuid;
	protected HtmlForm form1;
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
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
		this.HiddenFieldXmlPath.Value = base.Server.MapPath("~/Main/Settings/Site_Settings.xml");
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
		try
		{
			if (this.string_10 == "")
			{
				MessageBox.Show("请到设置配置邮件发送账号及邮件回复账号！");
			}
			else
			{
				NetMail netMail = new NetMail();
				ShopNum1_Email_Action shopNum1_Email_Action = new ShopNum1_Email_Action();
				DataTable emailGroupSendInfo = shopNum1_Email_Action.GetEmailGroupSendInfo(this.CheckGuid.Value.Replace("'", ""));
				netMail.RecipientEmail = emailGroupSendInfo.Rows[0]["SendObjectEmail"].ToString();
				netMail.Subject = emailGroupSendInfo.Rows[0]["EmailTitle"].ToString();
				netMail.Body = emailGroupSendInfo.Rows[0]["Remark"].ToString();
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
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
	protected void BindGrid()
	{
		this.Num1GridView.DataBind();
	}
	private void method_5()
	{
		try
		{
			ListItem listItem = new ListItem();
			listItem.Text = "-全部-";
			listItem.Value = "-1";
			this.DropDownListIsTime.Items.Add(listItem);
			ListItem listItem2 = new ListItem();
			listItem2.Text = "-全部-";
			listItem2.Value = "-1";
			this.DropDownListState.Items.Add(listItem2);
			ListItem listItem3 = new ListItem();
			listItem3.Text = "发送失败";
			listItem3.Value = "0";
			this.DropDownListState.Items.Add(listItem3);
			ListItem listItem4 = new ListItem();
			listItem4.Text = "未失败";
			listItem4.Value = "1";
			this.DropDownListState.Items.Add(listItem4);
			ListItem listItem5 = new ListItem();
			listItem5.Text = "发送成功";
			listItem5.Value = "2";
			this.DropDownListState.Items.Add(listItem5);
			ListItem listItem6 = new ListItem();
			listItem6.Text = "是";
			listItem6.Value = "0";
			this.DropDownListIsTime.Items.Add(listItem6);
			ListItem listItem7 = new ListItem();
			listItem7.Text = "否";
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
		DataSet dataSet = new DataSet();
		dataSet.ReadXml(this.HiddenFieldXmlPath.Value);
		this.string_5 = dataSet.Tables[0].Rows[0]["EmailServer"].ToString();
		this.string_6 = dataSet.Tables[0].Rows[0]["SMTP"].ToString();
		this.string_8 = dataSet.Tables[0].Rows[0]["ServerPort"].ToString();
		this.string_7 = dataSet.Tables[0].Rows[0]["EmailAccount"].ToString();
		this.string_9 = dataSet.Tables[0].Rows[0]["EmailPassword"].ToString();
		this.string_10 = dataSet.Tables[0].Rows[0]["RestoreEmail"].ToString();
		this.string_11 = dataSet.Tables[0].Rows[0]["EmailCode"].ToString();
	}
	public string ChangeState(string strState)
	{
		string result;
		if (strState == "0")
		{
			result = "发送失败";
		}
		else if (strState == "1")
		{
			result = "未发送";
		}
		else if (strState == "2")
		{
			result = "发送成功";
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
			result = "error";
		}
		return result;
	}
	protected void ButtonDelete_Click1(object sender, EventArgs e)
	{
		ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
		int num = shopNum1_Email_Action.Deleted(this.CheckGuid.Value.ToString());
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
