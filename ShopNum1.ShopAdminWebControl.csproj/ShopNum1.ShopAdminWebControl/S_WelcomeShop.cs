using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_WelcomeShop : BaseShopWebControl
	{
		private string string_0 = "S_Welcome.ascx";
		private Label label_0;
		private HtmlImage htmlImage_0;
		private HtmlImage htmlImage_1;
		private Label label_1;
		private Label label_2;
		private Image image_0;
		private Label label_3;
		private Label label_4;
		private Label label_5;
		private Label label_6;
		private Label label_7;
		private Label label_8;
		private Label label_9;
		private Label label_10;
		private Label label_11;
		private Label label_12;
		private Label label_13;
		private Label label_14;
		private Label label_15;
		private Image image_1;
		private Label label_16;
		private Label label_17;
		private Repeater repeater_0;
		private Label label_18;
		private Label label_19;
		private Label label_20;
		private Label label_21;
		private Label label_22;
		private Label label_23;
		private Label label_24;
		private Label label_25;
		private Label label_26;
		private Label label_27;
		private Label label_28;
		private Label label_29;
		private Label label_30;
		private Label label_31;
		private Label label_32;
		private Button button_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputHidden htmlInputHidden_3;
		private Image image_2;
		private HtmlAnchor htmlAnchor_0;
		private Label label_33;
		public S_WelcomeShop()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_33 = (Label)skin.FindControl("LabelSubstationID");
			this.image_2 = (Image)skin.FindControl("ImageShopSign");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("shopUrlA");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidShopRate");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidDetail");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidService");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidSpeed");
			this.button_0 = (Button)skin.FindControl("ButtonGoPayFor");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.label_32 = (Label)skin.FindControl("LabelVerifyTime");
			this.label_0 = (Label)skin.FindControl("LabelShopName");
			this.label_1 = (Label)skin.FindControl("LabelName");
			this.htmlImage_0 = (HtmlImage)skin.FindControl("imageIdd");
			this.htmlImage_1 = (HtmlImage)skin.FindControl("imageCompany");
			this.label_2 = (Label)skin.FindControl("LabelShopRank");
			this.image_0 = (Image)skin.FindControl("ImagePic");
			this.label_3 = (Label)skin.FindControl("LabelSaleCount");
			this.label_4 = (Label)skin.FindControl("LabelMemberReport");
			this.label_5 = (Label)skin.FindControl("LabelSaleOnline");
			this.label_6 = (Label)skin.FindControl("LabelAdvancePayment");
			this.label_7 = (Label)skin.FindControl("LabelPayOrderIng");
			this.label_8 = (Label)skin.FindControl("LabelOrderComplaint");
			this.label_9 = (Label)skin.FindControl("LabelWaitPayOrder");
			this.label_10 = (Label)skin.FindControl("LabelWaitSendProduct");
			this.label_11 = (Label)skin.FindControl("LabelWaitGetProduct");
			this.label_12 = (Label)skin.FindControl("LabelWaitPinjia");
			this.label_13 = (Label)skin.FindControl("LabelReturnMoney");
			this.label_14 = (Label)skin.FindControl("LabelReturnProduct");
			this.label_15 = (Label)skin.FindControl("LabelShopReputation");
			this.image_1 = (Image)skin.FindControl("ImageShopReputation");
			this.label_16 = (Label)skin.FindControl("Label_MessageBoard");
			this.label_17 = (Label)skin.FindControl("LabelProductComment");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterAnnouncement");
			this.label_18 = (Label)skin.FindControl("Labelztcj");
			this.label_19 = (Label)skin.FindControl("Labelztje");
			this.label_20 = (Label)skin.FindControl("Labelztuser");
			this.label_21 = (Label)skin.FindControl("Labelztzhl");
			this.label_22 = (Label)skin.FindControl("Labelztorder");
			this.label_23 = (Label)skin.FindControl("Labelqtcj");
			this.label_24 = (Label)skin.FindControl("Labelqtje");
			this.label_25 = (Label)skin.FindControl("Labelqtuser");
			this.label_26 = (Label)skin.FindControl("Labelqtzhl");
			this.label_27 = (Label)skin.FindControl("Labelqtorder");
			this.label_28 = (Label)skin.FindControl("LabelSumComment");
			this.label_29 = (Label)skin.FindControl("LabelSumCommentGood");
			this.label_30 = (Label)skin.FindControl("LabelSumCommentZhong");
			this.label_31 = (Label)skin.FindControl("LabelSumCommentCha");
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + this.MemLoginID + "'  ");
				if (!string.IsNullOrEmpty(nameById))
				{
					string nameById2 = ShopNum1.Common.Common.GetNameById("Name", "ShopNum1_SubstationManage", "   AND SubstationID='" + nameById + "'  ");
					this.label_33.Text = nameById2;
				}
				string nameById3 = ShopNum1.Common.Common.GetNameById("ShopRank", "ShopNum1_ShopInfo", "   AND   MemLoginID='" + this.MemLoginID + "'");
				string nameById4 = ShopNum1.Common.Common.GetNameById("IsDefault", "ShopNum1_ShopRank", "   AND     Guid='" + nameById3 + "'");
				if (nameById4 == "0")
				{
					this.label_32.Text = "永久";
					this.button_0.Text = "升级";
				}
				else
				{
					this.button_0.Text = "续费";
					this.label_32.Text = ShopNum1.Common.Common.GetNameById("VerifyTime", "ShopNum1_Shop_ApplyShopRank", string.Concat(new string[]
					{
						"  AND      RankGuid='",
						nameById3,
						"'   AND  MemberLoginID='",
						this.MemLoginID,
						"'"
					}));
					try
					{
						DateTime now = DateTime.Now;
						DateTime t = Convert.ToDateTime(this.label_32.Text);
						if (DateTime.Compare(now, t) == 1)
						{
							string nameById5 = ShopNum1.Common.Common.GetNameById("Guid", "ShopNum1_ShopRank", "   AND     IsDefault=0  ");
							Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
							shop_Rank_Action.UpdateUserRank(nameById5, this.MemLoginID);
							shop_Rank_Action.ClearApplyShopRank(this.MemLoginID);
						}
					}
					catch (Exception)
					{
					}
				}
				this.GetDataInfo(nameById3);
				this.GetAnnouncement();
				if (!this.Page.IsPostBack)
				{
					this.method_0();
				}
			}
			catch (Exception)
			{
			}
		}
		private void method_0()
		{
			Shop_ProductComment_Action shop_ProductComment_Action = (Shop_ProductComment_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductComment_Action();
			string goodRate = shop_ProductComment_Action.GetGoodRate(this.MemLoginID, "4");
			if (goodRate != "")
			{
				this.htmlInputHidden_0.Value = goodRate.Split(new char[]
				{
					'|'
				})[0];
				this.htmlInputHidden_3.Value = goodRate.Split(new char[]
				{
					'|'
				})[1];
				this.htmlInputHidden_1.Value = goodRate.Split(new char[]
				{
					'|'
				})[2];
				this.htmlInputHidden_2.Value = goodRate.Split(new char[]
				{
					'|'
				})[3];
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ShowShopRank.aspx");
		}
		public void GetDataInfo(string rankGuid)
		{
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("Banner", "ShopNum1_ShopInfo", "   AND   MemLoginID='" + this.MemLoginID + "'");
				string nameById2 = ShopNum1.Common.Common.GetNameById("ShopUrl", "ShopNum1_ShopInfo", "   AND   MemLoginID='" + this.MemLoginID + "'");
				if (!string.IsNullOrEmpty(nameById2))
				{
					string siteDomain = ShopSettings.siteDomain;
					try
					{
						ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
						DataTable substationByShopInfo = shopNum1_SubstationManage_Action.GetSubstationByShopInfo(this.MemLoginID);
						string text = string.Empty;
						string text2 = string.Empty;
						if (substationByShopInfo != null && substationByShopInfo.Rows.Count > 0)
						{
							text = substationByShopInfo.Rows[0]["SubstationID"].ToString();
						}
						if (text != "all")
						{
							text2 = shopNum1_SubstationManage_Action.GetDomainNameBySubstationID(text);
						}
						this.htmlAnchor_0.HRef = string.Concat(new string[]
						{
							"http://",
							nameById2,
							".",
							text2,
							ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'))
						});
					}
					catch (Exception)
					{
						this.htmlAnchor_0.HRef = "http://" + siteDomain.ToString();
					}
				}
				if (!string.IsNullOrEmpty(nameById))
				{
					this.image_2.ImageUrl = nameById;
				}
				else
				{
					this.image_2.ImageUrl = "~/ImgUpload/noImage.gif";
				}
				this.label_1.Text = this.MemLoginID;
				string nameById3 = ShopNum1.Common.Common.GetNameById("CardImage", "ShopNum1_ShopInfo", " AND  MemLoginID='" + this.MemLoginID + "'");
				if (!string.IsNullOrEmpty(nameById3))
				{
					this.htmlImage_0.Visible = true;
				}
				else
				{
					this.htmlImage_0.Visible = false;
				}
				string nameById4 = ShopNum1.Common.Common.GetNameById("BusinessLicense", "ShopNum1_ShopInfo", " AND  MemLoginID='" + this.MemLoginID + "'");
				if (!string.IsNullOrEmpty(nameById4) && nameById4.IndexOf("logodfwe.jpg") == -1)
				{
					this.htmlImage_1.Visible = true;
				}
				else
				{
					this.htmlImage_1.Visible = false;
				}
				this.label_15.Text = ShopNum1.Common.Common.GetNameById("ShopReputation", "ShopNum1_ShopInfo", " AND  MemLoginID='" + this.MemLoginID + "'");
				this.label_0.Text = ShopNum1.Common.Common.GetNameById("ShopName", "ShopNum1_ShopInfo", " AND  MemLoginID='" + this.MemLoginID + "'");
				int num = Convert.ToInt32(this.label_15.Text);
				DataTable tableById = ShopNum1.Common.Common.GetTableById("minScore,maxScore,Pic", "ShopNum1_ShopReputation", " AND  1=1 and isdeleted=0 ");
				if (tableById != null && tableById.Rows.Count > 0)
				{
					foreach (DataRow dataRow in tableById.Rows)
					{
						if (num >= Convert.ToInt32(dataRow["minScore"].ToString()) && num <= Convert.ToInt32(dataRow["maxScore"].ToString()))
						{
							this.image_1.ImageUrl = "~/" + dataRow["Pic"].ToString();
						}
					}
				}
				this.label_2.Text = ShopNum1.Common.Common.GetNameById("Name", "ShopNum1_ShopRank", " AND  Guid='" + rankGuid + "'");
				this.image_0.ImageUrl = ShopNum1.Common.Common.GetNameById("Pic", "ShopNum1_ShopRank", " AND  Guid='" + rankGuid + "'");
				this.label_3.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_Product", " AND  MemLoginID='" + this.MemLoginID + "' and issell=0 and issaled=1 and isdeleted=0 and isaudit=1");
				this.label_4.Text = ShopNum1.Common.Common.GetNameById("COUNT(ID)", "ShopNum1_MemberReport", "    AND    ReportShop='" + this.MemLoginID + "'");
				this.label_5.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_Product", " AND  MemLoginID='" + this.MemLoginID + "' and issell=1 and issaled=1 and isdeleted=0 and isaudit=1");
				this.label_6.Text = ShopNum1.Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member", " AND  MemLoginID='" + this.MemLoginID + "'");
				this.label_16.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_MessageBoard", " AND  ReplyUser='" + this.MemLoginID + "'");
				this.label_7.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND  OderStatus IN(0,1,2)  AND    shopid='" + this.MemLoginID + "' and isdeleted=0");
				this.label_8.Text = ShopNum1.Common.Common.GetNameById("COUNT(ID)", "ShopNum1_OrderComplaint", " AND  ComplaintShop ='" + this.MemLoginID + "'");
				this.label_9.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND  PaymentStatus =0 AND  OderStatus =0  AND    shopid='" + this.MemLoginID + "' and isdeleted=0   ");
				this.label_10.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND  OderStatus =1 And  ShipmentStatus=0 And paymentstatus=1  AND    shopid='" + this.MemLoginID + "' and isdeleted=0  ");
				this.label_11.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND  OderStatus =2  And  ShipmentStatus=1 And paymentstatus=1 AND  shopid='" + this.MemLoginID + "'  and isdeleted=0  ");
				this.label_12.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND   IsBuyComment=0   AND   OderStatus=3 And  ShipmentStatus=2 And paymentstatus=1 AND isdeleted=0 and    shopid='" + this.MemLoginID + "'   ");
				this.label_13.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND   paymentstatus=3   AND    shopid='" + this.MemLoginID + "' and isdeleted=0   ");
				this.label_14.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND   ShipmentStatus=4   AND    shopid='" + this.MemLoginID + "' and isdeleted=0   ");
				this.label_17.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_ProductComment", string.Concat(new object[]
				{
					" AND   CommentTime >='",
					DateTime.Now.AddMonths(-1),
					"'    AND    shoploginid='",
					this.MemLoginID,
					"'   "
				}));
				this.label_18.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND    OderStatus=3   AND    shopid='" + this.MemLoginID + "'  AND   datediff(day,ReceiptTime,getdate())=0 ");
				decimal num2 = 0m;
				string nameById5 = ShopNum1.Common.Common.GetNameById("SUM(shouldpayprice)", "ShopNum1_OrderInfo", " AND    OderStatus=3   AND    shopid='" + this.MemLoginID + "'  AND  datediff(day,ReceiptTime,getdate())=0 and isdeleted=0  ");
				if (nameById5 != "")
				{
					num2 = Convert.ToDecimal(nameById5);
				}
				this.label_19.Text = num2.ToString();
				int num3 = 0;
				string nameById6 = ShopNum1.Common.Common.GetNameById("COUNT(MemLoginID)", "ShopNum1_OrderInfo", " AND    OderStatus=3   AND    shopid='" + this.MemLoginID + "'  AND  datediff(day,ReceiptTime,getdate())=0 and isdeleted=0    GROUP BY  MemLoginID  ");
				if (nameById6 != "")
				{
					num3 = Convert.ToInt32(nameById6);
				}
				this.label_20.Text = num3.ToString();
				int num4 = Convert.ToInt32(this.label_18.Text);
				int num5 = Convert.ToInt32(ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND    OderStatus<3   AND    shopid='" + this.MemLoginID + "' and isdeleted=0    "));
				int num6 = Convert.ToInt32(ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND    OderStatus<3   AND    shopid='" + this.MemLoginID + "'  AND datediff(day,CreateTime,getdate())=0  and isdeleted=0   "));
				int num7 = num5 - num6;
				int num8 = num7 + num4;
				double num9 = 0.0;
				if (num4 != 0 && num8 != 0)
				{
					num9 = Convert.ToDouble(num4) / Convert.ToDouble(num8);
				}
				this.label_21.Text = (Convert.ToDouble(num9.ToString("0.00")) * 100.0).ToString() + "%";
				this.label_22.Text = ShopNum1.Common.Common.GetNameById("COUNT(*)", "shopnum1_refund", " AND    shopid='" + this.MemLoginID + "'  AND  datediff(day,applytime,getdate())=0 ");
				this.label_23.Text = ShopNum1.Common.Common.GetNameById("COUNT(*)", "ShopNum1_OrderInfo", " AND    OderStatus=3   AND    shopid='" + this.MemLoginID + "'  AND datediff(day,ReceiptTime,getdate())=1 and isdeleted=0   ");
				decimal num10 = 0m;
				string nameById7 = ShopNum1.Common.Common.GetNameById("SUM(shouldpayprice)", "ShopNum1_OrderInfo", " AND    OderStatus=3   AND    shopid='" + this.MemLoginID + "'  AND  datediff(day,ReceiptTime,getdate())=1  and isdeleted=0    ");
				if (nameById7 != "")
				{
					num10 = Convert.ToDecimal(nameById7);
				}
				this.label_24.Text = num10.ToString();
				int num11 = 0;
				string nameById8 = ShopNum1.Common.Common.GetNameById("COUNT(*)", "ShopNum1_OrderInfo", " AND    OderStatus=3   AND  shopid='" + this.MemLoginID + "'  AND  datediff(day,ReceiptTime,getdate())=1  and isdeleted=0    GROUP BY  MemLoginID  ");
				if (nameById8 != "")
				{
					num11 = Convert.ToInt32(nameById8);
				}
				this.label_25.Text = num11.ToString();
				int num12 = Convert.ToInt32(this.label_23.Text);
				int num13 = Convert.ToInt32(ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND    OderStatus<3   AND    shopid='" + this.MemLoginID + "'  and isdeleted=0    "));
				int num14 = Convert.ToInt32(ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND    OderStatus<3   AND    shopid='" + this.MemLoginID + "'  and isdeleted=0   AND datediff(day,ReceiptTime,getdate())=0 "));
				int num15 = Convert.ToInt32(ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND    OderStatus<3   AND    shopid='" + this.MemLoginID + "'  and isdeleted=0    AND datediff(day,CreateTime,getdate())=1"));
				int num16 = num13 - num14 - num15;
				int num17 = num16 + num12;
				double num18 = 0.0;
				if (num12 != 0 && num17 != 0)
				{
					num18 = Convert.ToDouble(num12) / Convert.ToDouble(num17);
				}
				this.label_26.Text = (Convert.ToDouble(num18.ToString("0.00")) * 100.0).ToString() + "%";
				this.label_27.Text = ShopNum1.Common.Common.GetNameById("COUNT(*)", "shopnum1_refund", " AND   shopid='" + this.MemLoginID + "'  AND  datediff(day,applytime,getdate())=1 ");
				this.label_28.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_ProductComment", " AND  shoploginid='" + this.MemLoginID + "'   ");
				this.label_29.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_ProductComment", string.Concat(new string[]
				{
					" AND   shoploginid='",
					this.MemLoginID,
					"'   AND  commenttype=5   AND   CommentTime>=  '",
					DateTime.Now.AddDays(-30.0).ToString("yyyyMMdd"),
					"'"
				}));
				this.label_30.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_ProductComment", string.Concat(new string[]
				{
					" AND    shoploginid='",
					this.MemLoginID,
					"'   AND  commenttype=3  AND   CommentTime >=   '",
					DateTime.Now.AddDays(-30.0).ToString("yyyyMMdd"),
					"' "
				}));
				this.label_31.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_ProductComment", string.Concat(new string[]
				{
					" AND  shoploginid='",
					this.MemLoginID,
					"'   AND  commenttype=1  AND   CommentTime >=   '",
					DateTime.Now.AddDays(-30.0).ToString("yyyyMMdd"),
					"' "
				}));
			}
			catch (Exception)
			{
			}
		}
		public void GetAnnouncement()
		{
			ShopNum1_Announcement_Action shopNum1_Announcement_Action = (ShopNum1_Announcement_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Announcement_Action();
			string substationID = string.Empty;
			try
			{
				substationID = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + this.MemLoginID + "'    ");
			}
			catch (Exception)
			{
			}
			DataTable announcementByTypeName = shopNum1_Announcement_Action.GetAnnouncementByTypeName("店铺公告", 5, substationID);
			if (announcementByTypeName != null && announcementByTypeName.Rows.Count > 0)
			{
				this.repeater_0.DataSource = announcementByTypeName.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
