using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_AddSupply : BaseMemberWebControl
	{
		private string string_0 = "M_AddSupply.ascx";
		private TextBox textBox_0;
		private RadioButton radioButton_0;
		private RadioButton radioButton_1;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private TextBox textBox_6;
		private TextBox textBox_7;
		private FileUpload fileUpload_0;
		private TextBox textBox_8;
		private Button button_0;
		private Button button_1;
		private DropDownList dropDownList_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputHidden htmlInputHidden_3;
		private HtmlInputHidden htmlInputHidden_4;
		private Image image_0;
		private Panel panel_0;
		private Label label_0;
		public M_AddSupply()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxTitle");
			this.radioButton_0 = (RadioButton)skin.FindControl("RadioButtonGong");
			this.radioButton_1 = (RadioButton)skin.FindControl("RadioButtonQiu");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxKeywords");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxTel");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxEmail");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxOtherContactWay");
			this.textBox_5 = (TextBox)skin.FindControl("TextBoxContactName");
			this.textBox_6 = (TextBox)skin.FindControl("TextBoxValidTime");
			this.textBox_7 = (TextBox)skin.FindControl("TextBoxDescription");
			this.fileUpload_0 = (FileUpload)skin.FindControl("FileUploadImage");
			this.textBox_8 = (TextBox)skin.FindControl("TexteditorContent");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListSubstationID");
			this.button_1 = (Button)skin.FindControl("ButtonGoBack");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("HiddenFieldSupplyDemandCategory");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("HiddenFieldRegionCode");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("HiddenGuid");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("HiddenAddressCode");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("HiddenImage");
			this.image_0 = (Image)skin.FindControl("ImageGq");
			this.button_0 = (Button)skin.FindControl("ButtonTj");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.panel_0 = (Panel)skin.FindControl("PanelIsShow");
			this.label_0 = (Label)skin.FindControl("LabelTitle");
			this.GetSubstationID();
			if (this.Page.Request.QueryString["ID"] != null)
			{
				this.htmlInputHidden_2.Value = this.Page.Request.QueryString["ID"].ToString();
				this.GetInfo(this.Page.Request.QueryString["ID"].ToString());
				this.panel_0.Visible = true;
				this.label_0.Text = "编辑供求信息";
			}
			else
			{
				this.htmlInputHidden_2.Value = "0";
				this.label_0.Text = "发布供求信息";
			}
		}
		public void GetSubstationID()
		{
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("全国站", "all"));
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.dropDownList_0.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
				}
			}
		}
		public void GetInfo(string ID)
		{
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			DataTable dataTable = shopNum1_SupplyDemandCheck_Action.SearchByID(ID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.htmlInputHidden_2.Value = dataTable.Rows[0]["CategoryCode"].ToString();
				this.htmlInputHidden_3.Value = dataTable.Rows[0]["AddressCode"].ToString();
				this.textBox_0.Text = dataTable.Rows[0]["Title"].ToString();
				if (dataTable.Rows[0]["TradeType"].ToString() == "0")
				{
					this.radioButton_0.Checked = true;
				}
				else if (dataTable.Rows[0]["TradeType"].ToString() == "1")
				{
					this.radioButton_1.Checked = true;
				}
				this.textBox_2.Text = dataTable.Rows[0]["Tel"].ToString();
				this.textBox_3.Text = dataTable.Rows[0]["Email"].ToString();
				this.textBox_4.Text = dataTable.Rows[0]["OtherContactWay"].ToString();
				this.textBox_5.Text = dataTable.Rows[0]["ContactName"].ToString();
				this.textBox_6.Text = dataTable.Rows[0]["ValidTime"].ToString();
				this.textBox_1.Text = dataTable.Rows[0]["Keywords"].ToString();
				this.textBox_7.Text = dataTable.Rows[0]["Description"].ToString();
				this.textBox_8.Text = dataTable.Rows[0]["Content"].ToString();
				this.htmlInputHidden_4.Value = dataTable.Rows[0]["Image"].ToString();
				this.image_0.ImageUrl = dataTable.Rows[0]["Image"].ToString();
				this.dropDownList_0.SelectedValue = dataTable.Rows[0]["SubstationID"].ToString();
				this.dropDownList_0.Enabled = false;
				if (!(dataTable.Rows[0]["IsAudit"].ToString() == "2") && !(dataTable.Rows[0]["IsAudit"].ToString() == "3"))
				{
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.htmlInputHidden_2.Value == "0")
			{
				this.Add();
			}
			else
			{
				this.Edit(this.Page.Request.QueryString["ID"].ToString());
			}
		}
		public void Edit(string ID)
		{
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			ShopNum1_SupplyDemand shopNum1_SupplyDemand = new ShopNum1_SupplyDemand();
			shopNum1_SupplyDemand.AddressCode = this.htmlInputHidden_1.Value.Split(new char[]
			{
				'|'
			})[1].ToString();
			shopNum1_SupplyDemand.AddressValue = this.AreaChineseName(this.htmlInputHidden_1.Value);
			shopNum1_SupplyDemand.CategoryCode = this.htmlInputHidden_0.Value.Split(new char[]
			{
				'|'
			})[1].ToString();
			shopNum1_SupplyDemand.CategoryName = this.CategoryChineseName(this.htmlInputHidden_0.Value);
			shopNum1_SupplyDemand.ContactName = this.textBox_5.Text.Trim();
			shopNum1_SupplyDemand.Content = this.textBox_8.Text;
			shopNum1_SupplyDemand.Description = this.textBox_7.Text.Trim();
			shopNum1_SupplyDemand.Email = this.textBox_3.Text.Trim();
			shopNum1_SupplyDemand.ID = Convert.ToInt32(ID);
			if (this.fileUpload_0.HasFile)
			{
				string text = this.FileUpload(this.fileUpload_0, Guid.NewGuid().ToString());
				if (text != "1" && text != "0")
				{
					shopNum1_SupplyDemand.Image = text;
				}
				else
				{
					shopNum1_SupplyDemand.Image = this.htmlInputHidden_4.Value;
				}
			}
			else
			{
				shopNum1_SupplyDemand.Image = this.htmlInputHidden_4.Value;
			}
			shopNum1_SupplyDemand.Keywords = this.textBox_1.Text.Trim();
			shopNum1_SupplyDemand.OtherContactWay = this.textBox_4.Text.Trim();
			shopNum1_SupplyDemand.Tel = this.textBox_2.Text.Trim();
			shopNum1_SupplyDemand.Title = this.textBox_0.Text.Trim();
			if (this.radioButton_0.Checked)
			{
				shopNum1_SupplyDemand.TradeType = 0;
			}
			else if (this.radioButton_1.Checked)
			{
				shopNum1_SupplyDemand.TradeType = 1;
			}
			shopNum1_SupplyDemand.ValidTime = this.textBox_6.Text.Trim();
			try
			{
				int num = shopNum1_SupplyDemandCheck_Action.Update(shopNum1_SupplyDemand);
				if (num > 0)
				{
					this.Page.Response.Redirect("M_MySupply.aspx");
				}
				else
				{
					MessageBox.Show("编辑失败！");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("编辑失败！" + ex.Message);
			}
		}
		public int GetMaxOrderID()
		{
			int result = 0;
			string nameById = ShopNum1.Common.Common.GetNameById("MAX(OrderID)", "ShopNum1_SupplyDemand", "  AND  1=1  ");
			if (!string.IsNullOrEmpty(nameById))
			{
				result = Convert.ToInt32(nameById) + 1;
			}
			return result;
		}
		public void Add()
		{
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			ShopNum1_SupplyDemand shopNum1_SupplyDemand = new ShopNum1_SupplyDemand();
			shopNum1_SupplyDemand.AddressCode = this.htmlInputHidden_1.Value.Split(new char[]
			{
				'|'
			})[1].ToString();
			shopNum1_SupplyDemand.AddressValue = this.AreaChineseName(this.htmlInputHidden_1.Value);
			shopNum1_SupplyDemand.CategoryCode = this.htmlInputHidden_0.Value.Split(new char[]
			{
				'|'
			})[1].ToString();
			shopNum1_SupplyDemand.CategoryName = this.CategoryChineseName(this.htmlInputHidden_0.Value);
			shopNum1_SupplyDemand.ContactName = this.textBox_5.Text.Trim();
			shopNum1_SupplyDemand.Content = this.textBox_8.Text;
			shopNum1_SupplyDemand.Description = this.textBox_7.Text.Trim();
			shopNum1_SupplyDemand.Email = this.textBox_3.Text.Trim();
			shopNum1_SupplyDemand.SubstationID = this.dropDownList_0.SelectedValue;
			string text = this.FileUpload(this.fileUpload_0, Guid.NewGuid().ToString());
			if (text != "1" && text != "0")
			{
				shopNum1_SupplyDemand.Image = text;
			}
			else
			{
				shopNum1_SupplyDemand.Image = "";
			}
			if (ShopSettings.GetValue("SupplyDemandIsAudit") == "0")
			{
				shopNum1_SupplyDemand.IsAudit = 3;
			}
			else
			{
				shopNum1_SupplyDemand.IsAudit = 0;
			}
			shopNum1_SupplyDemand.IsRecommend = 0;
			shopNum1_SupplyDemand.Keywords = this.textBox_1.Text.Trim();
			shopNum1_SupplyDemand.MemberID = this.MemLoginID;
			shopNum1_SupplyDemand.OrderID = new int?(this.GetMaxOrderID());
			shopNum1_SupplyDemand.OtherContactWay = this.textBox_4.Text.Trim();
			shopNum1_SupplyDemand.ReleaseTime = DateTime.Now;
			shopNum1_SupplyDemand.Tel = this.textBox_2.Text.Trim();
			shopNum1_SupplyDemand.Title = this.textBox_0.Text.Trim();
			if (this.radioButton_0.Checked)
			{
				shopNum1_SupplyDemand.TradeType = 0;
			}
			else if (this.radioButton_1.Checked)
			{
				shopNum1_SupplyDemand.TradeType = 1;
			}
			shopNum1_SupplyDemand.ValidTime = this.textBox_6.Text.Trim();
			try
			{
				int num = shopNum1_SupplyDemandCheck_Action.Add(shopNum1_SupplyDemand);
				if (num > 0)
				{
					MessageBox.Show("供求信息发布成功！");
					this.Clear();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("供求信息发布失败！");
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("M_MySupply.aspx");
		}
		public string AreaChineseName(string strCode)
		{
			string text = string.Empty;
			if (strCode.IndexOf('|') != -1)
			{
				text = strCode.Split(new char[]
				{
					'|'
				})[1].ToString();
			}
			ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			string text5 = string.Empty;
			string text6 = string.Empty;
			string text7 = string.Empty;
			if (text.Length == 9)
			{
				text2 = text.Substring(0, 3);
				text3 = text.Substring(0, 6);
				text4 = text.Substring(0, 9);
			}
			else if (text.Length == 6)
			{
				text2 = text.Substring(0, 3);
				text3 = text.Substring(0, 6);
			}
			else if (text.Length == 3)
			{
				text2 = text.Substring(0, 3);
			}
			if (text2 != string.Empty)
			{
				DataTable regionByCode = shopNum1_Region_Action.GetRegionByCode(text2);
				if (regionByCode != null && regionByCode.Rows.Count > 0)
				{
					text5 = regionByCode.Rows[0]["Name"].ToString();
				}
			}
			if (text3 != string.Empty)
			{
				DataTable regionByCode2 = shopNum1_Region_Action.GetRegionByCode(text3);
				if (regionByCode2 != null && regionByCode2.Rows.Count > 0)
				{
					text6 = regionByCode2.Rows[0]["Name"].ToString();
				}
			}
			if (text4 != string.Empty)
			{
				DataTable regionByCode3 = shopNum1_Region_Action.GetRegionByCode(text4);
				if (regionByCode3 != null && regionByCode3.Rows.Count > 0)
				{
					text7 = regionByCode3.Rows[0]["Name"].ToString();
				}
			}
			string text8 = string.Empty;
			if (text5 != string.Empty)
			{
				if (text8 == string.Empty)
				{
					text8 = text5;
				}
				else
				{
					text8 = text8 + " " + text5;
				}
			}
			if (text6 != string.Empty)
			{
				if (text8 == string.Empty)
				{
					text8 += text6;
				}
				else
				{
					text8 = text8 + " " + text6;
				}
			}
			if (text7 != string.Empty)
			{
				if (text8 == string.Empty)
				{
					text8 += text7;
				}
				else
				{
					text8 = text8 + " " + text7;
				}
			}
			return text8;
		}
		public string CategoryChineseName(string strCode)
		{
			string text = string.Empty;
			if (strCode.IndexOf('|') > -1)
			{
				text = strCode.Split(new char[]
				{
					'|'
				})[1];
			}
			ShopNum1_SupplyDemandCategory_Action shopNum1_SupplyDemandCategory_Action = (ShopNum1_SupplyDemandCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			string text5 = string.Empty;
			string text6 = string.Empty;
			string text7 = string.Empty;
			if (text.Length == 9)
			{
				text2 = text.Substring(0, 3);
				text3 = text.Substring(0, 6);
				text4 = text.Substring(0, 9);
			}
			else if (text.Length == 6)
			{
				text2 = text.Substring(0, 3);
				text3 = text.Substring(0, 6);
			}
			else if (text.Length == 3)
			{
				text2 = text.Substring(0, 3);
			}
			if (text2 != string.Empty)
			{
				DataTable dataByCode = shopNum1_SupplyDemandCategory_Action.GetDataByCode(text2);
				if (dataByCode != null && dataByCode.Rows.Count > 0)
				{
					text5 = dataByCode.Rows[0]["Name"].ToString();
				}
			}
			if (text3 != string.Empty)
			{
				DataTable dataByCode2 = shopNum1_SupplyDemandCategory_Action.GetDataByCode(text3);
				if (dataByCode2 != null && dataByCode2.Rows.Count > 0)
				{
					text6 = dataByCode2.Rows[0]["Name"].ToString();
				}
			}
			if (text4 != string.Empty)
			{
				DataTable dataByCode3 = shopNum1_SupplyDemandCategory_Action.GetDataByCode(text4);
				if (dataByCode3 != null && dataByCode3.Rows.Count > 0)
				{
					text7 = dataByCode3.Rows[0]["Name"].ToString();
				}
			}
			string text8 = string.Empty;
			if (text5 != string.Empty)
			{
				if (text8 == string.Empty)
				{
					text8 = text5;
				}
				else
				{
					text8 = text8 + "/" + text5;
				}
			}
			if (text6 != string.Empty)
			{
				if (text8 == string.Empty)
				{
					text8 += text6;
				}
				else
				{
					text8 = text8 + "/" + text6;
				}
			}
			if (text7 != string.Empty)
			{
				if (text8 == string.Empty)
				{
					text8 += text7;
				}
				else
				{
					text8 = text8 + "/" + text7;
				}
			}
			return text8;
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
		public void Clear()
		{
			this.textBox_0.Text = "";
			this.textBox_1.Text = "";
			this.textBox_2.Text = "";
			this.textBox_3.Text = "";
			this.textBox_4.Text = "";
			this.textBox_5.Text = "";
			this.textBox_6.Text = "";
			this.textBox_7.Text = "";
			this.textBox_8.Text = "";
		}
	}
}
