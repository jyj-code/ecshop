using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_OpGoods2 : BaseShopWebControl, IPostBackEventHandler
	{
		private string string_0 = "S_OpGoods2.ascx";
		private Button button_0;
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
		private HtmlInputHidden htmlInputHidden_10;
		private HtmlInputHidden htmlInputHidden_11;
		private HtmlInputHidden htmlInputHidden_12;
		private HtmlInputHidden htmlInputHidden_13;
		private HtmlInputHidden htmlInputHidden_14;
		private HtmlInputHidden htmlInputHidden_15;
		private HtmlInputHidden htmlInputHidden_16;
		private HtmlInputHidden htmlInputHidden_17;
		private HtmlInputHidden htmlInputHidden_18;
		private HtmlInputHidden htmlInputHidden_19;
		private HtmlInputHidden htmlInputHidden_20;
		private HtmlInputHidden htmlInputHidden_21;
		private HtmlInputHidden htmlInputHidden_22;
		private HtmlInputHidden htmlInputHidden_23;
		private HtmlInputHidden htmlInputHidden_24;
		private HtmlInputHidden htmlInputHidden_25;
		private HtmlInputHidden htmlInputHidden_26;
		private HtmlInputHidden htmlInputHidden_27;
		private HtmlInputHidden htmlInputHidden_28;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlTextArea htmlTextArea_0;
		private HtmlTextArea htmlTextArea_1;
		private HtmlTextArea htmlTextArea_2;
		private HtmlInputHidden htmlInputHidden_29;
		private HtmlInputText htmlInputText_4;
		private HtmlInputText htmlInputText_5;
		private HtmlInputText htmlInputText_6;
		private HtmlInputHidden htmlInputHidden_30;
		private HtmlInputHidden htmlInputHidden_31;
		private HtmlInputHidden htmlInputHidden_32;
		private Label label_0;
		private HtmlInputHidden htmlInputHidden_33;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private HtmlTextArea htmlTextArea_3;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private Shop_Product_Action shop_Product_Action_0 = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
		public S_OpGoods2()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			try
			{
				this.htmlTextArea_3 = (HtmlTextArea)skin.FindControl("txtPanicDetail");
				this.repeater_0 = (Repeater)skin.FindControl("repShopType");
				this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
				this.string_1 = ShopNum1.Common.Common.ReqStr("pid");
				this.string_2 = ShopNum1.Common.Common.ReqStr("ctype");
				this.string_3 = ShopNum1.Common.Common.ReqStr("code");
				this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidIsReal");
				this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidPType");
				this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidCategoryName");
				this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidName");
				this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidProductNum");
				this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("hidRepertoryCount");
				this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("hidShopPrice");
				this.htmlInputHidden_7 = (HtmlInputHidden)skin.FindControl("hidMarketPrice");
				this.htmlInputHidden_8 = (HtmlInputHidden)skin.FindControl("hidUnitName");
				this.htmlInputHidden_9 = (HtmlInputHidden)skin.FindControl("hidBrand");
				this.htmlInputHidden_12 = (HtmlInputHidden)skin.FindControl("hidState");
				this.htmlInputHidden_10 = (HtmlInputHidden)skin.FindControl("hidSpec_Check");
				this.htmlInputHidden_11 = (HtmlInputHidden)skin.FindControl("hidBaseStock");
				this.htmlInputHidden_24 = (HtmlInputHidden)skin.FindControl("hidProductSeries");
				this.htmlInputHidden_13 = (HtmlInputHidden)skin.FindControl("hidhandinput");
				this.htmlInputHidden_14 = (HtmlInputHidden)skin.FindControl("hidtxtinput");
				this.htmlInputHidden_15 = (HtmlInputHidden)skin.FindControl("hidradio");
				this.htmlInputHidden_16 = (HtmlInputHidden)skin.FindControl("hidselect");
				this.htmlInputHidden_17 = (HtmlInputHidden)skin.FindControl("hidlist");
				this.htmlInputHidden_18 = (HtmlInputHidden)skin.FindControl("hidBaseProp");
				this.htmlInputHidden_19 = (HtmlInputHidden)skin.FindControl("hidpro_img");
				this.htmlInputHidden_20 = (HtmlInputHidden)skin.FindControl("hidproImage");
				this.htmlInputHidden_21 = (HtmlInputHidden)skin.FindControl("hidarea");
				this.htmlInputHidden_22 = (HtmlInputHidden)skin.FindControl("hidpublishGoods");
				this.htmlInputHidden_23 = (HtmlInputHidden)skin.FindControl("hidisPanic");
				this.htmlInputHidden_25 = (HtmlInputHidden)skin.FindControl("hidfee");
				this.htmlInputHidden_26 = (HtmlInputHidden)skin.FindControl("hidsubfee");
				this.htmlInputHidden_27 = (HtmlInputHidden)skin.FindControl("hidsubStock");
				this.htmlInputHidden_32 = (HtmlInputHidden)skin.FindControl("hidTipMsg");
				this.htmlInputHidden_28 = (HtmlInputHidden)skin.FindControl("hidRepertoryAlertCount");
				this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtSendTime");
				this.htmlInputText_2 = (HtmlInputText)skin.FindControl("Panic_endtime");
				this.htmlInputText_1 = (HtmlInputText)skin.FindControl("Panic_starttime");
				this.htmlInputText_3 = (HtmlInputText)skin.FindControl("txtKeyword");
				this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txtDetail");
				this.htmlTextArea_2 = (HtmlTextArea)skin.FindControl("txtDesc");
				this.htmlTextArea_1 = (HtmlTextArea)skin.FindControl("txtWapDetail");
				this.htmlInputText_4 = (HtmlInputText)skin.FindControl("txtPost_fee");
				this.htmlInputText_5 = (HtmlInputText)skin.FindControl("txtExpress_fee");
				this.htmlInputText_6 = (HtmlInputText)skin.FindControl("txtEms_fee");
				this.htmlInputHidden_29 = (HtmlInputHidden)skin.FindControl("hidfee_template");
				this.htmlInputHidden_30 = (HtmlInputHidden)skin.FindControl("hidNewSpecs");
				this.htmlInputHidden_31 = (HtmlInputHidden)skin.FindControl("hidVd");
				this.label_0 = (Label)skin.FindControl("lblFeeName");
				this.button_0 = (Button)skin.FindControl("butSub");
				if (!this.Page.IsPostBack)
				{
					this.htmlInputText_0.Value = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
					this.htmlInputText_1.Value = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
					this.htmlInputText_2.Value = DateTime.Now.ToLocalTime().AddDays(7.0).ToString("yyyy-MM-dd HH:mm:ss");
					Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
					this.repeater_0.DataSource = shop_ProductCategory_Action.SearchShopType(0, this.MemLoginID).DefaultView;
					this.repeater_0.DataBind();
					if (this.string_1.Length >= 35)
					{
						this.method_3();
					}
					else
					{
						try
						{
							HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
							HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
							string rankguid = httpCookie.Values["ShopRank"].ToString();
							try
							{
								rankguid = ShopNum1.Common.Common.GetNameById("ShopRank", "ShopNum1_ShopInfo", " AND  MemLoginID='" + this.MemLoginID + "'  ");
							}
							catch (Exception)
							{
							}
							Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
							string str = shop_ShopInfo_Action.IsAllowToAddProduct(this.MemLoginID, rankguid, "1");
							string str2 = shop_ShopInfo_Action.IsAllowToAddProduct(this.MemLoginID, rankguid, "2");
							this.htmlInputHidden_32.Value = str + "|" + str2;
						}
						catch
						{
						}
					}
				}
				this.Page.RegisterRequiresRaiseEvent(this);
			}
			catch
			{
				this.Page.Response.Redirect("/login.html?goback=" + HttpUtility.UrlEncode(this.Page.Request.Url.ToString()));
			}
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				this.repeater_1 = (Repeater)e.Item.FindControl("repSubShopType");
				this.htmlInputHidden_33 = (HtmlInputHidden)e.Item.FindControl("hidShopFatherId");
				Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
				this.repeater_1.DataSource = shop_ProductCategory_Action.Search(Convert.ToInt32(this.htmlInputHidden_33.Value), this.MemLoginID);
				this.repeater_1.DataBind();
			}
		}
		private void method_0(string string_4)
		{
			string value = this.htmlInputHidden_10.Value;
			ShopNum1_SpecProudctDetail_Action shopNum1_SpecProudctDetail_Action = (ShopNum1_SpecProudctDetail_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_SpecProudctDetail_Action();
			List<ShopNum1_SpecProudctDetail> list = new List<ShopNum1_SpecProudctDetail>();
			list.Add(new ShopNum1_SpecProudctDetail
			{
				ProductGuid = new Guid?(new Guid(string_4)),
				TypeId = new int?(0),
				SpecId = new int?(0),
				SpecValueId = new int?(0),
				SpecValueName = "",
				ProductImage = ""
			});
			if (value != "")
			{
				string[] array = value.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < array.Length; i++)
				{
					ShopNum1_SpecProudctDetail shopNum1_SpecProudctDetail = new ShopNum1_SpecProudctDetail();
					shopNum1_SpecProudctDetail.ProductGuid = new Guid?(new Guid(string_4));
					shopNum1_SpecProudctDetail.TypeId = new int?(Convert.ToInt32(this.string_2));
					shopNum1_SpecProudctDetail.SpecId = new int?(Convert.ToInt32(array[i].Split(new char[]
					{
						','
					})[0]));
					shopNum1_SpecProudctDetail.SpecValueId = new int?(Convert.ToInt32(array[i].Split(new char[]
					{
						','
					})[1]));
					shopNum1_SpecProudctDetail.SpecValueName = array[i].Split(new char[]
					{
						','
					})[2];
					if (array[i].Split(new char[]
					{
						','
					})[3] == "undefined")
					{
						shopNum1_SpecProudctDetail.ProductImage = "";
					}
					else
					{
						shopNum1_SpecProudctDetail.ProductImage = array[i].Split(new char[]
						{
							','
						})[3];
					}
					list.Add(shopNum1_SpecProudctDetail);
				}
			}
			if (this.string_1.Length < 35)
			{
				shopNum1_SpecProudctDetail_Action.AddListSpecProudctDetail(list);
			}
			else
			{
				shopNum1_SpecProudctDetail_Action.UpdateListSpecProudctDetail(list, this.htmlInputHidden_31.Value, this.htmlInputHidden_30.Value);
			}
		}
		private void method_1(string string_4)
		{
			string value = this.htmlInputHidden_11.Value;
			ShopNum1_SpecProudct_Action shopNum1_SpecProudct_Action = (ShopNum1_SpecProudct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_SpecProudct_Action();
			if (value != "")
			{
				List<ShopNum1_SpecProudct> list = new List<ShopNum1_SpecProudct>();
				if (value.IndexOf("&") != -1)
				{
					string[] array = value.Split(new char[]
					{
						'&'
					});
					for (int i = 0; i < array.Length; i++)
					{
						ShopNum1_SpecProudct shopNum1_SpecProudct = new ShopNum1_SpecProudct();
						string[] array2 = array[i].Split(new char[]
						{
							'*'
						});
						shopNum1_SpecProudct.ProductGuid = string_4;
						shopNum1_SpecProudct.SpecDetail = array2[0];
						shopNum1_SpecProudct.SpecTotalId = array2[1].Split(new char[]
						{
							','
						})[0];
						shopNum1_SpecProudct.GoodsPrice = new decimal?(decimal.Parse(array2[1].Split(new char[]
						{
							','
						})[1]));
						shopNum1_SpecProudct.GoodsStock = new int?(Convert.ToInt32(array2[1].Split(new char[]
						{
							','
						})[2]));
						shopNum1_SpecProudct.GoodsNumber = array2[1].Split(new char[]
						{
							','
						})[3];
						shopNum1_SpecProudct.ShopID = this.MemLoginID;
						shopNum1_SpecProudct.CreateTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
						list.Add(shopNum1_SpecProudct);
					}
				}
				else
				{
					ShopNum1_SpecProudct shopNum1_SpecProudct = new ShopNum1_SpecProudct();
					string[] array2 = value.Split(new char[]
					{
						'*'
					});
					shopNum1_SpecProudct.ProductGuid = string_4;
					shopNum1_SpecProudct.SpecDetail = array2[0];
					shopNum1_SpecProudct.SpecTotalId = array2[1].Split(new char[]
					{
						','
					})[0];
					shopNum1_SpecProudct.GoodsPrice = new decimal?(Convert.ToDecimal(array2[1].Split(new char[]
					{
						','
					})[1]));
					shopNum1_SpecProudct.GoodsStock = new int?(Convert.ToInt32(array2[1].Split(new char[]
					{
						','
					})[2]));
					shopNum1_SpecProudct.GoodsNumber = array2[1].Split(new char[]
					{
						','
					})[3];
					shopNum1_SpecProudct.ShopID = this.MemLoginID;
					shopNum1_SpecProudct.CreateTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
					list.Add(shopNum1_SpecProudct);
				}
				shopNum1_SpecProudct_Action.AddListSpecProducts(list);
			}
			else
			{
				shopNum1_SpecProudct_Action.DeleteSpecProduct(string_4);
			}
		}
		private void method_2(string string_4)
		{
			ShopNum1_ShopProRelateProp_Action shopNum1_ShopProRelateProp_Action = (ShopNum1_ShopProRelateProp_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopProRelateProp_Action();
			List<ShopNum1_ShopProRelateProp> list = new List<ShopNum1_ShopProRelateProp>();
			string value = this.htmlInputHidden_18.Value;
			if (value != "")
			{
				if (value.IndexOf("|") != -1)
				{
					string[] array = value.Split(new char[]
					{
						'|'
					});
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(new ShopNum1_ShopProRelateProp
						{
							ProductGuid = new Guid(string_4),
							CTypeID = new int?(Convert.ToInt32(this.string_2)),
							PCategoryID = new int?(Convert.ToInt32(this.string_3)),
							ShowType = new int?(Convert.ToInt32(array[i].Split(new char[]
							{
								','
							})[0])),
							PropID = new int?(Convert.ToInt32(array[i].Split(new char[]
							{
								','
							})[1])),
							PropValueID = new int?(Convert.ToInt32((array[i].Split(new char[]
							{
								','
							})[2] == "") ? "0" : array[i].Split(new char[]
							{
								','
							})[2])),
							InputValue = array[i].Split(new char[]
							{
								','
							})[3]
						});
					}
				}
				else
				{
					list.Add(new ShopNum1_ShopProRelateProp
					{
						ProductGuid = new Guid(string_4),
						CTypeID = new int?(Convert.ToInt32(this.string_2)),
						PCategoryID = new int?(Convert.ToInt32(this.string_3)),
						ShowType = new int?(Convert.ToInt32(value.Split(new char[]
						{
							','
						})[0])),
						PropID = new int?(Convert.ToInt32(value.Split(new char[]
						{
							','
						})[1])),
						PropValueID = new int?(Convert.ToInt32((value.Split(new char[]
						{
							','
						})[2] == "") ? "0" : value.Split(new char[]
						{
							','
						})[2])),
						InputValue = value.Split(new char[]
						{
							','
						})[3]
					});
				}
				shopNum1_ShopProRelateProp_Action.AddListPropValue(list);
			}
		}
		private void method_3()
		{
			DataTable productDetail = this.shop_Product_Action_0.GetProductDetail(this.string_1);
			if (productDetail.Rows.Count > 0)
			{
				this.htmlInputHidden_28.Value = productDetail.Rows[0]["RepertoryAlertCount"].ToString();
				this.htmlInputHidden_21.Value = productDetail.Rows[0]["AddressValue"] + "|" + productDetail.Rows[0]["AddressCode"];
				this.htmlInputHidden_24.Value = productDetail.Rows[0]["ProductSeriesCode"] + "|" + productDetail.Rows[0]["ProductSeriesName"];
				this.htmlInputHidden_5.Value = productDetail.Rows[0]["RepertoryCount"].ToString();
				this.htmlInputHidden_3.Value = productDetail.Rows[0]["name"].ToString();
				this.htmlInputHidden_6.Value = productDetail.Rows[0]["shopprice"].ToString();
				this.htmlInputHidden_8.Value = productDetail.Rows[0]["UnitName"].ToString();
				this.htmlInputHidden_4.Value = productDetail.Rows[0]["productnum"].ToString();
				this.htmlTextArea_0.Value = productDetail.Rows[0]["Detail"].ToString();
				this.htmlInputHidden_2.Value = productDetail.Rows[0]["ProductCategoryName"].ToString();
				this.htmlInputHidden_9.Value = productDetail.Rows[0]["BrandGuid"] + "," + productDetail.Rows[0]["BrandName"];
				this.htmlInputText_3.Value = productDetail.Rows[0]["Keywords"].ToString();
				this.htmlTextArea_2.Value = productDetail.Rows[0]["Description"].ToString();
				this.htmlInputHidden_25.Value = productDetail.Rows[0]["FeeType"].ToString();
				this.htmlInputHidden_7.Value = productDetail.Rows[0]["MarketPrice"].ToString();
				this.htmlTextArea_1.Value = productDetail.Rows[0]["Wap_desc"].ToString();
				this.htmlTextArea_3.Value = productDetail.Rows[0]["Instruction"].ToString();
				if (productDetail.Rows[0]["FeeTemplateID"].ToString() != "0")
				{
					this.htmlInputHidden_29.Value = productDetail.Rows[0]["FeeTemplateID"] + "," + productDetail.Rows[0]["FeeTemplateName"];
					this.label_0.Text = productDetail.Rows[0]["FeeTemplateName"].ToString();
					this.htmlInputHidden_26.Value = "0";
				}
				else
				{
					this.htmlInputText_4.Value = productDetail.Rows[0]["Post_fee"].ToString();
					this.htmlInputText_5.Value = productDetail.Rows[0]["Express_fee"].ToString();
					this.htmlInputText_6.Value = productDetail.Rows[0]["Ems_fee"].ToString();
					this.htmlInputHidden_26.Value = "1";
				}
				this.htmlInputHidden_0.Value = productDetail.Rows[0]["isreal"].ToString();
				if (productDetail.Rows[0]["IsShopNew"].ToString() == "1")
				{
					this.htmlInputHidden_1.Value = "isnew";
				}
				if (productDetail.Rows[0]["IsShopHot"].ToString() == "1")
				{
					this.htmlInputHidden_1.Value = this.htmlInputHidden_1.Value + "ishot";
				}
				if (productDetail.Rows[0]["IsShopPromotion"].ToString() == "1")
				{
					this.htmlInputHidden_1.Value = this.htmlInputHidden_1.Value + "ispromotion";
				}
				if (productDetail.Rows[0]["IsShopRecommend"].ToString() == "1")
				{
					this.htmlInputHidden_1.Value = this.htmlInputHidden_1.Value + "Isrecommend";
				}
				this.htmlInputHidden_12.Value = productDetail.Rows[0]["ProductState"].ToString();
				this.htmlInputHidden_19.Value = productDetail.Rows[0]["MultiImages"].ToString();
				this.htmlInputHidden_22.Value = productDetail.Rows[0]["pulishtype"].ToString();
				this.htmlInputText_2.Value = productDetail.Rows[0]["endtime"].ToString();
				this.htmlInputText_0.Value = productDetail.Rows[0]["StartTime"].ToString();
				this.htmlInputHidden_27.Value = productDetail.Rows[0]["setstock"].ToString();
			}
		}
		public void RaisePostBackEvent(string eventArgument)
		{
			Func<string, bool> func = null;
			try
			{
				string arg = this.Page.Request.Form["__EVENTTARGET"];
				if (func == null)
				{
					func = new Func<string, bool>(this.method_4);
				}
				Func<string, bool> func2 = func;
				func2(arg);
			}
			catch (Exception ex)
			{
				this.Page.Response.Write(ex.Message + "|" + ex.StackTrace);
			}
		}
		protected bool OpProduct()
		{
			string text = Guid.NewGuid().ToString();
			text = ((this.string_1.Length < 35) ? text : this.string_1);
			ShopNum1_Shop_Product shopNum1_Shop_Product = new ShopNum1_Shop_Product();
			shopNum1_Shop_Product.Guid = new Guid(text);
			shopNum1_Shop_Product.Name = Operator.FilterString(this.htmlInputHidden_3.Value);
			shopNum1_Shop_Product.ProductNum = this.htmlInputHidden_4.Value;
			shopNum1_Shop_Product.Score = new int?(0);
			try
			{
				shopNum1_Shop_Product.RepertoryAlertCount = new int?(Convert.ToInt32(this.htmlInputHidden_28.Value));
			}
			catch
			{
				shopNum1_Shop_Product.RepertoryAlertCount = new int?(10);
			}
			shopNum1_Shop_Product.ShopPrice = decimal.Parse(this.htmlInputHidden_6.Value);
			shopNum1_Shop_Product.MarketPrice = new decimal?(decimal.Parse(this.htmlInputHidden_7.Value));
			shopNum1_Shop_Product.RepertoryCount = Convert.ToInt32(this.htmlInputHidden_5.Value);
			shopNum1_Shop_Product.UnitName = this.htmlInputHidden_8.Value;
			shopNum1_Shop_Product.Detail = this.htmlTextArea_0.Value;
			shopNum1_Shop_Product.Instruction = this.htmlTextArea_3.Value;
			shopNum1_Shop_Product.ProductSeriesCode = this.htmlInputHidden_24.Value.Split(new char[]
			{
				'|'
			})[0];
			shopNum1_Shop_Product.ProductSeriesName = this.htmlInputHidden_24.Value.Split(new char[]
			{
				'|'
			})[1];
			shopNum1_Shop_Product.ProductCategoryCode = this.string_3;
			shopNum1_Shop_Product.ProductCategoryName = this.htmlInputHidden_2.Value.Trim();
			if (this.htmlInputHidden_9.Value != "" && this.htmlInputHidden_9.Value.IndexOf("00000000-0000-0000-0000-000000000000") == -1)
			{
				shopNum1_Shop_Product.BrandGuid = new Guid(this.htmlInputHidden_9.Value.Split(new char[]
				{
					','
				})[0]);
				shopNum1_Shop_Product.BrandName = this.htmlInputHidden_9.Value.Split(new char[]
				{
					','
				})[1];
			}
			else
			{
				shopNum1_Shop_Product.BrandGuid = new Guid("00000000-0000-0000-0000-000000000000");
				shopNum1_Shop_Product.BrandName = "其它";
			}
			shopNum1_Shop_Product.OriginalImage = this.htmlInputHidden_20.Value;
			shopNum1_Shop_Product.ThumbImage = this.htmlInputHidden_20.Value;
			shopNum1_Shop_Product.SmallImage = this.htmlInputHidden_20.Value;
			shopNum1_Shop_Product.MultiImages = this.htmlInputHidden_19.Value;
			shopNum1_Shop_Product.Keywords = Operator.FilterString(this.htmlInputText_3.Value);
			shopNum1_Shop_Product.Description = Operator.FilterString(this.htmlTextArea_2.Value);
			shopNum1_Shop_Product.AddressCode = this.htmlInputHidden_21.Value.Split(new char[]
			{
				'|'
			})[1];
			shopNum1_Shop_Product.AddressValue = this.htmlInputHidden_21.Value.Split(new char[]
			{
				'|'
			})[0];
			shopNum1_Shop_Product.FeeType = Convert.ToInt32(this.htmlInputHidden_25.Value);
			shopNum1_Shop_Product.MemLoginID = this.MemLoginID;
			shopNum1_Shop_Product.ShopName = ShopNum1.Common.Common.GetNameById("shopname", "shopnum1_shopinfo", " and memloginId='" + this.MemLoginID + "'");
			if (shopNum1_Shop_Product.FeeType == 0)
			{
				if (this.htmlInputHidden_26.Value == "0")
				{
					shopNum1_Shop_Product.FeeTemplateID = new int?(Convert.ToInt32(this.htmlInputHidden_29.Value.Split(new char[]
					{
						','
					})[0]));
					shopNum1_Shop_Product.FeeTemplateName = this.htmlInputHidden_29.Value.Split(new char[]
					{
						','
					})[1];
				}
				else
				{
					shopNum1_Shop_Product.Post_fee = decimal.Parse(this.htmlInputText_4.Value);
					shopNum1_Shop_Product.Express_fee = decimal.Parse(this.htmlInputText_5.Value);
					shopNum1_Shop_Product.Ems_fee = decimal.Parse(this.htmlInputText_6.Value);
				}
			}
			shopNum1_Shop_Product.MinusFee = decimal.Parse("0.00");
			shopNum1_Shop_Product.IsReal = Convert.ToInt32(this.htmlInputHidden_0.Value);
			if (this.htmlInputHidden_1.Value.IndexOf("isnew") != -1)
			{
				shopNum1_Shop_Product.IsShopNew = 1;
			}
			if (this.htmlInputHidden_1.Value.IndexOf("ishot") != -1)
			{
				shopNum1_Shop_Product.IsShopHot = 1;
			}
			if (this.htmlInputHidden_1.Value.IndexOf("ispromotion") != -1)
			{
				shopNum1_Shop_Product.IsShopPromotion = 1;
			}
			if (this.htmlInputHidden_1.Value.IndexOf("Isrecommend") != -1)
			{
				shopNum1_Shop_Product.IsShopRecommend = 1;
			}
			shopNum1_Shop_Product.EndTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
			if (this.htmlInputHidden_22.Value == "0")
			{
				shopNum1_Shop_Product.DeSaleTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
				shopNum1_Shop_Product.StartTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
				shopNum1_Shop_Product.SaleTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
				shopNum1_Shop_Product.IsSell = 1;
			}
			else if (this.htmlInputHidden_22.Value == "1")
			{
				if (this.htmlInputText_0.Value != "")
				{
					shopNum1_Shop_Product.StartTime = new DateTime?(Convert.ToDateTime(this.htmlInputText_0.Value));
					shopNum1_Shop_Product.SaleTime = new DateTime?(Convert.ToDateTime(this.htmlInputText_0.Value));
				}
				else
				{
					shopNum1_Shop_Product.StartTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
					shopNum1_Shop_Product.SaleTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
				}
				shopNum1_Shop_Product.IsSell = 1;
			}
			else
			{
				shopNum1_Shop_Product.IsSell = 0;
			}
			if (this.htmlInputText_1.Value != "")
			{
				shopNum1_Shop_Product.StartTime = new DateTime?(Convert.ToDateTime(this.htmlInputText_1.Value));
			}
			if (this.htmlInputText_2.Value != "")
			{
				shopNum1_Shop_Product.EndTime = new DateTime?(Convert.ToDateTime(this.htmlInputText_2.Value));
			}
			string text2 = this.htmlTextArea_1.Value;
			string pattern = "<(?!img|br|a|p|/p).*?>";
			text2 = Regex.Replace(text2, pattern, string.Empty, RegexOptions.IgnoreCase);
			shopNum1_Shop_Product.Wap_desc = text2;
			shopNum1_Shop_Product.CreateUser = this.MemLoginID;
			shopNum1_Shop_Product.Ctype = new int?(Convert.ToInt32(this.string_2));
			shopNum1_Shop_Product.ProductState = new int?(Convert.ToInt32(this.htmlInputHidden_12.Value));
			shopNum1_Shop_Product.SetStock = new int?(Convert.ToInt32(this.htmlInputHidden_27.Value));
			shopNum1_Shop_Product.PulishType = new int?(Convert.ToInt32(this.htmlInputHidden_22.Value));
			if (shopNum1_Shop_Product.PulishType == 2)
			{
				shopNum1_Shop_Product.IsSell = 0;
			}
			shopNum1_Shop_Product.ModifyTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
			string nameById = ShopNum1.Common.Common.GetNameById("IsProductAduit", "shopnum1_shopinfo", " and memloginId='" + this.MemLoginID + "'");
			if (nameById == "3" || nameById == "")
			{
				if (ShopSettings.GetValue("AddProductIsAudit") == "0")
				{
					shopNum1_Shop_Product.IsAudit = 1;
				}
				else
				{
					shopNum1_Shop_Product.IsAudit = 0;
				}
			}
			else
			{
				shopNum1_Shop_Product.IsAudit = Convert.ToInt32(nameById);
			}
			if (shopNum1_Shop_Product.ProductState == 1)
			{
				if (ShopSettings.GetValue("AddPanicBuyProductIsAudit") == "0")
				{
					shopNum1_Shop_Product.IsAudit = 1;
				}
				else
				{
					shopNum1_Shop_Product.IsAudit = 0;
				}
			}
			string substationID = string.Empty;
			try
			{
				substationID = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND   MemLoginID='" + this.MemLoginID + "'   ");
			}
			catch (Exception)
			{
			}
			shopNum1_Shop_Product.SubstationID = substationID;
			if (this.string_1.Length < 35)
			{
				this.shop_Product_Action_0.AddShopProductNew(shopNum1_Shop_Product);
				this.method_0(text);
				this.method_1(text);
				this.method_2(text);
				this.Page.Response.Redirect(string.Concat(new object[]
				{
					"/shop/ShopAdmin/S_SellGoods_Three.aspx?op=add&step=two&shopid=",
					this.MemLoginID,
					"&pstate=",
					shopNum1_Shop_Product.ProductState,
					"&ctype=",
					ShopNum1.Common.Common.ReqStr("ctype"),
					"&pid=",
					text,
					"&code=",
					ShopNum1.Common.Common.ReqStr("code"),
					"&cid=",
					ShopNum1.Common.Common.ReqStr("cid")
				}));
			}
			else
			{
				this.shop_Product_Action_0.UpdateShopProduct(shopNum1_Shop_Product);
				this.method_0(text);
				this.method_1(text);
				this.method_2(text);
				this.Page.Response.Redirect(string.Concat(new object[]
				{
					"/shop/ShopAdmin/S_SellGoods_Three.aspx?op=edit&step=two&shopid=",
					this.MemLoginID,
					"&pstate=",
					shopNum1_Shop_Product.ProductState,
					"&ctype=",
					ShopNum1.Common.Common.ReqStr("ctype"),
					"&pid=",
					text,
					"&code=",
					ShopNum1.Common.Common.ReqStr("code"),
					"&cid=",
					ShopNum1.Common.Common.ReqStr("cid")
				}));
			}
			return true;
		}
		[CompilerGenerated]
		private bool method_4(string string_4)
		{
			if (string_4 != null && string_4 == "btnOk")
			{
				this.OpProduct();
			}
			return true;
		}
	}
}
