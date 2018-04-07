<%@ page language="C#" autoeventwireup="true" inherits="Main_Admin_SetMemberScoreV82"   CodeBehind="SetMemberScoreV82.aspx.cs"      %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link type="text/css" rel="Stylesheet" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl"></div>
            <div class="rcon">
                <h3><span id="LabelPageTitle">赠送会员积分</span></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
        <div class="inner_page_list">
    <table cellspacing="1" cellpadding="0" border="0">        <tr>
            <th align="right" width="150px">
                买家：
            </th>
            <td align="left" class="guige_text">
                    <asp:Label ID="lblMemloginId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th align="right" width="150px">
                赠送额度：
            </th>
            <td align="left" class="guige_text">
                    <input type="text" id="txtScore" onkeyup="NumTxt_Int(this)" runat="server" class="tinput" maxlength="8" />
            </td>
        </tr>
        <tr>
            <th align="right" width="150px">
                赠送备注：
            </th>
            <td align="left" class="guige_text">
                    <textarea id="txtRemark" runat="server" class="tinput txtarea"></textarea>
                    <br />备注不能超过200个字符且不能小于5个字符                           
            </td>
        </tr>
        </table>
            <div style="margin:10px 125px; margin-top:20px;">
                <asp:Button ID="btnSetScore" runat="server" OnClick="btnSetScore_Click" OnClientClick="return checkSub();" Text="赠送积分" CssClass="fanh"  /> 

                <script type="text/javascript" language="javascript">
                function NumTxt_Int(o)
                {
                   o.value=o.value.replace(/\D/g,'');
                }
         function checkSub()
        {
            var remark=$("#txtRemark").val();
            if(remark.trim().length>200||remark.trim()<10)
            {
               alert("备注不能超过200个字符且不能小于5个字符!");return false;
            }
            return true;
        }
        </script>
            </div>
            </div>
            <input type="hidden" id="hidMemloginId" runat=server />
            <input type="hidden" name="CheckGuid" runat="server" id="CheckGuid" value="b00bf6a3-ddd0-4ff7-ad6d-e7e24cd19073" />
        </div>
        </div>
    </form>
</body>
</html>
