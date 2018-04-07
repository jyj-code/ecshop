using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.ShopFeeTemplate;
using ShopNum1.ShopInterface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ConfirmOrder : BaseWebControl
	{
		private string string_0 = "ShoppingCart2.ascx";
		private IShopNum1_Cart_Action ishopNum1_Cart_Action_0 = ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Label label_4;
		private Label label_5;
		private Label label_6;
		private Label label_7;
		private Label label_8;
		private string string_1 = string.Empty;
		private Repeater repeater_0;
		private HiddenField hiddenField_0;
		private Repeater repeater_1;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private DropDownList dropDownList_0;
		private Button button_0;
		private HiddenField hiddenField_1;
		private HiddenField hiddenField_2;
		private HiddenField hiddenField_3;
		private Button button_1;
		private HiddenField hiddenField_4;
		private HiddenField hiddenField_5;
		private HiddenField hiddenField_6;
		private HiddenField hiddenField_7;
		private HiddenField hiddenField_8;
		private TextBox textBox_6;
		private DropDownList dropDownList_1;
		private Label label_9;
		private Label label_10;
		private HiddenField hiddenField_9;
		private HiddenField hiddenField_10;
		private HiddenField hiddenField_11;
		private HiddenField hiddenField_12;
		private HiddenField hiddenField_13;
		private HiddenField hiddenField_14;
		private HiddenField hiddenField_15;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private string string_2 = "all";
		private Repeater repeater_2;
		private Label label_11;
		private DropDownList dropDownList_2;
		private RadioButtonList radioButtonList_0;
		private TextBox textBox_7;
		private TextBox textBox_8;
		private Label label_12;
		private Label label_13;
		private Label label_14;
		private string string_3 = string.Empty;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		[CompilerGenerated]
		private string string_7;
		[CompilerGenerated]
		private string string_8;
		public string AddressGuid
		{
			get;
			set;
		}
		public string strMemLoginID
		{
			get;
			set;
		}
		private string Shopid
		{
			get;
			set;
		}
		private string ProductGuid
		{
			get;
			set;
		}
		private string BuyNumber
		{
			get;
			set;
		}
		public ConfirmOrder()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_2 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.label_14 = (Label)skin.FindControl("lblTotal");
			this.label_8 = (Label)skin.FindControl("labelAll");
			this.radioButtonList_0 = (RadioButtonList)skin.FindControl("RadioButtonListInvoice");
			this.textBox_7 = (TextBox)skin.FindControl("TextBoxInvoicespayable");
			this.textBox_8 = (TextBox)skin.FindControl("TextBoxInvoice");
			this.label_11 = (Label)skin.FindControl("LabelShopName");
			this.label_12 = (Label)skin.FindControl("LabelSellName");
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListPost");
			this.repeater_2 = (Repeater)skin.FindControl("RepeaterShopProduct");
			this.repeater_2.ItemDataBound += new RepeaterItemEventHandler(this.repeater_2_ItemDataBound);
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidSaleType");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidPrice");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidShopId");
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				this.Page.Response.Write(string.Concat(new string[]
				{
					"<script>window.top.location.target= '_blank '; window.top.location.href='",
					GetPageName.RetUrl("Login"),
					"?goback=",
					this.Page.Request.Url.ToString().Replace("/", "%2f"),
					"' </script>"
				}));
			}
			else
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.strMemLoginID = httpCookie.Values["MemLoginID"].ToString();
				this.hiddenField_13 = (HiddenField)skin.FindControl("HiddenFieldSName");
				this.hiddenField_14 = (HiddenField)skin.FindControl("HiddenFieldSValue");
				this.hiddenField_15 = (HiddenField)skin.FindControl("HiddenFieldFeeTemplateID");
				this.Shopid = ShopNum1.Common.Common.ReqStr("shopid");
				if (this.Page.Request.Cookies["SpecificationCookie"] != null)
				{
					HttpCookie cookie2 = this.Page.Request.Cookies["SpecificationCookie"];
					HttpCookie httpCookie2 = HttpSecureCookie.Decode(cookie2);
					this.hiddenField_13.Value = httpCookie2.Values["SpecName"].ToString().Replace(";", "&nbsp;&nbsp;&nbsp;");
					this.hiddenField_14.Value = httpCookie2.Values["SpecValue"].ToString();
					this.htmlInputHidden_0.Value = httpCookie2.Values["Price"].ToString();
					this.htmlInputHidden_1.Value = httpCookie2.Values["ShopId"].ToString();
					this.label_12.Text = httpCookie2.Values["ShopName"].ToString();
					this.Shopid = this.htmlInputHidden_1.Value;
					this.htmlInputHidden_2.Value = httpCookie2.Values["SaleType"].ToString();
				}
				this.label_0 = (Label)skin.FindControl("labelAllPrice");
				this.label_4 = (Label)skin.FindControl("labelMaretPrice");
				this.label_5 = (Label)skin.FindControl("labelLower");
				this.label_1 = (Label)skin.FindControl("LabelBuyShopPrice");
				this.label_2 = (Label)skin.FindControl("LabelOnlyProductPrice");
				this.label_3 = (Label)skin.FindControl("LabelPriceMeto");
				this.label_6 = (Label)skin.FindControl("LabelAllCartPrice");
				this.label_7 = (Label)skin.FindControl("labelProtectAllCount");
				this.string_1 = ((this.Page.Request.QueryString["checkedguid"] == null) ? string.Empty : this.Page.Request.QueryString["checkedguid"]);
				this.repeater_0 = (Repeater)skin.FindControl("RepeaterShoppingCartPayment");
				this.repeater_1 = (Repeater)skin.FindControl("RepeaterReceivingAddress");
				this.textBox_0 = (TextBox)skin.FindControl("TextBoxName");
				this.textBox_2 = (TextBox)skin.FindControl("TextBoxAddress");
				this.textBox_1 = (TextBox)skin.FindControl("TextBoxEmail");
				this.textBox_3 = (TextBox)skin.FindControl("TextBoxPostalcode");
				this.textBox_4 = (TextBox)skin.FindControl("TextBoxTel");
				this.textBox_5 = (TextBox)skin.FindControl("TextBoxMobile");
				this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListSelect");
				this.button_0 = (Button)skin.FindControl("ButtonAddReceivAddress");
				this.button_0.Click += new EventHandler(this.button_0_Click);
				this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldAddressCode");
				this.hiddenField_2 = (HiddenField)skin.FindControl("HiddenFieldAddressGuid");
				this.hiddenField_3 = (HiddenField)skin.FindControl("HiddenFieldAddressName");
				if (!this.Page.IsPostBack)
				{
					this.BindReceivingAddress();
				}
				this.button_1 = (Button)skin.FindControl("ButtonCreate");
				this.button_1.Click += new EventHandler(this.button_1_Click);
				this.hiddenField_4 = (HiddenField)skin.FindControl("HiddenFieldDispatchModeGuid");
				this.hiddenField_5 = (HiddenField)skin.FindControl("HiddenFieldDispatchModeName");
				this.hiddenField_6 = (HiddenField)skin.FindControl("HiddenFieldPaymentGuid");
				this.hiddenField_7 = (HiddenField)skin.FindControl("HiddenFieldPaymentName");
				this.hiddenField_8 = (HiddenField)skin.FindControl("HiddenFieldInvoiceType");
				this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldPaymentPriceValue");
				this.textBox_6 = (TextBox)skin.FindControl("TextBoxMessage");
				this.label_10 = (Label)skin.FindControl("LabelPost");
				this.hiddenField_9 = (HiddenField)skin.FindControl("HiddenFieldDispatchPrice");
				this.hiddenField_10 = (HiddenField)skin.FindControl("HiddenFieldProtectAllCount");
				this.hiddenField_11 = (HiddenField)skin.FindControl("HiddenFieldPaymentCharge");
				this.hiddenField_12 = (HiddenField)skin.FindControl("HiddenFieldAllCartPrice");
				this.ProductGuid = ShopNum1.Common.Common.ReqStr("ProductionGuid");
				this.BuyNumber = ((this.Page.Request.QueryString["num"] == null) ? "-1" : this.Page.Request.QueryString["num"]);
				this.method_0();
				this.BindDataPayment();
				this.label_11.Text = this.Shopid;
			}
		}
		private void repeater_2_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label label = (Label)e.Item.FindControl("LabelBuyPrice");
				Label label2 = (Label)e.Item.FindControl("lblSpecName");
				this.label_13 = (Label)e.Item.FindControl("lblBuyNumber");
				label2.Text = this.hiddenField_13.Value;
				TextBox textBox = (TextBox)e.Item.FindControl("TextBoxBuyNumber");
				textBox.Text = this.BuyNumber;
				if (this.Page.Request.Cookies["PackAgeCookie"] != null)
				{
					HttpCookie cookie = this.Page.Request.Cookies["PackAgeCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					this.label_13.Text = httpCookie.Values["BuyNum"].ToString();
					this.htmlInputHidden_0.Value = httpCookie.Values["PackPrice"].ToString();
					this.label_8.Text = (Convert.ToInt32(this.label_13.Text) * Convert.ToDecimal(this.htmlInputHidden_0.Value)).ToString();
					string text = httpCookie.Values["Pack_Price"].ToString();
					string text2 = httpCookie.Values["SpecName"].ToString();
					if (text.IndexOf(",") != -1)
					{
						string[] array = text.Split(new char[]
						{
							','
						});
						label.Text = array[e.Item.ItemIndex];
					}
					else
					{
						label.Text = text;
					}
					if (text2.IndexOf("|") != -1)
					{
						string[] array2 = text2.Split(new char[]
						{
							'|'
						});
						label2.Text = array2[e.Item.ItemIndex];
					}
					else
					{
						label2.Text = text2.Replace("|", "");
					}
					this.hiddenField_13.Value = label2.Text.Replace(";", "&nbsp;&nbsp;&nbsp;");
					this.hiddenField_14.Value = label2.Text.Replace(";", "&nbsp;&nbsp;&nbsp;");
				}
				else
				{
					label.Text = this.htmlInputHidden_0.Value;
					this.label_13.Text = this.BuyNumber;
					string value = textBox.Text.Trim();
					this.label_8.Text = label.Text;
					if (label.Text != "")
					{
						this.label_8.Text = (Convert.ToDecimal(label.Text) * Convert.ToInt32(value)).ToString();
					}
				}
			}
		}
		private void method_0()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
			DataTable shopProductEdit;
			if (this.Page.Request.Cookies["PackAgeCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["PackAgeCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.label_12.Text = httpCookie.Values["ShopName"].ToString();
				this.label_11.Text = httpCookie.Values["MemloginId"].ToString();
				this.htmlInputHidden_2.Value = "3";
				this.ProductGuid = httpCookie.Values["PackGuId"].ToString();
				shopProductEdit = shop_Product_Action.GetShopProductEdit(this.ProductGuid);
				this.Shopid = this.label_11.Text;
				this.label_14.Text = "组合套餐价";
			}
			else
			{
				shopProductEdit = shop_Product_Action.GetShopProductEdit("'" + this.ProductGuid + "'");
			}
			if (shopProductEdit != null || shopProductEdit.Rows.Count != 0)
			{
				this.label_11.Text = shopProductEdit.Rows[0]["MemLoginID"].ToString();
				this.Shopid = shopProductEdit.Rows[0]["MemLoginID"].ToString();
				this.repeater_2.DataSource = shopProductEdit.DefaultView;
				this.repeater_2.DataBind();
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
				DataTable editInfo = shopNum1_ShopInfoList_Action.GetEditInfo(this.Shopid);
				if (editInfo != null && editInfo.Rows.Count > 0)
				{
					this.method_3(shopProductEdit);
					this.method_4();
				}
				try
				{
					IShop_Ensure_Action shop_Ensure_Action = ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
					DataTable dataTable = shop_Ensure_Action.SearchEnsureApply(shopProductEdit.Rows[0]["memloginId"].ToString());
					for (int i = 0; i < this.repeater_2.Items.Count; i++)
					{
						Label label = (Label)this.repeater_2.Items[i].FindControl("LabelProductService");
						if (dataTable != null && dataTable.Rows.Count > 0)
						{
							for (int j = 0; j < dataTable.Rows.Count; j++)
							{
								Image image = new Image();
								image.ImageUrl = dataTable.Rows[j]["ImagePath"].ToString();
								label.Controls.Add(image);
							}
						}
						else
						{
							label.Text = "";
						}
					}
				}
				catch (Exception ex)
				{
					this.Page.Response.Write(ex.Message);
				}
			}
		}
		protected void BindDataPayment()
		{
			ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
			string value = ShopSettings.GetValue("PayMentType");
			DataTable dataTable = null;
			ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = (ShopNum1_ShopPayment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopPayment_Action();
			IShopNum1_Payment_Action shopNum1_Payment_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_Payment_Action();
			string nameById = ShopNum1.Common.Common.GetNameById("IsPayMentShop", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + this.Shopid + "'   ");
			if (nameById != "-1")
			{
				if (nameById == "0")
				{
					this.string_3 = "admin";
					dataTable = shopNum1_Payment_Action.Search(0);
				}
				else if (nameById == "1")
				{
					this.string_3 = this.Shopid;
					dataTable = shopNum1_ShopPayment_Action.Search(0, this.Shopid);
				}
			}
			else if (value == "0")
			{
				this.string_3 = "admin";
				dataTable = shopNum1_Payment_Action.Search(0);
			}
			else if (value == "1")
			{
				this.string_3 = this.Shopid;
				dataTable = shopNum1_ShopPayment_Action.Search(0, this.Shopid);
			}
			else if (value == "2")
			{
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
				string shopPayMentType = shopNum1_ShopInfoList_Action.GetShopPayMentType(this.Shopid);
				if (shopPayMentType == "0")
				{
					this.string_3 = "admin";
					dataTable = shopNum1_Payment_Action.Search(0);
				}
				else
				{
					this.string_3 = this.Shopid;
					dataTable = shopNum1_ShopPayment_Action.Search(0, this.Shopid);
				}
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
			foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
			{
				RadioButton radioButton = (RadioButton)repeaterItem.FindControl("RadioButtonPayment");
				radioButton.CheckedChanged += new EventHandler(this.method_1);
				Literal literal = (Literal)repeaterItem.FindControl("LiteralIsPersent");
				HiddenField hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldIsPersent");
				if (hiddenField.Value == "1")
				{
					literal.Visible = true;
				}
			}
			if (this.repeater_0.Items.Count > 0)
			{
				RadioButton radioButton = (RadioButton)this.repeater_0.Items[0].FindControl("RadioButtonPayment");
				radioButton.Checked = true;
			}
		}
		private void method_1(object sender, EventArgs e)
		{
			this.method_4();
		}
		private void method_2(object sender, EventArgs e)
		{
			this.method_4();
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			if (this.repeater_2.Items.Count != 0)
			{
				if (this.repeater_0.Items == null || this.repeater_0.Items.Count == 0)
				{
					MessageBox.Show("支付方式不能为空！");
				}
				else
				{
					this.method_5();
					ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
					shopNum1_OrderInfo.MemLoginID = this.strMemLoginID;
					shopNum1_OrderInfo.Guid = Guid.NewGuid();
					Order order = new Order();
					shopNum1_OrderInfo.OrderNumber = order.CreateOrderNumber();
					shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
					shopNum1_OrderInfo.ShipmentStatus = 0;
					shopNum1_OrderInfo.PaymentStatus = 0;
					shopNum1_OrderInfo.PayMentMemLoginID = this.string_3;
					shopNum1_OrderInfo.OrderType = new byte?(Convert.ToByte(this.htmlInputHidden_2.Value));
					if (this.hiddenField_2.Value == "-1" && this.Page.Request.Cookies["MemberLoginCookie"] != null)
					{
						shopNum1_OrderInfo.Name = this.textBox_0.Text.Trim();
						shopNum1_OrderInfo.Email = this.textBox_1.Text.Trim();
						shopNum1_OrderInfo.Address = this.hiddenField_3.Value + "  " + this.textBox_2.Text.Trim();
						shopNum1_OrderInfo.Postalcode = this.textBox_3.Text.Trim();
						shopNum1_OrderInfo.Tel = this.textBox_4.Text;
						shopNum1_OrderInfo.Mobile = this.textBox_5.Text.Trim();
						ShopNum1_Address shopNum1_Address = new ShopNum1_Address();
						shopNum1_Address.Name = this.textBox_0.Text.Trim();
						shopNum1_Address.Email = this.textBox_1.Text.Trim();
						shopNum1_Address.Address = this.hiddenField_3.Value + "  " + this.textBox_2.Text.Trim();
						shopNum1_Address.Postalcode = this.textBox_3.Text.Trim();
						shopNum1_Address.Tel = this.textBox_4.Text;
						shopNum1_Address.Guid = Guid.NewGuid();
						shopNum1_Address.MemLoginID = this.strMemLoginID;
						shopNum1_Address.CreateTime = DateTime.Now;
						shopNum1_Address.ModifyTime = DateTime.Now;
						shopNum1_Address.IsDeleted = 0;
						if (shopNum1_OrderInfo.Mobile != "" && shopNum1_OrderInfo.Address.Replace(",", "").Trim() != "-1")
						{
							IShopNum1_Address_Action shopNum1_Address_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_Address_Action();
							shopNum1_Address_Action.Add(shopNum1_Address);
							Thread.Sleep(100);
						}
						else
						{
							shopNum1_OrderInfo.Address = "";
						}
					}
					else
					{
						ShopNum1_Address_Action shopNum1_Address_Action2 = (ShopNum1_Address_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Address_Action();
						DataTable dataTable = shopNum1_Address_Action2.Search(this.hiddenField_2.Value);
						shopNum1_OrderInfo.Name = dataTable.Rows[0]["Name"].ToString();
						shopNum1_OrderInfo.Email = dataTable.Rows[0]["Email"].ToString();
						shopNum1_OrderInfo.Address = dataTable.Rows[0]["area"].ToString() + " " + dataTable.Rows[0]["Address"].ToString();
						shopNum1_OrderInfo.Postalcode = dataTable.Rows[0]["Postalcode"].ToString();
						shopNum1_OrderInfo.Tel = dataTable.Rows[0]["Tel"].ToString();
						shopNum1_OrderInfo.Mobile = dataTable.Rows[0]["Mobile"].ToString();
					}
					shopNum1_OrderInfo.ClientToSellerMsg = this.textBox_6.Text.Trim();
					if (this.dropDownList_1.SelectedValue.Split(new char[]
					{
						':'
					})[1] == "-2")
					{
						shopNum1_OrderInfo.DispatchType = new int?(0);
						shopNum1_OrderInfo.FeeType = new int?(1);
						shopNum1_OrderInfo.DispatchPrice = new decimal?(Convert.ToDecimal(0.0));
					}
					else
					{
						shopNum1_OrderInfo.FeeType = new int?(0);
						shopNum1_OrderInfo.DispatchType = new int?(int.Parse(this.dropDownList_1.SelectedValue.Split(new char[]
						{
							':'
						})[1]));
						if (this.dropDownList_1.SelectedValue.Split(new char[]
						{
							':'
						})[1] == "-1")
						{
							shopNum1_OrderInfo.FeeType = new int?(2);
						}
						shopNum1_OrderInfo.DispatchPrice = new decimal?(Convert.ToDecimal(this.dropDownList_1.SelectedValue.Split(new char[]
						{
							':'
						})[0]));
					}
					shopNum1_OrderInfo.DispatchPrice = new decimal?(Convert.ToDecimal(this.hiddenField_9.Value));
					if (this.dropDownList_1.SelectedValue.Split(new char[]
					{
						':'
					})[1] == "-1")
					{
						shopNum1_OrderInfo.FeeType = new int?(2);
						shopNum1_OrderInfo.DispatchType = new int?(-1);
						shopNum1_OrderInfo.IsMinus = 1;
					}
					else
					{
						shopNum1_OrderInfo.IsMinus = 0;
					}
					if (this.radioButtonList_0.SelectedValue == "0")
					{
						shopNum1_OrderInfo.InvoiceTitle = this.textBox_7.Text;
						shopNum1_OrderInfo.InvoiceContent = this.textBox_8.Text;
						shopNum1_OrderInfo.InvoiceType = "";
						shopNum1_OrderInfo.InvoiceTax = 0m;
					}
					else
					{
						shopNum1_OrderInfo.InvoiceTitle = "";
						shopNum1_OrderInfo.InvoiceContent = "";
						shopNum1_OrderInfo.InvoiceType = "";
						shopNum1_OrderInfo.InvoiceTax = 0m;
					}
					shopNum1_OrderInfo.PaymentGuid = new Guid?(new Guid(this.hiddenField_6.Value.ToUpper()));
					if (this.hiddenField_7.Value.ToString() == "货到付款" || shopNum1_OrderInfo.PaymentGuid == new Guid("ACB3A3BD-3229-436D-90DD-001B9C29AF9A") || shopNum1_OrderInfo.PaymentGuid == new Guid("9ECA37CE-91C3-4D0C-8EFC-48D37A586D57") || shopNum1_OrderInfo.PaymentGuid == new Guid("D2038EF7-7466-412F-AB4C-773EADB7FFFA") || shopNum1_OrderInfo.PaymentGuid == new Guid("ACB3A3BD-3229-436D-90DD-001B9C29AF9A"))
					{
						shopNum1_OrderInfo.OderStatus = 1;
					}
					else
					{
						shopNum1_OrderInfo.OderStatus = 0;
					}
					shopNum1_OrderInfo.PaymentName = this.hiddenField_7.Value;
					shopNum1_OrderInfo.PaymentPrice = new decimal?(Convert.ToDecimal("0.00"));
					shopNum1_OrderInfo.SellerToClientMsg = "";
					shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));
					shopNum1_OrderInfo.IsMemdelay = 0;
					shopNum1_OrderInfo.OutOfStockOperate = "";
					shopNum1_OrderInfo.PackGuid = new Guid?(Guid.NewGuid());
					shopNum1_OrderInfo.PackName = "";
					shopNum1_OrderInfo.PackPrice = 0m;
					shopNum1_OrderInfo.BlessCardGuid = new Guid?(Guid.NewGuid());
					shopNum1_OrderInfo.BlessCardName = "";
					shopNum1_OrderInfo.BlessCardPrice = 0m;
					shopNum1_OrderInfo.BlessCardContent = "";
					shopNum1_OrderInfo.ProductPrice = new decimal?(Convert.ToDecimal(this.htmlInputHidden_0.Value));
					shopNum1_OrderInfo.AlreadPayPrice = 0m;
					shopNum1_OrderInfo.SurplusPrice = 0m;
					shopNum1_OrderInfo.UseScore = 0;
					shopNum1_OrderInfo.ScorePrice = new decimal?(0m);
					shopNum1_OrderInfo.ShouldPayPrice = new decimal?(Convert.ToDecimal(this.hiddenField_12.Value));
					shopNum1_OrderInfo.JoinActiveType = new int?(-1);
					shopNum1_OrderInfo.FromAd = new Guid?(Guid.NewGuid());
					shopNum1_OrderInfo.FromUrl = string.Empty;
					shopNum1_OrderInfo.PayTime = null;
					shopNum1_OrderInfo.DispatchTime = null;
					shopNum1_OrderInfo.ShipmentNumber = string.Empty;
					shopNum1_OrderInfo.CreateTime = new DateTime?(DateTime.Now);
					shopNum1_OrderInfo.ConfirmTime = new DateTime?(DateTime.Now);
					shopNum1_OrderInfo.PayMemo = "";
					shopNum1_OrderInfo.ActivityGuid = new Guid?(Guid.NewGuid());
					shopNum1_OrderInfo.BuyType = "";
					shopNum1_OrderInfo.Discount = 0m;
					shopNum1_OrderInfo.Deposit = new decimal?(0m);
					shopNum1_OrderInfo.JoinActiveType = new int?(0);
					shopNum1_OrderInfo.ActvieContent = "";
					shopNum1_OrderInfo.UsedFavourTicket = "";
					string text = string.Empty;
					if (shopNum1_OrderInfo.FeeType == 2)
					{
						Random random = new Random();
						for (int i = 1; i < 7; i++)
						{
							text += random.Next(1, 9).ToString();
						}
						shopNum1_OrderInfo.identifycode = text;
					}
					shopNum1_OrderInfo.SubstationID = this.string_2;
					string value = ShopSettings.GetValue("IsRecommendCommisionOpen");
					if (value == "true")
					{
						ShopSettings.GetValue("RecommendCommision");
						double num = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
						shopNum1_OrderInfo.RecommendCommision = new decimal?(Convert.ToDecimal(Convert.ToDouble(this.hiddenField_12.Value) * num));
					}
					else
					{
						shopNum1_OrderInfo.RecommendCommision = new decimal?(0m);
					}
					if (this.hiddenField_2.Value != "-1")
					{
						shopNum1_OrderInfo.RegionCode = this.hiddenField_1.Value;
					}
					else
					{
						shopNum1_OrderInfo.RegionCode = this.hiddenField_1.Value;
						this.hiddenField_1.Value = shopNum1_OrderInfo.RegionCode;
					}
					Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
					DataTable dataTable2;
					if (this.Page.Request.Cookies["PackAgeCookie"] != null)
					{
						dataTable2 = shop_Product_Action.SearchProductShopByGuid(this.ProductGuid);
					}
					else
					{
						dataTable2 = shop_Product_Action.SearchProductShopByGuid("'" + this.ProductGuid + "'");
					}
					shopNum1_OrderInfo.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
					shopNum1_OrderInfo.ShopName = dataTable2.Rows[0]["ShopName"].ToString();
					List<ShopNum1_OrderProduct> list = new List<ShopNum1_OrderProduct>();
					foreach (RepeaterItem repeaterItem in this.repeater_2.Items)
					{
						HiddenField hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldGuid");
						Image image = (Image)repeaterItem.FindControl("ImageProductPic");
						Label label = repeaterItem.FindControl("lbProductName") as Label;
						ShopNum1_OrderProduct shopNum1_OrderProduct = new ShopNum1_OrderProduct();
						TextBox textBox = (TextBox)repeaterItem.FindControl("TextBoxBuyNumber");
						shopNum1_OrderProduct.BuyNumber = int.Parse(textBox.Text);
						shopNum1_OrderProduct.Guid = Guid.NewGuid();
						shopNum1_OrderProduct.OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString();
						shopNum1_OrderProduct.ProductGuid = hiddenField.Value;
						ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
						shopNum1_OrderProduct.GroupPrice = Convert.ToDecimal("0.00");
						shopNum1_OrderProduct.ProductName = label.Text;
						shopNum1_OrderProduct.RepertoryNumber = dataTable2.Rows[repeaterItem.ItemIndex]["ProductNum"].ToString();
						Label label2 = repeaterItem.FindControl("labelBuyPrice") as Label;
						shopNum1_OrderProduct.MarketPrice = Convert.ToDecimal(dataTable2.Rows[repeaterItem.ItemIndex]["MarketPrice"].ToString());
						shopNum1_OrderProduct.ShopPrice = Convert.ToDecimal(label2.Text);
						if (this.htmlInputHidden_2.Value != "3")
						{
							shopNum1_OrderProduct.BuyPrice = Convert.ToDecimal(this.hiddenField_12.Value);
						}
						else
						{
							shopNum1_OrderProduct.BuyPrice = Convert.ToDecimal(label2.Text) * Convert.ToInt32(shopNum1_OrderProduct.BuyNumber);
						}
						shopNum1_OrderProduct.ProductImg = image.ImageUrl;
						shopNum1_OrderProduct.OrderType = new int?(Convert.ToInt32(this.htmlInputHidden_2.Value));
						if (this.htmlInputHidden_2.Value == "1")
						{
							string nameById = ShopNum1.Common.Common.GetNameById("groupstock", "shopnum1_group_product", " And ProductGuId='" + hiddenField.Value + "'");
							if (nameById == "0" || nameById == "")
							{
								MessageBox.Show("很抱歉,商品太火爆了,库存不足,无法完成下面操作哟！^_^");
								return;
							}
						}
						if (shopNum1_OrderInfo.FeeType == 2)
						{
							string nameById2 = ShopNum1.Common.Common.GetNameById("mobile", "shopnum1_member", " and memloginid='" + this.strMemLoginID + "'");
							if (nameById2 == "")
							{
								MessageBox.Show("您还未绑定手机号码,这样不能通过手机收到验证码了哟！^_^");
								return;
							}
							shopNum1_OrderInfo.Mobile = nameById2;
						}
						shopNum1_OrderProduct.Attributes = dataTable2.Rows[repeaterItem.ItemIndex]["setStock"].ToString();
						Label label3 = (Label)repeaterItem.FindControl("lblSpecName");
						shopNum1_OrderProduct.SpecificationName = label3.Text;
						shopNum1_OrderProduct.SpecificationValue = this.hiddenField_14.Value;
						shopNum1_OrderProduct.setStock = dataTable2.Rows[repeaterItem.ItemIndex]["setStock"].ToString();
						shopNum1_OrderProduct.IsShipment = 0;
						shopNum1_OrderProduct.IsReal = Convert.ToInt32(dataTable2.Rows[repeaterItem.ItemIndex]["IsReal"].ToString());
						shopNum1_OrderProduct.ExtensionAttriutes = "";
						shopNum1_OrderProduct.IsJoinActivity = 0;
						shopNum1_OrderProduct.CreateTime = new DateTime?(DateTime.Now);
						shopNum1_OrderProduct.DetailedSpecifications = "";
						shopNum1_OrderProduct.MemLoginID = this.strMemLoginID;
						shopNum1_OrderProduct.ShopID = dataTable2.Rows[repeaterItem.ItemIndex]["MemLoginID"].ToString();
						list.Add(shopNum1_OrderProduct);
						if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
						{
							string nameById3 = ShopNum1.Common.Common.GetNameById("email", "shopnum1_member", " and memloginID='" + shopNum1_OrderProduct.ShopID + "'");
							this.IsEmail(nameById3, shopNum1_OrderInfo.ShopID, shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID, shopNum1_OrderInfo.Tel, shopNum1_OrderProduct.ProductName, shopNum1_OrderInfo.Mobile);
						}
						if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
						{
							string nameById4 = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member", " and memloginId='" + shopNum1_OrderProduct.ShopID + "'");
							string nameById5 = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member", " and memloginId='" + shopNum1_OrderProduct.MemLoginID + "'");
							this.IsMMS(nameById4, shopNum1_OrderInfo.ShopID, shopNum1_OrderInfo.MemLoginID, shopNum1_OrderInfo.Tel, shopNum1_OrderInfo.OrderNumber, label.Text.Trim(), nameById5);
						}
					}
					if (this.htmlInputHidden_2.Value == "3")
					{
						string nameById6 = ShopNum1.Common.Common.GetNameById("top 1 repertorycount", "shopnum1_shop_product", " And guid in(" + this.ProductGuid + ") order by repertorycount asc");
						if (Convert.ToInt32(nameById6) <= 0)
						{
							MessageBox.Show("很抱歉,商品太火爆了,库存不足,无法完成下面操作哟！^_^");
							return;
						}
					}
					ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
					int num2 = shopNum1_OrderInfo_Action.Add(shopNum1_OrderInfo, list);
					if (num2 > 0)
					{
						try
						{
							if (ShopSettings.GetValue("OrderIsEmail") == "1")
							{
								string nameById3 = ShopNum1.Common.Common.GetNameById("Email", "ShopNum1_Member", " and memloginid='" + this.strMemLoginID + "'");
								this.IsEmail(shopNum1_OrderInfo.Guid.ToString(), this.strMemLoginID, nameById3, shopNum1_OrderInfo.OrderNumber);
							}
							if (ShopSettings.GetValue("OrderIsMMS") == "1")
							{
								string nameById2 = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member", " and memloginid='" + this.strMemLoginID + "'");
								this.IsMMS(shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID, nameById2);
							}
						}
						catch (Exception)
						{
						}
						string text2 = string.Empty;
						try
						{
							text2 = ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "   AND   SubstationID='" + this.string_2 + "'    ");
						}
						catch (Exception)
						{
						}
						if (text2 == "")
						{
							this.Page.Response.Redirect("http://www" + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')) + "/ShoppingCart3.aspx?tradeid=" + shopNum1_OrderInfo.TradeID);
						}
						else
						{
							this.Page.Response.Redirect(string.Concat(new string[]
							{
								"http://",
								text2,
								ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')),
								"/ShoppingCart3.aspx?tradeid=",
								shopNum1_OrderInfo.TradeID
							}));
						}
					}
					else
					{
						ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "msg", "alert(\"购买失败！\")", true);
					}
				}
			}
		}
		private void method_3(DataTable dataTable_0)
		{
			this.dropDownList_1.Items.Clear();
			string path = Shop_Common_Action.GetShopPath(this.label_11.Text.Trim()) + "xml/PostageTemplate.xml";
			string regioncode = string.Empty;
			if (this.hiddenField_1.Value == "-1")
			{
				regioncode = ShopNum1.Common.Common.ReqStr("Code");
			}
			else if (this.hiddenField_1.Value.Length >= 3)
			{
				regioncode = this.hiddenField_1.Value.Substring(0, 3);
			}
			else
			{
				regioncode = this.hiddenField_1.Value;
			}
			int num = 0;
			decimal num2 = Convert.ToDecimal(0.0);
			decimal num3 = Convert.ToDecimal(0.0);
			decimal num4 = Convert.ToDecimal(0.0);
			for (int i = 0; i < dataTable_0.Rows.Count; i++)
			{
				if (dataTable_0.Rows[i]["FeeType"].ToString() != "1")
				{
					num = 1;
					if (dataTable_0.Rows[i]["FeeTemplateID"] != null && dataTable_0.Rows[i]["FeeTemplateID"].ToString() != "" && dataTable_0.Rows[i]["FeeTemplateID"].ToString() != "0")
					{
						this.hiddenField_15.Value = dataTable_0.Rows[i]["FeeTemplateID"].ToString();
						Shop_FeeTemplate_Action shop_FeeTemplate_Action = new Shop_FeeTemplate_Action();
						DataTable feesByFrontCache = shop_FeeTemplate_Action.GetFeesByFrontCache(HttpContext.Current.Server.MapPath(path), "-1", (dataTable_0.Rows[i]["FeeTemplateID"].ToString().Length > 1) ? ("'" + dataTable_0.Rows[i]["FeeTemplateID"].ToString() + "'") : dataTable_0.Rows[i]["FeeTemplateID"].ToString(), regioncode, "-1", false);
						if (feesByFrontCache != null)
						{
							IEnumerator enumerator = feesByFrontCache.Rows.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									DataRow dataRow = (DataRow)enumerator.Current;
									decimal d = Convert.ToDecimal(dataRow["fee"].ToString()) + (int.Parse(this.BuyNumber) - 1) * Convert.ToDecimal(dataRow["oneadd"].ToString());
									if (dataRow["feetype"].ToString() == "1")
									{
										num2 += d;
									}
									else if (dataRow["feetype"].ToString() == "2")
									{
										num3 += d;
									}
									else if (dataRow["feetype"].ToString() == "3")
									{
										num4 += d;
									}
								}
								goto IL_518;
							}
							finally
							{
								IDisposable disposable = enumerator as IDisposable;
								if (disposable != null)
								{
									disposable.Dispose();
								}
							}
						}
						if (!string.IsNullOrEmpty(dataTable_0.Rows[i]["Post_fee"].ToString()))
						{
							num2 += Convert.ToDecimal(dataTable_0.Rows[i]["Post_fee"].ToString());
						}
						if (!string.IsNullOrEmpty(dataTable_0.Rows[i]["Express_fee"].ToString()))
						{
							num3 += Convert.ToDecimal(dataTable_0.Rows[i]["Express_fee"].ToString());
						}
						if (!string.IsNullOrEmpty(dataTable_0.Rows[i]["Ems_fee"].ToString()))
						{
							num4 += Convert.ToDecimal(dataTable_0.Rows[i]["Ems_fee"].ToString());
						}
					}
					else
					{
						if (!string.IsNullOrEmpty(dataTable_0.Rows[i]["Post_fee"].ToString()))
						{
							num2 += Convert.ToDecimal(dataTable_0.Rows[i]["Post_fee"].ToString());
						}
						if (!string.IsNullOrEmpty(dataTable_0.Rows[i]["Express_fee"].ToString()))
						{
							num3 += Convert.ToDecimal(dataTable_0.Rows[i]["Express_fee"].ToString());
						}
						if (!string.IsNullOrEmpty(dataTable_0.Rows[i]["Ems_fee"].ToString()))
						{
							num4 += Convert.ToDecimal(dataTable_0.Rows[i]["Ems_fee"].ToString());
						}
					}
				}
				IL_518:;
			}
			if (dataTable_0.Rows[0]["isreal"].ToString() == "0")
			{
				ListItem listItem = new ListItem();
				listItem.Text = "自提货";
				listItem.Value = "0:-1";
				this.dropDownList_1.Items.Add(listItem);
			}
			else if (num == 1)
			{
				bool flag = true;
				bool flag2 = true;
				bool flag3 = true;
				if (num2 != 0m)
				{
					flag = false;
					ListItem listItem2 = new ListItem();
					listItem2.Text = "平邮" + num2 + "元";
					listItem2.Value = num2 + ":1";
					this.dropDownList_1.Items.Add(listItem2);
					flag2 = false;
					this.hiddenField_9.Value = num2.ToString();
				}
				if (num3 != 0m)
				{
					flag = false;
					ListItem listItem3 = new ListItem();
					listItem3.Text = "快递" + num3 + "元";
					listItem3.Value = num3 + ":2";
					this.dropDownList_1.Items.Add(listItem3);
					if (flag2)
					{
						this.hiddenField_9.Value = num3.ToString();
					}
					flag3 = false;
				}
				if (num4 != 0m)
				{
					flag = false;
					ListItem listItem4 = new ListItem();
					listItem4.Text = "EMS" + num4 + "元";
					listItem4.Value = num4 + ":3";
					this.dropDownList_1.Items.Add(listItem4);
					if (flag3 & flag2)
					{
						this.hiddenField_9.Value = num4.ToString();
					}
				}
				if (flag)
				{
					ListItem listItem5 = new ListItem();
					listItem5.Text = "免运费";
					listItem5.Value = "0:-2";
					this.dropDownList_1.Items.Add(listItem5);
				}
			}
			else
			{
				ListItem listItem5 = new ListItem();
				listItem5.Text = "免运费";
				listItem5.Value = "0:-2";
				this.dropDownList_1.Items.Add(listItem5);
			}
		}
		private void method_4()
		{
			this.label_0.Text = "0";
			decimal d = 0m;
			decimal d2 = 0m;
			decimal d3 = 0m;
			decimal num = 0m;
			bool flag = false;
			foreach (RepeaterItem repeaterItem in this.repeater_2.Items)
			{
				Label label = (Label)repeaterItem.FindControl("labelProductMarketPrice");
				if (this.label_8.Text.Trim() == "")
				{
					this.label_8.Text = "0";
				}
				d += Convert.ToDecimal(this.label_8.Text);
				this.label_2.Text = d.ToString();
				if (label.Text.Trim() == "")
				{
					label.Text = "0";
				}
				d2 += Convert.ToInt32(this.BuyNumber) * Convert.ToDecimal(label.Text.Trim());
				try
				{
					if (this.dropDownList_1.SelectedValue.Split(new char[]
					{
						':'
					})[1] == "-1")
					{
						HiddenField hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldFeeType");
						HiddenField hiddenField2 = (HiddenField)repeaterItem.FindControl("HiddenFieldMinusFee");
						if (hiddenField.Value == "1")
						{
							num += Convert.ToDecimal(hiddenField2.Value) * Convert.ToInt32(this.BuyNumber);
							flag = true;
						}
					}
				}
				catch
				{
				}
			}
			this.label_4.Text = d2.ToString();
			decimal d4 = 0m;
			string a = string.Empty;
			foreach (RepeaterItem repeaterItem2 in this.repeater_0.Items)
			{
				RadioButton radioButton = (RadioButton)repeaterItem2.FindControl("RadioButtonPayment");
				if (radioButton.Checked)
				{
					HiddenField hiddenField3 = (HiddenField)repeaterItem2.FindControl("HiddenFieldIsPersent");
					if (hiddenField3.Value == "1")
					{
						a = "1";
					}
					else
					{
						a = "0";
					}
					this.label_9 = (Label)repeaterItem2.FindControl("LabelCharge");
					d4 = Convert.ToDecimal(this.label_9.Text);
					break;
				}
			}
			if (a == "1")
			{
				if (flag)
				{
					this.label_1.Text = (d + d3 + (d + d3 - num) * d4 / 100m - num).ToString("n");
				}
				else
				{
					this.label_1.Text = (d + d3 + (d + d3) * d4 / 100m).ToString("n");
				}
			}
			else if (flag)
			{
				this.label_1.Text = (d + d3 + d4 - num).ToString("n");
			}
			else
			{
				this.label_1.Text = (d + d3 + d4).ToString("n");
			}
			this.label_5.Text = (Convert.ToDecimal(this.label_4.Text) - Convert.ToDecimal(this.label_2.Text)).ToString("n");
			if (a == "1")
			{
				if (flag)
				{
					this.label_3.Text = string.Concat(new object[]
					{
						"商品总价格：<b>",
						this.label_2.Text,
						"</b>元 + 支付费用：<b>",
						((d + d3) * d4 / 100m).ToString("n"),
						"</b>元 +运费：<b>",
						d3.ToString("n"),
						"</b>元 - 生活服务优惠: <b>",
						num,
						" </b>元 =<b>",
						this.label_1.Text.Replace(",", ""),
						"</b>元"
					});
				}
				else
				{
					this.label_3.Text = string.Concat(new string[]
					{
						"商品总价格：<b>",
						this.label_2.Text,
						"</b>元 + 支付费用：<b>",
						((d + d3) * d4 / 100m).ToString("n"),
						"</b>元 +运费：<b>",
						d3.ToString("n"),
						"</b>元 =<b>",
						this.label_1.Text.Replace(",", ""),
						"</b>元"
					});
				}
			}
			else if (flag)
			{
				this.label_3.Text = string.Concat(new object[]
				{
					"商品总价格：<b>",
					this.label_2.Text,
					"</b>元 + 支付费用：<b>",
					d4.ToString("n"),
					"</b>元 + 运费：<b>",
					d3.ToString("n"),
					"</b>元 - 生活服务优惠:<b>",
					num,
					" 元 =",
					this.label_1.Text.Replace(",", ""),
					"</b>元"
				});
			}
			else
			{
				this.label_3.Text = string.Concat(new string[]
				{
					"商品总价格：<b>",
					this.label_2.Text,
					"</b>元 + 支付费用：<b>",
					d4.ToString("n"),
					"</b>元 + 运费：<b>",
					d3.ToString("n"),
					"</b>元 =<b>",
					this.label_1.Text.Replace(",", ""),
					"</b>元"
				});
			}
		}
		protected void BindReceivingAddress()
		{
			ShopNum1_Address_Action shopNum1_Address_Action = (ShopNum1_Address_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Address_Action();
			DataTable dataTable = shopNum1_Address_Action.Search(this.strMemLoginID, 0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				bool flag = true;
				this.repeater_1.DataSource = dataTable;
				this.repeater_1.DataBind();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (dataTable.Rows[i]["IsDefault"].ToString() == "1")
					{
						flag = false;
						this.hiddenField_2.Value = dataTable.Rows[i]["Guid"].ToString();
						this.hiddenField_1.Value = dataTable.Rows[i]["AddressCode"].ToString();
					}
				}
				if (flag)
				{
					this.hiddenField_2.Value = dataTable.Rows[0]["Guid"].ToString();
					this.hiddenField_1.Value = dataTable.Rows[0]["AddressCode"].ToString();
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Address shopNum1_Address = new ShopNum1_Address();
			shopNum1_Address.Guid = Guid.NewGuid();
			shopNum1_Address.Name = this.textBox_0.Text;
			shopNum1_Address.Email = this.textBox_1.Text;
			shopNum1_Address.Address = this.textBox_2.Text;
			shopNum1_Address.Area = this.hiddenField_3.Value;
			shopNum1_Address.AddressCode = this.hiddenField_1.Value;
			shopNum1_Address.Postalcode = this.textBox_3.Text;
			shopNum1_Address.Tel = this.textBox_4.Text;
			shopNum1_Address.Mobile = this.textBox_5.Text;
			shopNum1_Address.IsDefault = 0;
			shopNum1_Address.MemLoginID = this.strMemLoginID;
			shopNum1_Address.CreateUser = this.strMemLoginID;
			shopNum1_Address.CreateTime = DateTime.Now;
			shopNum1_Address.ModifyUser = this.strMemLoginID;
			shopNum1_Address.ModifyTime = DateTime.Now;
			shopNum1_Address.IsDeleted = 0;
			shopNum1_Address.AddressValue = this.hiddenField_3.Value;
			IShopNum1_Address_Action shopNum1_Address_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_Address_Action();
			int num = shopNum1_Address_Action.Add(shopNum1_Address);
			if (num <= 0)
			{
			}
			this.textBox_0.Text = (this.textBox_5.Text = string.Empty);
			this.hiddenField_1.Value = string.Empty;
			this.hiddenField_3.Value = string.Empty;
			this.textBox_2.Text = string.Empty;
			this.Page.Response.Redirect(this.Page.Request.Url.ToString());
		}
		protected void IsEmail(string strEmail, string strName, string OrderNumber, string strMemloginId, string strHomeTel, string strProductName, string strMobile)
		{
			if (!string.IsNullOrEmpty(strEmail))
			{
				string value = ShopSettings.GetValue("Name");
				OrderInfo orderInfo = new OrderInfo();
				string memLoginID = orderInfo.Name = this.strMemLoginID;
				orderInfo.OrderNumber = OrderNumber;
				orderInfo.SysSendTime = DateTime.Now.ToString();
				orderInfo.ShopName = value;
				string text = string.Empty;
				string emailTitle = string.Empty;
				string text2 = "457f965d-f1cc-45cf-b4a5-ddbbd6b7fdc0";
				ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Email_Action();
				DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
				if (editInfo.Rows.Count > 0)
				{
					text = editInfo.Rows[0]["Remark"].ToString();
					emailTitle = editInfo.Rows[0]["Title"].ToString();
				}
				text = text.Replace("{$Name}", strName);
				text = text.Replace("{$OrderNumber}", OrderNumber);
				text = text.Replace("{$MemLoginId}", strMemloginId);
				text = text.Replace("{$UserTel}", strHomeTel);
				text = text.Replace("{$SysSendTime}", DateTime.Now.ToString());
				text = text.Replace("{$ShopName}", orderInfo.ShopName);
				text = text.Replace("{$ProductName}", strProductName);
				text = text.Replace("{$UserMobile}", strMobile);
				string emailBody = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text));
				SendEmail sendEmail = new SendEmail();
				sendEmail.Emails(strEmail, memLoginID, emailTitle, text2, emailBody);
			}
		}
		protected void IsEmail(string guid, string MemLoginID, string email, string OrderNumber)
		{
			if (!string.IsNullOrEmpty(email))
			{
				string value = ShopSettings.GetValue("Name");
				OrderInfo orderInfo = new OrderInfo();
				orderInfo.Name = MemLoginID;
				orderInfo.OrderNumber = OrderNumber;
				orderInfo.SysSendTime = DateTime.Now.ToString();
				orderInfo.ShopName = value;
				string text = string.Empty;
				string emailTitle = string.Empty;
				string text2 = "ce05437f-75a7-4ee2-8014-4bd992357e51";
				ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Email_Action();
				DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
				if (editInfo.Rows.Count > 0)
				{
					text = editInfo.Rows[0]["Remark"].ToString();
					emailTitle = editInfo.Rows[0]["Title"].ToString();
				}
				text = text.Replace("{$Name}", MemLoginID);
				text = text.Replace("{$OrderNumber}", OrderNumber);
				text = text.Replace("{$ShopName}", orderInfo.ShopName);
				text = text.Replace("{$SysSendTime}", DateTime.Now.ToString());
				string emailBody = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text));
				SendEmail sendEmail = new SendEmail();
				sendEmail.Emails(email, MemLoginID, emailTitle, text2, emailBody);
			}
		}
		protected void IsMMS(string OrderNumber, string memloginID, string string_9)
		{
			if (!(string_9.Trim() == ""))
			{
				OrderInfo orderInfo = new OrderInfo();
				orderInfo.Name = memloginID;
				orderInfo.OrderNumber = OrderNumber;
				orderInfo.SysSendTime = DateTime.Now.ToString();
				orderInfo.ShopName = ShopSettings.GetValue("Name");
				string text = "CE05437F-75A7-4EE2-8014-4BD992357E51";
				IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
				DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'" + text + "'", 0);
				if (editInfo != null && editInfo.Rows.Count > 0)
				{
					string text2 = editInfo.Rows[0]["Remark"].ToString();
					text2 = text2.Replace("{$Name}", orderInfo.Name);
					text2 = text2.Replace("{$OrderNumber}", orderInfo.OrderNumber);
					text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
					text2 = text2.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
					string mMsTitle = editInfo.Rows[0]["Title"].ToString();
					SMS sMS = new SMS();
					string text3 = "";
					text2 = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text2));
					sMS.Send(string_9.Trim(), text2, out text3);
					if (text3.IndexOf("发送成功") != -1)
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(memloginID, string_9.Trim(), mMsTitle, 2, text, text2);
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
					else
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(memloginID, string_9.Trim(), mMsTitle, 0, text, text2);
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
				}
			}
		}
		protected void IsMMS(string strTel, string strName, string strMemLoginId, string strHomeTel, string strOrderNumber, string strProductName, string strMobile)
		{
			if (!string.IsNullOrEmpty(strTel))
			{
				IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
				DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'190D25F8-A9E9-4162-B4E8-0A3954C83473'", 0);
				if (editInfo.Rows.Count > 0)
				{
					string text = editInfo.Rows[0]["Remark"].ToString();
					string mMsTitle = editInfo.Rows[0]["Title"].ToString();
					text = text.Replace("{$Name}", strName);
					text = text.Replace("{$OrderNumber}", strOrderNumber);
					text = text.Replace("{$MemLoginId}", strMemLoginId);
					text = text.Replace("{$ShopName}", ShopSettings.GetValue("Name"));
					text = text.Replace("{$UserTel}", strHomeTel);
					text = text.Replace("{$SysSendTime}", DateTime.Now.ToString());
					text = text.Replace("{$ProductName}", strProductName);
					text = text.Replace("{$UserMobile}", strMobile);
					OrderInfo orderInfo = new OrderInfo();
					SMS sMS = new SMS();
					text = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text));
					string empty = string.Empty;
					sMS.Send(strTel, text, out empty);
					if (empty.IndexOf("发送成功") != -1)
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(strName, strTel.Trim(), mMsTitle, 2, "190D25F8-A9E9-4162-B4E8-0A3954C83473", text);
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
					else
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(strName, strTel.Trim(), mMsTitle, 0, "190D25F8-A9E9-4162-B4E8-0A3954C83473", text);
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
		private void method_5()
		{
			foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
			{
				RadioButton radioButton = repeaterItem.FindControl("RadioButtonPayment") as RadioButton;
				if (radioButton.Checked)
				{
					HtmlGenericControl htmlGenericControl = repeaterItem.FindControl("guid") as HtmlGenericControl;
					this.hiddenField_6.Value = htmlGenericControl.InnerText;
					this.hiddenField_7.Value = ((Label)repeaterItem.FindControl("LabelName")).Text.Trim();
				}
			}
		}
	}
}
