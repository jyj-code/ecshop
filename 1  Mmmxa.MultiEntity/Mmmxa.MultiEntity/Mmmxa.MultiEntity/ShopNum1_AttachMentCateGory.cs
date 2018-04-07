namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_AttachMentCateGory")]
    public class ShopNum1_AttachMentCateGory
    {
        private string _CateGoryName;
        private string _Description;
        private System.Guid _Guid;
        private int _IsDeleted;

        [Column(Storage="_CateGoryName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CateGoryName
        {
            get
            {
                return this._CateGoryName;
            }
            set
            {
                if (this._CateGoryName != value)
                {
                    this._CateGoryName = value;
                }
            }
        }

        [Column(Storage="_Description", DbType="NVarChar(250)")]
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
    }
}

