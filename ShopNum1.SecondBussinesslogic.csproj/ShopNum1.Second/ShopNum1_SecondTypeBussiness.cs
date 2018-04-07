using ShopNum1.Second;
using System;
using System.Data;
namespace ShopNum1.Second
{
	public class ShopNum1_SecondTypeBussiness
	{
		private readonly ShopNum1_SecondTypeAccess shopNum1_SecondTypeAccess_0 = new ShopNum1_SecondTypeAccess();
		public int GetMaxOrderId()
		{
			return this.shopNum1_SecondTypeAccess_0.GetMaxOrderId();
		}
		public bool Exists(int ID)
		{
			return this.shopNum1_SecondTypeAccess_0.Exists(ID);
		}
		public bool Add(ShopNum1_SecondType model)
		{
			return this.shopNum1_SecondTypeAccess_0.Add(model);
		}
		public bool Update(ShopNum1_SecondType model)
		{
			return this.shopNum1_SecondTypeAccess_0.Update(model);
		}
		public bool Delete(int ID)
		{
			return this.shopNum1_SecondTypeAccess_0.Delete(ID);
		}
		public DataTable GetModel(int ID)
		{
			return this.shopNum1_SecondTypeAccess_0.GetModel(ID);
		}
		public DataTable GetSecondByCount(string count, string isAvabile)
		{
			return this.shopNum1_SecondTypeAccess_0.GetSecondByCount(count, isAvabile);
		}
	}
}
