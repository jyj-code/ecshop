namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Page")]
    public class ShopNum1_Page : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime _CreateTime;
        private string _CreateUser;
        private string _Description;
        private System.Guid _Guid;
        private int _IsDeleted;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private int _OneID;
        private int _OrderID;
        private string _PagePath;
        private int _PageType;
        private int _ThreeID;
        private int _TwoID;
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

        [Column(Storage="_Name", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (this._Name != value)
                {
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                }
            }
        }

        [Column(Storage="_OneID", DbType="Int NOT NULL")]
        public int OneID
        {
            get
            {
                return this._OneID;
            }
            set
            {
                if (this._OneID != value)
                {
                    this.SendPropertyChanging();
                    this._OneID = value;
                    this.SendPropertyChanged("OneID");
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

        [Column(Storage="_PagePath", DbType="NVarChar(250)")]
        public string PagePath
        {
            get
            {
                return this._PagePath;
            }
            set
            {
                if (this._PagePath != value)
                {
                    this.SendPropertyChanging();
                    this._PagePath = value;
                    this.SendPropertyChanged("PagePath");
                }
            }
        }

        [Column(Storage="_PageType", DbType="Int NOT NULL")]
        public int PageType
        {
            get
            {
                return this._PageType;
            }
            set
            {
                if (this._PageType != value)
                {
                    this.SendPropertyChanging();
                    this._PageType = value;
                    this.SendPropertyChanged("PageType");
                }
            }
        }

        [Column(Storage="_ThreeID", DbType="Int NOT NULL")]
        public int ThreeID
        {
            get
            {
                return this._ThreeID;
            }
            set
            {
                if (this._ThreeID != value)
                {
                    this.SendPropertyChanging();
                    this._ThreeID = value;
                    this.SendPropertyChanged("ThreeID");
                }
            }
        }

        [Column(Storage="_TwoID", DbType="Int NOT NULL")]
        public int TwoID
        {
            get
            {
                return this._TwoID;
            }
            set
            {
                if (this._TwoID != value)
                {
                    this.SendPropertyChanging();
                    this._TwoID = value;
                    this.SendPropertyChanged("TwoID");
                }
            }
        }
    }
}

