namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1__Limt_Product")]
    public class ShopNum1_Limt_Product : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private decimal? _DisCount;
        private int _Id;
        private int? _Lid;
        private string _MemLoginId;
        private Guid? _ProductGuid;
        private string _ShopName;
        private int? _State;
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        [Column(Storage="_DisCount", DbType="Decimal(18,0)")]
        public decimal? DisCount
        {
            get
            {
                return this._DisCount;
            }
            set
            {
                decimal? nullable = this._DisCount;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._DisCount = value;
                    this.SendPropertyChanged("DisCount");
                }
            }
        }

        [Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                }
            }
        }

        [Column(Storage="_Lid", DbType="Int")]
        public int? Lid
        {
            get
            {
                return this._Lid;
            }
            set
            {
                if (this._Lid != value)
                {
                    this.SendPropertyChanging();
                    this._Lid = value;
                    this.SendPropertyChanged("Lid");
                }
            }
        }

        [Column(Storage="_MemLoginId", DbType="VarChar(50)")]
        public string MemLoginId
        {
            get
            {
                return this._MemLoginId;
            }
            set
            {
                if (this._MemLoginId != value)
                {
                    this.SendPropertyChanging();
                    this._MemLoginId = value;
                    this.SendPropertyChanged("MemLoginId");
                }
            }
        }

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
                    this.SendPropertyChanging();
                    this._ProductGuid = value;
                    this.SendPropertyChanged("ProductGuid");
                }
            }
        }

        [Column(Storage="_ShopName", DbType="VarChar(100)")]
        public string ShopName
        {
            get
            {
                return this._ShopName;
            }
            set
            {
                if (this._ShopName != value)
                {
                    this.SendPropertyChanging();
                    this._ShopName = value;
                    this.SendPropertyChanged("ShopName");
                }
            }
        }

        [Column(Storage="_State", DbType="Int")]
        public int? State
        {
            get
            {
                return this._State;
            }
            set
            {
                if (this._State != value)
                {
                    this.SendPropertyChanging();
                    this._State = value;
                    this.SendPropertyChanged("State");
                }
            }
        }
    }
}

