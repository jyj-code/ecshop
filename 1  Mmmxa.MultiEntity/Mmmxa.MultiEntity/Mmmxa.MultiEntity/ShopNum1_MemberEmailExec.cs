namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_MemberEmailExec")]
    public class ShopNum1_MemberEmailExec : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Email;
        private string _Emailkey;
        private DateTime? _ExtireTime;
        private System.Guid? _Guid;
        private byte? _Isinvalid;
        private string _MemberID;
        private string _Phone;
        private byte _Type;
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

        [Column(Storage="_Email", DbType="NVarChar(100)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if (this._Email != value)
                {
                    this.SendPropertyChanging();
                    this._Email = value;
                    this.SendPropertyChanged("Email");
                }
            }
        }

        [Column(Storage="_Emailkey", DbType="NVarChar(200) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
        public string Emailkey
        {
            get
            {
                return this._Emailkey;
            }
            set
            {
                if (this._Emailkey != value)
                {
                    this.SendPropertyChanging();
                    this._Emailkey = value;
                    this.SendPropertyChanged("Emailkey");
                }
            }
        }

        [Column(Storage="_ExtireTime", DbType="DateTime")]
        public DateTime? ExtireTime
        {
            get
            {
                return this._ExtireTime;
            }
            set
            {
                if (this._ExtireTime != value)
                {
                    this.SendPropertyChanging();
                    this._ExtireTime = value;
                    this.SendPropertyChanged("ExtireTime");
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier")]
        public System.Guid? Guid
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

        [Column(Storage="_Isinvalid", DbType="TinyInt")]
        public byte? Isinvalid
        {
            get
            {
                return this._Isinvalid;
            }
            set
            {
                if (this._Isinvalid != value)
                {
                    this.SendPropertyChanging();
                    this._Isinvalid = value;
                    this.SendPropertyChanged("Isinvalid");
                }
            }
        }

        [Column(Storage="_MemberID", DbType="NVarChar(50)")]
        public string MemberID
        {
            get
            {
                return this._MemberID;
            }
            set
            {
                if (this._MemberID != value)
                {
                    this.SendPropertyChanging();
                    this._MemberID = value;
                    this.SendPropertyChanged("MemberID");
                }
            }
        }

        [Column(Storage="_Phone", DbType="NVarChar(100)")]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                if (this._Phone != value)
                {
                    this.SendPropertyChanging();
                    this._Phone = value;
                    this.SendPropertyChanged("Phone");
                }
            }
        }

        [Column(Storage="_Type", DbType="TinyInt NOT NULL")]
        public byte Type
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

