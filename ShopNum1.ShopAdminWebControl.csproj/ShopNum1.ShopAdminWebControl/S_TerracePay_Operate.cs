using ShopNum1.AdXml;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_TerracePay_Operate : BaseShopWebControl
	{
		private string string_0 = "S_TerracePay_Operate.ascx";
		private DropDownList dropDownList_0;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private FileUpload fileUpload_0;
		private Image image_0;
		private Button button_0;
		private Button button_1;
		private Button button_2;
		private Label label_0;
		private Panel panel_0;
		private Panel panel_1;
		private FileUpload fileUpload_1;
		private FileUpload fileUpload_2;
		private FileUpload fileUpload_3;
		private HiddenField hiddenField_0;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private TextBox textBox_6;
		private TextBox textBox_7;
		private Panel panel_2;
		private HiddenField hiddenField_1;
		private Label label_1;
		private DefaultAdvertPayOperateNoPath defaultAdvertPayOperateNoPath_0 = new DefaultAdvertPayOperateNoPath();
		public S_TerracePay_Operate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListArea");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.dropDownList_0_SelectedIndexChanged);
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxName");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxLinkAdress");
			this.fileUpload_0 = (FileUpload)skin.FindControl("FileUploadImage");
			this.image_0 = (Image)skin.FindControl("ImageMap");
			this.button_0 = (Button)skin.FindControl("ButtonBuy");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBuyGo");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.button_2 = (Button)skin.FindControl("ButtonGoBack");
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.panel_0 = (Panel)skin.FindControl("PanelShowAd");
			this.panel_1 = (Panel)skin.FindControl("PanelShowMoreAd");
			this.fileUpload_1 = (FileUpload)skin.FindControl("FileUploadAD1");
			this.fileUpload_2 = (FileUpload)skin.FindControl("FileUploadAD2");
			this.fileUpload_3 = (FileUpload)skin.FindControl("FileUploadAD3");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxLinkAdress1");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxLinkAdress2");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxLinkAdress3");
			this.textBox_5 = (TextBox)skin.FindControl("TextBoxName1");
			this.textBox_6 = (TextBox)skin.FindControl("TextBoxName2");
			this.textBox_7 = (TextBox)skin.FindControl("TextBoxName3");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldType");
			this.label_0 = (Label)skin.FindControl("LabelShow");
			this.fileUpload_0 = (FileUpload)skin.FindControl("FileUploadImage");
			this.panel_2 = (Panel)skin.FindControl("PanelShowMsg");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldshowDay");
			this.label_1 = (Label)skin.FindControl("LabelOrderID");
			this.ReadXml();
		}
		private void dropDownList_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			string substationID = "all";
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_AdvertPay_Action();
				string teamOrderNew = shopNum1_AdvertPay_Action.GetTeamOrderNew(substationID, this.dropDownList_0.SelectedValue);
				if (teamOrderNew == "0")
				{
					this.label_1.Text = "目前还没有人申请该广告位呢！";
				}
				else
				{
					this.label_1.Text = "目前有" + teamOrderNew + "个广告在队列中！";
				}
				this.panel_2.Visible = true;
			}
			else
			{
				this.label_1.Text = "";
				this.label_0.Text = "";
				this.panel_2.Visible = false;
			}
			DataTable dataTable = this.defaultAdvertPayOperateNoPath_0.SelecByID(this.dropDownList_0.SelectedValue);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.label_0.Text = string.Concat(new string[]
				{
					"该广告位展示期限为",
					dataTable.Rows[0]["showDay"].ToString(),
					"天，展示价格为",
					dataTable.Rows[0]["money"].ToString(),
					"元，"
				});
				Label expr_161 = this.label_0;
				string text = expr_161.Text;
				expr_161.Text = string.Concat(new string[]
				{
					text,
					"建议图片宽度：",
					dataTable.Rows[0]["width"].ToString(),
					"px，高度为：",
					dataTable.Rows[0]["height"].ToString(),
					"px"
				});
				this.image_0.ImageUrl = dataTable.Rows[0]["Map"].ToString();
				this.hiddenField_1.Value = dataTable.Rows[0]["showDay"].ToString();
				if (dataTable.Rows[0]["type"].ToString() == "1")
				{
					this.panel_0.Visible = true;
					this.panel_1.Visible = false;
					this.hiddenField_0.Value = "1";
				}
				else if (dataTable.Rows[0]["type"].ToString() == "2")
				{
					this.panel_1.Visible = true;
					this.panel_0.Visible = false;
					this.hiddenField_0.Value = "2";
				}
			}
		}
		public void ReadXml()
		{
			this.defaultAdvertPayOperateNoPath_0.Path = "~/Main/Themes/Skin_Default/Xml/PayAdImage.xml";
			DataTable xmlDataTableNew = this.defaultAdvertPayOperateNoPath_0.GetXmlDataTableNew();
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-请选择-", "-1"));
			if (xmlDataTableNew != null && xmlDataTableNew.Rows.Count > 0)
			{
				foreach (DataRow dataRow in xmlDataTableNew.Rows)
				{
					this.dropDownList_0.Items.Add(new ListItem(dataRow["title"].ToString(), dataRow["id"].ToString()));
				}
			}
			this.dropDownList_0.SelectedValue = "-1";
			this.dropDownList_0_SelectedIndexChanged(null, null);
		}
		public void ReadXml(string SubstationID)
		{
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-请选择-", "-1"));
			this.defaultAdvertPayOperateNoPath_0.Path = "~/Main/Themes/Skin_Default/Xml/PayAdImage.xml";
			DataTable dataTable = null;
			try
			{
				dataTable = this.defaultAdvertPayOperateNoPath_0.GetXmlDataTableNew();
			}
			catch (Exception)
			{
				dataTable = null;
				this.label_0.Text = "";
				this.label_1.Text = "";
				MessageBox.Show("数据不存在，请重新选择城市分站");
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.dropDownList_0.Items.Add(new ListItem(dataRow["title"].ToString(), dataRow["id"].ToString()));
				}
			}
			this.dropDownList_0.SelectedValue = "-1";
			this.dropDownList_0_SelectedIndexChanged(null, null);
		}
		public string GetFenID()
		{
			string result = string.Empty;
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable substationByShopInfo = shopNum1_SubstationManage_Action.GetSubstationByShopInfo(this.MemLoginID);
			if (substationByShopInfo != null && substationByShopInfo.Rows.Count > 0)
			{
				result = substationByShopInfo.Rows[0]["SubstationID"].ToString();
			}
			else
			{
				result = "all";
			}
			return result;
		}
		public string GetFenCityCodeByFenID()
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(this.GetFenID());
			string result;
			if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
			{
				result = dataBySubstationID.Rows[0]["CityCode"].ToString();
			}
			else
			{
				result = "0";
			}
			return result;
		}
		private void button_2_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("TerracePay_List.aspx");
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_AdvertPay_Action();
			try
			{
				int num = Convert.ToInt32(shopNum1_AdvertPay_Action.GetTeamCount("all", this.dropDownList_0.SelectedValue, 2));
				if (num > 15)
				{
					MessageBox.Show("本广告位的预购数量已经超过15个，不能继续排队了！");
					return;
				}
			}
			catch (Exception)
			{
				return;
			}
			this.Add(2);
		}
		public void Add(int type)
		{
			if (this.dropDownList_0.SelectedValue == "-1")
			{
				MessageBox.Show("请选择一个广告位！");
			}
			else
			{
				decimal num = Convert.ToDecimal(this.GetXmlDataMoney(this.dropDownList_0.SelectedValue));
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
				decimal num2 = 0m;
				if (type == 1)
				{
					DataTable dataTable = shopNum1_Member_Action.SearchByMemLoginID(this.MemLoginID);
					if (dataTable != null && dataTable.Rows.Count > 0 && !string.IsNullOrEmpty(dataTable.Rows[0]["AdvancePayment"].ToString()))
					{
						num2 = Convert.ToDecimal(dataTable.Rows[0]["AdvancePayment"].ToString());
					}
					if (num > num2)
					{
						MessageBox.Show("您的预存款不足！");
						return;
					}
				}
				ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_AdvertPay_Action();
				ShopNum1_AdvertPay shopNum1_AdvertPay = new ShopNum1_AdvertPay();
				shopNum1_AdvertPay.AdId = new int?(Convert.ToInt32(this.dropDownList_0.SelectedValue));
				shopNum1_AdvertPay.AdType = new int?(Convert.ToInt32(this.GetXmlData(this.dropDownList_0.SelectedValue)));
				shopNum1_AdvertPay.ApplyState = new int?(type);
				shopNum1_AdvertPay.BeginDate = new DateTime?(Convert.ToDateTime("1900-1-1"));
				shopNum1_AdvertPay.CityCode = "0";
				shopNum1_AdvertPay.ClickTime = new int?(0);
				shopNum1_AdvertPay.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_AdvertPay.CreateUser = this.MemLoginID;
				shopNum1_AdvertPay.EndDate = new DateTime?(Convert.ToDateTime("1900-1-1"));
				shopNum1_AdvertPay.ExamineCase = "";
				Guid guid = Guid.NewGuid();
				shopNum1_AdvertPay.Guid = new Guid?(guid);
				string text = string.Empty;
				if (this.hiddenField_0.Value == "1")
				{
					if (!this.fileUpload_0.HasFile)
					{
						MessageBox.Show("上传的图片格式必须是jpg、gif、png、bmp的一种！");
						return;
					}
					string arg_216_0 = this.fileUpload_0.PostedFile.ContentType;
					string fileName = this.fileUpload_0.PostedFile.FileName;
					string text2 = fileName.Substring(fileName.LastIndexOf('.'));
					if (!(text2 == ".jpg") && !(text2 == ".gif") && !(text2 == ".png") && !(text2 == ".bmp"))
					{
						MessageBox.Show("上传的图片格式必须是jpg、gif、png、bmp的一种！");
						return;
					}
					string text3 = Guid.NewGuid().ToString();
					string filename = this.Page.Server.MapPath("~/ImgUpload/PayAd/" + text3 + text2);
					try
					{
						this.fileUpload_0.SaveAs(filename);
						text = "~/ImgUpload/PayAd/" + text3 + text2;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString());
					}
					shopNum1_AdvertPay.Website = this.textBox_1.Text.Trim();
					shopNum1_AdvertPay.Remarks = this.textBox_0.Text.Trim();
				}
				else if (this.hiddenField_0.Value == "2")
				{
					if (!this.fileUpload_1.HasFile)
					{
						MessageBox.Show("图片1请选择要上传的图片格式文件！");
						return;
					}
					string arg_36A_0 = this.fileUpload_1.PostedFile.ContentType;
					string fileName = this.fileUpload_1.PostedFile.FileName;
					string text2 = fileName.Substring(fileName.LastIndexOf('.'));
					string text3 = Guid.NewGuid().ToString();
					string filename = this.Page.Server.MapPath("~/ImgUpload/PayAd/" + text3 + text2);
					try
					{
						this.fileUpload_1.SaveAs(filename);
						text = text + "~/ImgUpload/PayAd/" + text3 + text2;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString());
					}
					shopNum1_AdvertPay.Website = this.textBox_2.Text.Trim();
					shopNum1_AdvertPay.Remarks = this.textBox_5.Text.Trim();
					if (!this.fileUpload_2.HasFile)
					{
						MessageBox.Show("请选择要上传的图片格式文件！");
						return;
					}
					string arg_442_0 = this.fileUpload_2.PostedFile.ContentType;
					fileName = this.fileUpload_2.PostedFile.FileName;
					text2 = fileName.Substring(fileName.LastIndexOf('.'));
					text3 = Guid.NewGuid().ToString();
					filename = this.Page.Server.MapPath("~/ImgUpload/PayAd/" + text3 + text2);
					try
					{
						this.fileUpload_2.SaveAs(filename);
						text = text + "|~/ImgUpload/PayAd/" + text3 + text2;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString());
					}
					shopNum1_AdvertPay.Website1 = this.textBox_3.Text.Trim();
					shopNum1_AdvertPay.Remarks1 = this.textBox_6.Text.Trim();
					if (!this.fileUpload_3.HasFile)
					{
						MessageBox.Show("请选择要上传的图片格式文件！");
						return;
					}
					string arg_51A_0 = this.fileUpload_3.PostedFile.ContentType;
					fileName = this.fileUpload_3.PostedFile.FileName;
					text2 = fileName.Substring(fileName.LastIndexOf('.'));
					text3 = Guid.NewGuid().ToString();
					filename = this.Page.Server.MapPath("~/ImgUpload/PayAd/" + text3 + text2);
					try
					{
						this.fileUpload_3.SaveAs(filename);
						text = text + "|~/ImgUpload/PayAd/" + text3 + text2;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString());
					}
					shopNum1_AdvertPay.Website2 = this.textBox_4.Text.Trim();
					shopNum1_AdvertPay.Remarks2 = this.textBox_7.Text.Trim();
				}
				shopNum1_AdvertPay.Image = text;
				shopNum1_AdvertPay.IsCancel = new int?(0);
				shopNum1_AdvertPay.IsDeleted = new int?(0);
				shopNum1_AdvertPay.IsExamine = new int?(0);
				shopNum1_AdvertPay.MemLoginID = this.MemLoginID;
				shopNum1_AdvertPay.ModifyTime = new DateTime?(DateTime.Now);
				shopNum1_AdvertPay.ModifyUser = this.MemLoginID;
				shopNum1_AdvertPay.PayMoney = new decimal?(num);
				shopNum1_AdvertPay.SubstationID = "all";
				int num3 = shopNum1_AdvertPay_Action.Add(shopNum1_AdvertPay);
				if (num3 > 0)
				{
					if (type == 1)
					{
						MessageBox.Show("申请成功！");
						if (num > 0m)
						{
							shopNum1_Member_Action.UpdateAdvancePayment(1, this.MemLoginID, num);
							ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
							shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
							shopNum1_AdvancePaymentModifyLog.OperateType = 3;
							shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num2;
							shopNum1_AdvancePaymentModifyLog.OperateMoney = num;
							shopNum1_AdvancePaymentModifyLog.LastOperateMoney = num2 - num;
							shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
							ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
							string text4 = "all";
							string text5 = "分站不存在或者已经被删除";
							if (text4 == "all")
							{
								text5 = "全国站";
							}
							else
							{
								DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(text4);
								if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
								{
									text5 = dataBySubstationID.Rows[0]["Name"].ToString();
								}
							}
							shopNum1_AdvancePaymentModifyLog.Memo = string.Concat(new object[]
							{
								"发布广告到城市平台[",
								text5,
								"]，消费￥",
								num
							});
							shopNum1_AdvancePaymentModifyLog.MemLoginID = this.MemLoginID;
							shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
							shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
							shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
							ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
							shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
						}
					}
					else if (type == 2)
					{
						MessageBox.Show("预定成功！");
					}
				}
				if (ShopSettings.GetValue("IsExamineAd") == "0")
				{
					this.ShenHe(guid);
				}
			}
		}
		public void ShenHe(Guid newGuid)
		{
			ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_AdvertPay_Action();
			int num = shopNum1_AdvertPay_Action.UpdateIsExamine("'" + newGuid.ToString() + "'", 1);
			if (num > 0)
			{
				string substationID = "all";
				string text = shopNum1_AdvertPay_Action.GetMaxDate(substationID, this.dropDownList_0.SelectedValue).Rows[0][0].ToString();
				try
				{
					if (Convert.ToDateTime(text) == Convert.ToDateTime("1900-1-1"))
					{
						shopNum1_AdvertPay_Action.UpdateEndDate("'" + newGuid.ToString() + "'", DateTime.Now.ToString(), DateTime.Now.AddDays(Convert.ToDouble(this.hiddenField_1.Value)).ToString());
					}
					else
					{
						shopNum1_AdvertPay_Action.UpdateEndDate("'" + newGuid.ToString() + "'", text, Convert.ToDateTime(text).AddDays(Convert.ToDouble(this.hiddenField_1.Value)).ToString());
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
		public string GetXmlData(string ID)
		{
			DataTable dataTable = this.defaultAdvertPayOperateNoPath_0.SelecByID(ID);
			string result;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				result = dataTable.Rows[0]["type"].ToString();
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		public string GetXmlDataMoney(string ID)
		{
			DataTable dataTable = this.defaultAdvertPayOperateNoPath_0.SelecByID(ID);
			string result;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				result = dataTable.Rows[0]["money"].ToString();
			}
			else
			{
				result = "0";
			}
			return result;
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Add(1);
		}
	}
}
