using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_AdvertisementImage_Action : IShopNum1_AdvertisementImage_Action
	{
		public bool Add(List<ShopNum1_AdvertisementImage> configlist, string shopid, string ConfigType)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(" SET XACT_ABORT ON", new object[0]).AppendLine();
			stringBuilder.AppendFormat(" BEGIN TRANSACTION", new object[0]).AppendLine();
			stringBuilder.AppendFormat("DELETE [dbo].[ShopNum1_AdvertisementImage] WHERE ShopID = '{0}' And ConfigType='{1}'", shopid, ConfigType).AppendLine();
			foreach (ShopNum1_AdvertisementImage current in configlist)
			{
				stringBuilder.AppendFormat("INSERT INTO [dbo].[ShopNum1_AdvertisementImage]\r\n                                      ([MemLoginId],[ShopID],[Value],[Url],[ConfigType]) \r\n                                      VALUES('{4}','{0}','{1}','{2}','{3}')", new object[]
				{
					current.ShopID,
					current.Value,
					current.Url,
					current.ConfigType,
					current.MemLoginID
				}).AppendLine();
			}
			stringBuilder.AppendFormat(" COMMIT TRANSACTION", new object[0]).AppendLine();
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString()) > 0;
		}
		public DataTable Search(string strMemloginId, string strConfigType)
		{
			string strSql = string.Format("Select * from ShopNum1_AdvertisementImage where memloginid='{0}' And ConfigType='{1}'", strMemloginId, strConfigType);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
