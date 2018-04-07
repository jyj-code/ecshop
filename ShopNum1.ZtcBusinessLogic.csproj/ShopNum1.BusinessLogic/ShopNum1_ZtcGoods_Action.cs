using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ZtcGoods_Action : IShopNum1_ZtcGoods_Action
	{
		public int Add(ShopNum1_ZtcGoods ZtcGoods)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT ShopNum1_ZtcGoods(  ProductGuid, ProductPrice, SellPrice, SellCount, ZtcName, ZtcImg, Ztc_Money, StartTime, ShopName, State, CreateUser, CreateTime, ModifyUser, ModifyTime, MemberID, SubstationID, IsDeleted ) VALUES (  '",
				Operator.FilterString(ZtcGoods.ProductGuid),
				"',  '",
				Operator.FilterString(ZtcGoods.ProductPrice),
				"',  '",
				Operator.FilterString(ZtcGoods.SellPrice),
				"',  '",
				Operator.FilterString(ZtcGoods.SellCount),
				"',  '",
				Operator.FilterString(ZtcGoods.ZtcName),
				"',  '",
				ZtcGoods.ZtcImg,
				"',  '",
				Operator.FilterString(ZtcGoods.Ztc_Money),
				"',  '",
				Operator.FilterString(ZtcGoods.StartTime),
				"',  '",
				Operator.FilterString(ZtcGoods.ShopName),
				"',  '",
				Operator.FilterString(ZtcGoods.State),
				"',  '",
				Operator.FilterString(ZtcGoods.CreateUser),
				"',  '",
				Operator.FilterString(ZtcGoods.CreateTime),
				"',  '",
				Operator.FilterString(ZtcGoods.ModifyUser),
				"',  '",
				Operator.FilterString(ZtcGoods.ModifyTime),
				"',  '",
				Operator.FilterString(ZtcGoods.MemberID),
				"',  '",
				Operator.FilterString(ZtcGoods.SubstationID),
				"',  ",
				ZtcGoods.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "   DELETE ShopNum1_ZtcGoods where  ID IN  (" + guids + ")  ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetInfoByGuid(string guid)
		{
			string str = guid.Replace("'", "");
			string strSql = string.Empty;
			strSql = "   SELECT  * FROM  ShopNum1_ZtcGoods  WHERE ID ='" + str + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(int IsDeleted)
		{
			string text = string.Empty;
			text = "   SELECT   *  FROM  ShopNum1_ZtcGoods  WHERE 1=1 AND starttime<=getdate() ";
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = text + "   and   IsDeleted=" + IsDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetProduct(int topnumber, string ProductSeriesCode, string Name, string MemLoginID, int IsDeleted, int IsAudit, int IsSaled)
		{
			string text = string.Empty;
			text = "   SELECT  top  " + topnumber + "    Guid ,Name   from    ShopNum1_Shop_Product      where  1=1   ";
			if (ProductSeriesCode != "0")
			{
				text = text + "    and   ProductSeriesCode like  '" + ProductSeriesCode + "%'   ";
			}
			if (!string.IsNullOrEmpty(Name))
			{
				text = text + "    and   Name like  '%" + Name + "%'   ";
			}
			text = text + "    and   MemLoginID =  '" + MemLoginID + "'   ";
			if (IsDeleted == 1 || IsDeleted == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"    and   IsDeleted =  '",
					IsDeleted,
					"'   "
				});
			}
			if (IsAudit == 1 || IsAudit == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"    and   IsAudit =  '",
					IsAudit,
					"'   "
				});
			}
			if (IsSaled == 1 || IsSaled == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"    and   IsSaled =  '",
					IsSaled,
					"'   "
				});
			}
			text += "   order  by   CreateTime  desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetProduct(int topnumber, string ProductSeriesCode, string Name, string MemLoginID, int IsDeleted, int IsAudit, int IsSaled, int IsPanicBuy, int IsSpellBuy)
		{
			string text = string.Empty;
			text = "   SELECT  top  " + topnumber + "    Guid ,Name   from    ShopNum1_Shop_Product      where  1=1   ";
			if (ProductSeriesCode != "0")
			{
				text = text + "    and   ProductSeriesCode like  '" + ProductSeriesCode + "%'   ";
			}
			if (!string.IsNullOrEmpty(Name))
			{
				text = text + "    and   Name like  '%" + Name + "%'   ";
			}
			text = text + "    and   MemLoginID =  '" + MemLoginID + "'   ";
			if (IsDeleted == 1 || IsDeleted == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"    and   IsDeleted =  '",
					IsDeleted,
					"'   "
				});
			}
			if (IsAudit == 1 || IsAudit == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"    and   IsAudit =  '",
					IsAudit,
					"'   "
				});
			}
			if (IsSaled == 1 || IsSaled == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"    and   IsSaled =  '",
					IsSaled,
					"'   "
				});
			}
			text += "   order  by   CreateTime  desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetProduct(int topnumber, string ProductSeriesCode, string Name, string MemLoginID, int IsDeleted, int IsAudit, int IsSaled, int IsPanicBuy, int IsSpellBuy, string IsSell)
		{
			string text = string.Empty;
			text = "   SELECT  top  " + topnumber + "    Guid ,Name   from    ShopNum1_Shop_Product      where  1=1   ";
			if (ProductSeriesCode != "0")
			{
				text = text + "    and   ProductSeriesCode like  '" + ProductSeriesCode + "%'   ";
			}
			if (!string.IsNullOrEmpty(Name))
			{
				text = text + "    and   Name like  '%" + Name + "%'   ";
			}
			text = text + "    and   MemLoginID =  '" + MemLoginID + "'   ";
			if (IsDeleted == 1 || IsDeleted == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"    and   IsDeleted =  '",
					IsDeleted,
					"'   "
				});
			}
			if (IsAudit == 1 || IsAudit == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"    and   IsAudit =  '",
					IsAudit,
					"'   "
				});
			}
			if (IsSaled == 1 || IsSaled == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"    and   IsSaled =  '",
					IsSaled,
					"'   "
				});
			}
			if (IsSell != "-1")
			{
				text = text + "    and     IsSell =  '" + IsSell + "'   ";
			}
			text += "   order  by   CreateTime  desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchProductImage(string Guid)
		{
			string text = string.Empty;
			text = "   SELECT   OriginalImage  FROM  ShopNum1_Shop_Product  WHERE 1=1   ";
			text = text + "   and   Guid='" + Guid + "' ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchProductOrder(string Ztc_Money, string SubId)
		{
			string text = string.Empty;
			text = "   SELECT   COUNT(*)  FROM  ShopNum1_ZtcGoods  WHERE 1=1   ";
			if (!string.IsNullOrEmpty(Ztc_Money))
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"   and  Ztc_Money >",
					Ztc_Money,
					"  And substationid='",
					SubId,
					"' "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchShopInfo(string MemLoginID)
		{
			string text = string.Empty;
			text = "   SELECT   *   FROM  ShopNum1_ShopInfo  WHERE 1=1   ";
			text = text + "   and   MemLoginID='" + MemLoginID + "'";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string ZtcName, int State, string MemberID)
		{
			string text = string.Empty;
			text = "   SELECT   *  FROM  ShopNum1_ZtcGoods  WHERE 1=1   ";
			if (!string.IsNullOrEmpty(ZtcName))
			{
				text = text + "    ZtcName  LIKE  '%" + ZtcName + "%'  ";
			}
			if (State != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"    State=  ",
					State,
					"  "
				});
			}
			text = text + "   AND    MemberID ='" + MemberID + "'   ";
			text += "   ORDER BY   CreateTime  DESC     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string top1, string top2, int State)
		{
			string text = string.Empty;
			text = "    SELECT  * FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   FROM  ShopNum1_ZtcGoods   WHERE Ztc_Money>0 AND  State=",
				State,
				"  AND  StartTime <=GETDATE()  "
			});
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"   )AS B WHERE ROWID>=",
				top1,
				" AND  ROWID<=",
				top2,
				"    "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string top1, string top2, int State, decimal Ztc_Money)
		{
			string text = string.Empty;
			text = "    SELECT  *,(select salenumber from shopnum1_shop_product where guid=b.productguid)salenumber FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   FROM  ShopNum1_ZtcGoods z  WHERE Ztc_Money>=",
				Ztc_Money,
				" AND  State=",
				State,
				" AND  StartTime <=GETDATE()   "
			});
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"   )AS B WHERE ROWID>=",
				top1,
				" AND  ROWID<=",
				top2,
				"    "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string top1, string top2, int State, decimal Ztc_Money, string SubstationID)
		{
			string text = string.Empty;
			text = "    SELECT  *,(select salenumber from shopnum1_shop_product where guid=b.productguid)salenumber FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   FROM  ShopNum1_ZtcGoods z  WHERE Ztc_Money>=",
				Ztc_Money,
				" AND  State=",
				State,
				"  AND  SubstationID='",
				SubstationID,
				"'  AND  StartTime <=GETDATE()   "
			});
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"   )AS B WHERE ROWID>=",
				top1,
				" AND  ROWID<=",
				top2,
				"    "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string ZtcName, string ShopName, int State, int IsDeleted)
		{
			string text = string.Empty;
			text = "    SELECT * FROM   ShopNum1_ZtcGoods   WHERE 1=1     ";
			if (!string.IsNullOrEmpty(ZtcName))
			{
				text = text + "   AND      ZtcName  LIKE  '%" + ZtcName + "%'    ";
			}
			if (!string.IsNullOrEmpty(ShopName))
			{
				text = text + "   AND      ShopName  LIKE  '%" + ShopName + "%'    ";
			}
			if (State != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   AND      State  = ",
					State,
					"    "
				});
			}
			if (IsDeleted != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   AND      IsDeleted  = ",
					IsDeleted,
					"    "
				});
			}
			text += "    ORDER  BY  CreateTime   DESC       ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string ZtcName, string ShopName, int State, int IsDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "    SELECT * FROM   ShopNum1_ZtcGoods   WHERE 1=1     ";
			if (!string.IsNullOrEmpty(ZtcName))
			{
				text = text + "   AND      ZtcName  LIKE  '%" + ZtcName + "%'    ";
			}
			if (!string.IsNullOrEmpty(ShopName))
			{
				text = text + "   AND      ShopName  LIKE  '%" + ShopName + "%'    ";
			}
			if (State != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   AND      State  = ",
					State,
					"    "
				});
			}
			if (IsDeleted != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   AND      IsDeleted  = ",
					IsDeleted,
					"    "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + "   AND        SubstationID  ='" + SubstationID + "'    ";
			}
			text += "    ORDER  BY  CreateTime   DESC       ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdateState(string string_0, int State)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"  UPDATE   ShopNum1_ZtcGoods  SET   State=",
				State,
				"  WHERE   ID   IN  (",
				string_0,
				")     "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(string string_0, string ZtcName, string ZtcImg, string SellPrice, string SellCount)
		{
			string text = string.Empty;
			text = "    UPDATE   ShopNum1_ZtcGoods  SET     ";
			text = text + "   ZtcName ='" + ZtcName + "',     ";
			text = text + "   ZtcImg ='" + ZtcImg + "',     ";
			text = text + "   SellPrice ='" + SellPrice + "',     ";
			text = text + "   SellCount ='" + SellCount + "',     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   ModifyTime ='",
				DateTime.Now,
				"'     "
			});
			text = text + "   WHERE  ID='" + string_0 + "'     ";
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int UpdateAddMoney(string ID, decimal Ztc_Money)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"  UPDATE   ShopNum1_ZtcGoods  SET   Ztc_Money=Ztc_Money+",
				Ztc_Money,
				",ModifyTime='",
				DateTime.Now,
				"'  WHERE   ID   =  '",
				ID,
				"'     "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchData(int State, decimal Ztc_Money, int page, int int_0)
		{
			int num = page * int_0 - int_0 + 1;
			int num2 = page * int_0;
			string text = string.Empty;
			text = "    SELECT  * FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   FROM  ShopNum1_ZtcGoods   WHERE Ztc_Money>=",
				Ztc_Money,
				" And starttime<=getdate() AND  State=",
				State,
				"    "
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   )AS B WHERE ROWID>=",
				num,
				" AND  ROWID<=",
				num2,
				"    "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchData(int State, decimal Ztc_Money, int page, int int_0, string SubstationID)
		{
			int num = page * int_0 - int_0 + 1;
			int num2 = page * int_0;
			string text = string.Empty;
			text = "    SELECT  * FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   FROM  ShopNum1_ZtcGoods   WHERE Ztc_Money>=",
				Ztc_Money,
				" And starttime<=getdate() AND  State=",
				State,
				"   AND SubstationID='",
				SubstationID,
				"'   "
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   )AS B WHERE ROWID>=",
				num,
				" AND  ROWID<=",
				num2,
				"    "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchData(int State, decimal Ztc_Money)
		{
			string text = string.Empty;
			text = "    SELECT  * FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   FROM  ShopNum1_ZtcGoods   WHERE Ztc_Money>",
				Ztc_Money,
				" AND  State=",
				State,
				"    "
			});
			text += "   )AS B WHERE 1=1    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchData(int State, decimal Ztc_Money, string SubstationID)
		{
			string text = string.Empty;
			text = "    SELECT  * FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   FROM  ShopNum1_ZtcGoods   WHERE Ztc_Money>",
				Ztc_Money,
				" AND  State=",
				State,
				"  AND SubstationID='",
				SubstationID,
				"' And starttime<=getdate()    "
			});
			text += "   )AS B WHERE 1=1    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int TimeNessMoney(decimal money)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				" UPDATE  ShopNum1_ZtcGoods  SET  Ztc_Money=Ztc_Money-",
				money,
				"  WHERE  Ztc_Money>=",
				money,
				"  AND  StartTime <=GETDATE()  AND State=1 AND IsDeleted=0 "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
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
			array2[3] = "ShopNum1_ZtcGoods";
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
