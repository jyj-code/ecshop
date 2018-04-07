namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Weixin_ShopMenu")]
    public class ShopNum1_Weixin_ShopMenu : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _ID;
        private string _Name;
        private int? _PId;
        private string _ShopMemLoginId;
        private int? _Sort;
        private string _value;
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

        [Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                }
            }
        }

        [Column(Storage="_Name", DbType="VarChar(16)")]
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

        [Column(Storage="_PId", DbType="Int")]
        public int? PId
        {
            get
            {
                return this._PId;
            }
            set
            {
                if (this._PId != value)
                {
                    this.SendPropertyChanging();
                    this._PId = value;
                    this.SendPropertyChanged("PId");
                }
            }
        }

        [Column(Storage="_ShopMemLoginId", DbType="NVarChar(50)")]
        public string ShopMemLoginId
        {
            get
            {
                return this._ShopMemLoginId;
            }
            set
            {
                if (this._ShopMemLoginId != value)
                {
                    this.SendPropertyChanging();
                    this._ShopMemLoginId = value;
                    this.SendPropertyChanged("ShopMemLoginId");
                }
            }
        }

        [Column(Storage="_Sort", DbType="Int")]
        public int? Sort
        {
            get
            {
                return this._Sort;
            }
            set
            {
                if (this._Sort != value)
                {
                    this.SendPropertyChanging();
                    this._Sort = value;
                    this.SendPropertyChanged("Sort");
                }
            }
        }

        [Column(Storage="_value", DbType="VarChar(50)")]
        public string value
        {
            get
            {
                return this._value;
            }
            set
            {
                if (this._value != value)
                {
                    this.SendPropertyChanging();
                    this._value = value;
                    this.SendPropertyChanged("value");
                }
            }
        }
    }
}

