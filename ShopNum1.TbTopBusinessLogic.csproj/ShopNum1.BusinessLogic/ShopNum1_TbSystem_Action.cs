using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.TbLinq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_TbSystem_Action : IShopNum1_TbSystem_Action
	{
		[CompilerGenerated]
		private sealed class Class0
		{
			public ShopNum1_TbSystem shopNum1_TbSystem_0;
		}
		[CompilerGenerated]
		private sealed class Class1
		{
			public string string_0;
		}
		private ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext_0 = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
		[CompilerGenerated]
		private static Func<Pro_ShopNum1_TbSystemCheckBindResult, Pro_ShopNum1_TbSystemCheckBindResult> func_0;
		public bool UpdateTbSystem(ShopNum1_TbSystem tbSystem)
		{
			bool result;
			try
			{
				IQueryable<ShopNum1_TbSystem> queryable = 
					from v in this.shopNum1_TbLinqDataContext_0.ShopNum1_TbSystems
					where v.Memlogid == tbSystem.Memlogid && v.tbShopName == tbSystem.tbShopName
					select v;
				foreach (ShopNum1_TbSystem current in queryable)
				{
					current.hasTbOrder = tbSystem.hasTbOrder;
					current.hasTbRate = tbSystem.hasTbRate;
					current.isOpen = tbSystem.isOpen;
					current.siteCount = tbSystem.siteCount;
					current.siteDesc = tbSystem.siteDesc;
					current.siteImg = tbSystem.siteImg;
					current.siteItemName = tbSystem.siteItemName;
					current.siteItemPrice = tbSystem.siteItemPrice;
					current.siteSellCat = tbSystem.siteSellCat;
					current.tbCount = tbSystem.tbCount;
					current.tbDesc = tbSystem.tbDesc;
					current.tbImg = tbSystem.tbImg;
					current.tbItemName = tbSystem.tbItemName;
					current.tbItemPrice = tbSystem.tbItemPrice;
					current.tbSellCat = tbSystem.tbSellCat;
				}
				this.shopNum1_TbLinqDataContext_0.SubmitChanges();
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public bool InsertTbSystem(string memglogid, string shopname)
		{
			bool result;
			try
			{
				int num = this.shopNum1_TbLinqDataContext_0.Pro_ShopNum1_TbSystem_Insert(shopname, memglogid);
				if (num > 0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
		public bool CheckShopBind(string shopName, string memlgoid, out string Name)
		{
			Name = string.Empty;
			IEnumerable<Pro_ShopNum1_TbSystemCheckBindResult> arg_31_0 = this.shopNum1_TbLinqDataContext_0.Pro_ShopNum1_TbSystemCheckBind(shopName, memlgoid);
			if (ShopNum1_TbSystem_Action.func_0 == null)
			{
				ShopNum1_TbSystem_Action.func_0 = new Func<Pro_ShopNum1_TbSystemCheckBindResult, Pro_ShopNum1_TbSystemCheckBindResult>(ShopNum1_TbSystem_Action.smethod_0);
			}
			arg_31_0.Select(ShopNum1_TbSystem_Action.func_0);
			return true;
		}
		public ShopNum1_TbSystem GetTbSysem(string memlogid, string shopname)
		{
			ShopNum1_TbSystem result;
			try
			{
				ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
				List<ShopNum1_TbSystem> list = (
					from p in shopNum1_TbLinqDataContext.ShopNum1_TbSystems
					where p.Memlogid == memlogid
					select p).ToList<ShopNum1_TbSystem>();
				if (list != null && list.Count > 0)
				{
					result = list.First<ShopNum1_TbSystem>();
				}
				else
				{
					result = null;
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}
		public bool CheckTbUserBind(string tbShopName, string memlogid, out string shopName)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@tbshopname";
			array2[0] = tbShopName;
			array[1] = "@Memlogid";
			array2[1] = memlogid;
			DataSet dataSet = DatabaseExcetue.RunProcedureReturnDataSet("[Pro_ShopNum1_TbSystemCheckBind]", array, array2);
			int num = int.Parse(dataSet.Tables[0].Rows[0]["TotalCount"].ToString());
			bool result;
			if (num > 0)
			{
				shopName = dataSet.Tables[1].Rows[0]["tbShopName"].ToString();
				result = true;
			}
			else
			{
				shopName = dataSet.Tables[1].Rows[0]["tbShopName"].ToString();
				result = false;
			}
			return result;
		}
		public bool Remove(string memlogid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@Memlogid";
			array2[0] = memlogid;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbSystem_RemoveBind", array, array2) > 0;
		}
		[CompilerGenerated]
		private static Pro_ShopNum1_TbSystemCheckBindResult smethod_0(Pro_ShopNum1_TbSystemCheckBindResult pro_ShopNum1_TbSystemCheckBindResult_0)
		{
			return pro_ShopNum1_TbSystemCheckBindResult_0;
		}
	}
}
