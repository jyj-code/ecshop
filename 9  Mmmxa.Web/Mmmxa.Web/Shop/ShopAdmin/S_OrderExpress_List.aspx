<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="S_OrderExpress_List" Codebehind="S_OrderExpress_List.aspx.cs" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="style/css.css" />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">快递单列表</span></p>
        <div class="content">
            <div class="order_edit" style="margin-top: 10px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top">
                            <asp:LinkButton ID="ButtonAdd" runat="server" OnClientClick="GetCheckedBoxValues()"
                                CausesValidation="False" CssClass="tianjia2 lmf_btn" OnClick="ButtonAdd_Click"><span>添加</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="ButtonEdit" runat="server" OnClientClick="return EditButton()"
                                CausesValidation="False" CssClass="bji lmf_btn" OnClick="ButtonEdit_Click"><span>编辑</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="ButtonDelete" runat="server" OnClientClick="return DeleteButton()"
                                CausesValidation="False" CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click">批量删除</asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="order_list">
                <cc1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                    descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="100%"
                    Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                    PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0px"
                    CellPadding="4" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="th_le"></HeaderStyle>
                    <%--分页--%>
                    <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="40px">
                            <HeaderTemplate>
                                <input id="checkboxAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox" />
                            </HeaderTemplate>
                            <HeaderStyle CssClass="select_width" />
                            <ItemTemplate>
                                <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="center12" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="单据名称" SortExpression="Name">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="是否启用" SortExpression="IsDefault" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("IsDefault").ToString()=="0"?"否":"是"%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </cc1:Num1GridView>
            </div>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_OrderExpress_Action" OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
