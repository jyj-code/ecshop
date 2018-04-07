using System;
using System.Data;
namespace ShopNum1.WeiXinInterface
{
	public interface IShopNum1_Weixin_ReplyRuleContent_Active
	{
		DataSet GetContentByMenuId(string string_0, string menu_type);
		DataTable GetContentByKey(string shopmemloginid, string keyword);
		DataTable Select_ContentByRuleId(int ruleid, int msgtype);
		string Get_Article(string string_0);
	}
}
