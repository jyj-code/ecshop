using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class PageAdID_Operate : PageBase, IRequiresSessionState
{
	private ShopNum1_PageAdID_Action shopNum1_PageAdID_Action_0 = (ShopNum1_PageAdID_Action)LogicFactory.CreateShopNum1_PageAdID_Action();
	protected Label lbltitle;
	protected TextBox TextBoxPageName;
	protected RequiredFieldValidator RequiredFieldValidatorPageName;
	protected RegularExpressionValidator RegularExpressionValidatorDescription;
	protected DropDownList DropDownListFileName;
	protected Label Label2;
	protected CompareValidator CompareFatherCateGory;
	protected TextBox TextBoxAdID;
	protected TextBox TextBoxHeight;
	protected TextBox TextBoxWidth;
	protected TextBox TextBoxContent;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldADCount;
	protected HiddenField HiddenFieldADGuid;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"].Replace("'", ""));
		if (!this.Page.IsPostBack)
		{
			this.GetFileName();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.GetEditInfo();
				this.lbltitle.Text = "编辑自动广告位";
				this.ButtonConfirm.Text = "更新";
			}
			else
			{
				this.TextBoxAdID.Text = this.shopNum1_PageAdID_Action_0.GetNewDivID();
			}
		}
	}
	public void Add()
	{
		PageAdID pageAdID = new PageAdID();
		pageAdID.Guid = Guid.NewGuid().ToString();
		pageAdID.PageName = this.TextBoxPageName.Text;
		pageAdID.FileName = this.DropDownListFileName.SelectedItem.Text;
		pageAdID.Content = this.TextBoxContent.Text.Trim();
		pageAdID.DivID = this.TextBoxAdID.Text.Trim();
		pageAdID.Height = this.TextBoxHeight.Text.Trim();
		pageAdID.Width = this.TextBoxWidth.Text.Trim();
		int num = this.shopNum1_PageAdID_Action_0.Add(pageAdID);
		if (num > 0)
		{
			base.Response.Redirect("PageAdID_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	public void Edit()
	{
		PageAdID pageAdID = new PageAdID();
		pageAdID.Guid = this.hiddenFieldGuid.Value;
		pageAdID.PageName = this.TextBoxPageName.Text;
		pageAdID.FileName = this.DropDownListFileName.SelectedValue;
		pageAdID.Content = this.TextBoxContent.Text.Trim();
		pageAdID.Height = this.TextBoxHeight.Text.Trim();
		pageAdID.Width = this.TextBoxWidth.Text.Trim();
		int num = this.shopNum1_PageAdID_Action_0.Update(pageAdID);
		if (num > 0)
		{
			base.Response.Redirect("PageAdID_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	public void GetEditInfo()
	{
		ShopNum1_PageAdID_Action shopNum1_PageAdID_Action = (ShopNum1_PageAdID_Action)LogicFactory.CreateShopNum1_PageAdID_Action();
		DataRow dataRow = shopNum1_PageAdID_Action.SelectByID(this.hiddenFieldGuid.Value).Rows[0];
		this.TextBoxPageName.Text = dataRow["pagename"].ToString();
		this.DropDownListFileName.SelectedValue = dataRow["filename"].ToString();
		this.TextBoxAdID.Text = dataRow["divid"].ToString();
		this.TextBoxHeight.Text = dataRow["height"].ToString();
		this.TextBoxWidth.Text = dataRow["width"].ToString();
		this.TextBoxContent.Text = dataRow["content"].ToString();
	}
	public void GetFileName()
	{
		string[] files = Directory.GetFiles(base.Server.MapPath("~/Main/Themes/Skin_Default/"), "*.aspx");
		this.DropDownListFileName.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("Select");
		listItem.Value = "-1";
		this.DropDownListFileName.Items.Add(listItem);
		for (int i = 0; i < files.Length; i++)
		{
			this.DropDownListFileName.Items.Add(new ListItem
			{
				Text = files[i].Substring(files[i].LastIndexOf('\\') + 1),
				Value = files[i].Substring(files[i].LastIndexOf('\\') + 1)
			});
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
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PageAdID_List.aspx");
	}
}
