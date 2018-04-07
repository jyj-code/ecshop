using System;
using System.Collections.Generic;
using System.Text;
namespace ShopNum1.WeiXinCommon
{
	public class MsgXml
	{
		private StringBuilder stringBuilder_0 = new StringBuilder();
		public MsgXml(RequestModel requestXML)
		{
			this.stringBuilder_0.AppendFormat("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>\r\n                                  {2}</CreateTime>", requestXML.FromUserName, requestXML.ToUserName, DateHepler.ConvertDateTimeInt(DateTime.Now));
		}
		public string ReplyTxt(string Msg)
		{
			this.stringBuilder_0.AppendFormat("<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{0}]]></Content></xml>", Msg);
			return this.stringBuilder_0.ToString();
		}
		public string ReplyTxt(ReplyInfoModel replyinfomodel)
		{
			this.stringBuilder_0.AppendFormat("<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{0}]]></Content></xml>", replyinfomodel.RepMsgContent);
			return this.stringBuilder_0.ToString();
		}
		public string ReplyImg(ReplyInfoModel replyinfomodel)
		{
			this.stringBuilder_0.AppendFormat("<MsgType><![CDATA[news]]></MsgType><ArticleCount>1</ArticleCount><Articles>", new object[0]);
			this.stringBuilder_0.AppendFormat("<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]>\r\n                                  </Description><PicUrl><![CDATA[{2}]]>\r\n                                  </PicUrl><Url><![CDATA[{3}]]></Url></item>", new object[]
			{
				replyinfomodel.Title,
				replyinfomodel.Description,
				replyinfomodel.ImgSrc,
				replyinfomodel.Url
			});
			this.stringBuilder_0.AppendFormat("</Articles></xml>", new object[0]);
			return this.stringBuilder_0.ToString();
		}
		public string ReplyImg(List<ReplyInfoModel> replyinfomodels)
		{
			int num = 1;
			this.stringBuilder_0.AppendFormat("<MsgType><![CDATA[news]]></MsgType><ArticleCount>{0}</ArticleCount><Articles>", replyinfomodels.Count);
			foreach (ReplyInfoModel current in replyinfomodels)
			{
				this.stringBuilder_0.AppendFormat("<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]>\r\n                                   </Description><PicUrl><![CDATA[{2}]]>\r\n                                   </PicUrl><Url><![CDATA[{3}]]></Url></item>", new object[]
				{
					current.Title,
					current.Description,
					current.ImgSrc,
					current.Url
				});
				num++;
				if (num >= 10)
				{
					break;
				}
			}
			this.stringBuilder_0.AppendFormat("</Articles></xml>", new object[0]);
			return this.stringBuilder_0.ToString();
		}
		public string ReplyMusic(ReplyInfoModel replyinfomodel)
		{
			this.stringBuilder_0.AppendFormat("<MsgType><![CDATA[music]]></MsgType><Music><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description>\r\n                                  <MusicUrl><![CDATA[{2}]]></MusicUrl><HQMusicUrl><![CDATA[{3}]]></HQMusicUrl></Music></xml>", new object[]
			{
				replyinfomodel.Title,
				replyinfomodel.Description,
				replyinfomodel.Music_Url,
				replyinfomodel.HQ_Music_Url
			});
			return this.stringBuilder_0.ToString();
		}
	}
}
