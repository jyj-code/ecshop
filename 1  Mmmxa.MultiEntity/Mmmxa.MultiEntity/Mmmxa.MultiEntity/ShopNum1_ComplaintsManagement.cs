namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_ComplaintsManagement")]
    public class ShopNum1_ComplaintsManagement
    {
        private string _Evidence;
        private System.Guid _Guid;
        private string _MemLoginID;
        private string _ProcessingResult;
        private int? _ProcessingState;
        private DateTime? _ProcessingTime;
        private System.Guid _ProductGuid;
        private string _Remark;
        private DateTime _ReportTime;
        private int _ReportType;
        private string _ShopAppeal;
        private string _ShopID;

        [Column(Storage="_Evidence", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
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
                    this._Evidence = value;
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier NOT NULL")]
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
                    this._Guid = value;
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
                    this._MemLoginID = value;
                }
            }
        }

        [Column(Storage="_ProcessingResult", DbType="NVarChar(50)")]
        public string ProcessingResult
        {
            get
            {
                return this._ProcessingResult;
            }
            set
            {
                if (this._ProcessingResult != value)
                {
                    this._ProcessingResult = value;
                }
            }
        }

        [Column(Storage="_ProcessingState", DbType="Int")]
        public int? ProcessingState
        {
            get
            {
                return this._ProcessingState;
            }
            set
            {
                if (this._ProcessingState != value)
                {
                    this._ProcessingState = value;
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
                    this._ProcessingTime = value;
                }
            }
        }

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid ProductGuid
        {
            get
            {
                return this._ProductGuid;
            }
            set
            {
                if (this._ProductGuid != value)
                {
                    this._ProductGuid = value;
                }
            }
        }

        [Column(Storage="_Remark", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
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
                    this._Remark = value;
                }
            }
        }

        [Column(Storage="_ReportTime", DbType="DateTime NOT NULL")]
        public DateTime ReportTime
        {
            get
            {
                return this._ReportTime;
            }
            set
            {
                if (this._ReportTime != value)
                {
                    this._ReportTime = value;
                }
            }
        }

        [Column(Storage="_ReportType", DbType="Int NOT NULL")]
        public int ReportType
        {
            get
            {
                return this._ReportType;
            }
            set
            {
                if (this._ReportType != value)
                {
                    this._ReportType = value;
                }
            }
        }

        [Column(Storage="_ShopAppeal", DbType="NVarChar(200)")]
        public string ShopAppeal
        {
            get
            {
                return this._ShopAppeal;
            }
            set
            {
                if (this._ShopAppeal != value)
                {
                    this._ShopAppeal = value;
                }
            }
        }

        [Column(Storage="_ShopID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ShopID
        {
            get
            {
                return this._ShopID;
            }
            set
            {
                if (this._ShopID != value)
                {
                    this._ShopID = value;
                }
            }
        }
    }
}

