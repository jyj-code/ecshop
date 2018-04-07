using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Page_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelSPagePath;
	protected System.Web.UI.WebControls.TextBox TextBoxSName;
	protected Label LabelSOne;
	protected System.Web.UI.WebControls.DropDownList DropDownListSOne;
	protected Label LabelSTwo;
	protected System.Web.UI.WebControls.DropDownList DropDownListSTwo;
	protected Label LabelSName;
	protected System.Web.UI.WebControls.TextBox TextBoxSPagePath;
	protected Label LabelSPageType;
	protected System.Web.UI.WebControls.DropDownList DropDownListSPageType;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.Button ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected System.Web.UI.WebControls.Button ButtonDel;
	protected System.Web.UI.WebControls.Button ButtonManageControl;
	protected Num1GridView Num1GridViewShow;
	protected Label LabelPageTitle;
	protected Label LabelPageType;
	protected System.Web.UI.WebControls.DropDownList DropDownListPageType;
	protected Label Label5;
	protected CompareValidator CompareValidatorPageType;
	protected Label LabelOne;
	protected System.Web.UI.WebControls.DropDownList DropDownListOne;
	protected Label Label8;
	protected Label LabelTwo;
	protected System.Web.UI.WebControls.DropDownList DropDownListTwo;
	protected Label LabelName;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorLoginID0;
	protected Label LabelPagePath;
	protected System.Web.UI.WebControls.TextBox TextBoxPagePath;
	protected RegularExpressionValidator RegularExpressionValidatorPagePath;
	protected Label LabelDescription;
	protected System.Web.UI.WebControls.TextBox TextBoxDescription;
	protected Label LabelOrderID;
	protected System.Web.UI.WebControls.TextBox TextBoxOrderID;
	protected Label Label7;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorLoginID;
	protected System.Web.UI.WebControls.Button ButtonConfirm;
	protected HtmlInputReset inputReset;
	protected MessageShow MessageShow;
	protected HtmlGenericControl divPage;
	protected HiddenField CheckGuid;
	protected HiddenField hiddenGuid;
	protected ObjectDataSource ObjectDataSourceData;
	protected HtmlForm form1;
	protected bool One = false;
	protected bool Two = false;
	protected bool PagePath = true;
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
			if (base.ShopNum1UserGuid.ToUpper() == "8EA30851-571B-4FFA-8870-05A7E5134AA9".ToUpper())
			{
				this.ButtonDel.Visible = true;
			}
		}
	}
	private void method_5()
	{
		this.BindOne();
		this.BindSOne();
		this.BindSTwo();
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.DropDownListPageType.Enabled = true;
		this.ClearControl();
		if (this.ButtonAdd.ToolTip == "addok")
		{
			this.ButtonConfirm.ToolTip = "add";
			this.divPage.Visible = true;
			this.ButtonAdd.Text = "取消";
			this.ButtonAdd.ToolTip = "addno";
		}
		else
		{
			this.divPage.Visible = false;
			this.ButtonAdd.Text = "添加";
			this.ButtonAdd.ToolTip = "addok";
		}
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		this.ButtonConfirm.ToolTip = "update";
		this.LabelPageTitle.Text = "【编辑页面】";
		this.divPage.Visible = true;
		string guid = this.CheckGuid.Value.Replace("'", "");
		IShopNum1_Page_Action shopNum1_Page_Action = LogicFactory.CreateShopNum1_Page_Action();
		DataTable dataTable = shopNum1_Page_Action.Search(guid, 0);
		if (dataTable != null && dataTable.Rows.Count != 0)
		{
			this.BindOne();
			this.DropDownListPageType.SelectedValue = dataTable.Rows[0]["PageType"].ToString();
			if (this.DropDownListPageType.SelectedValue.Equals("-1"))
			{
				this.RemoveOne();
			}
			else
			{
				if (this.DropDownListPageType.SelectedValue.Equals("3"))
				{
					this.One = false;
					this.Two = false;
					this.RemoveOne();
				}
				else if (this.DropDownListPageType.SelectedValue.Equals("0"))
				{
					this.One = true;
					this.AddOne();
				}
				else if (this.DropDownListPageType.SelectedValue.Equals("1"))
				{
					this.One = true;
					this.Two = true;
					this.BindOne();
					this.DropDownListOne.SelectedValue = dataTable.Rows[0]["OneID"].ToString();
					this.BindTwo();
					this.DropDownListTwo.SelectedValue = dataTable.Rows[0]["TwoID"].ToString();
					this.RemoveOne();
				}
				if (this.DropDownListTwo.SelectedValue.Equals("-1"))
				{
					this.PagePath = false;
				}
				this.DropDownListPageType.Enabled = false;
				this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
				this.TextBoxPagePath.Text = ((dataTable.Rows[0]["PagePath"] != null) ? dataTable.Rows[0]["PagePath"].ToString() : "");
				this.TextBoxDescription.Text = dataTable.Rows[0]["Description"].ToString();
				this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
				this.ViewState["ThreeID"] = dataTable.Rows[0]["ThreeID"].ToString();
				this.ViewState["TwoID"] = dataTable.Rows[0]["TwoID"].ToString();
			}
		}
	}
	protected void ButtonEditByLink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string text = "'" + linkButton.CommandArgument + "'";
		this.hiddenGuid.Value = text;
		this.ButtonConfirm.ToolTip = "update";
		this.LabelPageTitle.Text = "【编辑页面】";
		this.divPage.Visible = true;
		string guid = text.Replace("'", "");
		IShopNum1_Page_Action shopNum1_Page_Action = LogicFactory.CreateShopNum1_Page_Action();
		DataTable dataTable = shopNum1_Page_Action.Search(guid, 0);
		if (dataTable != null && dataTable.Rows.Count != 0)
		{
			this.BindOne();
			this.DropDownListPageType.SelectedValue = dataTable.Rows[0]["PageType"].ToString();
			if (this.DropDownListPageType.SelectedValue.Equals("-1"))
			{
				this.RemoveOne();
			}
			else
			{
				if (this.DropDownListPageType.SelectedValue.Equals("3"))
				{
					this.One = false;
					this.Two = false;
					this.RemoveOne();
				}
				else if (this.DropDownListPageType.SelectedValue.Equals("0"))
				{
					this.One = true;
					this.AddOne();
				}
				else if (this.DropDownListPageType.SelectedValue.Equals("1"))
				{
					this.One = true;
					this.Two = true;
					this.BindOne();
					this.DropDownListOne.SelectedValue = dataTable.Rows[0]["OneID"].ToString();
					this.BindTwo();
					this.DropDownListTwo.SelectedValue = dataTable.Rows[0]["TwoID"].ToString();
					this.RemoveOne();
				}
				if (this.DropDownListTwo.SelectedValue.Equals("-1"))
				{
					this.PagePath = false;
				}
				this.DropDownListPageType.Enabled = false;
				this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
				this.TextBoxPagePath.Text = ((dataTable.Rows[0]["PagePath"] != null) ? dataTable.Rows[0]["PagePath"].ToString() : "");
				this.TextBoxDescription.Text = dataTable.Rows[0]["Description"].ToString();
				this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
				this.ViewState["ThreeID"] = dataTable.Rows[0]["ThreeID"].ToString();
				this.ViewState["TwoID"] = dataTable.Rows[0]["TwoID"].ToString();
			}
		}
	}
	protected void ButtonDel_Click(object sender, EventArgs e)
	{
		string pageguid = this.CheckGuid.Value.Replace("'", "");
		ShopNum1_Page_Action shopNum1_Page_Action = (ShopNum1_Page_Action)LogicFactory.CreateShopNum1_Page_Action();
		if (shopNum1_Page_Action.DelPageBySuper(pageguid) > 0)
		{
			this.MessageShow.ShowMessage("操作成功");
			this.MessageShow.Visible = true;
			this.method_5();
			this.BindGrid();
		}
		else
		{
			this.MessageShow.ShowMessage("操作失败");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		int threeID = 0;
		int oneID = 1 + ShopNum1_Common_Action.ReturnMaxID("OneID", "ShopNum1_Page");
		ShopNum1_Page_Action shopNum1_Page_Action = (ShopNum1_Page_Action)LogicFactory.CreateShopNum1_Page_Action();
		ShopNum1_Page shopNum1_Page = new ShopNum1_Page();
		if (this.ButtonConfirm.ToolTip == "add")
		{
			shopNum1_Page.Guid = Guid.NewGuid();
			shopNum1_Page.Name = this.TextBoxName.Text.Trim();
			shopNum1_Page.PagePath = this.TextBoxPagePath.Text.Trim();
			shopNum1_Page.PageType = Convert.ToInt32(this.DropDownListPageType.SelectedValue);
			shopNum1_Page.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
			shopNum1_Page.Description = this.TextBoxDescription.Text.Trim();
			shopNum1_Page.ThreeID = 0;
			if (this.DropDownListPageType.SelectedValue.Equals("0"))
			{
				if (this.DropDownListOne.SelectedValue.Equals("-1"))
				{
					shopNum1_Page.OneID = oneID;
					shopNum1_Page.TwoID = 0;
				}
				else
				{
					shopNum1_Page.OneID = Convert.ToInt32(this.DropDownListOne.SelectedValue);
					int twoID = 1 + shopNum1_Page_Action.RetrunMaxTwoID(Convert.ToInt32(this.DropDownListOne.SelectedValue));
					shopNum1_Page.TwoID = twoID;
				}
			}
			else if (this.DropDownListPageType.SelectedValue.Equals("3"))
			{
				shopNum1_Page.OneID = oneID;
				shopNum1_Page.TwoID = 0;
			}
			else if (this.DropDownListPageType.SelectedValue.Equals("1"))
			{
				if (this.DropDownListTwo.SelectedValue == "" || this.DropDownListTwo.SelectedValue == "-1")
				{
					this.DropDownListTwo.Focus();
					base.Response.Write(" <script>alert('操作有误!'); window.location.href=window.location.href </script> ");
				}
				shopNum1_Page.OneID = Convert.ToInt32(this.DropDownListOne.SelectedValue);
				shopNum1_Page.TwoID = Convert.ToInt32(this.DropDownListTwo.SelectedValue);
				threeID = 1 + shopNum1_Page_Action.RetrunMaxThreeID(shopNum1_Page.OneID, shopNum1_Page.TwoID);
				shopNum1_Page.ThreeID = threeID;
			}
			shopNum1_Page.CreateUser = "admin";
			shopNum1_Page.CreateTime = DateTime.Now;
			shopNum1_Page.ModifyUser = "admin";
			shopNum1_Page.ModifyTime = DateTime.Now;
			shopNum1_Page.IsDeleted = 0;
			int num = shopNum1_Page_Action.Add(shopNum1_Page);
			if (num > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "系统管理员添加页面",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "Page_List.aspx",
					Date = DateTime.Now
				});
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
				this.method_5();
				this.BindGrid();
				this.ClearControl();
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
		else
		{
			shopNum1_Page.Guid = new Guid(this.hiddenGuid.Value.Replace("'", ""));
			shopNum1_Page.Name = this.TextBoxName.Text.Trim();
			shopNum1_Page.PagePath = this.TextBoxPagePath.Text.Trim();
			shopNum1_Page.PageType = Convert.ToInt32(this.DropDownListPageType.SelectedValue);
			shopNum1_Page.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
			shopNum1_Page.Description = this.TextBoxDescription.Text.Trim();
			shopNum1_Page.ThreeID = Convert.ToInt32(this.ViewState["ThreeID"]);
			shopNum1_Page.TwoID = Convert.ToInt32(this.ViewState["TwoID"]);
			shopNum1_Page.OneID = Convert.ToInt32(this.ViewState["OneID"]);
			if (this.DropDownListPageType.SelectedValue.Equals("0"))
			{
				if (this.DropDownListOne.SelectedValue.Equals("-1"))
				{
					shopNum1_Page.OneID = oneID;
					shopNum1_Page.TwoID = 0;
				}
				else
				{
					shopNum1_Page.OneID = Convert.ToInt32(this.DropDownListOne.SelectedValue);
					int twoID = 1 + shopNum1_Page_Action.RetrunMaxTwoID(Convert.ToInt32(this.DropDownListOne.SelectedValue));
					shopNum1_Page.TwoID = twoID;
				}
			}
			else if (this.DropDownListPageType.SelectedValue.Equals("3"))
			{
				shopNum1_Page.OneID = oneID;
				shopNum1_Page.TwoID = 0;
			}
			else if (this.DropDownListPageType.SelectedValue.Equals("1"))
			{
				if (this.DropDownListTwo.SelectedValue == "" || this.DropDownListTwo.SelectedValue == "-1")
				{
					base.Response.Write(" <script>alert('操作有误!'); window.location.href=window.location.href </script> ");
					return;
				}
				shopNum1_Page.OneID = Convert.ToInt32(this.DropDownListOne.SelectedValue);
				shopNum1_Page.TwoID = Convert.ToInt32(this.DropDownListTwo.SelectedValue);
				shopNum1_Page.ThreeID = threeID;
			}
			shopNum1_Page.ModifyUser = "admin";
			shopNum1_Page.ModifyTime = DateTime.Now;
			shopNum1_Page.IsDeleted = 0;
			int num = shopNum1_Page_Action.Update(shopNum1_Page);
			if (num > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "系统管理员修改页面",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "Page_List.aspx",
					Date = DateTime.Now
				});
				this.MessageShow.ShowMessage("EditYes");
				this.MessageShow.Visible = true;
				this.method_5();
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
	protected void DropDownListOne_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListOne.SelectedValue.Equals("-1"))
		{
			this.One = true;
			this.PagePath = false;
		}
		else
		{
			this.One = true;
			this.Two = true;
			if (this.DropDownListPageType.SelectedValue.Equals("0"))
			{
				this.Two = false;
			}
			this.BindTwo();
		}
	}
	protected void DropDownListPageType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListPageType.SelectedValue.Equals("-1"))
		{
			this.RemoveOne();
		}
		else
		{
			if (this.DropDownListPageType.SelectedValue.Equals("3"))
			{
				this.One = false;
				this.Two = false;
				this.RemoveOne();
			}
			else if (this.DropDownListPageType.SelectedValue.Equals("0"))
			{
				this.One = true;
				this.AddOne();
			}
			else if (this.DropDownListPageType.SelectedValue.Equals("1"))
			{
				this.One = true;
				this.Two = true;
				this.BindOne();
				this.BindTwo();
				this.RemoveOne();
			}
			if (this.DropDownListTwo.SelectedValue.Equals("-1"))
			{
				this.PagePath = false;
			}
		}
	}
	protected void DropDownListTwo_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.One = true;
		this.Two = true;
	}
	protected void DropDownListSOne_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.BindSTwo();
	}
	public void GetMaxID()
	{
		int num = ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Page");
		this.TextBoxOrderID.Text = (num + 1).ToString();
	}
	protected void ButtonManageControl_Click(object sender, EventArgs e)
	{
		string str = this.CheckGuid.Value.Replace("'", "");
		base.Response.Redirect("Control_List.aspx?Guid=" + str);
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void BindOne()
	{
		this.DropDownListOne.Items.Clear();
		ShopNum1_Page_Action shopNum1_Page_Action = (ShopNum1_Page_Action)LogicFactory.CreateShopNum1_Page_Action();
		DataTable onePage = shopNum1_Page_Action.GetOnePage(0);
		foreach (DataRow dataRow in onePage.Rows)
		{
			ListItem listItem = new ListItem();
			listItem.Text = dataRow["Name"].ToString();
			listItem.Value = dataRow["OneID"].ToString();
			this.DropDownListOne.Items.Add(listItem);
		}
	}
	protected void BindTwo()
	{
		if (!(Operator.FormatToEmpty(this.DropDownListOne.SelectedValue) == string.Empty))
		{
			this.DropDownListTwo.Items.Clear();
			ShopNum1_Page_Action shopNum1_Page_Action = (ShopNum1_Page_Action)LogicFactory.CreateShopNum1_Page_Action();
			DataTable twopage = shopNum1_Page_Action.GetTwopage(Convert.ToInt32(this.DropDownListOne.SelectedValue), 0);
			foreach (DataRow dataRow in twopage.Rows)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataRow["Name"].ToString();
				listItem.Value = dataRow["TwoID"].ToString();
				this.DropDownListTwo.Items.Add(listItem);
			}
		}
	}
	protected void BindSOne()
	{
		this.DropDownListSOne.Items.Clear();
		this.AddAll(ref this.DropDownListSOne);
		ShopNum1_Page_Action shopNum1_Page_Action = (ShopNum1_Page_Action)LogicFactory.CreateShopNum1_Page_Action();
		DataTable onePage = shopNum1_Page_Action.GetOnePage(0);
		foreach (DataRow dataRow in onePage.Rows)
		{
			ListItem listItem = new ListItem();
			listItem.Text = dataRow["Name"].ToString();
			listItem.Value = dataRow["OneID"].ToString();
			this.DropDownListSOne.Items.Add(listItem);
		}
	}
	protected void BindSTwo()
	{
		this.DropDownListSTwo.Items.Clear();
		this.AddAll(ref this.DropDownListSTwo);
		ShopNum1_Page_Action shopNum1_Page_Action = (ShopNum1_Page_Action)LogicFactory.CreateShopNum1_Page_Action();
		DataTable twopage = shopNum1_Page_Action.GetTwopage(Convert.ToInt32(this.DropDownListSOne.SelectedValue), 0);
		foreach (DataRow dataRow in twopage.Rows)
		{
			ListItem listItem = new ListItem();
			listItem.Text = dataRow["Name"].ToString();
			listItem.Value = dataRow["TwoID"].ToString();
			this.DropDownListSTwo.Items.Add(listItem);
		}
	}
	protected void BindPageType()
	{
	}
	protected void RemoveOne()
	{
		for (int i = 0; i < this.DropDownListOne.Items.Count; i++)
		{
			if (this.DropDownListOne.Items[i].Value.Equals("-1"))
			{
				this.DropDownListOne.Items.Remove(this.DropDownListOne.Items[i]);
			}
		}
	}
	protected void AddOne()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "为一级目录";
		listItem.Value = "-1";
		this.DropDownListOne.Items.Add(listItem);
	}
	protected void AddAll(ref System.Web.UI.WebControls.DropDownList dropDownList)
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-1";
		if (!dropDownList.Items.Contains(listItem))
		{
			dropDownList.Items.Add(listItem);
		}
	}
	protected void ClearControl()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxOrderID.Text = string.Empty;
		this.TextBoxPagePath.Text = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
		this.DropDownListPageType.SelectedValue = "-1";
		this.One = false;
		this.Two = false;
	}
	public string ChangePageType(string strPageType)
	{
		string result;
		if (strPageType == "0")
		{
			result = "左边菜单页面";
		}
		else if (strPageType == "1")
		{
			result = "普通操作页面";
		}
		else if (strPageType == "3")
		{
			result = "顶部页面";
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
		string pageguid = "'" + linkButton.CommandArgument + "'";
		ShopNum1_Page_Action shopNum1_Page_Action = (ShopNum1_Page_Action)LogicFactory.CreateShopNum1_Page_Action();
		int num = shopNum1_Page_Action.DelPageBySuper(pageguid);
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
