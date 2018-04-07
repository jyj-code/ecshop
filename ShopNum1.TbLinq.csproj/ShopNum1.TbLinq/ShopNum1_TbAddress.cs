using System;
using System.Data.Linq.Mapping;
namespace ShopNum1.TbLinq
{
	[Table(Name = "dbo.ShopNum1_TbAddress")]
	public class ShopNum1_TbAddress
	{
		private int? _Id;
		private byte? _type;
		private string _name;
		private int? _parent_Id;
		private string _zip;
		private string _mark;
		[Column(Storage = "_Id", DbType = "Int")]
		public int? Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if (this._Id != value)
				{
					this._Id = value;
				}
			}
		}
		[Column(Storage = "_type", DbType = "TinyInt")]
		public byte? type
		{
			get
			{
				return this._type;
			}
			set
			{
				if (this._type != value)
				{
					this._type = value;
				}
			}
		}
		[Column(Storage = "_name", DbType = "NVarChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (this._name != value)
				{
					this._name = value;
				}
			}
		}
		[Column(Storage = "_parent_Id", DbType = "Int")]
		public int? parent_Id
		{
			get
			{
				return this._parent_Id;
			}
			set
			{
				if (this._parent_Id != value)
				{
					this._parent_Id = value;
				}
			}
		}
		[Column(Storage = "_zip", DbType = "NVarChar(50)")]
		public string zip
		{
			get
			{
				return this._zip;
			}
			set
			{
				if (this._zip != value)
				{
					this._zip = value;
				}
			}
		}
		[Column(Storage = "_mark", DbType = "VarChar(4)")]
		public string mark
		{
			get
			{
				return this._mark;
			}
			set
			{
				if (this._mark != value)
				{
					this._mark = value;
				}
			}
		}
	}
}
