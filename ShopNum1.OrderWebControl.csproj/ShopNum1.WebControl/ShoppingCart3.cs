using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ShoppingCart3 : BaseWebControl
	{
		private string string_0 = "ShoppingCart3.ascx";
		private Label label_0;
		private Label label_1;
		private Repeater repeater_0;
		private Button button_0;
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private HiddenField hiddenField_2;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		public string BuyType
		{
			get;
			set;
		}
		public string Deposit
		{
			get;
			set;
		}
		public string OrganizGuid
		{
			get;
			set;
		}
		public string IsPayDeposit
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public ShoppingCart3()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
				this.label_1 = (Label)skin.FindControl("LabelPayPrice");
				this.label_0 = (Label)skin.FindControl("LabelPaymentName");
				this.repeater_0 = (Repeater)skin.FindControl("RepeaterOrder");
				this.literal_0 = (Literal)skin.FindControl("LiteralPayMemLoginID");
				this.button_0 = (Button)skin.FindControl("ButtonPay");
				this.button_0.Click += new EventHandler(this.button_0_Click);
				this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldPaymentGuid");
				this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldProductNames");
				this.hiddenField_2 = (HiddenField)skin.FindControl("HiddenFieldTradeID");
				if (this.Page.Request.QueryString["PaymentName"] != null)
				{
					this.label_0.Text = this.Page.Request.QueryString["PaymentName"].ToString();
				}
				if (this.Page.Request.QueryString["ShouldPayPrice"] != null)
				{
					this.label_1.Text = this.Page.Request.QueryString["ShouldPayPrice"].ToString();
				}
				if (this.Page.Request.QueryString["tradeid"] != null)
				{
					this.hiddenField_2.Value = this.Page.Request.QueryString["tradeid"];
				}
				this.GetOtherInfo();
			}
			else
			{
				GetUrl.RedirectLogin();
			}
		}
		protected void GetOtherInfo()
		{
			IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataSet dataSet = shopNum1_OrderInfo_Action.OrderInfoGetSimpleByTradeID(this.hiddenField_2.Value, this.MemLoginID);
			if (dataSet != null && dataSet.Tables.Count == 2)
			{
				this.label_1.Text = dataSet.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
				DataTable dataTable = dataSet.Tables[1];
				this.label_0.Text = dataTable.Rows[0]["PaymentName"].ToString();
				if (this.label_0.Text == "货到付款" || this.label_0.Text.IndexOf("线下") != -1)
				{
					this.button_0.Visible = false;
				}
				this.hiddenField_0.Value = dataTable.Rows[0]["PaymentGuid"].ToString().ToUpper();
				if (this.hiddenField_0.Value == "ACB3A3BD-3229-436D-90DD-001B9C29AF9A" || this.hiddenField_0.Value == "9ECA37CE-91C3-4D0C-8EFC-48D37A586D57" || this.hiddenField_0.Value == "D2038EF7-7466-412F-AB4C-773EADB7FFFA" || this.hiddenField_0.Value == "ACB3A3BD-3229-436D-90DD-001B9C29AF9A")
				{
					this.button_0.Visible = false;
				}
				this.hiddenField_1.Value = "";
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
				int num = 0;
				foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
				{
					HiddenField hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldOrderGuid");
					Repeater repeater = (Repeater)repeaterItem.FindControl("RepeaterOrderProduct");
					DataTable dataTable2 = shopNum1_OrderInfo_Action.SearchOrderSimpleProduct(hiddenField.Value, dataTable.Rows[num]["ShopID"].ToString());
					repeater.DataSource = dataTable2.DefaultView;
					repeater.DataBind();
					foreach (DataRow dataRow in dataTable2.Rows)
					{
						if (this.hiddenField_1.Value.Length >= 48)
						{
							this.hiddenField_1.Value = this.hiddenField_1.Value.Substring(0, 44) + "...";
							break;
						}
						this.hiddenField_1.Value = this.hiddenField_1.Value + ";" + dataRow["ProductName"];
					}
					num++;
				}
				this.literal_0.Text = dataTable.Rows[0]["PayMentMemLoginID"].ToString();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string shouldPayPrice = this.label_1.Text;
			if (this.BuyType == "0")
			{
				shouldPayPrice = this.label_1.Text;
			}
			else if (this.BuyType == "2")
			{
				shouldPayPrice = this.label_1.Text;
			}
			else if (this.BuyType == "3")
			{
				shouldPayPrice = this.label_1.Text;
			}
			else if (this.BuyType == "1")
			{
				if (this.Deposit == "0.00")
				{
					shouldPayPrice = this.label_1.Text;
				}
				else
				{
					shouldPayPrice = this.Deposit;
				}
			}
			string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
			PayUrlOperate payUrlOperate = new PayUrlOperate();
			string payUrl = payUrlOperate.GetPayUrl(this.hiddenField_0.Value, shouldPayPrice, this.Page.Request.Url.Host, this.hiddenField_1.Value, this.hiddenField_2.Value, "product", "1", this.literal_0.Text, this.MemLoginID, timetemp);
			if (payUrl.Length > 1000)
			{
				Encoding contentEncoding;
				if (payUrl.Split(new char[]
				{
					'|'
				})[0].IndexOf("UTF") != -1)
				{
					contentEncoding = Encoding.UTF8;
				}
				else
				{
					contentEncoding = Encoding.Default;
				}
				this.Page.Response.ContentEncoding = contentEncoding;
				this.Page.Response.Write(payUrl.Split(new char[]
				{
					'|'
				})[1]);
			}
			else
			{
				this.Page.Response.Redirect(payUrl);
			}
		}
	}
}
