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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_ProductComment : BaseMemberWebControl
	{
		private string string_0 = "M_ProductComment.ascx";
		public static DataTable dt_order = null;
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
		public M_ProductComment()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_10 = (HtmlInputHidden)skin.FindControl("hidNick");
			this.htmlInputHidden_9 = (HtmlInputHidden)skin.FindControl("hidSpecValue");
			this.htmlInputHidden_7 = (HtmlInputHidden)skin.FindControl("hidProductName");
			this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("hidShopId");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidCtype");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidPGuId");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidCommentC");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidListCharacter");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidListSpeed");
			this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("hidListAttitude");
			this.htmlInputHidden_8 = (HtmlInputHidden)skin.FindControl("hidProductPrice");
			this.button_0 = (Button)skin.FindControl("btnSave");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (!this.Page.IsPostBack)
			{
				ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderProduct_Action();
				M_ProductComment.dt_order = shopNum1_OrderProduct_Action.SelectOrderProductByGuIdorAll(ShopNum1.Common.Common.ReqStr("orid"), "");
				if (M_ProductComment.dt_order.Rows.Count == 0)
				{
					M_ProductComment.dt_order = null;
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.htmlInputHidden_1.Value != "")
			{
				List<ShopNum1_Shop_ProductComment> list = new List<ShopNum1_Shop_ProductComment>();
				string value = ShopSettings.GetValue("ProductCommentISAudit");
				string[] array = (this.htmlInputHidden_1.Value + ",").Split(new char[]
				{
					','
				});
				string[] array2 = (this.htmlInputHidden_0.Value + ",").Split(new char[]
				{
					','
				});
				string[] array3 = (this.htmlInputHidden_2.Value + ",").Split(new char[]
				{
					','
				});
				string[] array4 = (this.htmlInputHidden_7.Value + ",").Split(new char[]
				{
					','
				});
				string[] array5 = (this.htmlInputHidden_8.Value + ",").Split(new char[]
				{
					','
				});
				string[] array6 = (this.htmlInputHidden_9.Value + ",").Split(new char[]
				{
					','
				});
				string[] array7 = (this.htmlInputHidden_10.Value + ",").Split(new char[]
				{
					','
				});
				string nameById = ShopNum1.Common.Common.GetNameById("shopname", "shopnum1_shopinfo", " and memloginid='" + this.htmlInputHidden_6.Value + "'");
				string nameById2 = ShopNum1.Common.Common.GetNameById("shopid", "shopnum1_shopinfo", " and memloginid='" + this.htmlInputHidden_6.Value + "'");
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != "")
					{
						ShopNum1_Shop_ProductComment shopNum1_Shop_ProductComment = new ShopNum1_Shop_ProductComment();
						shopNum1_Shop_ProductComment.Guid = Guid.NewGuid();
						shopNum1_Shop_ProductComment.CommentType = int.Parse(array2[i]);
						shopNum1_Shop_ProductComment.Speed = int.Parse(this.htmlInputHidden_4.Value);
						shopNum1_Shop_ProductComment.Comment = array3[i];
						shopNum1_Shop_ProductComment.ProductName = array4[i];
						if (shopNum1_Shop_ProductComment.Comment.Length > 500)
						{
							return;
						}
						shopNum1_Shop_ProductComment.CommentTime = DateTime.Now;
						shopNum1_Shop_ProductComment.IsDelete = 0;
						shopNum1_Shop_ProductComment.ProductGuid = array[i];
						shopNum1_Shop_ProductComment.ProductName = array4[i];
						shopNum1_Shop_ProductComment.SpecValue = array6[i];
						shopNum1_Shop_ProductComment.IsNick = new int?(Convert.ToInt32(array7[i]));
						shopNum1_Shop_ProductComment.ShopID = nameById2;
						shopNum1_Shop_ProductComment.ShopLoginId = this.htmlInputHidden_6.Value;
						shopNum1_Shop_ProductComment.ShopName = nameById;
						shopNum1_Shop_ProductComment.MemLoginID = this.MemLoginID;
						shopNum1_Shop_ProductComment.OrderGuid = ShopNum1.Common.Common.ReqStr("orid");
						shopNum1_Shop_ProductComment.Attitude = new int?(int.Parse(this.htmlInputHidden_5.Value));
						shopNum1_Shop_ProductComment.Character = new int?(int.Parse(this.htmlInputHidden_3.Value));
						shopNum1_Shop_ProductComment.ProductPrice = new decimal?(decimal.Parse(array5[i]));
						Shop_ProductComment_Action arg_315_0 = (Shop_ProductComment_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductComment_Action();
						if (value == "0")
						{
							shopNum1_Shop_ProductComment.IsAudit = 1;
							string s = (ShopSettings.GetValue("GoodAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("GoodAppraiseReputation");
							string s2 = (ShopSettings.GetValue("StandardAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("StandardAppraiseReputation");
							string s3 = (ShopSettings.GetValue("BadAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("BadAppraiseReputation");
							int score = 0;
							ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
							ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
							int num = (ShopSettings.GetValue("MyProductCommentRankSorce") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("MyProductCommentRankSorce"));
							int num2 = (ShopSettings.GetValue("MyProductCommentSorce") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("MyProductCommentSorce"));
							string text = array2[i];
							if (text != null)
							{
								if (!(text == "5"))
								{
									if (!(text == "3"))
									{
										if (text == "1")
										{
											score = -int.Parse(s3);
										}
									}
									else
									{
										score = int.Parse(s2);
									}
								}
								else
								{
									score = int.Parse(s);
								}
							}
							shopNum1_ShopInfoList_Action.UpdateShopReputationByMemLoginID(this.htmlInputHidden_6.Value, score);
							shopNum1_Member_Action.UpdateMemberScore(this.MemLoginID, num, num2);
							this.method_0(num2, num);
						}
						else
						{
							shopNum1_Shop_ProductComment.IsAudit = 0;
						}
						list.Add(shopNum1_Shop_ProductComment);
					}
				}
				ShopNum1.Common.Common.UpdateInfo("IsBuyComment=1", "shopnum1_orderinfo", " AND GUiD='" + ShopNum1.Common.Common.ReqStr("orid") + "'");
				ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductComment_Action();
				int num3 = shopNum1_ProductComment_Action.Add(list);
				if (num3 > 0)
				{
					this.OrderOperateLog("买家评价", "买家已经评价", "无");
					MessageBox.Show("评论成功！");
					this.Page.Response.Redirect("m_index.aspx?tomurl=M_FeedBack.aspx");
				}
				else
				{
					MessageBox.Show("评论失败！");
				}
			}
		}
		protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg)
		{
			if (!string.IsNullOrEmpty(ShopNum1.Common.Common.ReqStr("orid")))
			{
				ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
				shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
				shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(ShopNum1.Common.Common.ReqStr("orid"));
				shopNum1_OrderOperateLog.OderStatus = 1;
				shopNum1_OrderOperateLog.ShipmentStatus = 0;
				shopNum1_OrderOperateLog.PaymentStatus = 0;
				shopNum1_OrderOperateLog.CurrentStateMsg = CurrentStateMsg;
				shopNum1_OrderOperateLog.NextStateMsg = NextStateMsg;
				shopNum1_OrderOperateLog.Memo = memo;
				shopNum1_OrderOperateLog.OperateDateTime = DateTime.Now;
				shopNum1_OrderOperateLog.IsDeleted = 0;
				shopNum1_OrderOperateLog.CreateUser = this.MemLoginID;
				ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderOperateLog_Action();
				shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
			}
		}
		private void method_0(int int_0, int int_1)
		{
			string nameById = ShopNum1.Common.Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)", "shopnum1_member", " and memloginid='" + this.MemLoginID + "'");
			int num = 0;
			int num2 = 0;
			if (nameById != "" && nameById.IndexOf("-") != -1)
			{
				num = Convert.ToInt32(nameById.Split(new char[]
				{
					'-'
				})[1]);
				num2 = Convert.ToInt32(nameById.Split(new char[]
				{
					'-'
				})[0]);
			}
			if (int_0 > 0)
			{
				ShopNum1_ScoreModifyLog shopNum1_ScoreModifyLog = new ShopNum1_ScoreModifyLog();
				shopNum1_ScoreModifyLog.Guid = Guid.NewGuid();
				shopNum1_ScoreModifyLog.OperateType = 1;
				shopNum1_ScoreModifyLog.CurrentScore = num;
				shopNum1_ScoreModifyLog.OperateScore = int_0;
				shopNum1_ScoreModifyLog.LastOperateScore = int_0 + num;
				shopNum1_ScoreModifyLog.Date = DateTime.Now;
				shopNum1_ScoreModifyLog.Memo = "买家评论送消费积分";
				shopNum1_ScoreModifyLog.MemLoginID = this.MemLoginID;
				shopNum1_ScoreModifyLog.CreateUser = this.MemLoginID;
				shopNum1_ScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_ScoreModifyLog.IsDeleted = 0;
				ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
				shopNum1_ScoreModifyLog_Action.OperateScore(shopNum1_ScoreModifyLog);
			}
			if (int_1 > 0)
			{
				ShopNum1_RankScoreModifyLog shopNum1_RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
				shopNum1_RankScoreModifyLog.Guid = Guid.NewGuid();
				shopNum1_RankScoreModifyLog.OperateType = 1;
				shopNum1_RankScoreModifyLog.CurrentScore = num2;
				shopNum1_RankScoreModifyLog.OperateScore = int_1;
				shopNum1_RankScoreModifyLog.LastOperateScore = int_1 + num2;
				shopNum1_RankScoreModifyLog.Date = DateTime.Now;
				shopNum1_RankScoreModifyLog.Memo = "买家评论送等级积分";
				shopNum1_RankScoreModifyLog.MemLoginID = this.MemLoginID;
				shopNum1_RankScoreModifyLog.CreateUser = this.MemLoginID;
				shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_RankScoreModifyLog.IsDeleted = 0;
				ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
				shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
			}
		}
	}
}
