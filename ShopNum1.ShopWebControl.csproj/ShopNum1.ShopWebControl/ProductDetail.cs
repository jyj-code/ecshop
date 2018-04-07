using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductDetail : BaseWebControl
	{
		private string string_0 = string.Empty;
		private string string_1 = "ProductDetail.ascx";
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private HiddenField hiddenField_2;
		private HiddenField hiddenField_3;
		private Label label_0;
		private Button button_0;
		private Button button_1;
		private Button button_2;
		private Repeater repeater_0;
		private TextBox textBox_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Label label_4;
		private HtmlTableRow htmlTableRow_0;
		private HtmlTableRow htmlTableRow_1;
		private HtmlTableRow htmlTableRow_2;
		private HtmlTableRow htmlTableRow_3;
		private Label label_5;
		private Label label_6;
		private Label label_7;
		private Label label_8;
		private Label label_9;
		private Label label_10;
		private Label label_11;
		private Label label_12;
		private Label label_13;
		private Repeater repeater_1;
		private Repeater repeater_2;
		private Label label_14;
		private Label label_15;
		private HtmlAnchor htmlAnchor_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputHidden htmlInputHidden_3;
		private HtmlInputHidden htmlInputHidden_4;
		private HtmlInputHidden htmlInputHidden_5;
		private HtmlInputHidden htmlInputHidden_6;
		private HtmlInputHidden htmlInputHidden_7;
		private HtmlInputHidden htmlInputHidden_8;
		private HtmlInputHidden htmlInputHidden_9;
		private Literal literal_0;
		private Literal literal_1;
		private Label label_16;
		private Label label_17;
		private Label label_18;
		private Label label_19;
		private Label label_20;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private IShopNum1_SpecProudct_Action ishopNum1_SpecProudct_Action_0 = ShopNum1.Factory.LogicFactory.CreateShopNum1_SpecProudct_Action();
		private IShopNum1_Spec_Action ishopNum1_Spec_Action_0 = ShopNum1.Factory.LogicFactory.CreateShopNum1_Spec_Action();
		private IShopNum1_SpecProudctDetail_Action ishopNum1_SpecProudctDetail_Action_0 = ShopNum1.Factory.LogicFactory.CreateShopNum1_SpecProudctDetail_Action();
		public static DataTable dt_PackAge = null;
		public static string IsLoginId = "";
		private static string string_2 = "";
		public static string Detials = null;
		private DataTable dataTable_0 = null;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		public string ShopName
		{
			get;
			set;
		}
		public string MemberType
		{
			get;
			set;
		}
		public string MemberLoginID
		{
			get;
			set;
		}
		public ProductDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_14 = (Label)skin.FindControl("lblPackSalePrice");
			this.label_15 = (Label)skin.FindControl("lblSavePrice");
			this.label_13 = (Label)skin.FindControl("lblBrand");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("divCombin");
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("undercarriage");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("aviewshow");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("spansaletxt");
			this.label_12 = (Label)skin.FindControl("lblPriceTxt");
			this.label_4 = (Label)skin.FindControl("lblSaleNumber");
			this.label_20 = (Label)skin.FindControl("lblTipDisCount");
			this.label_19 = (Label)skin.FindControl("lblPromotionPrice");
			this.label_18 = (Label)skin.FindControl("lblUnitName");
			this.label_17 = (Label)skin.FindControl("lblCollectCount");
			this.label_16 = (Label)skin.FindControl("lblClickCount");
			this.literal_0 = (Literal)skin.FindControl("lblProductImgUrl");
			this.literal_1 = (Literal)skin.FindControl("literTime");
			this.button_0 = (Button)skin.FindControl("ButtonBuy");
			this.button_1 = (Button)skin.FindControl("ButtonShopCar");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.button_1.Text = "加入购物车";
			this.button_2 = (Button)skin.FindControl("ButtonCollect");
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.button_0 = (Button)skin.FindControl("ButtonBuy");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxBuyNum");
			this.label_1 = (Label)skin.FindControl("LabelName");
			this.label_11 = (Label)skin.FindControl("LabelMarketPrice");
			this.label_2 = (Label)skin.FindControl("LabelShopPrice");
			this.label_3 = (Label)skin.FindControl("LabelRepertoryCount");
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("cellFee1");
			this.htmlTableRow_1 = (HtmlTableRow)skin.FindControl("cellFee2");
			this.htmlTableRow_2 = (HtmlTableRow)skin.FindControl("trDisCount");
			this.label_5 = (Label)skin.FindControl("LabelPost_Fee");
			this.label_6 = (Label)skin.FindControl("LabelExpress_fee");
			this.label_7 = (Label)skin.FindControl("LabelEms_fee");
			this.label_8 = (Label)skin.FindControl("LabelPost");
			this.label_9 = (Label)skin.FindControl("LabelExpress");
			this.label_10 = (Label)skin.FindControl("LabelEms");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterDateImage");
			this.htmlTableRow_3 = (HtmlTableRow)skin.FindControl("trShopPrice");
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("cellFee1");
			this.htmlTableRow_1 = (HtmlTableRow)skin.FindControl("cellFee2");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidShopName");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidMemloginId");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidFeeType");
			this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("hidSaleType");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidIsReal");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidProductNum");
			this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("hidFeeTemplate");
			this.htmlInputHidden_7 = (HtmlInputHidden)skin.FindControl("hidDisCount");
			this.htmlInputHidden_8 = (HtmlInputHidden)skin.FindControl("hidProductImgurl");
			this.htmlInputHidden_9 = (HtmlInputHidden)skin.FindControl("hidCityCode");
			this.label_0 = (Label)skin.FindControl("lblFee");
			if (this.Page.Request.QueryString["ShopID"] != null)
			{
				this.Page.Request.QueryString["ShopID"].ToString();
			}
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterProductSepc");
			this.repeater_1.ItemDataBound += new RepeaterItemEventHandler(this.repeater_1_ItemDataBound);
			this.hiddenField_2 = (HiddenField)skin.FindControl("HiddenFieldSpecName");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldGuiGe");
			this.hiddenField_3 = (HiddenField)skin.FindControl("HiddenFieldGuiGev");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGuid");
			this.hiddenField_0.Value = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"]);
			this.method_0();
			if (!this.Page.IsPostBack)
			{
				this.BindClickCount();
			}
			Func<bool> func = new Func<bool>(this.method_2);
			func();
			this.Product_Browse();
		}
		public void Product_Browse()
		{
			try
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
			}
			catch (Exception)
			{
			}
			DataTable tableById = ShopNum1.Common.Common.GetTableById("OriginalImage,MemLoginID", "ShopNum1_Shop_Product", "   AND  Guid='" + this.Page.Request.QueryString["guid"].ToString() + "'");
			string productImage = "";
			string text = "";
			if (tableById.Rows.Count > 0)
			{
				productImage = tableById.Rows[0]["OriginalImage"].ToString();
				text = tableById.Rows[0]["MemLoginID"].ToString();
			}
			if (!string.IsNullOrEmpty(this.MemberLoginID) && text != this.MemberLoginID)
			{
				try
				{
					ShopNum1_ShopProduct_Browse_Action shopNum1_ShopProduct_Browse_Action = (ShopNum1_ShopProduct_Browse_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopProduct_Browse_Action();
					bool dataByMemLoginID;
					if (!(dataByMemLoginID = shopNum1_ShopProduct_Browse_Action.GetDataByMemLoginID(this.Page.Request.QueryString["guid"].ToString(), this.MemberLoginID)))
					{
						shopNum1_ShopProduct_Browse_Action.Add(new ShopNum1_ShopProduct_Browse
						{
							BrowseDateTime = new DateTime?(DateTime.Now),
							BrowseTimes = new int?(1),
							Guid = new Guid?(Guid.NewGuid()),
							MemLoginID = this.MemberLoginID,
							Name = this.label_1.Text,
							ProductGuid = new Guid?(new Guid(this.Page.Request.QueryString["guid"].ToString())),
							ProductImage = productImage,
							ShopID = text,
							ShopPrice = new decimal?(Convert.ToDecimal(this.label_2.Text))
						});
					}
					else if (dataByMemLoginID)
					{
						shopNum1_ShopProduct_Browse_Action.AddTimes(this.Page.Request.QueryString["guid"].ToString(), this.MemberLoginID);
					}
				}
				catch (Exception)
				{
				}
			}
		}
		private void repeater_1_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				try
				{
					this.repeater_2 = (Repeater)e.Item.FindControl("RepeaterProductSepcDetail");
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < this.dataTable_0.Rows.Count; i++)
					{
						string text = this.dataTable_0.Rows[i]["specdetail"].ToString().Split(new char[]
						{
							'|'
						})[e.Item.ItemIndex].Split(new char[]
						{
							','
						})[1];
						if (i <= 0 || !(text == this.dataTable_0.Rows[i - 1]["specdetail"].ToString().Split(new char[]
						{
							'|'
						})[e.Item.ItemIndex].Split(new char[]
						{
							','
						})[1]))
						{
							stringBuilder.Append(text + ",");
						}
					}
					if (stringBuilder.ToString() != "")
					{
						DataTable detailByDGuid = this.ishopNum1_SpecProudctDetail_Action_0.GetDetailByDGuid(stringBuilder.ToString().Substring(0, stringBuilder.Length - 1), this.hiddenField_0.Value);
						this.repeater_2.DataSource = detailByDGuid;
						this.repeater_2.DataBind();
					}
					else
					{
						this.repeater_1.DataSource = this.dataTable_0.DefaultView;
						this.repeater_1.DataBind();
					}
				}
				catch
				{
				}
			}
		}
		protected void BindClickCount()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
			shop_Product_Action.UpdateClickCountByGuid(this.hiddenField_0.Value.Replace("'", ""));
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				string text = this.Page.Request.Url.ToString().Replace("%3a%2f%2f", "://").Replace("/", "%2f").Replace("&", "%26");
				this.Page.RegisterClientScriptBlock("script", string.Concat(new string[]
				{
					"<script>$(function(){ $('#loginbox').show();$('#mylogingo').attr('src','http://",
					ShopSettings.siteDomain,
					"/poplogin.html?vj=shopcar&backurl=",
					text,
					"'); });</script>"
				}));
			}
			else
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
				if (this.htmlInputHidden_1.Value == this.MemberLoginID)
				{
					MessageBox.Show("您不能购买自己的商品！");
				}
				else
				{
					if (this.htmlInputHidden_6.Value == "4")
					{
						Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
						if (shop_Product_Action.CheckMenberBuyProduct(ShopNum1.Common.Common.ReqStr("guid"), this.MemberLoginID).Rows.Count > 0)
						{
							MessageBox.Show("您已经购买过");
							return;
						}
						this.textBox_0.Text = "1";
					}
					if (int.Parse(this.textBox_0.Text) <= 0)
					{
						MessageBox.Show("请正确填写购买数量!");
					}
					else if (int.Parse(this.label_3.Text.Trim().ToString()) < int.Parse(this.textBox_0.Text))
					{
						MessageBox.Show("商品库存不足！");
					}
					else
					{
						HttpCookie httpCookie2 = new HttpCookie("SpecificationCookie");
						httpCookie2.Values.Add("SpecName", HttpUtility.HtmlEncode(this.hiddenField_2.Value.Replace("/", "-").TrimEnd(new char[]
						{
							'0'
						})));
						httpCookie2.Values.Add("SpecValue", this.hiddenField_3.Value.Trim(new char[]
						{
							';'
						}).Replace(":", ",").Replace(";", "|"));
						httpCookie2.Values.Add("ShopName", this.htmlInputHidden_0.Value);
						httpCookie2.Values.Add("ShopId", this.htmlInputHidden_1.Value);
						string value = this.label_2.Text;
						if (!string.IsNullOrEmpty(this.hiddenField_3.Value))
						{
							DataTable specificationByProduct = this.ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(this.hiddenField_0.Value, this.hiddenField_3.Value.Replace(":", ",").Replace(";", "|").TrimEnd(new char[]
							{
								';'
							}).TrimEnd(new char[]
							{
								'|'
							}));
							if (specificationByProduct != null && specificationByProduct.Rows.Count > 0 && specificationByProduct.Rows[0]["GoodsPrice"].ToString() != "")
							{
								value = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
							}
						}
						if (this.htmlTableRow_2.Visible)
						{
							if (this.htmlInputHidden_6.Value == "2")
							{
								decimal d = Convert.ToDecimal(value) * Convert.ToDecimal(this.htmlInputHidden_7.Value);
								httpCookie2.Values.Add("Price", Math.Round(d, 2).ToString());
							}
							else if (this.htmlInputHidden_6.Value == "1")
							{
								httpCookie2.Values.Add("Price", this.label_19.Text);
							}
						}
						else
						{
							httpCookie2.Values.Add("Price", value);
						}
						if (this.label_12.Text == "抢 购 价：")
						{
							this.htmlInputHidden_6.Value = "4";
						}
						httpCookie2.Values.Add("SaleType", this.htmlInputHidden_6.Value);
						HttpCookie httpCookie3 = HttpSecureCookie.Encode(httpCookie2);
						httpCookie3.Expires = DateTime.Now.ToLocalTime().AddDays(1.0);
						httpCookie3.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
						this.Page.Response.AppendCookie(httpCookie3);
						if (this.Page.Request.Cookies["PackAgeCookie"] != null)
						{
							HttpCookie httpCookie4 = this.Page.Request.Cookies["PackAgeCookie"];
							httpCookie4.Values.Clear();
							httpCookie4.Expires = DateTime.Now.ToLocalTime().AddDays(-6.0);
							httpCookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
							this.Page.Response.Cookies.Add(httpCookie4);
						}
						string text2 = "";
						try
						{
							text2 = this.htmlInputHidden_9.Value;
						}
						catch
						{
						}
						string substationID = string.Empty;
						try
						{
							string str = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
							substationID = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  ShopID='" + str + "'    ");
						}
						catch (Exception)
						{
						}
						this.Page.Response.Redirect(GetPageName.GetMainPage(string.Concat(new string[]
						{
							"ConfirmOrder.html?ProductionGuid=",
							this.hiddenField_0.Value,
							"&num=",
							this.textBox_0.Text,
							"&Code=",
							text2
						}), substationID));
					}
				}
			}
		}
		private void button_2_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
				Shop_Collect_Action shop_Collect_Action = (Shop_Collect_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Collect_Action();
				if (this.htmlInputHidden_1.Value == this.MemberLoginID)
				{
					MessageBox.Show("您不能收藏自己的商品！");
				}
				else if (shop_Collect_Action.AddProductCollect(this.MemberLoginID, this.hiddenField_0.Value, this.htmlInputHidden_0.Value, "0", this.label_2.Text, this.label_1.Text, this.htmlInputHidden_1.Value) > 0)
				{
					MessageBox.Show("收藏成功!");
					shop_Collect_Action.ProductCollectNum(this.hiddenField_0.Value);
					this.method_0();
				}
				else
				{
					MessageBox.Show("已收藏过该商品!");
				}
			}
			else
			{
				this.Page.RegisterClientScriptBlock("script", "<script>$(function(){$('#mylogingo').attr('src','http://" + ShopSettings.siteDomain + "/poplogin.html?vj=shopcar');  $('#loginbox').show();});</script>");
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
				httpCookie.Values["MemberType"].ToString();
				if (this.htmlInputHidden_6.Value == "4")
				{
					Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
					if (shop_Product_Action.CheckMenberBuyProduct(ShopNum1.Common.Common.ReqStr("guid"), this.MemberLoginID).Rows.Count > 0)
					{
						MessageBox.Show("您已经购买过");
						return;
					}
					this.textBox_0.Text = "1";
				}
				this.AddShopCar(this.MemberLoginID);
			}
			else
			{
				string myMemLoginID = string.Empty;
				if (this.Page.Request.Cookies["Visitor_LoginCookie"] != null)
				{
					HttpCookie cookie = this.Page.Request.Cookies["Visitor_LoginCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					myMemLoginID = httpCookie.Values["MemLoginID"].ToString();
				}
				else
				{
					Order order = new Order();
					string text = "visitor_" + order.CreateOrderNumber();
					HttpCookie httpCookie2 = HttpSecureCookie.Encode(new HttpCookie("Visitor_LoginCookie")
					{
						Values = 
						{

							{
								"MemLoginID",
								text
							}
						}
					});
					httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
					this.Page.Response.AppendCookie(httpCookie2);
					myMemLoginID = text;
				}
				this.AddShopCar(myMemLoginID);
			}
		}
		public void AddShopCar(string MyMemLoginID)
		{
			bool flag = false;
			try
			{
				if (int.Parse(this.textBox_0.Text) > 0)
				{
					flag = true;
				}
				else
				{
					MessageBox.Show("请正确填写购买数量!");
				}
				if (int.Parse(this.label_3.Text.Trim().ToString()) < int.Parse(this.textBox_0.Text))
				{
					MessageBox.Show("商品库存不足！");
					return;
				}
				if (this.htmlInputHidden_1.Value == MyMemLoginID)
				{
					MessageBox.Show("您不能添加自己的商品！");
					return;
				}
			}
			catch (Exception)
			{
				MessageBox.Show("请正确填写购买数量!");
			}
			if (flag)
			{
				ShopNum1_Shop_Cart shopNum1_Shop_Cart = new ShopNum1_Shop_Cart();
				shopNum1_Shop_Cart.Guid = Guid.NewGuid();
				shopNum1_Shop_Cart.MemLoginID = MyMemLoginID;
				shopNum1_Shop_Cart.ProductGuid = new Guid(this.hiddenField_0.Value);
				shopNum1_Shop_Cart.OriginalImge = this.htmlInputHidden_8.Value;
				shopNum1_Shop_Cart.Name = this.label_1.Text;
				shopNum1_Shop_Cart.RepertoryNumber = this.htmlInputHidden_4.Value;
				shopNum1_Shop_Cart.BuyNumber = int.Parse(this.textBox_0.Text);
				shopNum1_Shop_Cart.MarketPrice = decimal.Parse(this.label_11.Text.Trim());
				string s = this.label_2.Text;
				if (!string.IsNullOrEmpty(this.hiddenField_3.Value))
				{
					DataTable specificationByProduct = this.ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(this.hiddenField_0.Value, this.hiddenField_3.Value.Replace(":", ",").Replace(";", "|").TrimEnd(new char[]
					{
						';'
					}).TrimEnd(new char[]
					{
						'|'
					}));
					if (specificationByProduct != null && specificationByProduct.Rows.Count > 0 && specificationByProduct.Rows[0]["GoodsPrice"].ToString() != "")
					{
						s = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
					}
				}
				shopNum1_Shop_Cart.ShopPrice = decimal.Parse(s);
				shopNum1_Shop_Cart.Attributes = ProductDetail.string_2;
				if (!string.IsNullOrEmpty(this.hiddenField_3.Value))
				{
					DataTable specificationByProduct = this.ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(this.hiddenField_0.Value, this.hiddenField_3.Value.Replace(":", ",").Replace(";", "|").TrimEnd(new char[]
					{
						';'
					}).TrimEnd(new char[]
					{
						'|'
					}));
					if (specificationByProduct != null && specificationByProduct.Rows.Count > 0)
					{
						shopNum1_Shop_Cart.BuyPrice = Convert.ToDecimal(specificationByProduct.Rows[0]["GoodsPrice"].ToString());
					}
					else
					{
						shopNum1_Shop_Cart.BuyPrice = decimal.Parse(this.label_2.Text.Trim());
					}
				}
				else
				{
					shopNum1_Shop_Cart.BuyPrice = decimal.Parse(this.label_2.Text.Trim());
				}
				if (this.htmlTableRow_2.Visible)
				{
					if (this.htmlInputHidden_6.Value == "1")
					{
						shopNum1_Shop_Cart.BuyPrice = decimal.Parse(this.label_19.Text);
					}
					else if (this.htmlInputHidden_6.Value == "2")
					{
						decimal d = Convert.ToDecimal(this.label_2.Text) * Convert.ToDecimal(this.htmlInputHidden_7.Value);
						shopNum1_Shop_Cart.BuyPrice = Math.Round(d, 2);
					}
				}
				if (this.label_12.Text == "抢 购 价：")
				{
					this.htmlInputHidden_6.Value = "4";
				}
				shopNum1_Shop_Cart.IsShipment = 0;
				shopNum1_Shop_Cart.IsReal = int.Parse(this.htmlInputHidden_3.Value);
				shopNum1_Shop_Cart.ExtensionAttriutes = "";
				shopNum1_Shop_Cart.IsJoinActivity = 0;
				shopNum1_Shop_Cart.CartType = Convert.ToInt32(this.htmlInputHidden_6.Value);
				shopNum1_Shop_Cart.IsPresent = 0;
				shopNum1_Shop_Cart.CreateTime = DateTime.Now;
				shopNum1_Shop_Cart.DetailedSpecifications = "";
				shopNum1_Shop_Cart.ShopID = this.htmlInputHidden_1.Value;
				shopNum1_Shop_Cart.SellName = this.htmlInputHidden_0.Value;
				shopNum1_Shop_Cart.FeeType = new int?(int.Parse(this.htmlInputHidden_2.Value));
				if (this.hiddenField_1.Value.Length > 1)
				{
					if (this.hiddenField_1.Value.Trim(new char[]
					{
						';'
					}) != "0")
					{
						shopNum1_Shop_Cart.SpecificationValue = this.hiddenField_3.Value.Trim(new char[]
						{
							';'
						}).Replace(":", ",").Replace(";", "|");
					}
					if (this.hiddenField_2.Value.Trim(new char[]
					{
						';'
					}) != "0")
					{
						shopNum1_Shop_Cart.SpecificationName = this.hiddenField_2.Value.TrimEnd(new char[]
						{
							';'
						}).Replace("/", "-").TrimEnd(new char[]
						{
							'0'
						});
					}
				}
				if (this.htmlInputHidden_2.Value == "1")
				{
					shopNum1_Shop_Cart.Post_fee = new decimal?(0m);
					shopNum1_Shop_Cart.Ems_fee = new decimal?(0m);
					shopNum1_Shop_Cart.Express_fee = new decimal?(0m);
				}
				else
				{
					shopNum1_Shop_Cart.Post_fee = new decimal?(decimal.Parse(this.label_5.Text));
					shopNum1_Shop_Cart.Ems_fee = new decimal?(decimal.Parse(this.label_7.Text));
					shopNum1_Shop_Cart.Express_fee = new decimal?(decimal.Parse(this.label_6.Text));
				}
				ShopNum1_Cart_Action shopNum1_Cart_Action = (ShopNum1_Cart_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
				int num;
				if (shopNum1_Shop_Cart.SellName != "")
				{
					num = shopNum1_Cart_Action.AddCart(shopNum1_Shop_Cart);
				}
				else
				{
					num = 1;
				}
				if (num > 0)
				{
					string str = string.Empty;
					string text = string.Empty;
					try
					{
						string str2 = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
						str = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  ShopID='" + str2 + "'    ");
						text = ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "   AND   SubstationID='" + str + "'    ");
					}
					catch (Exception)
					{
					}
					this.Page.Response.Redirect(string.Concat(new string[]
					{
						"http://",
						text,
						ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')),
						"/ShoppingCart1.aspx?gocityurl=",
						text
					}));
					MessageBox.Show("添加成功!");
				}
				else
				{
					MessageBox.Show("添加失败!");
				}
			}
		}
		public static string IsBegin(object begin, object object_0)
		{
			string result;
			if (DateTime.Parse(begin.ToString()) > DateTime.Now)
			{
				result = begin.ToString();
			}
			else
			{
				result = object_0.ToString();
			}
			return result;
		}
		private void method_0()
		{
			IShop_Product_Action shop_Product_Action = ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
			string shopid = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			DataSet productInfoByGuidAndMemLoginID = shop_Product_Action.GetProductInfoByGuidAndMemLoginID(this.hiddenField_0.Value, "");
			if (productInfoByGuidAndMemLoginID.Tables[0].Rows.Count == 0)
			{
				string url = "http://" + HttpContext.Current.Request.Url.Host + "/NoFind.aspx";
				this.Page.Response.Redirect(url);
			}
			else
			{
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
				string str = shop_ShopInfo_Action.GetMemberLoginidByShopid(shopid).ToString();
				if (productInfoByGuidAndMemLoginID.Tables[0].Select("memloginID='" + str + "'").Count<DataRow>() == 0)
				{
					string url = "http://" + HttpContext.Current.Request.Url.Host + "/NoFind.aspx";
					this.Page.Response.Redirect(url);
				}
			}
			string a = productInfoByGuidAndMemLoginID.Tables[0].Rows[0]["IsSaled"].ToString();
			string a2 = productInfoByGuidAndMemLoginID.Tables[0].Rows[0]["IsSell"].ToString();
			if (a2 == "0" || a == "0")
			{
				this.button_0.Visible = false;
				this.button_1.Visible = false;
				this.htmlGenericControl_2.Visible = true;
			}
			ProductDetail.dt_PackAge = productInfoByGuidAndMemLoginID.Tables[1];
			if (ProductDetail.dt_PackAge.Rows.Count == 0)
			{
				ProductDetail.dt_PackAge = null;
			}
			DataTable dataTable = productInfoByGuidAndMemLoginID.Tables[2];
			if (dataTable.Rows.Count > 0)
			{
				this.label_14.Text = dataTable.Rows[0]["SalePrice"].ToString();
				this.label_15.Text = (Convert.ToDecimal(dataTable.Rows[0]["Price"].ToString()) - Convert.ToDecimal(dataTable.Rows[0]["SalePrice"].ToString())).ToString();
				this.htmlAnchor_0.Target = "_blank";
				this.htmlAnchor_0.InnerText = "查看套餐";
				this.htmlAnchor_0.Attributes.Add("class", "tb-view");
				this.htmlAnchor_0.HRef = string.Concat(new object[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/Combination.html?pid=",
					this.hiddenField_0.Value,
					"&packid=",
					dataTable.Rows[0]["id"],
					"&action=viewpackage"
				});
			}
			else
			{
				this.htmlGenericControl_1.Visible = false;
			}
			DataTable dataTable2 = productInfoByGuidAndMemLoginID.Tables[0];
			if (dataTable2.Rows[0]["isreal"].ToString() == "0")
			{
				this.button_1.Visible = false;
			}
			this.label_17.Text = dataTable2.Rows[0]["collectcount"].ToString();
			ProductDetail.string_2 = dataTable2.Rows[0]["setStock"].ToString();
			this.label_18.Text = dataTable2.Rows[0]["unitname"].ToString();
			this.label_13.Text = dataTable2.Rows[0]["brandname"].ToString();
			this.hiddenField_1.Value = dataTable2.Rows[0]["setstock"].ToString();
			this.label_4.Text = dataTable2.Rows[0]["salenumber"].ToString();
			this.label_1.Text = dataTable2.Rows[0]["name"].ToString();
			this.htmlInputHidden_8.Value = this.Page.ResolveUrl(dataTable2.Rows[0]["Originalimage"].ToString());
			this.literal_0.Text = string.Concat(new string[]
			{
				"<img id=\"ProductImgurl\" src='",
				this.Page.ResolveUrl(dataTable2.Rows[0]["OriginalImage"].ToString()),
				"_300x300.jpg' width=\"300\" height=\"300\" onerror=\"javascript:this.src='/ImgUpload/noImg.jpg_300x300.jpg'\" jqimg='",
				this.Page.ResolveUrl(dataTable2.Rows[0]["OriginalImage"].ToString()),
				"' />"
			});
			this.htmlInputHidden_2.Value = dataTable2.Rows[0]["FeeType"].ToString();
			this.label_0.Text = ProductDetail.IsFeeType(this.htmlInputHidden_2.Value) + "承担";
			this.label_11.Text = dataTable2.Rows[0]["MarketPrice"].ToString();
			this.label_2.Text = dataTable2.Rows[0]["ShopPrice"].ToString();
			this.label_5.Text = dataTable2.Rows[0]["Post_fee"].ToString();
			this.label_6.Text = dataTable2.Rows[0]["Express_fee"].ToString();
			this.label_7.Text = dataTable2.Rows[0]["Ems_fee"].ToString();
			this.label_3.Text = dataTable2.Rows[0]["RepertoryCount"].ToString();
			if (Convert.ToInt32(this.label_3.Text) < 0)
			{
				this.label_3.Text = "0";
				this.button_0.Enabled = false;
				this.button_1.Visible = false;
			}
			this.label_16.Text = dataTable2.Rows[0]["ClickCount"].ToString();
			this.htmlInputHidden_5.Value = dataTable2.Rows[0]["FeeTemplateID"].ToString();
			this.htmlInputHidden_2.Value = dataTable2.Rows[0]["FeeType"].ToString();
			this.htmlInputHidden_4.Value = dataTable2.Rows[0]["ProductNum"].ToString();
			this.htmlInputHidden_0.Value = dataTable2.Rows[0]["ShopName"].ToString();
			this.htmlInputHidden_1.Value = dataTable2.Rows[0]["MemloginId"].ToString();
			this.htmlInputHidden_3.Value = dataTable2.Rows[0]["IsReal"].ToString();
			string text = dataTable2.Rows[0]["groupprice"].ToString();
			if (dataTable2.Rows[0]["productstate"].ToString() == "1" && Convert.ToDateTime(dataTable2.Rows[0]["starttime"].ToString()) >= DateTime.Now.ToLocalTime())
			{
				this.label_12.Text = "抢 购 价：";
				this.htmlInputHidden_6.Value = "4";
				this.label_1.Text = this.label_1.Text + "[抢购尚未开始]";
				this.button_0.Enabled = false;
			}
			else if (dataTable2.Rows[0]["productstate"].ToString() == "1" && Convert.ToDateTime(dataTable2.Rows[0]["endtime"].ToString()) >= DateTime.Now.ToLocalTime())
			{
				this.label_12.Text = "抢 购 价：";
				this.htmlInputHidden_6.Value = "4";
				this.label_1.Text = this.label_1.Text + "[抢购进行中...]";
				this.button_1.Visible = false;
			}
			else if (dataTable2.Rows[0]["productstate"].ToString() == "1")
			{
				this.label_12.Text = "抢 购 价：";
				this.htmlInputHidden_6.Value = "4";
				this.label_1.Text = this.label_1.Text + "[抢购时间已结束]";
				this.button_0.Enabled = false;
			}
			if (text != "")
			{
				this.htmlGenericControl_0.InnerText = "团购";
				DateTime dateTime = Convert.ToDateTime(dataTable2.Rows[0]["gstart"].ToString());
				DateTime dateTime2 = Convert.ToDateTime(dataTable2.Rows[0]["gend"].ToString());
				DateTime now = DateTime.Now;
				if (now <= dateTime2)
				{
					if (now > dateTime)
					{
						this.label_3.Text = dataTable2.Rows[0]["groupstock"].ToString();
						this.htmlTableRow_3.Visible = false;
						this.htmlTableRow_2.Visible = true;
						this.button_1.Visible = false;
						this.htmlInputHidden_6.Value = "1";
						this.label_19.Text = text;
						this.label_20.Text = "(" + this.method_1(now, dateTime2) + "后结束)";
						this.literal_1.Text = "<script>show_date_time('" + ProductDetail.IsBegin(dateTime, dateTime2).Replace("-", "/") + "','spTimego','后结束');</script>";
					}
					else
					{
						this.label_20.Text = "(" + this.method_1(dateTime, now) + "后开始)";
						this.literal_1.Text = "<script>show_date_time('" + ProductDetail.IsBegin(dateTime, dateTime2).Replace("-", "/") + "','spTimego','后开始');</script>";
					}
				}
				else
				{
					this.htmlTableRow_2.Visible = false;
				}
			}
			string value = dataTable2.Rows[0]["discount"].ToString();
			if (!string.IsNullOrEmpty(value) && ShopNum1.Common.Common.ReqStr("type") != "tg")
			{
				this.htmlGenericControl_0.InnerText = "限时折扣";
				DateTime dateTime = Convert.ToDateTime(dataTable2.Rows[0]["dstart"].ToString());
				DateTime dateTime2 = Convert.ToDateTime(dataTable2.Rows[0]["dend"].ToString());
				DateTime now = DateTime.Now;
				if (now <= dateTime2)
				{
					this.htmlInputHidden_7.Value = value;
					this.htmlTableRow_2.Visible = true;
					decimal d = Convert.ToDecimal(this.label_2.Text) * Convert.ToDecimal(value);
					this.label_19.Text = Math.Round(d, 2).ToString();
					if (now > dateTime)
					{
						this.htmlInputHidden_6.Value = "2";
						this.button_1.Visible = false;
						this.label_20.Text = "(" + this.method_1(now, dateTime2) + "后结束)";
						this.literal_1.Text = "<script>show_date_time('" + ProductDetail.IsBegin(dateTime, dateTime2).Replace("-", "/") + "','spTimego','后结束');</script>";
					}
					else
					{
						this.label_20.Text = "(" + this.method_1(dateTime, now).Replace("-", "") + "后开始)";
						this.literal_1.Text = "<script>show_date_time('" + ProductDetail.IsBegin(dateTime, dateTime2).Replace("-", "/") + "','spTimego','后开始');</script>";
					}
				}
				else
				{
					this.htmlTableRow_2.Visible = false;
				}
			}
			if (this.htmlInputHidden_2.Value == "0")
			{
				this.htmlTableRow_0.Visible = false;
				this.htmlTableRow_1.Visible = true;
				if (this.label_5.Text != "0.00")
				{
					this.label_5.Visible = true;
					this.label_8.Visible = true;
				}
				if (this.label_6.Text != "0.00")
				{
					this.label_6.Visible = true;
					this.label_9.Visible = true;
				}
				if (this.label_7.Text != "0.00")
				{
					this.label_7.Visible = true;
					this.label_10.Visible = true;
				}
			}
			else
			{
				this.htmlTableRow_0.Visible = true;
				this.htmlTableRow_1.Visible = false;
			}
			string[] array = dataTable2.Rows[0]["multiimages"].ToString().Split(new char[]
			{
				','
			});
			DataTable dataTable3 = new DataTable();
			DataColumn dataColumn = new DataColumn();
			dataColumn.ColumnName = "imgurl";
			dataColumn.DataType = Type.GetType("System.String");
			dataTable3.Columns.Add(dataColumn);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != "")
				{
					DataRow dataRow = dataTable3.NewRow();
					dataRow["imgurl"] = array[i].Replace("~/", "/");
					dataTable3.Rows.Add(dataRow);
				}
			}
			this.repeater_0.DataSource = dataTable3;
			this.repeater_0.DataBind();
		}
		private string method_1(DateTime dateTime_0, DateTime dateTime_1)
		{
			TimeSpan timeSpan = dateTime_1.Subtract(dateTime_0);
			return string.Concat(new object[]
			{
				timeSpan.Days,
				"天",
				timeSpan.Hours,
				"时",
				timeSpan.Minutes,
				"分",
				timeSpan.Seconds,
				"秒"
			});
		}
		public static string IsShow(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "0")
			{
				result = "否";
			}
			else if (a == "1")
			{
				result = "是";
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string IsFeeType(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "0")
			{
				result = "买家";
			}
			else if (a == "1")
			{
				result = "卖家";
			}
			else
			{
				result = "";
			}
			return result;
		}
		[CompilerGenerated]
		private bool method_2()
		{
			bool result;
			if (this.hiddenField_0.Value != string.Empty)
			{
				this.dataTable_0 = this.ishopNum1_SpecProudct_Action_0.dt_SpecProducts(this.hiddenField_0.Value);
				if (this.dataTable_0.Rows.Count > 0)
				{
					DataTable dataTable = this.ishopNum1_Spec_Action_0.SearchNameByGuid(this.hiddenField_0.Value);
					if (dataTable.Rows.Count > 0)
					{
						this.repeater_1.DataSource = dataTable;
						this.repeater_1.DataBind();
					}
					if (this.repeater_1.Items.Count > 0)
					{
						HtmlGenericControl htmlGenericControl = (HtmlGenericControl)this.repeater_1.Controls[this.repeater_1.Controls.Count - 1].FindControl("spanNoSelect");
						string text = string.Empty;
						foreach (DataRow dataRow in dataTable.Rows)
						{
							text = text + "\"" + dataRow["specname"].ToString() + "\" ";
						}
						htmlGenericControl.InnerHtml = text;
					}
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
