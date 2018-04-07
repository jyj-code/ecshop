using ShopNum1.AdXml;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_AdvertisementImg_Operate : PageBase, IRequiresSessionState
{
	private DefaultAdvertismentOperate defaultAdvertismentOperate_0 = new DefaultAdvertismentOperate();
	protected Label LabelPageTitle;
	protected TextBox TextBoxID;
	protected TextBox TextBoxPageName;
	protected TextBox TextBoxName;
	protected RequiredFieldValidator RequiredFieldValidatorFileName;
	protected TextBox TextBoxHref;
	protected TextBox TextBoxpath;
	protected HtmlImage imgshow;
	protected TextBox TextBoxWidth;
	protected RegularExpressionValidator RequiredFieldValidatorWidth;
	protected HtmlTableRow adwidth;
	protected TextBox TextBoxHeight;
	protected RegularExpressionValidator RegularExpressionValidatorHeight;
	protected HtmlTableRow adheight;
	protected TextBox TextBoxDes;
	protected HtmlTableRow Tr1;
	protected Button ButtonConfirm;
	protected MessageShow MessageShow;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"].Replace("'", ""));
		this.TextBoxID.Text = this.defaultAdvertismentOperate_0.GetMaxId().ToString();
		if (!this.Page.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.LabelPageTitle.Text = "编辑图片广告";
			this.GetEditInfo();
			this.ButtonConfirm.Text = "更新";
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
	public void Add()
	{
		string title = this.TextBoxName.Text.Trim();
		string href = this.TextBoxHref.Text.Trim();
		string imgsrc = this.TextBoxpath.Text.Trim();
		string height = this.TextBoxHeight.Text.Trim();
		string width = this.TextBoxWidth.Text.Trim();
		string pageName = this.TextBoxPageName.Text.Trim();
		string string_ = this.TextBoxDes.Text.Trim();
		int num = 0;
		try
		{
			num = this.defaultAdvertismentOperate_0.Add(title, imgsrc, href, width, height, pageName, string_);
		}
		catch (Exception)
		{
		}
		if (num > 0)
		{
			base.Response.Redirect("AdvertisementImg_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	public void Edit()
	{
		string string_ = this.hiddenFieldGuid.Value.Replace("'", "");
		string title = this.TextBoxName.Text.Trim();
		string linkUrl = this.TextBoxHref.Text.Trim();
		string imgsrc = this.TextBoxpath.Text.Trim();
		string height = this.TextBoxHeight.Text.Trim();
		string width = this.TextBoxWidth.Text.Trim();
		string pageName = this.TextBoxPageName.Text.Trim();
		string string_2 = this.TextBoxDes.Text.Trim();
		DefaultAdvertismentOperate defaultAdvertismentOperate = new DefaultAdvertismentOperate();
		int num = defaultAdvertismentOperate.Update(string_, title, imgsrc, linkUrl, height, width, pageName, string_2);
		if (num > 0)
		{
			base.Response.Redirect("AdvertisementImg_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	public void GetEditInfo()
	{
		DataRow dataRow = DefaultAdvertismentOperate.SelecByID(this.hiddenFieldGuid.Value.Replace("'", "")).Rows[0];
		this.TextBoxID.Text = this.hiddenFieldGuid.Value;
		this.TextBoxName.Text = dataRow["title"].ToString();
		this.TextBoxHeight.Text = dataRow["height"].ToString();
		this.TextBoxWidth.Text = dataRow["width"].ToString();
		this.TextBoxpath.Text = dataRow["imgsrc"].ToString();
		this.TextBoxHref.Text = dataRow["href"].ToString();
		this.TextBoxPageName.Text = dataRow["pagename"].ToString();
		this.TextBoxDes.Text = dataRow["des"].ToString();
		this.imgshow.Src = this.TextBoxpath.Text;
	}
}
