using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopCouponEdit : BaseShopWebControl
	{
		private string string_0 = "S_ShopCouponEdit.ascx";
		private Label label_0;
		private Button button_0;
		private Button button_1;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private DropDownList dropDownList_0;
		private CheckBox checkBox_0;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private FileUpload fileUpload_0;
		private TextBox textBox_4;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private Image image_0;
		private Panel panel_0;
		public S_ShopCouponEdit()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelTitle");
			this.button_0 = (Button)skin.FindControl("ButtonSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxSaleTitle");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxCouponName");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListType");
			this.checkBox_0 = (CheckBox)skin.FindControl("CheckBoxIsShow");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxStartTime");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxEndTime");
			this.fileUpload_0 = (FileUpload)skin.FindControl("FileUploadImgPath");
			this.textBox_4 = (TextBox)skin.FindControl("TexteditorContent");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_Area");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hid_AreaCode");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hid_Image");
			this.panel_0 = (Panel)skin.FindControl("PanelShowImage");
			this.image_0 = (Image)skin.FindControl("InputImgPath");
			this.BindType();
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.label_0.Text = "编辑优惠券";
				this.GetDataInfo();
			}
			else
			{
				this.label_0.Text = "添加优惠券";
			}
		}
		public void GetDataInfo()
		{
			Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)LogicFactory.CreateShop_Coupon_Action();
			DataTable couponInfoById = shop_Coupon_Action.GetCouponInfoById(this.Page.Request.QueryString["guid"].ToString());
			if (couponInfoById != null && couponInfoById.Rows.Count > 0)
			{
				this.textBox_0.Text = couponInfoById.Rows[0]["SaleTitle"].ToString();
				this.textBox_1.Text = couponInfoById.Rows[0]["CouponName"].ToString();
				this.dropDownList_0.SelectedValue = couponInfoById.Rows[0]["Type"].ToString();
				if (couponInfoById.Rows[0]["IsShow"].ToString() == "1")
				{
					this.checkBox_0.Checked = true;
				}
				else
				{
					this.checkBox_0.Checked = false;
				}
				this.textBox_2.Text = couponInfoById.Rows[0]["StartTime"].ToString();
				this.textBox_3.Text = couponInfoById.Rows[0]["EndTime"].ToString();
				this.textBox_4.Text = couponInfoById.Rows[0]["Content"].ToString();
				this.panel_0.Visible = true;
				this.image_0.ImageUrl = couponInfoById.Rows[0]["ImgPath"].ToString();
				this.htmlInputHidden_2.Value = couponInfoById.Rows[0]["ImgPath"].ToString();
				this.htmlInputHidden_0.Value = couponInfoById.Rows[0]["AdressName"].ToString() + "|" + couponInfoById.Rows[0]["AdressCode"].ToString();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ShopCoupon.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.method_0();
			}
			else
			{
				this.method_1();
			}
		}
		private void method_0()
		{
			if (this.htmlInputHidden_0.Value.IndexOf('|') == -1)
			{
				MessageBox.Show("请选择地区");
			}
			else
			{
				Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)LogicFactory.CreateShop_Coupon_Action();
				ShopNum1_Shop_Coupon shopNum1_Shop_Coupon = new ShopNum1_Shop_Coupon();
				shopNum1_Shop_Coupon.AdressCode = this.htmlInputHidden_0.Value.Split(new char[]
				{
					'|'
				})[1].ToString();
				shopNum1_Shop_Coupon.AdressName = this.htmlInputHidden_0.Value.Split(new char[]
				{
					'|'
				})[0].ToString();
				shopNum1_Shop_Coupon.Content = this.textBox_4.Text;
				shopNum1_Shop_Coupon.CouponName = this.textBox_1.Text.Trim();
				shopNum1_Shop_Coupon.EndTime = Convert.ToDateTime(this.textBox_3.Text.Trim());
				shopNum1_Shop_Coupon.Guid = new Guid(this.Page.Request.QueryString["guid"].ToString());
				if (this.fileUpload_0.HasFile)
				{
					shopNum1_Shop_Coupon.ImgPath = this.FileUpload(this.fileUpload_0, Guid.NewGuid().ToString());
				}
				else
				{
					shopNum1_Shop_Coupon.ImgPath = this.htmlInputHidden_2.Value;
				}
				if (this.checkBox_0.Checked)
				{
					shopNum1_Shop_Coupon.IsShow = 1;
				}
				else
				{
					shopNum1_Shop_Coupon.IsShow = 0;
				}
				shopNum1_Shop_Coupon.ModifyTime = new DateTime?(DateTime.Now);
				shopNum1_Shop_Coupon.ModifyUser = this.MemLoginID;
				shopNum1_Shop_Coupon.SaleTitle = this.textBox_0.Text.Trim();
				shopNum1_Shop_Coupon.ShopName = this.ShopName(this.MemLoginID);
				shopNum1_Shop_Coupon.StartTime = Convert.ToDateTime(this.textBox_2.Text.Trim());
				shopNum1_Shop_Coupon.Type = Convert.ToInt32(this.dropDownList_0.SelectedValue);
				try
				{
					int num = shop_Coupon_Action.UpdateCoupon1(shopNum1_Shop_Coupon);
					if (num > 0)
					{
						MessageBox.Show("编辑成功！");
					}
					else
					{
						MessageBox.Show("编辑失败！");
					}
				}
				catch (Exception)
				{
					MessageBox.Show("编辑失败！");
				}
			}
		}
		private void method_1()
		{
			if (this.htmlInputHidden_0.Value.IndexOf('|') == -1)
			{
				MessageBox.Show("请选择地区");
			}
			else
			{
				string substationID = string.Empty;
				try
				{
					substationID = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + this.MemLoginID + "'   ");
				}
				catch (Exception)
				{
				}
				Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)LogicFactory.CreateShop_Coupon_Action();
				ShopNum1_Shop_Coupon shopNum1_Shop_Coupon = new ShopNum1_Shop_Coupon();
				shopNum1_Shop_Coupon.AdressCode = this.htmlInputHidden_0.Value.Split(new char[]
				{
					'|'
				})[1].ToString();
				shopNum1_Shop_Coupon.AdressName = this.htmlInputHidden_0.Value.Split(new char[]
				{
					'|'
				})[0].ToString();
				shopNum1_Shop_Coupon.BrowserCount = new int?(0);
				shopNum1_Shop_Coupon.Content = this.textBox_4.Text;
				shopNum1_Shop_Coupon.CouponName = this.textBox_1.Text.Trim();
				shopNum1_Shop_Coupon.CreateTime = DateTime.Now;
				shopNum1_Shop_Coupon.CreateUser = this.MemLoginID;
				shopNum1_Shop_Coupon.DownloadCount = new int?(0);
				shopNum1_Shop_Coupon.EndTime = Convert.ToDateTime(this.textBox_3.Text.Trim());
				shopNum1_Shop_Coupon.Guid = Guid.NewGuid();
				shopNum1_Shop_Coupon.ImgPath = this.FileUpload(this.fileUpload_0, Guid.NewGuid().ToString());
				shopNum1_Shop_Coupon.SubstationID = substationID;
				if (ShopSettings.GetValue("AddCouponIsAudit").ToString() == "1")
				{
					shopNum1_Shop_Coupon.IsAudit = 0;
				}
				else
				{
					shopNum1_Shop_Coupon.IsAudit = 1;
				}
				shopNum1_Shop_Coupon.IsDeleted = 0;
				shopNum1_Shop_Coupon.IsEffective = new int?(1);
				shopNum1_Shop_Coupon.IsHot = 0;
				shopNum1_Shop_Coupon.IsNew = 1;
				shopNum1_Shop_Coupon.IsRecommend = 0;
				if (this.checkBox_0.Checked)
				{
					shopNum1_Shop_Coupon.IsShow = 1;
				}
				else
				{
					shopNum1_Shop_Coupon.IsShow = 0;
				}
				shopNum1_Shop_Coupon.MemLoginID = this.MemLoginID;
				shopNum1_Shop_Coupon.ModifyTime = new DateTime?(DateTime.Now);
				shopNum1_Shop_Coupon.ModifyUser = this.MemLoginID;
				shopNum1_Shop_Coupon.SaleTitle = this.textBox_0.Text.Trim();
				shopNum1_Shop_Coupon.ShopName = this.ShopName(this.MemLoginID);
				shopNum1_Shop_Coupon.StartTime = Convert.ToDateTime(this.textBox_2.Text.Trim());
				shopNum1_Shop_Coupon.Type = Convert.ToInt32(this.dropDownList_0.SelectedValue);
				shopNum1_Shop_Coupon.UseCount = new int?(0);
				try
				{
					int num = shop_Coupon_Action.Add(shopNum1_Shop_Coupon);
					if (num > 0)
					{
						this.Page.Response.Redirect("S_ShopCoupon.aspx");
					}
					else
					{
						MessageBox.Show("添加失败！");
					}
				}
				catch (Exception)
				{
					MessageBox.Show("添加失败！");
				}
			}
		}
		public string ShopName(string memloginID)
		{
			string result = string.Empty;
			Shop_ShopLink_Action shop_ShopLink_Action = (Shop_ShopLink_Action)LogicFactory.CreateShop_ShopLink_Action();
			DataTable dataTable = shop_ShopLink_Action.CheckMemLoginID(memloginID);
			if (dataTable.Rows.Count > 0 && dataTable.Rows.Count < 2)
			{
				result = dataTable.Rows[0]["ShopName"].ToString();
			}
			return result;
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
		public void BindType()
		{
			Shop_CouponType_Action shop_CouponType_Action = (Shop_CouponType_Action)LogicFactory.CreateShop_CouponType_Action();
			DataTable dataTable = shop_CouponType_Action.search(-1, 1);
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-全部-", "-1"));
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.dropDownList_0.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["id"].ToString()));
			}
		}
	}
}
