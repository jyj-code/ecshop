using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Xml;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_OnLineService_Action : IShopNum1_OnLineService_Action
	{
		public XmlDocument xmlDoc;
		public int Add(ShopNum1_OnlineService onlineservice)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_OnlineService( Guid, Type, Name, ServiceAccount, Location, IsShow, OrderID, CreateUser, CreateTime, ModifyUser, ModifyTime, SubstationID, IsDeleted  ) VALUES (  '",
				onlineservice.Guid,
				"',  '",
				onlineservice.Type,
				"',  '",
				Operator.FilterString(onlineservice.Name),
				"',  '",
				Operator.FilterString(onlineservice.ServiceAccount),
				"',  '",
				Operator.FilterString(onlineservice.Location),
				"',  ",
				onlineservice.IsShow,
				",  ",
				onlineservice.OrderID,
				",  '",
				onlineservice.CreateUser,
				"', '",
				onlineservice.CreateTime,
				"',  '",
				onlineservice.ModifyUser,
				"' , '",
				onlineservice.ModifyTime,
				"',  '",
				onlineservice.SubstationID,
				"',  ",
				onlineservice.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "delete from ShopNum1_OnlineService  WHERE Guid IN (" + guids + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string guid, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid,Type, Name,ServiceAccount,Location,IsShow,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted FROM ShopNum1_OnlineService where guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataSet GetOnlineService(string showcountqq, string showcountmsn)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@showcountqq";
			array2[0] = showcountqq;
			array[1] = "@showcountmsn";
			array2[1] = showcountmsn;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_GetOnlineService", array, array2);
		}
		public DataTable GetOnlineServiceInfo(int Deleted)
		{
			string text = string.Empty;
			text = "SELECT A.Guid, A.Name,A.ServiceAccount,A.Location,A.IsShow,A.OrderID,A.CreateUser,A.CreateTime, A.ModifyUser,A.ModifyTime,A.IsDeleted FROM ShopNum1_OnlineService as A where 0=0";
			if (Deleted == 0 || Deleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsDeleted=",
					Deleted,
					" "
				});
			}
			text += "Order By A.OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetOnlineServiceInfo(int Deleted, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT A.Guid, A.Name,A.ServiceAccount,A.Location,A.IsShow,A.OrderID,A.CreateUser,A.CreateTime, A.ModifyUser,A.ModifyTime,A.IsDeleted FROM ShopNum1_OnlineService as A where 0=0";
			if (Deleted == 0 || Deleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsDeleted=",
					Deleted,
					" "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + " AND A.SubstationID='" + SubstationID + "' ";
			}
			text += "Order By A.OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(string guid, ShopNum1_OnlineService onlineservice)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OnlineService SET  Type='",
				onlineservice.Type,
				"', Name='",
				Operator.FilterString(onlineservice.Name),
				"', ServiceAccount='",
				Operator.FilterString(onlineservice.ServiceAccount),
				"', Location='",
				Operator.FilterString(onlineservice.Location),
				"', IsShow='",
				onlineservice.IsShow,
				"', orderid='",
				onlineservice.OrderID,
				"', ModifyUser='",
				onlineservice.ModifyUser,
				"', ModifyTime='",
				onlineservice.ModifyTime,
				"' WHERE Guid=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchTypeInfo(string strType, int isShow)
		{
			string text = string.Empty;
			text = "select name,ServiceAccount from ShopNum1_OnlineService where 1=1";
			if (Operator.FormatToEmpty(strType) != string.Empty)
			{
				text = text + " And Type='" + Operator.FilterString(strType) + "'";
			}
			if (isShow == 0 || isShow == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsShow=",
					isShow,
					" "
				});
			}
			text += " order by orderid asc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchTypeInfo(string strType, int isShow, int showCount)
		{
			string text = string.Empty;
			text = "select top " + showCount + "  name,ServiceAccount from ShopNum1_OnlineService where 1=1";
			if (Operator.FormatToEmpty(strType) != string.Empty)
			{
				text = text + " And Type='" + Operator.FilterString(strType) + "'";
			}
			if (isShow == 0 || isShow == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsShow=",
					isShow,
					" "
				});
			}
			text += " order by orderid asc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchTypeInfo(string strType, int isShow, int showCount, string SubstationID)
		{
			string text = string.Empty;
			text = "select top " + showCount + "  name,ServiceAccount from ShopNum1_OnlineService where 1=1";
			if (Operator.FormatToEmpty(strType) != string.Empty)
			{
				text = text + " And Type='" + Operator.FilterString(strType) + "'";
			}
			if (isShow == 0 || isShow == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsShow=",
					isShow,
					" "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + " And   SubstationID='" + SubstationID + "'";
			}
			text += " order by orderid asc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetPath()
		{
			return HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/OnLineServer.xml");
		}
		public void LoadXml()
		{
			this.xmlDoc = new XmlDocument();
			this.xmlDoc.Load(this.GetPath());
		}
		public DataTable Search(string name, string type)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			DataTable result;
			if (name != "-1" && type != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("Name='" + name + "' AND Type=" + type);
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (name != "-1" && type == "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("Name='" + name + "'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (name == "-1" && type != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("Type=" + type);
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (dataSet.Tables.Count > 0)
			{
				result = dataSet.Tables[0];
			}
			else
			{
				result = null;
			}
			return result;
		}
		public DataTable Search(string name, string type, string SubstationID)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPathNew(SubstationID));
			DataTable result;
			if (name != "-1" && type != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("Name='" + name + "' AND Type=" + type);
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (name != "-1" && type == "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("Name='" + name + "'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (name == "-1" && type != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("Type=" + type);
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (dataSet.Tables.Count > 0)
			{
				result = dataSet.Tables[0];
			}
			else
			{
				result = null;
			}
			return result;
		}
		public string GetIsShowByID(string string_0)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			string result;
			if (string_0 != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("id=" + string_0);
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>().Rows[0]["IsShow"].ToString();
				}
				else
				{
					result = "-1";
				}
			}
			else if (dataSet.Tables.Count > 0)
			{
				result = dataSet.Tables[0].Rows[0]["IsShow"].ToString();
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		public int Update(string[] string_0, string[] isshow)
		{
			this.LoadXml();
			XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("Servers").ChildNodes;
			for (int i = 0; i < string_0.Length; i++)
			{
				XmlElement xmlElement = childNodes[i] as XmlElement;
				if (xmlElement.GetAttribute("id") == string_0[i])
				{
					xmlElement.SetAttribute("IsShow", isshow[i]);
					this.UpdateIsShow(xmlElement.GetAttribute("Name"), xmlElement.GetAttribute("IsShow"));
				}
			}
			int result;
			try
			{
				this.xmlDoc.Save(this.GetPath());
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Update(string[] string_0, string[] isshow, string SubstationID)
		{
			this.LoadXmlNew(SubstationID);
			XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("Servers").ChildNodes;
			for (int i = 0; i < string_0.Length; i++)
			{
				XmlElement xmlElement = childNodes[i] as XmlElement;
				if (xmlElement.GetAttribute("id") == string_0[i])
				{
					xmlElement.SetAttribute("IsShow", isshow[i]);
					this.UpdateIsShow(xmlElement.GetAttribute("Name"), xmlElement.GetAttribute("IsShow"), SubstationID);
				}
			}
			int result;
			try
			{
				this.xmlDoc.Save(this.GetPathNew(SubstationID));
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public string GetPathNew(string SubstationID)
		{
			string result;
			if (SubstationID == "all")
			{
				result = HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/OnLineServer.xml");
			}
			else
			{
				result = HttpContext.Current.Server.MapPath("~/City/" + SubstationID + "/Themes/Skin_Default/Xml/OnLineServer.xml");
			}
			return result;
		}
		public void LoadXmlNew(string SubstationID)
		{
			this.xmlDoc = new XmlDocument();
			this.xmlDoc.Load(this.GetPathNew(SubstationID));
		}
		public int UpdateIsShow(string type, string isshow)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" update ShopNum1_OnlineService ");
			stringBuilder.Append(" set ISshow='" + isshow + "'");
			stringBuilder.Append(" where  Type='" + type + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int UpdateIsShow(string type, string isshow, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" update ShopNum1_OnlineService ");
			stringBuilder.Append(" set ISshow='" + isshow + "'");
			stringBuilder.Append(" where  Type='" + type + "'");
			stringBuilder.Append("  and   SubstationID='" + SubstationID + "'       ");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
	}
}
