<div id="footer">
    <div class="lmf_all_foot">
        <div class="warp clearfix">
            <ShopNum1:HelpListButtom ID="HelpListButtom" ShowCount="6" runat="server" SkinFilename="HelpListButtom.ascx" />            
        </div>
        <div class="clearfix tc"><img src="Themes/Skin_Default/Images/bottm_10.jpg" /></div>
    </div>
    <div class="copyright">
        <ShopNum1:DomainCopyright ID="DomainCopyright" runat="server" SkinFilename="DomainCopyright.ascx" />
    </div>
</div>

<!--在线客服 start-->
<ShopNum1Shop:OnLineFootService ID="OnLineFootService" runat="server" SkinFilename="OnLineFootService.ascx" ShowCount="5" />
<!--//在线客服 end-->

<!--返回顶部 start-->
<div id="fixed-bottom" onclick="pageScroll()" style="display: none;" onmouseover="ChangeImageIn()" onmouseout="ChangeImageOut()">
    <img id="fixed-bottom_zhiding" src="Themes/Skin_Default/Images/myzhiding.png" />
</div>
<!--//返回顶部 end-->

<!--微信、建议、返回顶部 start-->
<div id="fixed-weixin" class="weixin">
    <div class="ShouJi js-change-img"><img src="Themes/Skin_Default/Images/shouji.png" /></div>
    <div class="MicroInfo js-change-img"><img src="Themes/Skin_Default/Images/MicroInfo.png" /></div>
    <div class="ReturnTop js-change-img" onclick="pageScroll()"><img src="Themes/Skin_Default/Images/ReturnTop.png" /></div>
    <div class="erwei">
        <p><img src='<%=ShopNum1.Common.ShopSettings.GetValue("MicroEWM") %>' /></p>
        <p>扫一扫，加我为微信好友吧!</p>
    </div>
    <div class="ShouJi_erwei">
        <p><img src='<%=ShopNum1.Common.ShopSettings.GetValue("PhoneEWM") %>' /></p>
        <p>扫一扫，快速进入商城!</p>
    </div>
</div>
<!--微信、建议、返回顶部 end-->

<!--[if lte IE 6]>
<style type="text/css">
    *html, *htmlbody
    {
        background-image: url(about:blank);
        background-attachment: fixed;
    }
    /*修正IE6振动bug*/#fixed-weixin /* IE6 底部固定*/
    {
        position: absolute;
        bottom: auto;
        top: expression(eval(document.documentElement.scrollTop+document.documentElement.clientHeight-this.offsetHeight-(parseInt(this.currentStyle.marginTop, 10)||0)-(parseInt(this.currentStyle.marginBottom, 10)||0)));
        right: auto;
        left: expression(eval(document.documentElement.scrollLeft+document.documentElement.clientWidth-this.offsetWidth)-(parseInt(this.currentStyle.marginLeft, 10)||0)-(parseInt(this.currentStyle.marginRight, 10)||0));
    }
</style>
<![endif]-->

<script type="text/javascript">
    window.onscroll = function() {
        var st = document.documentElement.scrollTop + document.body.scrollTop; //滚去的高度
        if (st > 460) {
            //var imgWeight=document.getElementById("fixed-bottom_zhiding").width;
            document.getElementById("fixed-weixin").style.display = "block";            
            document.getElementById("fixed-weixin").style.left= (document.body.clientWidth/2+510)+"px";
        }
        else {
            document.getElementById("fixed-weixin").style.display = "none";
        }
    }

    function pageScroll() {
        window.scrollBy(0, -1000000);
    }

    function ChangeImageIn() {
        document.getElementById("fixed-bottom_zhiding").src = "Themes/Skin_Default/Images/myzhiding1.png";
    }
    function ChangeImageOut() {
        document.getElementById("fixed-bottom_zhiding").src = "Themes/Skin_Default/Images/myzhiding.png";
    }
</script>



<script type="text/javascript">  
$(window).resize(function(){
 $('.sp_dialog_out').css({
  position:'absolute',
  left: ($(window).width() - $('.sp_dialog_out').outerWidth())/2,
   top: ($(window).height() - $('.sp_dialog_out').outerHeight())/2
 });
});
//初始化函数
$(window).resize();

</script>


<script type="text/javascript">
$(document).ready(function(){
    //鼠标滑过二维码显示隐藏
    $('div.ShouJi').MouseShow($('div.ShouJi_erwei'));
    $('div.MicroInfo').MouseShow($('div.erwei'));
    
    //鼠标滑过图片更换
    $('div.js-change-img img').ChangeImg();
});
jQuery.fn.extend({
    
    //鼠标滑过二维码显示隐藏
    MouseShow: function(item){
        if(this.length <= 0){
            return false;
        }
        var main = this;
        return main.bind({
            mouseover: function(e){
                item.show();
            },
            mouseout: function(e){
                item.hide();
            }
         });
         
    },
    
    //鼠标滑过图片更换
    ChangeImg: function(){
        if(this.length <= 0){
            return false;
        }
        var main = this;
        return main.bind({
            mouseover: function(e){
               var original = $(this).attr('src');
               var nowSrc = original.substring(0,original.length-4)+1+'.png';
               $(this).attr('src',nowSrc);
            },
            mouseout: function(e){
               var original = $(this).attr('src');
               var nowSrc = original.substring(0,original.length-5)+'.png';
               $(this).attr('src',nowSrc);
            }
         });
    }
});
</script>

