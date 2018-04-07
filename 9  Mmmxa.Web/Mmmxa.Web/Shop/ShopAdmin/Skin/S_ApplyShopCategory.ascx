<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script language="javascript" type="text/javascript">
    function SelectAllCheckboxes(obj) {
        var theTable = obj.parentNode.parentNode.parentNode;
        var inputs = theTable.getElementsByTagName('input');
        for(var i = 0;i<inputs.length;i++) {
            if(inputs[i].type == "checkbox") {
                inputs[i].checked = obj.checked;
            }
        }
    }

    function GetCheckedBoxValues() {
        var checkedBoxValues = "";
        var inputs = document.getElementsByTagName("input");
        for(var j = 0 ; j < inputs.length ; j++) {
            if(inputs[j].type == "checkbox" && inputs[j].id != "checkboxAll") {
                if(inputs[j].checked == true) {
                    checkedBoxValues += "'"+inputs[j].value+"',";             
                }
            }
        }
        if(checkedBoxValues.length > 0) {
            checkedBoxValues = checkedBoxValues.substring(0,checkedBoxValues.length -1);
        }
        
        return checkedBoxValues;
    }

    function DeleteBt() {
        var checkedBoxValues = GetCheckedBoxValues();
        if(checkedBoxValues == "") {
            alert("请选择要删除的记录！");
            return false;
        }
        else if(window.confirm("您确定要删除吗?")) {
            document.getElementById('<%= CheckGuid.ClientID %>').value = checkedBoxValues;
            return true;
        }
        else {
            return false;
        }
    }
    
    function EditBt() {
        var checkedBoxValues = GetCheckedBoxValues();
        if(checkedBoxValues == "") {
            alert("请选择要操作的记录！");
            return false;
        }
        else if(checkedBoxValues.split(",").length > 1) {
            alert("您每次只能选择一条记录操作！");
            return false;
        }
        else {
            document.getElementById('<%= CheckGuid.ClientID %>').value = checkedBoxValues;
            return true;
        }
    }
</script>
<div id="list_main">
    <div class="content">
        <div class="content" style="width: 100%;">
            <table cellpadding="0" width="100%" cellspacing="0" style="display:none;">
                <tr>
                    <td style="text-align: right; width: 120px; display:none">
                        审核时间：
                    </td>
                    <td style="text-align: left; width: 380px; display:none">
                        <asp:TextBox ID="textBoxtime1" runat="server" CssClass="input1"></asp:TextBox>
                        -
                        <asp:TextBox ID="textBoxtime2" runat="server" CssClass="input1"></asp:TextBox>
                    </td>
                    <td style="text-align: right; width: 115px;">
                        审核状态：
                    </td>
                    <td style="text-align:left">
                        <asp:DropDownList ID="dropDownListstate" Width="150px" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align:center">
                        <asp:Button ID="ButtonSearch" CssClass="chax btn_spc" runat="server" CausesValidation="false"
                            Text="搜索" />
                    </td>
                </tr>
            </table>
            <div class="btntable_tbg">
                <div class="shanc"><asp:LinkButton ID="ButtonDel" runat="server" Text="批量删除" CssClass="shanchu lmf_btn" OnClientClick="return DeleteBt()" />
                </div>
                <div class="shanc">
                    <a class="xiugai lmf_btn" href="S_ShopCategoryOperate.aspx">修改分类</a>
                </div>
            </div>
            <table cellpadding="0" cellspacing="0" width="100%" class="gridview_m blue_tbw1">
                <tr class="MemberTr">
                    <th width="30" style="text-align: center" class="th_le">
                        <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                    </th>
                    <th style="text-align: center">
                        店铺原始分类
                    </th>
                    <th style="text-align: center">
                        申请店铺分类
                    </th>
                    <th style="text-align: center">
                        是否审核
                    </th>
                    <th style="text-align: center">
                        备注
                    </th>
                </tr>
                <asp:Repeater EnableViewState="False" ID="RepeaterData" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center">
                                <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                            </td>
                            <td style="text-align: center">
                                <%# DataBinder.Eval(Container.DataItem, "OldShopCategoryName")%>
                            </td>
                            <td style="text-align: center">
                                <%# DataBinder.Eval(Container.DataItem, "ShopCategoryName")%>
                            </td>
                            <td style="text-align: center">
                                <%#S_ApplyShopCategory.IsAudit(Eval("IsAudit").ToString())%>
                            </td>
                            <td style="text-align:left">
                                <%# DataBinder.Eval(Container.DataItem, "Remarks")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" />
</div>