using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Help_Action : IShopNum1_Help_Action
	{
		public int Add(ShopNum1_Help shopNum1_Help)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Help( Guid, Title, HelpTypeGuid, Remark, OrderID, CreateUser, CreateTime, ModifyUser, ModifyTime  ) VALUES (  '",
				shopNum1_Help.Guid,
				"',  '",
				Operator.FilterString(shopNum1_Help.Title),
				"',  '",
				shopNum1_Help.HelpTypeGuid,
				"',  '",
				Operator.FilterString(shopNum1_Help.Remark),
				"',  ",
				shopNum1_Help.OrderID.ToString(),
				",  '",
				shopNum1_Help.CreateUser,
				"', getdate(),  '",
				shopNum1_Help.ModifyUser,
				"' , getdate())"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = "delete from ShopNum1_Help  WHERE Guid IN (" + guids + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.Guid, A.Title, A.Remark,A.OrderID,B.Name,A.HelpTypeGuid,B.Name As Type, A.CreateUser,A.CreateTime,A.ModifyUser,A.ModifyTime,A.IsDeleted  FROM ShopNum1_Help A left join ShopNum1_HelpType B on A.HelpTypeGuid=B.Guid Where A.Guid= " + guid + " ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string title, string type)
		{
			string text = string.Empty;
			text = "SELECT A.Guid, A.Title,B.Name, A.CreateUser,A.CreateTime,A.ModifyUser,A.ModifyTime FROM ShopNum1_Help A left join ShopNum1_HelpType B on A.HelpTypeGuid=B.Guid Where";
			text += " A.IsDeleted=0";
			if (Operator.FormatToEmpty(title) != "")
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (type != "-1")
			{
				text = text + " AND A.HelpTypeGuid = '" + type + "'";
			}
			text += " ORDER BY A.OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(ShopNum1_Help shopNum1_Help)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Help SET  Title='",
				Operator.FilterString(shopNum1_Help.Title),
				"', HelpTypeGuid='",
				shopNum1_Help.HelpTypeGuid,
				"', OrderID=",
				shopNum1_Help.OrderID.ToString(),
				", Remark='",
				Operator.FilterString(shopNum1_Help.Remark),
				"', ModifyUser='",
				shopNum1_Help.ModifyUser,
				"', ModifyTime=getdate() WHERE Guid='",
				shopNum1_Help.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchRemark(string guid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT  Guid, Title, CreateUser, CreateTime, Remark, IsDeleted FROM ShopNum1_Help Where 0=0  ";
			if (guid != "-1" && Operator.FormatToEmpty(guid) != string.Empty)
			{
				text = text + " AND Guid = '" + guid + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string helpTypeGuid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT  Guid, Title, HelpTypeGuid, OrderID, ModifyTime,  IsDeleted FROM ShopNum1_Help Where 0=0  ";
			if (helpTypeGuid != "-1")
			{
				text = text + " AND HelpTypeGuid = '" + helpTypeGuid + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string helpTypeGuid, int showCount, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT  TOP " + showCount + " Guid, Title, HelpTypeGuid, OrderID, ModifyTime,  IsDeleted FROM ShopNum1_Help Where 0=0 ";
			if (helpTypeGuid != "-1")
			{
				text = text + " AND HelpTypeGuid = '" + helpTypeGuid + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetHelpMeto(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Title,Remark from ShopNum1_Help where Guid= '" + guid + "' ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataSet Search(string productName, string ordername, string soft, string perpagenum, string current_page, string isreturcount)
		{
			string text = string.Empty;
			if (productName != "-1" && !string.IsNullOrEmpty(productName))
			{
				text = "  A.Title like '%" + Operator.FilterString(productName) + "%' ";
			}
			else
			{
				text = "1=1";
			}
			if (ordername == "-1")
			{
				ordername = "A.Guid ";
			}
			else
			{
				ordername = "A." + ordername;
			}
			if (string.IsNullOrEmpty(soft))
			{
				soft = "desc";
			}
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@columnnames";
			array2[2] = " A.Guid,A.Title,A.Remark ";
			array[3] = "@ordername";
			array2[3] = ordername;
			array[4] = "@searchname";
			array2[4] = text;
			array[5] = "@sdesc";
			array2[5] = soft;
			array[6] = "@isreturcount";
			array2[6] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageHelpLists", array, array2);
		}
	}
}
