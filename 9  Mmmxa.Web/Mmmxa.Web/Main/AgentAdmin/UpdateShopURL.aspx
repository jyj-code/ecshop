<%@ page language="C#" autoeventwireup="true" inherits="AgentAdmin_UpdateShopURL, ShopNum1.Deploy" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>填写店铺URL</title>
      <link rel="stylesheet" type="text/css" href="style/css.css" />

    <script src="/JS/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <script type="text/javascript" language="javascript">
        function funCheckShopUrl()
        {
            var shopurl=$("#TextBoxShopURL").val();
            var hidshopurl=$("#HiddenFieldShopURL").val();
            if(shopurl!=hidshopurl)
            {
                //求唯一店铺名称！
                $.ajax({
                 type: "get",
                 url: "/Api/Main/AdminApi.ashx",
                 async: true,
                 data: "type=checkshopurl&keyword="+shopurl,
                 dataType: "html",
                 success: function (ajaxData) {
                    if(ajaxData!="")
                    {
                        if(ajaxData=="chinese")
                        {
                            $("#Labelerr").html("不能用汉字表示域名");
                            return false;
                        }
                        else if(ajaxData=="no")
                        {
                            $("#Labelerr").html("域名已经被申请，请换一个域名！");
                            $("#ButtonUpdata").attr("disabled","disabled")
                            return false;
                        }
                        else
                        {
                            $("#Labelerr").html("");
                            $("#ButtonUpdata").removeAttr("disabled")
                            return true;
                        }
                    }
                 }
                });
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
          
         <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="填写店铺URL"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right" width="150px">
                        <div class="shopth">
                           店铺URL：
                        </div>
                    </th>
                    <td valign="middle">
                        <div class="shoptd">
                           <asp:TextBox ID="TextBoxShopURL" MaxLength="20" ValidationGroup="shopurl"  CssClass="tinput"
                            runat="server" ontextchanged="TextBoxShopURL_TextChanged" onblur="funCheckShopUrl()"></asp:TextBox>
                        <asp:Literal ID="LiteralURL" runat="server"></asp:Literal>
                        <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red" /><asp:Label ID="Labelerr"
                            runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxShopURL"
                            Display="Dynamic" ValidationGroup="shopurl" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                            ControlToValidate="TextBoxShopURL" Display="Dynamic" 
                            ErrorMessage="只能为字母或者数字" ValidationGroup="shopurl" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>




                        </div>
                    </td>
                </tr>
                
               
              
            </table>
            <div class="tablebtn" onmouseover="funCheckShopUrl()">
                 <asp:Button ID="ButtonUpdata" runat="server" ValidationGroup="shopurl" Text="确定" CssClass="fanh"
                            onclick="ButtonUpdata_Click" UseSubmitBehavior="false" OnClientClick="this.disabled=true;"/><%-- --%>
                            <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh"
                            onclick="ButtonBack_Click" />
                            <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />

             
            </div>
        </div>
    </div>





            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFieldShopURL" runat="server" Value="0" />
    </form>
</body>
</html>
