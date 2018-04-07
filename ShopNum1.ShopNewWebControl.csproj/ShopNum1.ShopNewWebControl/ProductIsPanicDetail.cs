using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class ProductIsPanicDetail : BaseWebControl
	{
		private string string_0 = string.Empty;
		private string string_1 = "ProductIsPanicDetailNew.ascx";
		private Repeater repeater_0;
		private Button button_0 = new Button();
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Label label_4;
		private Literal literal_0;
		private string string_2;
		private Label label_5;
		private Label label_6;
		private Label label_7;
		private Label label_8;
		private Label label_9;
		private Label label_10;
		private Label label_11;
		public static int int_0 = 0;
		public static int finished = 0;
		[CompilerGenerated]
		private static string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private static string string_6;
		public static string MemLoginID
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
		public static string Isfinished
		{
			get;
			set;
		}
		public ProductIsPanicDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			ProductIsPanicDetail.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.string_2 = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"].ToString());
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(ProductIsPanicDetail.MemLoginID);
			if (memLoginInfo.Rows.Count > 0)
			{
				this.MemberType = memLoginInfo.Rows[0]["MemberType"].ToString();
				this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
				if (this.Page.IsPostBack)
				{
				}
				this.method_0();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
				string shopid = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
				ProductIsPanicDetail.MemLoginID = shop_ShopInfo_Action.GetMemberLoginidByShopid(shopid).ToString();
				httpCookie.Values["MemberType"].ToString();
				if (ProductIsPanicDetail.MemLoginID != this.MemberLoginID)
				{
					Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
					if (shop_Product_Action.CheckMenberBuyProduct(this.string_2, this.MemberLoginID).Rows.Count > 0)
					{
						MessageBox.Show("您已经购买过");
					}
					else
					{
						string url = string.Concat(new string[]
						{
							"http://",
							this.Page.Request.Url.Host,
							"/ProductDetail/",
							ShopNum1.Common.Common.ReqStr("GuID"),
							".html?type=qg&"
						});
						this.Page.Response.Redirect(url);
					}
				}
				else
				{
					MessageBox.Show("您不能购买自己的商品！");
				}
			}
			else
			{
				GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再购买！");
			}
		}
		private void method_0()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			DataSet panicInfo = shop_Product_Action.GetPanicInfo(ProductIsPanicDetail.MemLoginID, this.string_2);
			if (panicInfo.Tables[0].Rows.Count > 0)
			{
				this.string_2 = panicInfo.Tables[0].Rows[0]["Guid"].ToString();
				this.repeater_0.DataSource = panicInfo;
				this.repeater_0.DataBind();
				foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
				{
					this.label_5 = (Label)repeaterItem.FindControl("lblCharactervg");
					this.label_6 = (Label)repeaterItem.FindControl("lblAllnum");
					this.label_7 = (Label)repeaterItem.FindControl("lblGoodCount");
					this.label_8 = (Label)repeaterItem.FindControl("lblMiddelCount");
					this.label_9 = (Label)repeaterItem.FindControl("lblBadCount");
					this.label_10 = (Label)repeaterItem.FindControl("lblTotal");
					this.label_11 = (Label)repeaterItem.FindControl("lblContinue");
					DataTable dataTable = panicInfo.Tables[1];
					if (dataTable.Rows.Count > 0)
					{
						this.label_5.Text = ((dataTable.Rows[0]["Characteravg"].ToString() == "") ? "0" : dataTable.Rows[0]["Characteravg"].ToString());
						this.label_6.Text = dataTable.Rows[0]["Allnum"].ToString();
					}
					if (panicInfo.Tables[2].Rows.Count > 0)
					{
						string text = panicInfo.Tables[2].Rows[0]["py"].ToString();
						this.label_10.Text = text.Split(new char[]
						{
							'-'
						})[0];
						this.label_7.Text = text.Split(new char[]
						{
							'-'
						})[1];
						this.label_8.Text = text.Split(new char[]
						{
							'-'
						})[2];
						this.label_9.Text = text.Split(new char[]
						{
							'-'
						})[3];
						this.label_11.Text = text.Split(new char[]
						{
							'-'
						})[4];
					}
					new Button();
					this.button_0 = (Button)repeaterItem.FindControl("ButtonShopCar");
					this.button_0.Click += new EventHandler(this.button_0_Click);
					this.label_4 = (Label)repeaterItem.FindControl("LabelTime");
					this.label_0 = (Label)repeaterItem.FindControl("LabelName");
					this.label_1 = (Label)repeaterItem.FindControl("LabelShopPrice");
					this.label_2 = (Label)repeaterItem.FindControl("LabelCarriage");
					this.label_3 = (Label)repeaterItem.FindControl("LabelRepertoryCount");
					Repeater repeater = (Repeater)repeaterItem.FindControl("RepeaterDateImage");
					this.literal_0 = (Literal)repeaterItem.FindControl("LiteralMemLoginID");
					string[] array = panicInfo.Tables[0].Rows[0]["multiimages"].ToString().Split(new char[]
					{
						','
					});
					DataTable dataTable2 = new DataTable();
					dataTable2.Columns.Add("imgurl", Type.GetType("System.String"));
					if (array.Length > 0)
					{
						for (int i = 0; i < array.Length; i++)
						{
							DataRow dataRow = dataTable2.NewRow();
							dataRow["imgurl"] = array[i];
							dataTable2.Rows.Add(dataRow);
						}
					}
					else
					{
						DataRow dataRow2 = dataTable2.NewRow();
						dataRow2["imgurl"] = panicInfo.Tables[0].Rows[0]["multiimages"].ToString();
						dataTable2.Rows.Add(dataRow2);
					}
					repeater.DataSource = dataTable2;
					repeater.DataBind();
				}
				if (DateTime.Parse(panicInfo.Tables[0].Rows[0]["StartTime"].ToString()) > DateTime.Now)
				{
					this.button_0.Enabled = false;
					this.label_4.Text = "开始倒计时：";
				}
				else
				{
					this.label_4.Text = "结束倒计时：";
				}
				if (DateTime.Parse(panicInfo.Tables[0].Rows[0]["EndTime"].ToString()) < DateTime.Now)
				{
					this.button_0.Enabled = false;
					this.label_4.Text = "已结束时间：";
					ProductIsPanicDetail.finished = 1;
					ProductIsPanicDetail.Isfinished = "1";
				}
				if (!string.IsNullOrEmpty(panicInfo.Tables[0].Rows[0]["SaleNumber"].ToString()) && int.Parse(panicInfo.Tables[0].Rows[0]["repertorycount"].ToString()) <= int.Parse(panicInfo.Tables[0].Rows[0]["SaleNumber"].ToString()))
				{
					this.button_0.Enabled = false;
					ProductIsPanicDetail.finished = 1;
					ProductIsPanicDetail.Isfinished = "1";
				}
			}
		}
		public static string SetNoNull(object value)
		{
			string result;
			if (value.ToString() == "")
			{
				result = "0";
			}
			else
			{
				result = value.ToString();
			}
			return result;
		}
		public static string IsBegin(object begin, object object_0)
		{
			string result;
			if (DateTime.Parse(begin.ToString()) > DateTime.Now)
			{
				Convert.ToDateTime(begin.ToString()).ToString();
				result = Convert.ToDateTime(begin.ToString()).ToString();
			}
			else
			{
				result = Convert.ToDateTime(object_0.ToString()).ToString();
			}
			return result;
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
		public static int GetCount(object PanicBuyCount, object SaledNum)
		{
			int result;
			if (!string.IsNullOrEmpty(SaledNum.ToString()))
			{
				result = int.Parse(PanicBuyCount.ToString()) - int.Parse(SaledNum.ToString());
			}
			else
			{
				result = int.Parse(PanicBuyCount.ToString());
			}
			return result;
		}
		public static string SetLastBuyTime(object MemberName, object LastTine)
		{
			string result;
			if (!string.IsNullOrEmpty(MemberName.ToString()))
			{
				result = MemberName.ToString() + "在" + LastTine.ToString() + "购买了它";
			}
			else
			{
				result = "当前还无人购买";
			}
			return result;
		}
		public static string returnImagePath(object object_0)
		{
			string newValue = "http://" + ProductIsPanicDetail.MemLoginID + ConfigurationManager.AppSettings["Domain"];
			return object_0.ToString().Replace("~/", newValue);
		}
	}
}
