<%@ page language="C#" autoeventwireup="true" inherits="Main_Admin_PaymentRecords"   CodeBehind="PaymentRecords.aspx.cs"      %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    
    <script type="text/javascript" src="js/CommonJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="right">
            <div class="rhigth">
                <div class="rl">
                </div>
                <div class="rcon">
                    <h3>第三方支付记录
                    </h3> 
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="sbtn">
                <table cellpadding="0" cellspacing="2" border="0">
                    <tr>
                        <td valign="top"><asp:LinkButton ID="ButtonReportAll" OnClick="ButtonReportAll_Click" runat="server"  OnClientClick="return ImportData(true);"  CausesValidation="False" CssClass="daochubtn lmf_btn"><span>导出到Excel</span></asp:LinkButton></td>
                        <td valign="top" class="lmf_app"><asp:LinkButton ID="ButtonReportAllHtml" OnClick="ButtonReportAllHtml_Click" runat="server"  OnClientClick="return ImportData(true);"  CausesValidation="False" CssClass="daochubtn lmf_btn"><span>导出到Html</span></asp:LinkButton></td>
                    </tr>
                </table>
            </div>
            <div class="welcon clearfix">
                <div class="order_edit">
                    <table class="gridview_m" cellspacing="0" cellpadding="4" rules="cols" ascendingimageurl="~/images/SortAsc.gif" descendingimageurl="~/images/SortDesc.gif" border="1" id="Num1GridiewShow" style="background-color: White; border-color: #DEDFDE; border-width: 1px; border-style: None; width: 98%; border-collapse: collapse;">
                       <thead> <tr class="list_header" align="center" style="color: White;">

                            <th scope="col"><a href="javascript:__doPostBack('Num1GridiewShow','Sort$ReceiveID')" style="color: White;">订单编号</a></th>
                            <th scope="col"><a href="javascript:__doPostBack('Num1GridiewShow','Sort$Type')" style="color: White;">支付方式</a></th>
                            <th scope="col"><a href="javascript:__doPostBack('Num1GridiewShow','Sort$CreateTime')" style="color: White;">支付类型</a></th>
                            <th scope="col"><a href="javascript:__doPostBack('Num1GridiewShow','Sort$Type')" style="color: White;">支付金额</a></th>
                            <th scope="col"><a href="javascript:__doPostBack('Num1GridiewShow','Sort$Type')" style="color: White;">支付完成时间</a></th>

                        </tr>
                        </thead>
                        <tbody>
                        <asp:Repeater ID="repeaList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center"><%#Eval("OrderNumber") %></td>
                                    <td align="center"><%#Eval("PayTypeName") %>
                                    </td>
                                    <td align="center"><%#Eval("PayTypeCode") %></td>
                                    <td align="center"><%#"￥"+Eval("PayMoney") %>
                                    </td>
                                    <td align="center"><%#Eval("HasPayTime") %>
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="5">  <div id="mydivpage" runat="server" class="fpage"></div></td>
                        </tr>
                        </tbody>
                    </table>
                   
            </div>
<script type="text/javascript" language="javascript">
		                function NumTxt_Int(o)
                        {
                           o.value=o.value.replace(/\D/g,'');
                        }
		                // 判断是否是数字
                        function checknum(str)
                        {
                            var re = /^[0-9]+.?[0-9]*$/; 
                            if (!re.test(str))
                            {
                                alert("请输入正确的数字！");
                                return false;
                            }else{return true;}
                        }
		                        $(function(){
		                               var pagesize='<%=ShopNum1.Common.Common.ReqStr("pagesize") %>';
		                                $("#page"+pagesize).addClass("cur");
		                                $(".fpage").find(".quedbtn").click(function(){
		                                      var pageindex=$("input[name='vjpage']").val();
		                                      if(checknum(pageindex))
		                                      {
		                                          location.href='?&pagesize='+pagesize+'&pageid='+pageindex;
		                                      }
		                                });
		                        });
		                </script>
            <input type="hidden" name="CheckGuid" id="CheckGuid" value="0" />
        </div>
     </div>
    </form>
</body>
</html>
