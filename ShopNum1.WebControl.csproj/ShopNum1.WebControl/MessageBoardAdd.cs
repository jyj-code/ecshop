using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class MessageBoardAdd : BaseWebControl
	{
		private string string_0 = "MessageBoardAdd.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private Button button_0;
		private HtmlTableRow htmlTableRow_0;
		private HtmlAnchor htmlAnchor_0;
		private RadioButtonList radioButtonList_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string MessageCondition
		{
			get;
			set;
		}
		public string MessageConditionVerifyCode
		{
			get;
			set;
		}
		public MessageBoardAdd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("trCode");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("LoginHref");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxContent");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.radioButtonList_0 = (RadioButtonList)skin.FindControl("RadioButtonListmessageType");
			this.method_0();
			this.MessageConditionVerifyCode = ShopSettings.GetValue("MessageVerifyCode");
			if (this.MessageConditionVerifyCode == "0")
			{
				this.htmlTableRow_0.Visible = false;
			}
			else
			{
				this.textBox_3 = (TextBox)skin.FindControl("TextBoxCode");
			}
			this.MessageCondition = ShopSettings.GetValue("MessageCondition");
			if (this.MessageCondition == "1")
			{
				if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
				{
					HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					this.textBox_0.Text = httpCookie.Values["MemLoginID"].ToString();
					this.textBox_0.ReadOnly = true;
					this.htmlAnchor_0.Visible = false;
				}
				else
				{
					this.htmlAnchor_0.Visible = true;
					this.htmlAnchor_0.HRef = "http://" + ShopSettings.siteDomain + "/Login" + (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
				}
			}
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.IsPostBack)
			{
			}
		}
		private void method_0()
		{
			ListItem listItem = new ListItem();
			listItem.Text = "售后";
			listItem.Value = "0";
			this.radioButtonList_0.Items.Add(listItem);
			ListItem listItem2 = new ListItem();
			listItem2.Text = "询问";
			listItem2.Value = "1";
			this.radioButtonList_0.Items.Add(listItem2);
			ListItem listItem3 = new ListItem();
			listItem3.Text = "一般信息";
			listItem3.Value = "2";
			this.radioButtonList_0.Items.Add(listItem3);
			ListItem listItem4 = new ListItem();
			listItem4.Text = "求购";
			listItem4.Value = "3";
			this.radioButtonList_0.Items.Add(listItem4);
			ListItem listItem5 = new ListItem();
			listItem5.Text = "留言";
			listItem5.Value = "4";
			this.radioButtonList_0.Items.Add(listItem5);
			ListItem listItem6 = new ListItem();
			listItem6.Text = "重要消息";
			listItem6.Value = "5";
			this.radioButtonList_0.Items.Add(listItem6);
			this.radioButtonList_0.Items[0].Selected = true;
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.MessageCondition == "1" && this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
			}
			else
			{
				if (this.MessageConditionVerifyCode == "1")
				{
					if (this.textBox_3.Text == null)
					{
						MessageBox.Show("验证码不能为空值！");
						return;
					}
					if (this.Page.Session["code"] == null)
					{
						MessageBox.Show("验证码有误！");
						return;
					}
					if (this.textBox_3.Text.ToUpper() != this.Page.Session["code"].ToString().ToUpper())
					{
						MessageBox.Show("验证码输入错误！");
						return;
					}
				}
				ShopNum1_MessageBoard shopNum1_MessageBoard = new ShopNum1_MessageBoard();
				shopNum1_MessageBoard.Guid = Guid.NewGuid();
				shopNum1_MessageBoard.MessageType = this.radioButtonList_0.SelectedValue;
				shopNum1_MessageBoard.MemLoginID = this.textBox_0.Text.Trim();
				shopNum1_MessageBoard.ReplyUser = "";
				shopNum1_MessageBoard.Title = this.textBox_1.Text.ToString().Trim();
				shopNum1_MessageBoard.Content = this.textBox_2.Text.ToString().Trim();
				shopNum1_MessageBoard.ModifyUser = this.textBox_0.Text.ToString().Trim();
				shopNum1_MessageBoard.ModifyTime = DateTime.Now;
				if (ShopSettings.GetValue("MessageCommentISAudit") == "1")
				{
					shopNum1_MessageBoard.IsAudit = 0;
				}
				else
				{
					shopNum1_MessageBoard.IsAudit = 1;
				}
				ShopNum1_MessageBoard_Action shopNum1_MessageBoard_Action = (ShopNum1_MessageBoard_Action)LogicFactory.CreateShopNum1_MessageBoard_Action();
				int num = shopNum1_MessageBoard_Action.AddMemberMessageBoard(shopNum1_MessageBoard);
				if (num > 0)
				{
					MessageBox.Show("留言成功！");
					this.textBox_2.Text = (this.textBox_1.Text = "");
					if (this.MessageConditionVerifyCode == "0" && this.textBox_3 != null)
					{
						this.textBox_3.Text = "";
					}
					if (ShopSettings.GetValue("MessageCommentISAudit") == "0" && this.Page.Request.Cookies["MemberLoginCookie"] != null)
					{
						string text = this.textBox_0.Text;
						string value = ShopSettings.GetValue("MyMessageRankSorce");
						string value2 = ShopSettings.GetValue("MyMessageSorce");
						if (int.Parse(value) > 0 || int.Parse(value2) > 0)
						{
							ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
							DataTable memInfoByMemberloginId = shopNum1_Member_Action.GetMemInfoByMemberloginId(text);
							if (memInfoByMemberloginId != null && memInfoByMemberloginId.Rows.Count > 0)
							{
								int num2 = int.Parse(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString());
								int num3 = int.Parse(memInfoByMemberloginId.Rows[0]["Score"].ToString());
								int num4 = shopNum1_Member_Action.UpdateScore(new ShopNum1_Member
								{
									MemberRank = new int?(num2 + int.Parse(value)),
									Score = num3 + int.Parse(value2),
									MemLoginID = text
								});
								if (num4 >= 0)
								{
									if (int.Parse(value2) > 0)
									{
										ShopNum1_ScoreModifyLog shopNum1_ScoreModifyLog = new ShopNum1_ScoreModifyLog();
										shopNum1_ScoreModifyLog.Guid = Guid.NewGuid();
										shopNum1_ScoreModifyLog.OperateType = 1;
										shopNum1_ScoreModifyLog.CurrentScore = num3;
										shopNum1_ScoreModifyLog.OperateScore = int.Parse(value2);
										shopNum1_ScoreModifyLog.LastOperateScore = num3 + int.Parse(value2);
										shopNum1_ScoreModifyLog.Date = DateTime.Now;
										shopNum1_ScoreModifyLog.Memo = "平台留言赠送消费积分";
										shopNum1_ScoreModifyLog.MemLoginID = text;
										shopNum1_ScoreModifyLog.CreateUser = text;
										shopNum1_ScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
										shopNum1_ScoreModifyLog.IsDeleted = 0;
										ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
										shopNum1_ScoreModifyLog_Action.OperateScore(shopNum1_ScoreModifyLog);
									}
									if (int.Parse(value) > 0)
									{
										ShopNum1_RankScoreModifyLog shopNum1_RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
										shopNum1_RankScoreModifyLog.Guid = Guid.NewGuid();
										shopNum1_RankScoreModifyLog.OperateType = 1;
										shopNum1_RankScoreModifyLog.CurrentScore = num2;
										shopNum1_RankScoreModifyLog.OperateScore = int.Parse(value);
										shopNum1_RankScoreModifyLog.LastOperateScore = num2 + int.Parse(value);
										shopNum1_RankScoreModifyLog.Date = DateTime.Now;
										shopNum1_RankScoreModifyLog.Memo = "平台留言赠送等级积分";
										shopNum1_RankScoreModifyLog.MemLoginID = text;
										shopNum1_RankScoreModifyLog.CreateUser = text;
										shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
										shopNum1_RankScoreModifyLog.IsDeleted = 0;
										ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
										shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
									}
								}
							}
						}
					}
				}
				else
				{
					MessageBox.Show("留言失败！");
				}
			}
		}
	}
}
