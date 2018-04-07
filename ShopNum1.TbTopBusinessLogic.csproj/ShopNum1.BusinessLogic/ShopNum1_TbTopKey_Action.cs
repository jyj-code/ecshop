using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.TbLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_TbTopKey_Action : IShopNum1_TbTopKey_Action
	{
		[CompilerGenerated]
		private sealed class Class2
		{
			public ShopNum1_TbTopKey shopNum1_TbTopKey_0;
		}
		[CompilerGenerated]
		private sealed class Class3
		{
			public string string_0;
		}
		[CompilerGenerated]
		private sealed class Class4
		{
			public string string_0;
		}
		private ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext_0 = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
		public bool AddTbTopKey(ShopNum1_TbTopKey tbtopkey)
		{
			bool result;
			try
			{
				ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
				shopNum1_TbLinqDataContext.ShopNum1_TbTopKeys.InsertOnSubmit(tbtopkey);
				shopNum1_TbLinqDataContext.SubmitChanges();
				result = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public bool UpdateTopKey(ShopNum1_TbTopKey tbtopkey)
		{
			bool result;
			try
			{
				IQueryable<ShopNum1_TbTopKey> queryable = 
					from v in this.shopNum1_TbLinqDataContext_0.ShopNum1_TbTopKeys
					where v.MemloginID == tbtopkey.MemloginID
					select v;
				foreach (ShopNum1_TbTopKey current in queryable)
				{
					current.AppKey = tbtopkey.AppKey;
					current.AppSecret = tbtopkey.AppSecret;
					current.IsForbid = tbtopkey.IsForbid;
					current.ModifyTime = tbtopkey.ModifyTime;
					current.URL = tbtopkey.URL;
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
		public ShopNum1_TbTopKey SearchTopKey(string memlogid)
		{
			ShopNum1_TbTopKey result;
			try
			{
				IQueryable<ShopNum1_TbTopKey> queryable = 
					from v in this.shopNum1_TbLinqDataContext_0.ShopNum1_TbTopKeys
					where v.MemloginID == memlogid
					select v;
				using (IEnumerator<ShopNum1_TbTopKey> enumerator = queryable.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						ShopNum1_TbTopKey current = enumerator.Current;
						result = current;
						return result;
					}
				}
			}
			catch (Exception)
			{
				result = null;
				return result;
			}
			result = null;
			return result;
		}
		public bool Delete(string memlogid)
		{
			bool result;
			try
			{
				IQueryable<ShopNum1_TbTopKey> entities = 
					from v in this.shopNum1_TbLinqDataContext_0.ShopNum1_TbTopKeys
					where v.MemloginID == memlogid
					select v;
				this.shopNum1_TbLinqDataContext_0.ShopNum1_TbTopKeys.DeleteAllOnSubmit<ShopNum1_TbTopKey>(entities);
				this.shopNum1_TbLinqDataContext_0.SubmitChanges();
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
