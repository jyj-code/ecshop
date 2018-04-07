<%@ page language="C#" autoeventwireup="true" inherits="Admin_ShopIncomeReport"   CodeBehind="ShopIncomeReport.aspx.cs"      %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="GroupFly" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺总收入报表</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    店铺总收入报表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div style="height: 35px; vertical-align: top;">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                           <td>
                                店主：
                            </td>
                            <td>
                                <asp:TextBox ID="txtshophost" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                            </td>
                             <td class="lmf_padding">
                                店铺名称：
                            </td>
                            <td>
                                <asp:TextBox ID="txtshopname" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                            </td>                            
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="搜索" CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonReport" runat="server" OnClick="ButtonReport_Click" CausesValidation="False"
                                    class="daochubtn lmf_btn"><span>导出到Excel</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonHtml" runat="server" CausesValidation="False" OnClick="ButtonHtml_Click"
                                    OnClientClick="javascript:document.getElementById('form1').target='_blank';window.location.href=window.location.href;"
                                    class="daochubtn lmf_btn"><span>导出到Html</span></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="MemLoginID" HeaderText="店主" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ShopName" HeaderText="店铺名称" SortExpression="ShopName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="moneycount" HeaderText="店铺收入" SortExpression="moneycount">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>                    
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchShopIncome"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Report_Action" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
              <asp:ControlParameter ControlID="txtshophost" Name="memloginid"
                    PropertyName="Text" Type="String" />
              <asp:ControlParameter ControlID="txtshopname" Name="shopname"
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
