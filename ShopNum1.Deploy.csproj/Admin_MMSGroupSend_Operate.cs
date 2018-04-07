using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_MMSGroupSend_Operate : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
	private string string_12 = string.Empty;
	private string string_13 = "";
	private bool bool_1 = false;
	private ShopNum1_MMS_Action shopNum1_MMS_Action_0 = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
	protected HtmlLink sizestylesheet;
	protected HiddenField hidSelect;
	protected ScriptManager ScriptManager1;
	protected Label Label1;
	protected Label SendObject;
	protected RadioButtonList RadioButtonListSendObject;
	protected Label LabeSendTObjectMMS;
	protected HtmlSelect selectMMS;
	protected TextBox TextBoxSendObjectMMS;
	protected Label Labelmessage;
	protected DropDownList dropTemplte;
	protected DropDownList DropDownListMMSCaregory;
	protected DropDownList DropDownListMMSTitle;
	protected CompareValidator CompareValidatorMMSTitle;
	protected TextBox FCKeditorContent;
	protected Button ButtonConfirm;
	protected Button Button1;
	protected MessageShow MessageShow;
	protected HiddenField hidValue;
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
		if (!this.Page.IsPostBack)
		{
			this.RadioButtonListSendObject.SelectedIndex = 0;
			this.BindDropDownListMMSCaregory();
		}
	}
	protected ShopNum1_MMSGroupSend Add(string memLoginID, string mobile, int state, string noteContent)
	{
		return new ShopNum1_MMSGroupSend
		{
			Guid = Guid.NewGuid(),
			MMSTitle = this.dropTemplte.SelectedItem.Text,
			CreateTime = DateTime.Now,
			MMSGuid = new Guid(this.dropTemplte.SelectedValue.ToString()),
			SendObjectMMS = noteContent,
			SendObject = memLoginID + "-" + mobile,
			State = state
		};
	}
	protected void BindDropDownListMMSCaregory()
	{
		ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
		DataView defaultView = shopNum1_MMS_Action.Search(0).DefaultView;
		ListItem listItem = new ListItem();
		listItem.Text = "短信群发";
		listItem.Value = "00000000-0000-0000-0000-000000000000";
		this.dropTemplte.Items.Add(listItem);
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Title"].ToString().Trim();
			listItem2.Value = dataRow["Guid"].ToString().Trim();
			this.dropTemplte.Items.Add(listItem2);
		}
		this.LabeSendTObjectMMS.Text = "选择会员:";
		this.selectMMS.Items.Clear();
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		DataView defaultView2 = shopNum1_Member_Action.SearchMember(0).DefaultView;
		foreach (DataRow dataRow in defaultView2.Table.Rows)
		{
			if (dataRow["Mobile"].ToString().Length == 11)
			{
				this.selectMMS.Visible = true;
				this.TextBoxSendObjectMMS.Visible = false;
				ListItem listItem2 = new ListItem();
				listItem2.Text = dataRow["MemLoginID"].ToString().Trim() + "-" + dataRow["Mobile"].ToString().Trim();
				listItem2.Value = dataRow["MemLoginID"].ToString().Trim() + "-" + dataRow["Mobile"].ToString().Trim();
				this.selectMMS.Items.Add(listItem2);
			}
		}
	}
	protected void BindStatus()
	{
		this.DropDownListMMSTitle.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("Select");
		listItem.Value = "-1";
		this.DropDownListMMSTitle.Items.Add(listItem);
		ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
		DataView defaultView = shopNum1_MMS_Action.Search(string.Empty, this.DropDownListMMSCaregory.SelectedValue.ToString(), 0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Title"].ToString().Trim();
			listItem2.Value = dataRow["Guid"].ToString().Trim();
			this.DropDownListMMSTitle.Items.Add(listItem2);
		}
	}
	protected void ClearControl()
	{
		this.FCKeditorContent.Text = string.Empty;
	}
	protected void dropTemplte_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			this.FCKeditorContent.Text = string.Empty;
			ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
			DataTable dataTable = shopNum1_MMS_Action.SearchMMSContent(this.dropTemplte.SelectedValue);
			this.FCKeditorContent.Text = dataTable.Rows[0]["Remark"].ToString();
			if (this.dropTemplte.SelectedValue == "-1")
			{
				this.FCKeditorContent.Text = string.Empty;
			}
			this.hidSelect.Value = this.dropTemplte.SelectedValue;
		}
		catch (Exception ex)
		{
			base.Response.Write(ex.Message);
		}
	}
	protected void DropDownListMMSTitle_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.FCKeditorContent.Text = string.Empty;
		ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
		DataTable dataTable = shopNum1_MMS_Action.SearchMMSContent(this.DropDownListMMSTitle.SelectedValue);
		this.FCKeditorContent.Text = dataTable.Rows[0]["Remark"].ToString();
		if (this.DropDownListMMSTitle.SelectedValue == "-1")
		{
			this.FCKeditorContent.Text = string.Empty;
		}
	}
	private bool method_5(string string_14)
	{
		bool result;
		for (int i = 0; i < string_14.Length; i++)
		{
			if (string_14[i] < '0' || string_14[i] > '9')
			{
				result = false;
				return result;
			}
		}
		result = true;
		return result;
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.FCKeditorContent.Text == string.Empty)
		{
			MessageBox.Show("短信内容不能为空!");
		}
		else if (this.FCKeditorContent.Text.Length > 100)
		{
			MessageBox.Show("短信内容不能大于100个字符！");
		}
		else
		{
			SMS sMS = new SMS();
			string[] array = this.hidValue.Value.Split(new char[]
			{
				'|'
			});
			if (array.Length > 0 && this.RadioButtonListSendObject.SelectedValue == "0")
			{
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(new char[]
					{
						'-'
					});
					if (array2.Length <= 0 || !(array2[0] != string.Empty))
					{
						MessageBox.Show("请选中会员!");
						return;
					}
					if (array[i].Split(new char[]
					{
						'-'
					})[1].ToString() != "")
					{
						this.bool_1 = true;
						sMS.Send(array[i].Split(new char[]
						{
							'-'
						})[1], Operator.FilterString(this.FCKeditorContent.Text), out this.string_13);
						this.method_6(array[i].Split(new char[]
						{
							'-'
						})[0], array[i].Split(new char[]
						{
							'-'
						})[1], Operator.FilterString(this.FCKeditorContent.Text), this.string_13);
					}
				}
			}
			if (this.RadioButtonListSendObject.SelectedValue == "1")
			{
				for (int i = 0; i < array.Length; i++)
				{
					DataTable dataTable = this.shopNum1_MMS_Action_0.SearchMemberAssignGroup(array[i]);
					for (int j = 0; j < dataTable.Rows.Count; j++)
					{
						if (dataTable.Rows[j]["Mobile"].ToString().Length == 11)
						{
							this.bool_1 = true;
							string string_ = dataTable.Rows[j]["MemLoginID"].ToString();
							string text = dataTable.Rows[j]["Mobile"].ToString() ?? string.Empty;
							if (text != string.Empty)
							{
								sMS.Send(text, Operator.FilterString(this.FCKeditorContent.Text), out this.string_13);
							}
							this.method_6(string_, text, Operator.FilterString(this.FCKeditorContent.Text), this.string_13);
						}
					}
				}
			}
			if (this.RadioButtonListSendObject.SelectedValue == "3")
			{
				for (int i = 0; i < array.Length; i++)
				{
					ShopNum1_Member_Action shopNum1_Member_Action = new ShopNum1_Member_Action();
					DataTable dataTable = shopNum1_Member_Action.SearchMemberByMemberRank(array[i]);
					if (dataTable != null)
					{
						for (int j = 0; j < dataTable.Rows.Count; j++)
						{
							if (dataTable.Rows[j]["Mobile"].ToString().Length == 11)
							{
								this.bool_1 = true;
								ListItem listItem = new ListItem();
								listItem.Text = dataTable.Rows[j]["MemLoginID"].ToString();
								listItem.Value = dataTable.Rows[j]["Mobile"].ToString();
								sMS.Send(listItem.Value, Operator.FilterString(this.FCKeditorContent.Text), out this.string_13);
								this.method_6(listItem.Value = dataTable.Rows[j]["Mobile"].ToString(), listItem.Value = dataTable.Rows[j]["Mobile"].ToString(), Operator.FilterString(this.FCKeditorContent.Text), this.string_13);
							}
						}
					}
				}
			}
			if (this.RadioButtonListSendObject.SelectedValue == "5")
			{
				string text2 = this.TextBoxSendObjectMMS.Text.Replace("\r\n", "");
				if (text2 == "")
				{
					MessageBox.Show("请输入手机号码");
					return;
				}
				string[] array3 = text2.Split(new char[]
				{
					';'
				});
				for (int i = 0; i < array3.Length; i++)
				{
					if (!(array3[i] == ""))
					{
						if (!this.method_5(array3[i]))
						{
							MessageBox.Show("输入不正确");
							return;
						}
						this.bool_1 = true;
						sMS.Send(array3[i], Operator.FilterString(this.FCKeditorContent.Text), out this.string_13);
						this.method_6(array3[i], array3[i], Operator.FilterString(this.FCKeditorContent.Text), this.string_13);
					}
				}
			}
			if (this.bool_1)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "群发短信",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "MMSGroupSend_List.aspx",
					Date = DateTime.Now
				});
				this.MessageShow.ShowMessage("短信发送成功！");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("短信发送失败！");
				this.MessageShow.Visible = true;
			}
		}
	}
	private void method_6(string string_14, string string_15, string string_16, string string_17)
	{
		try
		{
			if (this.string_13.IndexOf("发送成功") != -1)
			{
				ShopNum1_MMSGroupSend mMSGroupSend = this.Add(string_14, string_15, 2, string_16);
				this.shopNum1_MMS_Action_0.AddMMSGroupSend(mMSGroupSend);
				this.MessageShow.ShowMessage("SendNoteYes");
				this.MessageShow.Visible = true;
			}
			else
			{
				ShopNum1_MMSGroupSend mMSGroupSend = this.Add(string_14, string_15, 0, string_16);
				this.shopNum1_MMS_Action_0.AddMMSGroupSend(mMSGroupSend);
				this.MessageShow.ShowMessage("SendNoteNo");
				this.MessageShow.Visible = true;
			}
		}
		catch
		{
			this.MessageShow.ShowMessage("SendNoteNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void RadioButtonListSendObject_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.RadioButtonListSendObject.SelectedValue == "0")
		{
			this.LabeSendTObjectMMS.Text = "选择会员:";
			this.selectMMS.Items.Clear();
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataView defaultView = shopNum1_Member_Action.SearchMember(0).DefaultView;
			foreach (DataRow dataRow in defaultView.Table.Rows)
			{
				if (dataRow["Mobile"].ToString() != "")
				{
					this.selectMMS.Visible = true;
					this.TextBoxSendObjectMMS.Visible = false;
					ListItem listItem = new ListItem();
					listItem.Text = dataRow["MemLoginID"].ToString().Trim() + "-" + dataRow["Mobile"].ToString().Trim();
					listItem.Value = dataRow["Mobile"].ToString().Trim();
					this.selectMMS.Items.Add(listItem);
				}
			}
		}
		if (this.RadioButtonListSendObject.SelectedValue == "1")
		{
			this.LabeSendTObjectMMS.Text = "选择短信组:";
			this.selectMMS.Items.Clear();
			ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
			DataView defaultView = shopNum1_MMS_Action.SearchMemberGroup(0).DefaultView;
			foreach (DataRow dataRow in defaultView.Table.Rows)
			{
				this.selectMMS.Visible = true;
				this.TextBoxSendObjectMMS.Visible = false;
				ListItem listItem = new ListItem();
				listItem.Text = dataRow["Name"].ToString().Trim();
				listItem.Value = dataRow["Guid"].ToString().Trim();
				this.selectMMS.Items.Add(listItem);
			}
		}
		if (this.RadioButtonListSendObject.SelectedValue == "3")
		{
			this.LabeSendTObjectMMS.Text = "选择会员等级:";
			this.selectMMS.Items.Clear();
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataView defaultView = shopNum1_Member_Action.SearchMemberRank(0).DefaultView;
			foreach (DataRow dataRow in defaultView.Table.Rows)
			{
				this.selectMMS.Visible = true;
				this.TextBoxSendObjectMMS.Visible = false;
				ListItem listItem = new ListItem();
				listItem.Text = dataRow["Name"].ToString().Trim();
				listItem.Value = dataRow["minScore"].ToString() + "/" + dataRow["maxScore"].ToString();
				this.selectMMS.Items.Add(listItem);
			}
		}
		if (this.RadioButtonListSendObject.SelectedValue == "5")
		{
			this.selectMMS.Items.Clear();
			this.selectMMS.Visible = false;
			this.TextBoxSendObjectMMS.Visible = true;
			this.LabeSendTObjectMMS.Text = "输入手机号：";
			this.Labelmessage.Text = "多个手机号以\";\"分割";
		}
	}
	protected void DropDownListMMSCaregory_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListMMSCaregory.SelectedValue.ToString() != "-1")
		{
			this.BindStatus();
		}
		else
		{
			this.DropDownListMMSTitle.Items.Clear();
			ListItem listItem = new ListItem();
			listItem.Text = LocalizationUtil.GetCommonMessage("Select");
			listItem.Value = "-1";
			this.DropDownListMMSTitle.Items.Add(listItem);
		}
	}
}
