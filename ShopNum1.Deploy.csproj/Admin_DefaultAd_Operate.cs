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
public class Admin_DefaultAd_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected TextBox TextBoxExplain;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxExplain;
	protected RegularExpressionValidator RegularExpressionValidatorDescription;
	protected DropDownList DropDownListPathType;
	protected TextBox TextBoxHref;
	protected TextBox TextBoxpath;
	protected FileUpload FileUploadpath;
	protected HtmlInputButton ButtonSelectSingleImage;
	protected TextBox TextBoxHeight;
	protected HtmlTableRow adheight;
	protected TextBox TextBoxWidth;
	protected HtmlTableRow adwidth;
	protected TextBox TextBoxLocation;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxLocation;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxLocation;
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
		if (!this.Page.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.LabelPageTitle.Text = "编辑幻灯片图片";
			this.GetEditInfo();
		}
	}
	protected void DropDownListPathType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListPathType.SelectedValue == "0")
		{
			this.TextBoxpath.Visible = true;
			this.FileUploadpath.Visible = false;
			this.ButtonSelectSingleImage.Visible = true;
		}
		else
		{
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
		base.Response.Redirect("DefaultAd_List.aspx");
	}
	public void Add()
	{
		DefaultAdImg defaultAdImg = new DefaultAdImg();
		defaultAdImg.Guid = Guid.NewGuid().ToString();
		defaultAdImg.title = this.TextBoxExplain.Text;
		defaultAdImg.Type = "1";
		defaultAdImg.Href = this.TextBoxHref.Text;
		defaultAdImg.Width = this.TextBoxWidth.Text;
		defaultAdImg.Height = this.TextBoxHeight.Text;
		defaultAdImg.orderID = this.TextBoxLocation.Text.Trim();
		if (this.DropDownListPathType.SelectedValue == "1")
		{
			string text = "";
			if (this.FileUpload(this.FileUploadpath, "~/ImgUpload/", out text))
			{
				defaultAdImg.imgsrc = this.TextBoxpath.Text;
			}
			else
			{
				defaultAdImg.imgsrc = this.TextBoxpath.Text;
			}
		}
		else
		{
			defaultAdImg.imgsrc = this.TextBoxpath.Text;
		}
		ShopNum1_DefaultAdImg_Action shopNum1_DefaultAdImg_Action = (ShopNum1_DefaultAdImg_Action)LogicFactory.CreateShopNum1_DefaultAdImg_Action();
		if (shopNum1_DefaultAdImg_Action.Add(defaultAdImg))
		{
			base.Response.Redirect("DefaultAd_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	public void Edit()
	{
		DefaultAdImg defaultAdImg = new DefaultAdImg();
		defaultAdImg.Guid = this.hiddenFieldGuid.Value;
		defaultAdImg.title = this.TextBoxExplain.Text;
		defaultAdImg.Type = "1";
		defaultAdImg.Href = this.TextBoxHref.Text;
		defaultAdImg.Width = this.TextBoxWidth.Text;
		defaultAdImg.Height = this.TextBoxHeight.Text;
		defaultAdImg.orderID = this.TextBoxLocation.Text.Trim();
		if (this.DropDownListPathType.SelectedValue == "1")
		{
			string imgsrc = "";
			if (this.FileUpload(this.FileUploadpath, "~/ImgUpload/", out imgsrc))
			{
				defaultAdImg.imgsrc = imgsrc;
			}
			else
			{
				defaultAdImg.imgsrc = imgsrc;
			}
		}
		else
		{
			defaultAdImg.imgsrc = this.TextBoxpath.Text;
		}
		ShopNum1_DefaultAdImg_Action shopNum1_DefaultAdImg_Action = (ShopNum1_DefaultAdImg_Action)LogicFactory.CreateShopNum1_DefaultAdImg_Action();
		if (shopNum1_DefaultAdImg_Action.Update(defaultAdImg))
		{
			base.Response.Redirect("DefaultAd_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	public void GetEditInfo()
	{
		ShopNum1_DefaultAdImg_Action shopNum1_DefaultAdImg_Action = (ShopNum1_DefaultAdImg_Action)LogicFactory.CreateShopNum1_DefaultAdImg_Action();
		DataRow dataRow = shopNum1_DefaultAdImg_Action.SelectByID(this.hiddenFieldGuid.Value).Rows[0];
		this.TextBoxExplain.Text = dataRow["title"].ToString();
		this.TextBoxHref.Text = dataRow["href"].ToString();
		this.TextBoxpath.Text = dataRow["imgsrc"].ToString();
		this.TextBoxHeight.Text = dataRow["height"].ToString();
		this.TextBoxWidth.Text = dataRow["width"].ToString();
		this.TextBoxLocation.Text = dataRow["orderID"].ToString();
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
				retstr = "~/ImgUpload/" + str4;
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
