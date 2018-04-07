using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_CategoryAdvertisement_Action : IShopNum1_CategoryAdvertisement_Action
	{
		public int Add(ShopNum1_CategoryAdvertisement shopNum1_CategoryAdvertisement)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into ShopNum1_CategoryAdvertisement(");
			stringBuilder.Append("CreateTime,AdvertisementName,Width,Height,AdvertisementDPic,CategoryAdID,CategoryType,CategoryCode,CategoryName,Adlocation,AdDefaultLike,AdvertisementPrice,AdIntroduce,Advertisementflow,IsEnabled,IsShow,IsBuy");
			stringBuilder.Append(")");
			stringBuilder.Append(" values (");
			stringBuilder.Append("'" + shopNum1_CategoryAdvertisement.CreateTime.ToString() + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdvertisement.AdvertisementName + "',");
			stringBuilder.Append(shopNum1_CategoryAdvertisement.Width + ",");
			stringBuilder.Append(shopNum1_CategoryAdvertisement.Height + ",");
			stringBuilder.Append("'" + shopNum1_CategoryAdvertisement.AdvertisementDPic + "',");
			stringBuilder.Append(shopNum1_CategoryAdvertisement.CategoryAdID + ",");
			stringBuilder.Append("'" + shopNum1_CategoryAdvertisement.CategoryType + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdvertisement.CategoryCode + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdvertisement.CategoryName + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdvertisement.Adlocation + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdvertisement.AdDefaultLike + "',");
			stringBuilder.Append(shopNum1_CategoryAdvertisement.AdvertisementPrice + ",");
			stringBuilder.Append("'" + shopNum1_CategoryAdvertisement.AdIntroduce + "',");
			stringBuilder.Append(shopNum1_CategoryAdvertisement.Advertisementflow + ",");
			stringBuilder.Append(shopNum1_CategoryAdvertisement.IsEnabled + ",");
			stringBuilder.Append(shopNum1_CategoryAdvertisement.IsShow + ",");
			stringBuilder.Append(string.Concat(shopNum1_CategoryAdvertisement.IsBuy));
			stringBuilder.Append(")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Updata(ShopNum1_CategoryAdvertisement shopNum1_CategoryAdvertisement)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ShopNum1_CategoryAdvertisement set ");
			stringBuilder.Append("AdvertisementName='" + shopNum1_CategoryAdvertisement.AdvertisementName + "',");
			stringBuilder.Append("Width=" + shopNum1_CategoryAdvertisement.Width + ",");
			stringBuilder.Append("Height=" + shopNum1_CategoryAdvertisement.Height + ",");
			stringBuilder.Append("AdvertisementDPic='" + shopNum1_CategoryAdvertisement.AdvertisementDPic + "',");
			stringBuilder.Append("AdvertisementNPic='" + shopNum1_CategoryAdvertisement.AdvertisementNPic + "',");
			stringBuilder.Append("CategoryAdID=" + shopNum1_CategoryAdvertisement.CategoryAdID + ",");
			stringBuilder.Append("CategoryType='" + shopNum1_CategoryAdvertisement.CategoryType + "',");
			stringBuilder.Append("CategoryCode='" + shopNum1_CategoryAdvertisement.CategoryCode + "',");
			stringBuilder.Append("CategoryName='" + shopNum1_CategoryAdvertisement.CategoryName + "',");
			stringBuilder.Append("Adlocation='" + shopNum1_CategoryAdvertisement.Adlocation + "',");
			stringBuilder.Append("AdDefaultLike='" + shopNum1_CategoryAdvertisement.AdDefaultLike + "',");
			stringBuilder.Append("AdvertisementLike='" + shopNum1_CategoryAdvertisement.AdvertisementLike + "',");
			stringBuilder.Append("AdvertisementPrice=" + shopNum1_CategoryAdvertisement.AdvertisementPrice + ",");
			stringBuilder.Append("AdIntroduce='" + shopNum1_CategoryAdvertisement.AdIntroduce + "',");
			stringBuilder.Append("Advertisementflow=" + shopNum1_CategoryAdvertisement.Advertisementflow + ",");
			stringBuilder.Append("IsEnabled=" + shopNum1_CategoryAdvertisement.IsEnabled + ",");
			stringBuilder.Append("IsShow=" + shopNum1_CategoryAdvertisement.IsShow + ",");
			stringBuilder.Append("IsBuy=" + shopNum1_CategoryAdvertisement.IsBuy);
			stringBuilder.Append(" where ID=" + shopNum1_CategoryAdvertisement.ID);
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Delete(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from ShopNum1_CategoryAdvertisement ");
			stringBuilder.Append(" where ID IN(" + string_0 + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable Search(string AdName, string CategoryType, string CategoryID, string AdCode, string AdIShow, string AdIsBuy)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select   ");
			stringBuilder.Append(" ID,AdvertisementName,Width,Height,AdvertisementDPic,CategoryName,AdvertisementNPic,CategoryAdID,CategoryType,CategoryCode,Adlocation,AdDefaultLike,AdvertisementLike,AdvertisementPrice,AdIntroduce,Advertisementflow,IsEnabled,IsShow,IsBuy ");
			stringBuilder.Append(" from ShopNum1_CategoryAdvertisement ");
			stringBuilder.Append(" where 0=0");
			if (Operator.FilterString(AdName) != "-1")
			{
				stringBuilder.Append(" AND AdvertisementName='" + AdName + "' ");
			}
			if (Operator.FilterString(CategoryType) != "-1")
			{
				stringBuilder.Append(" AND CategoryType='" + CategoryType + "' ");
			}
			if (Operator.FilterString(CategoryID) != "-1")
			{
				stringBuilder.Append(" AND CategoryAdID=" + CategoryID + " ");
			}
			if (Operator.FilterString(AdCode) != "-1")
			{
				stringBuilder.Append(" AND CategoryCode like '" + AdCode + "%' ");
			}
			if (Operator.FilterString(AdIShow) != "-1")
			{
				stringBuilder.Append(" AND IsShow=" + AdIShow + " ");
			}
			if (Operator.FilterString(AdIsBuy) != "-1")
			{
				stringBuilder.Append(" AND IsBuy=" + AdIsBuy + " ");
			}
			stringBuilder.Append(" ORDER BY CreateTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string string_0)
		{
			string text = string.Empty;
			text = "SELECT * FROM ShopNum1_CategoryAdvertisement WHERE 0=0";
			if (Operator.FilterString(string_0) != "-1")
			{
				text = text + " AND ID=" + string_0 + " ";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetFatherIDByID(string string_0)
		{
			string strSql = string.Empty;
			strSql = "SELECT FatherID FROM ShopNum1_ArticleCategory WHERE ID=" + string_0;
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataTable GetPriceAndID(string categorytype, string categoryid, string categorycode)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@categorytype";
			array2[0] = categorytype;
			array[1] = "@categoryid";
			array2[1] = categoryid;
			array[2] = "@categorycode";
			array2[2] = categorycode;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetPriceAndID", array, array2);
		}
	}
}
