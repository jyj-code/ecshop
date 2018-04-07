using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class CouponList : BaseWebControl
	{
		private string string_0 = "CouponListNew.ascx";
		private Repeater repeater_0;
		private HtmlImage htmlImage_0;
		private HtmlImage htmlImage_1;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private Panel panel_0;
		private string string_1 = GetPageName.AgentGetPage("");
		private int int_0;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		private string MemLoginID
		{
			get;
			set;
		}
		private string ShopID
		{
			get;
			set;
		}
		public int ShowCount
		{
			get;
			set;
		}
		public string ordername
		{
			get;
			set;
		}
		public string soft
		{
			get;
			set;
		}
		public CouponList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.panel_0 = (Panel)skin.FindControl("PanelNoFind");
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(this.Page.Request.QueryString["PageID"]);
			}
			catch
			{
				this.int_0 = 1;
			}
			this.ordername = ((this.Page.Request.QueryString["ordername"] == null) ? "guid" : this.Page.Request.QueryString["ordername"].ToString());
			this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "desc" : this.Page.Request.QueryString["sort"].ToString());
			this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(this.ShopID).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.method_0();
		}
		private void method_0()
		{
			Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)LogicFactory.CreateShop_Coupon_Action();
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			DataSet dataSet = shop_Coupon_Action.SearchCouponByMemloginID(this.MemLoginID, this.ordername, this.soft, this.ShowCount.ToString(), this.int_0.ToString(), "1");
			if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("CouponList", true);
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_0.Text = this.int_0.ToString();
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = pageList.PageCount.ToString();
			DataSet dataSet2 = shop_Coupon_Action.SearchCouponByMemloginID(this.MemLoginID, this.ordername, this.soft, this.ShowCount.ToString(), this.int_0.ToString(), "0");
			if (dataSet2.Tables[0] == null || dataSet2.Tables[0].Rows.Count == 0)
			{
				this.panel_0.Visible = true;
			}
			else
			{
				this.repeater_0.DataSource = dataSet2.Tables[0];
				this.repeater_0.DataBind();
				for (int i = 0; i < this.repeater_0.Items.Count; i++)
				{
					this.htmlImage_1 = (HtmlImage)this.repeater_0.Items[i].FindControl("ImgCoupon");
					this.htmlImage_1.Src = this.Page.ResolveUrl(dataSet2.Tables[0].Rows[i]["ImgPath"].ToString());
					this.htmlImage_0 = (HtmlImage)this.repeater_0.Items[i].FindControl("imgIsEffective");
					if (dataSet2.Tables[0].Rows[i]["IsEffective"].ToString() == "0" || Convert.ToDateTime(dataSet2.Tables[0].Rows[i]["EndTime"].ToString()) < DateTime.Now)
					{
						this.htmlImage_0.Src = "../Images/unineffect.gif";
					}
					else
					{
						this.htmlImage_0.Src = "../Images/ineffect.gif";
					}
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = this.textBox_0.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?sort=",
				this.soft,
				"&ordername=",
				this.ordername,
				"&pageid=",
				text
			}));
		}
		protected string GetWebFilePath()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable openTimeByShopID = shop_ShopInfo_Action.GetOpenTimeByShopID(this.ShopID);
			string text = DateTime.Parse(openTimeByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			string text2 = string.Concat(new string[]
			{
				"~/ImgUpload/",
				text.Replace("-", "/"),
				"/shop",
				this.ShopID,
				"/Coupon/"
			});
			if (!Directory.Exists(HttpContext.Current.Server.MapPath(text2)))
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath(text2));
			}
			return text2;
		}
	}
}
