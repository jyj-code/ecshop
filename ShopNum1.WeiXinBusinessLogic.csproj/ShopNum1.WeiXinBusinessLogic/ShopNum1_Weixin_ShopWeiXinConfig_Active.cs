using ShopNum1.DataAccess;
using ShopNum1.WeiXinInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.WeiXinBusinessLogic
{
	public class ShopNum1_Weixin_ShopWeiXinConfig_Active : IShopNum1_Weixin_ShopWeiXinConfig_Active
	{
		public bool Add_DefaultSetting(ShopNum1_Weixin_ShopWeiXinConfig model)
		{
			string text = string.Format("if(select count(1) from ShopNum1_Weixin_ShopWeiXinConfig where ShopMemLoginId = '{0}')=0\r\n                                            begin\r\n\t                                            insert into ShopNum1_Weixin_ShopWeiXinConfig([ShopMemLoginId],[ShopWeiXinId],[TokenURL],[Token],[AppId],[AppSecret],[AttenRepKeys],[NotFindKeys],[IsOpenAtten],[IsOpenNotFindKey])\r\n\t                                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')\r\n                                            end\r\n                                            else\r\n                                            begin\r\n\t                                            update ShopNum1_Weixin_ShopWeiXinConfig set AttenRepKeys='{6}',NotFindKeys='{7}',IsOpenAtten='{8}',IsOpenNotFindKey='{9}'\r\n                                                where ShopMemLoginId = '{0}'\r\n                                            end", new object[]
			{
				model.ShopMemLoginId,
				model.ShopWeiXinId,
				model.TokenURL,
				model.Token,
				model.AppId,
				model.AppSecret,
				model.AttenRepKeys,
				model.NotFindKeys,
				model.IsOpenAtten,
				model.IsOpenNotFindKey
			});
			return DatabaseExcetue.RunNonQuery(text.ToString()) > 0;
		}
		public bool Add_TokenApp(ShopNum1_Weixin_ShopWeiXinConfig model)
		{
			string text = string.Format("if(select count(1) from ShopNum1_Weixin_ShopWeiXinConfig where ShopMemLoginId = '{0}')=0\r\n                                            begin\r\n\t                                            insert into ShopNum1_Weixin_ShopWeiXinConfig([ShopMemLoginId],[ShopWeiXinId],[TokenURL],[Token],[AppId],[AppSecret],[AttenRepKeys],[NotFindKeys],[IsOpenAtten],[IsOpenNotFindKey])\r\n\t                                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')\r\n                                            end\r\n                                            else\r\n                                            begin\r\n\t                                            update ShopNum1_Weixin_ShopWeiXinConfig set TokenURL='{2}',Token='{3}',[AppId]='{4}',[AppSecret]='{5}'\r\n                                                where ShopMemLoginId = '{0}'\r\n                                            end", new object[]
			{
				model.ShopMemLoginId,
				model.ShopWeiXinId,
				model.TokenURL,
				model.Token,
				model.AppId,
				model.AppSecret,
				model.AttenRepKeys,
				model.NotFindKeys,
				model.IsOpenAtten,
				model.IsOpenNotFindKey
			});
			return DatabaseExcetue.RunNonQuery(text.ToString()) > 0;
		}
		public DataTable GetWeixinConfigByUrl(string TokenURL)
		{
			string strSql = string.Format("select [ID],[ShopMemLoginId],[ShopWeiXinId],[TokenURL],[Token],[AppId],[AppSecret],[AttenRepKeys],[NotFindKeys],[IsOpenAtten],[IsOpenNotFindKey] from ShopNum1_Weixin_ShopWeiXinConfig where TokenURL = '{0}'", TokenURL);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetWeixinConfig(string ShopMemLoginId)
		{
			string strSql = string.Format("select [ID],[ShopMemLoginId],[ShopWeiXinId],[TokenURL],[Token],[AppId],[AppSecret],[AttenRepKeys],[NotFindKeys],[IsOpenAtten],[IsOpenNotFindKey] from ShopNum1_Weixin_ShopWeiXinConfig where ShopMemLoginId = '{0}'", ShopMemLoginId);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
