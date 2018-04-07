namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ComplaintsReply")]
    public class ShopNum1_ComplaintsReply : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private Guid _ComplaintsManagementGuid;
        private Guid _guid;
        private DateTime _RepalyTime;
        private string _ReplayContent;
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

        [Column(Storage="_ComplaintsManagementGuid", DbType="UniqueIdentifier NOT NULL")]
        public Guid ComplaintsManagementGuid
        {
            get
            {
                return this._ComplaintsManagementGuid;
            }
            set
            {
                if (this._ComplaintsManagementGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ComplaintsManagementGuid = value;
                    this.SendPropertyChanged("ComplaintsManagementGuid");
                }
            }
        }

        [Column(Storage="_guid", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
        public Guid guid
        {
            get
            {
                return this._guid;
            }
            set
            {
                if (this._guid != value)
                {
                    this.SendPropertyChanging();
                    this._guid = value;
                    this.SendPropertyChanged("guid");
                }
            }
        }

        [Column(Storage="_RepalyTime", DbType="DateTime NOT NULL")]
        public DateTime RepalyTime
        {
            get
            {
                return this._RepalyTime;
            }
            set
            {
                if (this._RepalyTime != value)
                {
                    this.SendPropertyChanging();
                    this._RepalyTime = value;
                    this.SendPropertyChanged("RepalyTime");
                }
            }
        }

        [Column(Storage="_ReplayContent", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
        public string ReplayContent
        {
            get
            {
                return this._ReplayContent;
            }
            set
            {
                if (this._ReplayContent != value)
                {
                    this.SendPropertyChanging();
                    this._ReplayContent = value;
                    this.SendPropertyChanged("ReplayContent");
                }
            }
        }
    }
}

