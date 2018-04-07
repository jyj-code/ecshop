<%@ page language="C#" autoeventwireup="true" inherits="Admin_SubstationOrderReport"   CodeBehind="SubstationOrderReport.aspx.cs"      %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="GroupFly" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>城市分站订单销售统计</title>
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
                    城市分站订单销售统计</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
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
                    <asp:BoundField DataField="SubstationID" HeaderText="分站ID" SortExpression="SubstationID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="分站名称">
                        <ItemTemplate>
                            <%#GetSubstationIDname(Eval("SubstationID").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="orderCount" HeaderText="销售订单数量" SortExpression="orderCount">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SellMoney" HeaderText="订单销售金额" SortExpression="SellMoney">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="GetSubstationOrder"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_SubstationReport_Action">
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
