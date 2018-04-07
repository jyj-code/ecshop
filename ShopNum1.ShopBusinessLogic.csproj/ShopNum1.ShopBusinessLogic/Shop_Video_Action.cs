using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Video_Action : IShop_Video_Action
	{
		public int AddVideoInfo(ShopNum1_Shop_Video shop_Video)
		{
			string[] array = new string[13];
			string[] array2 = new string[13];
			array[0] = "@title";
			array2[0] = shop_Video.Title;
			array[1] = "@imgadd";
			array2[1] = shop_Video.ImgAdd;
			array[2] = "@videoadd";
			array2[2] = shop_Video.VideoAdd;
			array[3] = "@categoryguid";
			array2[3] = shop_Video.CategoryGuid;
			array[4] = "@keywords";
			array2[4] = shop_Video.KeyWords;
			array[5] = "@content";
			array2[5] = shop_Video.Content;
			array[6] = "@createuser";
			array2[6] = shop_Video.CreateUser;
			array[7] = "@orderid";
			array2[7] = shop_Video.OrderID.ToString();
			array[8] = "@isrecommend";
			array2[8] = shop_Video.IsRecommend.ToString();
			array[9] = "@shopid";
			array2[9] = shop_Video.ShopID;
			array[10] = "@description";
			array2[10] = shop_Video.Description;
			array[11] = "@memLoginID";
			array2[11] = shop_Video.MemLoginID;
			array[12] = "@BroadcastCount";
			array2[12] = shop_Video.BroadcastCount.ToString();
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddVideoInfo", array, array2);
		}
		public DataTable GetVideoInfo(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetVideoInfo", array, array2);
		}
		public DataTable GetVideoInfoByGuidAndMemLoginID(string guid, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetVideoInfoByGuidAndMemLoginID", array, array2);
		}
		public int UpdateVideoInfo(ShopNum1_Shop_Video shop_Video)
		{
			string[] array = new string[12];
			string[] array2 = new string[12];
			array[0] = "@guid";
			array2[0] = shop_Video.Guid.ToString();
			array[1] = "@title";
			array2[1] = shop_Video.Title;
			array[2] = "@imgadd";
			array2[2] = shop_Video.ImgAdd;
			array[3] = "@videoadd";
			array2[3] = shop_Video.VideoAdd;
			array[4] = "@categoryguid";
			array2[4] = shop_Video.CategoryGuid;
			array[5] = "@keywords";
			array2[5] = shop_Video.KeyWords;
			array[6] = "@content";
			array2[6] = shop_Video.Content;
			array[7] = "@modifyuser";
			array2[7] = shop_Video.ModifyUser;
			array[8] = "@orderid";
			array2[8] = shop_Video.OrderID.ToString();
			array[9] = "@isrecommend";
			array2[9] = shop_Video.IsRecommend.ToString();
			array[10] = "@shopid";
			array2[10] = shop_Video.ShopID;
			array[11] = "@description";
			array2[11] = shop_Video.Description;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateVideoInfo", array, array2);
		}
		public int DeleteVideoInfo(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteVideoInfo", array, array2);
		}
		public DataTable SearchVideoList(string shopid, string categoryguid, string showcount, string title, string order)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@categoryguid";
			array2[1] = categoryguid;
			array[2] = "@showcount";
			array2[2] = showcount;
			array[3] = "@title";
			array2[3] = title;
			array[4] = "@order";
			array2[4] = order;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchVideoList", array, array2);
		}
		public DataTable MetaGetVideo(string memloginid, string guid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@guid";
			array2[1] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_MetaGetVideo", array, array2);
		}
		public DataTable GetShopVedioDetailMeto(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopVedioDetailMeto", array, array2);
		}
		public DataTable GetCountVedioByMemLoginID(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCountVedioByMemLoginID", array, array2);
		}
		public DataSet SearchVideoListNew(string shopid, string ordertype, string sort, string perpagenum, string current_page, string isreturcount)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@ordertype";
			array2[1] = ordertype;
			array[2] = "@sort";
			array2[2] = sort;
			array[3] = "@perpagenum";
			array2[3] = perpagenum;
			array[4] = "@current_page";
			array2[4] = current_page;
			array[5] = "@isreturcount";
			array2[5] = isreturcount;
			array[6] = "@columnnames";
			array2[6] = " A.Guid,A.Title,A.ImgAdd,A.VideoAdd,A.CategoryGuid,A.KeyWords,A.Content,A.IsRecommend,A.ShopID,A.BroadcastCount,B.Name ";
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchVideoListNew", array, array2);
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
			array2[2] = " * ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Shop_Video";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "OrderID";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public string GetMaxOrderID(string MemLoginID)
		{
			string strSql = string.Empty;
			strSql = "     SELECT MAX(OrderID)  FROM   ShopNum1_Shop_Video  WHERE 1=1   AND    MemLoginID='" + MemLoginID + "'     ";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				return "0";
			}
			if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
			{
				return dataTable.Rows[0][0].ToString();
			}
			return "0";
		}
		public int AddBroadcastCount(int BroadcastCount, string guid)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"   UPDATE  ShopNum1_Shop_Video  SET    BroadcastCount=BroadcastCount+",
				BroadcastCount.ToString(),
				"  WHERE   Guid ='",
				guid,
				"'   "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
