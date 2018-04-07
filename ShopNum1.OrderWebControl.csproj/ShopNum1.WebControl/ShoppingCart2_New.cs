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
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ShoppingCart2_New : BaseWebControl
	{
		private string string_0 = "ShoppingCart2_New.ascx";
		private IShopNum1_Cart_Action ishopNum1_Cart_Action_0 = ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
		private Repeater repeater_0;
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Label label_4;
		private Label label_5;
		private Label label_6;
		private string string_1 = string.Empty;
		private Repeater repeater_1;
		private HiddenField hiddenField_0;
		private Repeater repeater_2;
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
		private HiddenField hiddenField_4;
		private Button button_1;
		private HiddenField hiddenField_5;
		private HiddenField hiddenField_6;
		private HiddenField hiddenField_7;
		private HiddenField hiddenField_8;
		private HiddenField hiddenField_9;
		private HiddenField hiddenField_10;
		private HiddenField hiddenField_11;
		private TextBox textBox_6;
		private DropDownList dropDownList_1;
		private Label label_7;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
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
		public string PayMentMemLoginID
		{
			get;
			set;
		}
		public ShoppingCart2_New()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				this.Page.Response.Write("<script>window.top.location.target= '_blank '; window.top.location.href='" + GetPageName.RetUrl("Login") + "' </script>");
			}
			else
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.strMemLoginID = httpCookie.Values["MemLoginID"].ToString();
				this.repeater_0 = (Repeater)skin.FindControl("RepeaterShopCart2");
				this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
				this.label_0 = (Label)skin.FindControl("labelAllPrice");
				this.label_4 = (Label)skin.FindControl("labelMaretPrice");
				this.label_5 = (Label)skin.FindControl("labelLower");
				this.label_1 = (Label)skin.FindControl("LabelBuyShopPrice");
				this.label_2 = (Label)skin.FindControl("LabelOnlyProductPrice");
				this.label_3 = (Label)skin.FindControl("LabelPriceMeto");
				this.label_6 = (Label)skin.FindControl("LabelAllCartPrice");
				this.label_6.Text = "";
				if (this.Page.Request.Cookies["VjProductGuId"] != null)
				{
					HttpCookie cookie2 = this.Page.Request.Cookies["VjProductGuId"];
					HttpCookie httpCookie2 = HttpSecureCookie.Decode(cookie2);
					this.string_1 = httpCookie2.Values["parry"].ToString();
				}
				if (this.string_1 != "")
				{
					if (this.string_1.IndexOf(",") != -1)
					{
						StringBuilder stringBuilder = new StringBuilder();
						string[] array = this.string_1.Split(new char[]
						{
							','
						});
						for (int i = 0; i < array.Length; i++)
						{
							stringBuilder.Append("'" + array[i] + "',");
						}
						stringBuilder.Remove(stringBuilder.Length - 1, 1);
						this.string_1 = stringBuilder.ToString();
					}
					else
					{
						this.string_1 = "'" + this.string_1 + "'";
					}
				}
				this.repeater_1 = (Repeater)skin.FindControl("RepeaterShoppingCartPayment");
				this.BindDataPayment();
				this.repeater_2 = (Repeater)skin.FindControl("RepeaterReceivingAddress");
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
				this.hiddenField_2 = (HiddenField)skin.FindControl("HiddenFieldAddressName");
				this.hiddenField_3 = (HiddenField)skin.FindControl("HiddenFieldAddressGuid");
				this.hiddenField_4 = (HiddenField)skin.FindControl("HiddenFieldDispatchPrice");
				this.BindReceivingAddress();
				this.button_1 = (Button)skin.FindControl("ButtonCreate");
				this.button_1.Click += new EventHandler(this.button_1_Click);
				this.hiddenField_5 = (HiddenField)skin.FindControl("HiddenFieldDispatchModeGuid");
				this.hiddenField_6 = (HiddenField)skin.FindControl("HiddenFieldDispatchModeName");
				this.hiddenField_7 = (HiddenField)skin.FindControl("HiddenFieldPaymentGuid");
				this.hiddenField_8 = (HiddenField)skin.FindControl("HiddenFieldPaymentName");
				this.hiddenField_9 = (HiddenField)skin.FindControl("HiddenFieldInvoiceType");
				this.hiddenField_10 = (HiddenField)skin.FindControl("HiddenFieldMoreMemloginid");
				this.hiddenField_11 = (HiddenField)skin.FindControl("HiddenFieldFeeTemplateIDandNumber");
				this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldPaymentPriceValue");
				this.textBox_6 = (TextBox)skin.FindControl("TextBoxMessage");
				this.method_1();
			}
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label label = (Label)e.Item.FindControl("LabelShopName");
				this.dropDownList_1 = (DropDownList)e.Item.FindControl("DropDownListPost");
				this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.dropDownList_1_SelectedIndexChanged);
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterShopProduct");
				repeater.ItemDataBound += new RepeaterItemEventHandler(this.method_0);
				if (this.string_1 == string.Empty)
				{
					this.Page.Response.Redirect("/ShoppingCart1.html");
				}
				else
				{
					DataTable dataTable = this.ishopNum1_Cart_Action_0.SearchByShopMemID(this.strMemLoginID, label.Text, this.string_1);
					repeater.DataSource = dataTable.DefaultView;
					repeater.DataBind();
					IShop_Ensure_Action shop_Ensure_Action = ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
					DataTable dataTable2 = shop_Ensure_Action.SearchEnsureApply(label.Text);
					for (int i = 0; i < repeater.Items.Count; i++)
					{
						Label label2 = (Label)repeater.Items[i].FindControl("LabelProductService");
						if (dataTable2 != null && dataTable2.Rows.Count > 0)
						{
							for (int j = 0; j < dataTable2.Rows.Count; j++)
							{
								Image image = new Image();
								image.ImageUrl = dataTable2.Rows[j]["ImagePath"].ToString();
								label2.Controls.Add(image);
							}
						}
						else
						{
							label2.Text = "";
						}
					}
				}
			}
		}
		private void method_0(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label label = (Label)e.Item.FindControl("LabelBuyPrice");
				string value = label.Text.Trim();
				TextBox textBox = (TextBox)e.Item.FindControl("TextBoxBuyNumber");
				string text = textBox.Text.Trim();
				Label label2 = (Label)e.Item.FindControl("LabelAll");
				label2.Text = text;
				label2.Text = (Convert.ToDecimal(value) * Convert.ToInt32(text)).ToString();
			}
		}
		private void method_1()
		{
			if (this.string_1 == string.Empty)
			{
				this.Page.Response.Redirect("/ShoppingCart1.html");
			}
			else
			{
				DataTable dataTable = this.ishopNum1_Cart_Action_0.SearchShopByMemLoginID(this.strMemLoginID, this.string_1);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					string text = string.Empty;
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						if (i < dataTable.Rows.Count - 1)
						{
							text = text + dataTable.Rows[i]["ShopID"].ToString() + ",";
						}
						else
						{
							text += dataTable.Rows[i]["ShopID"].ToString();
						}
					}
					this.hiddenField_10.Value = text;
					this.repeater_0.DataSource = dataTable.DefaultView;
					this.repeater_0.DataBind();
				}
				this.method_3();
				this.GetAllMoney();
			}
		}
		protected void BindDataPayment()
		{
			if (this.string_1 == string.Empty)
			{
				this.Page.Response.Redirect("/ShoppingCart1.html");
			}
			else
			{
				DataTable dataTable = this.ishopNum1_Cart_Action_0.SearchShopByMemLoginID(this.strMemLoginID, this.string_1);
				if (dataTable.Rows.Count == 0)
				{
					this.Page.Response.Redirect("/ShoppingCart1.html");
				}
				else
				{
					string value = ShopSettings.GetValue("PayMentType");
					DataTable dataTable2 = null;
					ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = (ShopNum1_ShopPayment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopPayment_Action();
					IShopNum1_Payment_Action shopNum1_Payment_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_Payment_Action();
					string nameById = ShopNum1.Common.Common.GetNameById("IsPayMentShop", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + dataTable.Rows[0]["shopid"] + "'   ");
					if (dataTable.Rows.Count > 1)
					{
						this.PayMentMemLoginID = "admin";
						dataTable2 = shopNum1_Payment_Action.Search(0);
					}
					else if (nameById != "-1")
					{
						if (nameById == "0")
						{
							this.PayMentMemLoginID = "admin";
							dataTable2 = shopNum1_Payment_Action.Search(0);
						}
						else if (nameById == "1")
						{
							this.PayMentMemLoginID = dataTable.Rows[0]["MemloginId"].ToString();
							dataTable2 = shopNum1_ShopPayment_Action.Search(0, dataTable.Rows[0]["shopid"].ToString());
						}
					}
					else if (value == "0")
					{
						this.PayMentMemLoginID = "admin";
						dataTable2 = shopNum1_Payment_Action.Search(0);
					}
					else if (value == "1")
					{
						this.PayMentMemLoginID = dataTable.Rows[0]["shopid"].ToString();
						dataTable2 = shopNum1_ShopPayment_Action.Search(0, dataTable.Rows[0]["shopid"].ToString());
					}
					else if (value == "2")
					{
						ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
						string shopPayMentType = shopNum1_ShopInfoList_Action.GetShopPayMentType(dataTable.Rows[0]["shopid"].ToString());
						if (shopPayMentType == "0")
						{
							this.PayMentMemLoginID = "admin";
							dataTable2 = shopNum1_Payment_Action.Search(0);
						}
						else
						{
							this.PayMentMemLoginID = dataTable.Rows[0]["shopid"].ToString();
							dataTable2 = shopNum1_ShopPayment_Action.Search(0, dataTable.Rows[0]["shopid"].ToString());
						}
					}
					if (dataTable2 != null && dataTable2.Rows.Count > 0)
					{
						this.repeater_1.DataSource = dataTable2.DefaultView;
						this.repeater_1.DataBind();
					}
					foreach (RepeaterItem repeaterItem in this.repeater_1.Items)
					{
						RadioButton radioButton = (RadioButton)repeaterItem.FindControl("RadioButtonPayment");
						radioButton.CheckedChanged += new EventHandler(this.method_2);
						Literal literal = (Literal)repeaterItem.FindControl("LiteralIsPersent");
						HiddenField hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldIsPersent");
						if (hiddenField.Value == "1")
						{
							literal.Visible = true;
						}
					}
					if (this.repeater_1.Items.Count > 0)
					{
						RadioButton radioButton = (RadioButton)this.repeater_1.Items[0].FindControl("RadioButtonPayment");
						radioButton.Checked = true;
					}
				}
			}
		}
		private void method_2(object sender, EventArgs e)
		{
			this.GetAllMoney();
		}
		private void dropDownList_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.GetAllMoney();
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			if (this.repeater_1.Items == null || this.repeater_1.Items.Count == 0)
			{
				MessageBox.Show("支付方式不能为空！");
			}
			else if (this.repeater_0.Items.Count <= 0)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "msg", "alert(\"当前结算商品为空,请购买商品后去结算!\");", true);
			}
			else
			{
				this.method_4();
				List<ShopNum1_OrderInfo> list = new List<ShopNum1_OrderInfo>();
				List<ShopNum1_OrderProduct> list2 = new List<ShopNum1_OrderProduct>();
				IShopNum1_Address_Action shopNum1_Address_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_Address_Action();
				foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
				{
					this.dropDownList_1 = (DropDownList)repeaterItem.FindControl("DropDownListPost");
					if (!(this.dropDownList_1.SelectedValue != "") || !(this.dropDownList_1.SelectedValue.Split(new char[]
					{
						':'
					})[1] != "-1"))
					{
					}
				}
				Order order = new Order();
				string text = order.CreateOrderNumber();
				string text2 = text;
				Thread.Sleep(5);
				int num = 0;
				DataTable dataTable = this.ishopNum1_Cart_Action_0.SearchShopByMemLoginID(this.strMemLoginID);
				string text3 = string.Empty;
				foreach (RepeaterItem repeaterItem2 in this.repeater_0.Items)
				{
					Thread.Sleep(5);
					ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
					shopNum1_OrderInfo.MemLoginID = this.strMemLoginID;
					shopNum1_OrderInfo.TradeID = text2;
					if (this.hiddenField_8.Value.ToString() == "货到付款")
					{
						shopNum1_OrderInfo.OderStatus = 0;
					}
					else
					{
						shopNum1_OrderInfo.OderStatus = 0;
					}
					shopNum1_OrderInfo.ShipmentStatus = 0;
					shopNum1_OrderInfo.PaymentStatus = 0;
					shopNum1_OrderInfo.OrderType = new byte?(0);
					shopNum1_OrderInfo.PayMentMemLoginID = this.PayMentMemLoginID;
					this.dropDownList_1 = (DropDownList)repeaterItem2.FindControl("DropDownListPost");
					if (!(this.dropDownList_1.SelectedValue != ""))
					{
						ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "msg", "alert(\"该订单商品已被商家删除或下架!\");window.location.href='/default.html';", true);
						return;
					}
					if (this.dropDownList_1.SelectedValue.Split(new char[]
					{
						':'
					})[1] == "-1")
					{
						shopNum1_OrderInfo.IsMinus = 1;
					}
					else
					{
						shopNum1_OrderInfo.IsMinus = 0;
					}
					if (this.hiddenField_3.Value == "-1" && this.Page.Request.Cookies["MemberLoginCookie"] != null)
					{
						shopNum1_OrderInfo.Name = this.textBox_0.Text.Trim();
						shopNum1_OrderInfo.Email = this.textBox_1.Text.Trim();
						shopNum1_OrderInfo.Address = this.hiddenField_2.Value + "  " + this.textBox_2.Text.Trim();
						shopNum1_OrderInfo.Postalcode = this.textBox_3.Text.Trim();
						shopNum1_OrderInfo.Tel = this.textBox_4.Text;
						shopNum1_OrderInfo.Mobile = this.textBox_5.Text.Trim();
						ShopNum1_Address shopNum1_Address = new ShopNum1_Address();
						shopNum1_Address.Name = this.textBox_0.Text.Trim();
						shopNum1_Address.Email = this.textBox_1.Text.Trim();
						shopNum1_Address.Address = this.hiddenField_2.Value + "  " + this.textBox_2.Text.Trim();
						shopNum1_Address.Postalcode = this.textBox_3.Text.Trim();
						shopNum1_Address.Tel = this.textBox_4.Text;
						shopNum1_Address.Guid = Guid.NewGuid();
						shopNum1_Address.MemLoginID = this.strMemLoginID;
						shopNum1_Address.CreateTime = DateTime.Now;
						shopNum1_Address.IsDeleted = 0;
						shopNum1_Address.ModifyTime = DateTime.Now;
						if (shopNum1_OrderInfo.Mobile != "" && shopNum1_OrderInfo.Address.Replace(",", "").Trim() != "-1")
						{
							Thread.Sleep(200);
							IShopNum1_Address_Action shopNum1_Address_Action2 = ShopNum1.Factory.LogicFactory.CreateShopNum1_Address_Action();
							shopNum1_Address_Action2.Add(shopNum1_Address);
						}
					}
					else
					{
						DataTable dataTable2 = shopNum1_Address_Action.Search(this.hiddenField_3.Value);
						shopNum1_OrderInfo.Name = dataTable2.Rows[0]["Name"].ToString();
						shopNum1_OrderInfo.Email = dataTable2.Rows[0]["Email"].ToString();
						shopNum1_OrderInfo.Address = dataTable2.Rows[0]["area"].ToString() + " " + dataTable2.Rows[0]["Address"].ToString();
						shopNum1_OrderInfo.Postalcode = dataTable2.Rows[0]["Postalcode"].ToString();
						shopNum1_OrderInfo.Tel = dataTable2.Rows[0]["Tel"].ToString();
						shopNum1_OrderInfo.Mobile = dataTable2.Rows[0]["Mobile"].ToString();
					}
					this.ViewState["tel"] = shopNum1_OrderInfo.Mobile;
					this.ViewState["Email"] = shopNum1_OrderInfo.Email;
					shopNum1_OrderInfo.PaymentGuid = new Guid?(new Guid(this.hiddenField_7.Value));
					shopNum1_OrderInfo.PaymentName = this.hiddenField_8.Value;
					shopNum1_OrderInfo.PaymentPrice = new decimal?(Convert.ToDecimal(this.hiddenField_0.Value.Trim()));
					this.textBox_6 = (TextBox)repeaterItem2.FindControl("TextBoxMessage");
					shopNum1_OrderInfo.ClientToSellerMsg = this.textBox_6.Text.Trim();
					shopNum1_OrderInfo.SellerToClientMsg = "";
					shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));
					shopNum1_OrderInfo.IsMemdelay = 0;
					RadioButtonList radioButtonList = (RadioButtonList)repeaterItem2.FindControl("RadioButtonListInvoice");
					if (radioButtonList.SelectedValue == "1")
					{
						shopNum1_OrderInfo.InvoiceTitle = "";
						shopNum1_OrderInfo.InvoiceContent = "";
					}
					else
					{
						TextBox textBox = (TextBox)repeaterItem2.FindControl("TextBoxInvoicespayable");
						TextBox textBox2 = (TextBox)repeaterItem2.FindControl("TextBoxInvoice");
						shopNum1_OrderInfo.InvoiceTitle = textBox.Text.Trim();
						shopNum1_OrderInfo.InvoiceContent = textBox2.Text.Trim();
					}
					shopNum1_OrderInfo.InvoiceType = "";
					shopNum1_OrderInfo.InvoiceTax = 0m;
					shopNum1_OrderInfo.OutOfStockOperate = "";
					shopNum1_OrderInfo.PackGuid = new Guid?(Guid.NewGuid());
					shopNum1_OrderInfo.PackName = "";
					shopNum1_OrderInfo.PackPrice = 0m;
					shopNum1_OrderInfo.BlessCardGuid = new Guid?(Guid.NewGuid());
					shopNum1_OrderInfo.BlessCardName = "";
					shopNum1_OrderInfo.BlessCardPrice = 0m;
					shopNum1_OrderInfo.BlessCardContent = "";
					shopNum1_OrderInfo.AlreadPayPrice = 0m;
					shopNum1_OrderInfo.SurplusPrice = 0m;
					shopNum1_OrderInfo.UseScore = 0;
					shopNum1_OrderInfo.ScorePrice = new decimal?(0m);
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
					if (this.hiddenField_3.Value != "-1")
					{
						shopNum1_OrderInfo.RegionCode = this.hiddenField_1.Value;
					}
					else
					{
						shopNum1_OrderInfo.RegionCode = this.hiddenField_1.Value;
					}
					shopNum1_OrderInfo.Guid = Guid.NewGuid();
					this.label_0.Text = "0";
					string value = "0";
					this.dropDownList_1 = (DropDownList)repeaterItem2.FindControl("DropDownListPost");
					Repeater repeater = (Repeater)repeaterItem2.FindControl("RepeaterShopProduct");
					decimal num2 = 0m;
					foreach (RepeaterItem repeaterItem3 in repeater.Items)
					{
						Label label = (Label)repeaterItem3.FindControl("LabelAll");
						this.label_0.Text = Convert.ToString(Convert.ToDecimal(this.label_0.Text) + Convert.ToDecimal(label.Text));
						value = Convert.ToString(Convert.ToDecimal(value) + Convert.ToDecimal(label.Text));
						HiddenField hiddenField = (HiddenField)repeaterItem3.FindControl("HiddenFieldFeeType");
						HiddenField hiddenField2 = (HiddenField)repeaterItem3.FindControl("HiddenFieldMinusFee");
						if (hiddenField.Value == "1")
						{
							num2 += Convert.ToDecimal(hiddenField2.Value);
						}
						Label arg_A07_0 = (Label)repeaterItem3.FindControl("LabelBuyPrice");
						TextBox arg_A19_0 = (TextBox)repeaterItem3.FindControl("TextBoxBuyNumber");
						Label label2 = repeaterItem2.FindControl("LabelShopName") as Label;
						Label label3 = repeaterItem3.FindControl("lbProductName") as Label;
						if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
						{
							string nameById = ShopNum1.Common.Common.GetNameById("email", "shopnum1_member", " and memloginID='" + shopNum1_OrderInfo.ShopID + "'");
							this.IsEmail(nameById, shopNum1_OrderInfo.ShopID, shopNum1_OrderInfo.MemLoginID, shopNum1_OrderInfo.OrderNumber, label3.Text, shopNum1_OrderInfo.Tel, shopNum1_OrderInfo.Mobile);
						}
						if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
						{
							string nameById2 = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member", " and memloginId='" + label2.Text + "'");
							this.IsMMS(nameById2, label2.Text, shopNum1_OrderInfo.ShopID, shopNum1_OrderInfo.Tel, shopNum1_OrderInfo.OrderNumber, label3.Text.Trim(), shopNum1_OrderInfo.Mobile);
						}
					}
					if (this.dropDownList_1.SelectedValue != "")
					{
						if (this.dropDownList_1.SelectedValue.Split(new char[]
						{
							':'
						})[1] == "-1")
						{
							this.label_0.Text = Convert.ToString(Convert.ToDecimal(this.label_0.Text) + Convert.ToDecimal(this.dropDownList_1.SelectedValue.Split(new char[]
							{
								':'
							})[0]) - num2);
						}
						else
						{
							this.label_0.Text = Convert.ToString(Convert.ToDecimal(this.label_0.Text) + Convert.ToDecimal(this.dropDownList_1.SelectedValue.Split(new char[]
							{
								':'
							})[0]));
						}
					}
					decimal d = 0m;
					string a = string.Empty;
					foreach (RepeaterItem repeaterItem in this.repeater_1.Items)
					{
						RadioButton radioButton = (RadioButton)repeaterItem.FindControl("RadioButtonPayment");
						if (radioButton.Checked)
						{
							HiddenField hiddenField3 = (HiddenField)repeaterItem.FindControl("HiddenFieldIsPersent");
							if (hiddenField3.Value == "1")
							{
								a = "1";
							}
							else
							{
								a = "0";
							}
							this.label_7 = (Label)repeaterItem.FindControl("LabelCharge");
							d = Convert.ToDecimal(this.label_7.Text);
							break;
						}
					}
					if (a == "1")
					{
						this.label_0.Text = Convert.ToString(Convert.ToDecimal(this.label_0.Text) + Convert.ToDecimal(this.label_0.Text) * d / 100m);
					}
					else
					{
						this.label_0.Text = Convert.ToString(Convert.ToDecimal(this.label_0.Text) + d);
					}
					string value2 = ShopSettings.GetValue("IsRecommendCommisionOpen");
					if (value2 == "true")
					{
						ShopSettings.GetValue("RecommendCommision");
						double num3 = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
						shopNum1_OrderInfo.RecommendCommision = new decimal?(Convert.ToDecimal(Convert.ToDouble(this.label_0.Text) * num3));
					}
					else
					{
						shopNum1_OrderInfo.RecommendCommision = new decimal?(0m);
					}
					Order order2 = new Order();
					if (this.repeater_0.Items.Count == 1)
					{
						shopNum1_OrderInfo.OrderNumber = text2;
					}
					else
					{
						shopNum1_OrderInfo.OrderNumber = order2.CreateOrderNumber();
					}
					if (this.ViewState["OrderNumber"] == null)
					{
						this.ViewState["OrderNumber"] = shopNum1_OrderInfo.OrderNumber;
					}
					else
					{
						StateBag viewState;
						(viewState = this.ViewState)["OrderNumber"] = viewState["OrderNumber"] + "," + shopNum1_OrderInfo.OrderNumber;
					}
					Label label4 = (Label)repeaterItem2.FindControl("LabelShopName");
					Label label5 = (Label)repeaterItem2.FindControl("LabelSellName");
					shopNum1_OrderInfo.ShopName = label5.Text;
					shopNum1_OrderInfo.ShopID = label4.Text;
					string substationID = string.Empty;
					try
					{
						substationID = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   and     MemLoginID='" + label4.Text + "'      ");
						goto IL_150C;
					}
					catch (Exception)
					{
						goto IL_150C;
					}
					goto IL_F1A;
					IL_F3A:
					shopNum1_OrderInfo.ProductPrice = new decimal?(Convert.ToDecimal(value));
					shopNum1_OrderInfo.ShouldPayPrice = new decimal?(Convert.ToDecimal(this.label_0.Text));
					if (this.dropDownList_1.SelectedValue != "")
					{
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
								shopNum1_OrderInfo.FeeType = new int?(1);
							}
							shopNum1_OrderInfo.DispatchPrice = new decimal?(Convert.ToDecimal(this.dropDownList_1.SelectedValue.Split(new char[]
							{
								':'
							})[0]));
						}
					}
					string text4 = this.hiddenField_4.Value;
					if (text4.IndexOf(",") != -1)
					{
						text4 = text4.Split(new char[]
						{
							','
						})[repeaterItem2.ItemIndex];
					}
					shopNum1_OrderInfo.DispatchPrice = new decimal?(Convert.ToDecimal(text4));
					list.Add(shopNum1_OrderInfo);
					DataTable dataTable3 = new DataTable();
					if (this.string_1 == string.Empty)
					{
						dataTable3 = this.ishopNum1_Cart_Action_0.SearchByMemLoginIDAndShopID(this.strMemLoginID, dataTable.Rows[num]["ShopID"].ToString());
					}
					else
					{
						dataTable3 = this.ishopNum1_Cart_Action_0.SearchByMemLoginIDAndShopID(this.strMemLoginID, dataTable.Rows[num]["ShopID"].ToString(), this.string_1);
					}
					for (int i = 0; i < dataTable3.Rows.Count; i++)
					{
						list2.Add(new ShopNum1_OrderProduct
						{
							ProductImg = dataTable3.Rows[i]["originalimge"].ToString(),
							OrderType = new int?(Convert.ToInt32(dataTable3.Rows[i]["carttype"].ToString())),
							Guid = Guid.NewGuid(),
							OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString(),
							ProductGuid = dataTable3.Rows[i]["ProductGuid"].ToString(),
							GroupPrice = Convert.ToDecimal("0.00"),
							SpecificationName = dataTable3.Rows[i]["SpecificationName"].ToString(),
							SpecificationValue = dataTable3.Rows[i]["SpecificationValue"].ToString(),
							setStock = dataTable3.Rows[i]["Attributes"].ToString(),
							ProductName = dataTable3.Rows[i]["Name"].ToString(),
							RepertoryNumber = dataTable3.Rows[i]["RepertoryNumber"].ToString(),
							BuyNumber = Convert.ToInt32(dataTable3.Rows[i]["BuyNumber"].ToString()),
							MarketPrice = Convert.ToDecimal(dataTable3.Rows[i]["MarketPrice"].ToString()),
							ShopPrice = Convert.ToDecimal(dataTable3.Rows[i]["ShopPrice"].ToString()),
							BuyPrice = Convert.ToDecimal(dataTable3.Rows[i]["BuyPrice"].ToString()) * Convert.ToInt32(dataTable3.Rows[i]["BuyNumber"].ToString()),
							Attributes = dataTable3.Rows[i]["Attributes"].ToString(),
							IsShipment = Convert.ToInt32(dataTable3.Rows[i]["IsShipment"].ToString()),
							IsReal = Convert.ToInt32(dataTable3.Rows[i]["IsReal"].ToString()),
							ExtensionAttriutes = dataTable3.Rows[i]["ExtensionAttriutes"].ToString(),
							IsJoinActivity = Convert.ToInt32(dataTable3.Rows[i]["IsJoinActivity"].ToString()),
							CreateTime = new DateTime?(DateTime.Now),
							DetailedSpecifications = dataTable3.Rows[i]["DetailedSpecifications"].ToString(),
							MemLoginID = this.strMemLoginID,
							ShopID = dataTable3.Rows[i]["ShopID"].ToString()
						});
					}
					num++;
					continue;
					IL_F1A:
					text3 = shopNum1_OrderInfo.ShopID;
					goto IL_F3A;
					IL_150C:
					shopNum1_OrderInfo.SubstationID = substationID;
					if (text3 == string.Empty)
					{
						goto IL_F1A;
					}
					text3 = text3 + "," + shopNum1_OrderInfo.ShopID;
					goto IL_F3A;
				}
				ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
				int num4 = shopNum1_OrderInfo_Action.Add(list, list2);
				if (num4 > 0)
				{
					int num5;
					if (this.string_1 == string.Empty)
					{
						num5 = this.ishopNum1_Cart_Action_0.DeleteByMemLoginID(this.strMemLoginID);
					}
					else
					{
						num5 = this.ishopNum1_Cart_Action_0.DeleteByMemLoginID(this.strMemLoginID, this.string_1);
					}
					if (num5 <= 0)
					{
					}
					ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
					DataTable memberInfoByMemLoginID = shopNum1_Member_Action.GetMemberInfoByMemLoginID(this.strMemLoginID);
					if (memberInfoByMemLoginID.Rows.Count > 0)
					{
						if (ShopSettings.GetValue("OrderIsEmail") == "1")
						{
							string nameById = ShopNum1.Common.Common.GetNameById("Email", "ShopNum1_Member", " and memloginid='" + this.strMemLoginID + "'");
							this.IsEmail(this.ViewState["OrderNumber"].ToString(), this.strMemLoginID, nameById);
						}
						if (ShopSettings.GetValue("SubmitOrderIsMMS") == "1")
						{
							string nameById3 = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member", " and memloginid='" + this.strMemLoginID + "'");
							this.IsMMS(this.ViewState["OrderNumber"].ToString(), this.strMemLoginID, nameById3);
						}
					}
					if (this.Page.Request.QueryString["gocityurl"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["gocityurl"].ToString()))
					{
						string text5 = string.Empty;
						try
						{
							text5 = ShopNum1.Common.Common.GetNameById("Guid", "ShopNum1_SubstationManage", "   AND    DomainName='" + this.Page.Request.QueryString["gocityurl"].ToString() + "'    ");
							if (string.IsNullOrEmpty(text5))
							{
								return;
							}
						}
						catch (Exception)
						{
						}
						if (text5 == "")
						{
							this.Page.Response.Redirect("http://www" + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')) + "/ShoppingCart3.aspx?tradeid=" + text2);
						}
						else
						{
							this.Page.Response.Redirect(string.Concat(new string[]
							{
								"http://",
								this.Page.Request.QueryString["gocityurl"].ToString(),
								ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')),
								"/ShoppingCart3.aspx?tradeid=",
								text2
							}));
						}
					}
					else
					{
						this.Page.Response.Redirect("http://www" + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')) + "/ShoppingCart3.aspx?tradeid=" + text2);
					}
				}
				else
				{
					ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "msg", "alert(\"购买失败！\")", true);
				}
			}
		}
		private void method_3()
		{
			foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
			{
				Label label = (Label)repeaterItem.FindControl("LabelShopName");
				this.dropDownList_1 = (DropDownList)repeaterItem.FindControl("DropDownListPost");
				this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.dropDownList_1_SelectedIndexChanged);
				this.dropDownList_1.Items.Clear();
				string path = Shop_Common_Action.GetShopPath(label.Text.Trim()) + "xml/PostageTemplate.xml";
				string regioncode = string.Empty;
				if (this.hiddenField_1.Value == "-1")
				{
					regioncode = "-1";
				}
				else if (this.hiddenField_1.Value.Length > 3)
				{
					regioncode = this.hiddenField_1.Value.Substring(0, 3);
				}
				DataTable productInfoByCartProductGuid = this.ishopNum1_Cart_Action_0.GetProductInfoByCartProductGuid(this.strMemLoginID, label.Text.Trim(), this.string_1);
				if (productInfoByCartProductGuid == null || productInfoByCartProductGuid.Rows.Count == 0)
				{
					break;
				}
				string text = string.Empty;
				for (int i = 0; i < productInfoByCartProductGuid.Rows.Count; i++)
				{
					if (i < productInfoByCartProductGuid.Rows.Count - 1)
					{
						string text2 = text;
						text = string.Concat(new string[]
						{
							text2,
							productInfoByCartProductGuid.Rows[i]["FeeTemplateID"].ToString(),
							",",
							productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString(),
							",",
							productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString(),
							",",
							productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString(),
							",",
							productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString(),
							"|"
						});
					}
					else
					{
						string text2 = text;
						text = string.Concat(new string[]
						{
							text2,
							productInfoByCartProductGuid.Rows[i]["FeeTemplateID"].ToString(),
							",",
							productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString(),
							",",
							productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString(),
							",",
							productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString(),
							",",
							productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString()
						});
					}
				}
				this.hiddenField_11.Value = text;
				int num = 0;
				decimal num2 = Convert.ToDecimal(0.0);
				decimal num3 = Convert.ToDecimal(0.0);
				decimal num4 = Convert.ToDecimal(0.0);
				for (int i = 0; i < productInfoByCartProductGuid.Rows.Count; i++)
				{
					if (productInfoByCartProductGuid.Rows[i]["FeeType"].ToString() != "1")
					{
						num = 1;
						if (productInfoByCartProductGuid.Rows[i]["FeeTemplateID"] != null && productInfoByCartProductGuid.Rows[i]["FeeTemplateID"].ToString() != "" && productInfoByCartProductGuid.Rows[i]["FeeTemplateID"].ToString() != "0")
						{
							Shop_FeeTemplate_Action shop_FeeTemplate_Action = new Shop_FeeTemplate_Action();
							DataTable feesByFrontCache = shop_FeeTemplate_Action.GetFeesByFrontCache(HttpContext.Current.Server.MapPath(path), "-1", "'" + productInfoByCartProductGuid.Rows[i]["FeeTemplateID"].ToString() + "'", regioncode, "-1", false);
							if (feesByFrontCache != null)
							{
								IEnumerator enumerator2 = feesByFrontCache.Rows.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										DataRow dataRow = (DataRow)enumerator2.Current;
										decimal d = Convert.ToDecimal(dataRow["fee"].ToString()) + (int.Parse(productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString()) - 1) * Convert.ToDecimal(dataRow["oneadd"].ToString());
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
									goto IL_767;
								}
								finally
								{
									IDisposable disposable = enumerator2 as IDisposable;
									if (disposable != null)
									{
										disposable.Dispose();
									}
								}
							}
							if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString()))
							{
								num2 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString());
							}
							if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString()))
							{
								num3 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString());
							}
							if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString()))
							{
								num4 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString());
							}
						}
						else
						{
							if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString()))
							{
								num2 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString());
							}
							if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString()))
							{
								num3 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString());
							}
							if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString()))
							{
								num4 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString());
							}
						}
					}
					IL_767:;
				}
				if (num == 1)
				{
					bool flag = true;
					bool flag2 = true;
					bool flag3 = true;
					if (num2 != 0m)
					{
						flag = false;
						ListItem listItem = new ListItem();
						listItem.Text = "平邮" + num2 + "元";
						listItem.Value = num2 + ":1";
						this.dropDownList_1.Items.Add(listItem);
						flag2 = false;
						this.hiddenField_4.Value = num2.ToString();
					}
					if (num3 != 0m)
					{
						flag = false;
						ListItem listItem2 = new ListItem();
						listItem2.Text = "快递" + num3 + "元";
						listItem2.Value = num3 + ":2";
						this.dropDownList_1.Items.Add(listItem2);
						if (flag2)
						{
							this.hiddenField_4.Value = num3.ToString();
						}
						flag3 = false;
					}
					if (num4 != 0m)
					{
						flag = false;
						ListItem listItem3 = new ListItem();
						listItem3.Text = "EMS" + num4 + "元";
						listItem3.Value = num4 + ":3";
						this.dropDownList_1.Items.Add(listItem3);
						if (flag3 & flag2)
						{
							this.hiddenField_4.Value = num4.ToString();
						}
					}
					if (flag)
					{
						ListItem listItem4 = new ListItem();
						listItem4.Text = "免运费";
						listItem4.Value = "0:-2";
						this.dropDownList_1.Items.Add(listItem4);
					}
				}
				else
				{
					ListItem listItem4 = new ListItem();
					listItem4.Text = "免运费";
					listItem4.Value = "0:-2";
					this.dropDownList_1.Items.Add(listItem4);
				}
			}
		}
		protected void GetAllMoney()
		{
			this.label_0.Text = "0";
			decimal d = 0m;
			decimal d2 = 0m;
			decimal num = 0m;
			decimal num2 = 0m;
			bool flag = false;
			IEnumerator enumerator;
			for (int i = 0; i < this.repeater_0.Items.Count; i++)
			{
				this.dropDownList_1 = (DropDownList)this.repeater_0.Items[i].FindControl("DropDownListPost");
				Repeater repeater = (Repeater)this.repeater_0.Items[i].FindControl("RepeaterShopProduct");
				enumerator = repeater.Items.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						RepeaterItem repeaterItem = (RepeaterItem)enumerator.Current;
						Label label = (Label)repeaterItem.FindControl("LabelAll");
						Label label2 = (Label)repeaterItem.FindControl("labelProductMarketPrice");
						Label label3 = (Label)repeaterItem.FindControl("labelBuyNumber");
						d += Convert.ToDecimal(label.Text);
						this.label_2.Text = d.ToString();
						d2 += Convert.ToInt32(label3.Text.Trim()) * Convert.ToDecimal(label2.Text.Trim());
						if (this.dropDownList_1.SelectedValue != "" && this.dropDownList_1.SelectedValue.Split(new char[]
						{
							':'
						})[1] == "-1")
						{
							HiddenField hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldFeeType");
							HiddenField hiddenField2 = (HiddenField)repeaterItem.FindControl("HiddenFieldMinusFee");
							if (hiddenField.Value == "1")
							{
								num2 += Convert.ToDecimal(hiddenField2.Value);
								flag = true;
							}
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				try
				{
					num += Convert.ToDecimal(this.dropDownList_1.SelectedValue.Split(new char[]
					{
						':'
					})[0]);
				}
				catch
				{
					num = 0m;
				}
			}
			this.label_4.Text = d2.ToString();
			decimal d3 = 0m;
			string a = string.Empty;
			enumerator = this.repeater_1.Items.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					RepeaterItem repeaterItem2 = (RepeaterItem)enumerator.Current;
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
						this.label_7 = (Label)repeaterItem2.FindControl("LabelCharge");
						d3 = Convert.ToDecimal(this.label_7.Text);
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			if (a == "1")
			{
				if (flag)
				{
					this.label_1.Text = (d + num + (d + num - num2) * d3 / 100m - num2).ToString("n");
				}
				else
				{
					this.label_1.Text = (d + num + (d + num) * d3 / 100m).ToString("n");
				}
			}
			else if (flag)
			{
				this.label_1.Text = (d + num + d3 - num2).ToString("n");
			}
			else
			{
				this.label_1.Text = (d + num + d3).ToString("n");
			}
			if (this.label_2.Text.ToString() == "")
			{
				this.label_2.Text = "0";
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
						((d + num) * d3 / 100m).ToString("n"),
						"</b>元 +运费：<b>",
						num.ToString("n"),
						"</b>元 - 自提货优惠: <b>",
						num2,
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
						((d + num) * d3 / 100m).ToString("n"),
						"</b>元 +运费：<b>",
						num.ToString("n"),
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
					d3.ToString("n"),
					"</b>元 + 运费：<b>",
					num.ToString("n"),
					"</b>元 - 自提货优惠:<b>",
					num2,
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
					d3.ToString("n"),
					"</b>元 + 运费：<b>",
					num.ToString("n"),
					"</b>元 =<b>",
					this.label_1.Text.Replace(",", ""),
					"</b>元"
				});
			}
			this.label_6.Text = this.label_1.Text.Replace(",", "");
		}
		protected void BindReceivingAddress()
		{
			ShopNum1_Address_Action shopNum1_Address_Action = (ShopNum1_Address_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Address_Action();
			DataTable dataTable = shopNum1_Address_Action.Search(this.strMemLoginID, 0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				bool flag = true;
				this.repeater_2.DataSource = dataTable;
				this.repeater_2.DataBind();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (dataTable.Rows[i]["IsDefault"].ToString() == "1")
					{
						flag = false;
						this.hiddenField_3.Value = dataTable.Rows[i]["Guid"].ToString();
						this.hiddenField_1.Value = dataTable.Rows[i]["AddressCode"].ToString();
					}
				}
				if (flag)
				{
					this.hiddenField_3.Value = dataTable.Rows[0]["Guid"].ToString();
					this.hiddenField_1.Value = dataTable.Rows[0]["AddressCode"].ToString();
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Address shopNum1_Address = new ShopNum1_Address();
			if (shopNum1_Address.Mobile != "" && shopNum1_Address.Address != "")
			{
				shopNum1_Address.Guid = Guid.NewGuid();
				shopNum1_Address.Name = this.textBox_0.Text;
				shopNum1_Address.Email = this.textBox_1.Text;
				shopNum1_Address.Address = this.textBox_2.Text;
				shopNum1_Address.Area = this.hiddenField_2.Value;
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
				IShopNum1_Address_Action shopNum1_Address_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_Address_Action();
				int num = shopNum1_Address_Action.Add(shopNum1_Address);
				if (num <= 0)
				{
				}
				this.textBox_0.Text = (this.textBox_5.Text = string.Empty);
				this.hiddenField_1.Value = string.Empty;
				this.hiddenField_2.Value = string.Empty;
				this.textBox_2.Text = string.Empty;
				this.Page.Response.Redirect(this.Page.Request.Url.ToString());
			}
			else
			{
				MessageBox.Show("*号项为必填项！");
			}
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
		protected void IsEmail(string OrderNumber, string MemLoginID, string email)
		{
			if (email != null && !(email == ""))
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
				text = text.Replace("{$ShopName}", "多用户商城系统");
				text = text.Replace("{$SysSendTime}", DateTime.Now.ToString());
				string emailBody = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text));
				SendEmail sendEmail = new SendEmail();
				sendEmail.Emails(email, MemLoginID, emailTitle, text2, emailBody);
			}
		}
		protected void IsMMS(string OrderNumber, string memloginID, string string_5)
		{
			if (!(string_5.Trim() == ""))
			{
				OrderInfo orderInfo = new OrderInfo();
				orderInfo.Name = memloginID;
				orderInfo.OrderNumber = OrderNumber;
				orderInfo.SysSendTime = DateTime.Now.ToString();
				orderInfo.ShopName = ShopSettings.GetValue("Name");
				IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
				DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'CE05437F-75A7-4EE2-8014-4BD992357E51'", 0);
				string text = editInfo.Rows[0]["Remark"].ToString();
				string mMsTitle = editInfo.Rows[0]["Title"].ToString();
				SMS sMS = new SMS();
				string text2 = "";
				text = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text));
				sMS.Send(string_5.Trim(), text, out text2);
				if (text2.IndexOf("发送成功") != -1)
				{
					ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(memloginID, string_5.Trim(), text, mMsTitle, 2, "CE05437F-75A7-4EE2-8014-4BD992357E51");
					shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
				}
				else
				{
					ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(memloginID, string_5.Trim(), text, mMsTitle, 0, "CE05437F-75A7-4EE2-8014-4BD992357E51");
					shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
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
					text = text.Replace("{$UserTel}", strHomeTel);
					text = text.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
					text = text.Replace("{$ProductName}", strProductName);
					text = text.Replace("{$UserMobile}", strMobile);
					OrderInfo orderInfo = new OrderInfo();
					SMS sMS = new SMS();
					text = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text));
					string empty = string.Empty;
					sMS.Send(strTel, text, out empty);
					if (empty.IndexOf("发送成功") != -1)
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(strName, strTel.Trim(), text, mMsTitle, 2, "190D25F8-A9E9-4162-B4E8-0A3954C83473");
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
					else
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(strName, strTel.Trim(), text, mMsTitle, 0, "190D25F8-A9E9-4162-B4E8-0A3954C83473");
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
				}
			}
		}
		protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsContent, string MMsTitle, int state, string mmsGuid)
		{
			return new ShopNum1_MMSGroupSend
			{
				Guid = Guid.NewGuid(),
				MMSTitle = MMsTitle,
				CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
				MMSGuid = new Guid(mmsGuid),
				SendObjectMMS = MMsContent,
				SendObject = memLoginID + "-" + mobile,
				State = state
			};
		}
		private void method_4()
		{
			foreach (RepeaterItem repeaterItem in this.repeater_1.Items)
			{
				RadioButton radioButton = repeaterItem.FindControl("RadioButtonPayment") as RadioButton;
				if (radioButton.Checked)
				{
					HtmlGenericControl htmlGenericControl = repeaterItem.FindControl("guid") as HtmlGenericControl;
					this.hiddenField_7.Value = htmlGenericControl.InnerText;
					this.hiddenField_8.Value = ((Label)repeaterItem.FindControl("LabelName")).Text.Trim();
				}
			}
		}
	}
}
