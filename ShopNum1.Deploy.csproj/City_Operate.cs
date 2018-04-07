using ShopNum1.BusinessLogic;
using ShopNum1.Common;
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
public class City_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Label LabelFatherID;
	protected DropDownList DropDownListFatherID;
	protected Label Label5;
	protected TextBox TextBoxShortName;
	protected Label Label6;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Label LabelKeywords;
	protected TextBox TextBoxLetter;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidatorKeywords;
	protected Label LabelOrderID;
	protected TextBox TextBoxOrderID;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorOrderID;
	protected Label LabelIsShow;
	protected CheckBox CheckBoxIsShow;
	protected Label Label1;
	protected CheckBox CheckBoxIsHot;
	protected Button ButtonConfirm;
	protected HtmlInputReset inputReset;
	protected MessageShow MessageShow;
	protected HiddenField hiddenGuid;
	protected HtmlForm form1;
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
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
		this.hiddenGuid.Value = ((base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"]);
		if (!this.Page.IsPostBack)
		{
			this.method_6();
			this.GetOrderID();
			if (this.hiddenGuid.Value != "0")
			{
				this.method_8();
			}
		}
	}
	protected void GetOrderID()
	{
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Submit")
		{
			ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
			ShopNum1_City shopNum1_City = new ShopNum1_City();
			shopNum1_City.CityName = this.TextBoxName.Text.Trim();
			shopNum1_City.FatherID = Convert.ToInt32(this.DropDownListFatherID.SelectedValue);
			shopNum1_City.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
			shopNum1_City.Letter = this.TextBoxLetter.Text.Trim();
			shopNum1_City.ShortName = this.TextBoxShortName.Text.Trim();
			if (this.CheckBoxIsShow.Checked)
			{
				shopNum1_City.IsShow = new byte?(1);
			}
			else
			{
				shopNum1_City.IsShow = new byte?(0);
			}
			if (this.CheckBoxIsHot.Checked)
			{
				shopNum1_City.IsHot = new byte?(1);
			}
			else
			{
				shopNum1_City.IsHot = new byte?(0);
			}
			shopNum1_City.CreateUser = base.ShopNum1LoginID;
			shopNum1_City.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_City.ModifyUser = base.ShopNum1LoginID;
			shopNum1_City.ModifyTime = new DateTime?(DateTime.Now);
			shopNum1_City.IsDeleted = new int?(0);
			shopNum1_City.ID = shopNum1_City_Action.GetMaxID();
			if (this.DropDownListFatherID.SelectedValue.ToString() == "0")
			{
				shopNum1_City.CategoryLevel = new int?(1);
			}
			else
			{
				string[] array = this.DropDownListFatherID.SelectedItem.Text.Split(new char[]
				{
					this.charSapce
				});
				if (array.Length > 0)
				{
					shopNum1_City.CategoryLevel = new int?((array.Length + 1) / 2 + 1);
				}
				else
				{
					shopNum1_City.CategoryLevel = new int?(2);
				}
			}
			if (shopNum1_City.CategoryLevel >= 4)
			{
				MessageBox.Show("城市分类级别数为3");
			}
			else
			{
				int num = shopNum1_City_Action.Add(shopNum1_City);
				if (num > 0)
				{
					base.OperateLog(new ShopNum1_OperateLog
					{
						Record = "新增" + this.TextBoxName.Text.Trim() + "成功",
						OperatorID = base.ShopNum1LoginID,
						IP = Globals.IPAddress,
						PageName = "City_Operate.aspx",
						Date = DateTime.Now
					});
					this.MessageShow.ShowMessage("AddYes");
					this.MessageShow.Visible = true;
					this.method_6();
					this.method_9();
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
			if (this.hiddenGuid.Value.ToString() == this.DropDownListFatherID.SelectedValue)
			{
				this.MessageShow.ShowMessage("EditError");
				this.MessageShow.Visible = true;
			}
			else
			{
				ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
				ShopNum1_City shopNum1_City = new ShopNum1_City();
				shopNum1_City.ID = Convert.ToInt32(this.hiddenGuid.Value.Replace("'", ""));
				shopNum1_City.CityName = this.TextBoxName.Text.Trim();
				shopNum1_City.FatherID = Convert.ToInt32(this.DropDownListFatherID.SelectedValue);
				shopNum1_City.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
				shopNum1_City.Letter = this.TextBoxLetter.Text.Trim();
				if (this.CheckBoxIsShow.Checked)
				{
					shopNum1_City.IsShow = new byte?(1);
				}
				else
				{
					shopNum1_City.IsShow = new byte?(0);
				}
				if (this.CheckBoxIsHot.Checked)
				{
					shopNum1_City.IsHot = new byte?(1);
				}
				else
				{
					shopNum1_City.IsHot = new byte?(0);
				}
				shopNum1_City.ModifyUser = base.ShopNum1LoginID;
				shopNum1_City.ModifyTime = new DateTime?(DateTime.Now);
				shopNum1_City.IsDeleted = new int?(0);
				if (this.DropDownListFatherID.SelectedValue.ToString() == "0")
				{
					shopNum1_City.CategoryLevel = new int?(1);
				}
				else
				{
					string[] array = this.DropDownListFatherID.SelectedItem.Text.Split(new char[]
					{
						this.charSapce
					});
					if (array.Length > 0)
					{
						shopNum1_City.CategoryLevel = new int?((array.Length + 1) / 2 + 1);
					}
					else
					{
						shopNum1_City.CategoryLevel = new int?(2);
					}
				}
				if (shopNum1_City.CategoryLevel >= 4)
				{
					MessageBox.Show("商品分类级别数为3");
				}
				else if (this.method_5(shopNum1_City.ID.ToString(), shopNum1_City.FatherID.ToString()))
				{
					MessageBox.Show("无法使用该父分类");
				}
				else
				{
					int num = shopNum1_City_Action.Update(shopNum1_City);
					if (num > 0)
					{
						base.OperateLog(new ShopNum1_OperateLog
						{
							Record = "编辑" + this.TextBoxName.Text.Trim() + "成功",
							OperatorID = base.ShopNum1LoginID,
							IP = Globals.IPAddress,
							PageName = "City_Operate.aspx",
							Date = DateTime.Now
						});
						base.Response.Redirect("City_List.aspx");
					}
					else
					{
						this.MessageShow.ShowMessage("EditNo");
						this.MessageShow.Visible = true;
					}
				}
			}
		}
	}
	private bool method_5(string string_5, string string_6)
	{
		bool result = false;
		ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
		DataTable dataTable = shopNum1_City_Action.CheckIsChilds("ID", "ShopNum1_City", string_5);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			if (string_6.ToString() == dataRow[0].ToString())
			{
				result = true;
				break;
			}
		}
		return result;
	}
	private void method_6()
	{
		this.DropDownListFatherID.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("Select");
		listItem.Value = "0";
		this.DropDownListFatherID.Items.Add(listItem);
		ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
		DataView defaultView = shopNum1_City_Action.Search(0, 0).DefaultView;
		if (defaultView != null)
		{
			foreach (DataRow dataRow in defaultView.Table.Rows)
			{
				ListItem listItem2 = new ListItem();
				if (dataRow["FatherID"].ToString().Trim() == "0")
				{
					listItem2.Text = dataRow["CityName"].ToString().Trim();
					listItem2.Value = dataRow["ID"].ToString().Trim();
					this.DropDownListFatherID.Items.Add(listItem2);
					DataTable dataTable = shopNum1_City_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
					if (dataTable.Rows.Count > 0)
					{
						this.method_7(dataTable);
					}
				}
				else
				{
					DataTable dataTable = shopNum1_City_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
					if (dataTable.Rows.Count > 0)
					{
						this.method_7(dataTable);
					}
					else
					{
						listItem2.Text = "├ " + dataRow["CityName"].ToString().Trim();
						listItem2.Value = dataRow["ID"].ToString().Trim();
						this.DropDownListFatherID.Items.Add(listItem2);
					}
				}
			}
		}
	}
	private void method_7(DataTable dt)
	{
		ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
		foreach (DataRow dataRow in dt.Rows)
		{
			ListItem listItem = new ListItem();
			string text = string.Empty;
			for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
			{
				text += this.strSapce;
			}
			text += this.charSapce;
			text += dataRow["CityName"].ToString().Trim();
			listItem.Text = text;
			listItem.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListFatherID.Items.Add(listItem);
			DataTable dataTable = shopNum1_City_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.method_7(dataTable);
			}
		}
	}
	private void method_8()
	{
		ShopNum1_City_Action shopNum1_City_Action = new ShopNum1_City_Action();
		DataTable dataTable = shopNum1_City_Action.SearchInfoByID(this.hiddenGuid.Value.ToString());
		this.TextBoxName.Text = dataTable.Rows[0]["CityName"].ToString();
		this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
		this.TextBoxLetter.Text = dataTable.Rows[0]["Letter"].ToString().Replace(" ", "");
		if (dataTable.Rows[0]["IsHot"].ToString() == "0")
		{
			this.CheckBoxIsHot.Checked = false;
		}
		else
		{
			this.CheckBoxIsHot.Checked = true;
		}
		if (dataTable.Rows[0]["IsShow"].ToString() == "0")
		{
			this.CheckBoxIsShow.Checked = false;
		}
		else
		{
			this.CheckBoxIsShow.Checked = true;
		}
		this.TextBoxShortName.Text = dataTable.Rows[0]["ShortName"].ToString();
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
		this.LabelPageTitle.Text = "编辑商品分类";
	}
	private void method_9()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxOrderID.Text = string.Empty;
		this.DropDownListFatherID.SelectedValue = "0";
		this.TextBoxLetter.Text = string.Empty;
		this.CheckBoxIsShow.Checked = true;
		this.GetOrderID();
	}
}
