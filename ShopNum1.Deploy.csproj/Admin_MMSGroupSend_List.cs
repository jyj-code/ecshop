using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_MMSGroupSend_List : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
	protected HtmlLink sizestylesheet;
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
	protected CalendarExtender CalendarExtender3;
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
		ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
		int num = shopNum1_MMS_Action.Deleted(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "MMSGroupSend_List.aspx",
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
		try
		{
			ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
			DataTable mMSGroupSendInfo = shopNum1_MMS_Action.GetMMSGroupSendInfo(this.CheckGuid.Value.Replace("'", ""));
			string text = string.Empty;
			string content = string.Empty;
			try
			{
				content = mMSGroupSendInfo.Rows[0]["SendObjectMMS"].ToString();
				text = mMSGroupSendInfo.Rows[0]["SendObject"].ToString();
				if (text.IndexOf("-") != -1)
				{
					text = text.Split(new char[]
					{
						'-'
					})[1];
				}
			}
			catch (Exception)
			{
			}
			SMS sMS = new SMS();
			string text2 = "";
			if (text == "")
			{
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
			}
			sMS.Send(text.Trim(), content, out text2);
			if (text2.IndexOf("发送成功") != -1)
			{
				int num = shopNum1_MMS_Action.Update(new ShopNum1_MMSGroupSend
				{
					State = 2,
					Guid = new Guid(this.CheckGuid.Value.ToString().Replace("'", ""))
				});
				if (num > 0)
				{
					this.MessageShow.ShowMessage("重新发送成功！");
					this.MessageShow.Visible = true;
				}
				else
				{
					this.MessageShow.ShowMessage("重新发送失败！");
					this.MessageShow.Visible = true;
				}
			}
			else
			{
				this.MessageShow.ShowMessage(text2);
				this.MessageShow.Visible = true;
			}
		}
		catch (Exception ex)
		{
			this.MessageShow.ShowMessage(ex.Message);
			this.MessageShow.Visible = true;
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
			result = LocalizationUtil.GetChangeMessage("EmailGroupSend", "Istime", "0");
		}
		else if (isTime == "1")
		{
			result = LocalizationUtil.GetChangeMessage("EmailGroupSend", "Istime", "1");
		}
		else
		{
			result = "";
		}
		return result;
	}
}
