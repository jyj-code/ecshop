<%@ Control Language="C#" AutoEventWireup="true" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<script src="/JS/jquery.1.7.1.js" type="text/javascript"></script>
<script src="../../../JS/CommonJS.js"></script>
<script type="text/javascript">
    function edititem() {
        checkCount = 0;
        var checkedBoxValues = GetCheckedBoxValues();
        if (checkedBoxValues == "0") {
            alert("请选择要操作的记录！");
            return false;
        } else if (checkCount > 1) {
            alert("您每次只能选择一条记录操作！");
            return false;
        } else {
            $("#S_ShipperList_ctl00_CheckGuid").val(checkedBoxValues.replace('0,', ''));
            return true;
        }
    }
    function deleteitem() {
        var checkedBoxValues = GetCheckedBoxValues();
        if (checkedBoxValues == "0") {
            alert("请选择要删除的记录！");
            return false;
        } else if (window.confirm("您确定要删除吗?")) {
            $("#S_ShipperList_ctl00_CheckGuid").val(checkedBoxValues.replace('0,', ''));
            return true;
        } else {
            return false;
        }
    }

</script>
<div class="dpsc_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">发货信息列表</span>
    </p>
    <div class="content">
        <div class="order_edit" style="margin-top: 10px;">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td valign="top">
                        <asp:LinkButton ID="ButtonAdd" runat="server" CssClass="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                    </td>
                    <td valign="top" class="lmf_app">
                        <asp:LinkButton ID="ButtonEdit" runat="server" OnClientClick="return edititem();" CssClass="bji lmf_btn"><span>编辑</span></asp:LinkButton>
                    </td>
                    <td valign="top" class="lmf_app">
                        <asp:LinkButton ID="ButtonDelete" runat="server" OnClientClick="return deleteitem()" CssClass="shanchu lmf_btn">批量删除</asp:LinkButton>
                    </td>
                    <td valign="top" class="lmf_app"></td>
                </tr>
            </table>
        </div>
        <div class="order_list">

            <table class="gridview_m" cellspacing="0" cellpadding="4" rules="cols" ascendingimageurl="~/images/SortAsc.gif" descendingimageurl="~/images/SortDesc.gif" border="0" id="Table1" style="background-color: White; border-color: #DEDFDE; border-width: 0px; border-style: None; width: 100%; border-collapse: collapse;">
                <tr class="th_le" align="center">
                    <th class="select_width" scope="col">
                        <input id="checkboxAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox" />
                    </th>
                    <th scope="col">发货点名称 </th>
                    <th scope="col">发货人姓名 </th>
                    <th scope="col">邮编 </th>
                    <th scope="col">手机 </th>
                    <th scope="col">电话 </th>
                    <th scope="col">是否默认</th>
                </tr>
                <asp:Repeater ID="rlist" runat="server">
                    <ItemTemplate>
                        <tr class="th_le" align="center">
                            <th class="select_width" scope="col">
                                <input id="checkboxItem" value='<%#Eval("Guid") %>' type="checkbox" />
                            </th>
                            <th scope="col"><%#Eval("ShipperName") %></th>
                            <th scope="col"><%#Eval("SendName") %> </th>
                            <th scope="col"><%#Eval("PostalCode") %> </th>
                            <th scope="col"><%#Eval("Mobile") %> </th>
                            <th scope="col"><%#Eval("Phone") %> </th>
                            <th scope="col"><%# Eval("IsDefault").ToString()=="1"?"是":"否"  %></th>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
</div>
