namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Weixin_ShopWeiXinConfig")]
    public class ShopNum1_Weixin_ShopWeiXinConfig : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _AppId;
        private string _AppSecret;
        private string _AttenRepKeys;
        private int _ID;
        private bool? _IsOpenAtten;
        private bool? _IsOpenNotFindKey;
        private string _NotFindKeys;
        private string _ShopMemLoginId;
        private string _ShopWeiXinId;
        private string _Token;
        private string _TokenURL;
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

        [Column(Storage="_AppId", DbType="VarChar(50)")]
        public string AppId
        {
            get
            {
                return this._AppId;
            }
            set
            {
                if (this._AppId != value)
                {
                    this.SendPropertyChanging();
                    this._AppId = value;
                    this.SendPropertyChanged("AppId");
                }
            }
        }

        [Column(Storage="_AppSecret", DbType="VarChar(50)")]
        public string AppSecret
        {
            get
            {
                return this._AppSecret;
            }
            set
            {
                if (this._AppSecret != value)
                {
                    this.SendPropertyChanging();
                    this._AppSecret = value;
                    this.SendPropertyChanged("AppSecret");
                }
            }
        }

        [Column(Storage="_AttenRepKeys", DbType="NVarChar(200)")]
        public string AttenRepKeys
        {
            get
            {
                return this._AttenRepKeys;
            }
            set
            {
                if (this._AttenRepKeys != value)
                {
                    this.SendPropertyChanging();
                    this._AttenRepKeys = value;
                    this.SendPropertyChanged("AttenRepKeys");
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

        [Column(Storage="_IsOpenAtten", DbType="Bit")]
        public bool? IsOpenAtten
        {
            get
            {
                return this._IsOpenAtten;
            }
            set
            {
                if (this._IsOpenAtten != value)
                {
                    this.SendPropertyChanging();
                    this._IsOpenAtten = value;
                    this.SendPropertyChanged("IsOpenAtten");
                }
            }
        }

        [Column(Storage="_IsOpenNotFindKey", DbType="Bit")]
        public bool? IsOpenNotFindKey
        {
            get
            {
                return this._IsOpenNotFindKey;
            }
            set
            {
                if (this._IsOpenNotFindKey != value)
                {
                    this.SendPropertyChanging();
                    this._IsOpenNotFindKey = value;
                    this.SendPropertyChanged("IsOpenNotFindKey");
                }
            }
        }

        [Column(Storage="_NotFindKeys", DbType="NVarChar(200)")]
        public string NotFindKeys
        {
            get
            {
                return this._NotFindKeys;
            }
            set
            {
                if (this._NotFindKeys != value)
                {
                    this.SendPropertyChanging();
                    this._NotFindKeys = value;
                    this.SendPropertyChanged("NotFindKeys");
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

        [Column(Storage="_ShopWeiXinId", DbType="NVarChar(50)")]
        public string ShopWeiXinId
        {
            get
            {
                return this._ShopWeiXinId;
            }
            set
            {
                if (this._ShopWeiXinId != value)
                {
                    this.SendPropertyChanging();
                    this._ShopWeiXinId = value;
                    this.SendPropertyChanged("ShopWeiXinId");
                }
            }
        }

        [Column(Storage="_Token", DbType="VarChar(50)")]
        public string Token
        {
            get
            {
                return this._Token;
            }
            set
            {
                if (this._Token != value)
                {
                    this.SendPropertyChanging();
                    this._Token = value;
                    this.SendPropertyChanged("Token");
                }
            }
        }

        [Column(Storage="_TokenURL", DbType="VarChar(200)")]
        public string TokenURL
        {
            get
            {
                return this._TokenURL;
            }
            set
            {
                if (this._TokenURL != value)
                {
                    this.SendPropertyChanging();
                    this._TokenURL = value;
                    this.SendPropertyChanged("TokenURL");
                }
            }
        }
    }
}

