namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Control")]
    public class ShopNum1_Control
    {
        private string _ControlFileName;
        private string _ControlImg;
        private string _ControlKey;
        private string _ControlName;
        private DateTime _CreateTime;
        private string _CreateUser;
        private System.Guid _Guid;
        private int _IsShow;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private string _PageFileName;
        private string _PageName;

        [Column(Storage="_ControlFileName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ControlFileName
        {
            get
            {
                return this._ControlFileName;
            }
            set
            {
                if (this._ControlFileName != value)
                {
                    this._ControlFileName = value;
                }
            }
        }

        [Column(Storage="_ControlImg", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
        public string ControlImg
        {
            get
            {
                return this._ControlImg;
            }
            set
            {
                if (this._ControlImg != value)
                {
                    this._ControlImg = value;
                }
            }
        }

        [Column(Storage="_ControlKey", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ControlKey
        {
            get
            {
                return this._ControlKey;
            }
            set
            {
                if (this._ControlKey != value)
                {
                    this._ControlKey = value;
                }
            }
        }

        [Column(Storage="_ControlName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ControlName
        {
            get
            {
                return this._ControlName;
            }
            set
            {
                if (this._ControlName != value)
                {
                    this._ControlName = value;
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

        [Column(Storage="_PageFileName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string PageFileName
        {
            get
            {
                return this._PageFileName;
            }
            set
            {
                if (this._PageFileName != value)
                {
                    this._PageFileName = value;
                }
            }
        }

        [Column(Storage="_PageName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string PageName
        {
            get
            {
                return this._PageName;
            }
            set
            {
                if (this._PageName != value)
                {
                    this._PageName = value;
                }
            }
        }
    }
}

