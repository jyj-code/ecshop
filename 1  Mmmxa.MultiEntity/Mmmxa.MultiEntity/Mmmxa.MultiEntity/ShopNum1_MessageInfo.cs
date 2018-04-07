namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_MessageInfo")]
    public class ShopNum1_MessageInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Content;
        private System.Guid _Guid;
        private int _IsDeleted;
        private byte _IsRead;
        private string _MemLoginID;
        private string _OperateUser;
        private DateTime _SendTime;
        private string _Title;
        private string _Type;
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

        [Column(Storage="_Content", DbType="NVarChar(1000)")]
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

        [Column(Storage="_IsRead", DbType="TinyInt NOT NULL")]
        public byte IsRead
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

        [Column(Storage="_OperateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string OperateUser
        {
            get
            {
                return this._OperateUser;
            }
            set
            {
                if (this._OperateUser != value)
                {
                    this.SendPropertyChanging();
                    this._OperateUser = value;
                    this.SendPropertyChanged("OperateUser");
                }
            }
        }

        [Column(Storage="_SendTime", DbType="DateTime NOT NULL")]
        public DateTime SendTime
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

        [Column(Storage="_Type", DbType="NVarChar(50)")]
        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                if (this._Type != value)
                {
                    this.SendPropertyChanging();
                    this._Type = value;
                    this.SendPropertyChanged("Type");
                }
            }
        }
    }
}

