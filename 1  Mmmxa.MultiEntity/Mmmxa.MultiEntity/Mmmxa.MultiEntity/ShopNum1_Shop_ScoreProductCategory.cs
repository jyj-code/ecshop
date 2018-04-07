namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_ScoreProductCategory")]
    public class ShopNum1_Shop_ScoreProductCategory
    {
        private int _CategoryLevel;
        private string _Code;
        private DateTime _CreateTime;
        private string _CreateUser;
        private string _Description;
        private string _Family;
        private int _FatherID;
        private int _ID;
        private int _IsDeleted;
        private int _IsDownload;
        private int _IsShow;
        private string _Keywords;
        private string _MemLoginID;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private int _OrderID;

        [Column(Storage="_CategoryLevel", DbType="Int NOT NULL")]
        public int CategoryLevel
        {
            get
            {
                return this._CategoryLevel;
            }
            set
            {
                if (this._CategoryLevel != value)
                {
                    this._CategoryLevel = value;
                }
            }
        }

        [Column(Storage="_Code", DbType="NVarChar(50)")]
        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                if (this._Code != value)
                {
                    this._Code = value;
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

        [Column(Storage="_CreateUser", DbType="NVarChar(50)")]
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

        [Column(Storage="_Description", DbType="NVarChar(150)")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                if (this._Description != value)
                {
                    this._Description = value;
                }
            }
        }

        [Column(Storage="_Family", DbType="NVarChar(250)")]
        public string Family
        {
            get
            {
                return this._Family;
            }
            set
            {
                if (this._Family != value)
                {
                    this._Family = value;
                }
            }
        }

        [Column(Storage="_FatherID", DbType="Int NOT NULL")]
        public int FatherID
        {
            get
            {
                return this._FatherID;
            }
            set
            {
                if (this._FatherID != value)
                {
                    this._FatherID = value;
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

        [Column(Storage="_IsDownload", DbType="Int NOT NULL")]
        public int IsDownload
        {
            get
            {
                return this._IsDownload;
            }
            set
            {
                if (this._IsDownload != value)
                {
                    this._IsDownload = value;
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

        [Column(Storage="_Keywords", DbType="NVarChar(200)")]
        public string Keywords
        {
            get
            {
                return this._Keywords;
            }
            set
            {
                if (this._Keywords != value)
                {
                    this._Keywords = value;
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="NVarChar(50)")]
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
    }
}

