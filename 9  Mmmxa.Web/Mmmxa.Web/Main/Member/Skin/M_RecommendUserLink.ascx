<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.MemberWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace=" System.Data" %>
<script language="javascript">
        $(function(){
             if($("#M_RecommendUserLink_ctl00_inputShopurl").val().indexOf("userRecommend")==-1)
             {
                $("#M_RecommendUserLink_ctl00_inputShopurl").val($("#M_RecommendUserLink_ctl00_inputShopurl").val()+escape($("#M_RecommendUserLink_ctl00_hidMemLoginId").val())+"&userRecommend");    
             }
        });
        
 $(function(){
        if (!!window.ActiveXObject && !window.XMLHttpRequest) {
            $("#btn_Curl").click(function() {
                var clipBoardContent = $("#<%=inputShopurl.ClientID %>").val();
                if (window.clipboardData.setData("Text", clipBoardContent)) {
                    alert("以下内容已成功复制到粘贴板中:\r\n" + clipBoardContent);
                }
            })

        }
        else {
            $("#btn_Curl").zclip({
                path: '/JS/zclip/ZeroClipboard.swf',
                copy: $("#<%=inputShopurl.ClientID %>").val()
            });
        }      
});
</script>
<input type="hidden" id="hidMemLoginId" runat="server" />
        <div id="content" class="ordmain1" style="height:600px;">
        <div style="margin-top: 30px;border-left: 1px solid #C6DFFF; border-right: 1px solid #C6DFFF; border-bottom: 1px solid #C6DFFF; float:left; width:100%">
          <div style="border-top:solid 1px #c6dfff; border-bottom:solid 1px #c6dfff; border-left:solid 1px #c6dfff; border-right:solid 1px #c6dfff; height:30px; line-height:30px; background:#f6faff;  color:#6d6d6d; text-align:left; text-indent:15px; ">                       快捷推荐                     </div>
                 <div style="padding: 10px 20px;">
                    <div style="line-height: 20px; text-align:left;">
                            复制链接发给QQ/MSN上的好友：</div>
   
                     
                                    <input type="text" class="ss_nr1" style="width: 630px;"  runat="server" id="inputShopurl"/>
                               
                                    <a href="javascript:void(0)" class="zf_bot" id="btn_Curl">复制地址</a>
                    </div>       
        </div>
</div>
