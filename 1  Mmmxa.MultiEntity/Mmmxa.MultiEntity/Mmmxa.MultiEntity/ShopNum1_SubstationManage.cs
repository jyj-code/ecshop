namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_SubstationManage")]
    public class ShopNum1_SubstationManage : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private decimal? _AdvancePayment;
        private string _CityCode;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private string _DomainName;
        private System.Guid _Guid;
        private int? _IsDeleted;
        private int? _IsDisabled;
        private int? _IsHot;
        private string _Letter;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private string _People;
        private string _Phone;
        private string _Remarks;
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

        [Column(Storage="_AdvancePayment", DbType="Decimal(18,2)")]
        public decimal? AdvancePayment
        {
            get
            {
                return this._AdvancePayment;
            }
            set
            {
                decimal? nullable = this._AdvancePayment;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._AdvancePayment = value;
                    this.SendPropertyChanged("AdvancePayment");
                }
            }
        }

        [Column(Storage="_CityCode", DbType="NVarChar(50)")]
        public string CityCode
        {
            get
            {
                return this._CityCode;
            }
            set
            {
                if (this._CityCode != value)
                {
                    this.SendPropertyChanging();
                    this._CityCode = value;
                    this.SendPropertyChanged("CityCode");
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

        [Column(Storage="_DomainName", DbType="NVarChar(300)")]
        public string DomainName
        {
            get
            {
                return this._DomainName;
            }
            set
            {
                if (this._DomainName != value)
                {
                    this.SendPropertyChanging();
                    this._DomainName = value;
                    this.SendPropertyChanged("DomainName");
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

        [Column(Storage="_IsDisabled", DbType="Int")]
        public int? IsDisabled
        {
            get
            {
                return this._IsDisabled;
            }
            set
            {
                if (this._IsDisabled != value)
                {
                    this.SendPropertyChanging();
                    this._IsDisabled = value;
                    this.SendPropertyChanged("IsDisabled");
                }
            }
        }

        [Column(Storage="_IsHot", DbType="Int")]
        public int? IsHot
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

        [Column(Storage="_Letter", DbType="NVarChar(60)")]
        public string Letter
        {
            get
            {
                return this._Letter;
            }
            set
            {
                if (this._Letter != value)
                {
                    this.SendPropertyChanging();
                    this._Letter = value;
                    this.SendPropertyChanged("Letter");
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

        [Column(Storage="_Name", DbType="NVarChar(200)")]
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

        [Column(Storage="_People", DbType="NVarChar(50)")]
        public string People
        {
            get
            {
                return this._People;
            }
            set
            {
                if (this._People != value)
                {
                    this.SendPropertyChanging();
                    this._People = value;
                    this.SendPropertyChanged("People");
                }
            }
        }

        [Column(Storage="_Phone", DbType="NVarChar(50)")]
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

        [Column(Storage="_Remarks", DbType="NVarChar(500)")]
        public string Remarks
        {
            get
            {
                return this._Remarks;
            }
            set
            {
                if (this._Remarks != value)
                {
                    this.SendPropertyChanging();
                    this._Remarks = value;
                    this.SendPropertyChanged("Remarks");
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

