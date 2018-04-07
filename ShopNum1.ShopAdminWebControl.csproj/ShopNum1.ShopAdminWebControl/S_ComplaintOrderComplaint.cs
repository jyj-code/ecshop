using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ComplaintOrderComplaint : BaseMemberWebControl
	{
		private string string_0 = "S_ComplaintOrderComplaint.ascx";
		private Repeater repeater_0;
		private Button button_0;
		private Button button_1;
		private TextBox textBox_0;
		private FileUpload fileUpload_0;
		private HtmlTableRow htmlTableRow_0;
		public S_ComplaintOrderComplaint()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.button_0 = (Button)skin.FindControl("ButtonSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxEvidence");
			this.fileUpload_0 = (FileUpload)skin.FindControl("FileUploadImage");
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("trResult");
			if (this.Page.Request.QueryString["id"] != null)
			{
				this.GetReport(this.Page.Request.QueryString["id"].ToString());
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_OrderComplaints.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textBox_0.Text.Trim()))
			{
				MessageBox.Show("证据不能为空");
			}
			else
			{
				string appealimage = string.Empty;
				if (this.fileUpload_0.HasFile)
				{
					string text = this.FileUpload(this.fileUpload_0, Guid.NewGuid().ToString());
					if (text != "0" && text != "1")
					{
						appealimage = text;
					}
				}
				ShopNum1_OrderComplaintsReplyList_Action shopNum1_OrderComplaintsReplyList_Action = (ShopNum1_OrderComplaintsReplyList_Action)LogicFactory.CreateShopNum1_OrderComplaintsReplyList_Action();
				int num = shopNum1_OrderComplaintsReplyList_Action.UpdateOrderComplainInfoByID(this.Page.Request.QueryString["id"].ToString(), appealimage, this.textBox_0.Text.Trim());
				if (num > 0)
				{
					MessageBox.Show("申诉成功！");
					this.GetReport(this.Page.Request.QueryString["id"].ToString());
				}
			}
		}
		protected string FileUpload(FileUpload ControlName, string ImageName)
		{
			string result;
			if (ControlName.HasFile)
			{
				string fileName = ControlName.PostedFile.FileName;
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
				result = "1";
			}
			return result;
		}
		public void GetReport(string string_1)
		{
			ShopNum1_OrderComplaintsReplyList_Action shopNum1_OrderComplaintsReplyList_Action = (ShopNum1_OrderComplaintsReplyList_Action)LogicFactory.CreateShopNum1_OrderComplaintsReplyList_Action();
			DataTable dataTable = shopNum1_OrderComplaintsReplyList_Action.SearchComplaint(string_1);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0]["IsAppeal"].ToString() == "1")
				{
					this.button_0.Visible = false;
					this.textBox_0.Enabled = false;
				}
				if (dataTable.Rows[0]["ProcessingStatus"].ToString() == "2")
				{
					this.button_0.Visible = false;
					this.htmlTableRow_0.Visible = true;
					this.textBox_0.Enabled = false;
				}
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
