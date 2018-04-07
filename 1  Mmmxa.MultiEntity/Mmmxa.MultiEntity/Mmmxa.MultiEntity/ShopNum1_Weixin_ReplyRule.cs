namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Weixin_ReplyRule")]
    public class ShopNum1_Weixin_ReplyRule : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime? _CreateTime;
        private int _ID;
        private byte? _Matching;
        private byte? _RepMsgType;
        private string _ShopMemLoginId;
        private byte? _Type;
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

        [Column(Storage="_Matching", DbType="TinyInt")]
        public byte? Matching
        {
            get
            {
                return this._Matching;
            }
            set
            {
                if (this._Matching != value)
                {
                    this.SendPropertyChanging();
                    this._Matching = value;
                    this.SendPropertyChanged("Matching");
                }
            }
        }

        [Column(Storage="_RepMsgType", DbType="TinyInt")]
        public byte? RepMsgType
        {
            get
            {
                return this._RepMsgType;
            }
            set
            {
                if (this._RepMsgType != value)
                {
                    this.SendPropertyChanging();
                    this._RepMsgType = value;
                    this.SendPropertyChanged("RepMsgType");
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

        [Column(Storage="_Type", DbType="TinyInt")]
        public byte? Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                if (this._Type != value)
                {
                    this.SendPropertyChanging();
                    this._Type = value;
                    this.SendPropertyChanged("Type");
                }
            }
        }
    }
}

