<%@ page language="C#" autoeventwireup="true" inherits="Admin_ApplyAdvertisement_List"   CodeBehind="ApplyAdvertisement_List.aspx.cs"      %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%=HeaderInfo("广告列表")%>
    <link rel="stylesheet" type="text/css" href="style/css.css" />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="left: -1000px; top: 377px; position: absolute; visibility: hidden;" id="dhtmltooltip">
        <img src="" height="200" width="200px">
    </div>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    会员申请广告列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <asp:ObjectDataSource ID="ObjectDataSourceXml" runat="server" SelectMethod="Search1"
                    TypeName="ShopNum1.BusinessLogic.ShopNum1_AdvertPay_Action">
                    <SelectParameters>
                    <asp:ControlParameter ControlID="TextBoxPageName" Name="MemLoginID" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="DropDownListFileName" Name="AdId"
                        PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="DropDownListIsExamine" Name="IsExamine"
                        PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="HiddenFieldCode" Name="CityCode"
                        PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="DropDownListSubstationID" Name="SubstationID"
                        PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                    </asp:ObjectDataSource>
                    <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            会员名：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                            
                        </td>
                        <td style="display:none">
                            分站：
                        </td>
                        <td style="display:none">
                            <asp:DropDownList ID="DropDownListSubstationID" runat="server"  
                                AutoPostBack="true" Width="200px" CssClass="tselect" 
                                onselectedindexchanged="DropDownListSubstationID_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            广告位：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListFileName" runat="server" Width="200px" CssClass="tselect">
                            <asp:ListItem Text="-请选择-" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            审核状态：
                        </td>
                        <td>
                             <asp:DropDownList ID="DropDownListIsExamine" runat="server" Width="200px" CssClass="tselect">
                             <asp:ListItem Text="-请选择-" Value="-1"></asp:ListItem>
                             <asp:ListItem Text="已审核" Value="1"></asp:ListItem>
                             <asp:ListItem Text="未审核" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        <asp:Button ID="ButtonGet" runat="server" Text="查询" CssClass="dele" 
                                onclick="ButtonGet_Click" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                      
                        <td valign="top" >
                            <asp:LinkButton ID="ButtonIsExamine" runat="server"  CausesValidation="False"
                                class="tianjia2 lmf_btn" onclick="ButtonIsExamine_Click" OnClientClick="return EditButton()"><span>审核</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                           <asp:LinkButton ID="LinkButtonIsCancel" runat="server"  CausesValidation="False" 
                                class="shanchu lmf_btn" onclick="LinkButtonIsCancel_Click" OnClientClick="return EditButton()"><span>撤销</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                           <asp:LinkButton ID="LinkButtonRun" runat="server"  CausesValidation="False" 
                                class="tianjia2 lmf_btn"  OnClientClick="return EditButton()" 
                                onclick="LinkButtonRun_Click" ><span>启用</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                             <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick="return DeleteButton()"
                                CausesValidation="False" class="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                        </td>
                    </tr>
                </table>
                </div>
            </div>
                
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceXml" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
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
                    <asp:BoundField DataField="MemLoginID" HeaderText="会员" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="广告位">
                        <ItemTemplate>
                            <%#ShopNum1.ShopAdminWebControl.S_TerracePayList.GetAdId(Eval("AdId").ToString(), Eval("SubstationID").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="广告图片">
                        <ItemTemplate>
                            <img src='<%# Page.ResolveUrl(Eval("Image").ToString().Split('|')[0].ToString())%>' onmouseover="javascript:ddrivetip('<img width=200px height=200 src=<%#Page.ResolveUrl(Eval("Image").ToString().Split('|')[0].ToString())%> >','#ffffff')"
                                onmouseout="hideddrivetip()" height="40" width="40" />
                                
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="审核" SortExpression="IsExamine">
                        <ItemTemplate>
                                  <asp:Image ID="ImageIsExamine" runat="server" src='<%# PageOperator.GetListImageStatus(Eval("IsExamine").ToString()=="1"?"0":"1") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="撤销">
                        <ItemTemplate>
                            <asp:Image ID="ImageIsCancel" runat="server" src='<%# PageOperator.GetListImageStatus(Eval("IsCancel").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="CreateTime" HeaderText="申请日期" ItemStyle-HorizontalAlign="Center"/>
                    <asp:TemplateField HeaderText="审核日期">
                        <ItemTemplate>
                            <%#CheckTime(Eval("IsExamine").ToString(), Eval("ModifyTime").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="开始日期">
                        <ItemTemplate>
                            <%#ShopNum1.ShopAdminWebControl.S_TerracePayList.BeginDate(Eval("BeginDate").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="结束日期">
                        <ItemTemplate>
                            <%# ShopNum1.ShopAdminWebControl.S_TerracePayList.EndDate(Eval("EndDate").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "ApplyAdvertisement_Operate.aspx?guid='"+Eval("Guid") %>'" style="color: #4482b4;">
                                审核</a>
                             
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldCode" runat="server" />
        <asp:HiddenField ID="HiddenFieldSubstationID" runat="server" />
    </div>
    </form>

    <script type="text/javascript" src="js/showimg.js"></script>

</body>
</html>
