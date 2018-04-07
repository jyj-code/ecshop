using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_MemberMessage_Action : IShopNum1_MemberMessage_Action
	{
		public DataTable SelectMsg(ShopNum1_MemberMessage shopNum1_MemberMessage)
		{
			string text = "select * from shopNum1_MemberMessage where IsDeleted=0 ";
			Guid arg_0C_0 = shopNum1_MemberMessage.Guid;
			if (shopNum1_MemberMessage.Guid != new Guid("00000000-0000-0000-0000-000000000000"))
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" and Guid='",
					shopNum1_MemberMessage.Guid,
					"'"
				});
			}
			if (shopNum1_MemberMessage.IsRead != 2)
			{
				text = text + " and isread=" + shopNum1_MemberMessage.IsRead;
			}
			text += " order by sendtime desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SelectMsg_List(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = "Guid,isread,sendtime,title";
			array[3] = "@tablename";
			array2[3] = "shopNum1_MemberMessage";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "sendtime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int Add_MemberMsg(ShopNum1_MemberMessage shopNum1_MemberMessage)
		{
			string text = "insert into ShopNum1_MemberMessage(guid,title,content,sendloginid,reloginid)values('{0}','{1}','{2}','{3}','{4}')";
			text = string.Format(text, new object[]
			{
				Guid.NewGuid(),
				shopNum1_MemberMessage.Title,
				shopNum1_MemberMessage.Content,
				shopNum1_MemberMessage.SendLoginID,
				shopNum1_MemberMessage.ReLoginID
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int Update_MsgIsRead(string strGuid)
		{
			string strSql = "update ShopNum1_MemberMessage set isread=1 where guid='" + strGuid + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete_Msg(string strArray)
		{
			string strSql = "update ShopNum1_MemberMessage set isdeleted=1 where guid in (" + strArray + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
