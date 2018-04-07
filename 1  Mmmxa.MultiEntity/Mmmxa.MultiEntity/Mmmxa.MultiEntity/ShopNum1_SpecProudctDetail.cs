namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_SpecProudctDetails")]
    public class ShopNum1_SpecProudctDetail
    {
        private Guid? _ProductGuid;
        private string _ProductImage;
        private int? _SpecId;
        private int? _SpecValueId;
        private string _SpecValueName;
        private int? _TypeId;

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier")]
        public Guid? ProductGuid
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

        [Column(Storage="_ProductImage", DbType="VarChar(100)")]
        public string ProductImage
        {
            get
            {
                return this._ProductImage;
            }
            set
            {
                if (this._ProductImage != value)
                {
                    this._ProductImage = value;
                }
            }
        }

        [Column(Storage="_SpecId", DbType="Int")]
        public int? SpecId
        {
            get
            {
                return this._SpecId;
            }
            set
            {
                if (this._SpecId != value)
                {
                    this._SpecId = value;
                }
            }
        }

        [Column(Storage="_SpecValueId", DbType="Int")]
        public int? SpecValueId
        {
            get
            {
                return this._SpecValueId;
            }
            set
            {
                if (this._SpecValueId != value)
                {
                    this._SpecValueId = value;
                }
            }
        }

        [Column(Storage="_SpecValueName", DbType="VarChar(50)")]
        public string SpecValueName
        {
            get
            {
                return this._SpecValueName;
            }
            set
            {
                if (this._SpecValueName != value)
                {
                    this._SpecValueName = value;
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

