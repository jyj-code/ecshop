using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.TbLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_TbAddress_Action : IShopNum1_TbAddress_Action
	{
		[CompilerGenerated]
		private sealed class Class5
		{
			public int int_0;
		}
		public List<ShopNum1_TbAddress> GetAllProvince()
		{
			ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
			List<ShopNum1_TbAddress> list = new List<ShopNum1_TbAddress>();
			List<ShopNum1_TbAddress> result;
			try
			{
				IQueryable<ShopNum1_TbAddress> queryable = 
					from v in shopNum1_TbLinqDataContext.ShopNum1_TbAddresses
					where v.parent_Id == (int?)0
					select v;
				foreach (ShopNum1_TbAddress current in queryable)
				{
					list.Add(current);
				}
				result = list;
			}
			catch (Exception)
			{
				result = list;
			}
			return result;
		}
		public List<ShopNum1_TbAddress> GetCitysByParent(int parentId)
		{
			ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
			List<ShopNum1_TbAddress> list = new List<ShopNum1_TbAddress>();
			List<ShopNum1_TbAddress> result;
			try
			{
				IOrderedQueryable<ShopNum1_TbAddress> orderedQueryable = 
					from v in shopNum1_TbLinqDataContext.ShopNum1_TbAddresses
					where v.parent_Id == (int?)parentId
					orderby v.Id descending
					select v;
				foreach (ShopNum1_TbAddress current in orderedQueryable)
				{
					list.Add(current);
				}
				result = list;
			}
			catch (Exception)
			{
				result = list;
			}
			return result;
		}
		public bool InsertTbAreas(ShopNum1_TbAddress tbAreas)
		{
			ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
			bool result;
			try
			{
				shopNum1_TbLinqDataContext.ShopNum1_TbAddresses.InsertOnSubmit(tbAreas);
				shopNum1_TbLinqDataContext.SubmitChanges();
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
