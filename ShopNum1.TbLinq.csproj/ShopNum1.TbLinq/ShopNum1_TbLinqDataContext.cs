using ShopNum1.TbLinq.Properties;
using System;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
namespace ShopNum1.TbLinq
{
	[Database(Name = "ShopNum1_MultiV7.2")]
	public class ShopNum1_TbLinqDataContext : DataContext
	{
		private static MappingSource mappingSource = new AttributeMappingSource();
		public Table<ShopNum1_TbAddress> ShopNum1_TbAddresses
		{
			get
			{
				return base.GetTable<ShopNum1_TbAddress>();
			}
		}
		public Table<ShopNum1_TbSystem> ShopNum1_TbSystems
		{
			get
			{
				return base.GetTable<ShopNum1_TbSystem>();
			}
		}
		public Table<ShopNum1_TbTopKey> ShopNum1_TbTopKeys
		{
			get
			{
				return base.GetTable<ShopNum1_TbTopKey>();
			}
		}
		public Table<ShopNum1_TbSellCat> ShopNum1_TbSellCats
		{
			get
			{
				return base.GetTable<ShopNum1_TbSellCat>();
			}
		}
		public Table<ShopNum1_TbItem> ShopNum1_TbItems
		{
			get
			{
				return base.GetTable<ShopNum1_TbItem>();
			}
		}
		public ShopNum1_TbLinqDataContext() : base(Settings.Default.ShopNum1_MultiV7_2ConnectionString2, ShopNum1_TbLinqDataContext.mappingSource)
		{
		}
		public ShopNum1_TbLinqDataContext(string connection) : base(connection, ShopNum1_TbLinqDataContext.mappingSource)
		{
		}
		public ShopNum1_TbLinqDataContext(IDbConnection connection) : base(connection, ShopNum1_TbLinqDataContext.mappingSource)
		{
		}
		public ShopNum1_TbLinqDataContext(string connection, MappingSource mappingSource) : base(connection, mappingSource)
		{
		}
		public ShopNum1_TbLinqDataContext(IDbConnection connection, MappingSource mappingSource) : base(connection, mappingSource)
		{
		}
		[Function(Name = "dbo.Pro_ShopNum1_TbSystemCheckBind")]
		public ISingleResult<Pro_ShopNum1_TbSystemCheckBindResult> Pro_ShopNum1_TbSystemCheckBind([Parameter(DbType = "NVarChar(100)")] string tbShopName, [Parameter(Name = "Memlogid", DbType = "NVarChar(100)")] string memlogid)
		{
			IExecuteResult executeResult = base.ExecuteMethodCall(this, (MethodInfo)MethodBase.GetCurrentMethod(), new object[]
			{
				tbShopName,
				memlogid
			});
			return (ISingleResult<Pro_ShopNum1_TbSystemCheckBindResult>)executeResult.ReturnValue;
		}
		[Function(Name = "dbo.Pro_ShopNum1_TbSystem_Insert")]
		public int Pro_ShopNum1_TbSystem_Insert([Parameter(DbType = "NVarChar(100)")] string tbShopName, [Parameter(Name = "Memlogid", DbType = "NVarChar(100)")] string memlogid)
		{
			IExecuteResult executeResult = base.ExecuteMethodCall(this, (MethodInfo)MethodBase.GetCurrentMethod(), new object[]
			{
				tbShopName,
				memlogid
			});
			return (int)executeResult.ReturnValue;
		}
		[Function(Name = "dbo.Pro_ShopNum1_TbSellCat_Delete")]
		public int Pro_ShopNum1_TbSellCat_Delete([Parameter(DbType = "NVarChar(200)")] string shopname, [Parameter(DbType = "NVarChar(50)")] string memlogid, [Parameter(DbType = "Decimal")] decimal? cid, [Parameter(DbType = "Decimal")] decimal? site_cid)
		{
			IExecuteResult executeResult = base.ExecuteMethodCall(this, (MethodInfo)MethodBase.GetCurrentMethod(), new object[]
			{
				shopname,
				memlogid,
				cid,
				site_cid
			});
			return (int)executeResult.ReturnValue;
		}
	}
}
