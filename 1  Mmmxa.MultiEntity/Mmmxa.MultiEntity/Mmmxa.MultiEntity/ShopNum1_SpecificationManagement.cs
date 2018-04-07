namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_SpecificationManagement")]
    public class ShopNum1_SpecificationManagement
    {
        private int _Guid;
        private string _Memo;
        private int _OrderID;
        private int _ShowType;
        private string _SpecificationName;
        private string _tbProp;

        [Column(Storage="_Guid", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
        public int Guid
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

        [Column(Storage="_Memo", DbType="NVarChar(50)")]
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

        [Column(Storage="_OrderID", DbType="Int NOT NULL")]
        public int OrderID
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

        [Column(Storage="_ShowType", DbType="Int NOT NULL")]
        public int ShowType
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

        [Column(Storage="_SpecificationName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string SpecificationName
        {
            get
            {
                return this._SpecificationName;
            }
            set
            {
                if (this._SpecificationName != value)
                {
                    this._SpecificationName = value;
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

