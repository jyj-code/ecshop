namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_SupplyDemand")]
    public class ShopNum1_SupplyDemand : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _AddressCode;
        private string _AddressValue;
        private string _CategoryCode;
        private string _CategoryName;
        private string _ContactName;
        private string _Content;
        private string _Description;
        private string _Email;
        private int _ID;
        private string _Image;
        private int _IsAudit;
        private byte _IsRecommend;
        private string _Keywords;
        private string _MemberID;
        private int? _OrderID;
        private string _OtherContactWay;
        private DateTime _ReleaseTime;
        private string _SubstationID;
        private string _Tel;
        private string _Title;
        private int _TradeType;
        private string _ValidTime;
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

        [Column(Storage="_AddressCode", DbType="NVarChar(9) NOT NULL", CanBeNull=false)]
        public string AddressCode
        {
            get
            {
                return this._AddressCode;
            }
            set
            {
                if (this._AddressCode != value)
                {
                    this.SendPropertyChanging();
                    this._AddressCode = value;
                    this.SendPropertyChanged("AddressCode");
                }
            }
        }

        [Column(Storage="_AddressValue", DbType="NVarChar(50)")]
        public string AddressValue
        {
            get
            {
                return this._AddressValue;
            }
            set
            {
                if (this._AddressValue != value)
                {
                    this.SendPropertyChanging();
                    this._AddressValue = value;
                    this.SendPropertyChanged("AddressValue");
                }
            }
        }

        [Column(Storage="_CategoryCode", DbType="NVarChar(50)")]
        public string CategoryCode
        {
            get
            {
                return this._CategoryCode;
            }
            set
            {
                if (this._CategoryCode != value)
                {
                    this.SendPropertyChanging();
                    this._CategoryCode = value;
                    this.SendPropertyChanged("CategoryCode");
                }
            }
        }

        [Column(Storage="_CategoryName", DbType="NVarChar(50)")]
        public string CategoryName
        {
            get
            {
                return this._CategoryName;
            }
            set
            {
                if (this._CategoryName != value)
                {
                    this.SendPropertyChanging();
                    this._CategoryName = value;
                    this.SendPropertyChanged("CategoryName");
                }
            }
        }

        [Column(Storage="_ContactName", DbType="NVarChar(50)")]
        public string ContactName
        {
            get
            {
                return this._ContactName;
            }
            set
            {
                if (this._ContactName != value)
                {
                    this.SendPropertyChanging();
                    this._ContactName = value;
                    this.SendPropertyChanged("ContactName");
                }
            }
        }

        [Column(Storage="_Content", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
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

        [Column(Storage="_Description", DbType="NText", UpdateCheck=UpdateCheck.Never)]
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

        [Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                }
            }
        }

        [Column(Storage="_Image", DbType="NVarChar(250)")]
        public string Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                if (this._Image != value)
                {
                    this.SendPropertyChanging();
                    this._Image = value;
                    this.SendPropertyChanged("Image");
                }
            }
        }

        [Column(Storage="_IsAudit", DbType="Int NOT NULL")]
        public int IsAudit
        {
            get
            {
                return this._IsAudit;
            }
            set
            {
                if (this._IsAudit != value)
                {
                    this.SendPropertyChanging();
                    this._IsAudit = value;
                    this.SendPropertyChanged("IsAudit");
                }
            }
        }

        [Column(Storage="_IsRecommend", DbType="TinyInt NOT NULL")]
        public byte IsRecommend
        {
            get
            {
                return this._IsRecommend;
            }
            set
            {
                if (this._IsRecommend != value)
                {
                    this.SendPropertyChanging();
                    this._IsRecommend = value;
                    this.SendPropertyChanged("IsRecommend");
                }
            }
        }

        [Column(Storage="_Keywords", DbType="NVarChar(200)")]
        public string Keywords
        {
            get
            {
                return this._Keywords;
            }
            set
            {
                if (this._Keywords != value)
                {
                    this.SendPropertyChanging();
                    this._Keywords = value;
                    this.SendPropertyChanged("Keywords");
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

        [Column(Storage="_OrderID", DbType="Int")]
        public int? OrderID
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

        [Column(Storage="_OtherContactWay", DbType="NVarChar(200)")]
        public string OtherContactWay
        {
            get
            {
                return this._OtherContactWay;
            }
            set
            {
                if (this._OtherContactWay != value)
                {
                    this.SendPropertyChanging();
                    this._OtherContactWay = value;
                    this.SendPropertyChanged("OtherContactWay");
                }
            }
        }

        [Column(Storage="_ReleaseTime", DbType="DateTime NOT NULL")]
        public DateTime ReleaseTime
        {
            get
            {
                return this._ReleaseTime;
            }
            set
            {
                if (this._ReleaseTime != value)
                {
                    this.SendPropertyChanging();
                    this._ReleaseTime = value;
                    this.SendPropertyChanged("ReleaseTime");
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

        [Column(Storage="_Tel", DbType="NVarChar(25)")]
        public string Tel
        {
            get
            {
                return this._Tel;
            }
            set
            {
                if (this._Tel != value)
                {
                    this.SendPropertyChanging();
                    this._Tel = value;
                    this.SendPropertyChanged("Tel");
                }
            }
        }

        [Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_TradeType", DbType="Int NOT NULL")]
        public int TradeType
        {
            get
            {
                return this._TradeType;
            }
            set
            {
                if (this._TradeType != value)
                {
                    this.SendPropertyChanging();
                    this._TradeType = value;
                    this.SendPropertyChanged("TradeType");
                }
            }
        }

        [Column(Storage="_ValidTime", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ValidTime
        {
            get
            {
                return this._ValidTime;
            }
            set
            {
                if (this._ValidTime != value)
                {
                    this.SendPropertyChanging();
                    this._ValidTime = value;
                    this.SendPropertyChanged("ValidTime");
                }
            }
        }
    }
}

