namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Spec")]
    public class ShopNum1_Spec
    {
        private int? _ID;
        private string _Memo;
        private int? _OrderID;
        private int? _ShowType;
        private string _SpecName;
        private string _tbProp;

        [Column(Storage="_ID", DbType="Int")]
        public int? ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this._ID = value;
                }
            }
        }

        [Column(Storage="_Memo", DbType="VarChar(50)")]
        public string Memo
        {
            get
            {
                return this._Memo;
            }
            set
            {
                if (this._Memo != value)
                {
                    this._Memo = value;
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
                    this._OrderID = value;
                }
            }
        }

        [Column(Storage="_ShowType", DbType="Int")]
        public int? ShowType
        {
            get
            {
                return this._ShowType;
            }
            set
            {
                if (this._ShowType != value)
                {
                    this._ShowType = value;
                }
            }
        }

        [Column(Storage="_SpecName", DbType="VarChar(50)")]
        public string SpecName
        {
            get
            {
                return this._SpecName;
            }
            set
            {
                if (this._SpecName != value)
                {
                    this._SpecName = value;
                }
            }
        }

        [Column(Storage="_tbProp", DbType="VarChar(50)")]
        public string tbProp
        {
            get
            {
                return this._tbProp;
            }
            set
            {
                if (this._tbProp != value)
                {
                    this._tbProp = value;
                }
            }
        }
    }
}

