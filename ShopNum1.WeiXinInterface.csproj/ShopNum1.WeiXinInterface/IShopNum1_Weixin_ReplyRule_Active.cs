using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.WeiXinInterface
{
	public interface IShopNum1_Weixin_ReplyRule_Active
	{
		bool KeyExists(string shopmemloginid, string keys, string ruleid);
		bool InsertRule(ShopNum1_Weixin_ReplyRule rulemdl, List<ShopNum1_Weixin_ReplyRuleKey> keylist, ShopNum1_Weixin_ReplyRuleContent content);
		bool InsertRule(ShopNum1_Weixin_ReplyRule rulemdl, List<ShopNum1_Weixin_ReplyRuleKey> keylist, ShopNum1_Weixin_ReplyRuleContent content, string contentchirlds);
		bool InsertRule(ShopNum1_Weixin_ReplyRule rulemdl, List<ShopNum1_Weixin_ReplyRuleKey> keylist, ShopNum1_Weixin_ReplyRuleContent content, ShopNum1_Weixin_ReplyRuleContentArticle article, string contentchirlds);
		DataSet SelectReplyRule(string shopmemloginid, int msgtype);
		DataTable SelectReplyRule(string shopmemloginid, int msgtype, string ruleid);
		DataSet SelectReplyRule(string ruleid);
		bool Delete_ReplyRule(string rules);
		DataTable SelectArticle(string contentid);
		DataTable SelectContent(string contentid);
		DataTable Select_AllKeys(string shopmemloginid);
	}
}
