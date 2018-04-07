namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_IPManage")]
    public class ShopNum1_IPManage
    {
        private System.Guid _Guid;
        private string _IPBegin;
        private string _IPEnd;
        private string _IPGroupName;
        private string _Remark;
        private DateTime _TimeBegin;
        private DateTime _TimeEnd;

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

        [Column(Storage="_IPBegin", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string IPBegin
        {
            get
            {
                return this._IPBegin;
            }
            set
            {
                if (this._IPBegin != value)
                {
                    this._IPBegin = value;
                }
            }
        }

        [Column(Storage="_IPEnd", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string IPEnd
        {
            get
            {
                return this._IPEnd;
            }
            set
            {
                if (this._IPEnd != value)
                {
                    this._IPEnd = value;
                }
            }
        }

        [Column(Storage="_IPGroupName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string IPGroupName
        {
            get
            {
                return this._IPGroupName;
            }
            set
            {
                if (this._IPGroupName != value)
                {
                    this._IPGroupName = value;
                }
            }
        }

        [Column(Storage="_Remark", DbType="NVarChar(250)")]
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

        [Column(Storage="_TimeBegin", DbType="DateTime NOT NULL")]
        public DateTime TimeBegin
        {
            get
            {
                return this._TimeBegin;
            }
            set
            {
                if (this._TimeBegin != value)
                {
                    this._TimeBegin = value;
                }
            }
        }

        [Column(Storage="_TimeEnd", DbType="DateTime NOT NULL")]
        public DateTime TimeEnd
        {
            get
            {
                return this._TimeEnd;
            }
            set
            {
                if (this._TimeEnd != value)
                {
                    this._TimeEnd = value;
                }
            }
        }
    }
}

