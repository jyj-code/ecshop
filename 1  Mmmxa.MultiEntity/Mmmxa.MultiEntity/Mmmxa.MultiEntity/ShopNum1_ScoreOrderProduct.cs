namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_ScoreOrderProduct")]
    public class ShopNum1_ScoreOrderProduct
    {
        private int? _BuyNumber;
        private System.Guid? _Guid;
        private string _Name;
        private string _OrderNumber;
        private System.Guid? _ProductGuid;
        private string _RepertoryNumber;
        private int? _Score;

        [Column(Storage="_BuyNumber", DbType="Int")]
        public int? BuyNumber
        {
            get
            {
                return this._BuyNumber;
            }
            set
            {
                if (this._BuyNumber != value)
                {
                    this._BuyNumber = value;
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
                    this._Name = value;
                }
            }
        }

        [Column(Storage="_OrderNumber", DbType="VarChar(100)")]
        public string OrderNumber
        {
            get
            {
                return this._OrderNumber;
            }
            set
            {
                if (this._OrderNumber != value)
                {
                    this._OrderNumber = value;
                }
            }
        }

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier")]
        public System.Guid? ProductGuid
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

        [Column(Storage="_RepertoryNumber", DbType="VarChar(100)")]
        public string RepertoryNumber
        {
            get
            {
                return this._RepertoryNumber;
            }
            set
            {
                if (this._RepertoryNumber != value)
                {
                    this._RepertoryNumber = value;
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
    }
}

