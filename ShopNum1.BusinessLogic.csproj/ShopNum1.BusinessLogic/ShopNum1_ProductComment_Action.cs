using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ProductComment_Action : IShopNum1_ProductComment_Action
	{
		public DataTable GetProductAll(string ProductName, string ShopID, string createMember, string isaudit, string createTime1, string createTime2)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("b.Name,");
			stringBuilder.Append("b.ProductState,");
			stringBuilder.Append("a.ProductGuid,");
			stringBuilder.Append("a.MemLoginID,");
			stringBuilder.Append("a.ShopID,");
			stringBuilder.Append("a.ShopName,");
			stringBuilder.Append("a.shopid AS Shopids,");
			stringBuilder.Append("a.CommentTime,");
			stringBuilder.Append("a.IsAudit");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shop_ProductComment AS a,");
			stringBuilder.Append("ShopNum1_Shop_Product AS b");
			stringBuilder.Append(" WHERE a.ProductGuid=b.Guid ");
			if (Operator.FormatToEmpty(ProductName) != string.Empty)
			{
				stringBuilder.Append(" AND b.Name LIKE '%" + Operator.FilterString(ProductName) + "%'");
			}
			if (Operator.FormatToEmpty(ShopID) != string.Empty)
			{
				stringBuilder.Append(" AND a.ShopName like '%" + ShopID + "%'");
			}
			if (Operator.FormatToEmpty(createMember) != string.Empty)
			{
				stringBuilder.Append(" AND a.MemLoginID LIKE '%" + Operator.FilterString(createMember) + "%'");
			}
			if (isaudit != "1")
			{
				stringBuilder.Append(" AND a.IsAudit IN(0,2) ");
			}
			else
			{
				stringBuilder.Append(" AND a.IsAudit=1 ");
			}
			if (Operator.FormatToEmpty(createTime1) != string.Empty)
			{
				stringBuilder.Append(" AND a.CommentTime>='" + createTime1 + "' ");
			}
			if (Operator.FormatToEmpty(createTime2) != string.Empty)
			{
				stringBuilder.Append(" AND a.CommentTime<='" + createTime2 + "' ");
			}
			stringBuilder.Append(" ORDER BY a.CommentTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetProductAll1(string ProductName, string ShopID, string createMember, string isaudit, string createTime1, string createTime2, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("b.Name,");
			stringBuilder.Append("b.ProductState,");
			stringBuilder.Append("a.ProductGuid,");
			stringBuilder.Append("a.MemLoginID,");
			stringBuilder.Append("a.ShopID,");
			stringBuilder.Append("a.ShopName,");
			stringBuilder.Append("a.shopid AS Shopids,");
			stringBuilder.Append("a.CommentTime,");
			stringBuilder.Append("c.SubstationID,");
			stringBuilder.Append("a.IsAudit");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shop_ProductComment AS a,");
			stringBuilder.Append("ShopNum1_Shop_Product AS b,");
			stringBuilder.Append("ShopNum1_ShopInfo AS c ");
			stringBuilder.Append(" WHERE a.ProductGuid=b.Guid  and  a.ShopID=c.ShopID  ");
			if (Operator.FormatToEmpty(ProductName) != string.Empty)
			{
				stringBuilder.Append(" AND b.Name LIKE '%" + Operator.FilterString(ProductName) + "%'");
			}
			if (Operator.FormatToEmpty(ShopID) != string.Empty)
			{
				stringBuilder.Append(" AND a.ShopName like '%" + ShopID + "%'");
			}
			if (Operator.FormatToEmpty(createMember) != string.Empty)
			{
				stringBuilder.Append(" AND a.MemLoginID LIKE '%" + Operator.FilterString(createMember) + "%'");
			}
			if (isaudit != "1")
			{
				stringBuilder.Append(" AND a.IsAudit IN(0,2) ");
			}
			else
			{
				stringBuilder.Append(" AND a.IsAudit=1 ");
			}
			if (Operator.FormatToEmpty(createTime1) != string.Empty)
			{
				stringBuilder.Append(" AND a.CommentTime>='" + createTime1 + "' ");
			}
			if (Operator.FormatToEmpty(createTime2) != string.Empty)
			{
				stringBuilder.Append(" AND a.CommentTime<='" + createTime2 + "' ");
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND c.SubstationID='" + SubstationID + "' ");
			}
			stringBuilder.Append(" ORDER BY a.CommentTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetProductAll(string ProductName, string ProductGuid, string createMember, string isAudit, string createTime1, string createTime2, string memLoginID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("b.Name,");
			stringBuilder.Append("a.MemLoginID,");
			stringBuilder.Append("a.SendTime,");
			stringBuilder.Append("a.IsAudit");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shop_ProductComment AS a,");
			stringBuilder.Append("ShopNum1_Shop_Product AS b");
			stringBuilder.Append(" WHERE a.ProductGuid=b.Guid");
			stringBuilder.Append(" AND a.MemLoginID='" + memLoginID + "'");
			if (Operator.FormatToEmpty(ProductName) != string.Empty)
			{
				stringBuilder.Append(" AND b.Name LIKE '%" + Operator.FilterString(ProductName) + "%'");
			}
			if (Operator.FormatToEmpty(ProductGuid) != string.Empty)
			{
				stringBuilder.Append(" AND a.Guid LIKE '%" + Operator.FilterString(ProductGuid) + "%'");
			}
			if (Operator.FormatToEmpty(createMember) != string.Empty)
			{
				stringBuilder.Append(" AND a.MemLoginID LIKE '%" + Operator.FilterString(createMember) + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				stringBuilder.Append(" AND a.IsAudit LIKE '%" + isAudit + "%'");
			}
			if (Operator.FormatToEmpty(createTime1) != string.Empty)
			{
				stringBuilder.Append(" AND a.SendTime>='" + createTime1 + "' ");
			}
			if (Operator.FormatToEmpty(createTime2) != string.Empty)
			{
				stringBuilder.Append(" AND a.SendTime<='" + createTime2 + "' ");
			}
			stringBuilder.Append(" ORDER BY a.SendTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int DeleteProduct(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "delete from ShopNum1_Shop_ProductComment  WHERE [Guid] IN (" + guids + ") ";
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int DeleteProductComment(string guids)
		{
			string strSql = string.Empty;
			strSql = "update ShopNum1_Shop_ProductComment set IsDelete=1  WHERE [Guid] IN (" + guids + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetProductCommentMemberID(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" SELECT ");
			stringBuilder.Append(" MemLoginID");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1Multi_ProductComment");
			stringBuilder.Append(" WHERE guid='" + guid + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int UpdateProductAudit(string guids, string state)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ");
			stringBuilder.Append("ShopNum1_Shop_ProductComment");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("IsAudit = " + state);
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] in (" + guids + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable MemberProductComment(string memloginid, string commenttitle, string productname, string shopID, string isaudit, string createtime1, string createtime2)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@commenttitle";
			array2[1] = commenttitle;
			array[2] = "@productname";
			array2[2] = productname;
			array[3] = "@shopid";
			array2[3] = shopID;
			array[4] = "@isaudit";
			array2[4] = isaudit;
			array[5] = "@createtime1";
			array2[5] = createtime1;
			array[6] = "@createtime2";
			array2[6] = createtime2;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberProductComment", array, array2);
		}
		public DataTable ShopProductComment(string shopid, string commenttitle, string productname, string productguid, string createmember, string isaudit, string createtime1, string createtime2)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@commenttitle";
			array2[1] = commenttitle;
			array[2] = "@productname";
			array2[2] = productname;
			array[3] = "@productguid";
			array2[3] = productguid;
			array[4] = "@createmember";
			array2[4] = createmember;
			array[5] = "@isaudit";
			array2[5] = isaudit;
			array[6] = "@createtime1";
			array2[6] = createtime1;
			array[7] = "@createtime2";
			array2[7] = createtime2;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ShopProductComment", array, array2);
		}
		public DataTable ShopProductCommentList(string shopid, string commenttitle, string productname, string isreply, string createmember, string isaudit, string createtime1, string createtime2)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@commenttitle";
			array2[1] = commenttitle;
			array[2] = "@productname";
			array2[2] = productname;
			array[3] = "@isreply";
			array2[3] = isreply;
			array[4] = "@createmember";
			array2[4] = createmember;
			array[5] = "@isaudit";
			array2[5] = isaudit;
			array[6] = "@createtime1";
			array2[6] = createtime1;
			array[7] = "@createtime2";
			array2[7] = createtime2;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ShopProductCommentList", array, array2);
		}
		public int Add(ShopNum1_Shop_ProductComment productcomment)
		{
			string strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Shop_ProductComment( Guid,CommentType,Speed,Comment,CommentTime,IsDelete,ProductGuid,ProductName,Title,ShopID,MemLoginID,OrderGuid,Attitude,Character,IsAudit ) VALUES ( '",
				productcomment.Guid,
				"',",
				productcomment.CommentType,
				",",
				productcomment.Speed,
				",'",
				Operator.FilterString(productcomment.Comment),
				"','",
				productcomment.CommentTime,
				"',",
				productcomment.IsDelete,
				",'",
				productcomment.ProductGuid,
				"','",
				Operator.FilterString(productcomment.ProductName),
				"','",
				productcomment.ShopID,
				"','",
				productcomment.MemLoginID,
				"','",
				productcomment.OrderGuid,
				"', ",
				productcomment.Attitude,
				", ",
				productcomment.Character,
				",",
				productcomment.IsAudit,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Add(List<ShopNum1_Shop_ProductComment> listProductComment)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < listProductComment.Count; i++)
			{
				string item = string.Concat(new object[]
				{
					"INSERT INTO ShopNum1_Shop_ProductComment( Guid,CommentType,Speed,Comment,CommentTime,IsDelete,ProductGuid,ProductName,ProductPrice,Shoploginid,ShopName,ShopID,MemLoginID,OrderGuid,Attitude,Character,IsAudit ) VALUES ( '",
					listProductComment[i].Guid,
					"',",
					listProductComment[i].CommentType,
					",",
					listProductComment[i].Speed,
					",'",
					Operator.FilterString(listProductComment[i].Comment),
					"','",
					listProductComment[i].CommentTime,
					"',",
					listProductComment[i].IsDelete,
					",'",
					listProductComment[i].ProductGuid,
					"','",
					Operator.FilterString(listProductComment[i].ProductName),
					"','",
					listProductComment[i].ProductPrice,
					"','",
					listProductComment[i].ShopLoginId,
					"','",
					listProductComment[i].ShopName,
					"','",
					listProductComment[i].ShopID,
					"','",
					listProductComment[i].MemLoginID,
					"','",
					listProductComment[i].OrderGuid,
					"', ",
					listProductComment[i].Attitude,
					", ",
					listProductComment[i].Character,
					",",
					listProductComment[i].IsAudit,
					")"
				});
				list.Add(item);
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Search(string orderguid, string menlogin)
		{
			string text = string.Empty;
			text = "SELECT Guid  FROM ShopNum1_Shop_ProductComment  WHERE 0=0 ";
			if (orderguid != "-1")
			{
				text = text + " AND OrderGuid in ('" + orderguid + "')";
			}
			if (menlogin != "")
			{
				text = text + " AND MemLoginID in ('" + menlogin + "')";
			}
			int count = DatabaseExcetue.ReturnDataTable(text).Rows.Count;
			int result;
			if (count > 0)
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
			return result;
		}
		public DataTable Search(string guid)
		{
			string text = string.Empty;
			text = "SELECT *  FROM ShopNum1_Shop_ProductComment  WHERE 0=0 ";
			if (guid != "-1")
			{
				text = text + " AND Guid in ('" + guid + "')";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdateComment(string guid, string reply, string replytime, string BuyerAttitude)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"update ShopNum1_Shop_ProductComment set Reply='",
				reply,
				"',ReplyTime='",
				replytime,
				"',BuyerAttitude=",
				BuyerAttitude,
				" WHERE [Guid] IN ('",
				guid,
				"') "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetCommentTypeByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT CommentType,IsAudit,ShopID,MemLoginID,ShopLoginId FROM ShopNum1_Shop_ProductComment WHERE Guid IN (" + guid + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateComment(string guid, string reply, string replytime, string BuyerAttitude, bool IsContinueComment)
		{
			string strSql = string.Empty;
			if (IsContinueComment)
			{
				strSql = string.Concat(new string[]
				{
					"update ShopNum1_Shop_ProductComment set ContinueReply='",
					reply,
					"',ContinueReplyTime='",
					replytime,
					"',ContinueState=2 WHERE Guid = '",
					guid,
					"' "
				});
			}
			else
			{
				strSql = string.Concat(new string[]
				{
					"update ShopNum1_Shop_ProductComment set Reply='",
					reply,
					"',ReplyTime='",
					replytime,
					"',BuyerAttitude=",
					BuyerAttitude,
					" WHERE Guid = '",
					guid,
					"' "
				});
			}
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateProductComment(string guid, string content)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Shop_ProductComment SET ContinueComment='",
				Operator.FilterString(content),
				"',ContinueTime='",
				DateTime.Now,
				"',ContinueState=1 WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable CheckIsComment(string orderguid, string menlogin)
		{
			string text = string.Empty;
			text = "SELECT Guid,CONTINUECOMMENT  FROM ShopNum1_Shop_ProductComment  WHERE 0=0 ";
			text = text + " AND OrderGuid in ('" + orderguid + "')";
			text = text + " AND MemLoginID in ('" + menlogin + "')";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetShopIDByName(string name)
		{
			string strSql = string.Empty;
			strSql = " select ShopID from ShopNum1_ShopInfo where MemLoginID='" + name + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
	}
}
