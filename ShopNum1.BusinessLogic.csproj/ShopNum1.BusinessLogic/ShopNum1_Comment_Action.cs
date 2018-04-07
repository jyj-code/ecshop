using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Comment_Action : IShopNum1_Comment_Action
	{
		public int AddComment(ShopNum1_Comment comment)
		{
			string[] array = new string[9];
			string[] array2 = new string[9];
			array[0] = "@memberone";
			array2[0] = comment.MemberOne;
			array[1] = "@membertwo";
			array2[1] = comment.MemberTwo;
			array[2] = "@commenttype";
			array2[2] = comment.CommentType.ToString();
			array[3] = "@good";
			array2[3] = comment.Good.ToString();
			array[4] = "@middle";
			array2[4] = comment.Middle.ToString();
			array[5] = "@bad";
			array2[5] = comment.Bad.ToString();
			array[6] = "@comment";
			array2[6] = comment.Comment;
			array[7] = "@commenttime";
			array2[7] = comment.CommentTime.ToShortDateString();
			array[8] = "@orderid";
			array2[8] = comment.OrderId;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddComment", array, array2);
		}
		public int DeleteComment(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteComment", array, array2);
		}
		public DataTable CommentListStatReport(string memberid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memberid";
			array2[0] = memberid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CommentListStatReport", array, array2);
		}
		public DataTable SearchCommentList(string memberid, string membertype, string commenttype)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@memberid";
			array2[0] = memberid;
			array[1] = "@membertype";
			array2[1] = membertype;
			array[2] = "@commenttype";
			array2[2] = commenttype;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCommentList", array, array2);
		}
	}
}
