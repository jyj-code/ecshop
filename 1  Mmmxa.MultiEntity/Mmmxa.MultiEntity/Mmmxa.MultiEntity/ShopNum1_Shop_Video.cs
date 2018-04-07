namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Shop_Video")]
    public class ShopNum1_Shop_Video : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int? _BroadcastCount;
        private string _CategoryGuid;
        private string _Content;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private string _Description;
        private System.Guid _Guid;
        private string _ImgAdd;
        private int? _IsAudit;
        private int? _IsRecommend;
        private string _KeyWords;
        private string _MemLoginID;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private int? _OrderID;
        private string _ShopID;
        private string _Title;
        private string _VideoAdd;
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

        [Column(Storage="_BroadcastCount", DbType="Int")]
        public int? BroadcastCount
        {
            get
            {
                return this._BroadcastCount;
            }
            set
            {
                if (this._BroadcastCount != value)
                {
                    this.SendPropertyChanging();
                    this._BroadcastCount = value;
                    this.SendPropertyChanged("BroadcastCount");
                }
            }
        }

        [Column(Storage="_CategoryGuid", DbType="NVarChar(50)")]
        public string CategoryGuid
        {
            get
            {
                return this._CategoryGuid;
            }
            set
            {
                if (this._CategoryGuid != value)
                {
                    this.SendPropertyChanging();
                    this._CategoryGuid = value;
                    this.SendPropertyChanged("CategoryGuid");
                }
            }
        }

        [Column(Storage="_Content", DbType="NText", UpdateCheck=UpdateCheck.Never)]
        public string Content
        {
            get
            {
                return this._Content;
            }
            set
            {
                if (this._Content != value)
                {
                    this.SendPropertyChanging();
                    this._Content = value;
                    this.SendPropertyChanged("Content");
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
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
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
                    this.SendPropertyChanging();
                    this._CreateUser = value;
                    this.SendPropertyChanged("CreateUser");
                }
            }
        }

        [Column(Storage="_Description", DbType="NVarChar(100)")]
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
                    this.SendPropertyChanging();
                    this._Description = value;
                    this.SendPropertyChanged("Description");
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
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
                    this.SendPropertyChanging();
                    this._Guid = value;
                    this.SendPropertyChanged("Guid");
                }
            }
        }

        [Column(Storage="_ImgAdd", DbType="NVarChar(200)")]
        public string ImgAdd
        {
            get
            {
                return this._ImgAdd;
            }
            set
            {
                if (this._ImgAdd != value)
                {
                    this.SendPropertyChanging();
                    this._ImgAdd = value;
                    this.SendPropertyChanged("ImgAdd");
                }
            }
        }

        [Column(Storage="_IsAudit", DbType="Int")]
        public int? IsAudit
        {
            get
            {
                return this._IsAudit;
            }
            set
            {
                if (this._IsAudit != value)
                {
                    this.SendPropertyChanging();
                    this._IsAudit = value;
                    this.SendPropertyChanged("IsAudit");
                }
            }
        }

        [Column(Storage="_IsRecommend", DbType="Int")]
        public int? IsRecommend
        {
            get
            {
                return this._IsRecommend;
            }
            set
            {
                if (this._IsRecommend != value)
                {
                    this.SendPropertyChanging();
                    this._IsRecommend = value;
                    this.SendPropertyChanged("IsRecommend");
                }
            }
        }

        [Column(Storage="_KeyWords", DbType="NVarChar(50)")]
        public string KeyWords
        {
            get
            {
                return this._KeyWords;
            }
            set
            {
                if (this._KeyWords != value)
                {
                    this.SendPropertyChanging();
                    this._KeyWords = value;
                    this.SendPropertyChanged("KeyWords");
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
                    this.SendPropertyChanging();
                    this._MemLoginID = value;
                    this.SendPropertyChanged("MemLoginID");
                }
            }
        }

        [Column(Storage="_ModifyTime", DbType="DateTime")]
        public DateTime? ModifyTime
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

        [Column(Storage="_ModifyUser", DbType="NVarChar(50)")]
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
                    this.SendPropertyChanging();
                    this._ModifyUser = value;
                    this.SendPropertyChanged("ModifyUser");
                }
            }
        }

        [Column(Storage="_OrderID", DbType="Int")]
        public int? OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                if (this._OrderID != value)
                {
                    this.SendPropertyChanging();
                    this._OrderID = value;
                    this.SendPropertyChanged("OrderID");
                }
            }
        }

        [Column(Storage="_ShopID", DbType="NVarChar(50)")]
        public string ShopID
        {
            get
            {
                return this._ShopID;
            }
            set
            {
                if (this._ShopID != value)
                {
                    this.SendPropertyChanging();
                    this._ShopID = value;
                    this.SendPropertyChanged("ShopID");
                }
            }
        }

        [Column(Storage="_Title", DbType="NVarChar(50)")]
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
                    this.SendPropertyChanging();
                    this._Title = value;
                    this.SendPropertyChanged("Title");
                }
            }
        }

        [Column(Storage="_VideoAdd", DbType="NVarChar(500)")]
        public string VideoAdd
        {
            get
            {
                return this._VideoAdd;
            }
            set
            {
                if (this._VideoAdd != value)
                {
                    this.SendPropertyChanging();
                    this._VideoAdd = value;
                    this.SendPropertyChanged("VideoAdd");
                }
            }
        }
    }
}

