using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ImageCategory_Operate : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Label LabelFatherID;
	protected DropDownList DropDownListFatherID;
	protected Label LabelDescription;
	protected TextBox TextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorDescription;
	protected Button ButtonConfirm;
	protected AgentAdmin_MessageShow MessageShow;
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
		this.hiddenGuid.Value = ((base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"]);
		if (!this.Page.IsPostBack)
		{
			this.method_6();
			if (this.hiddenGuid.Value != "0")
			{
				this.method_8();
				this.DropDownListFatherID.Enabled = false;
			}
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (!this.method_5())
		{
			MessageBox.Show("分类名称不能和上级分类重复!");
		}
		else if (this.ButtonConfirm.ToolTip == "Submit")
		{
			string family = "";
			string name = this.TextBoxName.Text.Trim();
			string description = this.TextBoxDescription.Text.Trim();
			string selectedValue = this.DropDownListFatherID.SelectedValue;
			string user = "admin";
			int num;
			if (this.DropDownListFatherID.SelectedValue.ToString() == "0")
			{
				num = 1;
			}
			else
			{
				string[] array = this.DropDownListFatherID.SelectedItem.Text.Split(new char[]
				{
					this.charSapce
				});
				if (array.Length > 0)
				{
					num = (array.Length + 1) / 2 + 1;
				}
				else
				{
					num = 2;
				}
			}
			ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
			int num2 = shopNum1_ImageCategory_Action.Insert(name, description, num.ToString(), selectedValue, family, user);
			if (num2 > 0)
			{
				this.Page.RegisterStartupScript("script", "<script>alert('添加成功！');window.parent.location.reload();</script>");
				this.method_6();
				this.method_9();
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
		else if (this.ButtonConfirm.ToolTip == "Update")
		{
			string family = "";
			string strid = this.hiddenGuid.Value.ToString();
			string name = this.TextBoxName.Text.Trim();
			string description = this.TextBoxDescription.Text.Trim();
			string selectedValue = this.DropDownListFatherID.SelectedValue;
			string user = "admin";
			int num;
			if (this.DropDownListFatherID.SelectedValue.ToString() == "0")
			{
				num = 1;
			}
			else
			{
				string[] array = this.DropDownListFatherID.SelectedItem.Text.Split(new char[]
				{
					this.charSapce
				});
				if (array.Length > 0)
				{
					num = (array.Length + 1) / 2 + 1;
				}
				else
				{
					num = 2;
				}
			}
			ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
			int num2 = shopNum1_ImageCategory_Action.Update(strid, name, description, num.ToString(), selectedValue, family, user);
			if (num2 > 0)
			{
				this.Page.RegisterStartupScript("script", "<script>window.parent.location.reload();</script>");
			}
			else
			{
				this.MessageShow.ShowMessage("EditNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	private bool method_5()
	{
		string a = this.TextBoxName.Text.Trim();
		return !(a == this.DropDownListFatherID.SelectedItem.Text);
	}
	private void method_6()
	{
		this.DropDownListFatherID.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "全部";
		listItem.Value = "0";
		this.DropDownListFatherID.Items.Add(listItem);
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		DataView defaultView = shopNum1_ImageCategory_Action.Search(0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListFatherID.Items.Add(listItem2);
			DataTable dataTable = shopNum1_ImageCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()));
			if (dataTable.Rows.Count > 0)
			{
				this.method_7(dataTable);
			}
		}
	}
	private void method_7(DataTable dt)
	{
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		foreach (DataRow dataRow in dt.Rows)
		{
			ListItem listItem = new ListItem();
			string text = string.Empty;
			for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
			{
				text += this.strSapce;
			}
			text += dataRow["Name"].ToString().Trim();
			listItem.Text = text;
			listItem.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListFatherID.Items.Add(listItem);
			DataTable dataTable = shopNum1_ImageCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()));
			if (dataTable.Rows.Count > 0)
			{
				this.method_7(dataTable);
			}
		}
	}
	private void method_8()
	{
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		DataTable dataTable = shopNum1_ImageCategory_Action.SearchInfoByID(this.hiddenGuid.Value.ToString());
		this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
		this.ViewState["cName"] = this.TextBoxName.Text;
		this.DropDownListFatherID.SelectedValue = dataTable.Rows[0]["FatherID"].ToString();
		this.TextBoxDescription.Text = dataTable.Rows[0]["Description"].ToString();
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
		this.LabelPageTitle.Text = "编辑图片分类";
	}
	private void method_9()
	{
		this.TextBoxName.Text = string.Empty;
		this.DropDownListFatherID.SelectedValue = "0";
		this.TextBoxDescription.Text = string.Empty;
	}
}
