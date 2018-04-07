<%@ Control Language="C#"  %>
<script src="Js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
     var num=60;
     var timeInterv=window.setInterval(function onTime1(){
      var spanTimeValue=document.getElementById("spanTime").innerHTML;
         if(parseInt(spanTimeValue)<=0)
         {
           window.clearInterval(timeInterv);
           window.location.href='<%=ShopUrlOperate.GetSiteDomain() %>';
         }
         else
         {
         document.getElementById("spanTime").innerHTML=parseInt(spanTimeValue)-1;
         }
         
      },1000)
  </script>
<div class="ShopError clearfix">
         <!--店铺关闭-->
        <div class="ignore">
            <dl>
                <dt class="knight"><img src="Themes/Skin_Default/Images/mofines.jpg" /></dt>
                <dd class="warrior snipe">
                    <h4>对不起，您访问的城市分站可能已被删除或者关闭......</h4>
                   现在，您可以进行如下操作：
                    <p class="courtday">
                        1.<span id="spanTime" class="redtwo">60</span> 秒后跳转到 <a href="" id="aMainUrl" runat="server">
                            <asp:Label ID="LabelMainCity" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="HiddenFieldCityUrl" runat="server" />                        </a><br />                        2.<a href="javascript:void(0)" onclick="window.history.go(-1)">后退</a> 检查刚才的输入</p>
                    <p>
                    </p>
                </dd>
            </dl>
        </div>
    </div>