namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_OrderScore")]
    public class ShopNum1_OrderScore
    {
        private DateTime _CreateTime;
        private int? _GotScore;
        private System.Guid? _Guid;
        private int? _IsFinished;
        private string _MemLoginID;
        private int? _NeedScore;
        private string _OrderInfoGuid;
        private int? _Score;
        private string _ShopID;

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

        [Column(Storage="_GotScore", DbType="Int")]
        public int? GotScore
        {
            get
            {
                return this._GotScore;
            }
            set
            {
                if (this._GotScore != value)
                {
                    this._GotScore = value;
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier")]
        public System.Guid? Guid
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

        [Column(Storage="_IsFinished", DbType="Int")]
        public int? IsFinished
        {
            get
            {
                return this._IsFinished;
            }
            set
            {
                if (this._IsFinished != value)
                {
                    this._IsFinished = value;
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="NVarChar(50)")]
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

        [Column(Storage="_NeedScore", DbType="Int")]
        public int? NeedScore
        {
            get
            {
                return this._NeedScore;
            }
            set
            {
                if (this._NeedScore != value)
                {
                    this._NeedScore = value;
                }
            }
        }

        [Column(Storage="_OrderInfoGuid", DbType="NVarChar(50)")]
        public string OrderInfoGuid
        {
            get
            {
                return this._OrderInfoGuid;
            }
            set
            {
                if (this._OrderInfoGuid != value)
                {
                    this._OrderInfoGuid = value;
                }
            }
        }

        [Column(Storage="_Score", DbType="Int")]
        public int? Score
        {
            get
            {
                return this._Score;
            }
            set
            {
                if (this._Score != value)
                {
                    this._Score = value;
                }
            }
        }

        [Column(Storage="_ShopID", DbType="NVarChar(50)")]
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

