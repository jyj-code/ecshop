<%@ page language="C#" autoeventwireup="true" inherits="Admin_UserDefinedColumn_List"   CodeBehind="UserDefinedColumn_List.aspx.cs"      %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
      <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <script type='text/javascript' src='js/resolution-test.js'></script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    主站栏目列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <%--<tr>
                        <td valign="top" class="lmf_app" style="line-height:36px;">分站名称：
                        </td>
                        <td><asp:DropDownList ID="DropDownListSubstationID" runat="server" AutoPostBack="true" Width="207px" CssClass="tselect"></asp:DropDownList></td>
                    </tr>--%>
                    <tr>
                        
                        <td valign="top" >
                            <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                class="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td><asp:LinkButton ID="ButtonEdit" runat="server" Visible="false" OnClick="ButtonEdit_Click" OnClientClick="return EditButton()"
                                CausesValidation="False" class="dele lmf_btn"><span>编辑</span></asp:LinkButton>
                            <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick="return DeleteButton()"
                                CausesValidation="False" class="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton></td>
                                <td><uc1:MessageShow ID="MessageShow" runat="server" Visible="False" /></td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                </table>
                
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical" Style="margin-top: 15px;">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle  CssClass="lmf_page"  BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="GUID" Visible="False" SortExpression="Guid"
                        ItemStyle-HorizontalAlign="Center" />
                    <%--<asp:TemplateField HeaderText="分站名称" SortExpression="ShopName">
                        <ItemTemplate>
                            <a>
                            <%#GetSubstationIDname(Eval("SubstationID").ToString())%>
                            </a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="Name" HeaderText="栏目名称" SortExpression="Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LinkAddress" HeaderText="链接地址" SortExpression="LinkAddress"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:TemplateField HeaderText="是否前台显示" SortExpression="IfShow" Visible="false">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IfShow").ToString()=="0"?"1":"0") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否会员中心显示" SortExpression="IsMember" Visible="false">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IsMember").ToString()=="0"?"1":"0") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否店铺前台显示" SortExpression="IsShop" Visible="false">
                        <ItemTemplate>
                            <asp:Image ID="Image3" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IsShop").ToString()=="0"?"1":"0") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="显示位置" SortExpression="IfOpen">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# ShowLocation(Eval("ShowLocation").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否在新窗口打开" SortExpression="IfOpen">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# ChangeIfOpen(Eval("IfOpen").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="OrderID" HeaderText="排序" SortExpression="OrderID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "UserDefinedColumn_Operate.aspx?guid='"+Eval("Guid")+"'" %>" style="color: #4482b4;">
                                编辑</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("Guid") %>' OnClientClick="return window.confirm('您确定要删除吗?');">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldAgentID" runat="server" />
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_UserDefinedColumn_Action" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="SubstationID" DefaultValue="all" Type="String" />
            <%--<asp:ControlParameter ControlID="DropDownListSubstationID" Name="SubstationID"
                    PropertyName="SelectedValue" Type="String" />--%>
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
