using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Xml;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_OnLineService_Action : IShop_OnLineService_Action
	{
		public XmlDocument xmlDoc;
		[CompilerGenerated]
		private string string_0;
		public string StrPath
		{
			get;
			set;
		}
		public int AddOnLineService(ShopNum1_Shop_OnlineService onlineService)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@type";
			array2[0] = onlineService.Type;
			array[1] = "@name";
			array2[1] = onlineService.Name;
			array[2] = "@serviceaccount";
			array2[2] = onlineService.ServiceAccount;
			array[3] = "@isshow";
			array2[3] = onlineService.IsShow.ToString();
			array[4] = "@orderid";
			array2[4] = onlineService.OrderID.ToString();
			array[5] = "@memloginid";
			array2[5] = onlineService.MemLoginID;
			array[6] = "@TypeName";
			array2[6] = onlineService.TypeName;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddOnLineService", array, array2);
		}
		public DataTable GetOnLineServiceList(string memloginid, string type, string isshow)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@type";
			array2[1] = type;
			array[2] = "@isshow";
			array2[2] = isshow;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOnLineServiceList", array, array2);
		}
		public DataTable GetOnLineService(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOnLineService", array, array2);
		}
		public int UpdateOnLineService(ShopNum1_Shop_OnlineService onlineService)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@guid";
			array2[0] = onlineService.Guid.ToString();
			array[1] = "@type";
			array2[1] = onlineService.Type;
			array[2] = "@name";
			array2[2] = onlineService.Name;
			array[3] = "@serviceaccount";
			array2[3] = onlineService.ServiceAccount;
			array[4] = "@isshow";
			array2[4] = onlineService.IsShow.ToString();
			array[5] = "@orderid";
			array2[5] = onlineService.OrderID.ToString();
			array[6] = "@TypeName";
			array2[6] = onlineService.TypeName.ToString();
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateOnLineService", array, array2);
		}
		public int DeleteOnLineService(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteOnLineService", array, array2);
		}
		public DataTable GetOnLineServiceList1(string memloginid, string type, string showcount)
		{
			string text = string.Empty;
			text = text + " select top " + showcount + "  *  from ShopNum1_Shop_OnlineService";
			text = text + " where  MemLoginID='" + memloginid + "' ";
			text = text + "  and  Type='" + type + "' ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"  and  IsShow='",
				1,
				"' "
			});
			text += " order by orderid asc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetPath()
		{
			return HttpContext.Current.Server.MapPath(this.StrPath);
		}
		public void LoadXml()
		{
			this.xmlDoc = new XmlDocument();
			this.xmlDoc.Load(this.GetPath());
		}
		public DataTable Search(string name, string type, string strPath)
		{
			this.StrPath = strPath;
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			if (name != "-1" && type != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("Name='" + name + "' AND Type=" + type);
				if (array.Length > 0)
				{
					return array.CopyToDataTable<DataRow>();
				}
				return null;
			}
			else if (name != "-1" && type == "-1")
			{
				DataRow[] array2 = dataSet.Tables[0].Select("Name='" + name + "'");
				if (array2.Length > 0)
				{
					return array2.CopyToDataTable<DataRow>();
				}
				return null;
			}
			else if (name == "-1" && type != "-1")
			{
				DataRow[] array3 = dataSet.Tables[0].Select("Type=" + type);
				if (array3.Length > 0)
				{
					return array3.CopyToDataTable<DataRow>();
				}
				return null;
			}
			else
			{
				if (dataSet.Tables.Count > 0)
				{
					return dataSet.Tables[0];
				}
				return null;
			}
		}
		public string GetIsShowByID(string string_1)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			if (string_1 != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("id=" + string_1);
				if (array.Length > 0)
				{
					return array.CopyToDataTable<DataRow>().Rows[0]["IsShow"].ToString();
				}
				return "-1";
			}
			else
			{
				if (dataSet.Tables.Count > 0)
				{
					return dataSet.Tables[0].Rows[0]["IsShow"].ToString();
				}
				return "-1";
			}
		}
		public int Update(string[] string_1, string[] isshow, string strPath, string memloginid)
		{
			this.StrPath = strPath;
			this.LoadXml();
			XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("Servers").ChildNodes;
			for (int i = 0; i < string_1.Length; i++)
			{
				XmlElement xmlElement = childNodes[i] as XmlElement;
				if (xmlElement.GetAttribute("id") == string_1[i])
				{
					xmlElement.SetAttribute("IsShow", isshow[i]);
					this.UpdateIsShow(xmlElement.GetAttribute("Name"), memloginid, xmlElement.GetAttribute("IsShow"));
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
		public int UpdateIsShow(string type, string shopid, string isshow)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" update ShopNum1_Shop_OnlineService ");
			stringBuilder.Append(" set ISshow='" + isshow + "'");
			stringBuilder.Append("  where  MemLoginID='" + shopid + "'");
			stringBuilder.Append(" and Type='" + type + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable SelectOnLineService_List(CommonPageModel commonModel)
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
			array2[3] = commonModel.Tablename;
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
		public int UpdateShopOnlinePhone(ShopNum1_Shop_OnlineService onlineService)
		{
			if (onlineService.Guid.ToString() != "")
			{
				return this.UpdateOnLineService(onlineService);
			}
			return this.AddOnLineService(onlineService);
		}
	}
}
