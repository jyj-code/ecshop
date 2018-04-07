using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Article_Action : IShopNum1_Article_Action
	{
		public int Add(ShopNum1_Article article, List<string> strRelateArticleList, List<string> strRelateProductList)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Article(  Guid ,  Title ,  ArticleCategoryID ,  Publisher ,  Source ,  Content ,  Keywords ,  Description ,  IsShow ,  IsAllowComment ,  OrderID ,  IsHot ,  IsRecommend ,  IsHead ,  CreateUser ,  CreateTime ,  ModifyUser ,  ModifyTime ,  IsDeleted , ClickCount , SubstationID , IsAudit  ) VALUES (  '",
				article.Guid,
				"',  '",
				Operator.FilterString(article.Title),
				"',  ",
				article.ArticleCategoryID,
				",  '",
				Operator.FilterString(article.Publisher),
				"',  '",
				Operator.FilterString(article.Source),
				"',  '",
				article.Content,
				"',  '",
				Operator.FilterString(article.Keywords),
				"',  '",
				Operator.FilterString(article.Description),
				"',  ",
				article.IsShow,
				",  ",
				article.IsAllowComment,
				",  ",
				article.OrderID,
				",  ",
				article.IsHot,
				",  ",
				article.IsRecommend,
				",  ",
				article.IsHead,
				",  '",
				Operator.FilterString(article.CreateUser),
				"', '",
				article.CreateTime,
				"',  '",
				Operator.FilterString(article.ModifyUser),
				"' , '",
				article.ModifyTime,
				"',  ",
				article.IsDeleted,
				" , ",
				article.ClickCount,
				" , '",
				article.SubstationID,
				"' , ",
				article.IsAudit,
				" )"
			});
			list.Add(item);
			for (int i = 0; i < strRelateArticleList.Count; i++)
			{
				string[] array = strRelateArticleList[i].Split(new char[]
				{
					';'
				});
				string item2 = string.Concat(new object[]
				{
					"INSERT INTO ShopNum1_RelatedArticle( ArticleGuid, IsBoth, SubArticleGuid, CreateUser, CreateTime  ) VALUES (  '",
					article.Guid,
					"',  '",
					array[1],
					"',  '",
					array[0],
					"',  '",
					article.CreateUser,
					"', '",
					article.CreateTime,
					"' )"
				});
				list.Add(item2);
			}
			for (int j = 0; j < strRelateProductList.Count; j++)
			{
				string item3 = string.Concat(new object[]
				{
					"INSERT INTO ShopNum1_ProductArticle( ArticleGuid, ProductGuid, CreateUser, CreateTime  ) VALUES (  '",
					article.Guid,
					"',  '",
					strRelateProductList[j].ToString(),
					"',  '",
					article.CreateUser,
					"', '",
					article.CreateTime,
					"' )"
				});
				list.Add(item3);
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
		public int Delete(string guids)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = "delete from ShopNum1_RelatedArticle  WHERE ArticleGuid IN (" + guids + ") ";
			list.Add(item);
			item = "delete from ShopNum1_Article  WHERE Guid IN (" + guids + ") ";
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
		public DataTable Search(string title, string publisher, int articlecategoryid, string startdate, string enddate, int isshow, int ishot, int isrecommand, int ishead, int isallowcomment, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT    Guid ,  A.Title ,  B.Name ,  A.Publisher ,  A.Source ,  A.Content ,  A.Keywords ,  A.Description ,  A.IsShow ,  A.IsAllowComment ,  A.OrderID ,  A.IsHot ,  A.IsRecommend ,  A.IsHead ,  A.CreateUser ,  A.CreateTime ,  A.ModifyUser ,  A.ModifyTime ,  A.IsDeleted  FROM ShopNum1_Article A LEFT JOIN ShopNum1_ArticleCategory B on A.ArticleCategoryID=B.ID  Where 0=0";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(publisher) != string.Empty)
			{
				text = text + " AND A.Publisher LIKE '%" + Operator.FilterString(publisher) + "%'";
			}
			if (articlecategoryid != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.ArticleCategoryID =",
					articlecategoryid,
					" "
				});
			}
			if (Operator.FormatToEmpty(startdate) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(startdate) + "' ";
			}
			if (Operator.FormatToEmpty(enddate) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(enddate) + "' ";
			}
			if (isshow == 0 || isshow == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsShow =",
					isshow,
					" "
				});
			}
			if (ishot == 0 || ishot == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsHot =",
					ishot,
					" "
				});
			}
			if (isrecommand == 0 || isrecommand == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsRecommend =",
					isrecommand,
					" "
				});
			}
			if (ishead == 0 || ishead == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsHead =",
					ishead,
					" "
				});
			}
			if (isallowcomment == 0 || isallowcomment == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsAllowComment =",
					isallowcomment,
					" "
				});
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
		public DataTable Search(string title, string publisher, int articlecategoryid, string startdate, string enddate, int isshow, int ishot, int isrecommand, int ishead, int isallowcomment, int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT    Guid ,  A.Title ,  B.Name ,  A.Publisher ,  A.Source ,  A.Content ,  A.Keywords ,  A.Description ,  A.IsShow ,  A.IsAllowComment ,  A.OrderID ,  A.IsHot ,  A.IsRecommend ,  A.IsHead ,  A.CreateUser ,  A.CreateTime ,  A.ModifyUser ,  A.ModifyTime ,  A.SubstationID ,  A.IsDeleted  FROM ShopNum1_Article A LEFT JOIN ShopNum1_ArticleCategory B on A.ArticleCategoryID=B.ID  Where 0=0";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(publisher) != string.Empty)
			{
				text = text + " AND A.Publisher LIKE '%" + Operator.FilterString(publisher) + "%'";
			}
			if (articlecategoryid != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.ArticleCategoryID =",
					articlecategoryid,
					" "
				});
			}
			if (Operator.FormatToEmpty(startdate) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(startdate) + "' ";
			}
			if (Operator.FormatToEmpty(enddate) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(enddate) + "' ";
			}
			if (isshow == 0 || isshow == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsShow =",
					isshow,
					" "
				});
			}
			if (ishot == 0 || ishot == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsHot =",
					ishot,
					" "
				});
			}
			if (isrecommand == 0 || isrecommand == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsRecommend =",
					isrecommand,
					" "
				});
			}
			if (ishead == 0 || ishead == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsHead =",
					ishead,
					" "
				});
			}
			if (isallowcomment == 0 || isallowcomment == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsAllowComment =",
					isallowcomment,
					" "
				});
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
				text = text + " AND A.SubstationID ='" + SubstationID + "' ";
			}
			text += " ORDER BY A.OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(ShopNum1_Article article, List<string> strRelateArticleList, List<string> strRelateProductList)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Article SET  Title='",
				Operator.FilterString(article.Title),
				"', ArticleCategoryID='",
				article.ArticleCategoryID,
				"', Publisher='",
				Operator.FilterString(article.Publisher),
				"', Source='",
				Operator.FilterString(article.Source),
				"', Content='",
				article.Content,
				"', Keywords='",
				Operator.FilterString(article.Keywords),
				"', Description='",
				Operator.FilterString(article.Description),
				"', IsShow=",
				article.IsShow,
				", IsAllowComment=",
				article.IsAllowComment,
				", OrderID=",
				article.OrderID,
				", IsHot=",
				article.IsHot,
				", IsRecommend=",
				article.IsRecommend,
				", IsHead=",
				article.IsHead,
				", ModifyUser='",
				article.ModifyUser,
				"', ModifyTime='",
				article.ModifyTime,
				"', IsDeleted='",
				article.IsDeleted,
				"'WHERE Guid='",
				article.Guid,
				"'"
			});
			list.Add(item);
			item = "Delete from ShopNum1_RelatedArticle where ArticleGuid='" + article.Guid + "'";
			list.Add(item);
			for (int i = 0; i < strRelateArticleList.Count; i++)
			{
				string[] array = strRelateArticleList[i].Split(new char[]
				{
					';'
				});
				string item2 = string.Concat(new object[]
				{
					"INSERT INTO ShopNum1_RelatedArticle( ArticleGuid, IsBoth, SubArticleGuid, CreateUser, CreateTime  ) VALUES (  '",
					article.Guid,
					"',  '",
					array[1],
					"',  '",
					array[0],
					"',  '",
					article.ModifyUser,
					"', '",
					article.ModifyTime,
					"' )"
				});
				list.Add(item2);
			}
			for (int i = 0; i < strRelateProductList.Count; i++)
			{
				string[] array = strRelateProductList[i].Split(new char[]
				{
					';'
				});
				string item2 = string.Concat(new object[]
				{
					"INSERT INTO ShopNum1_ProductArticle( ArticleGuid, ProductGuid,CreateUser, CreateTime  ) VALUES (  '",
					article.Guid,
					"',  '",
					new Guid(array[0]),
					"',  '",
					article.ModifyUser,
					"', '",
					article.ModifyTime,
					"' )"
				});
				list.Add(item2);
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
		public DataTable GetEditInfo(string guid)
		{
			string text = "SELECT  Guid ,  Title ,  ArticleCategoryID ,  Publisher ,  Source ,  Content ,  Keywords ,  Description ,  IsShow ,  IsAllowComment ,  OrderID ,  IsHot ,  IsRecommend ,  IsHead ,  CreateUser ,  CreateTime ,  ModifyUser ,  ModifyTime ,  ClickCount ,  IsDeleted  FROM ShopNum1_Article  Where 0=0 ";
			if (Operator.FormatToEmpty(guid) != string.Empty)
			{
				text = text + " AND  Guid= " + guid + " ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetRelatedArticleInfo(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT  ArticleGuid ,  IsBoth ,  SubArticleGuid ,  CreateUser ,  CreateTime  FROM ShopNum1_RelatedArticle  Where ArticleGuid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetRelatedProductInfo(string guid)
		{
			string strSql = "SELECT  ArticleGuid ,  ProductGuid ,  CreateUser ,  CreateTime  FROM ShopNum1_ProductArticle  Where ArticleGuid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetArticleCategoryInfo(int isDeleted)
		{
			string text = "SELECT  ID as Code,  Name  as Name FROM ShopNum1_ArticleCategory  where 1=1";
			if (isDeleted == 0 || isDeleted == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND IsDeleted =",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetProductCategoryInfo(int isDeleted)
		{
			string text = "SELECT  ID as Code,  Name  as Name FROM dbo.ShopNum1_ProductCategory  where 1=1";
			if (isDeleted == 0 || isDeleted == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND IsDeleted =",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string Title, int articleCategoryID)
		{
			string text = "SELECT  Guid ,  Title ,  ArticleCategoryID   FROM ShopNum1_Article  Where IsDeleted = 0 ";
			if (Operator.FormatToEmpty(Title) != string.Empty)
			{
				text = text + " AND Title='" + Operator.FilterString(Title) + "'";
			}
			if (articleCategoryID != -1)
			{
				text = text + " AND ArticleCategoryID=" + articleCategoryID;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByArticleCategoryID(int articleCategoryID)
		{
			string text = "SELECT  Guid ,  Title ,  ArticleCategoryID   FROM ShopNum1_Article  Where IsDeleted = 0 ";
			if (articleCategoryID != -1)
			{
				text = text + " AND ArticleCategoryID=" + articleCategoryID;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByArticleCategoryID(int articleCategoryID, int showCount)
		{
			string text = "SELECT  TOP " + showCount + " Guid ,  Title ,  ArticleCategoryID   FROM ShopNum1_Article  Where IsDeleted = 0 ";
			if (articleCategoryID != -1)
			{
				text = text + " AND ArticleCategoryID=" + articleCategoryID;
			}
			text += " ORDER BY OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetNameByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid,Title FROM ShopNum1_Article  WHERE Guid ='" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0][1].ToString();
		}
		public DataTable SearchArticleList(string guid, int articleCategoryID)
		{
			string text = string.Empty;
			if (articleCategoryID != -1)
			{
				text += " Create TABLE #Temp(ID INT) ";
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" INSERT #Temp SELECT ID  FROM ShopNum1_ArticleCategory WHERE FatherID=",
					articleCategoryID,
					" OR ID=",
					articleCategoryID,
					" "
				});
				obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" INSERT #Temp SELECT ID  FROM ShopNum1_ArticleCategory WHERE FatherID IN (SELECT ID FROM ShopNum1_ArticleCategory WHERE FatherID=",
					articleCategoryID,
					") "
				});
			}
			text += "select  Title,  Publisher,  Keywords,  CreateTime,  OrderID,  Guid  From ShopNum1_Article  where 1=1";
			if (Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " AND Guid='" + guid + "'";
			}
			if (articleCategoryID != -1)
			{
				text += " AND ArticleCategoryID IN(SELECT * FROM  #Temp) ";
			}
			text += " ORDER BY OrderID DESC";
			if (articleCategoryID != -1)
			{
				text += " DROP TABLE #Temp";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchArticleList(string guid, int articleCategoryID, int count)
		{
			string text = string.Empty;
			object obj;
			if (articleCategoryID != -1)
			{
				text += " Create TABLE #Temp(ID INT) ";
				obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" INSERT #Temp SELECT ID  FROM ShopNum1_ArticleCategory WHERE FatherID=",
					articleCategoryID,
					" OR ID=",
					articleCategoryID,
					" "
				});
				obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" INSERT #Temp SELECT ID  FROM ShopNum1_ArticleCategory WHERE FatherID IN (SELECT ID FROM ShopNum1_ArticleCategory WHERE FatherID=",
					articleCategoryID,
					") "
				});
			}
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"select top ",
				count,
				" Title,  Publisher,  Keywords,  CreateTime,  OrderID,  Guid  From ShopNum1_Article  where 1=1"
			});
			if (Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " AND Guid='" + guid + "'";
			}
			if (articleCategoryID != -1)
			{
				text += " AND ArticleCategoryID IN(SELECT * FROM  #Temp) ";
			}
			text += " ORDER BY OrderID DESC";
			if (articleCategoryID != -1)
			{
				text += " DROP TABLE #Temp";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchNewArticle(int count)
		{
			string strSql = string.Empty;
			if (count > 0)
			{
				strSql = "SELECT  top  " + count + " Guid ,  A.Title ,  B.Name ,  A.IsDeleted  FROM ShopNum1_Article A LEFT JOIN ShopNum1_ArticleCategory B on A.ArticleCategoryID=B.ID  Where 0=0 AND A.IsShow = 1 AND A.IsDeleted=0  ORDER BY A.CreateTime Desc";
			}
			else
			{
				strSql = "SELECT   Guid ,  A.Title ,  B.Name ,  A.IsDeleted  FROM ShopNum1_Article A LEFT JOIN ShopNum1_ArticleCategory B on A.ArticleCategoryID=B.ID  Where 0=0 AND A.IsShow = 1 AND A.IsDeleted=0  ORDER BY A.CreateTime Desc";
			}
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchNewArticle(int count, string SubstationID)
		{
			string strSql = string.Empty;
			if (count > 0)
			{
				strSql = string.Concat(new object[]
				{
					"SELECT  top  ",
					count,
					" Guid ,  A.Title ,  B.Name ,  A.IsDeleted  FROM ShopNum1_Article A LEFT JOIN ShopNum1_ArticleCategory B on A.ArticleCategoryID=B.ID  Where 0=0 AND A.IsShow = 1 AND A.IsDeleted=0 AND A.SubstationID='",
					SubstationID,
					"'  ORDER BY A.CreateTime Desc"
				});
			}
			else
			{
				strSql = "SELECT   Guid ,  A.Title ,  B.Name ,  A.IsDeleted  FROM ShopNum1_Article A LEFT JOIN ShopNum1_ArticleCategory B on A.ArticleCategoryID=B.ID  Where 0=0 AND A.IsShow = 1 AND A.IsDeleted=0 AND A.SubstationID='" + SubstationID + "'  ORDER BY A.CreateTime Desc";
			}
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchArticleRelatedArticle(string guid, int count)
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
			text = text + " Guid,Title FROM ShopNum1_Article AS A,(SELECT ArticleGuid,SubArticleGuid FROM ShopNum1_RelatedArticle WHERE ArticleGuid='" + guid + "' ) AS B WHERE A.Guid=B.SubArticleGuid";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchArticle(string title)
		{
			string text = string.Empty;
			text = "SELECT   Guid ,  Title ,  Publisher ,  CreateTime ,  IsDeleted  FROM ShopNum1_Article Where 0=0 AND IsShow = 1 AND IsDeleted=0 ";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			text += " ORDER BY CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetArticleMeto(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT  Title ,  Keywords ,  Description   FROM ShopNum1_Article  Where Guid='" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetArticleIsHotorIsRecommend(string showCount, string categoryID, string type)
		{
			string text = string.Empty;
			if (string.IsNullOrEmpty(showCount))
			{
				text = "SELECT  Top 10";
			}
			else
			{
				text = "SELECT  top " + showCount;
			}
			text = text + "  Guid, Title ,  Keywords ,  Description   FROM ShopNum1_Article  Where ArticleCategoryID=" + categoryID;
			if (type == "Ishot")
			{
				text += " and  IsHot=1 ";
			}
			else
			{
				text += " and  IsRecommend=1 ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetArticleIsHotorIsRecommend(string showCount, string categoryID, string type, string SubstationID)
		{
			string text = string.Empty;
			if (string.IsNullOrEmpty(showCount))
			{
				text = "SELECT  Top 10";
			}
			else
			{
				text = "SELECT  top " + showCount;
			}
			text = text + "  Guid, Title ,  Keywords ,  Description   FROM ShopNum1_Article  Where ArticleCategoryID=" + categoryID;
			if (type == "Ishot")
			{
				text += " and  IsHot=1 ";
			}
			else
			{
				text += " and  IsRecommend=1 ";
			}
			if (SubstationID != "-1")
			{
				text = text + " and   SubstationID='" + SubstationID + "' ";
			}
			File.AppendAllText(HttpContext.Current.Server.MapPath("~/log/logArticle.txt"), text);
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByCategoryIDFrist(int articleCategoryID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT  TOP 1 Guid,Title,Description FROM ShopNum1_Article where ArticleCategoryID = " + articleCategoryID);
			stringBuilder.Append(" ORDER BY CreateTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchByCategoryIDFrist(int articleCategoryID, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT  TOP 1 Guid,Title,Description FROM ShopNum1_Article where ArticleCategoryID = " + articleCategoryID);
			stringBuilder.Append("   AND   SubstationID='" + SubstationID + "'   ");
			stringBuilder.Append(" ORDER BY CreateTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchByCategoryIDOther(int articleCategoryID, string guid, string showCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT TOP " + showCount + " ShopNum1_Article.Guid,ShopNum1_Article.CreateTime,ShopNum1_Article.Title,ShopNum1_ArticleCategory.ID,");
			stringBuilder.Append("ShopNum1_Article.Description,ShopNum1_ArticleCategory.Name FROM ShopNum1_Article,");
			stringBuilder.Append("ShopNum1_ArticleCategory where ShopNum1_ArticleCategory.ID = ShopNum1_Article.ArticleCategoryID");
			stringBuilder.Append(" and ShopNum1_Article.ArticleCategoryID = " + articleCategoryID);
			stringBuilder.Append(" and guid not in ('" + guid + "') ORDER BY ShopNum1_Article.CreateTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchByCategoryIDOther(int articleCategoryID, string guid, string showCount, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT TOP " + showCount + " ShopNum1_Article.Guid,ShopNum1_Article.CreateTime,ShopNum1_Article.Title,ShopNum1_ArticleCategory.ID,");
			stringBuilder.Append("ShopNum1_Article.Description,ShopNum1_ArticleCategory.Name FROM ShopNum1_Article,");
			stringBuilder.Append("ShopNum1_ArticleCategory where ShopNum1_ArticleCategory.ID = ShopNum1_Article.ArticleCategoryID");
			stringBuilder.Append(" and ShopNum1_Article.ArticleCategoryID = " + articleCategoryID);
			stringBuilder.Append(" and ShopNum1_Article.SubstationID ='" + SubstationID + "'");
			stringBuilder.Append(" and guid not in ('" + guid + "') ORDER BY ShopNum1_Article.CreateTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetChildCategory(string showcount, string fatherId)
		{
			string text = string.Empty;
			if (string.IsNullOrEmpty(showcount))
			{
				text = "SELECT  Top 10";
			}
			else
			{
				text = "SELECT  top " + showcount;
			}
			text = text + "  ID, Name  FROM ShopNum1_ArticleCategory  Where FatherID=" + fatherId;
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetArticleOnAndNext(string guid, string onArticleName, string nextArticleName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @modifyTime datetime ");
			stringBuilder.Append("SELECT @modifyTime = ModifyTime FROM ShopNum1_Article ");
			stringBuilder.Append("WHERE Guid = '" + guid + "' ");
			stringBuilder.Append("SELECT * FROM(");
			stringBuilder.Append("SELECT TOP 1 Guid,Title,'" + onArticleName + "' as [Name] FROM ShopNum1_Article ");
			stringBuilder.Append("WHERE ModifyTime < @modifyTime ");
			stringBuilder.Append("ORDER BY ModifyTime DESC");
			stringBuilder.Append(") as a ");
			stringBuilder.Append("UNION ");
			stringBuilder.Append("SELECT * FROM(");
			stringBuilder.Append("SELECT TOP 1 Guid,Title,'" + nextArticleName + "' as [Name] FROM ShopNum1_Article ");
			stringBuilder.Append("WHERE ModifyTime > @modifyTime ");
			stringBuilder.Append("ORDER BY ModifyTime ASC ");
			stringBuilder.Append(") as b");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetTitleByID(string ID, string type, string ShowCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top (" + ShowCount + ") ");
			stringBuilder.Append(" Title,[Guid] ");
			stringBuilder.Append("FROM ShopNum1_Article ");
			stringBuilder.Append("WHERE ArticleCategoryID in " + ID + " ");
			if (type == "IsHead")
			{
				stringBuilder.Append(" AND IsHead = 1 ");
			}
			else if (type == "IsHot")
			{
				stringBuilder.Append(" AND IsHot = 1 ");
			}
			else if (type == "IsRecommend")
			{
				stringBuilder.Append(" AND IsRecommend = 1");
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchArticle(string articlename, string articlecode, string pageindex, string pagesize, string isreturcount)
		{
			string text = string.Empty;
			if (!string.IsNullOrEmpty(articlename) && articlename != "-1")
			{
				text = text + " AND A.title like '%" + articlename + "%' ";
			}
			if (!string.IsNullOrEmpty(articlecode) && articlecode != "-1")
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" AND A.ArticleCategoryID  in(select id from ShopNum1_ArticleCategory where fatherid='",
					articlecode,
					"' union all select ",
					articlecode,
					" as id) "
				});
			}
			text += " AND A.IsShow=1 AND A.IsAudit=1 AND A.IsDeleted=0 ";
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@perpagenum";
			array2[0] = pagesize;
			array[1] = "@current_page";
			array2[1] = pageindex;
			array[2] = "@columnnames";
			array2[2] = " A.Guid,A.ClickCount,A.Title,A.Description,A.Publisher,A.Source,A.Content,A.Keywords,A.CreateTime,B.Name ";
			array[3] = "@searchname";
			array2[3] = text;
			array[4] = "@isreturcount";
			array2[4] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonArticles", array, array2);
		}
		public DataTable SearchArticle(string articlename, string articlecode, string pageindex, string pagesize, string isreturcount, string SubstationID)
		{
			string text = string.Empty;
			if (!string.IsNullOrEmpty(articlename) && articlename != "-1")
			{
				text = text + " AND A.title like '%" + articlename + "%' ";
			}
			if (!string.IsNullOrEmpty(articlecode) && articlecode != "-1")
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" AND A.ArticleCategoryID  in(select id from ShopNum1_ArticleCategory where fatherid='",
					articlecode,
					"' union all select ",
					articlecode,
					" as id) "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + " AND A.SubstationID ='" + SubstationID + "' ";
			}
			text += " AND A.IsShow=1 AND A.IsAudit=1 AND A.IsDeleted=0 ";
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@perpagenum";
			array2[0] = pagesize;
			array[1] = "@current_page";
			array2[1] = pageindex;
			array[2] = "@columnnames";
			array2[2] = " A.Guid,A.ClickCount,A.Title,A.Description,A.Publisher,A.Source,A.Content,A.Keywords,A.CreateTime,B.Name ";
			array[3] = "@searchname";
			array2[3] = text;
			array[4] = "@isreturcount";
			array2[4] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonArticles", array, array2);
		}
		public int UpdateClickCount(string guid)
		{
			string strSql = string.Empty;
			strSql = " UPDATE ShopNum1_Article SET ClickCount=ClickCount+1 WHERE GUID='" + guid + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetAnnouncementByTypeName(string Name, int int_0)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"    SELECT  TOP   ",
				int_0,
				"    A.* FROM ShopNum1_Announcement AS A LEFT JOIN ShopNum1_AnnouncementCategory AS B      "
			});
			text += "    ON A.AnnouncementCategoryID =B.ID     ";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"    WHERE B.Name='",
				Name,
				"'   AND   A.CreateTime <='",
				DateTime.Now.ToString(),
				"'         ORDER  BY   A.CreateTime  DESC    "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
