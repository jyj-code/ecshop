using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_OrderExpress_Action : IShopNum1_OrderExpress_Action
	{
		public int Delete(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Delete ShopNum1_OrderExpressInfo where guid in(" + guid + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Edit(string name, int IsDefault, string hidden, string imgPath, string guid)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"Update ShopNum1_OrderExpressInfo set name='",
				name,
				"',IsDefault=",
				IsDefault,
				",hidden= '",
				hidden,
				"',imgPath= '",
				imgPath,
				"' where guid =",
				guid
			});
			return DatabaseExcetue.RunNonQuery(text.ToString());
		}
		public DataTable Search()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from ShopNum1_OrderExpressInfo where isDefault = 1 or isDefault=0");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchByIsDefault()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from ShopNum1_OrderExpressInfo where isDefault = 1");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from ShopNum1_OrderExpressInfo where guid ='" + guid.Replace("'", "") + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Add(string guid, string name, int isDefault, string hidden, string imgPath, string code)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new object[]
			{
				"insert into ShopNum1_OrderExpressInfo values('",
				guid,
				"','",
				name,
				"',",
				isDefault,
				",'",
				hidden,
				"','",
				imgPath,
				"','",
				code,
				"')"
			}));
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable SearchByLogisticsID(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from ShopNum1_OrderExpressInfo where LogisticsID ='" + string_0 + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
	}
}
