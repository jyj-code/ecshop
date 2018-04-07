using ShopNum1.Common;
using ShopNum1.Standard.VjWebservice;
using System;
using System.Collections.Generic;
namespace ShopNum1.Standard
{
	public class SMSSecond
	{
		public bool SendEmayMMS(string strSN, string strPwd, string strMobile, out string errmsg, string strContent, string strAddSerial)
		{
			SDKService sDKService = new SDKService();
			int num = -1;
			try
			{
				num = sDKService.sendSMS(strSN, strPwd, "", strMobile.ToString().Split(new char[]
				{
					','
				}), strContent, "", "GBK", 3, Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff")));
			}
			catch
			{
			}
			errmsg = "发送成功";
			bool result = false;
			string text = num.ToString();
			switch (text)
			{
			case "0":
				errmsg = "发送成功";
				result = true;
				return result;
			case "17":
				errmsg = "短信发送失败";
				return result;
			case "18":
				errmsg = "发送定时信息失败";
				return result;
			case "303":
				errmsg = "客户端网络故障";
				return result;
			case "305":
				errmsg = "服务器端返回错误，错误的返回值";
				return result;
			case "307":
				errmsg = "目标电话号码不符合规则，电话号码必须是以0、1开头";
				return result;
			case "997":
				errmsg = "平台返回找不到超时的短信，该信息是否成功无法确定";
				return result;
			case "998":
				errmsg = "由于客户端网络问题导致信息发送超时，该信息是否成功下发无法确定";
				return result;
			case "-1100":
				errmsg = "没有注册";
				return result;
			case "-9020":
				errmsg = "手机号码格式错误";
				return result;
			}
			errmsg = num + "系统错误";
			return result;
		}
		public bool SendFast(string mobile, string content, out string errmsg, string Username, string Password)
		{
			errmsg = "发送成功";
			bool result = false;
			string text = "http://big.smsbao.com/sms?";
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("u", Username);
			string string_ = Encryption.Decrypt(Password);
			dictionary.Add("p", SendMessage.smethod_0(string_));
			dictionary.Add("m", mobile);
			dictionary.Add("c", content);
			dictionary.Add("s", "");
			string text2 = SendMessage.send(text, text, dictionary);
			if (text2.Substring(0, 1) == "0")
			{
				errmsg = "发送成功";
				result = true;
			}
			else if (text2.Substring(0, 1) == "-")
			{
				errmsg = "手机号码不正确";
			}
			else
			{
				text2 = text2.Substring(0, 2);
				string text3 = text2;
				if (text3 != null)
				{
					if (!(text3 == "30"))
					{
						if (!(text3 == "40"))
						{
							if (!(text3 == "41"))
							{
								if (!(text3 == "42"))
								{
									if (!(text3 == "43"))
									{
										if (text3 == "50")
										{
											errmsg = "内容含有敏感词";
										}
									}
									else
									{
										errmsg = "IP地址限制";
									}
								}
								else
								{
									errmsg = "帐号过期";
								}
							}
							else
							{
								errmsg = "余额不足";
							}
						}
						else
						{
							errmsg = "账号不存在";
						}
					}
					else
					{
						errmsg = "密码错误";
					}
				}
			}
			return result;
		}
		public bool Send(string mobile, string content, out string errmsg, string Username, string Password)
		{
			bool result = false;
			errmsg = "发送成功";
			string text = "http://sms.shsms.cn/tx/?";
			string text2 = SendMessage.send(text, text, new Dictionary<string, string>
			{

				{
					"content",
					content
				},

				{
					"mobile",
					mobile
				},

				{
					"user",
					Username
				},

				{
					"pass",
					SendMessage.smethod_0(Encryption.Decrypt(Password))
				}
			});
			string text3 = text2;
			switch (text3)
			{
			case "100":
				errmsg = "发送成功";
				result = true;
				break;
			case "101":
				errmsg = "验证失败";
				break;
			case "102":
				errmsg = "短信不足";
				break;
			case "103":
				errmsg = "操作失败";
				break;
			case "104":
				errmsg = "非法字符";
				break;
			case "105":
				errmsg = "内容过多";
				break;
			case "106":
				errmsg = "号码过多";
				break;
			case "107":
				errmsg = "频率过快";
				break;
			case "108":
				errmsg = "号码内容空";
				break;
			case "109":
				errmsg = "账号冻结";
				break;
			case "110":
				errmsg = "禁止频繁单条发送";
				break;
			case "111":
				errmsg = "系统暂定发送";
				break;
			case "112":
				errmsg = "号码不正确";
				break;
			case "120":
				errmsg = "系统升级";
				break;
			}
			return result;
		}
		public bool SmsbaoSend(string mobile, string content, out string errmsg, string Username, string Password)
		{
			errmsg = "发送成功";
			bool result = false;
			string text = "http://www.smsbao.com/sms?";
			string text2 = SendMessage.send(text, text, new Dictionary<string, string>
			{

				{
					"u",
					Username
				},

				{
					"p",
					SendMessage.smethod_0(Encryption.Decrypt(Password))
				},

				{
					"m",
					mobile
				},

				{
					"c",
					content
				},

				{
					"s",
					""
				}
			});
			if (text2.Substring(0, 1) == "0")
			{
				errmsg = "发送成功";
				result = true;
			}
			else
			{
				text2 = text2.Substring(0, 2);
				string text3 = text2;
				switch (text3)
				{
				case "30":
					errmsg = "密码错误";
					break;
				case "40":
					errmsg = "账号不存在";
					break;
				case "41":
					errmsg = "余额不足";
					break;
				case "42":
					errmsg = "帐号过期";
					break;
				case "43":
					errmsg = "IP地址限制";
					break;
				case "50":
					errmsg = "内容含有敏感词";
					break;
				case "51":
					errmsg = "手机号码不正确";
					break;
				}
			}
			return result;
		}
	}
}
