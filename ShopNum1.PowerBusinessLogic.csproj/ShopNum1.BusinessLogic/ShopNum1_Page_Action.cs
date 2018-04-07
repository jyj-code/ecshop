using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Page_Action : IShopNum1_Page_Action
	{
		public DataTable Search(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, OrderID,OneID,TwoID,ThreeID,Description,PagePath, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_Page WHERE 0=0";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(int oneID, int twoID, int pageType, string name, string pagePath, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT  Guid, \tName\t,\tOrderID\t,\tOneID\t,\tTwoID\t,\tThreeID\t,\tDescription\t,\tPageType\t,\tPagePath\t,\tCreateUser\t,\tCreateTime\t,\tModifyUser\t,\tModifyTime\t,\tIsDeleted FROM ShopNum1_Page  WHERE 0=0 ";
			if (oneID >= 0)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND OneID=",
					oneID,
					" "
				});
			}
			if (twoID >= 0)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND TwoID=",
					twoID,
					" "
				});
			}
			if (pageType >= 0)
			{
				text = text + " AND PageType=" + pageType;
			}
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name='" + Operator.FilterString(name) + "'";
			}
			if (Operator.FormatToEmpty(pagePath) != string.Empty)
			{
				text = text + " AND PagePath='" + Operator.FilterString(pagePath) + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string guid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT  Guid, \tName\t,\tOrderID\t,\tOneID\t,\tTwoID\t,\tThreeID\t,\tDescription\t,\tPageType\t,\tPagePath\t,\tCreateUser\t,\tCreateTime\t,\tModifyUser\t,\tModifyTime\t,\tIsDeleted FROM ShopNum1_Page  WHERE 0=0 ";
			if (Operator.FormatToEmpty(guid) != string.Empty)
			{
				text = text + " AND Guid='" + Operator.FilterString(guid) + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetOnePageBySuper(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name,OneID  FROM ShopNum1_Page WHERE 0=0 AND TwoID=0 AND ThreeID=0 AND PageType=0";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += " ORDER BY OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetTwopageBySupper(int oneID, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name,OneID,TwoID,PagePath,OrderID FROM ShopNum1_Page WHERE 0=0 AND TwoID!=0 AND PageType=0";
			if (oneID > 0)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND OneID='",
					oneID,
					"'"
				});
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetOnePage(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, OrderID,OneID,TwoID,ThreeID,Description,PagePath, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_Page WHERE 0=0 AND TwoID=0 AND ThreeID=0 AND PageType=0";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += " ORDER BY OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetOnePage(string guid, int isDeleted)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"select D.PageGuid,E.Guid AS Guid,E.Name AS Name,E.PagePath AS PagePath,E.OneID AS OneID,E.TwoID AS TwoID,E.Description AS Description FROM   ( Select distinct PageGuid From   (  Select distinct A.* from ShopNum1_GroupPage AS A,(select GroupGuid From ShopNum1_GroupUser  where UserGuid ='",
				guid,
				"') as B  Where A.GroupGuid = B.GroupGuid  )AS C)AS D, ShopNum1_Page AS E WHERE D.PageGuid = E.Guid AND E.TwoID=0 AND E.ThreeID=0 AND E.PageType=0 And E.IsDeleted=",
				isDeleted
			});
			text += " ORDER BY E.OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetTwopage(int oneID, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, OrderID,OneID,TwoID,ThreeID,Description,PagePath, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_Page WHERE 0=0 AND TwoID!=0 AND PageType=0";
			if (oneID > 0)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND OneID='",
					oneID,
					"'"
				});
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetTwopage(string guid, int oneID, int isDeleted)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"select D.PageGuid,E.Guid AS Guid,E.Name AS Name,E.PagePath AS PagePath,E.OneID AS OneID,E.TwoID AS TwoID,E.Description AS Description FROM   ( Select distinct PageGuid From   (  Select distinct A.* from ShopNum1_GroupPage AS A,(select GroupGuid From ShopNum1_GroupUser  where UserGuid ='",
				guid,
				"') as B  Where A.GroupGuid = B.GroupGuid  )AS C)AS D, ShopNum1_Page AS E WHERE D.PageGuid = E.Guid AND E.TwoID!=0 AND E.PageType=0  AND E.OneID =",
				oneID,
				" And E.IsDeleted=",
				isDeleted
			});
			text += " ORDER BY E.OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetTopPage(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, OrderID,OneID,TwoID,ThreeID,Description,PagePath, IsDeleted FROM ShopNum1_Page WHERE 0=0 AND TwoID=0 AND ThreeID=0 AND PageType=3";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += " ORDER BY OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Add(ShopNum1_Page page)
		{
			string strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Page( Guid, \tName\t,\tOrderID\t,\tOneID\t,\tTwoID\t,\tThreeID\t,\tDescription\t,\tPageType\t,\tPagePath\t,\tCreateUser\t,\tCreateTime\t,\tModifyUser\t,\tModifyTime\t,\tIsDeleted ) VALUES (  '",
				page.Guid,
				"',  '",
				Operator.FilterString(page.Name),
				"',  ",
				page.OrderID,
				",  ",
				page.OneID,
				",  ",
				page.TwoID,
				",  ",
				page.ThreeID,
				",  '",
				Operator.FilterString(page.Description),
				"',  ",
				page.PageType,
				",  '",
				Operator.FilterString(page.PagePath),
				"',  '",
				page.CreateUser,
				"', '",
				page.CreateTime,
				"',  '",
				page.ModifyUser,
				"' , '",
				page.ModifyTime,
				"',  ",
				page.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(ShopNum1_Page page)
		{
			string text = " UPDATE shopnum1_page SET Name='{0}',OneID={1},TwoID={2},ThreeID={3},Description='{4}',PageType={5},PagePath='{6}',ModifyTime='{7}',ModifyUser='{8}',IsDeleted=0 where Guid='{9}'";
			text = string.Format(text, new object[]
			{
				page.Name,
				page.OneID,
				page.TwoID,
				page.ThreeID,
				page.Description,
				page.PageType,
				page.PagePath,
				page.ModifyTime,
				page.ModifyUser,
				page.Guid
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int RetrunMaxTwoID(int oneID)
		{
			string strSql = "SELECT max(TwoID) FROM ShopNum1_Page  WHERE OneID=" + oneID;
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int result;
			if (dataTable.Rows.Count < 1)
			{
				result = 0;
			}
			else if (dataTable.Rows[0][0].ToString() != "")
			{
				result = int.Parse(dataTable.Rows[0][0].ToString());
			}
			else
			{
				result = 0;
			}
			return result;
		}
		public int RetrunMaxThreeID(int oneID, int twoID)
		{
			string strSql = string.Concat(new object[]
			{
				"SELECT max(ThreeID) FROM ShopNum1_Page  WHERE OneID=",
				oneID,
				" AND  TwoID=",
				twoID
			});
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int result;
			if (dataTable.Rows.Count < 1)
			{
				result = 0;
			}
			else if (dataTable.Rows[0][0].ToString() != "")
			{
				result = int.Parse(dataTable.Rows[0][0].ToString());
			}
			else
			{
				result = 0;
			}
			return result;
		}
		public int DelPageBySuper(string pageguid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@pageguid";
			array2[0] = pageguid;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_PageDelBySuper", array, array2);
		}
	}
}
