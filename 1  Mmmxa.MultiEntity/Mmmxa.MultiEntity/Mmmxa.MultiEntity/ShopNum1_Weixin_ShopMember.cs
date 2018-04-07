namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Weixin_ShopMember")]
    public class ShopNum1_Weixin_ShopMember : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private byte? _Group;
        private int _ID;
        private string _MemLoginId;
        private string _ShopMemLoginId;
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

        [Column(Name="[Group]", Storage="_Group", DbType="TinyInt")]
        public byte? Group
        {
            get
            {
                return this._Group;
            }
            set
            {
                if (this._Group != value)
                {
                    this.SendPropertyChanging();
                    this._Group = value;
                    this.SendPropertyChanged("Group");
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

        [Column(Storage="_MemLoginId", DbType="NVarChar(50)")]
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
    }
}

