namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Weixin_ReplyRuleContentArticle")]
    public class ShopNum1_Weixin_ReplyRuleContentArticle : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _ArticleContent;
        private int? _ContentID;
        private int _ID;
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

        [Column(Storage="_ArticleContent", DbType="Text", UpdateCheck=UpdateCheck.Never)]
        public string ArticleContent
        {
            get
            {
                return this._ArticleContent;
            }
            set
            {
                if (this._ArticleContent != value)
                {
                    this.SendPropertyChanging();
                    this._ArticleContent = value;
                    this.SendPropertyChanged("ArticleContent");
                }
            }
        }

        [Column(Storage="_ContentID", DbType="Int")]
        public int? ContentID
        {
            get
            {
                return this._ContentID;
            }
            set
            {
                if (this._ContentID != value)
                {
                    this.SendPropertyChanging();
                    this._ContentID = value;
                    this.SendPropertyChanged("ContentID");
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

