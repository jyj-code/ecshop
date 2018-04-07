namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_OrderComplaint")]
    public class ShopNum1_OrderComplaint : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _AppealContent;
        private string _AppealImage;
        private DateTime? _AppealTime;
        private string _ComplaintContent;
        private string _ComplaintShop;
        private DateTime? _ComplaintTime;
        private string _ComplaintType;
        private string _CustomerMessage;
        private string _Evidence;
        private string _EvidenceImage;
        private int _ID;
        private int? _IsAppeal;
        private string _MemLoginID;
        private string _OperateUser;
        private Guid? _OrderGuid;
        private string _OrderID;
        private string _ProcessingResults;
        private int? _ProcessingStatus;
        private DateTime? _ProcessingTime;
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

        [Column(Storage="_AppealContent", DbType="NVarChar(MAX)")]
        public string AppealContent
        {
            get
            {
                return this._AppealContent;
            }
            set
            {
                if (this._AppealContent != value)
                {
                    this.SendPropertyChanging();
                    this._AppealContent = value;
                    this.SendPropertyChanged("AppealContent");
                }
            }
        }

        [Column(Storage="_AppealImage", DbType="NVarChar(200)")]
        public string AppealImage
        {
            get
            {
                return this._AppealImage;
            }
            set
            {
                if (this._AppealImage != value)
                {
                    this.SendPropertyChanging();
                    this._AppealImage = value;
                    this.SendPropertyChanged("AppealImage");
                }
            }
        }

        [Column(Storage="_AppealTime", DbType="DateTime")]
        public DateTime? AppealTime
        {
            get
            {
                return this._AppealTime;
            }
            set
            {
                if (this._AppealTime != value)
                {
                    this.SendPropertyChanging();
                    this._AppealTime = value;
                    this.SendPropertyChanged("AppealTime");
                }
            }
        }

        [Column(Storage="_ComplaintContent", DbType="NVarChar(MAX)")]
        public string ComplaintContent
        {
            get
            {
                return this._ComplaintContent;
            }
            set
            {
                if (this._ComplaintContent != value)
                {
                    this.SendPropertyChanging();
                    this._ComplaintContent = value;
                    this.SendPropertyChanged("ComplaintContent");
                }
            }
        }

        [Column(Storage="_ComplaintShop", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ComplaintShop
        {
            get
            {
                return this._ComplaintShop;
            }
            set
            {
                if (this._ComplaintShop != value)
                {
                    this.SendPropertyChanging();
                    this._ComplaintShop = value;
                    this.SendPropertyChanged("ComplaintShop");
                }
            }
        }

        [Column(Storage="_ComplaintTime", DbType="DateTime")]
        public DateTime? ComplaintTime
        {
            get
            {
                return this._ComplaintTime;
            }
            set
            {
                if (this._ComplaintTime != value)
                {
                    this.SendPropertyChanging();
                    this._ComplaintTime = value;
                    this.SendPropertyChanged("ComplaintTime");
                }
            }
        }

        [Column(Storage="_ComplaintType", DbType="NVarChar(50)")]
        public string ComplaintType
        {
            get
            {
                return this._ComplaintType;
            }
            set
            {
                if (this._ComplaintType != value)
                {
                    this.SendPropertyChanging();
                    this._ComplaintType = value;
                    this.SendPropertyChanged("ComplaintType");
                }
            }
        }

        [Column(Storage="_CustomerMessage", DbType="NVarChar(MAX)")]
        public string CustomerMessage
        {
            get
            {
                return this._CustomerMessage;
            }
            set
            {
                if (this._CustomerMessage != value)
                {
                    this.SendPropertyChanging();
                    this._CustomerMessage = value;
                    this.SendPropertyChanged("CustomerMessage");
                }
            }
        }

        [Column(Storage="_Evidence", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
        public string Evidence
        {
            get
            {
                return this._Evidence;
            }
            set
            {
                if (this._Evidence != value)
                {
                    this.SendPropertyChanging();
                    this._Evidence = value;
                    this.SendPropertyChanged("Evidence");
                }
            }
        }

        [Column(Storage="_EvidenceImage", DbType="NVarChar(250)")]
        public string EvidenceImage
        {
            get
            {
                return this._EvidenceImage;
            }
            set
            {
                if (this._EvidenceImage != value)
                {
                    this.SendPropertyChanging();
                    this._EvidenceImage = value;
                    this.SendPropertyChanged("EvidenceImage");
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

        [Column(Storage="_IsAppeal", DbType="Int")]
        public int? IsAppeal
        {
            get
            {
                return this._IsAppeal;
            }
            set
            {
                if (this._IsAppeal != value)
                {
                    this.SendPropertyChanging();
                    this._IsAppeal = value;
                    this.SendPropertyChanged("IsAppeal");
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string MemLoginID
        {
            get
            {
                return this._MemLoginID;
            }
            set
            {
                if (this._MemLoginID != value)
                {
                    this.SendPropertyChanging();
                    this._MemLoginID = value;
                    this.SendPropertyChanged("MemLoginID");
                }
            }
        }

        [Column(Storage="_OperateUser", DbType="NVarChar(50)")]
        public string OperateUser
        {
            get
            {
                return this._OperateUser;
            }
            set
            {
                if (this._OperateUser != value)
                {
                    this.SendPropertyChanging();
                    this._OperateUser = value;
                    this.SendPropertyChanged("OperateUser");
                }
            }
        }

        [Column(Storage="_OrderGuid", DbType="UniqueIdentifier")]
        public Guid? OrderGuid
        {
            get
            {
                return this._OrderGuid;
            }
            set
            {
                if (this._OrderGuid != value)
                {
                    this.SendPropertyChanging();
                    this._OrderGuid = value;
                    this.SendPropertyChanged("OrderGuid");
                }
            }
        }

        [Column(Storage="_OrderID", DbType="NVarChar(100)")]
        public string OrderID
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

        [Column(Storage="_ProcessingResults", DbType="NVarChar(1000)")]
        public string ProcessingResults
        {
            get
            {
                return this._ProcessingResults;
            }
            set
            {
                if (this._ProcessingResults != value)
                {
                    this.SendPropertyChanging();
                    this._ProcessingResults = value;
                    this.SendPropertyChanged("ProcessingResults");
                }
            }
        }

        [Column(Storage="_ProcessingStatus", DbType="Int")]
        public int? ProcessingStatus
        {
            get
            {
                return this._ProcessingStatus;
            }
            set
            {
                if (this._ProcessingStatus != value)
                {
                    this.SendPropertyChanging();
                    this._ProcessingStatus = value;
                    this.SendPropertyChanged("ProcessingStatus");
                }
            }
        }

        [Column(Storage="_ProcessingTime", DbType="DateTime")]
        public DateTime? ProcessingTime
        {
            get
            {
                return this._ProcessingTime;
            }
            set
            {
                if (this._ProcessingTime != value)
                {
                    this.SendPropertyChanging();
                    this._ProcessingTime = value;
                    this.SendPropertyChanged("ProcessingTime");
                }
            }
        }
    }
}

