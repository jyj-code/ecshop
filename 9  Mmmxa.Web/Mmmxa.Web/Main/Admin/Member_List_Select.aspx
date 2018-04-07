<%@ page language="C#" autoeventwireup="true" inherits="Main_Admin_Member_List_Select"   CodeBehind="Member_List_Select.aspx.cs"      %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员选择</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <base target="_self" />
    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>

    <script type="text/javascript">
       function ReturnValue() 
        { 
        var checkMemValus="";
        $("input:checked").each(function(){
        
        if(checkMemValus=="")
        {
        checkMemValus=$(this).val();
        }
        else
        {
        checkMemValus+="\r\n"+$(this).val();
        }
        
        });
        
           if (window.opener != undefined) {
                window.opener.returnValue = checkMemValus;
           }
           else {
                window.returnValue = checkMemValus;
           }       
           window.close(); 
        } 
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <table>
                <tr style="height: 35px; vertical-align: middle;">
                    <td class="lmf_padding" style="width: 100px;">
                        <label style="text-align: left">
                            会员名称 :
                        </label>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="txtMemName" runat="server" CssClass="tinput"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="ButtonSearch" runat="server" Text="查询" CausesValidation="False" CssClass="dele"
                            OnClick="ButtonSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <div style="padding:0 10px;">
            <div>
                <asp:DataList ID="DataListShow" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"
                    Width="100%">
                    <ItemTemplate>
                        <input id="checkboxItem" value='<%# Eval("MemLoginID") %>' type="checkbox" />
                        <label><%# Eval("MemLoginID") %></label>                        
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="clearfix" style="margin:10px 0;">
                <!-- 分页部分-->
                <div class="btconfig" style="text-align: right; background: #e8e8e8; float: right;">
                    &nbsp;<span>转到
                        <asp:Literal ID="lnkTo" runat="server" />
                        <asp:DropDownList ID="DropDownListNumSelect" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListNumSelect_SelectedIndexChanged">
                        </asp:DropDownList>
                        页</span>
                </div>
                <div id="pageDiv" runat="server" class="fpage">
                </div>
            </div>
            <div style=" text-align:center;">
                <input type="button" value="确定" class="fanh" onclick='ReturnValue();' />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
