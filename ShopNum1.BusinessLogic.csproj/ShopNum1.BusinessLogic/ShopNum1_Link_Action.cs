using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Link_Action : IShopNum1_Link_Action
	{
		public int Add(ShopNum1_Link Service_Link)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT ShopNum1_Link(Guid,Name,ImgADD,Href,OrderID,ImgType,LinkType,Description,Memo,IsShow,CreateTime, CreateUser, ModifyUser, ModifyTime, SubstationID, IsDeleted ) values('",
				Service_Link.Guid,
				"','",
				Operator.FilterString(Service_Link.Name),
				"','",
				Operator.FilterString(Service_Link.ImgADD),
				"','",
				Operator.FilterString(Service_Link.Href),
				"',",
				Service_Link.OrderID,
				",'",
				Operator.FilterString(Service_Link.ImgType),
				"',",
				Service_Link.LinkType,
				",'",
				Operator.FilterString(Service_Link.Description),
				"','",
				Operator.FilterString(Service_Link.Memo),
				"',",
				Service_Link.IsShow,
				", '",
				Service_Link.CreateTime,
				"',  '",
				Operator.FilterString(Service_Link.CreateUser),
				"', '",
				Operator.FilterString(Service_Link.ModifyUser),
				"' , '",
				Service_Link.ModifyTime,
				"',  '",
				Service_Link.SubstationID,
				"',  '",
				Service_Link.IsDeleted,
				"' )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT  Name, ImgADD, Href, ImgType, OrderID, Description, Memo, LinkType,IsShow FROM ShopNum1_Link Where Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string name, int isShow)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, ImgADD, Href, ImgType, OrderID, Description, Memo,CreateTime, LinkType,IsShow FROM ShopNum1_Link Where 0=0";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
			}
			if (isShow != -1)
			{
				text = text + " AND IsShow=" + isShow;
			}
			text += " ORDER BY OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string name, int isShow, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, ImgADD, Href, ImgType, OrderID, Description, Memo,CreateTime, LinkType,IsShow FROM ShopNum1_Link Where 0=0";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
			}
			if (isShow != -1)
			{
				text = text + " AND IsShow=" + isShow;
			}
			if (SubstationID != "-1")
			{
				text = text + " AND   SubstationID='" + SubstationID + "'";
			}
			text += " ORDER BY OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT  Name, ImgADD, Href, ImgType, OrderID, Description, Memo, LinkType,IsDeleted,IsShow FROM ShopNum1_Link Where 0=0 and IsShow=1";
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
			text += " ORDER BY OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Link WHERE Guid IN (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(string guid, ShopNum1_Link Service_Link)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"update  ShopNum1_Link set Href='",
				Operator.FilterString(Service_Link.Href),
				"',ImgADD='",
				Operator.FilterString(Service_Link.ImgADD),
				"',Memo='",
				Operator.FilterString(Service_Link.Memo),
				"',[Name]='",
				Operator.FilterString(Service_Link.Name),
				"',OrderID=",
				Service_Link.OrderID,
				",LinkType=",
				Service_Link.LinkType,
				",ImgType=",
				Service_Link.ImgType,
				",Description='",
				Operator.FilterString(Service_Link.Description),
				"',IsShow=",
				Service_Link.IsShow,
				" where Guid=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetLink()
		{
			string strProcedureName = "Pro_ShopNum1_GetLinkList";
			return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName);
		}
		public DataTable GetLinkListImage(string showCount)
		{
			string strProcedureName = "[dbo].[Pro_ShopNum1_GetLinkListImage]";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@showCount";
			array2[0] = showCount;
			return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, array, array2);
		}
		public DataTable GetLinkListImage(string showCount, string SubstationID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				" SELECT TOP  ",
				showCount,
				"  * FROM  ShopNum1_Link   WHERE      SubstationID='",
				SubstationID,
				"'  AND  IsDeleted=0   AND   IsShow=1 ORDER BY OrderID DESC          "
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable CheckIsDuplication(string link)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@link";
			array2[0] = link;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CheckIsDuplication", array, array2);
		}
		int IShopNum1_Link_Action.Add(ShopNum1_Link Service_Link)
		{
			throw new NotImplementedException();
		}
		int IShopNum1_Link_Action.Delete(string guids)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_Link_Action.GetEditInfo(string guid)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_Link_Action.GetLink()
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_Link_Action.Search(int isDeleted)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_Link_Action.Search(string name, int isShow)
		{
			throw new NotImplementedException();
		}
		int IShopNum1_Link_Action.Update(string guid, ShopNum1_Link Service_Link)
		{
			throw new NotImplementedException();
		}
	}
}
