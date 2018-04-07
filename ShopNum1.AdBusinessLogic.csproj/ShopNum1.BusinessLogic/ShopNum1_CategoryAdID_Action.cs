using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_CategoryAdID_Action : IShopNum1_CategoryAdID_Action
	{
		public int Add(ShopNum1_CategoryAdID shopNum1_CategoryAdID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"insert ShopNum1_CategoryAdID( CategoryType,CategoryAdName,CategoryAdIntroduce,Width,Height,CategoryAdPic,CategoryAdflow,visitPeople,CategoryAdDefalutPic,CategoryAdDefalutLike,IsShow ) VALUES (  '",
				shopNum1_CategoryAdID.CategoryType,
				"',  '",
				Operator.FilterString(shopNum1_CategoryAdID.CategoryAdName),
				"',  '",
				Operator.FilterString(shopNum1_CategoryAdID.CategoryAdIntroduce),
				"',   ",
				Operator.FilterString(shopNum1_CategoryAdID.Width.ToString()),
				",   ",
				Operator.FilterString(shopNum1_CategoryAdID.Height.ToString()),
				",  '",
				Operator.FilterString(shopNum1_CategoryAdID.CategoryAdPic),
				"',   ",
				Operator.FilterString(shopNum1_CategoryAdID.CategoryAdflow.ToString()),
				",   ",
				Operator.FilterString(shopNum1_CategoryAdID.visitPeople.ToString()),
				",  '",
				Operator.FilterString(shopNum1_CategoryAdID.CategoryAdDefalutPic),
				"',  '",
				Operator.FilterString(shopNum1_CategoryAdID.CategoryAdDefalutLike),
				"',   ",
				Operator.FilterString(shopNum1_CategoryAdID.IsShow.ToString()),
				"  )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Updata(ShopNum1_CategoryAdID shopNum1_CategoryAdID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE  ShopNum1_CategoryAdID SET  CategoryType ='",
				Operator.FilterString(shopNum1_CategoryAdID.CategoryType),
				"', CategoryAdName ='",
				Operator.FilterString(shopNum1_CategoryAdID.CategoryAdName),
				"', CategoryAdIntroduce ='",
				Operator.FilterString(shopNum1_CategoryAdID.CategoryAdIntroduce),
				"', Width =",
				shopNum1_CategoryAdID.Width.ToString(),
				", Height =",
				shopNum1_CategoryAdID.Height.ToString(),
				", CategoryAdPic ='",
				shopNum1_CategoryAdID.CategoryAdPic,
				"', CategoryAdflow =",
				shopNum1_CategoryAdID.CategoryAdflow.ToString(),
				", visitPeople =",
				shopNum1_CategoryAdID.visitPeople.ToString(),
				", CategoryAdDefalutPic ='",
				shopNum1_CategoryAdID.CategoryAdDefalutPic,
				"', CategoryAdDefalutLike ='",
				shopNum1_CategoryAdID.CategoryAdDefalutLike,
				"', IsShow =",
				shopNum1_CategoryAdID.IsShow.ToString(),
				" WHERE id=",
				shopNum1_CategoryAdID.ID.ToString()
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string string_0)
		{
			string strSql = string.Empty;
			strSql = "SELECT COUNT(*) FROM ShopNum1_CategoryAdPayMent WHERE CategoryAdID IN (" + string_0 + ")";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int result;
			if (dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0][0].ToString() != "0")
			{
				result = -2;
			}
			else
			{
				strSql = "DELETE FROM ShopNum1_CategoryAdID WHERE id IN (" + string_0 + ")";
				result = DatabaseExcetue.RunNonQuery(strSql);
			}
			return result;
		}
		public DataTable Search(string categoryType, string adID)
		{
			string text = string.Empty;
			text = "SELECT * FROM ShopNum1_CategoryAdID WHERE 0=0";
			if (Operator.FilterString(categoryType) != "-1")
			{
				text = text + " AND CategoryType='" + categoryType + "' ";
			}
			if (Operator.FilterString(adID) != "-1")
			{
				text = text + " AND ID=" + adID + " ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
