using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_Link_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label lblLinkType;
	protected DropDownList DropListLinkType;
	protected Label Label1;
	protected Label lblTitle;
	protected TextBox textBoxTitle;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidatorT;
	protected Label lblLinkAddress;
	protected TextBox textBoxLinkAddress;
	protected Label Label3;
	protected Label Label11;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Label lblOrderID;
	protected TextBox textBoxOrderID;
	protected Label Label6;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Label lblIMGTYPE;
	protected RadioButtonList radioButtonImgType;
	protected Label lblImgAddress;
	protected TextBox textBoxImgAddress;
	protected Label Label10;
	protected RequiredFieldValidator RequiredFieldValidatorImgAddress;
	protected Panel Panelimage;
	protected HtmlImage ImageOriginalImge;
	protected RegularExpressionValidator RegularExpressionValidatorPackImagePath;
	protected Panel PanelPic;
	protected Label lblDescription;
	protected TextBox textBoxDescription;
	protected Label lblIsShow;
	protected CheckBox CheckBoxIsShow;
	protected Label lblRemark;
	protected TextBox textBoxMemo;
	protected Button BottonConfirm;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
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
		if (!this.Page.IsPostBack)
		{
			this.BindStatus();
			this.GetOrderID();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑友情链接";
				this.GetEditInfo();
			}
		}
	}
	protected void GetOrderID()
	{
		string columnName = "OrderID";
		string tableName = "ShopNum1_Link";
		this.textBoxOrderID.Text = Convert.ToString(1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
	}
	protected void Edit()
	{
		ShopNum1_Link shopNum1_Link = new ShopNum1_Link();
		shopNum1_Link.Guid = Guid.NewGuid();
		shopNum1_Link.Href = this.textBoxLinkAddress.Text.Trim();
		shopNum1_Link.ImgADD = this.textBoxImgAddress.Text.Trim();
		shopNum1_Link.Description = this.textBoxDescription.Text.Trim();
		if (Convert.ToInt32(this.DropListLinkType.SelectedValue) == 1)
		{
			shopNum1_Link.ImgADD = this.textBoxImgAddress.Text.Trim();
			shopNum1_Link.ImgType = this.radioButtonImgType.SelectedValue;
		}
		else
		{
			shopNum1_Link.ImgADD = string.Empty;
			shopNum1_Link.ImgType = string.Empty;
		}
		shopNum1_Link.Memo = this.textBoxMemo.Text.Trim();
		shopNum1_Link.Name = this.textBoxTitle.Text.Trim();
		shopNum1_Link.LinkType = Convert.ToInt32(this.DropListLinkType.SelectedValue);
		shopNum1_Link.ImgType = this.radioButtonImgType.SelectedValue;
		shopNum1_Link.OrderID = Convert.ToInt32(this.textBoxOrderID.Text.Trim());
		shopNum1_Link.CreateUser = "Admin";
		shopNum1_Link.ModifyUser = "Admin";
		shopNum1_Link.CreateTime = DateTime.Now;
		shopNum1_Link.ModifyTime = DateTime.Now;
		shopNum1_Link.IsDeleted = 0;
		if (this.CheckBoxIsShow.Checked)
		{
			shopNum1_Link.IsShow = 1;
		}
		else
		{
			shopNum1_Link.IsShow = 0;
		}
		ShopNum1_Link_Action shopNum1_Link_Action = (ShopNum1_Link_Action)LogicFactory.CreateShopNum1_Link_Action();
		int num = shopNum1_Link_Action.Update(this.hiddenFieldGuid.Value, shopNum1_Link);
		if (num > 0)
		{
			base.Response.Redirect("Link_Manage.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Add()
	{
		ShopNum1_Link shopNum1_Link = new ShopNum1_Link();
		shopNum1_Link.Guid = Guid.NewGuid();
		shopNum1_Link.Href = this.textBoxLinkAddress.Text.Trim();
		if (Convert.ToInt32(this.DropListLinkType.SelectedValue) == 1)
		{
			shopNum1_Link.ImgADD = this.textBoxImgAddress.Text.Trim();
			shopNum1_Link.ImgType = this.radioButtonImgType.SelectedValue;
		}
		else
		{
			shopNum1_Link.ImgADD = string.Empty;
			shopNum1_Link.ImgType = string.Empty;
		}
		shopNum1_Link.Description = this.textBoxDescription.Text.Trim();
		shopNum1_Link.Memo = this.textBoxMemo.Text.Trim();
		shopNum1_Link.Name = this.textBoxTitle.Text.Trim();
		shopNum1_Link.LinkType = Convert.ToInt32(this.DropListLinkType.SelectedValue);
		shopNum1_Link.CreateUser = "Admin";
		shopNum1_Link.ModifyUser = "Admin";
		shopNum1_Link.CreateTime = DateTime.Now;
		shopNum1_Link.ModifyTime = DateTime.Now;
		shopNum1_Link.IsDeleted = 0;
		shopNum1_Link.OrderID = Convert.ToInt32(this.textBoxOrderID.Text.Trim());
		shopNum1_Link.SubstationID = base.SubstationID;
		if (this.CheckBoxIsShow.Checked)
		{
			shopNum1_Link.IsShow = 1;
		}
		else
		{
			shopNum1_Link.IsShow = 0;
		}
		ShopNum1_Link_Action shopNum1_Link_Action = (ShopNum1_Link_Action)LogicFactory.CreateShopNum1_Link_Action();
		int num = shopNum1_Link_Action.Add(shopNum1_Link);
		if (num > 0)
		{
			this.GetOrderID();
			this.ClearControl();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void radioButtonIMGTYPE_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.radioButtonImgType.SelectedIndex == 0)
		{
			this.lblImgAddress.Text = "本地上传";
			this.Panelimage.Visible = true;
		}
		if (this.radioButtonImgType.SelectedIndex == 1)
		{
			this.lblImgAddress.Text = "远程链接";
			this.Panelimage.Visible = false;
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_Link_Action shopNum1_Link_Action = (ShopNum1_Link_Action)LogicFactory.CreateShopNum1_Link_Action();
		DataTable editInfo = shopNum1_Link_Action.GetEditInfo(this.hiddenFieldGuid.Value);
		this.textBoxTitle.Text = editInfo.Rows[0]["Name"].ToString();
		this.DropListLinkType.SelectedValue = editInfo.Rows[0]["LinkType"].ToString();
		if (this.DropListLinkType.SelectedValue == "0")
		{
			this.PanelPic.Visible = false;
		}
		this.textBoxLinkAddress.Text = editInfo.Rows[0]["Href"].ToString();
		this.radioButtonImgType.SelectedValue = editInfo.Rows[0]["ImgType"].ToString();
		this.textBoxImgAddress.Text = editInfo.Rows[0]["ImgADD"].ToString();
		this.textBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
		this.textBoxMemo.Text = editInfo.Rows[0]["Memo"].ToString();
		this.textBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
		this.ImageOriginalImge.Src = editInfo.Rows[0]["ImgADD"].ToString();
		this.BottonConfirm.Text = "更新";
		if (editInfo.Rows[0]["IsShow"].ToString() == "1")
		{
			this.CheckBoxIsShow.Checked = true;
		}
		else
		{
			this.CheckBoxIsShow.Checked = false;
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.Edit();
		}
		else
		{
			this.Add();
		}
	}
	protected void ClearControl()
	{
		this.DropListLinkType.SelectedValue = "0";
		this.textBoxTitle.Text = string.Empty;
		this.textBoxImgAddress.Text = string.Empty;
		this.textBoxLinkAddress.Text = string.Empty;
		this.textBoxMemo.Text = string.Empty;
		this.textBoxDescription.Text = string.Empty;
	}
	protected void BindStatus()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "图片链接";
		listItem.Value = "1";
		this.DropListLinkType.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "文字链接";
		listItem2.Value = "0";
		this.DropListLinkType.Items.Add(listItem2);
		this.DropListLinkType.SelectedValue = "1";
	}
	protected void DropListLinkType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (Convert.ToInt32(this.DropListLinkType.SelectedValue) == 0)
		{
			this.PanelPic.Visible = false;
		}
		else
		{
			this.PanelPic.Visible = true;
		}
	}
}
