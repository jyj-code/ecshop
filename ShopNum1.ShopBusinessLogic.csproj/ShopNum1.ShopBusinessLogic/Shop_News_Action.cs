using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_News_Action : IShop_News_Action
	{
		public int AddNews(ShopNum1_Shop_News shop_News)
		{
			string[] array = new string[10];
			string[] array2 = new string[10];
			array[0] = "@title";
			array2[0] = shop_News.Title;
			array[1] = "@content";
			array2[1] = shop_News.Content;
			array[2] = "@isshow";
			array2[2] = shop_News.IsShow.ToString();
			array[3] = "@orderid";
			array2[3] = shop_News.OrderID.ToString();
			array[4] = "@createtime";
			array2[4] = shop_News.CreateTime.ToShortDateString();
			array[5] = "@seotitle";
			array2[5] = shop_News.SEOTitle;
			array[6] = "@keywords";
			array2[6] = shop_News.Keywords;
			array[7] = "@description";
			array2[7] = shop_News.Description;
			array[8] = "@newscategoryguid";
			array2[8] = shop_News.NewsCategoryGuid;
			array[9] = "@memloginid";
			array2[9] = shop_News.MemLoginID;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddNews", array, array2);
		}
		public DataTable GetNewsList(string memloginid, string isshow)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@isshow";
			array2[1] = isshow;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetNewsList", array, array2);
		}
		public DataTable SearchNewsList(string memloginid, string newscategoryguid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@newscategoryguid";
			array2[1] = newscategoryguid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchNewsList", array, array2);
		}
		public int UpdateNews(ShopNum1_Shop_News shop_News)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@guid";
			array2[0] = shop_News.Guid.ToString();
			array[1] = "@title";
			array2[1] = shop_News.Title;
			array[2] = "@content";
			array2[2] = shop_News.Content;
			array[3] = "@isshow";
			array2[3] = shop_News.IsShow.ToString();
			array[4] = "@seotitle";
			array2[4] = shop_News.SEOTitle;
			array[5] = "@keywords";
			array2[5] = shop_News.Keywords;
			array[6] = "@description";
			array2[6] = shop_News.Description;
			array[7] = "@newscategoryguid";
			array2[7] = shop_News.NewsCategoryGuid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateNews", array, array2);
		}
		public int DeleteNews(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteNews", array, array2);
		}
		public DataTable GetNews(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetNews", array, array2);
		}
		public DataTable GetNewsByGuidAndMemLoginID(string guid, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetNewsByGuidAndMemLoginID", array, array2);
		}
		public DataTable GetShopMetaByNewsguid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopMetaByNewsguid", array, array2);
		}
		public DataTable MetaGetNews(string memloginid, string guid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@guid";
			array2[1] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_MetaGetNews", array, array2);
		}
		public DataTable GetShopArticleDetailMeto(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopArticleDetailMeto", array, array2);
		}
		public DataTable GetCountNewsByMemLoginID(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCountNewsByMemLoginID", array, array2);
		}
		public DataSet SearchNewsListNew(string memloginid, string newscategoryguid, string ordertype, string sort, string perpagenum, string current_page, string isreturcount)
		{
			string empty = string.Empty;
			string[] array = new string[9];
			string[] array2 = new string[9];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@newscategoryguid";
			array2[1] = newscategoryguid;
			array[2] = "@columnnames";
			array2[2] = " A.Guid,A.ClickCount,A.Title,A.Content,A.OrderID,A.CreateTime,A.Keywords,A.Description,A.NewsCategoryGuid,A.MemLoginID,B.Name ";
			array[3] = "@searchname";
			array2[3] = empty;
			array[4] = "@ordertype";
			array2[4] = ordertype;
			array[5] = "@sort";
			array2[5] = sort;
			array[6] = "@perpagenum";
			array2[6] = perpagenum;
			array[7] = "@current_page";
			array2[7] = current_page;
			array[8] = "@isreturcount";
			array2[8] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchNewsListNew", array, array2);
		}
		public int UpdateClickCountByGuid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateNewsClickCountByGuid", array, array2);
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
			array2[3] = "ShopNum1_Shop_NewsComment";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "CommentTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable GetTitleByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "     SELECT  Title  FROM  ShopNum1_Shop_News  WHERE  Guid='" + guid + "'         ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int DeleteNewsComment(string guids)
		{
			string strSql = string.Empty;
			strSql = "      DELETE FROM ShopNum1_Shop_NewsComment  WHERE   Guid IN (" + guids + ")       ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetNewsCommentDetail(string guid)
		{
			string text = string.Empty;
			text += "       SELECT  A.*,B.Title AS ShopNewsTitle FROM  ShopNum1_Shop_NewsComment AS A LEFT JOIN ShopNum1_Shop_News AS B    ";
			text += "       ON A.ArticleGuid=B.Guid        ";
			text = text + "       WHERE A.Guid='" + guid + "'      ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SelectNews_List(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = " * ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Shop_News";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "CreateTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
