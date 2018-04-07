namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Weixin_ReplyRuleKey")]
    public class ShopNum1_Weixin_ReplyRuleKey : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _ID;
        private string _KeyWord;
        private int? _RuleId;
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

        [Column(Storage="_KeyWord", DbType="NVarChar(30)")]
        public string KeyWord
        {
            get
            {
                return this._KeyWord;
            }
            set
            {
                if (this._KeyWord != value)
                {
                    this.SendPropertyChanging();
                    this._KeyWord = value;
                    this.SendPropertyChanged("KeyWord");
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
    }
}

