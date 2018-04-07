using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopOpenStep2 : BaseMemberWebControl
	{
		private string string_0 = "S_ShopOpenStep2.ascx";
		private RadioButton radioButton_0;
		private RadioButton radioButton_1;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private FileUpload fileUpload_0;
		private FileUpload fileUpload_1;
		private Button button_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private Panel panel_0;
		private HtmlInputHidden htmlInputHidden_3;
		private HtmlInputHidden htmlInputHidden_4;
		private HtmlInputHidden htmlInputHidden_5;
		private HtmlInputHidden htmlInputHidden_6;
		private HtmlInputHidden htmlInputHidden_7;
		private HtmlInputHidden htmlInputHidden_8;
		private HtmlInputHidden htmlInputHidden_9;
		private TextBox textBox_6;
		private DropDownList dropDownList_0;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private string string_5 = string.Empty;
		private string string_6 = string.Empty;
		private string string_7 = string.Empty;
		private string string_8 = string.Empty;
		public S_ShopOpenStep2()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("HiddenShopCategoryValue");
			this.radioButton_0 = (RadioButton)skin.FindControl("RadioButtonPersonal");
			this.radioButton_0.CheckedChanged += new EventHandler(this.radioButton_0_CheckedChanged);
			this.radioButton_1 = (RadioButton)skin.FindControl("RadioButtonBusiness");
			this.radioButton_1.CheckedChanged += new EventHandler(this.radioButton_1_CheckedChanged);
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxShopName");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxMainGoods");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxAddress");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxPostalCode");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxPhone");
			this.textBox_5 = (TextBox)skin.FindControl("TextBoxIdentityCard");
			this.fileUpload_1 = (FileUpload)skin.FindControl("FileUploadBusinessLicense");
			this.fileUpload_0 = (FileUpload)skin.FindControl("FileUploadIdentityCard");
			this.button_0 = (Button)skin.FindControl("ButtonOpen");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_Area");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("HiddenShopCategory");
			this.panel_0 = (Panel)skin.FindControl("PanelBusinessLicense");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("HiddenIdentityCardValue");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("HiddenBusinessImageValue");
			this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("HiddenIdEdit");
			this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("HiddenShopNameValue");
			this.htmlInputHidden_7 = (HtmlInputHidden)skin.FindControl("HiddenIdentityValue");
			this.htmlInputHidden_8 = (HtmlInputHidden)skin.FindControl("HiddenShopName");
			this.htmlInputHidden_9 = (HtmlInputHidden)skin.FindControl("HiddenIdentityCard");
			this.textBox_6 = (TextBox)skin.FindControl("TextBoxTel");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListSubstationID");
			this.GetShopC();
			this.GetSubstationIDData();
			if (this.Page.Request.QueryString["OptMsg"] != null && this.Page.Request.QueryString["OptMsg"].ToString() == "edit")
			{
				this.GetEditData();
				this.button_0.Text = "编辑信息";
			}
			else if (this.Page.Request.QueryString["OptMsg"] != null && this.Page.Request.QueryString["OptMsg"].ToString() == "reopen")
			{
				this.GetEditData();
				this.button_0.Text = "重新开店";
			}
			else if (this.Page.Request.QueryString["type"] != null)
			{
				this.button_0.Text = "立即开店";
			}
		}
		public void GetSubstationIDData()
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-请选择-", "-1"));
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.dropDownList_0.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
				}
			}
		}
		public void GetEditData()
		{
			this.GetShopC();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable shopByMemLoginID = shopNum1_ShopInfoList_Action.GetShopByMemLoginID(this.MemLoginID);
			if (shopByMemLoginID != null && shopByMemLoginID.Rows.Count > 0)
			{
				if (shopByMemLoginID.Rows[0]["ShopType"].ToString() == "0")
				{
					this.radioButton_0.Checked = true;
				}
				else if (shopByMemLoginID.Rows[0]["ShopType"].ToString() == "1")
				{
					this.radioButton_1.Checked = true;
					this.panel_0.Visible = true;
				}
				this.textBox_0.Text = shopByMemLoginID.Rows[0]["ShopName"].ToString();
				this.textBox_1.Text = shopByMemLoginID.Rows[0]["MainGoods"].ToString();
				this.textBox_2.Text = shopByMemLoginID.Rows[0]["Address"].ToString();
				this.textBox_3.Text = shopByMemLoginID.Rows[0]["PostalCode"].ToString();
				this.textBox_4.Text = shopByMemLoginID.Rows[0]["Phone"].ToString();
				this.textBox_5.Text = shopByMemLoginID.Rows[0]["IdentityCard"].ToString();
				this.htmlInputHidden_0.Value = shopByMemLoginID.Rows[0]["AddressValue"].ToString() + "|" + shopByMemLoginID.Rows[0]["AddressCode"].ToString();
				this.htmlInputHidden_1.Value = shopByMemLoginID.Rows[0]["ShopCategoryID"].ToString();
				this.textBox_6.Text = shopByMemLoginID.Rows[0]["Tel"].ToString();
				this.htmlInputHidden_3.Value = shopByMemLoginID.Rows[0]["CardImage"].ToString();
				this.htmlInputHidden_4.Value = shopByMemLoginID.Rows[0]["BusinessLicense"].ToString();
				this.htmlInputHidden_5.Value = "1";
				this.htmlInputHidden_6.Value = shopByMemLoginID.Rows[0]["ShopName"].ToString();
				this.htmlInputHidden_7.Value = shopByMemLoginID.Rows[0]["IdentityCard"].ToString();
				this.htmlInputHidden_8.Value = "ok";
				this.htmlInputHidden_9.Value = "ok";
				this.dropDownList_0.SelectedValue = shopByMemLoginID.Rows[0]["SubstationID"].ToString();
			}
		}
		public void GetShopC()
		{
		}
		public string GetShopCategory(string strCode)
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable byCode = shopNum1_ShopCategory_Action.GetByCode(strCode);
			string result;
			if (byCode != null && byCode.Rows.Count > 0)
			{
				result = byCode.Rows[0]["ID"].ToString() + "|" + byCode.Rows[0]["Code"].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}
		public string GetShopCategoryName(string strCode)
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable byCode = shopNum1_ShopCategory_Action.GetByCode(strCode);
			string result;
			if (byCode != null && byCode.Rows.Count > 0)
			{
				result = byCode.Rows[0]["Name"].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}
		private void radioButton_1_CheckedChanged(object sender, EventArgs e)
		{
			this.panel_0.Visible = true;
		}
		private void radioButton_0_CheckedChanged(object sender, EventArgs e)
		{
			this.panel_0.Visible = false;
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["OptMsg"] != null)
			{
				this.method_1();
			}
			else
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
			DataTable dataTable = shop_Rank_Action.Search("'" + this.Page.Request.QueryString["type"].ToString() + "'", 0);
			decimal num = 0m;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				num = Convert.ToDecimal(dataTable.Rows[0]["price"].ToString());
			}
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			DataTable advancePayment = shopNum1_Member_Action.GetAdvancePayment(this.MemLoginID);
			decimal num2 = 0m;
			if (advancePayment != null && advancePayment.Rows.Count > 0)
			{
				num2 = Convert.ToDecimal(advancePayment.Rows[0][0].ToString());
			}
			if (num > num2)
			{
				MessageBox.Show("预存款不足，请充值后在操作！");
			}
			else
			{
				ShopNum1_Member_Action shopNum1_Member_Action2 = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
				try
				{
					if (shopNum1_Member_Action2.GetMemTypeByMemberId(this.MemLoginID) == "2")
					{
						MessageBox.Show("此会员已经有店铺");
						return;
					}
				}
				catch
				{
				}
				ShopNum1_ShopInfo shopNum1_ShopInfo = new ShopNum1_ShopInfo();
				shopNum1_ShopInfo.IsIntegralShop = new int?(0);
				new Order();
				string cardImage = string.Empty;
				cardImage = this.htmlInputHidden_3.Value;
				if (this.radioButton_1.Checked)
				{
					Thread.Sleep(10);
					new Order();
				}
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
				Shop_Common_Action shop_Common_Action = (Shop_Common_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Common_Action();
				if (this.Page.Request.QueryString["type"].ToString() == "0" || this.Page.Request.QueryString["type"].ToString() == "")
				{
					shopNum1_ShopInfo.ShopRank = new Guid("f1219854-f68e-4da3-af7a-b67fd032f9f5");
				}
				else
				{
					shopNum1_ShopInfo.ShopRank = new Guid(this.Page.Request.QueryString["type"].ToString());
				}
				shopNum1_ShopInfo.ShopName = this.textBox_0.Text.Trim();
				if (this.htmlInputHidden_0.Value.IndexOf("|") != -1)
				{
					shopNum1_ShopInfo.AddressCode = this.htmlInputHidden_0.Value.Split(new char[]
					{
						'|'
					})[1].ToString();
					shopNum1_ShopInfo.SalesRange = this.htmlInputHidden_0.Value.Split(new char[]
					{
						'|'
					})[0].ToString().Replace(",", "");
					shopNum1_ShopInfo.AddressValue = this.htmlInputHidden_0.Value.Split(new char[]
					{
						'|'
					})[0].ToString();
				}
				else
				{
					shopNum1_ShopInfo.AddressCode = "0";
					shopNum1_ShopInfo.SalesRange = "0";
					shopNum1_ShopInfo.AddressValue = "";
				}
				shopNum1_ShopInfo.Banner = "~/Shop/ShopAdmin/images/logodfwe.jpg";
				shopNum1_ShopInfo.CollectCount = 0;
				shopNum1_ShopInfo.ApplyTime = new DateTime?(DateTime.Now);
				shopNum1_ShopInfo.OpenTime = new DateTime?(DateTime.Now);
				shopNum1_ShopInfo.ModifyUser = this.MemLoginID;
				shopNum1_ShopInfo.ModifyTime = new DateTime?(DateTime.Now);
				if (this.htmlInputHidden_2.Value.IndexOf("|") != -1)
				{
					shopNum1_ShopInfo.ShopCategory = this.htmlInputHidden_2.Value.Split(new char[]
					{
						'|'
					})[1].ToString();
					shopNum1_ShopInfo.ShopCategoryID = this.htmlInputHidden_2.Value.Split(new char[]
					{
						'|'
					})[1].ToString();
				}
				else
				{
					shopNum1_ShopInfo.ShopCategory = "0";
					shopNum1_ShopInfo.ShopCategoryID = "0";
				}
				shopNum1_ShopInfo.OrderID = new int?(shop_Common_Action.ReturnMaxID("OrderID", "ShopNum1_ShopInfo") + 1);
				shopNum1_ShopInfo.MemLoginID = this.MemLoginID;
				shopNum1_ShopInfo.CompanIsAudit = -1;
				shopNum1_ShopInfo.IdentityIsAudit = -1;
				shopNum1_ShopInfo.IsAudit = 0;
				shopNum1_ShopInfo.IsDeleted = new int?(0);
				shopNum1_ShopInfo.Name = this.MemLoginID;
				shopNum1_ShopInfo.IdentityCard = this.textBox_5.Text;
				shopNum1_ShopInfo.Address = this.textBox_2.Text;
				shopNum1_ShopInfo.MainGoods = this.textBox_1.Text.Trim();
				shopNum1_ShopInfo.PostalCode = this.textBox_3.Text.Trim();
				shopNum1_ShopInfo.Tel = this.textBox_6.Text.Trim();
				shopNum1_ShopInfo.CardImage = cardImage;
				DataTable defaultTemplate = shop_Rank_Action.GetDefaultTemplate();
				string templateType = string.Empty;
				if (defaultTemplate != null && defaultTemplate.Rows.Count > 0)
				{
					templateType = defaultTemplate.Rows[0]["Path"].ToString();
				}
				shopNum1_ShopInfo.TemplateType = templateType;
				shopNum1_ShopInfo.RegistrationNum = "";
				shopNum1_ShopInfo.CompanName = "";
				shopNum1_ShopInfo.LegalPerson = "";
				shopNum1_ShopInfo.RegisteredCapital = 0m;
				shopNum1_ShopInfo.BusinessTerm = "";
				shopNum1_ShopInfo.BusinessScope = "";
				shopNum1_ShopInfo.BusinessLicense = this.htmlInputHidden_4.Value;
				shopNum1_ShopInfo.Phone = this.textBox_4.Text.Trim();
				shopNum1_ShopInfo.Longitude = "116.40391";
				shopNum1_ShopInfo.Latitude = "39.914861";
				shopNum1_ShopInfo.SubstationID = this.dropDownList_0.SelectedValue;
				if (this.radioButton_0.Checked)
				{
					shopNum1_ShopInfo.ShopType = new int?(0);
				}
				else if (this.radioButton_1.Checked)
				{
					shopNum1_ShopInfo.ShopType = new int?(1);
				}
				else
				{
					shopNum1_ShopInfo.ShopType = new int?(0);
				}
				try
				{
					shopNum1_ShopInfo.ShopID = int.Parse(ShopSettings.GetValue("InitialShopID"));
				}
				catch
				{
					shopNum1_ShopInfo.ShopID = 10000;
				}
				int shopIdMax = shopNum1_ShopInfoList_Action.GetShopIdMax();
				if (shopIdMax >= shopNum1_ShopInfo.ShopID)
				{
					shopNum1_ShopInfo.ShopID = shopIdMax + 1;
				}
				shopNum1_ShopInfo.ShopUrl = ShopSettings.GetValue("PersonShopUrl") + shopNum1_ShopInfo.ShopID.ToString();
				int num3 = 0;
				try
				{
					shopNum1_ShopInfo.Guid = Guid.NewGuid();
					num3 = shopNum1_ShopInfoList_Action.RegistShopMember(shopNum1_ShopInfo);
				}
				catch (Exception ex)
				{
					this.Page.Response.Write("|" + ex.Message);
				}
				if (num3 > 0)
				{
					try
					{
						if (ShopSettings.GetValue("ApplyOpenShopIsEmail") == "1")
						{
							this.IsEmail();
						}
						if (ShopSettings.GetValue("ApplyOpenShopIsMMS") == "1")
						{
							string text = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member", " and MemLoginID='" + this.MemLoginID + "'");
							if (string.IsNullOrEmpty(text))
							{
								text = this.textBox_4.Text;
							}
							this.IsMMS(shopNum1_ShopInfo.ShopID.ToString(), text);
						}
					}
					catch (Exception ex)
					{
						this.Page.Response.Write(ex.Message);
					}
					if (num > 0m)
					{
						try
						{
							shopNum1_Member_Action2.UpdateAdvancePayment(1, this.MemLoginID, num);
							ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
							shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
							shopNum1_AdvancePaymentModifyLog.OperateType = 3;
							shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num2;
							shopNum1_AdvancePaymentModifyLog.OperateMoney = num;
							shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(num2) - num;
							shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
							shopNum1_AdvancePaymentModifyLog.Memo = "开店铺扣除预存款￥" + num;
							shopNum1_AdvancePaymentModifyLog.MemLoginID = this.MemLoginID;
							shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
							shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
							shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
							ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
							shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
						}
						catch (Exception ex)
						{
						}
					}
					DataTable dataTable2 = shop_Rank_Action.Search("'" + this.Page.Request.QueryString["type"].ToString() + "'", 0);
					int num4 = 0;
					string rankName = string.Empty;
					if (dataTable2 != null && dataTable2.Rows.Count > 0)
					{
						num4 = Convert.ToInt32(dataTable2.Rows[0]["IsDefault"].ToString());
						rankName = dataTable2.Rows[0]["Name"].ToString();
					}
					if (num4 == 1)
					{
						Shop_ShopApplyRank_Action shop_ShopApplyRank_Action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
						try
						{
							shop_ShopApplyRank_Action.DeleteOutRankGuid(this.Page.Request.QueryString["type"].ToString(), this.MemLoginID);
						}
						catch (Exception ex)
						{
						}
						ShopNum1_Shop_ApplyShopRank shopNum1_Shop_ApplyShopRank = new ShopNum1_Shop_ApplyShopRank();
						shopNum1_Shop_ApplyShopRank.ApplyTime = new DateTime?(DateTime.Now);
						shopNum1_Shop_ApplyShopRank.IsAudit = 1;
						shopNum1_Shop_ApplyShopRank.MemberLoginID = this.MemLoginID;
						shopNum1_Shop_ApplyShopRank.IsPayMent = 1;
						shopNum1_Shop_ApplyShopRank.PaymentName = "预存款支付";
						shopNum1_Shop_ApplyShopRank.PaymentType = new Guid("385c9c54-2b58-4b65-8ea9-f01872126715");
						shopNum1_Shop_ApplyShopRank.RankGuid = new Guid(this.Page.Request.QueryString["type"].ToString());
						shopNum1_Shop_ApplyShopRank.VerifyTime = new DateTime?(DateTime.Now.ToLocalTime().AddYears(1));
						shopNum1_Shop_ApplyShopRank.RankName = rankName;
						try
						{
							shop_ShopApplyRank_Action.Add(shopNum1_Shop_ApplyShopRank);
						}
						catch (Exception ex)
						{
							MessageBox.Show("等级记录失败！");
						}
					}
					this.Page.Response.Redirect("S_ShopOpenStep3.aspx");
				}
				else
				{
					MessageBox.Show("提交失败!");
				}
			}
		}
		private void method_1()
		{
			Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
			decimal num = 0m;
			decimal num2 = 0m;
			if (this.Page.Request.QueryString["OptMsg"] != null && this.Page.Request.QueryString["OptMsg"].ToString() == "reopen" && this.button_0.Text == "重新开店")
			{
				string nameById = ShopNum1.Common.Common.GetNameById("ShopRank", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + this.MemLoginID + "'  ");
				if (string.IsNullOrEmpty(nameById))
				{
					MessageBox.Show("店铺信息错误");
					return;
				}
				DataTable dataTable = shop_Rank_Action.Search("'" + nameById + "'", 0);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					num = Convert.ToDecimal(dataTable.Rows[0]["price"].ToString());
				}
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
				DataTable advancePayment = shopNum1_Member_Action.GetAdvancePayment(this.MemLoginID);
				if (advancePayment != null && advancePayment.Rows.Count > 0)
				{
					num2 = Convert.ToDecimal(advancePayment.Rows[0][0].ToString());
				}
				if (num > num2)
				{
					MessageBox.Show("预存款不足，请充值后在操作！");
					return;
				}
			}
			ShopNum1_ShopInfo shopNum1_ShopInfo = new ShopNum1_ShopInfo();
			shopNum1_ShopInfo.AddressCode = this.htmlInputHidden_0.Value.Split(new char[]
			{
				'|'
			})[1].ToString();
			try
			{
				if (this.htmlInputHidden_2.Value.Split(new char[]
				{
					'|'
				}).Length > 0)
				{
					shopNum1_ShopInfo.ShopCategoryID = this.htmlInputHidden_2.Value.Split(new char[]
					{
						'|'
					})[1].ToString();
				}
				else
				{
					shopNum1_ShopInfo.ShopCategoryID = this.htmlInputHidden_2.Value;
				}
			}
			catch (Exception)
			{
				shopNum1_ShopInfo.ShopCategoryID = this.htmlInputHidden_2.Value;
			}
			new Order();
			string cardImage = string.Empty;
			cardImage = this.htmlInputHidden_3.Value;
			string businessLicense = "";
			if (this.radioButton_1.Checked)
			{
				Thread.Sleep(10);
				new Order();
				businessLicense = this.htmlInputHidden_4.Value;
			}
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			Shop_Common_Action arg_29E_0 = (Shop_Common_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Common_Action();
			shopNum1_ShopInfo.SubstationID = this.dropDownList_0.SelectedValue;
			shopNum1_ShopInfo.ShopName = this.textBox_0.Text.Trim();
			shopNum1_ShopInfo.SalesRange = this.htmlInputHidden_0.Value.Split(new char[]
			{
				'|'
			})[0].ToString().Replace(",", "");
			shopNum1_ShopInfo.AddressValue = this.htmlInputHidden_0.Value.Split(new char[]
			{
				'|'
			})[0].ToString();
			shopNum1_ShopInfo.ModifyUser = this.MemLoginID;
			shopNum1_ShopInfo.ModifyTime = new DateTime?(DateTime.Now);
			try
			{
				if (this.htmlInputHidden_2.Value.Split(new char[]
				{
					'|'
				}).Length > 0)
				{
					shopNum1_ShopInfo.ShopCategory = this.htmlInputHidden_2.Value.Split(new char[]
					{
						'|'
					})[1].ToString();
				}
				else
				{
					shopNum1_ShopInfo.ShopCategory = this.htmlInputHidden_2.Value;
				}
			}
			catch (Exception)
			{
				shopNum1_ShopInfo.ShopCategory = this.htmlInputHidden_2.Value;
			}
			shopNum1_ShopInfo.IdentityCard = this.textBox_5.Text;
			shopNum1_ShopInfo.Address = this.textBox_2.Text;
			shopNum1_ShopInfo.MainGoods = this.textBox_1.Text.Trim();
			shopNum1_ShopInfo.PostalCode = this.textBox_3.Text.Trim();
			shopNum1_ShopInfo.CardImage = cardImage;
			DataTable defaultTemplate = shop_Rank_Action.GetDefaultTemplate();
			string templateType = string.Empty;
			if (defaultTemplate != null && defaultTemplate.Rows.Count > 0)
			{
				templateType = defaultTemplate.Rows[0]["Path"].ToString();
			}
			shopNum1_ShopInfo.TemplateType = templateType;
			shopNum1_ShopInfo.BusinessLicense = businessLicense;
			shopNum1_ShopInfo.Phone = this.textBox_4.Text.Trim();
			shopNum1_ShopInfo.Tel = this.textBox_6.Text.Trim();
			if (this.radioButton_0.Checked)
			{
				shopNum1_ShopInfo.ShopType = new int?(0);
			}
			else if (this.radioButton_1.Checked)
			{
				shopNum1_ShopInfo.ShopType = new int?(1);
			}
			else
			{
				shopNum1_ShopInfo.ShopType = new int?(0);
			}
			try
			{
				int num3 = shopNum1_ShopInfoList_Action.UpdateShop(this.MemLoginID, shopNum1_ShopInfo);
				if (num3 > 0)
				{
					if (this.Page.Request.QueryString["OptMsg"] != null && this.Page.Request.QueryString["OptMsg"].ToString() == "reopen" && this.button_0.Text == "重新开店" && num > 0m)
					{
						try
						{
							ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
							shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
							shopNum1_AdvancePaymentModifyLog.OperateType = 3;
							shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num2;
							shopNum1_AdvancePaymentModifyLog.OperateMoney = num;
							shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(num2) - num;
							shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
							shopNum1_AdvancePaymentModifyLog.Memo = "重新开店扣除预存款￥" + num;
							shopNum1_AdvancePaymentModifyLog.MemLoginID = this.MemLoginID;
							shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
							shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
							shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
							ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
							shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
						}
						catch (Exception)
						{
						}
					}
					this.Page.Response.Redirect("S_ShopOpenStep3.aspx");
				}
				else
				{
					MessageBox.Show("修改失败！");
				}
			}
			catch (Exception)
			{
				MessageBox.Show("修改失败！");
			}
		}
		protected string FileUpload(FileUpload ControlName, string ImageName)
		{
			string result;
			if (ControlName.HasFile)
			{
				string fileName = ControlName.PostedFile.FileName;
				FileInfo fileInfo = new FileInfo(fileName);
				string text = "~/ImgUpload/ShopCertification";
				string filepath = string.Concat(new string[]
				{
					text,
					"/",
					ImageName,
					this.MemLoginID,
					fileInfo.Extension
				});
				string empty = string.Empty;
				if (ShopNum1UpLoad.ImageUpLoadWithName(ControlName, filepath, out empty))
				{
					result = ImageName + this.MemLoginID + fileInfo.Extension;
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
		protected void GetEmailSetting()
		{
			ShopSettings shopSettings = new ShopSettings();
			this.string_1 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailServer"));
			this.string_2 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SMTP"));
			this.string_4 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ServerPort"));
			this.string_3 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailAccount"));
			this.string_5 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailPassword"));
			this.string_6 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "RestoreEmail"));
			this.string_7 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailCode"));
		}
		protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string scont)
		{
			return new ShopNum1_EmailGroupSend
			{
				Guid = Guid.NewGuid(),
				EmailTitle = "申请开店时邮件提醒",
				CreateTime = DateTime.Now,
				EmailGuid = new Guid("114410a5-6f57-465c-b149-b319dd73511e"),
				SendObjectEmail = scont,
				SendObject = memLoginID + "-" + email,
				State = state
			};
		}
		protected ShopNum1_MMSGroupSend AddSendNote(string memLoginID, string mobile, int state, string scont)
		{
			return new ShopNum1_MMSGroupSend
			{
				Guid = Guid.NewGuid(),
				MMSTitle = this.string_8,
				CreateTime = DateTime.Now,
				MMSGuid = new Guid("114410a5-6f57-465c-b149-b319dd73511e"),
				SendObjectMMS = scont,
				SendObject = memLoginID + "-" + mobile,
				State = state
			};
		}
		protected void IsEmail()
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			DataTable memberInfoByMemLoginID = shopNum1_Member_Action.GetMemberInfoByMemLoginID(this.MemLoginID);
			if (!(memberInfoByMemLoginID.Rows[0]["Email"].ToString() == ""))
			{
				string value = ShopSettings.GetValue("Name");
				OpenShop openShop = new OpenShop();
				this.GetEmailSetting();
				NetMail netMail = new NetMail();
				netMail.RecipientEmail = memberInfoByMemLoginID.Rows[0]["Email"].ToString();
				netMail.Subject = "申请开店时邮件提醒";
				openShop.Name = memberInfoByMemLoginID.Rows[0]["MemLoginID"].ToString();
				openShop.ShopID = ShopSettings.GetValue("PersonShopUrl") + memberInfoByMemLoginID.Rows[0]["ShopID"].ToString();
				openShop.ShopStatus = "审核中...";
				openShop.SysSendTime = DateTime.Now.ToString();
				openShop.ShopName = value;
				ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Email_Action();
				string text = string.Empty;
				string subject = string.Empty;
				DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'baf3ca6b-e3b2-4a9d-beb3-5385ed81c69c'", 0);
				if (editInfo.Rows.Count > 0)
				{
					text = editInfo.Rows[0]["Remark"].ToString();
					subject = editInfo.Rows[0]["Title"].ToString();
				}
				text = text.Replace("{$Name}", memberInfoByMemLoginID.Rows[0]["MemLoginID"].ToString());
				text = text.Replace("{$ShopName}", openShop.ShopName);
				text = text.Replace("{$SysSendTime}", DateTime.Now.ToString());
				netMail.Subject = subject;
				netMail.Body = openShop.ChangeOpenShop(this.Page.Server.HtmlDecode(text));
				if (!netMail.Send())
				{
					ShopNum1_EmailGroupSend emailGroupSend = this.Add(memberInfoByMemLoginID.Rows[0]["MemLoginID"].ToString(), memberInfoByMemLoginID.Rows[0]["Email"].ToString(), 0, netMail.Body);
					shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
				}
				else
				{
					ShopNum1_EmailGroupSend emailGroupSend = this.Add(memberInfoByMemLoginID.Rows[0]["MemLoginID"].ToString(), memberInfoByMemLoginID.Rows[0]["Email"].ToString(), 2, netMail.Body);
					shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
				}
			}
		}
		protected void IsMMS(string ShopID, string string_9)
		{
			if (!(string_9.Trim() == ""))
			{
				OpenShop openShop = new OpenShop();
				openShop.Name = this.MemLoginID;
				openShop.ShopID = ShopID;
				openShop.ShopName = this.textBox_0.Text.Trim();
				openShop.ShopStatus = "审核中";
				openShop.SysSendTime = DateTime.Now.ToString();
				IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
				string text = "baf3ca6b-e3b2-4a9d-beb3-5385ed81c69c";
				DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'" + text + "'", 0);
				if (editInfo.Rows.Count > 0)
				{
					string text2 = editInfo.Rows[0]["Remark"].ToString();
					text2 = text2.Replace("{$Name}", openShop.Name);
					text2 = text2.Replace("{$ShopName}", openShop.ShopName);
					text2 = text2.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
					string mMsTitle = editInfo.Rows[0]["Title"].ToString();
					SMS sMS = new SMS();
					string text3 = "";
					text2 = openShop.ChangeOpenShop(this.Page.Server.HtmlDecode(text2));
					sMS.Send(string_9.Trim(), text2, out text3);
					if (text3.IndexOf("发送成功") != -1)
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(this.MemLoginID, string_9.Trim(), mMsTitle, 2, text, text2);
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
					else
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(this.MemLoginID, string_9.Trim(), mMsTitle, 0, text, text2);
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
				}
			}
		}
		protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state, string mmsGuid, string content)
		{
			return new ShopNum1_MMSGroupSend
			{
				Guid = Guid.NewGuid(),
				MMSTitle = MMsTitle,
				CreateTime = DateTime.Now,
				MMSGuid = new Guid(mmsGuid),
				SendObjectMMS = content,
				SendObject = memLoginID + "-" + mobile,
				State = state
			};
		}
	}
}
