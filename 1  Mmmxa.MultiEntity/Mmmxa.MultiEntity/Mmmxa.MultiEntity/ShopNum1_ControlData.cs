namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_ControlData")]
    public class ShopNum1_ControlData
    {
        private string _ControlGuid;
        private DateTime _CreateTime;
        private string _CreateUser;
        private int _DataType;
        private int _GroupID;
        private System.Guid _Guid;
        private string _Href;
        private string _Image;
        private int _IsShow;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private int _OrderID;
        private decimal _Price;
        private string _Title;

        [Column(Storage="_ControlGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ControlGuid
        {
            get
            {
                return this._ControlGuid;
            }
            set
            {
                if (this._ControlGuid != value)
                {
                    this._ControlGuid = value;
                }
            }
        }

        [Column(Storage="_CreateTime", DbType="DateTime NOT NULL")]
        public DateTime CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                if (this._CreateTime != value)
                {
                    this._CreateTime = value;
                }
            }
        }

        [Column(Storage="_CreateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CreateUser
        {
            get
            {
                return this._CreateUser;
            }
            set
            {
                if (this._CreateUser != value)
                {
                    this._CreateUser = value;
                }
            }
        }

        [Column(Storage="_DataType", DbType="Int NOT NULL")]
        public int DataType
        {
            get
            {
                return this._DataType;
            }
            set
            {
                if (this._DataType != value)
                {
                    this._DataType = value;
                }
            }
        }

        [Column(Storage="_GroupID", DbType="Int NOT NULL")]
        public int GroupID
        {
            get
            {
                return this._GroupID;
            }
            set
            {
                if (this._GroupID != value)
                {
                    this._GroupID = value;
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

        [Column(Storage="_Href", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_Image", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
        public string Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                if (this._Image != value)
                {
                    this._Image = value;
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

        [Column(Storage="_ModifyTime", DbType="DateTime NOT NULL")]
        public DateTime ModifyTime
        {
            get
            {
                return this._ModifyTime;
            }
            set
            {
                if (this._ModifyTime != value)
                {
                    this._ModifyTime = value;
                }
            }
        }

        [Column(Storage="_ModifyUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ModifyUser
        {
            get
            {
                return this._ModifyUser;
            }
            set
            {
                if (this._ModifyUser != value)
                {
                    this._ModifyUser = value;
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

        [Column(Storage="_Price", DbType="Decimal(18,0) NOT NULL")]
        public decimal Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                if (this._Price != value)
                {
                    this._Price = value;
                }
            }
        }

        [Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                if (this._Title != value)
                {
                    this._Title = value;
                }
            }
        }
    }
}

