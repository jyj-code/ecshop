using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_PageAddress_Action : IShopNum1_PageAddress_Action
	{
		public DataTable GetArticlePageAddress(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
			stringBuilder.Append(" SELECT @id = B.ID FROM ShopNum1_Article AS A,ShopNum1_ArticleCategory AS B where A.[Guid]='" + guid + "' AND A.ArticleCategoryID=B.ID");
			stringBuilder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ArticleCategory WHERE ID = @id");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_ArticleCategory WHERE ID = @fatherid) > 0) ");
			stringBuilder.Append(" BEGIN ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ArticleCategory WHERE ID = @fatherid");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" END");
			stringBuilder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetArticleCategoryPageAddress(string ArticleCategoryID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
			stringBuilder.Append(" SET @id=" + ArticleCategoryID);
			stringBuilder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ArticleCategory WHERE ID = @id");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_ArticleCategory WHERE ID = @fatherid) > 0) ");
			stringBuilder.Append(" BEGIN ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ArticleCategory WHERE ID = @fatherid");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" END");
			stringBuilder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetProductCategoryPageAddress(string ProductCategoryID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
			stringBuilder.Append(" SET @id=" + ProductCategoryID);
			stringBuilder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ProductCategory WHERE ID = @id");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_ProductCategory WHERE ID = @fatherid) > 0) ");
			stringBuilder.Append(" BEGIN ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ProductCategory WHERE ID = @fatherid");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" END");
			stringBuilder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetProductPageAddress(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
			stringBuilder.Append(" SELECT @id = B.ID FROM ShopNum1_Product AS A,ShopNum1_ProductCategory AS B WHERE A.[Guid]='" + guid + "' AND A.ProductCategoryID=B.ID");
			stringBuilder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ProductCategory WHERE ID = @id");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_ProductCategory WHERE ID = @fatherid) > 0) ");
			stringBuilder.Append(" BEGIN ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ProductCategory WHERE ID = @fatherid");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" END");
			stringBuilder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetHelpCategoryPageAddress(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" DECLARE @HelpTypeGuid Uniqueidentifier");
			stringBuilder.Append(" SELECT @HelpTypeGuid=HelpTypeGuid FROM ShopNum1_Help WHERE [guid]='" + guid + "'");
			stringBuilder.Append(" SELECT [guid],[name] FROM ShopNum1_HelpType WHERE [guid]=@HelpTypeGuid");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetVideoPageAddress(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
			stringBuilder.Append(" SELECT @id = B.ID FROM ShopNum1_Video AS A,ShopNum1_VideoCategory AS B WHERE A.[Guid]='" + guid + "' AND A.CategoryID=B.ID");
			stringBuilder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_VideoCategory WHERE ID = @id");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_VideoCategory WHERE ID = @fatherid) > 0) ");
			stringBuilder.Append(" BEGIN ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_VideoCategory WHERE ID = @fatherid");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" END");
			stringBuilder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetVideoCategoryPageAddress(string categoryID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
			stringBuilder.Append(" SET @id=" + categoryID);
			stringBuilder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_VideoCategory WHERE ID = @id");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_VideoCategory WHERE ID = @fatherid) > 0) ");
			stringBuilder.Append(" BEGIN ");
			stringBuilder.Append(" SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_VideoCategory WHERE ID = @fatherid");
			stringBuilder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
			stringBuilder.Append(" END");
			stringBuilder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
	}
}
