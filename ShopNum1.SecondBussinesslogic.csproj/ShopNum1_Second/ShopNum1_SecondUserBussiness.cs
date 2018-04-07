using ShopNum1.Second;
using System;
namespace ShopNum1_Second
{
	public class ShopNum1_SecondUserBussiness
	{
		private readonly ShopNum1_SecondUserAccess shopNum1_SecondUserAccess_0 = new ShopNum1_SecondUserAccess();
		public int GetMaxId()
		{
			return this.shopNum1_SecondUserAccess_0.GetMaxId();
		}
		public bool Exists(int ID)
		{
			return this.shopNum1_SecondUserAccess_0.Exists(ID);
		}
		public string GetMemLogid(string SecondID, string Secondtype)
		{
			object memLogid = this.shopNum1_SecondUserAccess_0.GetMemLogid(SecondID, Secondtype);
			string result;
			if (memLogid == null)
			{
				result = "";
			}
			else
			{
				result = memLogid.ToString();
			}
			return result;
		}
		public bool Add(ShopNum1_SecondUser model)
		{
			return this.shopNum1_SecondUserAccess_0.Add(model);
		}
		public bool Update(ShopNum1_SecondUser model)
		{
			return this.shopNum1_SecondUserAccess_0.Update(model);
		}
		public bool Delete(int ID)
		{
			return this.shopNum1_SecondUserAccess_0.Delete(ID);
		}
	}
}
