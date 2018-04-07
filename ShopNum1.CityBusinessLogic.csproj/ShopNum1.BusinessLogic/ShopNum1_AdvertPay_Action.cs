using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_AdvertPay_Action : IShopNum1_AdvertPay_Action
	{
		public int Add(ShopNum1_AdvertPay AdvertPay)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"insert ShopNum1_AdvertPay( Guid,AdId,AdType,CityCode,SubstationID,Image,Website,Remarks,MemLoginID,IsExamine,BeginDate,EndDate,ApplyState,ExamineCase,PayMoney,IsCancel,ClickTime,CreateUser,CreateTime,ModifyUser,ModifyTime,Website1,Website2,Remarks1,Remarks2,IsDeleted ) VALUES (  '",
				AdvertPay.Guid,
				"',  '",
				Operator.FilterString(AdvertPay.AdId),
				"',  '",
				Operator.FilterString(AdvertPay.AdType),
				"',  '",
				Operator.FilterString(AdvertPay.CityCode),
				"',  '",
				Operator.FilterString(AdvertPay.SubstationID),
				"',  '",
				Operator.FilterString(AdvertPay.Image),
				"',  '",
				Operator.FilterString(AdvertPay.Website),
				"',  '",
				Operator.FilterString(AdvertPay.Remarks),
				"',  '",
				Operator.FilterString(AdvertPay.MemLoginID),
				"',  '",
				Operator.FilterString(AdvertPay.IsExamine),
				"',  '",
				Operator.FilterString(AdvertPay.BeginDate),
				"',  '",
				Operator.FilterString(AdvertPay.EndDate),
				"',  '",
				Operator.FilterString(AdvertPay.ApplyState),
				"',  '",
				Operator.FilterString(AdvertPay.ExamineCase),
				"',  '",
				Operator.FilterString(AdvertPay.PayMoney),
				"',  '",
				Operator.FilterString(AdvertPay.IsCancel),
				"',  '",
				Operator.FilterString(AdvertPay.ClickTime),
				"',  '",
				Operator.FilterString(AdvertPay.CreateUser),
				"',  '",
				Operator.FilterString(AdvertPay.CreateTime),
				"',  '",
				Operator.FilterString(AdvertPay.ModifyUser),
				"',  '",
				Operator.FilterString(AdvertPay.ModifyTime),
				"',  '",
				Operator.FilterString(AdvertPay.Website1),
				"',  '",
				Operator.FilterString(AdvertPay.Website2),
				"',  '",
				Operator.FilterString(AdvertPay.Remarks1),
				"',  '",
				Operator.FilterString(AdvertPay.Remarks2),
				"',  '",
				Operator.FilterString(AdvertPay.IsDeleted),
				"'  )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Updata(ShopNum1_AdvertPay AdvertPay)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_AdvertPay SET  AdId ='",
				Operator.FilterString(AdvertPay.AdId),
				"', AdType ='",
				Operator.FilterString(AdvertPay.AdType),
				"', CityCode ='",
				Operator.FilterString(AdvertPay.CityCode),
				"', SubstationID ='",
				AdvertPay.SubstationID,
				"', Image ='",
				AdvertPay.Image,
				"', Website ='",
				AdvertPay.Website,
				"',WHERE Guid=",
				AdvertPay.Guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string Guid)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_AdvertPay WHERE Guid IN (" + Guid + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateIsExamine(string Guid, int IsExamine)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"update  ShopNum1_AdvertPay  set IsExamine='",
				IsExamine,
				"', ModifyTime='",
				DateTime.Now,
				"'   WHERE Guid IN (",
				Guid,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetMaxDate(string SubstationID, string AdId)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"   select max(EndDate)  from  ShopNum1_AdvertPay where SubstationID='",
				SubstationID,
				"' and AdId='",
				AdId,
				"'  and IsDeleted=0   "
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateEndDate(string Guid, string BeginDate, string EndDate)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"update  ShopNum1_AdvertPay  set BeginDate='",
				BeginDate,
				"', EndDate='",
				EndDate,
				"'  WHERE Guid IN (",
				Guid,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string MemLoginID)
		{
			string text = string.Empty;
			text = "SELECT * FROM ShopNum1_AdvertPay WHERE 0=0";
			if (Operator.FilterString(MemLoginID) != "")
			{
				text = text + " AND MemLoginID='" + MemLoginID + "' ";
			}
			text += "   and IsDeleted=0   ";
			text += "   order  by  CreateTime     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search()
		{
			string strSql = string.Empty;
			strSql = "SELECT * FROM ShopNum1_AdvertPay WHERE 0=0";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int IsCancel(string guid, int IsCancel)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"  update  ShopNum1_AdvertPay set  IsCancel='",
				IsCancel,
				"'  where   Guid  in(",
				guid,
				") "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchAll(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT * FROM ShopNum1_AdvertPay WHERE   Guid  in(" + guid + ")  ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string MemLoginID, int AdId, int IsExamine, string CityCode)
		{
			string text = string.Empty;
			text = "SELECT * FROM ShopNum1_AdvertPay WHERE  1=1  ";
			if (!string.IsNullOrEmpty(MemLoginID))
			{
				text = text + "   and    MemLoginID='" + MemLoginID + "'   ";
			}
			if (AdId != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"  and    AdId='",
					AdId,
					"'   "
				});
			}
			if (IsExamine != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"  and    IsExamine='",
					IsExamine,
					"'   "
				});
			}
			if (!string.IsNullOrEmpty(CityCode))
			{
				text = text + "  and    CityCode='" + CityCode + "'   ";
			}
			text += "  and    IsDeleted=0   ";
			text += "  order  by  CreateTime   desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string MemLoginID, int AdId, int IsExamine, string CityCode, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT * FROM ShopNum1_AdvertPay WHERE  1=1  ";
			if (!string.IsNullOrEmpty(MemLoginID))
			{
				text = text + "   and    MemLoginID='" + MemLoginID + "'   ";
			}
			if (AdId != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"  and    AdId='",
					AdId,
					"'   "
				});
			}
			if (IsExamine != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"  and    IsExamine='",
					IsExamine,
					"'   "
				});
			}
			if (!string.IsNullOrEmpty(CityCode))
			{
				text = text + "  and    CityCode='" + CityCode + "'   ";
			}
			text = text + "  and    SubstationID='" + SubstationID + "'   ";
			text += "  and    IsDeleted=0   ";
			text += "  order  by  CreateTime   desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search1(string MemLoginID, int AdId, int IsExamine, string CityCode, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT * FROM ShopNum1_AdvertPay WHERE  1=1  ";
			if (!string.IsNullOrEmpty(MemLoginID))
			{
				text = text + "   and    MemLoginID='" + MemLoginID + "'   ";
			}
			if (AdId != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"  and    AdId='",
					AdId,
					"'   "
				});
			}
			if (IsExamine != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"  and    IsExamine='",
					IsExamine,
					"'   "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + "  and    SubstationID='" + SubstationID + "'   ";
			}
			text += "  and    IsDeleted=0   ";
			text += "  order  by  CreateTime   desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchNowData(string AdId, string CityCode, int type, string SubstationID)
		{
			string text = string.Empty;
			text = "  select * from ShopNum1_AdvertPay    ";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"    where AdId='",
				AdId,
				"' and  CityCode='",
				CityCode,
				"'     "
			});
			text += "   and BeginDate<=getdate() and EndDate>=getdate()   ";
			text += "   and IsCancel=0 and IsDeleted=0   ";
			text += "  and IsExamine=1 and     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"  ApplyState=1  and AdType=",
				type,
				"     "
			});
			text = text + "   and  SubstationID='" + SubstationID + "'   ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchNowData(string AdId, int type, string SubstationID)
		{
			string text = string.Empty;
			text = "  select * from ShopNum1_AdvertPay    ";
			text = text + "    where AdId='" + AdId + "'      ";
			text += "   and BeginDate<=getdate() and EndDate>=getdate()   ";
			text += "   and IsCancel=0 and IsDeleted=0   ";
			text += "  and IsExamine=1 and     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"  ApplyState=1  and AdType=",
				type,
				"     "
			});
			text = text + "   and  SubstationID='" + SubstationID + "'   ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchNowDataIsDelete(string AdId, string SubstationID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"  select * from ShopNum1_AdvertPay   where  AdId  in (",
				AdId,
				")  and SubstationID='",
				SubstationID,
				"' "
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int ChangeApplyState(string guid, int ApplyState)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"  update  ShopNum1_AdvertPay set  ApplyState='",
				ApplyState,
				"',CreateTime='",
				DateTime.Now,
				"'  where   Guid  in(",
				guid,
				") "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public string GetTeamCount(string SubstationID, string AdId, int ApplyState)
		{
			string text = string.Empty;
			text += "   select count(Guid) from  ShopNum1_AdvertPay     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   where SubstationID='",
				SubstationID,
				"' and AdId=",
				AdId,
				"  and ApplyState=",
				ApplyState,
				"   "
			});
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string GetTeamOrder(string SubstationID, string AdId)
		{
			string text = string.Empty;
			text += "   select count(Guid) from  ShopNum1_AdvertPay       ";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"   where SubstationID='",
				SubstationID,
				"' and AdId=",
				AdId,
				"  and IsExamine=1 and BeginDate < getdate()    "
			});
			text += "   and EndDate>getdate() and IsCancel=0        ";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string GetTeamOrderNew(string SubstationID, string AdId)
		{
			string text = string.Empty;
			text += "   select count(Guid) from  ShopNum1_AdvertPay       ";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"   where SubstationID='",
				SubstationID,
				"' and AdId=",
				AdId,
				"  and IsExamine=1     "
			});
			text += "   and EndDate>getdate() and IsCancel=0        ";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public int ChangeIsDeleted(string guid, int IsDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"  update  ShopNum1_AdvertPay set  IsDeleted='",
				IsDeleted,
				"'   where   Guid  in(",
				guid,
				") "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int ChangeRun(string guid, string Website, string Image, int IsCancel)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"    update  ShopNum1_AdvertPay set  Website='",
				Website,
				"' ,Image='",
				Image,
				"',IsCancel=",
				IsCancel,
				"     "
			});
			text = text + "   where   Guid='" + guid + "'     ";
			return DatabaseExcetue.RunNonQuery(text);
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
			array2[3] = "ShopNum1_AdvertPay";
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
