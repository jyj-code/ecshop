namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_CategoryInfo")]
    public class ShopNum1_CategoryInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _AddressCode;
        private string _AddressValue;
        private string _AssociatedCategoryGuid;
        private string _AssociatedCategoryName;
        private string _AssociatedMemberID;
        private string _Content;
        private DateTime _CreateTime;
        private string _Description;
        private string _Email;
        private System.Guid _Guid;
        private int _IsAudit;
        private string _Keywords;
        private string _OtherContactWay;
        private string _Tel;
        private string _Title;
        private string _Type;
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

        [Column(Storage="_AddressCode", DbType="NVarChar(50)")]
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

        [Column(Storage="_AssociatedCategoryGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string AssociatedCategoryGuid
        {
            get
            {
                return this._AssociatedCategoryGuid;
            }
            set
            {
                if (this._AssociatedCategoryGuid != value)
                {
                    this.SendPropertyChanging();
                    this._AssociatedCategoryGuid = value;
                    this.SendPropertyChanged("AssociatedCategoryGuid");
                }
            }
        }

        [Column(Storage="_AssociatedCategoryName", DbType="NVarChar(100)")]
        public string AssociatedCategoryName
        {
            get
            {
                return this._AssociatedCategoryName;
            }
            set
            {
                if (this._AssociatedCategoryName != value)
                {
                    this.SendPropertyChanging();
                    this._AssociatedCategoryName = value;
                    this.SendPropertyChanged("AssociatedCategoryName");
                }
            }
        }

        [Column(Storage="_AssociatedMemberID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string AssociatedMemberID
        {
            get
            {
                return this._AssociatedMemberID;
            }
            set
            {
                if (this._AssociatedMemberID != value)
                {
                    this.SendPropertyChanging();
                    this._AssociatedMemberID = value;
                    this.SendPropertyChanged("AssociatedMemberID");
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

        [Column(Storage="_Email", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_OtherContactWay", DbType="NVarChar(25)")]
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

        [Column(Storage="_Tel", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_Type", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

