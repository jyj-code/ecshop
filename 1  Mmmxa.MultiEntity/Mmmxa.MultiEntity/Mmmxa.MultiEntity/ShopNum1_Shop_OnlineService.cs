namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_OnlineService")]
    public class ShopNum1_Shop_OnlineService
    {
        private System.Guid _Guid;
        private int _IsDeleted;
        private int _IsShow;
        private string _MemLoginID;
        private string _Name;
        private int _OrderID;
        private string _ServiceAccount;
        private string _Type;
        private string _TypeName;

        [Column(Storage="_Guid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid Guid
        {
            get
            {
                return this._Guid;
            }
            set
            {
                if (this._Guid != value)
                {
                    this._Guid = value;
                }
            }
        }

        [Column(Storage="_IsDeleted", DbType="Int NOT NULL")]
        public int IsDeleted
        {
            get
            {
                return this._IsDeleted;
            }
            set
            {
                if (this._IsDeleted != value)
                {
                    this._IsDeleted = value;
                }
            }
        }

        [Column(Storage="_IsShow", DbType="Int NOT NULL")]
        public int IsShow
        {
            get
            {
                return this._IsShow;
            }
            set
            {
                if (this._IsShow != value)
                {
                    this._IsShow = value;
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string MemLoginID
        {
            get
            {
                return this._MemLoginID;
            }
            set
            {
                if (this._MemLoginID != value)
                {
                    this._MemLoginID = value;
                }
            }
        }

        [Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (this._Name != value)
                {
                    this._Name = value;
                }
            }
        }

        [Column(Storage="_OrderID", DbType="Int NOT NULL")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                if (this._OrderID != value)
                {
                    this._OrderID = value;
                }
            }
        }

        [Column(Storage="_ServiceAccount", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
        public string ServiceAccount
        {
            get
            {
                return this._ServiceAccount;
            }
            set
            {
                if (this._ServiceAccount != value)
                {
                    this._ServiceAccount = value;
                }
            }
        }

        [Column(Storage="_Type", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                if (this._Type != value)
                {
                    this._Type = value;
                }
            }
        }

        [Column(Storage="_TypeName", CanBeNull=false)]
        public string TypeName
        {
            get
            {
                return this._TypeName;
            }
            set
            {
                if (this._TypeName != value)
                {
                    this._TypeName = value;
                }
            }
        }
    }
}

