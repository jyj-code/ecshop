namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ShopPayment")]
    public class ShopNum1_ShopPayment : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private decimal _Charge;
        private string _Email;
        private System.Guid _Guid;
        private int _IsCOD;
        private int _IsDeleted;
        private int _IsPercent;
        private string _memloginID;
        private string _Memo;
        private string _MerchantCode;
        private string _Name;
        private int _OrderID;
        private string _Partner;
        private string _PaymentType;
        private string _Pwd;
        private string _SecondKey;
        private string _SecretKey;
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

        [Column(Storage="_Charge", DbType="Decimal(18,2) NOT NULL")]
        public decimal Charge
        {
            get
            {
                return this._Charge;
            }
            set
            {
                if (this._Charge != value)
                {
                    this.SendPropertyChanging();
                    this._Charge = value;
                    this.SendPropertyChanged("Charge");
                }
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

        [Column(Storage="_IsCOD", DbType="Int NOT NULL")]
        public int IsCOD
        {
            get
            {
                return this._IsCOD;
            }
            set
            {
                if (this._IsCOD != value)
                {
                    this.SendPropertyChanging();
                    this._IsCOD = value;
                    this.SendPropertyChanged("IsCOD");
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

        [Column(Storage="_IsPercent", DbType="Int NOT NULL")]
        public int IsPercent
        {
            get
            {
                return this._IsPercent;
            }
            set
            {
                if (this._IsPercent != value)
                {
                    this.SendPropertyChanging();
                    this._IsPercent = value;
                    this.SendPropertyChanged("IsPercent");
                }
            }
        }

        [Column(Storage="_memloginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string memloginID
        {
            get
            {
                return this._memloginID;
            }
            set
            {
                if (this._memloginID != value)
                {
                    this.SendPropertyChanging();
                    this._memloginID = value;
                    this.SendPropertyChanged("memloginID");
                }
            }
        }

        [Column(Storage="_Memo", DbType="NVarChar(4000)")]
        public string Memo
        {
            get
            {
                return this._Memo;
            }
            set
            {
                if (this._Memo != value)
                {
                    this.SendPropertyChanging();
                    this._Memo = value;
                    this.SendPropertyChanged("Memo");
                }
            }
        }

        [Column(Storage="_MerchantCode", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string MerchantCode
        {
            get
            {
                return this._MerchantCode;
            }
            set
            {
                if (this._MerchantCode != value)
                {
                    this.SendPropertyChanging();
                    this._MerchantCode = value;
                    this.SendPropertyChanged("MerchantCode");
                }
            }
        }

        [Column(Storage="_Name", DbType="NVarChar(100)")]
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

        [Column(Storage="_Partner", DbType="NVarChar(100)")]
        public string Partner
        {
            get
            {
                return this._Partner;
            }
            set
            {
                if (this._Partner != value)
                {
                    this.SendPropertyChanging();
                    this._Partner = value;
                    this.SendPropertyChanged("Partner");
                }
            }
        }

        [Column(Storage="_PaymentType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string PaymentType
        {
            get
            {
                return this._PaymentType;
            }
            set
            {
                if (this._PaymentType != value)
                {
                    this.SendPropertyChanging();
                    this._PaymentType = value;
                    this.SendPropertyChanged("PaymentType");
                }
            }
        }

        [Column(Storage="_Pwd", DbType="NVarChar(250)")]
        public string Pwd
        {
            get
            {
                return this._Pwd;
            }
            set
            {
                if (this._Pwd != value)
                {
                    this.SendPropertyChanging();
                    this._Pwd = value;
                    this.SendPropertyChanged("Pwd");
                }
            }
        }

        [Column(Storage="_SecondKey", DbType="NVarChar(250)")]
        public string SecondKey
        {
            get
            {
                return this._SecondKey;
            }
            set
            {
                if (this._SecondKey != value)
                {
                    this.SendPropertyChanging();
                    this._SecondKey = value;
                    this.SendPropertyChanged("SecondKey");
                }
            }
        }

        [Column(Storage="_SecretKey", DbType="NVarChar(250)")]
        public string SecretKey
        {
            get
            {
                return this._SecretKey;
            }
            set
            {
                if (this._SecretKey != value)
                {
                    this.SendPropertyChanging();
                    this._SecretKey = value;
                    this.SendPropertyChanged("SecretKey");
                }
            }
        }
    }
}

