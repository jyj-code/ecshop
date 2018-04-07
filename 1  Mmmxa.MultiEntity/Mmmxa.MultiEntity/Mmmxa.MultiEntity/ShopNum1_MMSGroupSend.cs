namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_MMSGroupSend")]
    public class ShopNum1_MMSGroupSend
    {
        private DateTime _CreateTime;
        private System.Guid _Guid;
        private int _IsTime;
        private System.Guid _MMSGuid;
        private string _MMSTitle;
        private string _SendObject;
        private string _SendObjectMMS;
        private int _State;
        private DateTime? _TimeSendTime;

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
                    this._CreateTime = value;
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

        [Column(Storage="_IsTime", DbType="Int NOT NULL")]
        public int IsTime
        {
            get
            {
                return this._IsTime;
            }
            set
            {
                if (this._IsTime != value)
                {
                    this._IsTime = value;
                }
            }
        }

        [Column(Storage="_MMSGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid MMSGuid
        {
            get
            {
                return this._MMSGuid;
            }
            set
            {
                if (this._MMSGuid != value)
                {
                    this._MMSGuid = value;
                }
            }
        }

        [Column(Storage="_MMSTitle", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string MMSTitle
        {
            get
            {
                return this._MMSTitle;
            }
            set
            {
                if (this._MMSTitle != value)
                {
                    this._MMSTitle = value;
                }
            }
        }

        [Column(Storage="_SendObject", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string SendObject
        {
            get
            {
                return this._SendObject;
            }
            set
            {
                if (this._SendObject != value)
                {
                    this._SendObject = value;
                }
            }
        }

        [Column(Storage="_SendObjectMMS", DbType="NVarChar(4000) NOT NULL", CanBeNull=false)]
        public string SendObjectMMS
        {
            get
            {
                return this._SendObjectMMS;
            }
            set
            {
                if (this._SendObjectMMS != value)
                {
                    this._SendObjectMMS = value;
                }
            }
        }

        [Column(Storage="_State", DbType="Int NOT NULL")]
        public int State
        {
            get
            {
                return this._State;
            }
            set
            {
                if (this._State != value)
                {
                    this._State = value;
                }
            }
        }

        [Column(Storage="_TimeSendTime", DbType="DateTime")]
        public DateTime? TimeSendTime
        {
            get
            {
                return this._TimeSendTime;
            }
            set
            {
                if (this._TimeSendTime != value)
                {
                    this._TimeSendTime = value;
                }
            }
        }
    }
}

