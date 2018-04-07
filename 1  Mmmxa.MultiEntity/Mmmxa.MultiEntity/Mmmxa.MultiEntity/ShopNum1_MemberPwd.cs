namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_MemberPwd")]
    public class ShopNum1_MemberPwd : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Email;
        private DateTime _extireTime;
        private int _Guid;
        private byte _isinvalid;
        private string _MemberID;
        private string _pwd;
        private string _pwdkey;
        private byte _type;
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

        [Column(Storage="_extireTime", DbType="DateTime NOT NULL")]
        public DateTime extireTime
        {
            get
            {
                return this._extireTime;
            }
            set
            {
                if (this._extireTime != value)
                {
                    this.SendPropertyChanging();
                    this._extireTime = value;
                    this.SendPropertyChanged("extireTime");
                }
            }
        }

        [Column(Storage="_Guid", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
        public int Guid
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

        [Column(Storage="_isinvalid", DbType="TinyInt NOT NULL")]
        public byte isinvalid
        {
            get
            {
                return this._isinvalid;
            }
            set
            {
                if (this._isinvalid != value)
                {
                    this.SendPropertyChanging();
                    this._isinvalid = value;
                    this.SendPropertyChanged("isinvalid");
                }
            }
        }

        [Column(Storage="_MemberID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_pwd", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string pwd
        {
            get
            {
                return this._pwd;
            }
            set
            {
                if (this._pwd != value)
                {
                    this.SendPropertyChanging();
                    this._pwd = value;
                    this.SendPropertyChanged("pwd");
                }
            }
        }

        [Column(Storage="_pwdkey", DbType="VarChar(200) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
        public string pwdkey
        {
            get
            {
                return this._pwdkey;
            }
            set
            {
                if (this._pwdkey != value)
                {
                    this.SendPropertyChanging();
                    this._pwdkey = value;
                    this.SendPropertyChanged("pwdkey");
                }
            }
        }

        [Column(Storage="_type", DbType="TinyInt NOT NULL")]
        public byte type
        {
            get
            {
                return this._type;
            }
            set
            {
                if (this._type != value)
                {
                    this.SendPropertyChanging();
                    this._type = value;
                    this.SendPropertyChanged("type");
                }
            }
        }
    }
}

