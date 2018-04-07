namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_SupplyDemandComment")]
    public class ShopNum1_SupplyDemandComment : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _AssociateMemberID;
        private string _Content;
        private string _CreateIP;
        private string _CreateMerber;
        private DateTime _CreateTime;
        private System.Guid _Guid;
        private int _IsAudit;
        private string _Reply;
        private string _SupplyDemandGuid;
        private string _Title;
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

        [Column(Storage="_AssociateMemberID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string AssociateMemberID
        {
            get
            {
                return this._AssociateMemberID;
            }
            set
            {
                if (this._AssociateMemberID != value)
                {
                    this.SendPropertyChanging();
                    this._AssociateMemberID = value;
                    this.SendPropertyChanged("AssociateMemberID");
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

        [Column(Storage="_CreateIP", DbType="Char(25) NOT NULL", CanBeNull=false)]
        public string CreateIP
        {
            get
            {
                return this._CreateIP;
            }
            set
            {
                if (this._CreateIP != value)
                {
                    this.SendPropertyChanging();
                    this._CreateIP = value;
                    this.SendPropertyChanged("CreateIP");
                }
            }
        }

        [Column(Storage="_CreateMerber", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CreateMerber
        {
            get
            {
                return this._CreateMerber;
            }
            set
            {
                if (this._CreateMerber != value)
                {
                    this.SendPropertyChanging();
                    this._CreateMerber = value;
                    this.SendPropertyChanged("CreateMerber");
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

        [Column(Storage="_Reply", DbType="NText", UpdateCheck=UpdateCheck.Never)]
        public string Reply
        {
            get
            {
                return this._Reply;
            }
            set
            {
                if (this._Reply != value)
                {
                    this.SendPropertyChanging();
                    this._Reply = value;
                    this.SendPropertyChanged("Reply");
                }
            }
        }

        [Column(Storage="_SupplyDemandGuid", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string SupplyDemandGuid
        {
            get
            {
                return this._SupplyDemandGuid;
            }
            set
            {
                if (this._SupplyDemandGuid != value)
                {
                    this.SendPropertyChanging();
                    this._SupplyDemandGuid = value;
                    this.SendPropertyChanged("SupplyDemandGuid");
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
    }
}

