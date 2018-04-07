namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_UserDefinedColumn")]
    public class ShopNum1_UserDefinedColumn : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime _CreateTime;
        private string _CreateUser;
        private System.Guid _Guid;
        private int _IfOpen;
        private int _IfShow;
        private int _IsDeleted;
        private int _IsMember;
        private int _IsShop;
        private int _IsSite;
        private string _LinkAddress;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private int _OrderID;
        private string _Remark;
        private string _ShowLocation;
        private string _SubstationID;
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

        [Column(Storage="_IfOpen", DbType="Int NOT NULL")]
        public int IfOpen
        {
            get
            {
                return this._IfOpen;
            }
            set
            {
                if (this._IfOpen != value)
                {
                    this.SendPropertyChanging();
                    this._IfOpen = value;
                    this.SendPropertyChanged("IfOpen");
                }
            }
        }

        [Column(Storage="_IfShow", DbType="Int NOT NULL")]
        public int IfShow
        {
            get
            {
                return this._IfShow;
            }
            set
            {
                if (this._IfShow != value)
                {
                    this.SendPropertyChanging();
                    this._IfShow = value;
                    this.SendPropertyChanged("IfShow");
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

        [Column(Storage="_IsMember", DbType="Int NOT NULL")]
        public int IsMember
        {
            get
            {
                return this._IsMember;
            }
            set
            {
                if (this._IsMember != value)
                {
                    this.SendPropertyChanging();
                    this._IsMember = value;
                    this.SendPropertyChanged("IsMember");
                }
            }
        }

        [Column(Storage="_IsShop", DbType="Int NOT NULL")]
        public int IsShop
        {
            get
            {
                return this._IsShop;
            }
            set
            {
                if (this._IsShop != value)
                {
                    this.SendPropertyChanging();
                    this._IsShop = value;
                    this.SendPropertyChanged("IsShop");
                }
            }
        }

        [Column(Storage="_IsSite", DbType="Int NOT NULL")]
        public int IsSite
        {
            get
            {
                return this._IsSite;
            }
            set
            {
                if (this._IsSite != value)
                {
                    this.SendPropertyChanging();
                    this._IsSite = value;
                    this.SendPropertyChanged("IsSite");
                }
            }
        }

        [Column(Storage="_LinkAddress", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
        public string LinkAddress
        {
            get
            {
                return this._LinkAddress;
            }
            set
            {
                if (this._LinkAddress != value)
                {
                    this.SendPropertyChanging();
                    this._LinkAddress = value;
                    this.SendPropertyChanged("LinkAddress");
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

        [Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_Remark", DbType="NVarChar(200)")]
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                if (this._Remark != value)
                {
                    this.SendPropertyChanging();
                    this._Remark = value;
                    this.SendPropertyChanged("Remark");
                }
            }
        }

        [Column(Storage="_ShowLocation", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
        public string ShowLocation
        {
            get
            {
                return this._ShowLocation;
            }
            set
            {
                if (this._ShowLocation != value)
                {
                    this.SendPropertyChanging();
                    this._ShowLocation = value;
                    this.SendPropertyChanged("ShowLocation");
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
    }
}

