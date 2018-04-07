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
public class Main_Admin_adduser : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected Label LabelName;
	protected TextBox TextBoxLoginID;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorLoginID;
	protected RegularExpressionValidator RegularExpressionValidatorLoginID;
	protected Label LabelPassword1;
	protected TextBox TextBoxPassword1;
	protected Label LabelPassword2;
	protected TextBox TextBoxPassword2;
	protected Label LabelRealName;
	protected TextBox TextBoxRealName;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidatorRealName;
	protected RegularExpressionValidator RegularExpressionValidatorRealName;
	protected Label LabelSex;
	protected DropDownList DropDownListSex;
	protected RadioButtonList RadioButtonList1;
	protected Label LabelDept;
	protected DropDownList DropDownListDept;
	protected Label Label5;
	protected Label LabelGroup;
	protected DropDownList DropDownListGroup;
	protected Label Label10;
	protected CompareValidator CompareValidator1;
	protected Panel pane1;
	protected Label LabelAge;
	protected TextBox TextBoxAge;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxAge;
	protected Label LabelWorkNumber;
	protected TextBox TextBoxWorkNumber;
	protected Label LabelEmail;
	protected TextBox TextBoxEmail;
	protected RegularExpressionValidator RegularExpressionValidatorEmail;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Label LabelTelephone;
	protected TextBox TextBoxTelephone;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTelephone;
	protected Label LabelIsForbid;
	protected DropDownList DropDownListIsForbid;
	protected Button ButtonConfirm;
	protected HtmlInputReset inputReset;
	protected MessageShow MessageShow;
	protected HiddenField hiddenGuid;
	protected HtmlForm form1;
	private int int_0;
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
			this.method_5();
			if (base.Request.QueryString["id"] != null)
			{
				this.ButtonConfirm.Text = "更新";
				this.TextBoxLoginID.Enabled = false;
				string comId = base.Request.QueryString["id"].ToString();
				DataTable user = this.GetUser(comId);
				this.hiddenGuid.Value = user.Rows[0]["Guid"].ToString();
				this.TextBoxLoginID.Text = user.Rows[0]["LoginID"].ToString();
				this.TextBoxRealName.Text = user.Rows[0]["RealName"].ToString();
				this.DropDownListSex.SelectedValue = user.Rows[0]["Sex"].ToString();
				if (user.Rows[0]["DeptGuid"].ToString() == "00000000-0000-0000-0000-000000000000")
				{
					this.DropDownListDept.SelectedValue = "-1";
				}
				else
				{
					this.DropDownListDept.SelectedValue = user.Rows[0]["DeptGuid"].ToString();
				}
				this.RadioButtonList1.SelectedValue = user.Rows[0]["PeopleType"].ToString();
				this.TextBoxAge.Text = user.Rows[0]["Age"].ToString();
				this.TextBoxWorkNumber.Text = user.Rows[0]["WorkNumber"].ToString();
				this.TextBoxEmail.Text = user.Rows[0]["Email"].ToString();
				this.TextBoxTelephone.Text = user.Rows[0]["Telephone"].ToString();
				this.DropDownListIsForbid.SelectedValue = user.Rows[0]["IsForbid"].ToString();
				if (user.Rows.Count >= 1 && user.Rows[0]["GroupGuid"].ToString() != "")
				{
					for (int i = 0; i < this.DropDownListGroup.Items.Count; i++)
					{
						for (int j = 0; j < user.Rows.Count; j++)
						{
							if (this.DropDownListGroup.Items[i].Value == user.Rows[j]["GroupGuid"].ToString())
							{
								this.DropDownListGroup.Items[i].Selected = true;
							}
						}
					}
				}
				this.ButtonConfirm.ToolTip = "Update";
			}
			else
			{
				this.ButtonConfirm.ToolTip = "Submit";
			}
		}
	}
	private void method_5()
	{
		try
		{
			ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
			DataView defaultView;
			if (this.Page.Request.QueryString["sub"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["sub"].ToString()))
			{
				defaultView = Common.GetTableById("Guid, Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted,Remarks", "ShopNum1_Group", " and SubstationID='" + this.Page.Request.QueryString["sub"].ToString() + "' Order by CreateTime Desc ").DefaultView;
			}
			else
			{
				defaultView = shopNum1_Group_Action.Search(0, base.SubstationID).DefaultView;
			}
			foreach (DataRow dataRow in defaultView.Table.Rows)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataRow["Name"].ToString().Trim();
				listItem.Value = dataRow["GUID"].ToString().Trim();
				this.DropDownListGroup.Items.Add(listItem);
			}
		}
		catch (Exception ex)
		{
			this.Page.Response.Write(string.Concat(new string[]
			{
				ex.Message,
				"|",
				ex.StackTrace,
				"|",
				this.Page.Request.QueryString["sub"]
			}));
		}
	}
	protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.int_0 = Convert.ToInt32(this.RadioButtonList1.SelectedValue);
		if (this.int_0 == 1)
		{
			this.pane1.Visible = true;
		}
		else
		{
			this.pane1.Visible = false;
		}
	}
	protected DataTable GetUser(string comId)
	{
		ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
		return shopNum1_User_Action.GetUserByGuid(comId, 0);
	}
	protected void ClearControl()
	{
		this.TextBoxLoginID.Text = string.Empty;
		this.TextBoxPassword1.Text = string.Empty;
		this.TextBoxPassword2.Text = string.Empty;
		this.TextBoxRealName.Text = string.Empty;
		this.TextBoxTelephone.Text = string.Empty;
		this.TextBoxWorkNumber.Text = string.Empty;
		this.TextBoxEmail.Text = string.Empty;
		this.TextBoxAge.Text = "0";
		this.DropDownListSex.SelectedValue = "1";
		this.DropDownListDept.SelectedValue = "-1";
		this.DropDownListIsForbid.SelectedValue = "0";
		this.DropDownListGroup.SelectedIndex = -1;
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Submit")
		{
			ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
			DataTable userByLoginID = shopNum1_User_Action.GetUserByLoginID(this.TextBoxLoginID.Text.Trim(), 0);
			if (userByLoginID != null && userByLoginID.Rows.Count > 0)
			{
				MessageBox.Show("用户名已存在，请更换！");
			}
			else if (string.IsNullOrEmpty(this.TextBoxPassword1.Text))
			{
				MessageBox.Show("密码不能为空！");
			}
			else
			{
				ShopNum1_User shopNum1_User = new ShopNum1_User();
				shopNum1_User.Guid = Guid.NewGuid();
				this.TextBoxLoginID.Enabled = true;
				shopNum1_User.LoginId = this.TextBoxLoginID.Text.Trim();
				shopNum1_User.Pwd = Encryption.GetSHA1SecondHash(this.TextBoxPassword1.Text.Trim());
				shopNum1_User.RealName = this.TextBoxRealName.Text.Trim();
				shopNum1_User.Sex = Convert.ToInt32(this.DropDownListSex.SelectedValue);
				if (this.TextBoxAge.Text.Trim() == string.Empty || this.TextBoxAge.Text.Trim() == null)
				{
					shopNum1_User.Age = 0;
				}
				else
				{
					shopNum1_User.Age = Convert.ToInt32(this.TextBoxAge.Text.Trim());
				}
				shopNum1_User.WorkNumber = this.TextBoxWorkNumber.Text.Trim();
				shopNum1_User.Email = this.TextBoxEmail.Text.Trim();
				shopNum1_User.Telephone = this.TextBoxTelephone.Text.Trim();
				shopNum1_User.IsForbid = Convert.ToInt32(this.DropDownListIsForbid.SelectedValue);
				shopNum1_User.LoginTimes = 0;
				shopNum1_User.LastLoginTime = new DateTime?(DateTime.Now);
				shopNum1_User.LastLoginIP = string.Empty;
				shopNum1_User.LastModifyPasswordTime = new DateTime?(DateTime.Now);
				shopNum1_User.CreateUser = base.ShopNum1LoginID;
				shopNum1_User.CreateTime = DateTime.Now;
				shopNum1_User.ModifyUser = base.ShopNum1LoginID;
				shopNum1_User.ModifyTime = DateTime.Now;
				shopNum1_User.IsDeleted = 0;
				if (this.Page.Request.QueryString["sub"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["sub"].ToString()))
				{
					shopNum1_User.SubstationID = this.Page.Request.QueryString["sub"].ToString();
				}
				else
				{
					shopNum1_User.SubstationID = "all";
				}
				List<string> list = new List<string>();
				ShopNum1_GroupUser shopNum1_GroupUser = new ShopNum1_GroupUser();
				if (Convert.ToInt32(this.RadioButtonList1.SelectedValue) == 1)
				{
					shopNum1_User.PeopleType = new int?(1);
					shopNum1_GroupUser.GroupGuid = new Guid(this.DropDownListGroup.SelectedValue);
				}
				else
				{
					shopNum1_User.PeopleType = new int?(0);
				}
				list.Add(shopNum1_GroupUser.GroupGuid.ToString());
				int num = shopNum1_User_Action.Add(shopNum1_User, list);
				if (num > 0)
				{
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
			ShopNum1_User shopNum1_User = new ShopNum1_User();
			shopNum1_User.Guid = new Guid(this.hiddenGuid.Value);
			shopNum1_User.LoginId = this.TextBoxLoginID.Text.Trim();
			if (this.TextBoxPassword1.Text.Trim() != "")
			{
				shopNum1_User.Pwd = Encryption.GetSHA1SecondHash(this.TextBoxPassword1.Text.Trim());
				shopNum1_User.LastModifyPasswordTime = new DateTime?(DateTime.Now);
			}
			shopNum1_User.RealName = this.TextBoxRealName.Text.Trim();
			shopNum1_User.Sex = Convert.ToInt32(this.DropDownListSex.SelectedValue);
			if (this.TextBoxAge.Text.Trim() == string.Empty || this.TextBoxAge.Text.Trim() == null)
			{
				shopNum1_User.Age = 0;
			}
			else
			{
				shopNum1_User.Age = Convert.ToInt32(this.TextBoxAge.Text.Trim());
			}
			shopNum1_User.WorkNumber = this.TextBoxWorkNumber.Text.Trim();
			shopNum1_User.Email = this.TextBoxEmail.Text.Trim();
			shopNum1_User.Telephone = this.TextBoxTelephone.Text.Trim();
			shopNum1_User.IsForbid = Convert.ToInt32(this.DropDownListIsForbid.SelectedValue);
			shopNum1_User.LoginTimes = 0;
			shopNum1_User.LastLoginTime = null;
			shopNum1_User.LastLoginIP = string.Empty;
			shopNum1_User.ModifyUser = base.ShopNum1LoginID;
			shopNum1_User.ModifyTime = DateTime.Now;
			shopNum1_User.IsDeleted = 0;
			List<string> list = new List<string>();
			ShopNum1_GroupUser shopNum1_GroupUser = new ShopNum1_GroupUser();
			if (Convert.ToInt32(this.RadioButtonList1.SelectedValue) == 1)
			{
				shopNum1_User.PeopleType = new int?(1);
				shopNum1_GroupUser.GroupGuid = new Guid(this.DropDownListGroup.SelectedValue);
				list.Add(shopNum1_GroupUser.GroupGuid.ToString());
			}
			else
			{
				shopNum1_User.PeopleType = new int?(0);
			}
			ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
			int num = shopNum1_User_Action.Update(shopNum1_User, list);
			if (num > 0)
			{
				this.Page.RegisterStartupScript("script", "<script>window.parent.location.reload();</script>");
				this.ClearControl();
				this.ButtonConfirm.ToolTip = "Submit";
				this.ButtonConfirm.Text = "确定";
				this.TextBoxLoginID.Enabled = true;
			}
			else
			{
				this.MessageShow.ShowMessage("EditNo");
				this.MessageShow.Visible = true;
			}
		}
	}
}
