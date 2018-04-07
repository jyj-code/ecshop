namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_EmailGroupSend")]
    public class ShopNum1_EmailGroupSend : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime _CreateTime;
        private System.Guid _EmailGuid;
        private string _EmailTitle;
        private System.Guid _Guid;
        private int _IsTime;
        private string _SendObject;
        private string _SendObjectEmail;
        private int _State;
        private DateTime? _TimeSendTime;
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

        [Column(Storage="_EmailGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid EmailGuid
        {
            get
            {
                return this._EmailGuid;
            }
            set
            {
                if (this._EmailGuid != value)
                {
                    this.SendPropertyChanging();
                    this._EmailGuid = value;
                    this.SendPropertyChanged("EmailGuid");
                }
            }
        }

        [Column(Storage="_EmailTitle", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string EmailTitle
        {
            get
            {
                return this._EmailTitle;
            }
            set
            {
                if (this._EmailTitle != value)
                {
                    this.SendPropertyChanging();
                    this._EmailTitle = value;
                    this.SendPropertyChanged("EmailTitle");
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

        [Column(Storage="_IsTime", DbType="Int NOT NULL")]
        public int IsTime
        {
            get
            {
                return this._IsTime;
            }
            set
            {
                if (this._IsTime != value)
                {
                    this.SendPropertyChanging();
                    this._IsTime = value;
                    this.SendPropertyChanged("IsTime");
                }
            }
        }

        [Column(Storage="_SendObject", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string SendObject
        {
            get
            {
                return this._SendObject;
            }
            set
            {
                if (this._SendObject != value)
                {
                    this.SendPropertyChanging();
                    this._SendObject = value;
                    this.SendPropertyChanged("SendObject");
                }
            }
        }

        [Column(Storage="_SendObjectEmail", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
        public string SendObjectEmail
        {
            get
            {
                return this._SendObjectEmail;
            }
            set
            {
                if (this._SendObjectEmail != value)
                {
                    this.SendPropertyChanging();
                    this._SendObjectEmail = value;
                    this.SendPropertyChanged("SendObjectEmail");
                }
            }
        }

        [Column(Storage="_State", DbType="Int NOT NULL")]
        public int State
        {
            get
            {
                return this._State;
            }
            set
            {
                if (this._State != value)
                {
                    this.SendPropertyChanging();
                    this._State = value;
                    this.SendPropertyChanged("State");
                }
            }
        }

        [Column(Storage="_TimeSendTime", DbType="DateTime")]
        public DateTime? TimeSendTime
        {
            get
            {
                return this._TimeSendTime;
            }
            set
            {
                if (this._TimeSendTime != value)
                {
                    this.SendPropertyChanging();
                    this._TimeSendTime = value;
                    this.SendPropertyChanged("TimeSendTime");
                }
            }
        }
    }
}

