namespace ShopNum1MultiEntity
{
    using System;

    public class CommonPageModel
    {
        private string _columns;
        private string _condition;
        private string _currentpage;
        private string _ordercolumn;
        private string _pagesize;
        private string _resultnum;
        private string _tablename;

        public string Columns
        {
            get
            {
                return this._columns;
            }
            set
            {
                this._columns = value;
            }
        }

        public string Condition
        {
            get
            {
                return this._condition;
            }
            set
            {
                this._condition = value;
            }
        }

        public string Currentpage
        {
            get
            {
                return this._currentpage;
            }
            set
            {
                this._currentpage = value;
            }
        }

        public string Ordercolumn
        {
            get
            {
                return this._ordercolumn;
            }
            set
            {
                this._ordercolumn = value;
            }
        }

        public string PageSize
        {
            get
            {
                return this._pagesize;
            }
            set
            {
                this._pagesize = value;
            }
        }

        public string Resultnum
        {
            get
            {
                return this._resultnum;
            }
            set
            {
                this._resultnum = value;
            }
        }

        public string Tablename
        {
            get
            {
                return this._tablename;
            }
            set
            {
                this._tablename = value;
            }
        }
    }
}

