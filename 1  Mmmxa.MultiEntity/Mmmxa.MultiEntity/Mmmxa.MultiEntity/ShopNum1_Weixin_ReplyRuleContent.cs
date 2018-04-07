namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Weixin_ReplyRuleContent")]
    public class ShopNum1_Weixin_ReplyRuleContent : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Description;
        private int _ID;
        private string _ImgSrc;
        private string _RepMsgContent;
        private int? _RuleId;
        private string _Title;
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

        [Column(Storage="_Description", DbType="NVarChar(200)")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                if (this._Description != value)
                {
                    this.SendPropertyChanging();
                    this._Description = value;
                    this.SendPropertyChanged("Description");
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

        [Column(Storage="_ImgSrc", DbType="VarChar(200)")]
        public string ImgSrc
        {
            get
            {
                return this._ImgSrc;
            }
            set
            {
                if (this._ImgSrc != value)
                {
                    this.SendPropertyChanging();
                    this._ImgSrc = value;
                    this.SendPropertyChanged("ImgSrc");
                }
            }
        }

        [Column(Storage="_RepMsgContent", DbType="NVarChar(300)")]
        public string RepMsgContent
        {
            get
            {
                return this._RepMsgContent;
            }
            set
            {
                if (this._RepMsgContent != value)
                {
                    this.SendPropertyChanging();
                    this._RepMsgContent = value;
                    this.SendPropertyChanged("RepMsgContent");
                }
            }
        }

        [Column(Storage="_RuleId", DbType="Int")]
        public int? RuleId
        {
            get
            {
                return this._RuleId;
            }
            set
            {
                if (this._RuleId != value)
                {
                    this.SendPropertyChanging();
                    this._RuleId = value;
                    this.SendPropertyChanged("RuleId");
                }
            }
        }

        [Column(Storage="_Title", DbType="NVarChar(50)")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                if (this._Title != value)
                {
                    this.SendPropertyChanging();
                    this._Title = value;
                    this.SendPropertyChanged("Title");
                }
            }
        }
    }
}

