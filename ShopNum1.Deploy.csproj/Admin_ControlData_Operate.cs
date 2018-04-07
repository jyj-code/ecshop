using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ControlData_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelTitle;
	protected DropDownList DropDownListDataType;
	protected Label Label17;
	protected TextBox TextBoxTitle;
	protected Label Label18;
	protected RequiredFieldValidator RequiredFieldValidator7;
	protected Label Label22;
	protected TextBox TextBoxHref;
	protected Label Label24;
	protected RequiredFieldValidator RequiredFieldValidator9;
	protected RegularExpressionValidator RegularExpressionValidator10;
	protected Label LabelHref;
	protected Label Label2;
	protected TextBox TextBoxOrderID;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorContent;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryOrderID;
	protected Label Label19;
	protected TextBox TextBoxGroupID;
	protected Label Label20;
	protected RequiredFieldValidator RequiredFieldValidator8;
	protected RegularExpressionValidator RegularExpressionValidator5;
	protected Label Label11;
	protected TextBox TextBoxControlImg;
	protected Label Label15;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected HtmlImage ImgControlImg;
	protected Panel PanelImg;
	protected Label Label9;
	protected TextBox TextBoxProductImg;
	protected Label Label10;
	protected RequiredFieldValidator RequiredFieldValidator4;
	protected HtmlImage ImgProductImg;
	protected Label Label12;
	protected TextBox TextBoxPrice;
	protected Label Label13;
	protected RequiredFieldValidator RequiredFieldValidator5;
	protected RegularExpressionValidator RegularExpressionValidatorCostPrice1;
	protected Panel PanelProduct;
	protected Label Label14;
	protected TextBox TextBoxFlashImage;
	protected Label Label16;
	protected RequiredFieldValidator RequiredFieldValidator6;
	protected RegularExpressionValidator RegularExpressionValidator3;
	protected Panel PanelFlash;
	protected CheckBox CheckBoxMore;
	protected Label Label1;
	protected DropDownList DropDownListIsShow;
	protected Label Label23;
	protected TextBox TextBoxTitle1;
	protected Label Label21;
	protected TextBox TextBoxHref1;
	protected RegularExpressionValidator RegularExpressionValidator6;
	protected Label Label25;
	protected TextBox TextBoxTitle2;
	protected Label Label27;
	protected TextBox TextBoxHref2;
	protected RegularExpressionValidator RegularExpressionValidator9;
	protected Panel PanelMore;
	protected Button BottonConfirm;
	protected Button BottonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldControlGuid;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		this.HiddenFieldControlGuid.Value = ((base.Request.QueryString["ControlGuid"] == null) ? "0" : base.Request.QueryString["ControlGuid"]);
		if (!this.Page.IsPostBack)
		{
			this.GetOrderID();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "【 编辑模块数据 】";
				this.GetEditInfo();
			}
		}
	}
	protected void GetOrderID()
	{
		string columnName = "OrderID";
		string tableName = "ShopNum1_ControlData";
		this.TextBoxOrderID.Text = Convert.ToString(1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.BottonConfirm.ToolTip == "Update")
		{
			this.Edit();
		}
		else if (this.BottonConfirm.ToolTip == "Submit")
		{
			this.Add();
		}
	}
	protected void Add()
	{
		ShopNum1_ControlData shopNum1_ControlData = new ShopNum1_ControlData();
		shopNum1_ControlData.Guid = Guid.NewGuid();
		shopNum1_ControlData.Title = this.TextBoxTitle.Text;
		shopNum1_ControlData.OrderID = int.Parse(this.TextBoxOrderID.Text);
		shopNum1_ControlData.GroupID = int.Parse(this.TextBoxGroupID.Text);
		shopNum1_ControlData.DataType = int.Parse(this.DropDownListDataType.SelectedValue);
		shopNum1_ControlData.Href = this.TextBoxHref.Text;
		shopNum1_ControlData.Price = 0m;
		if (this.DropDownListDataType.SelectedValue == "2")
		{
			shopNum1_ControlData.Image = this.TextBoxControlImg.Text;
			shopNum1_ControlData.Price = 0m;
		}
		else if (this.DropDownListDataType.SelectedValue == "3")
		{
			shopNum1_ControlData.Image = this.TextBoxProductImg.Text;
			shopNum1_ControlData.Price = decimal.Parse(this.TextBoxPrice.Text);
		}
		else if (this.DropDownListDataType.SelectedValue == "4")
		{
			shopNum1_ControlData.Image = this.TextBoxFlashImage.Text;
		}
		if (this.CheckBoxMore.Checked)
		{
			ShopNum1_ControlData expr_13C = shopNum1_ControlData;
			string text = expr_13C.Title;
			expr_13C.Title = string.Concat(new string[]
			{
				text,
				"|",
				this.TextBoxTitle1.Text,
				"|",
				this.TextBoxTitle2.Text
			});
			ShopNum1_ControlData expr_18F = shopNum1_ControlData;
			text = expr_18F.Href;
			expr_18F.Href = string.Concat(new string[]
			{
				text,
				"|",
				this.TextBoxHref1.Text,
				"|",
				this.TextBoxHref2.Text
			});
		}
		shopNum1_ControlData.IsShow = int.Parse(this.DropDownListIsShow.SelectedValue);
		shopNum1_ControlData.ControlGuid = this.HiddenFieldControlGuid.Value.ToString();
		shopNum1_ControlData.CreateUser = base.ShopNum1LoginID;
		shopNum1_ControlData.CreateTime = DateTime.Now;
		shopNum1_ControlData.ModifyUser = base.ShopNum1LoginID;
		shopNum1_ControlData.ModifyTime = DateTime.Now;
		ShopNum1_ControlData_Action shopNum1_ControlData_Action = (ShopNum1_ControlData_Action)LogicFactory.CreateShopNum1_ControlData_Action();
		int num = shopNum1_ControlData_Action.Insert(shopNum1_ControlData);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "新增" + this.LabelTitle.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ControlData_Operate.aspx",
				Date = DateTime.Now
			});
			base.Response.Redirect("ControlData_List.aspx?guid=" + this.HiddenFieldControlGuid.Value.Replace("'", ""));
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Edit()
	{
		ShopNum1_ControlData shopNum1_ControlData = new ShopNum1_ControlData();
		shopNum1_ControlData.Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", ""));
		shopNum1_ControlData.Title = this.TextBoxTitle.Text;
		shopNum1_ControlData.OrderID = int.Parse(this.TextBoxOrderID.Text);
		shopNum1_ControlData.GroupID = int.Parse(this.TextBoxGroupID.Text);
		shopNum1_ControlData.DataType = int.Parse(this.DropDownListDataType.SelectedValue);
		shopNum1_ControlData.Href = this.TextBoxHref.Text;
		shopNum1_ControlData.Price = 0m;
		if (this.DropDownListDataType.SelectedValue == "2")
		{
			shopNum1_ControlData.Image = this.TextBoxControlImg.Text;
		}
		else if (this.DropDownListDataType.SelectedValue == "3")
		{
			shopNum1_ControlData.Image = this.TextBoxProductImg.Text;
			shopNum1_ControlData.Price = decimal.Parse(this.TextBoxPrice.Text);
		}
		else if (this.DropDownListDataType.SelectedValue == "4")
		{
			shopNum1_ControlData.Image = this.TextBoxFlashImage.Text;
		}
		if (this.CheckBoxMore.Checked)
		{
			ShopNum1_ControlData expr_14A = shopNum1_ControlData;
			string text = expr_14A.Title;
			expr_14A.Title = string.Concat(new string[]
			{
				text,
				"| ",
				this.TextBoxTitle1.Text,
				"| ",
				this.TextBoxTitle2.Text
			});
			ShopNum1_ControlData expr_19D = shopNum1_ControlData;
			text = expr_19D.Href;
			expr_19D.Href = string.Concat(new string[]
			{
				text,
				"| ",
				this.TextBoxHref1.Text,
				"| ",
				this.TextBoxHref2.Text
			});
		}
		shopNum1_ControlData.IsShow = int.Parse(this.DropDownListIsShow.SelectedValue);
		shopNum1_ControlData.ModifyUser = base.ShopNum1LoginID;
		shopNum1_ControlData.ModifyTime = DateTime.Now;
		ShopNum1_ControlData_Action shopNum1_ControlData_Action = (ShopNum1_ControlData_Action)LogicFactory.CreateShopNum1_ControlData_Action();
		int num = shopNum1_ControlData_Action.Update(shopNum1_ControlData);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "编辑" + this.LabelTitle.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ControlData_Operate.aspx",
				Date = DateTime.Now
			});
			base.Response.Redirect("ControlData_List.aspx?guid=" + this.HiddenFieldControlGuid.Value.Replace("'", ""));
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_ControlData_Action shopNum1_ControlData_Action = (ShopNum1_ControlData_Action)LogicFactory.CreateShopNum1_ControlData_Action();
		DataTable editInfo = shopNum1_ControlData_Action.GetEditInfo(this.hiddenFieldGuid.Value);
		string text = editInfo.Rows[0]["Title"].ToString();
		this.TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
		this.TextBoxGroupID.Text = editInfo.Rows[0]["GroupID"].ToString();
		this.DropDownListDataType.SelectedValue = editInfo.Rows[0]["DataType"].ToString();
		this.DropDownListIsShow.SelectedValue = editInfo.Rows[0]["IsShow"].ToString();
		string text2 = editInfo.Rows[0]["Href"].ToString();
		if (text.Contains("|") || text2.Contains("|"))
		{
			this.CheckBoxMore.Checked = true;
			this.CheckBoxMore_CheckedChanged(null, null);
			this.TextBoxTitle.Text = text.Split(new char[]
			{
				'|'
			})[0].ToString();
			this.TextBoxTitle1.Text = text.Split(new char[]
			{
				'|'
			})[1].ToString();
			this.TextBoxTitle2.Text = text.Split(new char[]
			{
				'|'
			})[2].ToString();
			this.TextBoxHref.Text = text2.Split(new char[]
			{
				'|'
			})[0].ToString();
			this.TextBoxHref1.Text = text2.Split(new char[]
			{
				'|'
			})[1].ToString();
			this.TextBoxHref2.Text = text2.Split(new char[]
			{
				'|'
			})[2].ToString();
		}
		else
		{
			this.TextBoxTitle.Text = text;
			this.TextBoxHref.Text = text2;
		}
		if (this.DropDownListDataType.SelectedValue == "1")
		{
			this.PanelImg.Visible = false;
			this.PanelProduct.Visible = false;
			this.PanelFlash.Visible = false;
		}
		if (this.DropDownListDataType.SelectedValue == "2")
		{
			this.PanelImg.Visible = true;
			this.PanelProduct.Visible = false;
			this.PanelFlash.Visible = false;
			this.TextBoxControlImg.Text = editInfo.Rows[0]["Image"].ToString();
			this.ImgControlImg.Src = "~/ImgUpload/" + editInfo.Rows[0]["Image"].ToString();
		}
		if (this.DropDownListDataType.SelectedValue == "3")
		{
			this.PanelImg.Visible = false;
			this.PanelProduct.Visible = true;
			this.PanelFlash.Visible = false;
			this.TextBoxProductImg.Text = editInfo.Rows[0]["Image"].ToString();
			this.ImgControlImg.Src = "~/ImgUpload/" + editInfo.Rows[0]["Image"].ToString();
			this.TextBoxPrice.Text = editInfo.Rows[0]["Price"].ToString();
		}
		if (this.DropDownListDataType.SelectedValue == "4")
		{
			this.PanelImg.Visible = false;
			this.PanelProduct.Visible = false;
			this.PanelFlash.Visible = true;
			this.TextBoxFlashImage.Text = editInfo.Rows[0]["Image"].ToString();
			this.ImgControlImg.Src = "~/ImgUpload/" + editInfo.Rows[0]["Image"].ToString();
		}
		this.BottonConfirm.Text = "更新";
		this.BottonConfirm.ToolTip = "Update";
	}
	protected void DropDownListDataType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListDataType.SelectedValue == "1")
		{
			this.PanelImg.Visible = false;
			this.PanelProduct.Visible = false;
			this.PanelFlash.Visible = false;
		}
		if (this.DropDownListDataType.SelectedValue == "2")
		{
			this.PanelImg.Visible = true;
			this.PanelProduct.Visible = false;
			this.PanelFlash.Visible = false;
		}
		if (this.DropDownListDataType.SelectedValue == "3")
		{
			this.PanelImg.Visible = false;
			this.PanelProduct.Visible = true;
			this.PanelFlash.Visible = false;
		}
		if (this.DropDownListDataType.SelectedValue == "4")
		{
			this.PanelImg.Visible = false;
			this.PanelProduct.Visible = false;
			this.PanelFlash.Visible = true;
		}
	}
	protected void CheckBoxMore_CheckedChanged(object sender, EventArgs e)
	{
		if (this.CheckBoxMore.Checked)
		{
			this.PanelMore.Visible = true;
		}
		else
		{
			this.PanelMore.Visible = false;
		}
	}
	protected void BottonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ControlData_List.aspx?guid=" + this.HiddenFieldControlGuid.Value.Replace("'", ""));
	}
}
