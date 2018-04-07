namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_IPInfo")]
    public class ShopNum1_IPInfo
    {
        private System.Guid _Guid;
        private string _IPGroupGuid;
        private string _IPName;
        private int _IsForbid;

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

        [Column(Storage="_IPGroupGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string IPGroupGuid
        {
            get
            {
                return this._IPGroupGuid;
            }
            set
            {
                if (this._IPGroupGuid != value)
                {
                    this._IPGroupGuid = value;
                }
            }
        }

        [Column(Storage="_IPName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string IPName
        {
            get
            {
                return this._IPName;
            }
            set
            {
                if (this._IPName != value)
                {
                    this._IPName = value;
                }
            }
        }

        [Column(Storage="_IsForbid", DbType="Int NOT NULL")]
        public int IsForbid
        {
            get
            {
                return this._IsForbid;
            }
            set
            {
                if (this._IsForbid != value)
                {
                    this._IsForbid = value;
                }
            }
        }
    }
}

