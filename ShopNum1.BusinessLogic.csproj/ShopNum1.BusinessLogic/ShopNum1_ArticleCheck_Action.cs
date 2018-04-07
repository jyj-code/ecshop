using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ArticleCheck_Action : IShopNum1_ArticleCheck_Action
	{
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Shop_News WHERE Guid IN (" + guids + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string guid)
		{
			string text = "SELECT Guid, Title, [Content], IsShow, OrderID, CreateTime, SEOTitle, Keywords, Description, NewsCategoryGuid, MemLoginID, IsAudit   FROM ShopNum1_Shop_News  Where 0=0";
			if (Operator.FormatToEmpty(guid) != string.Empty)
			{
				text = text + " AND  Guid= " + guid + " ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string title, string shopID, string startdate, string enddate, int IsAudit, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT   A.Guid, A.Title, A.[Content], A.IsShow, A.OrderID, A.CreateTime, A.SEOTitle, A.Keywords, A.Description, A.NewsCategoryGuid, A.MemLoginID, A.IsAudit,B.Name  FROM ShopNum1_Shop_News A LEFT JOIN ShopNum1_Shop_NewsCategory B on A.NewsCategoryGuid=B.Guid  Where 0=0";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(shopID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + shopID + "%'";
			}
			if (Operator.FormatToEmpty(startdate) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(startdate) + "' ";
			}
			if (Operator.FormatToEmpty(enddate) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(enddate) + "' ";
			}
			if (IsAudit != -1)
			{
				if (IsAudit == -2)
				{
					text += " AND A.IsAudit IN (0,2) ";
				}
				else if (IsAudit == -3)
				{
					text += " AND A.IsAudit IN (1,3) ";
				}
				else
				{
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						" AND A.IsAudit =",
						IsAudit,
						" "
					});
				}
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsDeleted =",
					isDeleted,
					" "
				});
			}
			text += " ORDER BY A.OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string title, string shopID, string startdate, string enddate, int IsAudit, int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT   A.Guid, A.Title, A.[Content], A.IsShow, A.OrderID, A.CreateTime, A.SEOTitle, A.Keywords, A.Description, A.NewsCategoryGuid, A.MemLoginID, A.IsAudit,C.SubstationID,B.Name   FROM  ShopNum1_Shop_News AS A LEFT JOIN ShopNum1_Shop_NewsCategory AS  B on A.NewsCategoryGuid=B.Guid      left join ShopNum1_ShopInfo as C on  A.MemLoginID=C.MemLoginID     Where 0=0";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(shopID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + shopID + "%'";
			}
			if (Operator.FormatToEmpty(startdate) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(startdate) + "' ";
			}
			if (Operator.FormatToEmpty(enddate) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(enddate) + "' ";
			}
			if (IsAudit != -1)
			{
				if (IsAudit == -2)
				{
					text += " AND A.IsAudit IN (0,2) ";
				}
				else if (IsAudit == -3)
				{
					text += " AND A.IsAudit IN (1,3) ";
				}
				else
				{
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						" AND A.IsAudit =",
						IsAudit,
						" "
					});
				}
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsDeleted =",
					isDeleted,
					" "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + " AND  C.SubstationID='" + SubstationID + "' ";
			}
			text += " ORDER BY A.OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdateAudit(string guids, int isAudit)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Shop_News SET  IsAudit\t=",
				isAudit,
				" WHERE Guid in (",
				guids,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchDetailsByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.CreateTime,A.Title,A.Content,A.Keywords,A.MemLoginID,B.Name FROM ShopNum1_Shop_News AS A, ShopNum1_Shop_NewsCategory AS B WHERE A.NewsCategoryGuid=B.Guid AND A.Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataSet Search(string pageindex, string pagesize, string addresscode, string articlecategory, string startTime, string endTime, string keywords, string title)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@pageindex";
			array2[0] = pageindex;
			array[1] = "@pagesize";
			array2[1] = pagesize;
			array[2] = "@articlecategory";
			array2[2] = articlecategory;
			array[3] = "@createtime1";
			array2[3] = startTime;
			array[4] = "@createtime2";
			array2[4] = endTime;
			array[5] = "@keywords";
			array2[5] = keywords;
			array[6] = "@title";
			array2[6] = title;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_GetArticleInfoSearch", array, array2);
		}
		public DataTable Select_List(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = " *  ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_ArticleComment";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "SendTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable GetTitleByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "    SELECT  Title  FROM  ShopNum1_Article  WHERE  Guid ='" + guid + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int DeleteArticleComment(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_ArticleComment  WHERE Guid IN (" + guids + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchCommentDetailByGuid(string guid)
		{
			string text = string.Empty;
			text += "     SELECT A.* ,B.Title  AS ArticleTitle  FROM ShopNum1_ArticleComment AS  A  LEFT JOIN ShopNum1_Article AS B       ";
			text += "     ON A.ArticleGuid=B.Guid      ";
			text = text + "     WHERE A.Guid='" + guid + "'      ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
