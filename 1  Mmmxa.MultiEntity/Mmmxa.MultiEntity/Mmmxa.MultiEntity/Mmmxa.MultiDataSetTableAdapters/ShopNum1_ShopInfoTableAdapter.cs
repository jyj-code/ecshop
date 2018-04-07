namespace ShopNum1MultiEntity.ShopNum1_MultiDataSetTableAdapters
{
    using ShopNum1MultiEntity;
    using ShopNum1MultiEntity.Properties;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;

    [DataObject(true), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ToolboxItem(true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code")]
    public class ShopNum1_ShopInfoTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        [DebuggerNonUserCode]
        public ShopNum1_ShopInfoTableAdapter()
        {
            this.ClearBeforeFill = true;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Delete(Guid Original_Guid, string Original_Name, string Original_SalesRange, string Original_Address, string Original_Memo, string Original_Banner, int? Original_ClickCount, int Original_CollectCount, DateTime Original_ApplyTime, DateTime Original_OpenTime, string Original_ModifyUser, DateTime Original_ModifyTime, int Original_IsAudit, int Original_IsDeleted, string Original_ShopCategoryID, string Original_MemberLoginID, string Original_RegionCode, int Original_IsHot, int Original_IsRecommend, int Original_IsVisits_)
        {
            int num2;
            this.Adapter.DeleteCommand.Parameters[0].Value = Original_Guid;
            if (Original_Name == null)
            {
                throw new ArgumentNullException("Original_Name");
            }
            this.Adapter.DeleteCommand.Parameters[1].Value = Original_Name;
            if (Original_SalesRange == null)
            {
                throw new ArgumentNullException("Original_SalesRange");
            }
            this.Adapter.DeleteCommand.Parameters[2].Value = Original_SalesRange;
            if (Original_Address == null)
            {
                throw new ArgumentNullException("Original_Address");
            }
            this.Adapter.DeleteCommand.Parameters[3].Value = Original_Address;
            if (Original_Memo == null)
            {
                throw new ArgumentNullException("Original_Memo");
            }
            this.Adapter.DeleteCommand.Parameters[4].Value = Original_Memo;
            if (Original_Banner == null)
            {
                this.Adapter.DeleteCommand.Parameters[5].Value = 1;
                this.Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.DeleteCommand.Parameters[5].Value = 0;
                this.Adapter.DeleteCommand.Parameters[6].Value = Original_Banner;
            }
            if (Original_ClickCount.HasValue)
            {
                this.Adapter.DeleteCommand.Parameters[7].Value = 0;
                this.Adapter.DeleteCommand.Parameters[8].Value = Original_ClickCount.Value;
            }
            else
            {
                this.Adapter.DeleteCommand.Parameters[7].Value = 1;
                this.Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
            }
            this.Adapter.DeleteCommand.Parameters[9].Value = Original_CollectCount;
            this.Adapter.DeleteCommand.Parameters[10].Value = Original_ApplyTime;
            this.Adapter.DeleteCommand.Parameters[11].Value = Original_OpenTime;
            if (Original_ModifyUser == null)
            {
                throw new ArgumentNullException("Original_ModifyUser");
            }
            this.Adapter.DeleteCommand.Parameters[12].Value = Original_ModifyUser;
            this.Adapter.DeleteCommand.Parameters[13].Value = Original_ModifyTime;
            this.Adapter.DeleteCommand.Parameters[14].Value = Original_IsAudit;
            this.Adapter.DeleteCommand.Parameters[15].Value = Original_IsDeleted;
            if (Original_ShopCategoryID == null)
            {
                throw new ArgumentNullException("Original_ShopCategoryID");
            }
            this.Adapter.DeleteCommand.Parameters[0x10].Value = Original_ShopCategoryID;
            if (Original_MemberLoginID == null)
            {
                throw new ArgumentNullException("Original_MemberLoginID");
            }
            this.Adapter.DeleteCommand.Parameters[0x11].Value = Original_MemberLoginID;
            if (Original_RegionCode == null)
            {
                throw new ArgumentNullException("Original_RegionCode");
            }
            this.Adapter.DeleteCommand.Parameters[0x12].Value = Original_RegionCode;
            this.Adapter.DeleteCommand.Parameters[0x13].Value = Original_IsHot;
            this.Adapter.DeleteCommand.Parameters[20].Value = Original_IsRecommend;
            this.Adapter.DeleteCommand.Parameters[0x15].Value = Original_IsVisits_;
            ConnectionState state = this.Adapter.DeleteCommand.Connection.State;
            if ((this.Adapter.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                this.Adapter.DeleteCommand.Connection.Open();
            }
            try
            {
                num2 = this.Adapter.DeleteCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Adapter.DeleteCommand.Connection.Close();
                }
            }
            return num2;
        }

        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Fill, true), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Fill(ShopNum1_MultiDataSet.ShopNum1_ShopInfoDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual ShopNum1_MultiDataSet.ShopNum1_ShopInfoDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            ShopNum1_MultiDataSet.ShopNum1_ShopInfoDataTable dataTable = new ShopNum1_MultiDataSet.ShopNum1_ShopInfoDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [DebuggerNonUserCode]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping();
            mapping.SourceTable = "Table";
            mapping.DataSetTable = "ShopNum1_ShopInfo";
            mapping.ColumnMappings.Add("Guid", "Guid");
            mapping.ColumnMappings.Add("Name", "Name");
            mapping.ColumnMappings.Add("SalesRange", "SalesRange");
            mapping.ColumnMappings.Add("Address", "Address");
            mapping.ColumnMappings.Add("Memo", "Memo");
            mapping.ColumnMappings.Add("Banner", "Banner");
            mapping.ColumnMappings.Add("ClickCount", "ClickCount");
            mapping.ColumnMappings.Add("CollectCount", "CollectCount");
            mapping.ColumnMappings.Add("ApplyTime", "ApplyTime");
            mapping.ColumnMappings.Add("OpenTime", "OpenTime");
            mapping.ColumnMappings.Add("ModifyUser", "ModifyUser");
            mapping.ColumnMappings.Add("ModifyTime", "ModifyTime");
            mapping.ColumnMappings.Add("IsAudit", "IsAudit");
            mapping.ColumnMappings.Add("IsDeleted", "IsDeleted");
            mapping.ColumnMappings.Add("ShopCategoryID", "ShopCategoryID");
            mapping.ColumnMappings.Add("MemberLoginID", "MemberLoginID");
            mapping.ColumnMappings.Add("RegionCode", "RegionCode");
            mapping.ColumnMappings.Add("IsHot", "IsHot");
            mapping.ColumnMappings.Add("IsRecommend", "IsRecommend");
            mapping.ColumnMappings.Add("IsVisits ", "IsVisits ");
            this._adapter.TableMappings.Add(mapping);
            this._adapter.DeleteCommand = new SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[ShopNum1_ShopInfo] WHERE (([Guid] = @Original_Guid) AND ([Name] = @Original_Name) AND ([SalesRange] = @Original_SalesRange) AND ([Address] = @Original_Address) AND ([Memo] = @Original_Memo) AND ((@IsNull_Banner = 1 AND [Banner] IS NULL) OR ([Banner] = @Original_Banner)) AND ((@IsNull_ClickCount = 1 AND [ClickCount] IS NULL) OR ([ClickCount] = @Original_ClickCount)) AND ([CollectCount] = @Original_CollectCount) AND ([ApplyTime] = @Original_ApplyTime) AND ([OpenTime] = @Original_OpenTime) AND ([ModifyUser] = @Original_ModifyUser) AND ([ModifyTime] = @Original_ModifyTime) AND ([IsAudit] = @Original_IsAudit) AND ([IsDeleted] = @Original_IsDeleted) AND ([ShopCategoryID] = @Original_ShopCategoryID) AND ([MemberLoginID] = @Original_MemberLoginID) AND ([RegionCode] = @Original_RegionCode) AND ([IsHot] = @Original_IsHot) AND ([IsRecommend] = @Original_IsRecommend) AND ([IsVisits ] = @Original_IsVisits_))";
            this._adapter.DeleteCommand.CommandType = CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Guid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Guid", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SalesRange", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SalesRange", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Memo", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Memo", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Banner", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Banner", DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Banner", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Banner", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClickCount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClickCount", DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClickCount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClickCount", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_CollectCount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CollectCount", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ApplyTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ApplyTime", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_OpenTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "OpenTime", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ModifyUser", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ModifyUser", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ModifyTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ModifyTime", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IsAudit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsAudit", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IsDeleted", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsDeleted", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ShopCategoryID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ShopCategoryID", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_MemberLoginID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "MemberLoginID", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_RegionCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "RegionCode", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IsHot", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsHot", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IsRecommend", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsRecommend", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IsVisits_", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsVisits ", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[ShopNum1_ShopInfo] ([Guid], [Name], [SalesRange], [Address], [Memo], [Banner], [ClickCount], [CollectCount], [ApplyTime], [OpenTime], [ModifyUser], [ModifyTime], [IsAudit], [IsDeleted], [ShopCategoryID], [MemberLoginID], [RegionCode], [IsHot], [IsRecommend], [IsVisits ]) VALUES (@Guid, @Name, @SalesRange, @Address, @Memo, @Banner, @ClickCount, @CollectCount, @ApplyTime, @OpenTime, @ModifyUser, @ModifyTime, @IsAudit, @IsDeleted, @ShopCategoryID, @MemberLoginID, @RegionCode, @IsHot, @IsRecommend, @IsVisits_);\r\nSELECT Guid, Name, SalesRange, Address, Memo, Banner, ClickCount, CollectCount, ApplyTime, OpenTime, ModifyUser, ModifyTime, IsAudit, IsDeleted, ShopCategoryID, MemberLoginID, RegionCode, IsHot, IsRecommend, [IsVisits ] FROM ShopNum1_ShopInfo WHERE (Guid = @Guid)";
            this._adapter.InsertCommand.CommandType = CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Guid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Guid", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SalesRange", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SalesRange", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Memo", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Memo", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Banner", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Banner", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClickCount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClickCount", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CollectCount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CollectCount", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ApplyTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ApplyTime", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@OpenTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "OpenTime", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ModifyUser", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ModifyUser", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ModifyTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ModifyTime", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsAudit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsAudit", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsDeleted", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsDeleted", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ShopCategoryID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ShopCategoryID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@MemberLoginID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "MemberLoginID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RegionCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "RegionCode", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsHot", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsHot", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsRecommend", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsRecommend", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsVisits_", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsVisits ", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[ShopNum1_ShopInfo] SET [Guid] = @Guid, [Name] = @Name, [SalesRange] = @SalesRange, [Address] = @Address, [Memo] = @Memo, [Banner] = @Banner, [ClickCount] = @ClickCount, [CollectCount] = @CollectCount, [ApplyTime] = @ApplyTime, [OpenTime] = @OpenTime, [ModifyUser] = @ModifyUser, [ModifyTime] = @ModifyTime, [IsAudit] = @IsAudit, [IsDeleted] = @IsDeleted, [ShopCategoryID] = @ShopCategoryID, [MemberLoginID] = @MemberLoginID, [RegionCode] = @RegionCode, [IsHot] = @IsHot, [IsRecommend] = @IsRecommend, [IsVisits ] = @IsVisits_ WHERE (([Guid] = @Original_Guid) AND ([Name] = @Original_Name) AND ([SalesRange] = @Original_SalesRange) AND ([Address] = @Original_Address) AND ([Memo] = @Original_Memo) AND ((@IsNull_Banner = 1 AND [Banner] IS NULL) OR ([Banner] = @Original_Banner)) AND ((@IsNull_ClickCount = 1 AND [ClickCount] IS NULL) OR ([ClickCount] = @Original_ClickCount)) AND ([CollectCount] = @Original_CollectCount) AND ([ApplyTime] = @Original_ApplyTime) AND ([OpenTime] = @Original_OpenTime) AND ([ModifyUser] = @Original_ModifyUser) AND ([ModifyTime] = @Original_ModifyTime) AND ([IsAudit] = @Original_IsAudit) AND ([IsDeleted] = @Original_IsDeleted) AND ([ShopCategoryID] = @Original_ShopCategoryID) AND ([MemberLoginID] = @Original_MemberLoginID) AND ([RegionCode] = @Original_RegionCode) AND ([IsHot] = @Original_IsHot) AND ([IsRecommend] = @Original_IsRecommend) AND ([IsVisits ] = @Original_IsVisits_));\r\nSELECT Guid, Name, SalesRange, Address, Memo, Banner, ClickCount, CollectCount, ApplyTime, OpenTime, ModifyUser, ModifyTime, IsAudit, IsDeleted, ShopCategoryID, MemberLoginID, RegionCode, IsHot, IsRecommend, [IsVisits ] FROM ShopNum1_ShopInfo WHERE (Guid = @Guid)";
            this._adapter.UpdateCommand.CommandType = CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Guid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Guid", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SalesRange", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SalesRange", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Memo", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Memo", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Banner", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Banner", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClickCount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClickCount", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CollectCount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CollectCount", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ApplyTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ApplyTime", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OpenTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "OpenTime", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ModifyUser", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ModifyUser", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ModifyTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ModifyTime", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsAudit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsAudit", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsDeleted", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsDeleted", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ShopCategoryID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ShopCategoryID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@MemberLoginID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "MemberLoginID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RegionCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "RegionCode", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsHot", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsHot", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsRecommend", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsRecommend", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsVisits_", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsVisits ", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Guid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Guid", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SalesRange", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SalesRange", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Memo", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Memo", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Banner", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Banner", DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Banner", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Banner", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClickCount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClickCount", DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClickCount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClickCount", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_CollectCount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CollectCount", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ApplyTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ApplyTime", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_OpenTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "OpenTime", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ModifyUser", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ModifyUser", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ModifyTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ModifyTime", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IsAudit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsAudit", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IsDeleted", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsDeleted", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ShopCategoryID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ShopCategoryID", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_MemberLoginID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "MemberLoginID", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_RegionCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "RegionCode", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IsHot", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsHot", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IsRecommend", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsRecommend", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IsVisits_", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsVisits ", DataRowVersion.Original, false, null, "", "", ""));
        }

        [DebuggerNonUserCode]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[] { new SqlCommand() };
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT Guid, Name, SalesRange, Address, Memo, Banner, ClickCount, CollectCount, ApplyTime, OpenTime, ModifyUser, ModifyTime, IsAudit, IsDeleted, ShopCategoryID, MemberLoginID, RegionCode, IsHot, IsRecommend, [IsVisits ] FROM dbo.ShopNum1_ShopInfo";
            this._commandCollection[0].CommandType = CommandType.Text;
        }

        [DebuggerNonUserCode]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.ShopNum1_MultiConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Insert(Guid Guid, string Name, string SalesRange, string Address, string Memo, string Banner, int? ClickCount, int CollectCount, DateTime ApplyTime, DateTime OpenTime, string ModifyUser, DateTime ModifyTime, int IsAudit, int IsDeleted, string ShopCategoryID, string MemberLoginID, string RegionCode, int IsHot, int IsRecommend, int IsVisits_)
        {
            int num2;
            this.Adapter.InsertCommand.Parameters[0].Value = Guid;
            if (Name == null)
            {
                throw new ArgumentNullException("Name");
            }
            this.Adapter.InsertCommand.Parameters[1].Value = Name;
            if (SalesRange == null)
            {
                throw new ArgumentNullException("SalesRange");
            }
            this.Adapter.InsertCommand.Parameters[2].Value = SalesRange;
            if (Address == null)
            {
                throw new ArgumentNullException("Address");
            }
            this.Adapter.InsertCommand.Parameters[3].Value = Address;
            if (Memo == null)
            {
                throw new ArgumentNullException("Memo");
            }
            this.Adapter.InsertCommand.Parameters[4].Value = Memo;
            if (Banner == null)
            {
                this.Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[5].Value = Banner;
            }
            if (ClickCount.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[6].Value = ClickCount.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
            }
            this.Adapter.InsertCommand.Parameters[7].Value = CollectCount;
            this.Adapter.InsertCommand.Parameters[8].Value = ApplyTime;
            this.Adapter.InsertCommand.Parameters[9].Value = OpenTime;
            if (ModifyUser == null)
            {
                throw new ArgumentNullException("ModifyUser");
            }
            this.Adapter.InsertCommand.Parameters[10].Value = ModifyUser;
            this.Adapter.InsertCommand.Parameters[11].Value = ModifyTime;
            this.Adapter.InsertCommand.Parameters[12].Value = IsAudit;
            this.Adapter.InsertCommand.Parameters[13].Value = IsDeleted;
            if (ShopCategoryID == null)
            {
                throw new ArgumentNullException("ShopCategoryID");
            }
            this.Adapter.InsertCommand.Parameters[14].Value = ShopCategoryID;
            if (MemberLoginID == null)
            {
                throw new ArgumentNullException("MemberLoginID");
            }
            this.Adapter.InsertCommand.Parameters[15].Value = MemberLoginID;
            if (RegionCode == null)
            {
                throw new ArgumentNullException("RegionCode");
            }
            this.Adapter.InsertCommand.Parameters[0x10].Value = RegionCode;
            this.Adapter.InsertCommand.Parameters[0x11].Value = IsHot;
            this.Adapter.InsertCommand.Parameters[0x12].Value = IsRecommend;
            this.Adapter.InsertCommand.Parameters[0x13].Value = IsVisits_;
            ConnectionState state = this.Adapter.InsertCommand.Connection.State;
            if ((this.Adapter.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                this.Adapter.InsertCommand.Connection.Open();
            }
            try
            {
                num2 = this.Adapter.InsertCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Adapter.InsertCommand.Connection.Close();
                }
            }
            return num2;
        }

        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(ShopNum1_MultiDataSet dataSet)
        {
            return this.Adapter.Update(dataSet, "ShopNum1_ShopInfo");
        }

        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(ShopNum1_MultiDataSet.ShopNum1_ShopInfoDataTable dataTable)
        {
            return this.Adapter.Update(dataTable);
        }

        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(DataRow dataRow)
        {
            return this.Adapter.Update(new DataRow[] { dataRow });
        }

        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Update(DataRow[] dataRows)
        {
            return this.Adapter.Update(dataRows);
        }

        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Update, true)]
        public virtual int Update(string Name, string SalesRange, string Address, string Memo, string Banner, int? ClickCount, int CollectCount, DateTime ApplyTime, DateTime OpenTime, string ModifyUser, DateTime ModifyTime, int IsAudit, int IsDeleted, string ShopCategoryID, string MemberLoginID, string RegionCode, int IsHot, int IsRecommend, int IsVisits_, Guid Original_Guid, string Original_Name, string Original_SalesRange, string Original_Address, string Original_Memo, string Original_Banner, int? Original_ClickCount, int Original_CollectCount, DateTime Original_ApplyTime, DateTime Original_OpenTime, string Original_ModifyUser, DateTime Original_ModifyTime, int Original_IsAudit, int Original_IsDeleted, string Original_ShopCategoryID, string Original_MemberLoginID, string Original_RegionCode, int Original_IsHot, int Original_IsRecommend, int Original_IsVisits_)
        {
            return this.Update(Original_Guid, Name, SalesRange, Address, Memo, Banner, ClickCount, CollectCount, ApplyTime, OpenTime, ModifyUser, ModifyTime, IsAudit, IsDeleted, ShopCategoryID, MemberLoginID, RegionCode, IsHot, IsRecommend, IsVisits_, Original_Guid, Original_Name, Original_SalesRange, Original_Address, Original_Memo, Original_Banner, Original_ClickCount, Original_CollectCount, Original_ApplyTime, Original_OpenTime, Original_ModifyUser, Original_ModifyTime, Original_IsAudit, Original_IsDeleted, Original_ShopCategoryID, Original_MemberLoginID, Original_RegionCode, Original_IsHot, Original_IsRecommend, Original_IsVisits_);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(Guid Guid, string Name, string SalesRange, string Address, string Memo, string Banner, int? ClickCount, int CollectCount, DateTime ApplyTime, DateTime OpenTime, string ModifyUser, DateTime ModifyTime, int IsAudit, int IsDeleted, string ShopCategoryID, string MemberLoginID, string RegionCode, int IsHot, int IsRecommend, int IsVisits_, Guid Original_Guid, string Original_Name, string Original_SalesRange, string Original_Address, string Original_Memo, string Original_Banner, int? Original_ClickCount, int Original_CollectCount, DateTime Original_ApplyTime, DateTime Original_OpenTime, string Original_ModifyUser, DateTime Original_ModifyTime, int Original_IsAudit, int Original_IsDeleted, string Original_ShopCategoryID, string Original_MemberLoginID, string Original_RegionCode, int Original_IsHot, int Original_IsRecommend, int Original_IsVisits_)
        {
            int num2;
            this.Adapter.UpdateCommand.Parameters[0].Value = Guid;
            if (Name == null)
            {
                throw new ArgumentNullException("Name");
            }
            this.Adapter.UpdateCommand.Parameters[1].Value = Name;
            if (SalesRange == null)
            {
                throw new ArgumentNullException("SalesRange");
            }
            this.Adapter.UpdateCommand.Parameters[2].Value = SalesRange;
            if (Address == null)
            {
                throw new ArgumentNullException("Address");
            }
            this.Adapter.UpdateCommand.Parameters[3].Value = Address;
            if (Memo == null)
            {
                throw new ArgumentNullException("Memo");
            }
            this.Adapter.UpdateCommand.Parameters[4].Value = Memo;
            if (Banner == null)
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = Banner;
            }
            if (ClickCount.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = ClickCount.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
            }
            this.Adapter.UpdateCommand.Parameters[7].Value = CollectCount;
            this.Adapter.UpdateCommand.Parameters[8].Value = ApplyTime;
            this.Adapter.UpdateCommand.Parameters[9].Value = OpenTime;
            if (ModifyUser == null)
            {
                throw new ArgumentNullException("ModifyUser");
            }
            this.Adapter.UpdateCommand.Parameters[10].Value = ModifyUser;
            this.Adapter.UpdateCommand.Parameters[11].Value = ModifyTime;
            this.Adapter.UpdateCommand.Parameters[12].Value = IsAudit;
            this.Adapter.UpdateCommand.Parameters[13].Value = IsDeleted;
            if (ShopCategoryID == null)
            {
                throw new ArgumentNullException("ShopCategoryID");
            }
            this.Adapter.UpdateCommand.Parameters[14].Value = ShopCategoryID;
            if (MemberLoginID == null)
            {
                throw new ArgumentNullException("MemberLoginID");
            }
            this.Adapter.UpdateCommand.Parameters[15].Value = MemberLoginID;
            if (RegionCode == null)
            {
                throw new ArgumentNullException("RegionCode");
            }
            this.Adapter.UpdateCommand.Parameters[0x10].Value = RegionCode;
            this.Adapter.UpdateCommand.Parameters[0x11].Value = IsHot;
            this.Adapter.UpdateCommand.Parameters[0x12].Value = IsRecommend;
            this.Adapter.UpdateCommand.Parameters[0x13].Value = IsVisits_;
            this.Adapter.UpdateCommand.Parameters[20].Value = Original_Guid;
            if (Original_Name == null)
            {
                throw new ArgumentNullException("Original_Name");
            }
            this.Adapter.UpdateCommand.Parameters[0x15].Value = Original_Name;
            if (Original_SalesRange == null)
            {
                throw new ArgumentNullException("Original_SalesRange");
            }
            this.Adapter.UpdateCommand.Parameters[0x16].Value = Original_SalesRange;
            if (Original_Address == null)
            {
                throw new ArgumentNullException("Original_Address");
            }
            this.Adapter.UpdateCommand.Parameters[0x17].Value = Original_Address;
            if (Original_Memo == null)
            {
                throw new ArgumentNullException("Original_Memo");
            }
            this.Adapter.UpdateCommand.Parameters[0x18].Value = Original_Memo;
            if (Original_Banner == null)
            {
                this.Adapter.UpdateCommand.Parameters[0x19].Value = 1;
                this.Adapter.UpdateCommand.Parameters[0x1a].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x19].Value = 0;
                this.Adapter.UpdateCommand.Parameters[0x1a].Value = Original_Banner;
            }
            if (Original_ClickCount.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[0x1b].Value = 0;
                this.Adapter.UpdateCommand.Parameters[0x1c].Value = Original_ClickCount.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x1b].Value = 1;
                this.Adapter.UpdateCommand.Parameters[0x1c].Value = DBNull.Value;
            }
            this.Adapter.UpdateCommand.Parameters[0x1d].Value = Original_CollectCount;
            this.Adapter.UpdateCommand.Parameters[30].Value = Original_ApplyTime;
            this.Adapter.UpdateCommand.Parameters[0x1f].Value = Original_OpenTime;
            if (Original_ModifyUser == null)
            {
                throw new ArgumentNullException("Original_ModifyUser");
            }
            this.Adapter.UpdateCommand.Parameters[0x20].Value = Original_ModifyUser;
            this.Adapter.UpdateCommand.Parameters[0x21].Value = Original_ModifyTime;
            this.Adapter.UpdateCommand.Parameters[0x22].Value = Original_IsAudit;
            this.Adapter.UpdateCommand.Parameters[0x23].Value = Original_IsDeleted;
            if (Original_ShopCategoryID == null)
            {
                throw new ArgumentNullException("Original_ShopCategoryID");
            }
            this.Adapter.UpdateCommand.Parameters[0x24].Value = Original_ShopCategoryID;
            if (Original_MemberLoginID == null)
            {
                throw new ArgumentNullException("Original_MemberLoginID");
            }
            this.Adapter.UpdateCommand.Parameters[0x25].Value = Original_MemberLoginID;
            if (Original_RegionCode == null)
            {
                throw new ArgumentNullException("Original_RegionCode");
            }
            this.Adapter.UpdateCommand.Parameters[0x26].Value = Original_RegionCode;
            this.Adapter.UpdateCommand.Parameters[0x27].Value = Original_IsHot;
            this.Adapter.UpdateCommand.Parameters[40].Value = Original_IsRecommend;
            this.Adapter.UpdateCommand.Parameters[0x29].Value = Original_IsVisits_;
            ConnectionState state = this.Adapter.UpdateCommand.Connection.State;
            if ((this.Adapter.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                this.Adapter.UpdateCommand.Connection.Open();
            }
            try
            {
                num2 = this.Adapter.UpdateCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Adapter.UpdateCommand.Connection.Close();
                }
            }
            return num2;
        }

        [DebuggerNonUserCode]
        protected internal SqlDataAdapter Adapter
        {
            get
            {
                if (this._adapter == null)
                {
                    this.InitAdapter();
                }
                return this._adapter;
            }
        }

        [DebuggerNonUserCode]
        public bool ClearBeforeFill
        {
            get
            {
                return this._clearBeforeFill;
            }
            set
            {
                this._clearBeforeFill = value;
            }
        }

        [DebuggerNonUserCode]
        protected SqlCommand[] CommandCollection
        {
            get
            {
                if (this._commandCollection == null)
                {
                    this.InitCommandCollection();
                }
                return this._commandCollection;
            }
        }

        [DebuggerNonUserCode]
        internal SqlConnection Connection
        {
            get
            {
                if (this._connection == null)
                {
                    this.InitConnection();
                }
                return this._connection;
            }
            set
            {
                this._connection = value;
                if (this.Adapter.InsertCommand != null)
                {
                    this.Adapter.InsertCommand.Connection = value;
                }
                if (this.Adapter.DeleteCommand != null)
                {
                    this.Adapter.DeleteCommand.Connection = value;
                }
                if (this.Adapter.UpdateCommand != null)
                {
                    this.Adapter.UpdateCommand.Connection = value;
                }
                for (int i = 0; i < this.CommandCollection.Length; i++)
                {
                    if (this.CommandCollection[i] != null)
                    {
                        this.CommandCollection[i].Connection = value;
                    }
                }
            }
        }

        [DebuggerNonUserCode]
        internal SqlTransaction Transaction
        {
            get
            {
                return this._transaction;
            }
            set
            {
                this._transaction = value;
                for (int i = 0; i < this.CommandCollection.Length; i++)
                {
                    this.CommandCollection[i].Transaction = this._transaction;
                }
                if ((this.Adapter != null) && (this.Adapter.DeleteCommand != null))
                {
                    this.Adapter.DeleteCommand.Transaction = this._transaction;
                }
                if ((this.Adapter != null) && (this.Adapter.InsertCommand != null))
                {
                    this.Adapter.InsertCommand.Transaction = this._transaction;
                }
                if ((this.Adapter != null) && (this.Adapter.UpdateCommand != null))
                {
                    this.Adapter.UpdateCommand.Transaction = this._transaction;
                }
            }
        }
    }
}

