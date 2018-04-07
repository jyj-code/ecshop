using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Produce_ServiceAdmin_ServiceEmailGropSend_Operate : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HiddenField hidSelect;
	protected ScriptManager ScriptManager1;
	protected Label LabelTitle;
	protected RadioButtonList RadioButtonListSendObject;
	protected Label LabeSendTObjectEmail;
	protected HtmlSelect selectEmail;
	protected TextBox TextBoxSendObjectEmail;
	protected Label Labelmessage;
	protected DropDownList DropDownListEmailTitle;
	protected Label Label5;
	protected CompareValidator CompareDropDownListEmailTitle;
	protected TextBox txtDefine;
	protected TextBox TextBoxEmailTitle;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected TextBox FCKeditorContent;
	protected Label Label2;
	protected HiddenField hidValue;
	protected Button ButtonConfirm;
	protected Button Button1;
	protected MessageShow MessageShow;
	protected HiddenField HiddenFieldProduceMemLoginID;
	protected HiddenField HiddenFieldXmlPath;
	protected HiddenField HiddenFieldmsgCount;
	protected HiddenField HiddenFieldTop;
	protected HtmlForm form1;
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
	private string string_12 = string.Empty;
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
		this.HiddenFieldXmlPath.Value = base.Server.MapPath("~/Settings/ShopSetting.xml");
		this.GetEmailSetting();
		this.method_5();
		if (!this.Page.IsPostBack)
		{
			this.RadioButtonListSendObject.SelectedIndex = 0;
			this.RadioButtonListSendObject_SelectedIndexChanged(null, null);
			this.BindStatus();
		}
	}
	private void method_5()
	{
	}
	protected void BindStatus()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-请选择-";
		listItem.Value = "-1";
		this.DropDownListEmailTitle.Items.Add(listItem);
		ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
		DataView defaultView = shopNum1_Email_Action.Search(0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Title"].ToString().Trim();
			listItem2.Value = dataRow["Guid"].ToString().Trim();
			this.DropDownListEmailTitle.Items.Add(listItem2);
		}
		ListItem listItem3 = new ListItem();
		listItem3.Text = "自定义模板标题";
		listItem3.Value = "00000000-0000-0000-0000-000000000000";
		this.DropDownListEmailTitle.Items.Add(listItem3);
	}
	protected void GetEmailSetting()
	{
		new ShopSettings();
		DataSet dataSet = new DataSet();
		dataSet.ReadXml(this.HiddenFieldXmlPath.Value);
		this.string_5 = dataSet.Tables[0].Rows[0]["EmailServer"].ToString();
		this.string_6 = dataSet.Tables[0].Rows[0]["SMTP"].ToString();
		this.string_8 = dataSet.Tables[0].Rows[0]["ServerPort"].ToString();
		this.string_7 = dataSet.Tables[0].Rows[0]["EmailAccount"].ToString();
		this.string_9 = dataSet.Tables[0].Rows[0]["EmailPassword"].ToString();
		this.string_10 = dataSet.Tables[0].Rows[0]["RestoreEmail"].ToString();
		this.string_11 = dataSet.Tables[0].Rows[0]["EmailCode"].ToString();
		this.string_12 = dataSet.Tables[0].Rows[0]["EmailCode"].ToString();
	}
	protected void RadioButtonListSendObject_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.RadioButtonListSendObject.SelectedValue == "0")
		{
			this.LabeSendTObjectEmail.Text = "选择会员：";
			this.selectEmail.Items.Clear();
			this.selectEmail.Visible = true;
			this.TextBoxSendObjectEmail.Visible = false;
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataView defaultView = shopNum1_Member_Action.SearchMember(0).DefaultView;
			foreach (DataRow dataRow in defaultView.Table.Rows)
			{
				if (dataRow["Email"].ToString().IndexOf("@") != -1)
				{
					ListItem listItem = new ListItem();
					listItem.Text = dataRow["Email"].ToString().Trim() + ";" + dataRow["MemLoginID"].ToString().Trim();
					listItem.Value = dataRow["Email"].ToString().Trim() + ";" + dataRow["MemLoginID"].ToString().Trim();
					this.selectEmail.Items.Add(listItem);
				}
			}
		}
		if (this.RadioButtonListSendObject.SelectedValue == "1")
		{
			this.LabeSendTObjectEmail.Text = "选择短信组:";
			this.selectEmail.Items.Clear();
			this.selectEmail.Visible = true;
			this.TextBoxSendObjectEmail.Visible = false;
			ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
			DataView defaultView = shopNum1_Email_Action.SearchMemberGroup(0).DefaultView;
			foreach (DataRow dataRow in defaultView.Table.Rows)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataRow["Name"].ToString().Trim();
				listItem.Value = dataRow["Guid"].ToString().Trim();
				this.selectEmail.Items.Add(listItem);
			}
		}
		if (this.RadioButtonListSendObject.SelectedValue == "3")
		{
			this.LabeSendTObjectEmail.Text = "选择会员等级:";
			this.selectEmail.Items.Clear();
			this.selectEmail.Visible = true;
			this.TextBoxSendObjectEmail.Visible = false;
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataView defaultView = shopNum1_Member_Action.SearchMemberRank(0).DefaultView;
			foreach (DataRow dataRow in defaultView.Table.Rows)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataRow["Name"].ToString().Trim();
				listItem.Value = dataRow["minScore"].ToString() + "/" + dataRow["maxScore"].ToString();
				this.selectEmail.Items.Add(listItem);
			}
		}
		if (this.RadioButtonListSendObject.SelectedValue == "5")
		{
			this.selectEmail.Items.Clear();
			this.selectEmail.Visible = false;
			this.TextBoxSendObjectEmail.Visible = true;
			this.LabeSendTObjectEmail.Text = "输入邮件地址：";
			this.Labelmessage.Text = "多个邮件地址以\";\"分割";
		}
	}
	protected void DropDownListEmailTitle_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.FCKeditorContent.Text = string.Empty;
		if (this.DropDownListEmailTitle.SelectedValue != "00000000-0000-0000-0000-000000000000")
		{
			ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
			DataTable dataTable = shopNum1_Email_Action.SearchEmailContent(this.DropDownListEmailTitle.SelectedValue);
			this.FCKeditorContent.Text = dataTable.Rows[0]["Remark"].ToString();
			if (this.DropDownListEmailTitle.SelectedValue == "-1")
			{
				this.FCKeditorContent.Text = string.Empty;
			}
			this.txtDefine.Visible = false;
		}
		else
		{
			this.FCKeditorContent.Text = string.Empty;
			this.txtDefine.Visible = true;
		}
		this.hidSelect.Value = this.DropDownListEmailTitle.SelectedValue;
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		this.ButtonConfirm.Text = "发送中...";
		this.method_6();
		this.ButtonConfirm.Text = "确定";
	}
	private void method_6()
	{
		if (this.FCKeditorContent.Text == string.Empty)
		{
			MessageBox.Show("邮件内容不能为空!");
		}
		else if (this.TextBoxEmailTitle.Text == string.Empty)
		{
			MessageBox.Show("邮件标题不能为空!");
		}
		else if (this.FCKeditorContent.Text.Length > 1000)
		{
			MessageBox.Show("你输入的邮件内容长度已经大于1000，<br/>请删减文字！");
		}
		else
		{
			NetMail netMail = new NetMail();
			netMail.Subject = this.TextBoxEmailTitle.Text.Trim();
			if (this.DropDownListEmailTitle.SelectedItem.Value.Trim() == "00000000-0000-0000-0000-000000000000")
			{
				netMail.Subject = this.txtDefine.Text.Trim().Replace("'", "");
			}
			netMail.Body = this.FCKeditorContent.Text;
			netMail.RecipientEmail = this.string_10;
			new List<string>();
			string[] array = this.hidValue.Value.Split(new char[]
			{
				'|'
			});
			ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
			bool flag = true;
			bool flag2 = true;
			int num = 0;
			int num2 = 0;
			string text = string.Empty;
			string str = string.Empty;
			if (this.RadioButtonListSendObject.SelectedValue == "0")
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].ToString() != "")
					{
						string text2 = array[i];
						string[] array2;
						if (text2.IndexOf(';') != -1)
						{
							array2 = text2.Split(new char[]
							{
								';'
							});
						}
						else
						{
							array2 = (text2 + ";").Split(new char[]
							{
								';'
							});
						}
						netMail.RecipientEmail = array2[0];
						try
						{
							if (!netMail.Send())
							{
								flag2 = false;
								num2++;
								str = str + array2[1] + ",";
								ShopNum1_EmailGroupSend emailGroupSend = this.Add(array2[0], array2[1], 0);
								shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
							}
							else
							{
								flag = false;
								num++;
								text = text + array2[1] + ",";
								ShopNum1_EmailGroupSend emailGroupSend = this.Add(array2[1], array2[0], 2);
								shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
							}
						}
						catch (Exception)
						{
						}
					}
				}
			}
			else if (this.RadioButtonListSendObject.SelectedValue == "1")
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].ToString() != "")
					{
						ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
						DataTable dataTable = shopNum1_Member_Action.SearchMemberAssignGroup(array[i].ToString());
						for (int j = 0; j < dataTable.Rows.Count; j++)
						{
							if (dataTable.Rows[j]["Email"].ToString().IndexOf("@") != -1)
							{
								ListItem listItem = new ListItem();
								listItem.Text = dataTable.Rows[j]["MemLoginID"].ToString();
								listItem.Value = dataTable.Rows[j]["Email"].ToString();
								netMail.RecipientEmail = listItem.Value;
								if (!netMail.Send())
								{
									flag2 = false;
									str += listItem.Text;
									ShopNum1_EmailGroupSend emailGroupSend2 = this.Add(listItem.Text, listItem.Value, 0);
									shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend2);
								}
								else
								{
									flag = false;
									text += listItem.Text;
									ShopNum1_EmailGroupSend emailGroupSend2 = this.Add(listItem.Text, listItem.Value, 2);
									shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend2);
								}
							}
						}
					}
				}
			}
			else if (this.RadioButtonListSendObject.SelectedValue == "3")
			{
				for (int i = 0; i < array.Length; i++)
				{
					ShopNum1_Member_Action shopNum1_Member_Action = new ShopNum1_Member_Action();
					DataTable dataTable = shopNum1_Member_Action.SearchMemberByMemberRank(array[i]);
					for (int j = 0; j < dataTable.Rows.Count; j++)
					{
						if (dataTable.Rows[j]["Email"].ToString().IndexOf("@") != -1)
						{
							ListItem listItem = new ListItem();
							listItem.Text = dataTable.Rows[j]["MemLoginID"].ToString();
							listItem.Value = dataTable.Rows[j]["Email"].ToString();
							netMail.RecipientEmail = listItem.Value;
							if (!netMail.Send())
							{
								flag2 = false;
								this.method_7();
								str += listItem.Text;
								ShopNum1_EmailGroupSend emailGroupSend2 = this.Add(listItem.Text, listItem.Value, 0);
								shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend2);
							}
							else
							{
								flag = false;
								text += listItem.Text;
								ShopNum1_EmailGroupSend emailGroupSend2 = this.Add(listItem.Text, listItem.Value, 2);
								shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend2);
							}
						}
					}
				}
			}
			else if (this.RadioButtonListSendObject.SelectedValue == "5")
			{
				array = this.TextBoxSendObjectEmail.Text.Trim().Split(new char[]
				{
					';'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].ToString().IndexOf("@") != -1)
					{
						netMail.RecipientEmail = array[i];
						if (!netMail.Send())
						{
							flag2 = false;
							this.method_7();
							str += array[i];
							ShopNum1_EmailGroupSend emailGroupSend2 = this.Add(array[i], array[i], 0);
							shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend2);
						}
						else
						{
							flag = false;
							text += array[i];
							ShopNum1_EmailGroupSend emailGroupSend2 = this.Add(array[i], array[i], 2);
							shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend2);
						}
					}
				}
			}
			if (!flag2)
			{
				if (text != null && text != "")
				{
					this.MessageShow.ShowMessage(str + "的邮件发送失败，可能是没有这个邮箱地址, " + text + "的邮件发送成功！");
				}
				else
				{
					this.MessageShow.ShowMessage("邮件接口没有配置好，请在邮件发送接口那里测试邮件是否可以发送！");
				}
				this.MessageShow.Visible = true;
			}
			else if (flag)
			{
				this.MessageShow.ShowMessage("你选择的对象，没有可供发送的邮件地址！");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage(text + "的邮件发送成功！");
				this.MessageShow.Visible = true;
			}
		}
	}
	private void method_7()
	{
	}
	protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state)
	{
		ShopNum1_EmailGroupSend shopNum1_EmailGroupSend = new ShopNum1_EmailGroupSend();
		shopNum1_EmailGroupSend.Guid = Guid.NewGuid();
		string emailTitle = string.Empty;
		emailTitle = this.TextBoxEmailTitle.Text.Trim().Replace("'", "");
		shopNum1_EmailGroupSend.EmailTitle = emailTitle;
		shopNum1_EmailGroupSend.CreateTime = DateTime.Now;
		shopNum1_EmailGroupSend.EmailGuid = new Guid("00000000-0000-0000-0000-000000000000");
		shopNum1_EmailGroupSend.SendObjectEmail = email;
		shopNum1_EmailGroupSend.SendObject = memLoginID + "-" + email;
		shopNum1_EmailGroupSend.State = state;
		return shopNum1_EmailGroupSend;
	}
}
