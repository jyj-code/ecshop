using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_ProductComment_Action : IShop_ProductComment_Action
	{
		public DataTable CommentListStatReport(string shopid, string guid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@guid";
			array2[1] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CommentListStatReport", array, array2);
		}
		public int UpdateCommentType(string strMemloingId, string strGuid, string strCommentType, string strComment)
		{
			string strSql = string.Concat(new string[]
			{
				"update shopnum1_shop_productcomment set continuecomment='",
				strComment,
				"',continuetime='",
				DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
				"',CommentType='",
				strCommentType,
				"' where memloginId='",
				strMemloingId,
				"' And GuId='",
				strGuid,
				"';"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable CommentList(string memberid, string commenttype, string guid)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@memberid";
			array2[0] = memberid;
			array[1] = "@commenttype";
			array2[1] = commenttype;
			array[2] = "@guid";
			array2[2] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CommentList", array, array2);
		}
		public DataSet ProductCommentList(string productguid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@productguid";
			array2[0] = productguid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_ProductCommentList", array, array2);
		}
		public DataSet ProductCommentListByGuidAndMemLoginID(string productguid, string memloginid, string strType)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@productguid";
			array2[0] = productguid;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			array[2] = "@type";
			array2[2] = strType;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_ProductCommentListShow", array, array2);
		}
		public int ReplyComment(string guid, string reply)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@reply";
			array2[1] = reply;
			return DatabaseExcetue.RunProcedure("Pro_Shop_ReplyComment", array, array2);
		}
		public DataTable ShopCommentInfo(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ShopCommentInfo", array, array2);
		}
		public DataTable ShopComment(string type, string timetype, string shopid)
		{
			string text = string.Empty;
			text = "select count(Guid) from ShopNum1_Shop_ProductComment where ShopID='" + shopid + "' AND IsAudit=1 ";
			if (type != string.Empty)
			{
				text = text + " and CommentType=" + type;
			}
			if (timetype != string.Empty && timetype != null)
			{
				if (!(timetype == "1"))
				{
					if (!(timetype == "2"))
					{
						if (!(timetype == "3"))
						{
							if (timetype == "4")
							{
								object obj = text;
								text = string.Concat(new object[]
								{
									obj,
									" and CommentTime<'",
									DateTime.Now.AddMonths(-6),
									"'"
								});
							}
						}
						else
						{
							object obj2 = text;
							text = string.Concat(new object[]
							{
								obj2,
								" and CommentTime>='",
								DateTime.Now.AddMonths(-6),
								"'"
							});
						}
					}
					else
					{
						object obj3 = text;
						text = string.Concat(new object[]
						{
							obj3,
							" and CommentTime>='",
							DateTime.Now.AddMonths(-1),
							"'"
						});
					}
				}
				else
				{
					object obj4 = text;
					text = string.Concat(new object[]
					{
						obj4,
						" and CommentTime>='",
						DateTime.Now.AddDays(-7.0),
						"'"
					});
				}
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable ShopComment(string type, string shopid)
		{
			string text = string.Empty;
			text = "select  a.CommentType, a.Comment, a.ProductName, b.BuyPrice, a.MemLoginID, a.CommentTime  from ShopNum1_Shop_ProductComment as a , ShopNum1_OrderProduct as b  where a.ShopID='" + shopid + "' and a.ProductGuid=b.ProductGuid and  a.OrderGuid=b.OrderInfoGuid and a.IsAudit=1";
			if (type != string.Empty)
			{
				text = text + " and a.CommentType=" + type;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetShopIDByName(string name)
		{
			string strSql = string.Empty;
			strSql = " select ShopID from ShopNum1_ShopInfo where MemLoginID='" + name + "' and isaudit=1";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataSet ShopCommentNew(string shopid, string type, string ordertype, string sort, string perpagenum, string current_page, string isreturcount)
		{
			string text = string.Empty;
			if (type == "0")
			{
				text = " AND A.continuecomment!='' and A.isaudit=1";
			}
			else if (type != string.Empty)
			{
				text = " AND A.CommentType='" + type + "' and A.isaudit=1";
			}
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@columnnames";
			array2[1] = " a.Comment,a.CommentType,a.ProductName,a.MemLoginID,a.CommentTime,a.productprice as BuyPrice,A.isaudit,a.continuecomment  ";
			array[2] = "@searchname";
			array2[2] = text;
			array[3] = "@ordertype";
			array2[3] = ordertype;
			array[4] = "@sort";
			array2[4] = sort;
			array[5] = "@perpagenum";
			array2[5] = perpagenum;
			array[6] = "@current_page";
			array2[6] = current_page;
			array[7] = "@isreturcount";
			array2[7] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_ShopCommentNew", array, array2);
		}
		public DataTable GetShopCommentCount(string strMemloginId, string strIsShop)
		{
			string text = "select CommentTime,CommentType,isAudit from ShopNum1_Shop_ProductComment where 1=1 and isaudit=1 ";
			if (strIsShop == "0")
			{
				text = text + " and memloginid='" + strMemloginId + "'";
			}
			else
			{
				text = text + " and shoploginid='" + strMemloginId + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SelectShopComment(string strPageSize, string strCurrentPage, string strCondition, string strResultnum)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = strPageSize;
			array[1] = "@currentpage";
			array2[1] = strCurrentPage;
			array[2] = "@columns";
			array2[2] = "*";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Shop_ProductComment";
			array[4] = "@condition";
			array2[4] = strCondition;
			array[5] = "@ordercolumn";
			array2[5] = "commenttime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = strResultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public string GetGoodRate(string strShopLoginId, string strType)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@shoploginid";
			array2[0] = strShopLoginId;
			array[1] = "@type";
			array2[1] = strType;
			return DatabaseExcetue.ReturnProcedureString("Pro_shop_GetGoodRate", array, array2).ToString();
		}
		public DataTable SelectShopDetailComment(string strPageSize, string strCurrentPage, string strCondition, string strResultnum, string strShopID, string strType, string strProductGuID)
		{
			string text = string.Concat(new string[]
			{
				"select (select photo from shopnum1_member where memloginid=t.memloginid)pic,* from ShopNum1_Shop_ProductComment as t where shopid='",
				strShopID,
				"' and productguid='",
				strProductGuID,
				"' and isaudit=1"
			});
			if (strType == "2")
			{
				text = "select (select photo from shopnum1_member where memloginid=t.memloginid)pic,* from ShopNum1_Shop_ProductComment as t where shopid='" + strShopID + "' ";
				text = text + "and productguid in(select productguid from ShopNum1_Group_Product where id='" + strProductGuID + "') and isaudit=1 ";
			}
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = strPageSize;
			array[1] = "@currentpage";
			array2[1] = strCurrentPage;
			array[2] = "@columns";
			array2[2] = "*";
			array[3] = "@tablename";
			array2[3] = text;
			array[4] = "@condition";
			array2[4] = strCondition;
			array[5] = "@ordercolumn";
			array2[5] = "commenttime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = strResultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable GetCommentDetail(string strOrderguId, string strMemloingId)
		{
			string strSql = string.Concat(new string[]
			{
				"select shoploginid,productguid,commenttype,comment,commenttime,productname,(select originalimage from shopnum1_shop_product where guid=t.productguid)img from shopnum1_shop_productcomment as t \r\nwhere orderguid='",
				strOrderguId,
				"' and memloginId='",
				strMemloingId,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateContinueComment(string strOrderguId, string strMemloingId, string strComment, string strProductGuID)
		{
			string text = string.Concat(new string[]
			{
				"update shopnum1_shop_productcomment set continuecomment='",
				strComment,
				"',continuetime='",
				DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"),
				"' where orderguid='",
				strOrderguId,
				"' and memloginId='",
				strMemloingId,
				"' And ProductGuId='",
				strProductGuID,
				"';"
			});
			text = text + "update shopnum1_orderinfo set isbuycomment=2 where guid='" + strOrderguId + "';";
			return DatabaseExcetue.RunNonQuery(text);
		}
	}
}
