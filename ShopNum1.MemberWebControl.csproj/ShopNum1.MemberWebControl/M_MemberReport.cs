using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_MemberReport : BaseMemberWebControl
	{
		private string string_0 = "M_MemberReport.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private DropDownList dropDownList_0;
		private TextBox textBox_2;
		private FileUpload fileUpload_0;
		private Button button_0;
		private Button button_1;
		public M_MemberReport()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxID");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxProductUrl");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListType");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxEvidence");
			this.fileUpload_0 = (FileUpload)skin.FindControl("FileUploadImage");
			this.button_0 = (Button)skin.FindControl("ButtonSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("M_MyReport.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textBox_0.Text.Trim()))
			{
				MessageBox.Show("举报商家的ID号不能为空！");
			}
			else if (string.IsNullOrEmpty(this.textBox_1.Text.Trim()))
			{
				MessageBox.Show("商品链接不能为空！");
			}
			else if (this.dropDownList_0.SelectedValue == "-1")
			{
				MessageBox.Show("举报类型必选！");
			}
			else if (string.IsNullOrEmpty(this.textBox_2.Text.Trim()))
			{
				MessageBox.Show("证据不能为空！");
			}
			else
			{
				ShopNum1_MemberReport_Action shopNum1_MemberReport_Action = (ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action();
				ShopNum1_MemberReport shopNum1_MemberReport = new ShopNum1_MemberReport();
				shopNum1_MemberReport.ProductUrl = this.textBox_1.Text.Trim();
				shopNum1_MemberReport.ReportType = this.dropDownList_0.SelectedValue;
				shopNum1_MemberReport.Evidence = this.textBox_2.Text.Trim();
				shopNum1_MemberReport.ReportTime = new DateTime?(DateTime.Now);
				shopNum1_MemberReport.MemLoginID = this.MemLoginID;
				shopNum1_MemberReport.ReportShop = this.textBox_0.Text.Trim();
				string evidenceImage = string.Empty;
				if (this.fileUpload_0.HasFile)
				{
					string text = this.FileUpload(this.fileUpload_0, Guid.NewGuid().ToString());
					if (!(text != "0") || !(text != "1") || !(text != "2"))
					{
						return;
					}
					evidenceImage = text;
				}
				shopNum1_MemberReport.EvidenceImage = evidenceImage;
				try
				{
					int num = shopNum1_MemberReport_Action.Add(shopNum1_MemberReport);
					if (num > 0)
					{
						this.textBox_1.Text = "";
						this.dropDownList_0.SelectedValue = "-1";
						this.textBox_2.Text = "";
						this.textBox_0.Text = "";
						MessageBox.Show("添加成功！");
					}
				}
				catch (Exception)
				{
					MessageBox.Show("操作错误");
				}
			}
		}
		protected string FileUpload(FileUpload ControlName, string ImageName)
		{
			string result;
			if (ControlName.HasFile)
			{
				string fileName = ControlName.PostedFile.FileName;
				string strExt = fileName.Substring(fileName.IndexOf('.'));
				string[] extArry = new string[]
				{
					".png",
					".gif",
					".bmp",
					".png",
					".jpg"
				};
				if (ImageUpload.CheckImgTypex(extArry, strExt))
				{
					FileInfo fileInfo = new FileInfo(fileName);
					string str = "~/ImgUpload/ShopCertification";
					string text = str + "/" + ImageName + fileInfo.Extension;
					string empty = string.Empty;
					if (ShopNum1UpLoad.ImageUpLoadWithName(ControlName, text, out empty))
					{
						result = text;
					}
					else
					{
						MessageBox.Show(empty);
						result = "0";
					}
				}
				else
				{
					MessageBox.Show("请上传png/jpg/pjpeg/x-png/jpeg类型图片！");
					result = "2";
				}
			}
			else
			{
				result = "1";
			}
			return result;
		}
	}
}
