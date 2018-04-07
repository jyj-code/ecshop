namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Video")]
    public class ShopNum1_Video : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int? _BroadcastCount;
        private int? _CategoryID;
        private int? _CommentCount;
        private string _Content;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private string _Description;
        private int? _DownCount;
        private int? _FavoritesCount;
        private System.Guid _Guid;
        private string _ImgAdd;
        private int? _IsRecommend;
        private string _KeyWords;
        private string _KeyWordsSeo;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private int? _OrderID;
        private string _SubstationID;
        private string _Title;
        private int? _UpCount;
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

        [Column(Storage="_CategoryID", DbType="Int")]
        public int? CategoryID
        {
            get
            {
                return this._CategoryID;
            }
            set
            {
                if (this._CategoryID != value)
                {
                    this.SendPropertyChanging();
                    this._CategoryID = value;
                    this.SendPropertyChanged("CategoryID");
                }
            }
        }

        [Column(Storage="_CommentCount", DbType="Int")]
        public int? CommentCount
        {
            get
            {
                return this._CommentCount;
            }
            set
            {
                if (this._CommentCount != value)
                {
                    this.SendPropertyChanging();
                    this._CommentCount = value;
                    this.SendPropertyChanged("CommentCount");
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

        [Column(Storage="_Description", DbType="VarChar(150)")]
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

        [Column(Storage="_DownCount", DbType="Int")]
        public int? DownCount
        {
            get
            {
                return this._DownCount;
            }
            set
            {
                if (this._DownCount != value)
                {
                    this.SendPropertyChanging();
                    this._DownCount = value;
                    this.SendPropertyChanged("DownCount");
                }
            }
        }

        [Column(Storage="_FavoritesCount", DbType="Int")]
        public int? FavoritesCount
        {
            get
            {
                return this._FavoritesCount;
            }
            set
            {
                if (this._FavoritesCount != value)
                {
                    this.SendPropertyChanging();
                    this._FavoritesCount = value;
                    this.SendPropertyChanged("FavoritesCount");
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

        [Column(Storage="_KeyWordsSeo", DbType="VarChar(200)")]
        public string KeyWordsSeo
        {
            get
            {
                return this._KeyWordsSeo;
            }
            set
            {
                if (this._KeyWordsSeo != value)
                {
                    this.SendPropertyChanging();
                    this._KeyWordsSeo = value;
                    this.SendPropertyChanged("KeyWordsSeo");
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

        [Column(Storage="_SubstationID", DbType="NVarChar(100)")]
        public string SubstationID
        {
            get
            {
                return this._SubstationID;
            }
            set
            {
                if (this._SubstationID != value)
                {
                    this.SendPropertyChanging();
                    this._SubstationID = value;
                    this.SendPropertyChanged("SubstationID");
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

        [Column(Storage="_UpCount", DbType="Int")]
        public int? UpCount
        {
            get
            {
                return this._UpCount;
            }
            set
            {
                if (this._UpCount != value)
                {
                    this.SendPropertyChanging();
                    this._UpCount = value;
                    this.SendPropertyChanged("UpCount");
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

