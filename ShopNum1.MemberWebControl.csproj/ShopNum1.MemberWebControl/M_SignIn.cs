using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_SignIn : BaseMemberWebControl
	{
		private string string_0 = "M_SignIn.ascx";
		private Button button_0;
		private string string_1;
		public M_SignIn()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.button_0 = (Button)skin.FindControl("ButtonSingin");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
			DataTable dataTable = shopNum1_Member_Action.CheckSignin(this.MemLoginID, dayTime);
			if (dataTable != null && dataTable.Rows.Count != 0 && Convert.ToInt32(dataTable.Rows[0]["count"]) > 0)
			{
				this.button_0.Text = "已签到";
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
			DataTable dataTable = shopNum1_Member_Action.CheckSignin(this.MemLoginID, dayTime);
			if (dataTable != null && dataTable.Rows.Count != 0 && Convert.ToInt32(dataTable.Rows[0]["count"]) > 0)
			{
				this.Page.Response.Write("<script>alert(\"您今天已签到过了，明天再来吧！\");window.location.href=window.location.href</script>");
			}
			else
			{
				int num = shopNum1_Member_Action.AddSignin(new ShopNum1_SignIn
				{
					guid = Guid.NewGuid(),
					CreateTime = DateTime.Now,
					MemLoginID = this.MemLoginID
				});
				if (num > 0)
				{
					string value = ShopSettings.GetValue("SignOrSendScore");
					string value2 = ShopSettings.GetValue("SignRankScore");
					string value3 = ShopSettings.GetValue("SignScore");
					if (!string.IsNullOrEmpty(value) && int.Parse(value) == 1)
					{
						shopNum1_Member_Action.UpdateMemberScore(this.MemLoginID, Convert.ToInt32(value2), Convert.ToInt32(value3));
						this.method_0(Convert.ToInt32(value3), Convert.ToInt32(value2));
					}
					this.button_0.Text = "已签到";
					this.Page.Response.Write("<script>alert(\"签到成功！\");window.location.href=window.location.href</script>");
				}
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
				shopNum1_ScoreModifyLog.CurrentScore = num - int_0;
				shopNum1_ScoreModifyLog.OperateScore = int_0;
				shopNum1_ScoreModifyLog.LastOperateScore = num;
				shopNum1_ScoreModifyLog.Date = DateTime.Now;
				shopNum1_ScoreModifyLog.Memo = "签到送消费积分";
				shopNum1_ScoreModifyLog.MemLoginID = this.MemLoginID;
				shopNum1_ScoreModifyLog.CreateUser = this.MemLoginID;
				shopNum1_ScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_ScoreModifyLog.IsDeleted = 0;
				ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
				shopNum1_ScoreModifyLog_Action.OperateScore(shopNum1_ScoreModifyLog);
			}
			if (int_1 > 0)
			{
				ShopNum1_RankScoreModifyLog shopNum1_RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
				shopNum1_RankScoreModifyLog.Guid = Guid.NewGuid();
				shopNum1_RankScoreModifyLog.OperateType = 1;
				shopNum1_RankScoreModifyLog.CurrentScore = num2 - int_1;
				shopNum1_RankScoreModifyLog.OperateScore = int_1;
				shopNum1_RankScoreModifyLog.LastOperateScore = num2;
				shopNum1_RankScoreModifyLog.Date = DateTime.Now;
				shopNum1_RankScoreModifyLog.Memo = "签到送等级积分";
				shopNum1_RankScoreModifyLog.MemLoginID = this.MemLoginID;
				shopNum1_RankScoreModifyLog.CreateUser = this.MemLoginID;
				shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_RankScoreModifyLog.IsDeleted = 0;
				ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
				shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
			}
		}
	}
}
