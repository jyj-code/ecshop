namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_TypeProp")]
    public class ShopNum1_TypeProp
    {
        private int? _PropId;
        private int? _TypeId;

        [Column(Storage="_PropId", DbType="Int")]
        public int? PropId
        {
            get
            {
                return this._PropId;
            }
            set
            {
                if (this._PropId != value)
                {
                    this._PropId = value;
                }
            }
        }

        [Column(Storage="_TypeId", DbType="Int")]
        public int? TypeId
        {
            get
            {
                return this._TypeId;
            }
            set
            {
                if (this._TypeId != value)
                {
                    this._TypeId = value;
                }
            }
        }
    }
}

