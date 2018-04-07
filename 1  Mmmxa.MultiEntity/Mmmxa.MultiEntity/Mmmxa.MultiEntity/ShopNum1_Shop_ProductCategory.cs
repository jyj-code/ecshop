namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_ProductCategory")]
    public class ShopNum1_Shop_ProductCategory
    {
        private int _CategoryLevel;
        private string _Code;
        private string _Description;
        private string _Family;
        private int _FatherID;
        private int _ID;
        private int _IsShow;
        private string _Keywords;
        private string _MemLoginID;
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

        [Column(Storage="_Code", DbType="VarChar(9) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_Description", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_Family", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_Keywords", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
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
    }
}

