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
public class Admin_Advertisement_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected TextBox TextBoxPageName;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxPageName;
	protected TextBox TextBoxFileName;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxFileName;
	protected TextBox TextBoxDivID;
	protected TextBox TextBoxExplain;
	protected DropDownList DropDownListAdType;
	protected DropDownList DropDownListPathType;
	protected TextBox TextBoxHref;
	protected TextBox TextBoxContent;
	protected TextBox TextBoxpath;
	protected FileUpload FileUploadpath;
	protected HtmlInputButton ButtonSelectSingleImage;
	protected TextBox TextBoxHeight;
	protected RegularExpressionValidator RegularExpressionHeight;
	protected HtmlTableRow adheight;
	protected TextBox TextBoxWidth;
	protected RegularExpressionValidator RegularExpressionWidth;
	protected HtmlTableRow adwidth;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
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
		if (!this.Page.IsPostBack)
		{
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑广告";
				this.GetEditInfo();
			}
			else
			{
				this.DropDownListAdType_SelectedIndexChanged(null, null);
			}
		}
	}
	protected void DropDownListAdType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListAdType.SelectedValue == "0")
		{
			this.TextBoxContent.Visible = true;
			this.TextBoxpath.Visible = false;
			this.FileUploadpath.Visible = false;
			this.adheight.Visible = false;
			this.adwidth.Visible = false;
			this.DropDownListPathType.Visible = false;
			this.ButtonSelectSingleImage.Visible = false;
		}
		else
		{
			this.adheight.Visible = true;
			this.adwidth.Visible = true;
			this.DropDownListPathType.Visible = true;
			this.ButtonSelectSingleImage.Visible = true;
			this.DropDownListPathType_SelectedIndexChanged(null, null);
		}
	}
	protected void DropDownListPathType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListPathType.SelectedValue == "0")
		{
			this.TextBoxContent.Visible = false;
			this.TextBoxpath.Visible = true;
			this.FileUploadpath.Visible = false;
			this.ButtonSelectSingleImage.Visible = true;
		}
		else
		{
			this.TextBoxContent.Visible = false;
			this.TextBoxpath.Visible = false;
			this.FileUploadpath.Visible = true;
			this.ButtonSelectSingleImage.Visible = false;
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
		base.Response.Redirect("Advertisement_List.aspx");
	}
	public void Add()
	{
		Advertisement advertisement = new Advertisement();
		advertisement.Guid = Guid.NewGuid().ToString();
		advertisement.Explain = this.TextBoxExplain.Text;
		advertisement.PageName = this.TextBoxPageName.Text;
		advertisement.FileName = this.TextBoxFileName.Text;
		advertisement.DivID = this.TextBoxDivID.Text;
		advertisement.Type = this.DropDownListAdType.SelectedValue;
		advertisement.Href = this.TextBoxHref.Text;
		if (advertisement.Type == "0")
		{
			advertisement.Width = "";
			advertisement.Height = "";
			advertisement.Content = this.TextBoxContent.Text;
		}
		else
		{
			advertisement.Width = this.TextBoxWidth.Text;
			advertisement.Height = this.TextBoxHeight.Text;
			if (this.DropDownListPathType.SelectedValue == "1")
			{
				string content = "";
				if (this.FileUpload(this.FileUploadpath, "../ImgUpload/", out content))
				{
					advertisement.Content = content;
				}
				else
				{
					advertisement.Content = "";
				}
			}
			else
			{
				advertisement.Content = this.TextBoxpath.Text;
			}
		}
		ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
		int num = shopNum1_Advertisement_Action.Add(advertisement);
		if (num > 0)
		{
			base.Response.Redirect("Advertisement_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	public void Edit()
	{
		Advertisement advertisement = new Advertisement();
		advertisement.Guid = this.hiddenFieldGuid.Value;
		advertisement.Explain = this.TextBoxExplain.Text;
		advertisement.PageName = this.TextBoxPageName.Text;
		advertisement.FileName = this.TextBoxFileName.Text;
		advertisement.DivID = this.TextBoxDivID.Text;
		advertisement.Type = this.DropDownListAdType.SelectedValue;
		advertisement.Href = this.TextBoxHref.Text;
		if (advertisement.Type == "0")
		{
			advertisement.Width = "";
			advertisement.Height = "";
			advertisement.Content = this.TextBoxContent.Text;
		}
		else
		{
			advertisement.Width = this.TextBoxWidth.Text;
			advertisement.Height = this.TextBoxHeight.Text;
			if (this.DropDownListPathType.SelectedValue == "1")
			{
				string content = "";
				if (this.FileUpload(this.FileUploadpath, "/ImgUpload/", out content))
				{
					advertisement.Content = content;
				}
				else
				{
					advertisement.Content = content;
				}
			}
			else
			{
				advertisement.Content = this.TextBoxpath.Text;
			}
		}
		ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
		int num = shopNum1_Advertisement_Action.Update(advertisement);
		if (num > 0)
		{
			base.Response.Redirect("Advertisement_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	public void GetEditInfo()
	{
		ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
		DataRow dataRow = shopNum1_Advertisement_Action.SelectByID(this.hiddenFieldGuid.Value).Rows[0];
		this.TextBoxPageName.Text = dataRow["pagename"].ToString();
		this.TextBoxFileName.Text = dataRow["filename"].ToString();
		this.TextBoxDivID.Text = dataRow["divid"].ToString();
		this.TextBoxExplain.Text = dataRow["explain"].ToString();
		this.DropDownListAdType.SelectedValue = dataRow["type"].ToString();
		this.DropDownListAdType_SelectedIndexChanged(null, null);
		this.TextBoxHref.Text = dataRow["href"].ToString();
		if (this.DropDownListAdType.SelectedValue == "0")
		{
			this.TextBoxContent.Text = dataRow["content"].ToString();
		}
		else
		{
			this.TextBoxpath.Text = dataRow["content"].ToString();
			this.TextBoxHeight.Text = dataRow["height"].ToString();
			this.TextBoxWidth.Text = dataRow["width"].ToString();
		}
	}
	protected bool FileUpload(FileUpload fileUpload, string filepath, out string retstr)
	{
		bool result;
		if (fileUpload.HasFile)
		{
			Random random = new Random();
			string fileName = fileUpload.PostedFile.FileName;
			string str = HttpContext.Current.Server.MapPath(filepath);
			string str2 = fileName.Substring(fileName.LastIndexOf(".") + 1);
			string arg_50_0 = fileUpload.PostedFile.ContentType;
			int contentLength = fileUpload.PostedFile.ContentLength;
			string str3 = DateTime.Now.ToString("yyyyMMddHHmmss");
			string str4 = str3 + random.Next(100, 999).ToString() + "." + str2;
			if (contentLength < 1024000)
			{
				fileUpload.PostedFile.SaveAs(str + str4);
				retstr = "ImgUpload/" + str4;
				result = true;
			}
			else
			{
				retstr = "文件不能大于1M！";
				result = false;
			}
		}
		else
		{
			retstr = "请选择文件！";
			result = false;
		}
		return result;
	}
}
