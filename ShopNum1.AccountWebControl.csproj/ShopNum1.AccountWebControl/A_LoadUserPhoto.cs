using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ZoomImageDemo;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_LoadUserPhoto : BaseMemberWebControl
	{
		private string string_0 = "A_LoadUserPhoto.ascx";
		private Image image_0;
		private Image image_1;
		private Image image_2;
		private Button button_0;
		private FileUpload fileUpload_0;
		private Button button_1;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private TextBox textBox_6;
		private HiddenField hiddenField_0;
		private HtmlInputHidden htmlInputHidden_0;
		private string string_1 = string.Empty;
		public A_LoadUserPhoto()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.image_0 = (Image)skin.FindControl("imgphoto");
			this.image_1 = (Image)skin.FindControl("ImageDrag");
			this.image_2 = (Image)skin.FindControl("ImageIcon");
			this.button_0 = (Button)skin.FindControl("btnUpload");
			this.button_0.Click += new EventHandler(this.btnUpload_Click);
			this.fileUpload_0 = (FileUpload)skin.FindControl("fuPhoto");
			this.button_1 = (Button)skin.FindControl("btn_Image");
			this.button_1.Click += new EventHandler(this.btn_Image_Click);
			this.textBox_0 = (TextBox)skin.FindControl("txt_width");
			this.textBox_1 = (TextBox)skin.FindControl("txt_height");
			this.textBox_2 = (TextBox)skin.FindControl("txt_top");
			this.textBox_3 = (TextBox)skin.FindControl("txt_left");
			this.textBox_4 = (TextBox)skin.FindControl("txt_DropWidth");
			this.textBox_5 = (TextBox)skin.FindControl("txt_DropHeight");
			this.textBox_6 = (TextBox)skin.FindControl("txt_Zoom");
			this.hiddenField_0 = (HiddenField)skin.FindControl("hid_lefeValue");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_imgValue");
			this.string_1 = this.GetWebFilePath();
			if (!string.IsNullOrEmpty(this.Page.Request.QueryString["Picurl"]))
			{
				this.image_1.ImageUrl = this.Page.Request.QueryString["Picurl"];
				this.image_2.ImageUrl = this.Page.Request.QueryString["Picurl"];
				this.Page.ClientScript.RegisterStartupScript(typeof(A_LoadUserPhoto), "step2", "<script type='text/javascript'>Step2();</script>");
				this.htmlInputHidden_0.Value = this.image_1.ImageUrl;
			}
			else
			{
				this.Page.ClientScript.RegisterStartupScript(typeof(A_LoadUserPhoto), "step1", "<script type='text/javascript'>Step1();</script>");
			}
		}
		protected string GetWebFilePath()
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			shopNum1_Member_Action.SearchByMemLoginID(this.MemLoginID);
			DateTime.Now.ToString("yyyy-MM-dd");
			string text = "/ImgUpload/MemberImage/";
			if (!Directory.Exists(this.Page.Server.MapPath(text)))
			{
				Directory.CreateDirectory(this.Page.Server.MapPath(text));
			}
			return text;
		}
		protected void btnUpload_Click(object sender, EventArgs e)
		{
			if (this.fileUpload_0.PostedFile != null && this.fileUpload_0.PostedFile.ContentLength > 0)
			{
				string text = Path.GetExtension(this.fileUpload_0.PostedFile.FileName).ToLower();
				if (!(text != ".jpg") || !(text != ".jepg") || !(text != ".bmp") || !(text != ".gif") || !(text != ".png"))
				{
					string str = this.MemLoginID + DateTime.Now.ToString("yyyyMMddHHmmss") + text;
					string text2 = "/ImgUpload/MemberImage/" + str;
					this.fileUpload_0.PostedFile.SaveAs(this.Page.Server.MapPath(text2));
					this.Page.Response.Redirect("A_LoadUserPhoto.aspx?Picurl=" + this.Page.Server.UrlEncode(text2));
				}
			}
		}
		protected void btn_Image_Click(object sender, EventArgs e)
		{
			int imageWidth = int.Parse(this.textBox_0.Text);
			int imageHeight = int.Parse(this.textBox_1.Text);
			int pOrigStartPointY = int.Parse(this.textBox_2.Text);
			int pOrigStartPointX = int.Parse(this.textBox_3.Text);
			int pPartWidth = int.Parse(this.textBox_4.Text);
			int pPartHeight = int.Parse(this.textBox_5.Text);
			string str = CutPhotoHelp.SaveCutPic(this.Page.Server.MapPath(this.image_2.ImageUrl), this.Page.Server.MapPath(this.string_1), 0, 0, pPartWidth, pPartHeight, pOrigStartPointX, pOrigStartPointY, imageWidth, imageHeight);
			this.image_0.ImageUrl = this.string_1 + str;
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			string text = shopNum1_Member_Action.SearchByMemLoginID(this.MemLoginID).Rows[0]["Photo"].ToString();
			try
			{
				if (text != "")
				{
					File.Delete(this.Page.Server.MapPath(text));
				}
			}
			catch
			{
			}
			finally
			{
				shopNum1_Member_Action.UpdatePhoto(this.MemLoginID, this.string_1 + str);
				File.Delete(this.Page.Server.MapPath(this.htmlInputHidden_0.Value));
				this.Page.ClientScript.RegisterStartupScript(typeof(A_LoadUserPhoto), "setPic", "<script type='text/javascript'>setPic('" + this.image_0.ImageUrl + "');</script>");
			}
		}
	}
}
