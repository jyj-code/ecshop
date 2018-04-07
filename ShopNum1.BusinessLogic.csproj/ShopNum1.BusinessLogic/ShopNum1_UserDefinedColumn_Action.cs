using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_UserDefinedColumn_Action : IShopNum1_UserDefinedColumn_Action
	{
		public int Delete(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE FROM ShopNum1_UserDefinedColumn WHERE [Guid] in (" + guid + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int CreateAgentMenu(string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'首页','Default','0','1','0','首页','1','admin','2011-6-8 14:27:23','admin','2011-8-11 9:48:18','0','1','1','1','" + SubstationID + "');        ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'手机','#','0','1','1','手机','56','admin','2012-12-4 15:20:53','admin','2012-12-4 15:20:53','0','1','1','1','" + SubstationID + "');        ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'抢购','PanicBuyList','1','1','1','抢购商品','44','admin','2011-8-6 14:06:16','admin','2012-11-27 14:27:04','0','1','1','1','" + SubstationID + "');        ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'购物','ProductShow','0','0','0','商城购物','41','admin','2011-6-8 14:33:41','admin','2012-12-19 10:25:25','0','1','0','1','" + SubstationID + "');        ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'店铺','RecommendShopList','0','1','0','商城店铺','3','admin','2011-6-8 14:33:16','admin','2012-12-31 11:28:41','0','1','0','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'购物','ProductShow','1','1','1','商城购物','43','admin','2011-8-6 14:05:06','admin','2012-11-27 14:29:44','0','1','1','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'论坛','http://www.shopnum1.com/bbs/index.aspx','0','1','1','论坛','54','admin','2012-12-4 15:12:51','admin','2012-12-19 10:24:17','0','1','1','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'资讯','News_List','0','1','0','资讯1','4','admin','2011-6-8 14:35:13','admin','2012-11-27 14:27:49','0','1','1','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'优惠券','CouponsList','0','1','0','电子优惠券','40','admin','2011-6-8 14:31:19','admin','2012-12-4 15:10:55','0','1','0','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'供求','SupplyDemandList','0','1','0','供求','39','admin','2011-6-8 14:34:20','admin','2013-1-22 15:48:59','0','1','0','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'团购','SpellBuyList','1','1','1','团购商品','42','admin','2011-8-6 14:04:35','admin','2012-11-27 14:27:12','0','1','1','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'快递','Express.aspx','0','1','1','快递','55','admin','2012-12-4 15:15:54','admin','2012-12-4 15:15:54','0','1','1','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'积分','Integral','0','1','1','积分','53','admin','2012-12-4 15:12:29','admin','2013-2-18 16:51:05','0','1','1','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'品牌','BrandMoreSearch','2','1','1','品牌中心','48','admin','2011-8-6 14:12:41','admin','2012-11-27 14:26:35','0','1','1','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'抢购','PanicBuyList','0','1','0','抢购商品','51','admin','2012-10-8 9:42:10','admin','2012-11-27 14:26:10','0','1','0','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'团购','SpellBuyList','0','1','0','商城团购','50','admin','2011-9-14 18:47:07','admin','2012-12-4 15:10:39','0','1','1','1','" + SubstationID + "');       ");
			stringBuilder.Append("  insert into ShopNum1_UserDefinedColumn(Guid,Name,LinkAddress,ShowLocation,IfShow,IfOpen,Remark,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsMember,IsShop,IsSite,SubstationID)values(newid(),'店铺','ShopList','2','1','0','店铺','37','admin','2011-6-8 14:28:06','admin','2012-11-27 14:28:20','0','1','0','1','" + SubstationID + "');       ");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetButtomNavigation(string showCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append(" TOP  " + showCount);
			stringBuilder.Append(" Guid,");
			stringBuilder.Append("Name,");
			stringBuilder.Append("LinkAddress,");
			stringBuilder.Append("ShowLocation,");
			stringBuilder.Append("IfShow,");
			stringBuilder.Append("IfOpen,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_UserDefinedColumn");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" ShowLocation='1' AND IfShow=1 ");
			stringBuilder.Append(" ORDER BY OrderID  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetEditInfo(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Name,");
			stringBuilder.Append("LinkAddress,");
			stringBuilder.Append("ShowLocation,");
			stringBuilder.Append("IfShow,");
			stringBuilder.Append("IfOpen,");
			stringBuilder.Append("IsShop,");
			stringBuilder.Append("IsMember,");
			stringBuilder.Append("IsSite,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_UserDefinedColumn");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("Guid = " + guid);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetTopNavigation(string showCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append(" TOP  " + showCount);
			stringBuilder.Append(" Guid,");
			stringBuilder.Append("Name,");
			stringBuilder.Append("LinkAddress,");
			stringBuilder.Append("ShowLocation,");
			stringBuilder.Append("IfOpen,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("OrderID");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_UserDefinedColumn");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" ShowLocation='2' AND IfShow=1");
			stringBuilder.Append(" ORDER BY OrderID  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Insert(ShopNum1_UserDefinedColumn shopNum1_UserDefinedColumn)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_UserDefinedColumn(");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Name,");
			stringBuilder.Append("LinkAddress,");
			stringBuilder.Append("ShowLocation,");
			stringBuilder.Append("IfOpen,");
			stringBuilder.Append("IfShow,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime,");
			stringBuilder.Append("IsShop,");
			stringBuilder.Append("IsMember,");
			stringBuilder.Append("SubstationID,");
			stringBuilder.Append("IsSite)");
			stringBuilder.Append(" VALUES(");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.Guid + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_UserDefinedColumn.Name) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_UserDefinedColumn.LinkAddress) + "',");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.ShowLocation + "',");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.IfOpen + "',");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.IfShow + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_UserDefinedColumn.Remark) + "',");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.OrderID + "',");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.CreateUser + "',");
			stringBuilder.Append("getdate(),");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.ModifyUser + "',");
			stringBuilder.Append("getdate(),");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.IsShop + "',");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.IsMember + "',");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.SubstationID + "',");
			stringBuilder.Append("'" + shopNum1_UserDefinedColumn.IsSite + "')");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable Search(string Name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Name,");
			stringBuilder.Append("LinkAddress,");
			stringBuilder.Append("ShowLocation,");
			stringBuilder.Append("IfShow,");
			stringBuilder.Append("IsMember,");
			stringBuilder.Append("IsShop,");
			stringBuilder.Append("IfOpen,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("SubstationID,");
			stringBuilder.Append("ModifyTime");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_UserDefinedColumn");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" IsDeleted = 0");
			stringBuilder.Append(" ORDER BY OrderID DESC ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string Name, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Name,");
			stringBuilder.Append("LinkAddress,");
			stringBuilder.Append("ShowLocation,");
			stringBuilder.Append("IfShow,");
			stringBuilder.Append("IsMember,");
			stringBuilder.Append("IsShop,");
			stringBuilder.Append("IfOpen,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("SubstationID,");
			stringBuilder.Append("ModifyTime");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_UserDefinedColumn");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" IsDeleted = 0");
			if (SubstationID != "-1")
			{
				stringBuilder.Append("   AND SubstationID='" + SubstationID + "'    ");
			}
			stringBuilder.Append(" ORDER BY OrderID DESC ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchMiddleNavigation(string showCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append(" TOP  " + showCount);
			stringBuilder.Append(" Guid,");
			stringBuilder.Append("Name,");
			stringBuilder.Append("LinkAddress,");
			stringBuilder.Append("ShowLocation,");
			stringBuilder.Append("IfShow,");
			stringBuilder.Append("IfOpen,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_UserDefinedColumn");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" ShowLocation='0' AND IfShow=1");
			stringBuilder.Append(" ORDER BY OrderID  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchMiddleNavigation(string showCount, int type)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append(" TOP  " + showCount);
			stringBuilder.Append(" Guid,");
			stringBuilder.Append("Name,");
			stringBuilder.Append("LinkAddress,");
			stringBuilder.Append("ShowLocation,");
			stringBuilder.Append("IfShow,");
			stringBuilder.Append("IfOpen,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("OrderID");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_UserDefinedColumn");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" ShowLocation='0' AND IfShow=1");
			switch (type)
			{
			case 1:
				stringBuilder.Append(" AND IsSite=1");
				break;
			case 2:
				stringBuilder.Append(" AND IsMember=1");
				break;
			case 3:
				stringBuilder.Append(" AND IsShop=1");
				break;
			}
			stringBuilder.Append(" ORDER BY OrderID  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchMiddleNavigation(string showCount, int type, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append(" TOP  " + showCount);
			stringBuilder.Append(" Guid,");
			stringBuilder.Append("Name,");
			stringBuilder.Append("LinkAddress,");
			stringBuilder.Append("ShowLocation,");
			stringBuilder.Append("IfShow,");
			stringBuilder.Append("IfOpen,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("OrderID");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_UserDefinedColumn");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" ShowLocation='0' AND IfShow=1  AND   SubstationID='" + SubstationID + "'  ");
			switch (type)
			{
			case 1:
				stringBuilder.Append(" AND IsSite=1");
				break;
			case 2:
				stringBuilder.Append(" AND IsMember=1");
				break;
			case 3:
				stringBuilder.Append(" AND IsShop=1");
				break;
			}
			stringBuilder.Append(" ORDER BY OrderID  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Update(ShopNum1_UserDefinedColumn shopNum1_UserDefinedColumn)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_UserDefinedColumn");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("Name = '" + Operator.FilterString(shopNum1_UserDefinedColumn.Name) + "',");
			stringBuilder.Append("LinkAddress = '" + Operator.FilterString(shopNum1_UserDefinedColumn.LinkAddress) + "',");
			stringBuilder.Append("ShowLocation = '" + shopNum1_UserDefinedColumn.ShowLocation + "',");
			stringBuilder.Append("IfShow = '" + shopNum1_UserDefinedColumn.IfShow + "',");
			stringBuilder.Append("IfOpen = '" + shopNum1_UserDefinedColumn.IfOpen + "',");
			stringBuilder.Append("IsShop = '" + shopNum1_UserDefinedColumn.IsShop + "',");
			stringBuilder.Append("IsMember = '" + shopNum1_UserDefinedColumn.IsMember + "',");
			stringBuilder.Append("IsSite = '" + shopNum1_UserDefinedColumn.IsSite + "',");
			stringBuilder.Append("Remark = '" + Operator.FilterString(shopNum1_UserDefinedColumn.Remark) + "',");
			stringBuilder.Append("OrderID = '" + shopNum1_UserDefinedColumn.OrderID + "',");
			stringBuilder.Append("ModifyUser = '" + shopNum1_UserDefinedColumn.ModifyUser + "',");
			stringBuilder.Append("ModifyTime = getdate()");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("Guid = '" + shopNum1_UserDefinedColumn.Guid + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
	}
}
