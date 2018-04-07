using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopTemplate_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label Label1;
	protected FileUpload FileUploadShopTemplate;
	protected HtmlTableRow ShopTemplate;
	protected Label LabelShopTemplateImg;
	protected FileUpload FileUploadTemplateImg;
	protected Image ImageTemplate;
	protected HtmlAnchor ImageLink;
	protected HtmlTableRow ShopTemplateImg;
	protected Label LabelMeto;
	protected TextBox TextBoxMeto;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
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
		if (!base.IsPostBack)
		{
			this.CheckGuid.Value = ((this.Page.Request.QueryString["guid"] == "0") ? "0" : base.Request.QueryString["guid"]);
			if (this.CheckGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "修改店铺模板";
				this.method_5();
				this.ButtonConfirm.Text = "更新";
			}
		}
	}
	private void method_5()
	{
		ShopNum1_ShopTemplate_Action shopNum1_ShopTemplate_Action = (ShopNum1_ShopTemplate_Action)LogicFactory.CreateShopNum1_ShopTemplate_Action();
		DataTable dataTable = shopNum1_ShopTemplate_Action.Edit(this.CheckGuid.Value);
		this.TextBoxName.Text = dataTable.Rows[0]["name"].ToString();
		this.TextBoxMeto.Text = dataTable.Rows[0]["Meto"].ToString();
		this.ImageTemplate.ImageUrl = this.Page.ResolveUrl("/Template/ShopTemplate/" + dataTable.Rows[0]["TemplateImg"].ToString());
		this.ImageLink.HRef = this.Page.ResolveUrl("/Template/ShopTemplate/" + dataTable.Rows[0]["TemplateImg"].ToString());
		this.ViewState["shopTemName"] = dataTable.Rows[0]["Path"].ToString();
		this.ViewState["shopTemImg"] = dataTable.Rows[0]["TemplateImg"].ToString();
		this.ViewState["TextBoxName"] = dataTable.Rows[0]["name"].ToString();
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.CheckGuid.Value == "0")
		{
			if (this.CheckTemplateName(Operator.FilterString(this.TextBoxName.Text)))
			{
				string text = "ShopSkin" + DateTime.Now.ToString("yyyyMMddhhmmss");
				string text2 = this.method_6(text);
				if (!(text2 == "0"))
				{
					string text3 = text;
					string text4 = this.method_7(text3, "");
					if (!(text4 == "0"))
					{
						this.method_9(text2, text4);
					}
				}
			}
			else
			{
				MessageBox.Show("模板名重复！");
			}
		}
		else
		{
			string text = this.ViewState["shopTemName"].ToString();
			string text3 = this.ViewState["shopTemImg"].ToString();
			if (this.FileUploadShopTemplate.HasFile)
			{
				this.method_6(text.Split(new char[]
				{
					'.'
				})[0]);
			}
			if (this.FileUploadTemplateImg.HasFile)
			{
				text3 = this.method_7(text3.Split(new char[]
				{
					'.'
				})[0], text3);
			}
			this.method_8(text3);
		}
	}
	private string method_6(string string_5)
	{
		string result;
		if (this.FileUploadShopTemplate.HasFile)
		{
			string fileName = this.FileUploadShopTemplate.PostedFile.FileName;
			new FileInfo(fileName);
			string str = "~/Template/ShopTemplate/";
			string contentType = this.FileUploadShopTemplate.PostedFile.ContentType;
			if (contentType == "application/x-zip-compressed" || contentType == "application/zip" || contentType == "application/octet-stream")
			{
				try
				{
					if (File.Exists(this.Page.Server.MapPath(str + string_5 + ".zipzz")))
					{
						File.Delete(this.Page.Server.MapPath(str + string_5 + ".zipzz"));
					}
					this.FileUploadShopTemplate.PostedFile.SaveAs(base.Server.MapPath(str + string_5 + ".zipzz"));
					result = string_5 + ".zipzz";
					return result;
				}
				catch
				{
					MessageBox.Show("上传出错啦！");
					result = "0";
					return result;
				}
			}
			MessageBox.Show("文件格式不正确！");
			result = "0";
		}
		else
		{
			MessageBox.Show("请上传模板！");
			result = "0";
		}
		return result;
	}
	private string method_7(string string_5, string string_6)
	{
		string result;
		if (this.FileUploadTemplateImg.HasFile)
		{
			string fileName = this.FileUploadTemplateImg.PostedFile.FileName;
			FileInfo fileInfo = new FileInfo(fileName);
			string str = "/Template/ShopTemplate/";
			if (string_6 != "" && File.Exists(base.Server.MapPath(str + string_6)))
			{
				File.Delete(base.Server.MapPath(str + string_6));
			}
			string_5 += fileInfo.Extension;
			string arg_92_0 = this.FileUploadTemplateImg.PostedFile.ContentType;
			string empty = string.Empty;
			if (ShopNum1UpLoad.ImageType(this.FileUploadTemplateImg, out empty))
			{
				try
				{
					if (Directory.Exists(base.Server.MapPath(str + string_5)))
					{
						MessageBox.Show("此图片已存在！");
						result = "0";
						return result;
					}
					this.FileUploadTemplateImg.PostedFile.SaveAs(base.Server.MapPath(str + string_5));
					result = string_5;
					return result;
				}
				catch
				{
					MessageBox.Show("上传出错啦！");
					result = "0";
					return result;
				}
			}
			MessageBox.Show(empty);
			result = "0";
		}
		else
		{
			MessageBox.Show("请上传图片！");
			result = "0";
		}
		return result;
	}
	private void method_8(string string_5)
	{
		if (this.TextBoxName.Text != this.ViewState["TextBoxName"].ToString() && !this.CheckTemplateName(Operator.FilterString(this.TextBoxName.Text)))
		{
			MessageBox.Show("模板名重复！");
		}
		else
		{
			ShopNum1_Shop_Template shopNum1_Shop_Template = new ShopNum1_Shop_Template();
			shopNum1_Shop_Template.Name = this.TextBoxName.Text;
			shopNum1_Shop_Template.Money = new decimal?(0m);
			shopNum1_Shop_Template.Meto = this.TextBoxMeto.Text;
			shopNum1_Shop_Template.ValidDay = new int?(1000);
			shopNum1_Shop_Template.ModifyTime = DateTime.Now;
			shopNum1_Shop_Template.ModifyUser = "admin";
			shopNum1_Shop_Template.TemplateImg = string_5;
			shopNum1_Shop_Template.IsForbid = 0;
			shopNum1_Shop_Template.IsDefault = 1;
			shopNum1_Shop_Template.ID = int.Parse(this.CheckGuid.Value.Replace("'", "").ToString());
			ShopNum1_ShopTemplate_Action shopNum1_ShopTemplate_Action = (ShopNum1_ShopTemplate_Action)LogicFactory.CreateShopNum1_ShopTemplate_Action();
			int num = shopNum1_ShopTemplate_Action.Updata(shopNum1_Shop_Template);
			if (num > 0)
			{
				base.Response.Redirect("ShopTemplate_List.aspx");
			}
			else
			{
				this.MessageShow.ShowMessage("EditNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	private void method_9(string string_5, string string_6)
	{
		ShopNum1_Shop_Template shopNum1_Shop_Template = new ShopNum1_Shop_Template();
		shopNum1_Shop_Template.Name = this.TextBoxName.Text;
		shopNum1_Shop_Template.Money = new decimal?(0m);
		shopNum1_Shop_Template.Meto = this.TextBoxMeto.Text;
		shopNum1_Shop_Template.ValidDay = new int?(1000);
		shopNum1_Shop_Template.ModifyTime = DateTime.Now;
		shopNum1_Shop_Template.ModifyUser = "admin";
		shopNum1_Shop_Template.CreateTime = DateTime.Now;
		shopNum1_Shop_Template.CreateUser = "admin";
		shopNum1_Shop_Template.Path = string_5;
		shopNum1_Shop_Template.IsForbid = 0;
		shopNum1_Shop_Template.TemplateImg = string_6;
		shopNum1_Shop_Template.IsDefault = 1;
		ShopNum1_ShopTemplate_Action shopNum1_ShopTemplate_Action = (ShopNum1_ShopTemplate_Action)LogicFactory.CreateShopNum1_ShopTemplate_Action();
		int num = shopNum1_ShopTemplate_Action.Add(shopNum1_Shop_Template);
		if (num > 0)
		{
			this.method_10();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	private void method_10()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxMeto.Text = string.Empty;
	}
	public bool CheckTemplateName(string name)
	{
		ShopNum1_ShopTemplate_Action shopNum1_ShopTemplate_Action = (ShopNum1_ShopTemplate_Action)LogicFactory.CreateShopNum1_ShopTemplate_Action();
		int num = shopNum1_ShopTemplate_Action.CheckTemplateName(name);
		return num == 0;
	}
}
