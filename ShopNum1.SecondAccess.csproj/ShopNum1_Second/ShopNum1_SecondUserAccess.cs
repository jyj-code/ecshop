using ShopNum1.DataAccess;
using ShopNum1.Second;
using System;
using System.Text;
namespace ShopNum1_Second
{
	public class ShopNum1_SecondUserAccess
	{
		public int GetMaxId()
		{
			return DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_SecondUser");
		}
		public bool Exists(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from ShopNum1_SecondUser");
			stringBuilder.Append(" where ID=@ID ");
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@ID";
			array2[0] = ID.ToString();
			int num = Convert.ToInt32(DatabaseExcetue.ReturnObject(stringBuilder.ToString(), array, array2));
			return num > 0;
		}
		public object GetMemLogid(string SecondID, string Secondtype)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top (1) MemlogID from ShopNum1_SecondUser");
			stringBuilder.Append(" where SecondID=@SecondID AND Secondtype=@Secondtype ");
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@SecondID";
			array2[0] = SecondID;
			array[1] = "@Secondtype";
			array2[1] = Secondtype;
			return DatabaseExcetue.ReturnObject(stringBuilder.ToString(), array, array2);
		}
		public bool Add(ShopNum1_SecondUser model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into ShopNum1_SecondUser(");
			stringBuilder.Append("MemlogID,SecondID,Secondtype,isAvailable)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@MemlogID,@SecondID,@Secondtype,@isAvailable)");
			stringBuilder.Append(";select @@IDENTITY");
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@MemlogID";
			array[1] = "@SecondID";
			array[2] = "@Secondtype";
			array[3] = "@isAvailable";
			array2[0] = model.MemlogID;
			array2[1] = model.SecondID;
			array2[2] = model.Secondtype;
			array2[3] = model.isAvailable.ToString();
			object obj = DatabaseExcetue.ReturnObject(stringBuilder.ToString(), array, array2);
			return obj != null;
		}
		public bool Update(ShopNum1_SecondUser model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ShopNum1_SecondUser set ");
			stringBuilder.Append("MemlogID=@MemlogID,");
			stringBuilder.Append("SecondID=@SecondID,");
			stringBuilder.Append("Secondtype=@Secondtype,");
			stringBuilder.Append("isAvailable=@isAvailable");
			stringBuilder.Append(" where ID=@ID ");
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@MemlogID";
			array[1] = "@SecondID";
			array[2] = "@Secondtype";
			array[3] = "@isAvailable";
			array[4] = "@ID";
			array2[0] = model.MemlogID;
			array2[1] = model.SecondID;
			array2[2] = model.Secondtype;
			array2[3] = model.isAvailable.ToString();
			array2[4] = model.ID.ToString();
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString(), array, array2) > 0;
		}
		public bool Delete(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from ShopNum1_SecondUser ");
			stringBuilder.Append(" where ID=@ID ");
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@ID";
			array2[0] = ID.ToString();
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString(), array, array2) > 0;
		}
	}
}
