namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_ShopEnsure")]
    public class ShopNum1_ShopEnsure
    {
        private decimal _EnsureMoney;
        private string _Href;
        private int _ID;
        private string _ImagePath;
        private string _MemberLoginID;
        private string _Name;
        private string _Remark;

        [Column(Storage="_EnsureMoney", DbType="Decimal(18,2) NOT NULL")]
        public decimal EnsureMoney
        {
            get
            {
                return this._EnsureMoney;
            }
            set
            {
                if (this._EnsureMoney != value)
                {
                    this._EnsureMoney = value;
                }
            }
        }

        [Column(Storage="_Href", DbType="NVarChar(150)")]
        public string Href
        {
            get
            {
                return this._Href;
            }
            set
            {
                if (this._Href != value)
                {
                    this._Href = value;
                }
            }
        }

        [Column(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this._ID = value;
                }
            }
        }

        [Column(Storage="_ImagePath", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string ImagePath
        {
            get
            {
                return this._ImagePath;
            }
            set
            {
                if (this._ImagePath != value)
                {
                    this._ImagePath = value;
                }
            }
        }

        [Column(Storage="_MemberLoginID", DbType="NVarChar(50)")]
        public string MemberLoginID
        {
            get
            {
                return this._MemberLoginID;
            }
            set
            {
                if (this._MemberLoginID != value)
                {
                    this._MemberLoginID = value;
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

        [Column(Storage="_Remark", DbType="NVarChar(250)")]
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                if (this._Remark != value)
                {
                    this._Remark = value;
                }
            }
        }
    }
}

