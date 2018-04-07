namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_PackAge")]
    public class ShopNum1_PackAge : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime? _CreateTime;
        private string _Desc;
        private int? _Fee;
        private decimal? _FeePrice;
        private int _Id;
        private string _MemloginId;
        private string _Name;
        private string _Pic;
        private decimal? _Price;
        private decimal? _SalePrice;
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

        [Column(Storage="_CreateTime", DbType="DateTime")]
        public DateTime? CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                if (this._CreateTime != value)
                {
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
                }
            }
        }

        [Column(Name="[Desc]", Storage="_Desc", DbType="VarChar(3000)")]
        public string Desc
        {
            get
            {
                return this._Desc;
            }
            set
            {
                if (this._Desc != value)
                {
                    this.SendPropertyChanging();
                    this._Desc = value;
                    this.SendPropertyChanged("Desc");
                }
            }
        }

        [Column(Storage="_Fee", DbType="Int")]
        public int? Fee
        {
            get
            {
                return this._Fee;
            }
            set
            {
                if (this._Fee != value)
                {
                    this.SendPropertyChanging();
                    this._Fee = value;
                    this.SendPropertyChanged("Fee");
                }
            }
        }

        [Column(Storage="_FeePrice", DbType="Decimal(18,2)")]
        public decimal? FeePrice
        {
            get
            {
                return this._FeePrice;
            }
            set
            {
                decimal? nullable = this._FeePrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._FeePrice = value;
                    this.SendPropertyChanged("FeePrice");
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

        [Column(Storage="_MemloginId", DbType="VarChar(50)")]
        public string MemloginId
        {
            get
            {
                return this._MemloginId;
            }
            set
            {
                if (this._MemloginId != value)
                {
                    this.SendPropertyChanging();
                    this._MemloginId = value;
                    this.SendPropertyChanged("MemloginId");
                }
            }
        }

        [Column(Storage="_Name", DbType="VarChar(50)")]
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
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                }
            }
        }

        [Column(Storage="_Pic", DbType="VarChar(200)")]
        public string Pic
        {
            get
            {
                return this._Pic;
            }
            set
            {
                if (this._Pic != value)
                {
                    this.SendPropertyChanging();
                    this._Pic = value;
                    this.SendPropertyChanged("Pic");
                }
            }
        }

        [Column(Storage="_Price", DbType="Decimal(18,2)")]
        public decimal? Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                decimal? nullable = this._Price;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._Price = value;
                    this.SendPropertyChanged("Price");
                }
            }
        }

        [Column(Storage="_SalePrice", DbType="Decimal(18,2)")]
        public decimal? SalePrice
        {
            get
            {
                return this._SalePrice;
            }
            set
            {
                decimal? nullable = this._SalePrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._SalePrice = value;
                    this.SendPropertyChanged("SalePrice");
                }
            }
        }

        [Column(Storage="_ShopName", DbType="VarChar(50)")]
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

