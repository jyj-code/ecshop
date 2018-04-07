namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_WeiXin_ShopUser")]
    public class ShopNum1_WeiXin_ShopUser : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime _CreateTime;
        private int _ID;
        private DateTime _ModifyTime;
        private string _PublicNo;
        private string _ShopLoginID;
        private string _ShopPic;
        private string _TwoDimensionalPic;
        private string _WeiXinName;
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
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
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
                }
            }
        }

        [Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
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
                    this.SendPropertyChanging();
                    this._ModifyTime = value;
                    this.SendPropertyChanged("ModifyTime");
                }
            }
        }

        [Column(Storage="_PublicNo", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string PublicNo
        {
            get
            {
                return this._PublicNo;
            }
            set
            {
                if (this._PublicNo != value)
                {
                    this.SendPropertyChanging();
                    this._PublicNo = value;
                    this.SendPropertyChanged("PublicNo");
                }
            }
        }

        [Column(Storage="_ShopLoginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ShopLoginID
        {
            get
            {
                return this._ShopLoginID;
            }
            set
            {
                if (this._ShopLoginID != value)
                {
                    this.SendPropertyChanging();
                    this._ShopLoginID = value;
                    this.SendPropertyChanged("ShopLoginID");
                }
            }
        }

        [Column(Storage="_ShopPic", DbType="NVarChar(100)")]
        public string ShopPic
        {
            get
            {
                return this._ShopPic;
            }
            set
            {
                if (this._ShopPic != value)
                {
                    this.SendPropertyChanging();
                    this._ShopPic = value;
                    this.SendPropertyChanged("ShopPic");
                }
            }
        }

        [Column(Storage="_TwoDimensionalPic", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string TwoDimensionalPic
        {
            get
            {
                return this._TwoDimensionalPic;
            }
            set
            {
                if (this._TwoDimensionalPic != value)
                {
                    this.SendPropertyChanging();
                    this._TwoDimensionalPic = value;
                    this.SendPropertyChanged("TwoDimensionalPic");
                }
            }
        }

        [Column(Storage="_WeiXinName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string WeiXinName
        {
            get
            {
                return this._WeiXinName;
            }
            set
            {
                if (this._WeiXinName != value)
                {
                    this.SendPropertyChanging();
                    this._WeiXinName = value;
                    this.SendPropertyChanged("WeiXinName");
                }
            }
        }
    }
}

