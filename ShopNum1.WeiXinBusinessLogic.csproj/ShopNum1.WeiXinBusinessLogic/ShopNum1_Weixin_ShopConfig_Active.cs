using ShopNum1.DataAccess;
using ShopNum1.WeiXinInterface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.WeiXinBusinessLogic
{
	public class ShopNum1_Weixin_ShopConfig_Active : IShopNum1_Weixin_ShopConfig_Active
	{
		public bool Add(List<ShopNum1_Weixin_ShopConfig> configlist, string shopid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(" SET XACT_ABORT ON", new object[0]).AppendLine();
			stringBuilder.AppendFormat(" BEGIN TRANSACTION", new object[0]).AppendLine();
			stringBuilder.AppendFormat("DELETE [dbo].[ShopNum1_Weixin_ShopConfig] WHERE ShopID = '{0}'", shopid).AppendLine();
			foreach (ShopNum1_Weixin_ShopConfig current in configlist)
			{
				stringBuilder.AppendFormat("INSERT INTO [dbo].[ShopNum1_Weixin_ShopConfig]\r\n                                      ([ShopID],[Value],[Url],[ConfigType]) \r\n                                      VALUES('{0}','{1}','{2}','{3}')", new object[]
				{
					current.ShopID,
					current.Value,
					current.Url,
					current.ConfigType
				}).AppendLine();
			}
			stringBuilder.AppendFormat(" COMMIT TRANSACTION", new object[0]).AppendLine();
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString()) > 0;
		}
		public DataTable Get_Config(string shopid)
		{
			string strSql = string.Format("SELECT [ID],[ShopID],[Value],[Url],[ConfigType] FROM [dbo].[ShopNum1_Weixin_ShopConfig]\r\n                                            WHERE ShopID = '{0}'", shopid);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
