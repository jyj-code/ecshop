<%@ page language="C#" autoeventwireup="true" inherits="Admin_ControlData_List"   CodeBehind="ControlData_List.aspx.cs"      %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>模块数据列表</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

  
</head>
<body>
    <form id="form1" runat="server">
        <div id="right">
           <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    模块数据列表 </h3>
            </div>
            <div class="rr">
            </div>
        </div> 


           <div class="welcon clearfix">
              <div class="order_edit">
                    <asp:Button ID="ButtonAdd" runat="server" CausesValidation="False" Text="添加" OnClick="ButtonAdd_Click"
                        CssClass="tianjia2 picbtn"  />
                    <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="编辑" OnClick="ButtonEdit_Click" visible="false"
                        OnClientClick="return EditButton()" CssClass="dele" />
                    <asp:Button ID="ButtonDelete" runat="server" CausesValidation="False" Text="批量删除" OnClick="ButtonDelete_Click"
                        OnClientClick="return DeleteButton()" CssClass="shanchu com" />
                    <asp:Button ID="ButtonBack" runat="server" CausesValidation="False" Text="返回列表" CssClass="chongxinfs picbtn" 
                        OnClick="ButtonBack_Click" />
                    <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>



 
                <cc1:Num1GridView ID="num1GridiewShow" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataSourceID="ObjectDataSourceData" Width="100%"
                    AscendingImageUrl="~/images/SortAsc.gif" DescendingImageUrl="~/images/SortDesc.gif"
                    PageSize="5"  Font-Bold="False" AddSequenceColumn="False" AllowMultiColumnSorting="False"
                    BorderColor="#CCDDEF" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Del="False"
                    DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                    PagingStyle="None" Style="margin-left: 2px;" TableName="">
                    <HeaderStyle HorizontalAlign="Center" BackColor="#6699CC" Font-Bold="True" ForeColor="#FFFFFF">
                    </HeaderStyle>
                    <PagerStyle HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="center12" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Title" HeaderText="标题" SortExpression="Title">
                            <HeaderStyle HorizontalAlign="Center" CssClass="center11" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GroupID" HeaderText="数据组">
                            <HeaderStyle HorizontalAlign="Center" CssClass="center11" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="数据类型" SortExpression="DataType">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# ChangeDataType(Eval("DataType")) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="center11" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </cc1:Num1GridView>
        
    </div> 

    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_ControlData_Action" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="hiddenFieldGuid" Name="guid" PropertyName="Value"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" />
    <asp:HiddenField ID="HiddenFieldAgentID" runat="server" />
    </div> 
    </form>
</body>
</html>
