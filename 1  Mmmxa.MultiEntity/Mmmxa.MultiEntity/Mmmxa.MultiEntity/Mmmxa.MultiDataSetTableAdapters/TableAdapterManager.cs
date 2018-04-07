using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
namespace ShopNum1MultiEntity.ShopNum1_MultiDataSetTableAdapters
{
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), HelpKeyword("vs.data.TableAdapterManager"), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), DesignerCategory("code"), ToolboxItem(true)]
    public class TableAdapterManager : Component
    {
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public enum UpdateOrderOption
        {
            InsertUpdateDelete,
            UpdateInsertDelete
        }
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        private class SelfReferenceComparer : IComparer<DataRow>
        {
            private DataRelation _relation;
            private int _childFirst;
            [DebuggerNonUserCode]
            internal SelfReferenceComparer(DataRelation relation, bool childFirst)
            {
                this._relation = relation;
                if (childFirst)
                {
                    this._childFirst = -1;
                }
                else
                {
                    this._childFirst = 1;
                }
            }
            [DebuggerNonUserCode]
            private bool IsChildAndParent(DataRow child, DataRow parent)
            {
                Debug.Assert(child != null);
                Debug.Assert(parent != null);
                DataRow parentRow = child.GetParentRow(this._relation, DataRowVersion.Default);
                while (parentRow != null && !object.ReferenceEquals(parentRow, child) && !object.ReferenceEquals(parentRow, parent))
                {
                    parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Default);
                }
                if (parentRow == null)
                {
                    parentRow = child.GetParentRow(this._relation, DataRowVersion.Original);
                    while (parentRow != null && !object.ReferenceEquals(parentRow, child) && !object.ReferenceEquals(parentRow, parent))
                    {
                        parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Original);
                    }
                }
                return object.ReferenceEquals(parentRow, parent);
            }
            [DebuggerNonUserCode]
            public int Compare(DataRow row1, DataRow row2)
            {
                int result;
                if (object.ReferenceEquals(row1, row2))
                {
                    result = 0;
                }
                else if (row1 == null)
                {
                    result = -1;
                }
                else if (row2 == null)
                {
                    result = 1;
                }
                else if (this.IsChildAndParent(row1, row2))
                {
                    result = this._childFirst;
                }
                else if (this.IsChildAndParent(row2, row1))
                {
                    result = -1 * this._childFirst;
                }
                else
                {
                    result = 0;
                }
                return result;
            }
        }
        private TableAdapterManager.UpdateOrderOption _updateOrder;
        private ShopNum1_ShopInfoTableAdapter _shopNum1_ShopInfoTableAdapter;
        private bool _backupDataSetBeforeUpdate;
        private IDbConnection _connection;
        [DebuggerNonUserCode]
        public TableAdapterManager.UpdateOrderOption UpdateOrder
        {
            get
            {
                return this._updateOrder;
            }
            set
            {
                this._updateOrder = value;
            }
        }
        [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor"), DebuggerNonUserCode]
        public ShopNum1_ShopInfoTableAdapter ShopNum1_ShopInfoTableAdapter
        {
            get
            {
                return this._shopNum1_ShopInfoTableAdapter;
            }
            set
            {
                this._shopNum1_ShopInfoTableAdapter = value;
            }
        }
        [DebuggerNonUserCode]
        public bool BackupDataSetBeforeUpdate
        {
            get
            {
                return this._backupDataSetBeforeUpdate;
            }
            set
            {
                this._backupDataSetBeforeUpdate = value;
            }
        }
        [Browsable(false), DebuggerNonUserCode]
        public IDbConnection Connection
        {
            get
            {
                IDbConnection result;
                if (this._connection != null)
                {
                    result = this._connection;
                }
                else if (this._shopNum1_ShopInfoTableAdapter != null && this._shopNum1_ShopInfoTableAdapter.Connection != null)
                {
                    result = this._shopNum1_ShopInfoTableAdapter.Connection;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            set
            {
                this._connection = value;
            }
        }
        [Browsable(false), DebuggerNonUserCode]
        public int TableAdapterInstanceCount
        {
            get
            {
                int num = 0;
                if (this._shopNum1_ShopInfoTableAdapter != null)
                {
                    num++;
                }
                return num;
            }
        }
        [DebuggerNonUserCode]
        private int UpdateUpdatedRows(ShopNum1_MultiDataSet dataSet, List<DataRow> allChangedRows, List<DataRow> allAddedRows)
        {
            int num = 0;
            if (this._shopNum1_ShopInfoTableAdapter != null)
            {
                DataRow[] array = dataSet.ShopNum1_ShopInfo.Select(null, null, DataViewRowState.ModifiedCurrent);
                array = this.GetRealUpdatedRows(array, allAddedRows);
                if (array != null && 0 < array.Length)
                {
                    num += this._shopNum1_ShopInfoTableAdapter.Update(array);
                    allChangedRows.AddRange(array);
                }
            }
            return num;
        }
        [DebuggerNonUserCode]
        private int UpdateInsertedRows(ShopNum1_MultiDataSet dataSet, List<DataRow> allAddedRows)
        {
            int num = 0;
            if (this._shopNum1_ShopInfoTableAdapter != null)
            {
                DataRow[] array = dataSet.ShopNum1_ShopInfo.Select(null, null, DataViewRowState.Added);
                if (array != null && 0 < array.Length)
                {
                    num += this._shopNum1_ShopInfoTableAdapter.Update(array);
                    allAddedRows.AddRange(array);
                }
            }
            return num;
        }
        [DebuggerNonUserCode]
        private int UpdateDeletedRows(ShopNum1_MultiDataSet dataSet, List<DataRow> allChangedRows)
        {
            int num = 0;
            if (this._shopNum1_ShopInfoTableAdapter != null)
            {
                DataRow[] array = dataSet.ShopNum1_ShopInfo.Select(null, null, DataViewRowState.Deleted);
                if (array != null && 0 < array.Length)
                {
                    num += this._shopNum1_ShopInfoTableAdapter.Update(array);
                    allChangedRows.AddRange(array);
                }
            }
            return num;
        }
        [DebuggerNonUserCode]
        private DataRow[] GetRealUpdatedRows(DataRow[] updatedRows, List<DataRow> allAddedRows)
        {
            DataRow[] result;
            if (updatedRows == null || updatedRows.Length < 1)
            {
                result = updatedRows;
            }
            else if (allAddedRows == null || allAddedRows.Count < 1)
            {
                result = updatedRows;
            }
            else
            {
                List<DataRow> list = new List<DataRow>();
                for (int i = 0; i < updatedRows.Length; i++)
                {
                    DataRow item = updatedRows[i];
                    if (!allAddedRows.Contains(item))
                    {
                        list.Add(item);
                    }
                }
                result = list.ToArray();
            }
            return result;
        }
        [DebuggerNonUserCode]
        public virtual int UpdateAll(ShopNum1_MultiDataSet dataSet)
        {
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet");
            }
            int result;
            if (!dataSet.HasChanges())
            {
                result = 0;
            }
            else
            {
                if (this._shopNum1_ShopInfoTableAdapter != null && !this.MatchTableAdapterConnection(this._shopNum1_ShopInfoTableAdapter.Connection))
                {
                    throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
                }
                IDbConnection connection = this.Connection;
                if (connection == null)
                {
                    throw new ApplicationException("TableAdapterManager contains no connection information. Set each TableAdapterManager TableAdapter property to a valid TableAdapter instance.");
                }
                bool flag = false;
                if ((connection.State & ConnectionState.Broken) == ConnectionState.Broken)
                {
                    connection.Close();
                }
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    flag = true;
                }
                IDbTransaction dbTransaction = connection.BeginTransaction();
                if (dbTransaction == null)
                {
                    throw new ApplicationException("The transaction cannot begin. The current data connection does not support transactions or the current state is not allowing the transaction to begin.");
                }
                List<DataRow> list = new List<DataRow>();
                List<DataRow> list2 = new List<DataRow>();
                List<DataAdapter> list3 = new List<DataAdapter>();
                Dictionary<object, IDbConnection> dictionary = new Dictionary<object, IDbConnection>();
                int num = 0;
                DataSet dataSet2 = null;
                if (this.BackupDataSetBeforeUpdate)
                {
                    dataSet2 = new DataSet();
                    dataSet2.Merge(dataSet);
                }
                try
                {
                    if (this._shopNum1_ShopInfoTableAdapter != null)
                    {
                        dictionary.Add(this._shopNum1_ShopInfoTableAdapter, this._shopNum1_ShopInfoTableAdapter.Connection);
                        this._shopNum1_ShopInfoTableAdapter.Connection = (SqlConnection)connection;
                        this._shopNum1_ShopInfoTableAdapter.Transaction = (SqlTransaction)dbTransaction;
                        if (this._shopNum1_ShopInfoTableAdapter.Adapter.AcceptChangesDuringUpdate)
                        {
                            this._shopNum1_ShopInfoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
                            list3.Add(this._shopNum1_ShopInfoTableAdapter.Adapter);
                        }
                    }
                    if (this.UpdateOrder == TableAdapterManager.UpdateOrderOption.UpdateInsertDelete)
                    {
                        num += this.UpdateUpdatedRows(dataSet, list, list2);
                        num += this.UpdateInsertedRows(dataSet, list2);
                    }
                    else
                    {
                        num += this.UpdateInsertedRows(dataSet, list2);
                        num += this.UpdateUpdatedRows(dataSet, list, list2);
                    }
                    num += this.UpdateDeletedRows(dataSet, list);
                    dbTransaction.Commit();
                    if (0 < list2.Count)
                    {
                        DataRow[] array = new DataRow[list2.Count];
                        list2.CopyTo(array);
                        for (int i = 0; i < array.Length; i++)
                        {
                            DataRow dataRow = array[i];
                            dataRow.AcceptChanges();
                        }
                    }
                    if (0 < list.Count)
                    {
                        DataRow[] array = new DataRow[list.Count];
                        list.CopyTo(array);
                        for (int i = 0; i < array.Length; i++)
                        {
                            DataRow dataRow = array[i];
                            dataRow.AcceptChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    if (this.BackupDataSetBeforeUpdate)
                    {
                        Debug.Assert(dataSet2 != null);
                        dataSet.Clear();
                        dataSet.Merge(dataSet2);
                    }
                    else if (0 < list2.Count)
                    {
                        DataRow[] array = new DataRow[list2.Count];
                        list2.CopyTo(array);
                        for (int i = 0; i < array.Length; i++)
                        {
                            DataRow dataRow = array[i];
                            dataRow.AcceptChanges();
                            dataRow.SetAdded();
                        }
                    }
                    throw ex;
                }
                finally
                {
                    if (flag)
                    {
                        connection.Close();
                    }
                    if (this._shopNum1_ShopInfoTableAdapter != null)
                    {
                        this._shopNum1_ShopInfoTableAdapter.Connection = (SqlConnection)dictionary[this._shopNum1_ShopInfoTableAdapter];
                        this._shopNum1_ShopInfoTableAdapter.Transaction = null;
                    }
                    if (0 < list3.Count)
                    {
                        DataAdapter[] array2 = new DataAdapter[list3.Count];
                        list3.CopyTo(array2);
                        for (int i = 0; i < array2.Length; i++)
                        {
                            DataAdapter dataAdapter = array2[i];
                            dataAdapter.AcceptChangesDuringUpdate = true;
                        }
                    }
                }
                result = num;
            }
            return result;
        }
        [DebuggerNonUserCode]
        protected virtual void SortSelfReferenceRows(DataRow[] rows, DataRelation relation, bool childFirst)
        {
            Array.Sort<DataRow>(rows, new TableAdapterManager.SelfReferenceComparer(relation, childFirst));
        }
        [DebuggerNonUserCode]
        protected virtual bool MatchTableAdapterConnection(IDbConnection inputConnection)
        {
            return this._connection != null || (this.Connection == null || inputConnection == null) || string.Equals(this.Connection.ConnectionString, inputConnection.ConnectionString, StringComparison.Ordinal);
        }
    }
}
