namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_Template")]
    public class ShopNum1_Shop_Template
    {
        private DateTime _CreateTime;
        private string _CreateUser;
        private int _ID;
        private int _IsDefault;
        private int _IsDeleted;
        private int _IsForbid;
        private string _Meto;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private decimal? _Money;
        private string _Name;
        private string _Path;
        private string _TemplateImg;
        private int? _ValidDay;

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

        [Column(Storage="_IsDefault", DbType="Int NOT NULL")]
        public int IsDefault
        {
            get
            {
                return this._IsDefault;
            }
            set
            {
                if (this._IsDefault != value)
                {
                    this._IsDefault = value;
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

        [Column(Storage="_Meto", DbType="NVarChar(1000)")]
        public string Meto
        {
            get
            {
                return this._Meto;
            }
            set
            {
                if (this._Meto != value)
                {
                    this._Meto = value;
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

        [Column(Storage="_Money", DbType="Decimal(18,2)")]
        public decimal? Money
        {
            get
            {
                return this._Money;
            }
            set
            {
                decimal? nullable = this._Money;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this._Money = value;
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

        [Column(Storage="_Path", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string Path
        {
            get
            {
                return this._Path;
            }
            set
            {
                if (this._Path != value)
                {
                    this._Path = value;
                }
            }
        }

        [Column(Storage="_TemplateImg", DbType="NVarChar(100)")]
        public string TemplateImg
        {
            get
            {
                return this._TemplateImg;
            }
            set
            {
                if (this._TemplateImg != value)
                {
                    this._TemplateImg = value;
                }
            }
        }

        [Column(Storage="_ValidDay", DbType="Int")]
        public int? ValidDay
        {
            get
            {
                return this._ValidDay;
            }
            set
            {
                if (this._ValidDay != value)
                {
                    this._ValidDay = value;
                }
            }
        }
    }
}

