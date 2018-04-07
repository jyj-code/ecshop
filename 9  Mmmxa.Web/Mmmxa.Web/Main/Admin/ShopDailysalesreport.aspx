<%@ page language="C#" autoeventwireup="true" inherits="Admin_ShopDailysalesreport"   CodeBehind="ShopDailysalesreport.aspx.cs"      %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺每日收入报表</title>
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
                    店铺每日收入报表</h3>
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
                                <asp:TextBox ID="TextMemLoginIDValue" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                            </td>
                             <td class="lmf_padding">
                                店铺名称：
                            </td>
                            <td>
                                <asp:TextBox ID="txtshopname" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                            </td>  
                            <td class="lmf_padding">交易日期： </td>
                            <td>
                                <asp:TextBox ID="TextBoxSDate1" runat="server" CssClass="tinput_data" ></asp:TextBox>
                            </td>
                            <td style="padding-left: 4px; vertical-align: top;"><img id="imgCalendarSDate1" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                    height: 18px;top: 3px; position: relative;" /></td>
                            <td><asp:RegularExpressionValidator ID="RegularExpressionValidatorSDate1" runat="server"
                                    ControlToValidate="TextBoxSDate1" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                </td>
                            <td><ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                    EnableScriptLocalization="True">
                                </ShopNum1:ToolkitScriptManager></td>
                            <td><ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSDate1"
                                    PopupButtonID="imgCalendarSDate1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender></td>
                            <td class="lmf_px">-</td>
                            <td><asp:TextBox ID="TextBoxSDate2" runat="server" CssClass="tinput_data" ></asp:TextBox></td>
                            <td style="padding-left: 4px; vertical-align: top;"><img id="imgCalendarSDate2" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                    height: 18px;top: 3px; position: relative;" /></td>
                            <td><asp:RegularExpressionValidator ID="RegularExpressionValidatorSDate2" runat="server"
                                    ControlToValidate="TextBoxSDate2" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                </td>
                            <td><asp:CompareValidator ID="CompareValidatorTextBoxSDate2" runat="server" ErrorMessage="开始时间应当早于结束时间"
                                    Type="Date" Display="Dynamic" ControlToValidate="TextBoxSDate2" ControlToCompare="TextBoxSDate1"
                                    Operator="GreaterThan"></asp:CompareValidator></td>
                            <td><ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxSDate2"
                                    PopupButtonID="imgCalendarSDate2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender></td>                         
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="搜索" CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="2" border="0">
                        <tr>
                            <td valign="top"><asp:LinkButton ID="ButtonReportAll" OnClick="ButtonReportAll_Click" runat="server"  OnClientClick="return ImportData(true);"  CausesValidation="False" CssClass="daochubtn lmf_btn"><span>导出到Excel</span></asp:LinkButton></td>
                            <td valign="top" class="lmf_app"><asp:LinkButton ID="ButtonReportAllHtml" OnClick="ButtonReportAllHtml_Click" runat="server"  OnClientClick="return ImportData(true);"  CausesValidation="False" CssClass="daochubtn lmf_btn"><span>导出到Html</span></asp:LinkButton></td>
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
                    <asp:BoundField DataField="MemLoginID" HeaderText="店主名称" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="date" HeaderText="交易日期" SortExpression="date">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>                     
                    <asp:BoundField DataField="ShopName" HeaderText="店铺名称" SortExpression="ShopName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="moneycount" HeaderText="店铺日收入" SortExpression="moneycount">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>                                       
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchShopDailysales"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Report_Action" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
              <asp:ControlParameter ControlID="TextMemLoginIDValue" Name="memloginid" PropertyName="Text" Type="String" />
              <asp:ControlParameter ControlID="txtshopname" Name="shopname" PropertyName="Text" Type="String" />
              <asp:ControlParameter ControlID="TextBoxSDate1" Name="date1" PropertyName="Text" Type="String" />
              <asp:ControlParameter ControlID="TextBoxSDate2" Name="date2" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
