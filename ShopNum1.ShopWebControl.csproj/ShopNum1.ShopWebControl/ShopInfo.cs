using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopInfo : BaseWebControl
	{
		private string string_0 = "ShopInfo.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private static string string_1;
		[CompilerGenerated]
		private string string_2;
		public static string ShopID
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public ShopInfo()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			ShopInfo.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			if (!this.Page.IsPostBack)
			{
				this.method_0(ShopInfo.ShopID);
			}
			try
			{
				this.method_1();
			}
			catch
			{
			}
		}
		private void method_0(string string_3)
		{
			HttpCookie httpCookie = this.Page.Request.Cookies["IsExitCount"];
			if (httpCookie == null)
			{
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
				shop_ShopInfo_Action.UpdateClickCount(string_3);
				HttpCookie httpCookie2 = new HttpCookie("IsExitCount");
				httpCookie2.Expires = DateTime.Now.AddDays(1.0);
				this.Page.Response.AppendCookie(httpCookie2);
			}
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label label = (Label)e.Item.FindControl("LabelShopRank");
				Image image = (Image)e.Item.FindControl("ImageReputation");
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
				DataTable shopRank = shop_ShopInfo_Action.GetShopRank(this.MemLoginID);
				if (shopRank != null && shopRank.Rows.Count > 0)
				{
					label.Text = shopRank.Rows[0]["Name"].ToString();
					image.ImageUrl = shopRank.Rows[0]["Pic"].ToString();
					Shop_Reputation_Action shop_Reputation_Action = (Shop_Reputation_Action)LogicFactory.CreateShop_Reputation_Action();
					DataTable dataTable = shop_Reputation_Action.ShopReputationSearch(shopRank.Rows[0]["ShopReputation"].ToString(), "0", "1");
					if (dataTable == null || dataTable.Rows.Count < 0)
					{
						image.ImageUrl = "";
					}
					else
					{
						DataTable dataTable2 = shop_Reputation_Action.ShopReputationSearch(shopRank.Rows[0]["ShopReputation"].ToString(), "0", "1");
						if (dataTable2 != null && dataTable2.Rows.Count > 0)
						{
							image.ImageUrl = dataTable2.Rows[0]["Pic"].ToString();
						}
					}
				}
			}
		}
		private void method_1()
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(ShopInfo.ShopID).ToString();
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable shopInfo = shop_ShopInfo_Action.GetShopInfo(this.MemLoginID);
			if (shopInfo.Rows.Count > 0)
			{
				this.repeater_0.DataSource = shopInfo.DefaultView;
				this.repeater_0.DataBind();
				Image image = (Image)this.repeater_0.Items[0].FindControl("ImageIdentity");
				Image image2 = (Image)this.repeater_0.Items[0].FindControl("ImageCompan");
				HtmlTableRow htmlTableRow = (HtmlTableRow)this.repeater_0.Items[0].FindControl("TRIdentity");
				if (!string.IsNullOrEmpty(shopInfo.Rows[0]["BusinessLicense"].ToString()) && shopInfo.Rows[0]["BusinessLicense"].ToString().IndexOf("logodfwe") == -1)
				{
					image2.Visible = true;
				}
				else
				{
					image2.Visible = false;
				}
				if (!string.IsNullOrEmpty(shopInfo.Rows[0]["CardImage"].ToString()))
				{
					image.Visible = true;
				}
				else
				{
					image.Visible = false;
				}
				if (string.IsNullOrEmpty(shopInfo.Rows[0]["CardImage"].ToString()) && string.IsNullOrEmpty(shopInfo.Rows[0]["BusinessLicense"].ToString()))
				{
					htmlTableRow.Visible = false;
				}
			}
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
					result = "";
				}
				else if (num > int.Parse(shopRankScoreScope.Rows[index]["minScore"].ToString()) && num <= int.Parse(shopRankScoreScope.Rows[index]["maxScore"].ToString()))
				{
					result = shopRankScoreScope.Rows[index]["Pic"].ToString();
				}
				else
				{
					result = "";
				}
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
