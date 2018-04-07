namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Weixin_ReplyRuleChirldContent")]
    public class ShopNum1_Weixin_ReplyRuleChirldContent : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _ContentChirldId;
        private int? _ContentId;
        private int _ID;
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

        [Column(Storage="_ContentChirldId", DbType="NChar(10)")]
        public string ContentChirldId
        {
            get
            {
                return this._ContentChirldId;
            }
            set
            {
                if (this._ContentChirldId != value)
                {
                    this.SendPropertyChanging();
                    this._ContentChirldId = value;
                    this.SendPropertyChanged("ContentChirldId");
                }
            }
        }

        [Column(Storage="_ContentId", DbType="Int")]
        public int? ContentId
        {
            get
            {
                return this._ContentId;
            }
            set
            {
                if (this._ContentId != value)
                {
                    this.SendPropertyChanging();
                    this._ContentId = value;
                    this.SendPropertyChanged("ContentId");
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
    }
}

