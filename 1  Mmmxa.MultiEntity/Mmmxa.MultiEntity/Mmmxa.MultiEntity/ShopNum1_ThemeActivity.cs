namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ThemeActivity")]
    public class ShopNum1_ThemeActivity : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime _CreateTime;
        private string _CreateUser;
        private DateTime _EndDate;
        private System.Guid _Guid;
        private int _OrderID;
        private DateTime _StartDate;
        private string _SubstationID;
        private string _ThemeDescription;
        private string _ThemeImage;
        private int _ThemeStatus;
        private string _ThemeTitle;
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

        [Column(Storage="_EndDate", DbType="DateTime NOT NULL")]
        public DateTime EndDate
        {
            get
            {
                return this._EndDate;
            }
            set
            {
                if (this._EndDate != value)
                {
                    this.SendPropertyChanging();
                    this._EndDate = value;
                    this.SendPropertyChanged("EndDate");
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

        [Column(Storage="_StartDate", DbType="DateTime NOT NULL")]
        public DateTime StartDate
        {
            get
            {
                return this._StartDate;
            }
            set
            {
                if (this._StartDate != value)
                {
                    this.SendPropertyChanging();
                    this._StartDate = value;
                    this.SendPropertyChanged("StartDate");
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

        [Column(Storage="_ThemeDescription", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
        public string ThemeDescription
        {
            get
            {
                return this._ThemeDescription;
            }
            set
            {
                if (this._ThemeDescription != value)
                {
                    this.SendPropertyChanging();
                    this._ThemeDescription = value;
                    this.SendPropertyChanged("ThemeDescription");
                }
            }
        }

        [Column(Storage="_ThemeImage", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ThemeImage
        {
            get
            {
                return this._ThemeImage;
            }
            set
            {
                if (this._ThemeImage != value)
                {
                    this.SendPropertyChanging();
                    this._ThemeImage = value;
                    this.SendPropertyChanged("ThemeImage");
                }
            }
        }

        [Column(Storage="_ThemeStatus", DbType="Int NOT NULL")]
        public int ThemeStatus
        {
            get
            {
                return this._ThemeStatus;
            }
            set
            {
                if (this._ThemeStatus != value)
                {
                    this.SendPropertyChanging();
                    this._ThemeStatus = value;
                    this.SendPropertyChanged("ThemeStatus");
                }
            }
        }

        [Column(Storage="_ThemeTitle", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string ThemeTitle
        {
            get
            {
                return this._ThemeTitle;
            }
            set
            {
                if (this._ThemeTitle != value)
                {
                    this.SendPropertyChanging();
                    this._ThemeTitle = value;
                    this.SendPropertyChanged("ThemeTitle");
                }
            }
        }
    }
}

