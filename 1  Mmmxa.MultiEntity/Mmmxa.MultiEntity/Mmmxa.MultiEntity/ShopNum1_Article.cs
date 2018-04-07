namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Article")]
    public class ShopNum1_Article : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _ArticleCategoryID;
        private int? _ClickCount;
        private string _Content;
        private DateTime _CreateTime;
        private string _CreateUser;
        private string _Description;
        private System.Guid _Guid;
        private int _IsAllowComment;
        private int? _IsAudit;
        private int _IsCanConfigure;
        private int _IsDeleted;
        private int _IsHead;
        private int _IsHot;
        private int _IsRecommend;
        private int _IsShow;
        private string _Keywords;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private int _OrderID;
        private string _Publisher;
        private string _Source;
        private string _SubstationID;
        private string _Title;
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

        [Column(Storage="_ArticleCategoryID", DbType="Int NOT NULL")]
        public int ArticleCategoryID
        {
            get
            {
                return this._ArticleCategoryID;
            }
            set
            {
                if (this._ArticleCategoryID != value)
                {
                    this.SendPropertyChanging();
                    this._ArticleCategoryID = value;
                    this.SendPropertyChanged("ArticleCategoryID");
                }
            }
        }

        [Column(Storage="_ClickCount", DbType="Int")]
        public int? ClickCount
        {
            get
            {
                return this._ClickCount;
            }
            set
            {
                if (this._ClickCount != value)
                {
                    this.SendPropertyChanging();
                    this._ClickCount = value;
                    this.SendPropertyChanged("ClickCount");
                }
            }
        }

        [Column(Storage="_Content", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
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
                    this.SendPropertyChanging();
                    this._CreateUser = value;
                    this.SendPropertyChanged("CreateUser");
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

        [Column(Storage="_IsAllowComment", DbType="Int NOT NULL")]
        public int IsAllowComment
        {
            get
            {
                return this._IsAllowComment;
            }
            set
            {
                if (this._IsAllowComment != value)
                {
                    this.SendPropertyChanging();
                    this._IsAllowComment = value;
                    this.SendPropertyChanged("IsAllowComment");
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

        [Column(Storage="_IsCanConfigure", DbType="Int NOT NULL")]
        public int IsCanConfigure
        {
            get
            {
                return this._IsCanConfigure;
            }
            set
            {
                if (this._IsCanConfigure != value)
                {
                    this.SendPropertyChanging();
                    this._IsCanConfigure = value;
                    this.SendPropertyChanged("IsCanConfigure");
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
                    this.SendPropertyChanging();
                    this._IsDeleted = value;
                    this.SendPropertyChanged("IsDeleted");
                }
            }
        }

        [Column(Storage="_IsHead", DbType="Int NOT NULL")]
        public int IsHead
        {
            get
            {
                return this._IsHead;
            }
            set
            {
                if (this._IsHead != value)
                {
                    this.SendPropertyChanging();
                    this._IsHead = value;
                    this.SendPropertyChanged("IsHead");
                }
            }
        }

        [Column(Storage="_IsHot", DbType="Int NOT NULL")]
        public int IsHot
        {
            get
            {
                return this._IsHot;
            }
            set
            {
                if (this._IsHot != value)
                {
                    this.SendPropertyChanging();
                    this._IsHot = value;
                    this.SendPropertyChanged("IsHot");
                }
            }
        }

        [Column(Storage="_IsRecommend", DbType="Int NOT NULL")]
        public int IsRecommend
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
                    this.SendPropertyChanging();
                    this._IsShow = value;
                    this.SendPropertyChanged("IsShow");
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
                    this.SendPropertyChanging();
                    this._Keywords = value;
                    this.SendPropertyChanged("Keywords");
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
                    this.SendPropertyChanging();
                    this._ModifyUser = value;
                    this.SendPropertyChanged("ModifyUser");
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
                    this.SendPropertyChanging();
                    this._OrderID = value;
                    this.SendPropertyChanged("OrderID");
                }
            }
        }

        [Column(Storage="_Publisher", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Publisher
        {
            get
            {
                return this._Publisher;
            }
            set
            {
                if (this._Publisher != value)
                {
                    this.SendPropertyChanging();
                    this._Publisher = value;
                    this.SendPropertyChanged("Publisher");
                }
            }
        }

        [Column(Storage="_Source", DbType="NVarChar(150)")]
        public string Source
        {
            get
            {
                return this._Source;
            }
            set
            {
                if (this._Source != value)
                {
                    this.SendPropertyChanging();
                    this._Source = value;
                    this.SendPropertyChanged("Source");
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

        [Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
    }
}

