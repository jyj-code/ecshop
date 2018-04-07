<%@ page language="C#" autoeventwireup="true" inherits="Main_Admin_ReportMonthChart"   CodeBehind="ReportMonthChart.aspx.cs"      %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>访问购买率</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>店铺月收入报表</h3>
            </div>
            <div class="rr">
            <input type="text" id="txtMemloginId" runat="server" visible="false"/>
            </div>
        </div>
        <div class="welcon clearfix">
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
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                  <Columns>
                   <asp:BoundField DataField="月份" HeaderText="月份" SortExpression="月份" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                   <asp:BoundField DataField="订单数量" HeaderText="订单数量" SortExpression="订单数量" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="未付款" HeaderText="未付款" SortExpression="未付款" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="已付款" HeaderText="已付款" SortExpression="已付款" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="已消费" HeaderText="已消费" SortExpression="已消费" ItemStyle-HorizontalAlign="Center"></asp:BoundField>   
                     <asp:BoundField DataField="已关闭" HeaderText="已关闭" SortExpression="已关闭" ItemStyle-HorizontalAlign="Center"></asp:BoundField>   
                     </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SelectMonthChart"    TypeName="ShopNum1.BusinessLogic.ShopNum1_Report_Action">
            <SelectParameters>
               <asp:ControlParameter ControlID="txtMemloginId"  Name="strMemloginId" PropertyName="Value" Type="String" DefaultValue="0" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
