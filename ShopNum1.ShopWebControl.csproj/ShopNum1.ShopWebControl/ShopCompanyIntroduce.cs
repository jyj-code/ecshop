using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopCompanyIntroduce : BaseWebControl
	{
		private string string_0 = "ShopCompanyIntroduce.ascx";
		private Repeater repeater_0;
		private Button button_0;
		[CompilerGenerated]
		private static string string_1;
		public static string ShopID
		{
			get;
			set;
		}
		public ShopCompanyIntroduce()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			ShopCompanyIntroduce.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.button_0 = (Button)skin.FindControl("ButtonBooking");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			string memloginid = shop_ShopInfo_Action.GetMemberLoginidByShopid(ShopCompanyIntroduce.ShopID).ToString();
			DataTable shopInfo = shop_ShopInfo_Action.GetShopInfo(memloginid);
			this.repeater_0.DataSource = shopInfo.DefaultView;
			this.repeater_0.DataBind();
		}
		public string RetrunRankPic(object object_0)
		{
			int num = int.Parse(object_0.ToString());
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable shopRankScoreScope = shop_ShopInfo_Action.GetShopRankScoreScope();
			string result;
			if (shopRankScoreScope.Rows.Count > 0)
			{
				int index = 0;
				if (0 >= shopRankScoreScope.Rows.Count)
				{
					result = "~/ImgUpload/ShopEnsureImg/2011061409442255_20100821181046611.jpg";
				}
				else if (num > int.Parse(shopRankScoreScope.Rows[index]["minScore"].ToString()) && num <= int.Parse(shopRankScoreScope.Rows[index]["maxScore"].ToString()))
				{
					result = shopRankScoreScope.Rows[index]["Pic"].ToString();
				}
				else
				{
					result = "~/ImgUpload/ShopEnsureImg/2011061409442255_20100821181046611.jpg";
				}
			}
			else
			{
				result = "~/ImgUpload/ShopEnsureImg/2011061409442255_20100821181046611.jpg";
			}
			return result;
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(GetPageName.RetUrl("ProductBooking"));
		}
	}
}
