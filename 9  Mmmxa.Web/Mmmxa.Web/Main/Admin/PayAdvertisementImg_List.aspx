<%@ page language="C#" autoeventwireup="true" inherits="Admin_PayAdvertisementImg_List"   CodeBehind="PayAdvertisementImg_List.aspx.cs"      %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Import Namespace="ShopNum1.Common" %>
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
                    付费广告位列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <asp:ObjectDataSource ID="ObjectDataSourceXml" runat="server" SelectMethod="GetXmlDataTable"
                    TypeName="ShopNum1.AdXml.DefaultAdvertPayOperate">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownListSubstationID" Name="SubstationID" PropertyName="SelectedValue"
                        Type="String" />
                    </SelectParameters>
                    </asp:ObjectDataSource>
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="display:none">
                        <td  height="36">城市分站：</td>
                        <td colspan="3">
                            <asp:DropDownList ID="DropDownListSubstationID" runat="server" 
                                AutoPostBack="true" Width="200px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                      
                        <td valign="top" >
                            <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                class="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                            <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="编辑" Visible="false"
                                OnClientClick="return EditButton()" OnClick="ButtonEdit_Click" CssClass="fanh" />
                             
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:LinkButton ID="LinkButtonRun" runat="server"  CausesValidation="False"
                                class="tianjia2 lmf_btn" OnClientClick="return EditButton()" 
                                onclick="LinkButtonRun_Click" ><span>启用</span></asp:LinkButton>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:LinkButton ID="LinkButtonRunNo" runat="server"  CausesValidation="False"
                                class="shanchu lmf_btn" OnClientClick="return EditButton()" onclick="LinkButtonRunNo_Click" 
                                  ><span style="text-align:left">禁用</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick="return DeleteButton()"
                                CausesValidation="False" class="shanchu lmf_btn" Visible="false"><span>批量删除</span></asp:LinkButton>
                        </td>
                    </tr>
                </table>
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
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("id") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="id" HeaderText="广告位ID" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="title" HeaderText="位置说明" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="width" HeaderText="宽度(px)" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="height" HeaderText="高度(px)" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="默认图片">
                        <ItemTemplate>
                            <img src='<%# Eval("DefaultImage").ToString()%>' onmouseover="javascript:ddrivetip('<img width=200px height=200 src=<%# Eval("DefaultImage")%> >','#ffffff')"
                                onmouseout="hideddrivetip()" height="20" width="20" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="money" HeaderText="付费金额(￥)" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="showDay" HeaderText="展示期限(天)" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="启用状态">
                        <ItemTemplate>
                            <asp:Image ID="Image5" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IsRun").ToString()=="1"?"0":"1") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href='PayAdvertisementImg_Operate.aspx?guid=<%#Eval("id")%>&SubstationID=<%=GetSelectSub()%>' style="color: #4482b4;">
                                编辑</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" Visible="false" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("id") %>' OnClientClick="return window.confirm('您确定要删除吗?');">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldSubstationID" runat="server" />
    </div>
    </form>

    <script type="text/javascript" src="js/showimg.js"></script>

</body>
</html>
