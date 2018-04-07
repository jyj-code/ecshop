<%@ page language="C#" autoeventwireup="true" inherits="Admin_SubstationManage_List"   CodeBehind="SubstationManage_List.aspx.cs"      %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分站管理</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <script type='text/javascript' src='js/resolution-test.js'></script>

</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div style="left: -1000px; top: 377px; position: absolute; visibility: hidden;" id="dhtmltooltip">
        <img src="" height="200" width="200px">
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    分站列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="display:none">
                            选择地区：
                        </td>
                        <td style="display:none">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListProductGuid1" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownListProductGuid1_SelectedIndexChanged" CssClass="tselect"
                                        Width="100">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid2" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownListProductGuid2_SelectedIndexChanged" CssClass="tselect"
                                        Width="100">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid3" runat="server" CssClass="tselect"
                                        Width="100">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="LabelSubstationID" runat="server" Text="分站ID：" Font-Bold="False" ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSubstationID" runat="server" CssClass="tinput" Width="200" ></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick="GetCheckedBoxValues()"
                                    CssClass="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" OnClientClick="return EditButton()"
                                    CssClass="fanh" Visible="false"><span>编辑</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClientClick="return  DeleteSingeButton()"
                                    OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn"><span>单个删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="LinkButtonManageUser" runat="server" OnClick="LinkButtonManageUser_Click"
                                    OnClientClick="document.getElementById('form1').target='';return EditButton()" class="guanli lmf_btn"><span>管理分站用户</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                            <td>
                            <span>注意：如无必要，请谨慎删除分站数据。</span>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridviewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" 
                AllowMultiColumnSorting="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
                BorderWidth="0" CellPadding="4" GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' align="middle" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" SortExpression="Guid" />
                    <asp:BoundField DataField="SubstationID" HeaderText="分站ID" SortExpression="SubstationID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="分站名称" SortExpression="Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="分站城市">
                        <ItemTemplate>
                            <%#GetCityName(Eval("CityCode").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="DomainName" HeaderText="分站域名" SortExpression="DomainName" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="分站网址">
                        <ItemTemplate>
                        <a target="_blank"  href='<%#ShopUrlOperate.GetFenUrlByDomainName(Eval("DomainName").ToString()) %>'>
                            <%#ShopUrlOperate.GetFenUrlByDomainName(Eval("DomainName").ToString()) %>
                        </a>
                            
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="CreateTime" HeaderText="开通时间" SortExpression="CreateTime" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="开启状态">
                        <ItemTemplate>
                            <asp:Image ID="Image5" runat="server" ImageUrl='<%# GetListImageStatus1(Eval("IsDisabled").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否热门">
                        <ItemTemplate>
                            <asp:Image ID="Image5" runat="server" ImageUrl='<%# GetListImageStatus(Eval("IsHot").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "SubstationManage_Operate.aspx?guid="+"'"+Eval("Guid")+"'" %>" style="color: #4482b4;">
                                编辑</a>
                            <a href="<%# "SubstationManage_Install.aspx?SubstationID="+""+Eval("SubstationID")+"" %>" style="color: #4482b4;">
                                设置</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" Visible="false" CommandArgument='<%# Eval("Guid")%>'
                                OnClientClick="return window.confirm('您确定要删除吗?');" OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_SubstationManage_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxSubstationID" Name="SubstationID" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="HiddenFieldCode" Name="CityCode" PropertyName="Value"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server"  />
    </form>
    <script type="text/javascript" src="js/showimg.js"></script>

</body>
</html>
