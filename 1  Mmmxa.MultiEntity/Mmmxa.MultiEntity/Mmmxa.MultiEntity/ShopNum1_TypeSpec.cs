namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_TypeSpec")]
    public class ShopNum1_TypeSpec
    {
        private int? _SpecID;
        private int? _TypeID;

        [Column(Storage="_SpecID", DbType="Int")]
        public int? SpecID
        {
            get
            {
                return this._SpecID;
            }
            set
            {
                if (this._SpecID != value)
                {
                    this._SpecID = value;
                }
            }
        }

        [Column(Storage="_TypeID", DbType="Int")]
        public int? TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                if (this._TypeID != value)
                {
                    this._TypeID = value;
                }
            }
        }
    }
}

