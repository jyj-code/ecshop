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
	public class M_MemberComplaints : BaseMemberWebControl
	{
		private string string_0 = "M_MemberComplaints.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private DropDownList dropDownList_0;
		private TextBox textBox_2;
		private FileUpload fileUpload_0;
		private Button button_0;
		private Button button_1;
		public M_MemberComplaints()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxID");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxOrderID");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListType");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxEvidence");
			this.fileUpload_0 = (FileUpload)skin.FindControl("FileUploadImage");
			this.button_0 = (Button)skin.FindControl("ButtonSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.method_0();
		}
		private void method_0()
		{
			string text = ShopNum1.Common.Common.ReqStr("shopid");
			if (text.IndexOf("|") != -1)
			{
				this.textBox_1.Text = text.Split(new char[]
				{
					'|'
				})[1];
				this.textBox_1.Enabled = false;
				this.textBox_0.Text = ShopNum1.Common.Common.GetNameById("shopid", "shopnum1_orderinfo", " and ordernumber='" + text.Split(new char[]
				{
					'|'
				})[1] + "'");
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("M_Complaints.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textBox_0.Text.Trim()))
			{
				MessageBox.Show("投诉商家的ID号不能为空！");
			}
			else if (string.IsNullOrEmpty(this.textBox_1.Text.Trim()))
			{
				MessageBox.Show("订单编号不能为空！");
			}
			else if (this.dropDownList_0.SelectedValue == "-1")
			{
				MessageBox.Show("投诉类型必选！");
			}
			else if (string.IsNullOrEmpty(this.textBox_2.Text.Trim()))
			{
				MessageBox.Show("投诉证据不能为空！");
			}
			else
			{
				ShopNum1_OrderComplaintsReplyList_Action shopNum1_OrderComplaintsReplyList_Action = (ShopNum1_OrderComplaintsReplyList_Action)LogicFactory.CreateShopNum1_OrderComplaintsReplyList_Action();
				ShopNum1_OrderComplaint shopNum1_OrderComplaint = new ShopNum1_OrderComplaint();
				shopNum1_OrderComplaint.ComplaintShop = this.textBox_0.Text.Trim();
				shopNum1_OrderComplaint.OrderID = this.textBox_1.Text.Trim();
				shopNum1_OrderComplaint.ComplaintType = this.dropDownList_0.SelectedValue;
				shopNum1_OrderComplaint.Evidence = this.textBox_2.Text.Trim();
				shopNum1_OrderComplaint.ComplaintTime = new DateTime?(DateTime.Now);
				shopNum1_OrderComplaint.MemLoginID = this.MemLoginID;
				shopNum1_OrderComplaint.ProcessingStatus = new int?(0);
				string evidenceImage = string.Empty;
				if (this.fileUpload_0.HasFile)
				{
					string text = this.FileUpload(this.fileUpload_0, Guid.NewGuid().ToString());
					if (!(text != "0") || !(text != "1"))
					{
						return;
					}
					evidenceImage = text;
				}
				shopNum1_OrderComplaint.EvidenceImage = evidenceImage;
				try
				{
					int num = shopNum1_OrderComplaintsReplyList_Action.Add(shopNum1_OrderComplaint);
					if (num > 0)
					{
						this.textBox_1.Text = "";
						this.dropDownList_0.SelectedValue = "-1";
						this.textBox_2.Text = "";
						this.textBox_0.Text = "";
						this.Page.Response.Redirect("M_Complaints.aspx");
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
	}
}
