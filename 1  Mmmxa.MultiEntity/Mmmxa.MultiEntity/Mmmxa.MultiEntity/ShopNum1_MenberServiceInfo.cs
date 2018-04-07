namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_MenberServiceInfo")]
    public class ShopNum1_MenberServiceInfo
    {
        private DateTime? _EndTime;
        private System.Guid? _Guid;
        private int? _OtherProductCount;
        private string _ServiceGuid;
        private int? _ServiceProductCount;
        private string _ShopName;

        [Column(Storage="_EndTime", DbType="DateTime")]
        public DateTime? EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                if (this._EndTime != value)
                {
                    this._EndTime = value;
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier")]
        public System.Guid? Guid
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

        [Column(Storage="_OtherProductCount", DbType="Int")]
        public int? OtherProductCount
        {
            get
            {
                return this._OtherProductCount;
            }
            set
            {
                if (this._OtherProductCount != value)
                {
                    this._OtherProductCount = value;
                }
            }
        }

        [Column(Storage="_ServiceGuid", DbType="NVarChar(50)")]
        public string ServiceGuid
        {
            get
            {
                return this._ServiceGuid;
            }
            set
            {
                if (this._ServiceGuid != value)
                {
                    this._ServiceGuid = value;
                }
            }
        }

        [Column(Storage="_ServiceProductCount", DbType="Int")]
        public int? ServiceProductCount
        {
            get
            {
                return this._ServiceProductCount;
            }
            set
            {
                if (this._ServiceProductCount != value)
                {
                    this._ServiceProductCount = value;
                }
            }
        }

        [Column(Storage="_ShopName", DbType="NVarChar(50)")]
        public string ShopName
        {
            get
            {
                return this._ShopName;
            }
            set
            {
                if (this._ShopName != value)
                {
                    this._ShopName = value;
                }
            }
        }
    }
}

