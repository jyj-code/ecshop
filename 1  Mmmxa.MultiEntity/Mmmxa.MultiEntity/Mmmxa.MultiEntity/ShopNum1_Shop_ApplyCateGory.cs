namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_ApplyCateGory")]
    public class ShopNum1_Shop_ApplyCateGory
    {
        private DateTime _ApplyTime;
        private string _BrandName;
        private System.Guid _Guid;
        private int _IsAudit;
        private System.Guid _NewBrandGuid;
        private string _NewShopCateGoryCode;
        private System.Guid? _OldBrandGuid;
        private string _OldBrandName;
        private string _OldShopCategoryCode;
        private string _OldShopCategoryName;
        private string _Remarks;
        private string _ShopCategoryName;
        private string _ShopID;
        private DateTime? _VerifyTime;

        [Column(Storage="_ApplyTime", DbType="DateTime NOT NULL")]
        public DateTime ApplyTime
        {
            get
            {
                return this._ApplyTime;
            }
            set
            {
                if (this._ApplyTime != value)
                {
                    this._ApplyTime = value;
                }
            }
        }

        [Column(Storage="_BrandName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string BrandName
        {
            get
            {
                return this._BrandName;
            }
            set
            {
                if (this._BrandName != value)
                {
                    this._BrandName = value;
                }
            }
        }

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

        [Column(Storage="_IsAudit", DbType="Int NOT NULL")]
        public int IsAudit
        {
            get
            {
                return this._IsAudit;
            }
            set
            {
                if (this._IsAudit != value)
                {
                    this._IsAudit = value;
                }
            }
        }

        [Column(Storage="_NewBrandGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid NewBrandGuid
        {
            get
            {
                return this._NewBrandGuid;
            }
            set
            {
                if (this._NewBrandGuid != value)
                {
                    this._NewBrandGuid = value;
                }
            }
        }

        [Column(Storage="_NewShopCateGoryCode", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
        public string NewShopCateGoryCode
        {
            get
            {
                return this._NewShopCateGoryCode;
            }
            set
            {
                if (this._NewShopCateGoryCode != value)
                {
                    this._NewShopCateGoryCode = value;
                }
            }
        }

        [Column(Storage="_OldBrandGuid", DbType="UniqueIdentifier")]
        public System.Guid? OldBrandGuid
        {
            get
            {
                return this._OldBrandGuid;
            }
            set
            {
                if (this._OldBrandGuid != value)
                {
                    this._OldBrandGuid = value;
                }
            }
        }

        [Column(Storage="_OldBrandName", DbType="NVarChar(100)")]
        public string OldBrandName
        {
            get
            {
                return this._OldBrandName;
            }
            set
            {
                if (this._OldBrandName != value)
                {
                    this._OldBrandName = value;
                }
            }
        }

        [Column(Storage="_OldShopCategoryCode", DbType="VarChar(20)")]
        public string OldShopCategoryCode
        {
            get
            {
                return this._OldShopCategoryCode;
            }
            set
            {
                if (this._OldShopCategoryCode != value)
                {
                    this._OldShopCategoryCode = value;
                }
            }
        }

        [Column(Storage="_OldShopCategoryName", DbType="NVarChar(100)")]
        public string OldShopCategoryName
        {
            get
            {
                return this._OldShopCategoryName;
            }
            set
            {
                if (this._OldShopCategoryName != value)
                {
                    this._OldShopCategoryName = value;
                }
            }
        }

        [Column(Storage="_Remarks", DbType="NVarChar(250)")]
        public string Remarks
        {
            get
            {
                return this._Remarks;
            }
            set
            {
                if (this._Remarks != value)
                {
                    this._Remarks = value;
                }
            }
        }

        [Column(Storage="_ShopCategoryName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string ShopCategoryName
        {
            get
            {
                return this._ShopCategoryName;
            }
            set
            {
                if (this._ShopCategoryName != value)
                {
                    this._ShopCategoryName = value;
                }
            }
        }

        [Column(Storage="_ShopID", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string ShopID
        {
            get
            {
                return this._ShopID;
            }
            set
            {
                if (this._ShopID != value)
                {
                    this._ShopID = value;
                }
            }
        }

        [Column(Storage="_VerifyTime", DbType="DateTime")]
        public DateTime? VerifyTime
        {
            get
            {
                return this._VerifyTime;
            }
            set
            {
                if (this._VerifyTime != value)
                {
                    this._VerifyTime = value;
                }
            }
        }
    }
}

