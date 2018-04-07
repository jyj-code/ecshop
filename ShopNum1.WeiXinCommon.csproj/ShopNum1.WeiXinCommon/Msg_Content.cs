using System;
using System.Collections.Generic;
using System.Xml;
namespace ShopNum1.WeiXinCommon
{
	public class Msg_Content
	{
		public static string RepMsg_Content(string postStr)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(postStr);
			XmlElement documentElement = xmlDocument.DocumentElement;
			RequestModel requestModel = new RequestModel();
			requestModel.ToUserName = documentElement.SelectSingleNode("ToUserName").InnerText;
			requestModel.FromUserName = documentElement.SelectSingleNode("FromUserName").InnerText;
			requestModel.CreateTime = documentElement.SelectSingleNode("CreateTime").InnerText;
			requestModel.MsgType = documentElement.SelectSingleNode("MsgType").InnerText;
			string msgType = requestModel.MsgType;
			if (msgType != null)
			{
				if (!(msgType == "text"))
				{
					if (!(msgType == "location"))
					{
						if (!(msgType == "image"))
						{
							if (!(msgType == "link"))
							{
								if (msgType == "event")
								{
									requestModel.Wxevent = documentElement.SelectSingleNode("Event").InnerText;
									requestModel.EventKey = documentElement.SelectSingleNode("EventKey").InnerText;
								}
							}
							else
							{
								requestModel.Title = documentElement.SelectSingleNode("Title").InnerText;
								requestModel.Description = documentElement.SelectSingleNode("Description").InnerText;
								requestModel.Url = documentElement.SelectSingleNode("Url").InnerText;
								requestModel.MsgId = documentElement.SelectSingleNode("MsgId").InnerText;
							}
						}
						else
						{
							requestModel.PicUrl = documentElement.SelectSingleNode("PicUrl").InnerText;
							requestModel.MsgId = documentElement.SelectSingleNode("MsgId").InnerText;
						}
					}
					else
					{
						requestModel.Location_X = documentElement.SelectSingleNode("Location_X").InnerText;
						requestModel.Location_Y = documentElement.SelectSingleNode("Location_Y").InnerText;
						requestModel.Scale = documentElement.SelectSingleNode("Scale").InnerText;
						requestModel.Label = documentElement.SelectSingleNode("Label").InnerText;
						requestModel.MsgId = documentElement.SelectSingleNode("MsgId").InnerText;
					}
				}
				else
				{
					requestModel.Content = documentElement.SelectSingleNode("Content").InnerText;
					requestModel.MsgId = documentElement.SelectSingleNode("MsgId").InnerText;
				}
			}
			return Msg_Content.smethod_0(requestModel);
		}
		private static string smethod_0(RequestModel requestModel_0)
		{
			List<ReplyInfoModel> list = new List<ReplyInfoModel>();
			ReplyInfoModel replyInfoModel = new ReplyInfoModel();
			replyInfoModel.Title = "微信测试";
			replyInfoModel.Description = "描述，图片展示";
			replyInfoModel.ImgSrc = "http://d.hiphotos.baidu.com/pic/w%3D230/sign=761745944610b912bfc1f1fdf3fdfcb5/5bafa40f4bfbfbed1062345079f0f736afc31fe1.jpg";
			replyInfoModel.Url = "http://www.baidu.com";
			for (int i = 0; i < 5; i++)
			{
				list.Add(replyInfoModel);
			}
			string result = string.Empty;
			MsgXml msgXml = new MsgXml(requestModel_0);
			try
			{
				string text = requestModel_0.MsgType;
				if (text != null)
				{
					if (!(text == "text"))
					{
						if (!(text == "location"))
						{
							if (!(text == "image"))
							{
								if (!(text == "link"))
								{
									if (text == "event")
									{
										text = requestModel_0.Wxevent;
										if (text != null)
										{
											if (!(text == "subscribe"))
											{
												if (!(text == "unsubscribe") && !(text == "CLICK"))
												{
												}
											}
											else
											{
												result = msgXml.ReplyTxt("感谢关注...");
											}
										}
									}
								}
								else
								{
									result = msgXml.ReplyTxt("你发过来的是链接消息");
								}
							}
							else
							{
								result = msgXml.ReplyTxt("你发过来的是图片消息");
							}
						}
						else
						{
							result = msgXml.ReplyTxt("你发过来的是地理消息");
						}
					}
					else if (requestModel_0.Content.Trim() == "单图")
					{
						result = msgXml.ReplyImg(replyInfoModel);
					}
					else if (requestModel_0.Content.Trim() == "多图")
					{
						result = msgXml.ReplyImg(list);
					}
					else
					{
						result = msgXml.ReplyTxt("你发过来的是文字消息");
					}
				}
			}
			catch (Exception)
			{
			}
			return result;
		}
	}
}
