namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_MemberReport")]
    public class ShopNum1_MemberReport : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _ComplaintContent;
        private string _ComplaintImage;
        private DateTime? _ComplaintTime;
        private string _CustomerMessage;
        private string _Evidence;
        private string _EvidenceImage;
        private int _ID;
        private int _IsComplaint;
        private string _MemLoginID;
        private string _OperateUser;
        private string _ProcessingResults;
        private int? _ProcessingStatus;
        private DateTime? _ProcessingTime;
        private string _ProductUrl;
        private string _ReportShop;
        private DateTime? _ReportTime;
        private string _ReportType;
        private string _ShopProductID;
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

        [Column(Storage="_ComplaintImage", DbType="NVarChar(200)")]
        public string ComplaintImage
        {
            get
            {
                return this._ComplaintImage;
            }
            set
            {
                if (this._ComplaintImage != value)
                {
                    this.SendPropertyChanging();
                    this._ComplaintImage = value;
                    this.SendPropertyChanged("ComplaintImage");
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

        [Column(Storage="_IsComplaint", DbType="Int NOT NULL")]
        public int IsComplaint
        {
            get
            {
                return this._IsComplaint;
            }
            set
            {
                if (this._IsComplaint != value)
                {
                    this.SendPropertyChanging();
                    this._IsComplaint = value;
                    this.SendPropertyChanged("IsComplaint");
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

        [Column(Storage="_ProductUrl", DbType="NVarChar(250)")]
        public string ProductUrl
        {
            get
            {
                return this._ProductUrl;
            }
            set
            {
                if (this._ProductUrl != value)
                {
                    this.SendPropertyChanging();
                    this._ProductUrl = value;
                    this.SendPropertyChanged("ProductUrl");
                }
            }
        }

        [Column(Storage="_ReportShop", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ReportShop
        {
            get
            {
                return this._ReportShop;
            }
            set
            {
                if (this._ReportShop != value)
                {
                    this.SendPropertyChanging();
                    this._ReportShop = value;
                    this.SendPropertyChanged("ReportShop");
                }
            }
        }

        [Column(Storage="_ReportTime", DbType="DateTime")]
        public DateTime? ReportTime
        {
            get
            {
                return this._ReportTime;
            }
            set
            {
                if (this._ReportTime != value)
                {
                    this.SendPropertyChanging();
                    this._ReportTime = value;
                    this.SendPropertyChanged("ReportTime");
                }
            }
        }

        [Column(Storage="_ReportType", DbType="NVarChar(50)")]
        public string ReportType
        {
            get
            {
                return this._ReportType;
            }
            set
            {
                if (this._ReportType != value)
                {
                    this.SendPropertyChanging();
                    this._ReportType = value;
                    this.SendPropertyChanged("ReportType");
                }
            }
        }

        [Column(Storage="_ShopProductID", DbType="NVarChar(250)")]
        public string ShopProductID
        {
            get
            {
                return this._ShopProductID;
            }
            set
            {
                if (this._ShopProductID != value)
                {
                    this.SendPropertyChanging();
                    this._ShopProductID = value;
                    this.SendPropertyChanged("ShopProductID");
                }
            }
        }
    }
}

