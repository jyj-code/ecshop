namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Logistics")]
    public class ShopNum1_Logistic
    {
        private string _Description;
        private int _ID;
        private int _IsShow;
        private string _Name;
        private string _ValueCode;

        [Column(Storage="_Description", DbType="NVarChar(500)")]
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

        [Column(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_ValueCode", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ValueCode
        {
            get
            {
                return this._ValueCode;
            }
            set
            {
                if (this._ValueCode != value)
                {
                    this._ValueCode = value;
                }
            }
        }
    }
}

