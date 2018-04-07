﻿<%@ page language="C#" autoeventwireup="true" inherits="Main_Admin_RegionSalesOrderOperate"   CodeBehind="RegionSalesOrderOperate.aspx.cs"      %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="GroupFly" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商品销售明细报表</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="销售明细报表"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            订单号：
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrderNumber" CssClass="tinput" Width="150" runat="server"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            省份:
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListRegion" runat="server"  OnSelectedIndexChanged="DropDownListRegionSelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
                        </td>
                        <td class="lmf_padding">
                          订单金额:
                        </td>
                          <td colspan="3">
                            <asp:TextBox ID="TextBoxSPayPrice" runat="server" CssClass="tinput_data"></asp:TextBox>
                            -
                            <asp:TextBox ID="TextBoxEPayPrice" runat="server" CssClass="tinput_data"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            店铺名称：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopName" CssClass="tinput" Width="150" runat="server"></asp:TextBox>
                        </td>
                         <td class="lmf_padding">
                            商品名称：
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductName" CssClass="tinput" Width="150" runat="server"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            交易日期：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxStartDate" runat="server" CssClass="tinput_data"></asp:TextBox>
                            <img id="imgCalendarSReplyTime1" alt="UserName" src="/ImgUpload/Calendar.png" style="width: 16px;
                                height: 18px; position: relative; top: 3px" /><asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate"
                                    runat="server" ControlToValidate="TextBoxStartDate" Display="Dynamic" ErrorMessage="时间格式不正确"
                                    ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <GroupFly:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxStartDate"
                                PopupButtonID="imgCalendarSReplyTime1" CssClass="ajax__calendar" />
                            -
                            <asp:TextBox ID="TextBoxEndDate" runat="server" CssClass="tinput_data"></asp:TextBox>
                            <img id="imgCalendarSReplyTime2" alt="UserName" src="/ImgUpload/Calendar.png" style="width: 16px;
                                height: 18px; position: relative; top: 3px" /><asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate0"
                                    runat="server" ControlToValidate="TextBoxEndDate" Display="Dynamic" ErrorMessage="时间格式不正确"
                                    ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <GroupFly:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxEndDate"
                                PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                        </td>
                          <td class="lmf_padding">
                            商品类型：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryName" runat="server"  OnSelectedIndexChanged="DropDownListProductCategoryIndexChanged" >
                            </asp:DropDownList>
                            <asp:HiddenField ID="HiddenFieldCategoryCode" runat="server" Value="-1" />
                        </td>
                    </tr>
                    <tr>                        
                        <td colspan="8" align="right">
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonSearch" runat="server" Text="搜索" CssClass="dele"
                                OnClick="ButtonSearch_Click" />
                        </td>
                    </tr>
                </table>
                <div>
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
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                BorderWidth="0px" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                       <asp:TemplateField HeaderText="省份" SortExpression="AddressValue">
                        <ItemTemplate>
                         <asp:Label ID="LblAddressValue" runat="server" Text='<%#rstring(Eval("AddressValue"),1)%>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="OrderNumber" HeaderText="订单号" SortExpression="OrderNumber">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ShopName" HeaderText="店铺名称" SortExpression="ShopName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="商品名称" SortExpression="ProductName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="商品类型" SortExpression="ProductCategoryName">
                        <ItemTemplate>
                         <asp:Label ID="LabelPCategoryName" runat="server" Text='<%#rstring(Eval("ProductCategoryName"),2)%>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="数量" DataField="BuyNumber" SortExpression="BuyNumber">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="订单金额" DataField="BuyPrice" SortExpression="BuyPrice">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="订单日期" DataField="CreateTime" SortExpression="CreateTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchRegionSalesDetail"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopInfoList_Action" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtOrderNumber" Name="ordernumber" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="txtProductName" Name="productName" PropertyName="Text"
                    Type="String" DefaultValue="-1"  />
                <asp:ControlParameter ControlID="TextBoxShopName" DefaultValue="-1" Name="shopname"
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxStartDate" DefaultValue="-1" Name="startdate"
                    PropertyName="Text" Type="String" />
                  <asp:ControlParameter ControlID="TextBoxEndDate" DefaultValue="-1" Name="enddate"
                    PropertyName="Text" Type="String" />
                 <asp:ControlParameter ControlID="HiddenFieldRegionCode" DefaultValue="-1" Name="regioncecode"
                    PropertyName="Value" Type="String" />
                 <asp:ControlParameter ControlID="TextBoxSPayPrice" DefaultValue="-1" Name="sPayPrice"
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxEPayPrice" DefaultValue="-1" Name="ePayPrice"
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="HiddenFieldCategoryCode" DefaultValue="-1" Name="ProductCategoryCode"
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
