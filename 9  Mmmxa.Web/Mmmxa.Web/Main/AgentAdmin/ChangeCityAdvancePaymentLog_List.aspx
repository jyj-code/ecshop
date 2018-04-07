<%@ page language="C#" autoeventwireup="true" inherits="AgentAdmin_ChangeCityAdvancePaymentLog_List, ShopNum1.Deploy" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>分站变更预存款</title>
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
                    我的预存款变更日志</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit" style="margin-bottom: 1px;">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td class="lmf_padding">编号：</td>
                            <td>
                                <asp:TextBox ID="TextBoxOrderNumber" runat="server" CssClass="tinput" Width="201"  ></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSOperateType" runat="server" Text="变更类型："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListOperateType" runat="server" Width="201px" CssClass="tselect">
                                    <asp:ListItem Value="-1" Selected="True">-全部-</asp:ListItem>
                                    <asp:ListItem Value="0">收益</asp:ListItem>
                                    <asp:ListItem Value="1">支出</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSDate" runat="server" Text="变更日期："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSDate1" runat="server" CssClass="tinput" Width="76"></asp:TextBox>
                            </td>
                            <td style="padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarCreateTime1" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                    height: 18px; top: 3px; position: relative;" />
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxSDate1" runat="server"
                                    ControlToValidate="TextBoxSDate1" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                    EnableScriptLocalization="True">
                                </ShopNum1:ToolkitScriptManager>
                            </td>
                            <td>
                                <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSDate1"
                                    PopupButtonID="imgCalendarCreateTime1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender>
                            </td>
                            <td class="lmf_px">
                                -
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSDate2" runat="server" CssClass="tinput" Width="76"></asp:TextBox>
                            </td>
                            <td style="padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarCreateTime2" alt="" src="/ImgUpload/Calendar.png" style="width: 16px; height: 18px;
                                    top: 3px; position: relative;">
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxSDate2" runat="server"
                                    ControlToValidate="TextBoxSDate2" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidatorTextBoxSDate2" runat="server" ErrorMessage="开始时间应当大于结束时间"
                                    Type="Date" Display="Dynamic" ControlToValidate="TextBoxSDate2" ControlToCompare="TextBoxSDate1"
                                    Operator="GreaterThan"></asp:CompareValidator>
                            </td>
                            <td>
                                <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxSDate2"
                                    PopupButtonID="imgCalendarCreateTime2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" CausesValidation="False" Text="查询" OnClick="ButtonSearch_Click"
                                    CssClass="dele" />
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
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <HeaderStyle Height="25px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="OrderNumber" HeaderText="编号" SortExpression="OrderNumber">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                    <asp:BoundField DataField="Date" HeaderText="日期" SortExpression="Date">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="类型" SortExpression="OperateType">
                        <ItemTemplate>
                            <%#OperateType(Eval("OperateType").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="CurrentAdvancePayment" HeaderText="当前预存款" SortExpression="CurrentAdvancePayment">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="OperateMoney" HeaderText="变更金额" SortExpression="OperateMoney">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="变更后金额" DataField="LastOperateMoney" SortExpression="LastOperateMoney">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="备注" DataField="Memo" SortExpression="Memo">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_City_AdvancePaymentModifyLog_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownListOperateType" Name="OperateType" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="HiddenFieldSubstationID" DefaultValue="-1"  Name="SubstationID" PropertyName="Value" Type="String" />
            <asp:Parameter DefaultValue="0" Name="IsMainAdmin"  Type="String"/>
            <asp:ControlParameter ControlID="TextBoxOrderNumber" Name="OrderNumber" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSDate1" Name="startDate" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSDate2" Name="endDate" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="HiddenFieldSubstationID" runat="server" />
    </form>
</body>
</html>
