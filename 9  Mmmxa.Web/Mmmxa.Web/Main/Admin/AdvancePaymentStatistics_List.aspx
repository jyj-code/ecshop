
<%@ page language="C#" autoeventwireup="true" inherits="Admin_AdvancePaymentStatistics_List"   CodeBehind="AdvancePaymentStatistics_List.aspx.cs"      %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员预存款统计</title>
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
                    会员预存款统计</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height:35px; vertical-align:top;">
                        <td>
                            <asp:Label ID="LabelSMemLoginID" runat="server" Text="会员ID："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSMemLoginID" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="ButtonSearch" runat="server" Text="查询" OnClick="ButtonSearch_Click"
                                CssClass="dele" /></td>
                    </tr>
                </table>
            </div>
            <div style=" width:100%;">
                &nbsp;&nbsp;&nbsp;&nbsp;当前会员预存款累计金额【￥<asp:Label ID="LabelMoney" runat="server" Text="" ForeColor="Red"></asp:Label>】,
                会员冻结预存款累计金额【￥<asp:Label ID="LabelLockAdvancePayment" runat="server" Text="" ForeColor="Red"></asp:Label>】
            </div>
            <div style=" margin-left:20px; margin-bottom:10px;">
                <asp:LinkButton ID="ButtonReport" runat="server" OnClick="ButtonReport_Click"  
                        CausesValidation="False" CssClass="daochubtn lmf_btn"><span>导出全部数据</span></asp:LinkButton>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0"
                CellPadding="4" GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="MemLoginID" HeaderText="会员ID" SortExpression="MemLoginID" ItemStyle-Width="160">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="姓名" ItemStyle-Width="160">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField SortExpression="AdvancePayment" HeaderText="当前预存款">
                        <ItemTemplate>
                            ￥<%#Eval("AdvancePayment")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="LockAdvancePayment" HeaderText="冻结预存款">
                        <ItemTemplate>
                            ￥<%#Eval("LockAdvancePayment")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchAdvancePayment"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Member_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxSMemLoginID" Name="MemLoginID" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
