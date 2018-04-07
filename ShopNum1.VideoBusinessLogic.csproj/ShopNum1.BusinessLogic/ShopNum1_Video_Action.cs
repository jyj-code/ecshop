using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Video_Action : IShopNum1_Video_Action
	{
		public int Add(ShopNum1_Video video)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Video( Guid,Title,ImgAdd,VideoAdd,CategoryID,[Content],Keywords,IsRecommend,OrderID,CreateUser,CreateTime,ModifyUser,KeyWordsSeo,Description,BroadcastCount,SubstationID,ModifyTime ) VALUES ( '",
				video.Guid,
				"','",
				Operator.FilterString(video.Title),
				"','",
				Operator.FilterString(video.ImgAdd),
				"','",
				video.VideoAdd,
				"','",
				Operator.FilterString(video.CategoryID),
				"','",
				Operator.FilterString(video.Content),
				"','",
				Operator.FilterString(video.KeyWords),
				"',",
				video.IsRecommend,
				",",
				video.OrderID,
				",'",
				video.CreateUser,
				"','",
				video.CreateTime,
				"','",
				video.ModifyUser,
				"','",
				video.KeyWordsSeo,
				"','",
				video.Description,
				"','",
				video.BroadcastCount,
				"','",
				video.SubstationID,
				"','",
				video.ModifyTime,
				"')"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "delete  from ShopNum1_Video where Guid in(" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetVideoAll(string title, string categoryCode, string publisher, int IsRecommend, string time1, string time2, int isDeleted)
		{
			string text = string.Empty;
			text = "select A.*,B.Name from ShopNum1_Video as a Left join  ShopNum1_VideoCategory as b on a.CategoryID =b.ID where 1=1 ";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title Like '%" + Operator.FilterString(title) + "%'";
			}
			if (categoryCode != "-1")
			{
				text = text + " AND A.CategoryID =" + categoryCode;
			}
			if (Operator.FormatToEmpty(publisher) != string.Empty)
			{
				text = text + " AND A.CreateUser='" + Operator.FilterString(publisher) + "' ";
			}
			if (IsRecommend.ToString().Trim() != "-1")
			{
				text = text + " AND A.IsRecommend=" + Operator.FilterString(IsRecommend) + " ";
			}
			if (Operator.FormatToEmpty(time1) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(time1) + "' ";
			}
			if (Operator.FormatToEmpty(time2) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(time2) + "' ";
			}
			text += "  ORDER BY A.OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetVideoAll(string title, string categoryCode, string publisher, int IsRecommend, string time1, string time2, int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "select A.*,B.Name from ShopNum1_Video as a Left join  ShopNum1_VideoCategory as b on a.CategoryID =b.ID where 1=1 ";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title Like '%" + Operator.FilterString(title) + "%'";
			}
			if (categoryCode != "-1")
			{
				text = text + " AND A.CategoryID =" + categoryCode;
			}
			if (Operator.FormatToEmpty(publisher) != string.Empty)
			{
				text = text + " AND A.CreateUser='" + Operator.FilterString(publisher) + "' ";
			}
			if (IsRecommend.ToString().Trim() != "-1")
			{
				text = text + " AND A.IsRecommend=" + Operator.FilterString(IsRecommend) + " ";
			}
			if (Operator.FormatToEmpty(time1) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(time1) + "' ";
			}
			if (Operator.FormatToEmpty(time2) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(time2) + "' ";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND A.SubstationID='" + Operator.FilterString(SubstationID) + "' ";
			}
			text += "  ORDER BY A.OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpDateVideo(string guid, ShopNum1_Video video)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Video SET Title='",
				Operator.FilterString(video.Title),
				"',ImgAdd='",
				Operator.FilterString(video.ImgAdd),
				"',VideoAdd='",
				video.VideoAdd,
				"',CategoryID='",
				video.CategoryID,
				"',Keywords='",
				Operator.FilterString(video.KeyWords),
				"',Content='",
				Operator.FilterString(video.Content),
				"',IsRecommend=",
				video.IsRecommend,
				",OrderID=",
				video.OrderID,
				",KeyWordsSeo='",
				video.KeyWordsSeo,
				"',Description='",
				video.Description,
				"',ModifyUser='",
				video.ModifyUser,
				"',ModifyTime='",
				video.ModifyTime,
				"' where Guid=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetVideoByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "select A.*,B.Name from ShopNum1_Video as a Left join  ShopNum1_VideoCategory as b on a.CategoryID =b.ID   where Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetVideoList(int showcount, string isrecommend)
		{
			string text = string.Empty;
			if (showcount > 0)
			{
				text = "SELECT top " + showcount + "  *  FROM ShopNum1_Video  where 1=1 ";
			}
			else
			{
				text = "SELECT * FROM ShopNum1_Video  WHERE 1=1 ";
			}
			if (isrecommend != "-1")
			{
				text = text + " AND IsRecommend=" + isrecommend;
			}
			text += "  ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetVideoList(int showcount, string isrecommend, string SubstationID)
		{
			string text = string.Empty;
			if (showcount > 0)
			{
				text = "SELECT top " + showcount + "  *  FROM ShopNum1_Video  where 1=1 ";
			}
			else
			{
				text = "SELECT * FROM ShopNum1_Video  WHERE 1=1 ";
			}
			if (isrecommend != "-1")
			{
				text = text + " AND IsRecommend=" + isrecommend;
			}
			if (SubstationID != "-1")
			{
				text = text + " AND  SubstationID='" + SubstationID + "' ";
			}
			text += "  ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetVideoList(int showcount, string isrecommend, int CategoryID)
		{
			string text = string.Empty;
			if (showcount > 0)
			{
				text = "SELECT top " + showcount + "  *  FROM ShopNum1_Video  where 1=1 ";
			}
			else
			{
				text = "SELECT * FROM ShopNum1_Video  WHERE 1=1 ";
			}
			if (isrecommend != "-1")
			{
				text = text + " AND IsRecommend=" + isrecommend;
			}
			if (CategoryID != -1)
			{
				text = text + " AND  CategoryID=" + CategoryID;
			}
			text += "  ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetVideoHotList(int showcount)
		{
			string text = string.Empty;
			if (showcount > 0)
			{
				text = "SELECT top " + showcount + "  *  FROM ShopNum1_Video  where 1=1 ";
			}
			else
			{
				text = "SELECT * FROM ShopNum1_Video  WHERE 1=1 ";
			}
			text += "  ORDER BY BroadcastCount DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetVideoHotList(int showcount, string SubstationID)
		{
			string text = string.Empty;
			if (showcount > 0)
			{
				text = "SELECT top " + showcount + "  *  FROM ShopNum1_Video  where 1=1 ";
			}
			else
			{
				text = "SELECT * FROM ShopNum1_Video  WHERE 1=1 ";
			}
			if (SubstationID != "-1")
			{
				text = text + "  AND   SubstationID='" + SubstationID + "'     ";
			}
			text += "  ORDER BY BroadcastCount DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetVideoDetail(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT   *  FROM ShopNum1_Video  where [Guid]='" + guid + "' ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetVideoRelativelyList(string guid, int showcount)
		{
			string text = string.Empty;
			if (showcount > 0)
			{
				text = "SELECT top " + showcount + "  *  FROM ShopNum1_Video  where 1=1 ";
			}
			else
			{
				text = "SELECT * FROM ShopNum1_Video  WHERE 1=1 ";
			}
			text = text + " AND CategoryID =(SELECT CategoryID FROM ShopNum1_Video WHERE Guid='" + guid + "')";
			text = text + " AND  Guid not in('" + guid + "')";
			text += "  ORDER BY BroadcastCount DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchVideoList(string resultnum, string pagesize, string currentpage, string strType, string strCategory)
		{
			string text = string.Empty;
			string text2 = "ModifyTime";
			string text3 = "desc";
			if (strType != null)
			{
				if (!(strType == "0"))
				{
					if (strType == "2")
					{
						text2 = "BroadcastCount";
						text3 = "Desc";
					}
				}
				else
				{
					text = " And isRecommend = 1";
				}
			}
			if (strCategory != "")
			{
				text = text + " And CategoryID='" + strCategory + "'";
			}
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "Title,GuId,ImgAdd,BroadcastCount,CategoryID";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Video";
			array[4] = "@condition";
			array2[4] = text;
			array[5] = "@ordercolumn";
			array2[5] = text2;
			array[6] = "@sortvalue";
			array2[6] = text3;
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable SearchVideoList(string resultnum, string pagesize, string currentpage, string strType, string strCategory, string SubstationID)
		{
			string text = string.Empty;
			string text2 = "ModifyTime";
			string text3 = "desc";
			if (strType != null)
			{
				if (!(strType == "0"))
				{
					if (strType == "2")
					{
						text2 = "BroadcastCount";
						text3 = "Desc";
					}
				}
				else
				{
					text = " And isRecommend = 1";
				}
			}
			if (strCategory != "")
			{
				text = text + " And CategoryID='" + strCategory + "'";
			}
			text = text + "    and   SubstationID='" + SubstationID + "'    ";
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "Title,GuId,ImgAdd,BroadcastCount,CategoryID";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Video";
			array[4] = "@condition";
			array2[4] = text;
			array[5] = "@ordercolumn";
			array2[5] = text2;
			array[6] = "@sortvalue";
			array2[6] = text3;
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable SearchVideoList(string keyword, string string_0)
		{
			string text = string.Empty;
			text = "SELECT  *  FROM ShopNum1_Video  where 1=1 ";
			if (Operator.FormatToEmpty(keyword) != string.Empty)
			{
				text = text + " AND Title Like '%" + Operator.FilterString(keyword) + "%'";
			}
			if (Operator.FormatToEmpty(string_0) != string.Empty && string_0 != "-1")
			{
				text = text + " AND CategoryID = " + Operator.FilterString(string_0);
			}
			text += "  ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int AddVideoCout(string keyname, string videoguid)
		{
			string text = string.Concat(new string[]
			{
				"update dbo.ShopNum1_Video set ",
				keyname,
				"=",
				keyname,
				"+1 where guid='",
				videoguid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(text.ToString());
		}
		public int GetVideoComment(string VideoGuid)
		{
			int result;
			try
			{
				string text = string.Empty;
				text = "    SELECT COUNT(Guid)  FROM ShopNum1_VideoComment       ";
				text = text + "   WHERE VideoGuid='" + VideoGuid + "'    AND   IsAudit=1    ";
				DataTable dataTable = DatabaseExcetue.ReturnDataTable(text);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
					{
						result = Convert.ToInt32(dataTable.Rows[0][0].ToString());
					}
					else
					{
						result = 0;
					}
				}
				else
				{
					result = 0;
				}
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
	}
}
