using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Announcement_Action : IShopNum1_Announcement_Action
	{
		public int Add(ShopNum1_Announcement announcement)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Announcement( Guid, Title, Remark, Keywords, Description, AnnouncementCategoryID, CreateUser, CreateTime, ModifyUser, ModifyTime, SubstationID,  IsDeleted ) VALUES (  '",
				announcement.Guid,
				"',  '",
				Operator.FilterString(announcement.Title),
				"',  '",
				announcement.Remark,
				"',  '",
				announcement.Keywords,
				"',  '",
				announcement.Description,
				"',  ",
				announcement.AnnouncementCategoryID,
				",  '",
				Operator.FilterString(announcement.CreateUser),
				"', '",
				announcement.CreateTime,
				"',  '",
				Operator.FilterString(announcement.ModifyUser),
				"' , '",
				announcement.ModifyTime,
				"',  '",
				announcement.SubstationID,
				"',  ",
				announcement.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "delete from ShopNum1_Announcement  WHERE Guid IN (" + guids + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string guid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid,Title,Description,Keywords, Remark,AnnouncementCategoryID,CreateUser,CreateTime,ModifyUser, ModifyTime,IsDeleted  FROM ShopNum1_Announcement Where 0=0";
			if (guid != string.Empty)
			{
				text = text + " AND  Guid= " + guid + " ";
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
		public DataTable Search(string title, string creater, string startDate, string endDate, int isDeleted, string category)
		{
			string text = string.Empty;
			text = "SELECT Guid,Title, Remark,CreateUser,CreateTime,ModifyUser,announcementcategoryid, ModifyTime,IsDeleted  FROM ShopNum1_Announcement Where 0=0";
			if (Operator.FormatToEmpty(title) != null)
			{
				text = text + " AND Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(creater) != null)
			{
				text = text + " AND CreateUser LIKE '%" + Operator.FilterString(creater) + "%'";
			}
			if (Operator.FormatToEmpty(startDate) != string.Empty)
			{
				text = text + " AND CreateTime>='" + Operator.FilterString(startDate) + "' ";
			}
			if (Operator.FormatToEmpty(endDate) != string.Empty)
			{
				text = text + " AND CreateTime<='" + Operator.FilterString(endDate) + "' ";
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
			if (category != "-1")
			{
				text = text + " AND AnnouncementCategoryID=" + category + " ";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string title, string creater, string startDate, string endDate, int isDeleted, string category, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT Guid,Title, Remark,CreateUser,CreateTime,ModifyUser,announcementcategoryid,SubstationID, ModifyTime,IsDeleted  FROM ShopNum1_Announcement Where 0=0";
			if (Operator.FormatToEmpty(title) != null)
			{
				text = text + " AND Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(creater) != null)
			{
				text = text + " AND CreateUser LIKE '%" + Operator.FilterString(creater) + "%'";
			}
			if (Operator.FormatToEmpty(startDate) != string.Empty)
			{
				text = text + " AND CreateTime>='" + Operator.FilterString(startDate) + "' ";
			}
			if (Operator.FormatToEmpty(endDate) != string.Empty)
			{
				text = text + " AND CreateTime<='" + Operator.FilterString(endDate) + "' ";
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
			if (category != "-1")
			{
				text = text + " AND AnnouncementCategoryID=" + category + " ";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND  SubstationID='" + SubstationID + "' ";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(string guid, ShopNum1_Announcement announcement)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Announcement SET  Title='",
				Operator.FilterString(announcement.Title),
				"', Remark='",
				announcement.Remark,
				"', Keywords='",
				announcement.Keywords,
				"', Description='",
				announcement.Description,
				"', AnnouncementCategoryID=",
				announcement.AnnouncementCategoryID,
				", ModifyUser='",
				Operator.FilterString(announcement.ModifyUser),
				"', ModifyTime='",
				announcement.ModifyTime,
				"',  CreateTime='",
				announcement.CreateTime,
				"'WHERE Guid=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchTitle(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid,Title,IsDeleted,CreateTime FROM ShopNum1_Announcement Where 0=0";
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
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchTitle(int isDeleted, int count)
		{
			string text = string.Empty;
			if (count > 0)
			{
				text = "SELECT top " + count;
			}
			else
			{
				text = "SELECT ";
			}
			text += " Guid,Title,IsDeleted,CreateTime FROM ShopNum1_Announcement Where 0=0";
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
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetAnnoucementMeto(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT  Title ,  Keywords,   Description   FROM ShopNum1_Announcement  Where Guid='" + Operator.FilterString(guid) + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetAnnouncementOnAndNext(string guid, string onAnnouncementName, string nextAnnouncementName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @modifyTime datetime ");
			stringBuilder.Append("SELECT @modifyTime = ModifyTime FROM ShopNum1_Announcement ");
			stringBuilder.Append("WHERE Guid = '" + guid + "' ");
			stringBuilder.Append("SELECT * FROM(");
			stringBuilder.Append("SELECT TOP 1 Guid,Title,'" + onAnnouncementName + "' as [Name] FROM ShopNum1_Announcement ");
			stringBuilder.Append("WHERE ModifyTime < @modifyTime ");
			stringBuilder.Append("ORDER BY ModifyTime DESC");
			stringBuilder.Append(") as a ");
			stringBuilder.Append("UNION ");
			stringBuilder.Append("SELECT * FROM(");
			stringBuilder.Append("SELECT TOP 1 Guid,Title,'" + nextAnnouncementName + "' as [Name] FROM ShopNum1_Announcement ");
			stringBuilder.Append("WHERE ModifyTime > @modifyTime ");
			stringBuilder.Append("ORDER BY ModifyTime ASC ");
			stringBuilder.Append(") as b");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetAnnoucementNew(string showCount)
		{
			string text = string.Empty;
			text = "SELECT top " + showCount + "Guid,Title  FROM ShopNum1_Announcement  Where IsDeleted= 0";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetAnnoucementNew(string showCount, string SubstationID)
		{
			string text = string.Empty;
			text = text + "   SELECT top " + showCount + "     ";
			text += "   A.[Guid]     ";
			text += "   ,A.[Title]     ";
			text += "   ,A.[Remark]     ";
			text += "   ,A.[CreateUser]     ";
			text += "   ,A.[CreateTime]     ";
			text += "   ,A.[AnnouncementCategoryID]     ";
			text += "   ,A.[SubstationID] FROM ShopNum1_Announcement AS A LEFT JOIN   ShopNum1_AnnouncementCategory AS B     ";
			text += "   ON A.AnnouncementCategoryID=B.ID      ";
			text = text + "    WHERE   B.Name<>'店铺公告' AND B.Name<>'会员公告'  AND A.SubstationID='" + SubstationID + "'     ";
			text += "    ORDER BY  A.[CreateTime]    DESC    ";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetShopAnnouncementNew(string showCount, string AnnouncementCategoryID)
		{
			string strSql = string.Empty;
			strSql = "select top " + showCount + "Guid, Title  FROM ShopNum1_Announcement  Where IsDeleted= 0 And AnnouncementCategoryID=" + AnnouncementCategoryID;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetAnnoucementList()
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid , Title ,  Remark   FROM ShopNum1_Announcement  Where IsDeleted= 0";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetAnnoucementDetails(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Title, Remark, CreateUser, CreateTime FROM ShopNum1_Announcement Where Guid ='" + guid + "' and IsDeleted = 0";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetAnnouncementByTypeName(string cName, int int_0, string SubstationID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"   SELECT top ",
				int_0,
				"     A.[Guid]  ,A.[Title]    ,A.[Remark]    ,A.[CreateUser]    ,A.[CreateTime]    ,A.[AnnouncementCategoryID]    ,A.[SubstationID] FROM ShopNum1_Announcement AS A LEFT JOIN   ShopNum1_AnnouncementCategory AS B      ON A.AnnouncementCategoryID=B.ID        WHERE   B.Name='",
				cName,
				"'     AND (A.SubstationID='",
				SubstationID,
				"' or A.SubstationID='all')          ORDER BY  A.[CreateTime]    DESC     "
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
