using ShopNum1.Common;
using ShopNum1.Standard.WebReference;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
namespace ShopNum1.Standard
{
	public class SMS
	{
		public int mmsType;
		[CompilerGenerated]
		private string string_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string Ecode
		{
			get;
			set;
		}
		public string Username
		{
			get;
			set;
		}
		public string Password
		{
			get;
			set;
		}
		public void GetInfo()
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
			DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
			this.mmsType = Convert.ToInt32(dataRow["MMSType"].ToString());
			if (this.mmsType == 0)
			{
				this.Ecode = dataRow["Ecode"].ToString();
				this.Username = dataRow["UserName"].ToString();
				this.Password = dataRow["PassWord"].ToString();
			}
			else if (this.mmsType == 1)
			{
				this.Ecode = dataRow["Ecode"].ToString();
				this.Username = dataRow["UserName"].ToString();
				this.Password = dataRow["PassWord"].ToString();
			}
			else if (this.mmsType == 2)
			{
				this.Username = dataRow["SMSUser"].ToString();
				this.Password = dataRow["SMSPass"].ToString();
			}
			else if (this.mmsType == 3)
			{
				this.Username = dataRow["SmsbaoUser"].ToString();
				this.Password = dataRow["SmsbaoPass"].ToString();
			}
			else if (this.mmsType == 4)
			{
				this.Username = dataRow["SMSSpeedu"].ToString();
				this.Password = dataRow["SMSSpeedp"].ToString();
			}
		}
		public void GetShopInfo()
		{
			string str = HttpContext.Current.Request.QueryString["agenturl"].ToString();
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Shop/Shop/" + str + "/Site_Settings.xml"));
			DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
			this.mmsType = Convert.ToInt32(dataRow["MMSType"].ToString());
			if (this.mmsType == 0)
			{
				this.Ecode = dataRow["Ecode"].ToString();
				this.Username = dataRow["UserName"].ToString();
				this.Password = dataRow["PassWord"].ToString();
			}
			else if (this.mmsType == 1)
			{
				this.Ecode = dataRow["Ecode"].ToString();
				this.Username = dataRow["UserName"].ToString();
				this.Password = dataRow["PassWord"].ToString();
			}
			else if (this.mmsType == 2)
			{
				this.Username = dataRow["SMSUser"].ToString();
				this.Password = dataRow["SMSPass"].ToString();
			}
			else if (this.mmsType == 3)
			{
				this.Username = dataRow["SmsbaoUser"].ToString();
				this.Password = dataRow["SmsbaoPass"].ToString();
			}
			else if (this.mmsType == 4)
			{
				this.Username = dataRow["SMSSpeedu"].ToString();
				this.Password = dataRow["SMSSpeedp"].ToString();
			}
		}
		public bool Send(string mobile, string content, out string retmsg)
		{
			this.GetInfo();
			return this.method_0(mobile, content, out retmsg);
		}
		public bool ShopSend(string mobile, string content, string agentLoginID, out string retmsg)
		{
			this.GetShopInfo();
			return this.method_0(mobile, content, out retmsg);
		}
		private bool method_0(string string_3, string string_4, out string string_5)
		{
			bool result;
			if (this.mmsType == 0)
			{
				SMSSecond sMSSecond = new SMSSecond();
				result = sMSSecond.SendEmayMMS(this.Username, Encryption.Decrypt(this.Password), string_3, out string_5, string_4, "");
			}
			else if (this.mmsType == 1)
			{
				ISmsService smsService = new ISmsService();
				string code = smsService.smsSend(this.Ecode, null, this.Username, this.Password, string_3, string_4, "000001", null, null);
				result = this.GetRetMsg(code, out string_5);
			}
			else if (this.mmsType == 2)
			{
				SMSSecond sMSSecond = new SMSSecond();
				result = sMSSecond.Send(string_3, string_4, out string_5, this.Username, this.Password);
			}
			else if (this.mmsType == 3)
			{
				SMSSecond sMSSecond = new SMSSecond();
				result = sMSSecond.SendFast(string_3, string_4, out string_5, this.Username, this.Password);
			}
			else if (this.mmsType == 4)
			{
				SMSSecond sMSSecond = new SMSSecond();
				result = sMSSecond.SmsbaoSend(string_3, string_4, out string_5, this.Username, this.Password);
			}
			else
			{
				string_5 = "";
				result = false;
			}
			return result;
		}
		public bool EditPWD(string newpwd, out string retmsg)
		{
			ISmsService smsService = new ISmsService();
			string code = smsService.updatePassword(this.Ecode, this.Username, this.Password, newpwd);
			return this.GetRetMsg(code, out retmsg);
		}
		public bool GetRetMsg(string code, out string retmsg)
		{
			bool result = false;
			retmsg = "";
			switch (code)
			{
			case "1":
				retmsg = "发送成功！";
				result = true;
				break;
			case "-1":
				retmsg = "不能初始化SO";
				break;
			case "-2":
				retmsg = "网络不通";
				break;
			case "-3":
				retmsg = "一次发送的手机号码过多";
				break;
			case "-4":
				retmsg = "内容包含不合法文字";
				break;
			case "-5":
				retmsg = "登录账户错误";
				break;
			case "-6":
				retmsg = "通信数据传送";
				break;
			case "-7":
				retmsg = "没有进行参数初始化";
				break;
			case "-8":
				retmsg = "扩展号码长度不对";
				break;
			case "-9":
				retmsg = "手机号码不合法(黑名单)";
				break;
			case "-10":
				retmsg = "号码太长";
				break;
			case "-11":
				retmsg = "内容太长";
				break;
			case "-12":
				retmsg = "内部错误";
				break;
			case "-13":
				retmsg = "余额不足";
				break;
			case "-14":
				retmsg = "扩展号不正确";
				break;
			case "-17":
				retmsg = "发送内容为空";
				break;
			case "-19":
				retmsg = "没有找到该动作（不存在的url地址）";
				break;
			case "-20":
				retmsg = "手机号格式不正确";
				break;
			case "-50":
				retmsg = "配置参数错误";
				break;
			case "-21":
				retmsg = "非允许发送时间段";
				break;
			}
			return result;
		}
	}
}
