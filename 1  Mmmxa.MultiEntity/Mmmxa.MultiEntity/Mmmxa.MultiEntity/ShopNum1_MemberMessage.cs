namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_MemberMessage")]
    public class ShopNum1_MemberMessage : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Content;
        private System.Guid _Guid;
        private int? _IsDeleted;
        private int? _IsRead;
        private string _ReContent;
        private string _ReLoginID;
        private DateTime? _ReTime;
        private string _SendLoginID;
        private DateTime? _SendTime;
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

        [Column(Storage="_Content", DbType="NChar(1000)")]
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

        [Column(Storage="_IsDeleted", DbType="Int")]
        public int? IsDeleted
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

        [Column(Storage="_IsRead", DbType="Int")]
        public int? IsRead
        {
            get
            {
                return this._IsRead;
            }
            set
            {
                if (this._IsRead != value)
                {
                    this.SendPropertyChanging();
                    this._IsRead = value;
                    this.SendPropertyChanged("IsRead");
                }
            }
        }

        [Column(Storage="_ReContent", DbType="NChar(500)")]
        public string ReContent
        {
            get
            {
                return this._ReContent;
            }
            set
            {
                if (this._ReContent != value)
                {
                    this.SendPropertyChanging();
                    this._ReContent = value;
                    this.SendPropertyChanged("ReContent");
                }
            }
        }

        [Column(Storage="_ReLoginID", DbType="NChar(20)")]
        public string ReLoginID
        {
            get
            {
                return this._ReLoginID;
            }
            set
            {
                if (this._ReLoginID != value)
                {
                    this.SendPropertyChanging();
                    this._ReLoginID = value;
                    this.SendPropertyChanged("ReLoginID");
                }
            }
        }

        [Column(Storage="_ReTime", DbType="DateTime")]
        public DateTime? ReTime
        {
            get
            {
                return this._ReTime;
            }
            set
            {
                if (this._ReTime != value)
                {
                    this.SendPropertyChanging();
                    this._ReTime = value;
                    this.SendPropertyChanged("ReTime");
                }
            }
        }

        [Column(Storage="_SendLoginID", DbType="NChar(20)")]
        public string SendLoginID
        {
            get
            {
                return this._SendLoginID;
            }
            set
            {
                if (this._SendLoginID != value)
                {
                    this.SendPropertyChanging();
                    this._SendLoginID = value;
                    this.SendPropertyChanged("SendLoginID");
                }
            }
        }

        [Column(Storage="_SendTime", DbType="DateTime")]
        public DateTime? SendTime
        {
            get
            {
                return this._SendTime;
            }
            set
            {
                if (this._SendTime != value)
                {
                    this.SendPropertyChanging();
                    this._SendTime = value;
                    this.SendPropertyChanged("SendTime");
                }
            }
        }

        [Column(Storage="_Title", DbType="NChar(30)")]
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

