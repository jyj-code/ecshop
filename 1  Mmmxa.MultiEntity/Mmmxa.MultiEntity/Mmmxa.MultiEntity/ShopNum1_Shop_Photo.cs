namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_Photo")]
    public class ShopNum1_Shop_Photo
    {
        private string _AlbumsGuid;
        private DateTime? _CreateTime;
        private System.Guid _Guid;
        private string _Name;
        private string _PhotoPath;

        [Column(Storage="_AlbumsGuid", DbType="NVarChar(50)")]
        public string AlbumsGuid
        {
            get
            {
                return this._AlbumsGuid;
            }
            set
            {
                if (this._AlbumsGuid != value)
                {
                    this._AlbumsGuid = value;
                }
            }
        }

        [Column(Storage="_CreateTime", DbType="DateTime")]
        public DateTime? CreateTime
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

        [Column(Storage="_Name", DbType="NVarChar(50)")]
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

        [Column(Storage="_PhotoPath", DbType="NVarChar(250)")]
        public string PhotoPath
        {
            get
            {
                return this._PhotoPath;
            }
            set
            {
                if (this._PhotoPath != value)
                {
                    this._PhotoPath = value;
                }
            }
        }
    }
}

