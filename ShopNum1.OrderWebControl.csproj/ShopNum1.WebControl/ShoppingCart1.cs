using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ShoppingCart1 : BaseWebControl
	{
		private string string_0 = "ShoppingCart1.ascx";
		private Repeater repeater_0;
		private ImageButton imageButton_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private ImageButton imageButton_1;
		private ImageButton imageButton_2;
		private HiddenField hiddenField_0;
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private IShopNum1_Cart_Action ishopNum1_Cart_Action_0 = ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
		private string string_1;
		public ShoppingCart1()
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
				string text = string.Empty;
				if (this.Page.Request.Cookies["Visitor_LoginCookie"] != null)
				{
					HttpCookie cookie = this.Page.Request.Cookies["Visitor_LoginCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					text = httpCookie.Values["MemLoginID"].ToString();
				}
				else
				{
					Order order = new Order();
					string text2 = "visitor_" + order.CreateOrderNumber();
					HttpCookie httpCookie2 = HttpSecureCookie.Encode(new HttpCookie("Visitor_LoginCookie")
					{
						Values = 
						{

							{
								"MemLoginID",
								text2
							}
						}
					});
					httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
					this.Page.Response.AppendCookie(httpCookie2);
					text = text2;
				}
				this.string_1 = text;
			}
			else
			{
				HttpCookie cookie2 = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie3 = HttpSecureCookie.Decode(cookie2);
				this.string_1 = httpCookie3.Values["MemLoginID"].ToString();
			}
			this.label_0 = (Label)skin.FindControl("labelAllPrice");
			this.label_1 = (Label)skin.FindControl("labelMaretPrice");
			this.label_2 = (Label)skin.FindControl("labelLower");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShopCart1");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.method_3();
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldURLReferrer");
			this.imageButton_0 = (ImageButton)skin.FindControl("ImageButtonRemove");
			this.imageButton_1 = (ImageButton)skin.FindControl("ImageButtonPay");
			this.imageButton_2 = (ImageButton)skin.FindControl("ImageButtonContinue");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonDelete");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonRemove");
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonUpdate");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.imageButton_0.Click += new ImageClickEventHandler(this.imageButton_0_Click);
			this.imageButton_1.Click += new ImageClickEventHandler(this.imageButton_1_Click);
			this.imageButton_2.Click += new ImageClickEventHandler(this.imageButton_2_Click);
			if (!this.Page.IsPostBack && this.Page.Request.UrlReferrer != null)
			{
				this.hiddenField_0.Value = this.Page.Request.UrlReferrer.ToString();
			}
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
			{
				Repeater repeater = (Repeater)repeaterItem.FindControl("RepeaterShopProduct");
				foreach (RepeaterItem repeaterItem2 in repeater.Items)
				{
					CheckBox checkBox = repeaterItem2.FindControl("checkboxAll") as CheckBox;
					if (checkBox.Checked)
					{
						HiddenField hiddenField = repeaterItem2.FindControl("HiddenFieldGuid") as HiddenField;
						if (text != string.Empty)
						{
							text = text + ",'" + hiddenField.Value + "'";
						}
						else
						{
							text = text + "'" + hiddenField.Value + "'";
						}
					}
				}
			}
			if (text == string.Empty)
			{
				MessageBox.Show("请选择您要删除的记录!");
			}
			else
			{
				int num = this.ishopNum1_Cart_Action_0.Delete(text.Trim().Replace("\n", "").Replace("\t", ""));
				if (num > 0)
				{
					MessageBox.Show("删除成功!");
					this.method_3();
				}
				else
				{
					MessageBox.Show("删除失败!");
				}
			}
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			int num = 0;
			string text = string.Empty;
			foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
			{
				Repeater repeater = (Repeater)repeaterItem.FindControl("RepeaterShopProduct");
				foreach (RepeaterItem repeaterItem2 in repeater.Items)
				{
					CheckBox checkBox = repeaterItem2.FindControl("checkboxAll") as CheckBox;
					if (checkBox.Checked)
					{
						HiddenField hiddenField = repeaterItem2.FindControl("HiddenFieldGuid") as HiddenField;
						HiddenField hiddenField2 = repeaterItem2.FindControl("HiddenFieldProductGuid") as HiddenField;
						if (text != string.Empty)
						{
							text = text + ",'" + hiddenField.Value + "'";
						}
						else
						{
							text = text + "'" + hiddenField.Value + "'";
						}
						if (text == string.Empty)
						{
							MessageBox.Show("请选择您要操作的记录!");
							return;
						}
						DataTable infoByGuid = this.ishopNum1_Cart_Action_0.GetInfoByGuid(hiddenField.Value);
						if (infoByGuid != null && infoByGuid.Rows.Count > 0)
						{
							string shopID = infoByGuid.Rows[0]["SellName"].ToString();
							string shopPrice = infoByGuid.Rows[0]["ShopPrice"].ToString();
							string productName = infoByGuid.Rows[0]["Name"].ToString();
							string sellLoginID = infoByGuid.Rows[0]["ShopID"].ToString();
							Shop_Collect_Action shop_Collect_Action = (Shop_Collect_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Collect_Action();
							if (shop_Collect_Action.AddProductCollect(this.string_1, hiddenField2.Value, shopID, "0", shopPrice, productName, sellLoginID) > 0)
							{
								num++;
								shop_Collect_Action.ProductCollectNum(hiddenField2.Value);
							}
						}
					}
				}
			}
			if (text == string.Empty)
			{
				MessageBox.Show("请选择您要操作的记录!");
			}
			else
			{
				int num2 = this.ishopNum1_Cart_Action_0.Delete(text.Trim().Replace("\n", "").Replace("\t", ""));
				if (num2 > 0 && num > 0)
				{
					MessageBox.Show("批量移入收藏夹成功!");
					this.method_3();
				}
				else
				{
					MessageBox.Show("批量移入收藏夹失败!");
				}
			}
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
			this.ishopNum1_Cart_Action_0.SearchByMemLoginID(this.string_1);
			List<ShopNum1_Shop_Cart> list = new List<ShopNum1_Shop_Cart>();
			for (int i = 0; i < this.repeater_0.Items.Count; i++)
			{
				Repeater repeater = (Repeater)this.repeater_0.Items[i].FindControl("RepeaterShopProduct");
				int j = 0;
				while (j < repeater.Items.Count)
				{
					ShopNum1_Shop_Cart shopNum1_Shop_Cart = new ShopNum1_Shop_Cart();
					shopNum1_Shop_Cart.Guid = new Guid(((HiddenField)repeater.Items[j].FindControl("HiddenFieldGuid")).Value);
					shopNum1_Shop_Cart.BuyPrice = Convert.ToDecimal(((Label)repeater.Items[j].FindControl("labelBuyPrice")).Text);
					int num = 1;
					try
					{
						shopNum1_Shop_Cart.BuyNumber = Convert.ToInt32(((TextBox)repeater.Items[j].FindControl("TextBoxBuyNumber")).Text);
						goto IL_1BC;
					}
					catch (Exception)
					{
						num = 0;
						goto IL_1BC;
					}
					IL_115:
					string value = ((HiddenField)repeater.Items[j].FindControl("HiddenFieldProductGuid")).Value;
					int limitBuyCount = shop_Product_Action.GetLimitBuyCount(value);
					if (limitBuyCount >= shopNum1_Shop_Cart.BuyNumber || limitBuyCount == 0)
					{
						list.Add(shopNum1_Shop_Cart);
						j++;
						continue;
					}
					shopNum1_Shop_Cart.BuyNumber = limitBuyCount;
					MessageBox.Show("库存不足!");
					this.DataBind();
					return;
					IL_1BC:
					if (num == 0)
					{
						ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "msg", "alert(\"购买数量格式不对！\");", true);
						return;
					}
					goto IL_115;
				}
				if (list.Count <= 0)
				{
					MessageBox.Show("当前购物车没有添加商品！");
					break;
				}
				int num2 = this.ishopNum1_Cart_Action_0.Update(list);
				if (num2 > 0)
				{
					this.method_3();
					MessageBox.Show("更新购物车成功!");
				}
				else
				{
					MessageBox.Show("更新购物车失败！");
				}
			}
		}
		private void method_0(object sender, EventArgs e)
		{
			string commandArgument = ((LinkButton)sender).CommandArgument;
			int num = this.ishopNum1_Cart_Action_0.Delete("'" + commandArgument.Trim() + "'");
			if (num > 0)
			{
				MessageBox.Show("删除成功!");
				this.method_3();
			}
			else
			{
				MessageBox.Show("删除失败!");
			}
		}
		private void method_1(object sender, EventArgs e)
		{
			string commandArgument = ((LinkButton)sender).CommandArgument;
			string[] array = commandArgument.Split(new char[]
			{
				','
			});
			int num = this.ishopNum1_Cart_Action_0.Delete("'" + array[0] + "'");
			Shop_Collect_Action shop_Collect_Action = (Shop_Collect_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Collect_Action();
			int num2 = shop_Collect_Action.AddProductCollect(this.string_1, array[1], array[2], "0", array[3], array[4], array[5]);
			if (num > 0 && num2 > 0)
			{
				MessageBox.Show("收藏成功!");
				shop_Collect_Action.ProductCollectNum(array[1]);
				this.method_3();
			}
			else
			{
				MessageBox.Show("已收藏过该商品!");
			}
		}
		private void imageButton_2_Click(object sender, ImageClickEventArgs e)
		{
			if (this.Page.Request.QueryString["gocityurl"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["gocityurl"].ToString()))
			{
				try
				{
					string nameById = ShopNum1.Common.Common.GetNameById("Guid", "ShopNum1_SubstationManage", "   AND    DomainName='" + this.Page.Request.QueryString["gocityurl"].ToString() + "'    ");
					if (string.IsNullOrEmpty(nameById))
					{
						return;
					}
				}
				catch (Exception)
				{
				}
				this.Page.Response.Redirect("http://" + this.Page.Request.QueryString["gocityurl"].ToString() + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')));
			}
		}
		private void imageButton_0_Click(object sender, ImageClickEventArgs e)
		{
			int num = this.ishopNum1_Cart_Action_0.DeleteByMemLoginID(this.string_1);
			if (num > 0)
			{
				this.method_3();
			}
		}
		private void imageButton_1_Click(object sender, ImageClickEventArgs e)
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
			else if (this.repeater_0.Items.Count <= 0)
			{
				MessageBox.Show("当前购物车商品可能被商家删除,请重新商品后去结算！");
			}
			else
			{
				int num = 0;
				string text2 = string.Empty;
				foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
				{
					Repeater repeater = (Repeater)repeaterItem.FindControl("RepeaterShopProduct");
					foreach (RepeaterItem repeaterItem2 in repeater.Items)
					{
						CheckBox checkBox = repeaterItem2.FindControl("checkboxAll") as CheckBox;
						if (checkBox.Checked)
						{
							HiddenField hiddenField = repeaterItem2.FindControl("HiddenFieldGuid") as HiddenField;
							if (text2 != string.Empty)
							{
								text2 = text2 + ",'" + hiddenField.Value + "'";
							}
							else
							{
								text2 = text2 + "'" + hiddenField.Value + "'";
							}
						}
					}
				}
				if (num == 0)
				{
					if (text2 == string.Empty)
					{
						this.Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart2"));
					}
					else
					{
						HttpCookie httpCookie = HttpSecureCookie.Encode(new HttpCookie("VjProductGuId")
						{
							Values = 
							{

								{
									"parry",
									text2.Replace("'", "")
								}
							}
						});
						httpCookie.Expires = DateTime.Now.AddHours(1.0);
						httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
						this.Page.Response.AppendCookie(httpCookie);
						if (this.Page.Request.QueryString["gocityurl"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["gocityurl"].ToString()))
						{
							try
							{
								string nameById = ShopNum1.Common.Common.GetNameById("Guid", "ShopNum1_SubstationManage", "   AND    DomainName='" + this.Page.Request.QueryString["gocityurl"].ToString() + "'    ");
								if (string.IsNullOrEmpty(nameById))
								{
									string text3 = DatabaseExcetue.ReturnString("select top 1 A.domainname from ShopNum1_SubstationManage A \r\ninner join ShopNum1_shop_product B on b.substationid=A.substationid \r\ninner join shopnum1_shop_cart C on C.productguid=b.guid and C.guid IN(" + text2 + ")");
									this.Page.Response.Redirect(string.Concat(new string[]
									{
										"http://",
										text3,
										ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')),
										"/ShoppingCart2.aspx?gocityurl=",
										text3,
										"&checkedguid=0"
									}));
								}
							}
							catch (Exception)
							{
							}
							this.Page.Response.Redirect(string.Concat(new string[]
							{
								"http://",
								this.Page.Request.QueryString["gocityurl"].ToString(),
								ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')),
								"/ShoppingCart2.aspx?gocityurl=",
								this.Page.Request.QueryString["gocityurl"].ToString(),
								"&checkedguid=0"
							}));
						}
						else
						{
							string text3 = DatabaseExcetue.ReturnString("select top 1 A.domainname from ShopNum1_SubstationManage A \r\ninner join ShopNum1_shop_product B on b.substationid=A.substationid \r\ninner join shopnum1_shop_cart C on C.productguid=b.guid and C.guid IN(" + text2 + ")");
							this.Page.Response.Redirect(string.Concat(new string[]
							{
								"http://",
								text3,
								ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')),
								"/ShoppingCart2.aspx?gocityurl=",
								text3,
								"&checkedguid=0"
							}));
						}
					}
				}
			}
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterShopProduct");
				repeater.ItemDataBound += new RepeaterItemEventHandler(this.method_2);
				Label label = (Label)e.Item.FindControl("LabelShopName");
				Label label2 = (Label)e.Item.FindControl("LabelSellName");
				DataTable dataTable = this.ishopNum1_Cart_Action_0.SearchByShopMemID(this.string_1, label.Text);
				if (dataTable != null)
				{
					repeater.DataSource = dataTable.DefaultView;
					repeater.DataBind();
					for (int i = 0; i < repeater.Items.Count; i++)
					{
						IShop_Ensure_Action shop_Ensure_Action = ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
						DataTable dataTable2 = shop_Ensure_Action.SearchEnsureApply(label2.Text);
						Label label3 = (Label)repeater.Items[i].FindControl("LabelProductService");
						if (dataTable2 != null && dataTable2.Rows.Count > 0)
						{
							for (int j = 0; j < dataTable2.Rows.Count; j++)
							{
								Image image = new Image();
								image.ImageUrl = dataTable2.Rows[j]["ImagePath"].ToString();
								label3.Controls.Add(image);
							}
						}
						else
						{
							label3.Text = "";
						}
					}
				}
			}
		}
		private void method_2(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label label = (Label)e.Item.FindControl("LabelIsPresent");
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldIsPresent");
				LinkButton linkButton = (LinkButton)e.Item.FindControl("LinkButtonIRemove");
				LinkButton linkButton2 = (LinkButton)e.Item.FindControl("LinkButtonIDelete");
				linkButton.Click += new EventHandler(this.method_1);
				linkButton2.Click += new EventHandler(this.method_0);
				if (hiddenField.Value == "1")
				{
					label.Text = "赠品";
				}
				Label label2 = (Label)e.Item.FindControl("LabelBuyPrice");
				string value = label2.Text.Trim();
				TextBox textBox = (TextBox)e.Item.FindControl("TextBoxBuyNumber");
				string text = textBox.Text.Trim();
				Label label3 = (Label)e.Item.FindControl("LabelAll");
				label3.Text = text;
				try
				{
					Convert.ToDecimal(value);
				}
				catch
				{
					MessageBox.Show("购买价格有误！");
					return;
				}
				try
				{
					Convert.ToInt32(text);
				}
				catch
				{
					MessageBox.Show("购买数量有误！");
					return;
				}
				label3.Text = (Convert.ToDecimal(value) * Convert.ToInt32(text)).ToString();
			}
		}
		private void method_3()
		{
			DataTable dataTable = this.ishopNum1_Cart_Action_0.SearchShopByMemLoginID(this.string_1);
			this.repeater_0.DataSource = dataTable.DefaultView;
			this.repeater_0.DataBind();
			this.GetAllMoney();
			this.GetAllMarketMoney();
			this.GetSaveMoney();
		}
		protected void GetAllMoney()
		{
			this.label_0.Text = "0";
			for (int i = 0; i < this.repeater_0.Items.Count; i++)
			{
				Repeater repeater = (Repeater)this.repeater_0.Items[i].FindControl("RepeaterShopProduct");
				foreach (RepeaterItem repeaterItem in repeater.Items)
				{
					Label label = (Label)repeaterItem.FindControl("LabelAll");
					this.label_0.Text = Convert.ToString(Convert.ToDecimal(this.label_0.Text) + Convert.ToDecimal(label.Text));
				}
			}
		}
		protected void GetAllMarketMoney()
		{
			this.label_1.Text = "0";
			for (int i = 0; i < this.repeater_0.Items.Count; i++)
			{
				Repeater repeater = (Repeater)this.repeater_0.Items[i].FindControl("RepeaterShopProduct");
				foreach (RepeaterItem repeaterItem in repeater.Items)
				{
					Label label = (Label)repeaterItem.FindControl("labelMarketPrice");
					TextBox textBox = (TextBox)repeaterItem.FindControl("TextBoxBuyNumber");
					this.label_1.Text = Convert.ToString(Convert.ToDecimal(this.label_1.Text) + Convert.ToDecimal(label.Text) * Convert.ToInt32(textBox.Text));
				}
			}
		}
		protected void GetSaveMoney()
		{
			this.label_2.Text = Convert.ToString(Convert.ToDecimal(this.label_1.Text) - Convert.ToDecimal(this.label_0.Text));
		}
	}
}
