using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_CategoryAdPayMent_Action : IShopNum1_CategoryAdPayMent_Action
	{
		public int Add(ShopNum1_CategoryAdPayMent shopNum1_CategoryAdPayMent)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into ShopNum1_CategoryAdPayMent(");
			stringBuilder.Append("AdvertisementID,CategoryAdID,CategoryType,CategoryCode,CategoryName,TradeID,MemLoginID,BuyTime,StartTime,EndTime,ShowPayMentPrice,PayMentTime,IsPayMent,AdvertisementPic,FailCause,AdvertisementLike,AdvertisementContent,PayMentType,PayMentName,IsAudit,IsEffective");
			stringBuilder.Append(")");
			stringBuilder.Append(" values (");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.AdvertisementID + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.CategoryAdID + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.CategoryType + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.CategoryCode + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.CategoryName + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.TradeID + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.MemLoginID + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.BuyTime + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.StartTime + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.EndTime + "',");
			stringBuilder.Append(shopNum1_CategoryAdPayMent.ShowPayMentPrice + ",");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.PayMentTime + "',");
			stringBuilder.Append(shopNum1_CategoryAdPayMent.IsPayMent + ",");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.AdvertisementPic + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.FailCause + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.AdvertisementLike + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.AdvertisementContent + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.PayMentType + "',");
			stringBuilder.Append("'" + shopNum1_CategoryAdPayMent.PayMentName + "',");
			stringBuilder.Append(shopNum1_CategoryAdPayMent.IsAudit + ", ");
			stringBuilder.Append(shopNum1_CategoryAdPayMent.IsEffective + " ");
			stringBuilder.Append(")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Updata(ShopNum1_CategoryAdPayMent shopNum1_CategoryAdPayMent)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ShopNum1_CategoryAdPayMent set ");
			stringBuilder.Append("AdvertisementID='" + shopNum1_CategoryAdPayMent.AdvertisementID + "',");
			stringBuilder.Append("CategoryAdID='" + shopNum1_CategoryAdPayMent.CategoryAdID + "',");
			stringBuilder.Append("CategoryType='" + shopNum1_CategoryAdPayMent.CategoryType + "',");
			stringBuilder.Append("CategoryCode='" + shopNum1_CategoryAdPayMent.CategoryCode + "',");
			stringBuilder.Append("CategoryName='" + shopNum1_CategoryAdPayMent.CategoryName + "',");
			stringBuilder.Append("TradeID='" + shopNum1_CategoryAdPayMent.TradeID + "',");
			stringBuilder.Append("MemLoginID='" + shopNum1_CategoryAdPayMent.MemLoginID + "',");
			stringBuilder.Append("BuyTime='" + shopNum1_CategoryAdPayMent.BuyTime + "',");
			stringBuilder.Append("StartTime='" + shopNum1_CategoryAdPayMent.StartTime + "',");
			stringBuilder.Append("EndTime='" + shopNum1_CategoryAdPayMent.EndTime + "',");
			stringBuilder.Append("ShowPayMentPrice=" + shopNum1_CategoryAdPayMent.ShowPayMentPrice + ",");
			stringBuilder.Append("PayMentTime='" + shopNum1_CategoryAdPayMent.PayMentTime + "',");
			stringBuilder.Append("IsPayMent=" + shopNum1_CategoryAdPayMent.IsPayMent + ",");
			stringBuilder.Append("AdvertisementPic='" + shopNum1_CategoryAdPayMent.AdvertisementPic + "',");
			stringBuilder.Append("FailCause='" + shopNum1_CategoryAdPayMent.FailCause + "',");
			stringBuilder.Append("AdvertisementLike='" + shopNum1_CategoryAdPayMent.AdvertisementLike + "',");
			stringBuilder.Append("AdvertisementContent='" + shopNum1_CategoryAdPayMent.AdvertisementContent + "',");
			stringBuilder.Append("PayMentType='" + shopNum1_CategoryAdPayMent.PayMentType + "',");
			stringBuilder.Append("PayMentName='" + shopNum1_CategoryAdPayMent.PayMentName + "',");
			stringBuilder.Append("IsAudit=" + shopNum1_CategoryAdPayMent.IsAudit + ",");
			stringBuilder.Append("IsEffective=" + shopNum1_CategoryAdPayMent.IsEffective + " ");
			stringBuilder.Append(" where ID=" + shopNum1_CategoryAdPayMent.ID);
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Updata(string ImageName, string AdvertisementLike, string AdvertisementTitle, string PayMentType, string PayMentName, string AdID, string MemloginID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ShopNum1_CategoryAdPayMent set ");
			stringBuilder.Append("AdvertisementPic='" + ImageName + "',");
			stringBuilder.Append("AdvertisementLike='" + AdvertisementLike + "',");
			stringBuilder.Append("AdvertisementContent='" + AdvertisementTitle + "',");
			stringBuilder.Append("PayMentType='" + PayMentType + "',");
			stringBuilder.Append("PayMentName='" + PayMentName + "',");
			stringBuilder.Append("IsAudit=0 ");
			stringBuilder.Append(string.Concat(new string[]
			{
				" where ID=",
				AdID,
				" AND MemLoginID='",
				MemloginID,
				"'"
			}));
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Delete(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from ShopNum1_CategoryAdPayMent ");
			stringBuilder.Append(" where ID IN (" + string_0 + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable Search(string name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select   ");
			stringBuilder.Append(" A.ID,A.IsAudit,A.AdvertisementID,A.CategoryAdID,A.CategoryType,A.CategoryCode,A.CategoryName,A.TradeID,A.MemLoginID,A.BuyTime,A.StartTime,A.EndTime,A.ShowPayMentPrice,A.PayMentTime,A.IsPayMent,A.AdvertisementPic,A.AdvertisementLike,A.AdvertisementContent,A.PayMentType,A.PayMentName,B.AdvertisementName ");
			stringBuilder.Append(" from ShopNum1_CategoryAdPayMent AS A LEFT JOIN ShopNum1_CategoryAdvertisement AS B ON  A.AdvertisementID=B.ID ");
			stringBuilder.Append(" where A.ID=" + name);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchAdInfo(string categoryid, string categorycode, string categorytype)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@categoryid";
			array2[0] = categoryid;
			array[1] = "@categorycode";
			array2[1] = categorycode;
			array[2] = "@categorytype";
			array2[2] = categorytype;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchAdInfo", array, array2);
		}
		public DataTable SearchAdInfo(string categoryid, string categorytype)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@categoryid";
			array2[0] = categoryid;
			array[1] = "@categorytype";
			array2[1] = categorytype;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchAdInfo2", array, array2);
		}
		public DataSet PayCategoryAdPrice(string tradeid, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@tradeid";
			array2[0] = tradeid;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_PayCategoryAdPrice", array, array2);
		}
		public DataTable GetEndTimeByAdID(string AdvertisementID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT EndTime FROM ShopNum1_CategoryAdPayMent WHERE AdvertisementID=",
				AdvertisementID,
				" AND IsAudit=1 AND EndTime>'",
				DateTime.Now.ToString(),
				"' ORDER BY EndTime DESC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetEndTime(string categoryType, string categroyID, string categoryCode)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT EndTime FROM ShopNum1_CategoryAdPayMent WHERE CategoryAdID='",
				categroyID,
				"' AND CategoryType='",
				categoryType,
				"' AND CategoryCode='",
				categoryCode,
				"' AND IsAudit=1 AND EndTime>'",
				DateTime.Now.ToString(),
				"' ORDER BY EndTime DESC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetBuyCategoryAdByMemloginId(string memloginid, string advertisementname, string categorytype, string categoryid, string categorycode)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@advertisementname";
			array2[1] = advertisementname;
			array[2] = "@categorytype";
			array2[2] = categorytype;
			array[3] = "@categoryid";
			array2[3] = categoryid;
			array[4] = "@categorycode";
			array2[4] = categorycode;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetBuyCategoryAdByMemloginId", array, array2);
		}
		public DataTable GetCategoryAdInfo(string memloginid, string advertisementid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@advertisementid";
			array2[1] = advertisementid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCategoryAdInfo", array, array2);
		}
		public DataTable SearchBuyAdInfo(string isAudit, string categoryid, string categorycode, string categorytype, string MemloginID, string isPayMent, string AdvertisementName, string IsEffective)
		{
			string text = string.Empty;
			text = "SELECT A.*,B.AdvertisementName FROM ShopNum1_CategoryAdPayMent AS A LEFT JOIN ShopNum1_CategoryAdvertisement AS B ON  A.AdvertisementID=B.ID WHERE 0=0";
			if (Operator.FilterString(categoryid) != "-1")
			{
				text = text + " AND A.CategoryAdID='" + categoryid + "' ";
			}
			if (Operator.FilterString(categorycode) != "-1")
			{
				text = text + " AND A.CategoryCode='" + categorycode + "' ";
			}
			if (Operator.FilterString(categorytype) != "-1")
			{
				text = text + " AND A.CategoryType='" + categorytype + "' ";
			}
			if (Operator.FilterString(MemloginID) != "-1")
			{
				text = text + " AND A.MemLoginID='" + MemloginID + "' ";
			}
			if (Operator.FilterString(isPayMent) != "-1")
			{
				text = text + " AND A.IsPayMent=" + isPayMent + " ";
			}
			if (Operator.FilterString(isAudit) != "-1")
			{
				if (Operator.FilterString(isAudit) == "-2")
				{
					text += " AND A.IsAudit IN (0,2) ";
				}
				else
				{
					text = text + " AND A.IsAudit=" + isAudit + " ";
				}
			}
			if (Operator.FilterString(AdvertisementName) != "-1")
			{
				text = text + " AND B.AdvertisementName LIKE '" + AdvertisementName + "%' ";
			}
			if (Operator.FilterString(IsEffective) != "-1")
			{
				if (Operator.FilterString(IsEffective) == "0")
				{
					text = text + " AND A.EndTime <= '" + DateTime.Now.ToString() + "' or IsEffective=0 ";
				}
				else
				{
					text = text + " AND A.EndTime >= '" + DateTime.Now.ToString() + "' AND IsEffective=1 ";
				}
			}
			text += " ORDER BY BuyTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdataCategoryAdInfo(string memloginid, string adID, string isAudit, string FailCause)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"update ShopNum1_CategoryAdPayMent set  IsAudit= ",
				isAudit,
				",  FailCause= '",
				FailCause,
				"'  WHERE MemLoginID='",
				memloginid,
				"' AND ID='",
				adID,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateIsEffective(string time)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@time";
			array2[0] = time;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateIsEffective", array, array2);
		}
	}
}
