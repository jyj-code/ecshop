using ShopNum1.DataAccess;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.Second
{
	public class ShopNum1_SecondTypeAccess
	{
		public int GetMaxOrderId()
		{
			return DatabaseExcetue.ReturnMaxID("OrderID", "ShopNum1_SecondType") + 1;
		}
		public bool Exists(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from ShopNum1_SecondType");
			stringBuilder.Append(" where ID=@ID ");
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@ID";
			array2[0] = ID.ToString();
			int num = Convert.ToInt32(DatabaseExcetue.ReturnObject(stringBuilder.ToString(), array, array2));
			return num > 0;
		}
		public bool Add(ShopNum1_SecondType model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into ShopNum1_SecondType(");
			stringBuilder.Append("TypeName,AppID,AppSecret,content,redirectURL,isAvabile,OrderID,Imgsrc)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@TypeName,@AppID,@AppSecret,@content,@redirectURL,@isAvabile,@OrderID,@Imgsrc)");
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@TypeName";
			array[1] = "@AppID";
			array[2] = "@AppSecret";
			array[3] = "@content";
			array[4] = "@redirectURL";
			array[5] = "@isAvabile";
			array[6] = "@OrderID";
			array[7] = "@Imgsrc";
			array2[0] = model.TypeName;
			array2[1] = model.AppID;
			array2[2] = model.AppSecret;
			array2[3] = model.content;
			array2[4] = model.redirectURL;
			array2[5] = model.isAvabile.ToString();
			array2[6] = model.OrderID.ToString();
			array2[7] = model.ImgSrc.ToString();
			int num = DatabaseExcetue.RunNonQuery(stringBuilder.ToString(), array, array2);
			return num > 0;
		}
		public bool Update(ShopNum1_SecondType model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ShopNum1_SecondType set ");
			stringBuilder.Append("TypeName=@TypeName,");
			stringBuilder.Append("AppID=@AppID,");
			stringBuilder.Append("AppSecret=@AppSecret,");
			stringBuilder.Append("content=@content,");
			stringBuilder.Append("redirectURL=@redirectURL,");
			stringBuilder.Append("isAvabile=@isAvabile,OrderID=@OrderID,ImgSrc=@ImgSrc");
			stringBuilder.Append(" where ID=@ID ");
			string[] array = new string[9];
			string[] array2 = new string[9];
			array[0] = "@TypeName";
			array[1] = "@AppID";
			array[2] = "@AppSecret";
			array[3] = "@content";
			array[4] = "@redirectURL";
			array[5] = "@isAvabile";
			array[6] = "@ID";
			array[7] = "@OrderID";
			array[8] = "@ImgSrc";
			array2[0] = model.TypeName;
			array2[1] = model.AppID;
			array2[2] = model.AppSecret;
			array2[3] = model.content;
			array2[4] = model.redirectURL;
			array2[5] = model.isAvabile.ToString();
			array2[6] = model.ID.ToString();
			array2[7] = model.OrderID.ToString();
			array2[8] = model.ImgSrc.ToString();
			int num = DatabaseExcetue.RunNonQuery(stringBuilder.ToString(), array, array2);
			return num > 0;
		}
		public bool Delete(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from ShopNum1_SecondType ");
			stringBuilder.Append(" where ID=@ID ");
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@ID";
			array2[0] = ID.ToString();
			int num = DatabaseExcetue.RunNonQuery(stringBuilder.ToString(), array, array2);
			return num > 0;
		}
		public DataTable GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,TypeName,AppID,AppSecret,content,redirectURL,isAvabile,createTime,OrderID,Imgsrc from ShopNum1_SecondType ");
			stringBuilder.Append(" where ID=@ID ");
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@ID";
			array2[0] = ID.ToString();
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString(), array, array2);
		}
		public DataTable GetList(string strWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,TypeName,AppID,AppSecret,content,redirectURL,isAvabile,createTime,OrderID,Imgsrc ");
			stringBuilder.Append(" FROM ShopNum1_SecondType ");
			if (strWhere.Trim() != "")
			{
				stringBuilder.Append(" where " + strWhere);
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetSecondByCount(string count, string isAvabile)
		{
			string format = string.Empty;
			format = "select  top ({0}) ID,TypeName,Imgsrc from ShopNum1_SecondType where isAvabile={1}";
			return DatabaseExcetue.ReturnDataTable(string.Format(format, count, isAvabile));
		}
	}
}
