<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">

    window.onload = function() {

        document.getElementById("dz1").onclick = function() {
            //window.showModelessDialog("BaiDuMap.aspx?point="+document.getElementById("hdLongitude").value+"|"+document.getElementById("hdLatitude").value,"百度地图","scroll:1;resizable:1;dialogWidth:1000px;dialogHeight:600px;");
            //location.href = "http://" + document.location.host + "/BaiDuMap.aspx?MemLoginID=" + $("#hdMemLoginID").val();
            window.open("http://"+document.location.host+"/BaiDuMap.aspx?MemLoginID="+$("#hdMemLoginID").val(),"_blank");

        }
    }
</script>
<!--店铺信息-->
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
            <h2 class="penis"><i></i><%#((DataRowView)Container.DataItem).Row["ShopName"]%></h2>
            <div class="ks_panel">
            <div class="ks_panel_tab">
            <table>
                
                <tr>
                    <td class="shopkperInfo">
                        <dl>
                            <dt class="ncs_infn">
                                <img id="Img1" width="64" height="64" src='<%# ((DataRowView)Container.DataItem).Row["Banner"]%>' runat="server" />
                            </dt>
                            <dd class="ncs_name">
                                <a class="shopkps">
                                     <%#((DataRowView)Container.DataItem).Row["Name"]%></a>
                                    <input type="hidden" id="hdMemLoginID" value='<%#((DataRowView)Container.DataItem).Row["MemLoginID"]%>' />
                                </dd>
                            <dd class="ncs_level">
                                <asp:Image ID="ImageReputation" runat="server" /></dd>
                            <dd>
                                好评率：
                                <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["HaoPingLV"])*100%>%
                            </dd>
                        </dl>
                        <span style="display: none;">店铺等级：<asp:Label ID="LabelShopRank" runat="server" Text="1"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="shop_rate">
                            <h4>店铺动态评分：</h4>
                             <dl>
                                <dt>描述相符：</dt>
                                <dd class="rate_star">
                                    <ul>
                                        <li class="ncs_bfl">
                                            <%#((DataRowView)Container.DataItem).Row["ShopCharacter"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopCharacter"]%>
                                        </li>
                                        <li class="<%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["CharacterBL"]) >= 0  ? "star_red" : "star_gren"%>">
                                            <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["CharacterBL"]) >= 0 ? "<div class=\"gaoyu\"><span class=\"over\">高于</span></div>" : "<div class=\"diyu\"><span class=\"down\">低于</span></div>"%>
                                        </li>
                                        <li class="centage">
                                            <%#(Convert.ToDouble(((DataRowView)Container.DataItem).Row["CharacterBL"]) * 100).ToString().Replace("-", "")%>%
                                        </li>
                                    </ul>
                                </dd>
                                <dt>服务态度：</dt>
                                <dd class="rate_star">
                                    <ul>
                                        <li class="ncs_bfl">
                                            <%#((DataRowView)Container.DataItem).Row["ShopAttitude"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopAttitude"]%>
                                        </li>
                                        <li class="<%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["AttitudeBL"]) >= 0  ? "star_red" : "star_gren"%>">
                                            <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["AttitudeBL"]) >= 0 ? "<div class=\"gaoyu\"><span class=\"over\">高于</span></div>" : "<div class=\"diyu\"><span class=\"down\">低于</span></div>"%>
                                        </li>
                                        <li class="centage">
                                            <%#(Convert.ToDouble(((DataRowView)Container.DataItem).Row["AttitudeBL"]) * 100).ToString().Replace("-", "")%>%
                                        </li>
                                    </ul>
                                </dd>
                                <dt>发货速度：</dt>
                                <dd class="rate_star">
                                    <ul>
                                        <li class="ncs_bfl">
                                            <%#((DataRowView)Container.DataItem).Row["ShopSpeed"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopSpeed"]%>
                                        </li>
                                        <li class="<%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["SpeedBL"]) >= 0  ? "star_red" : "star_gren"%>">
                                            <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["SpeedBL"]) >= 0 ? "<div class=\"gaoyu\"><span class=\"over\">高于</span></div>" : "<div class=\"diyu\"><span class=\"down\">低于</span></div>"%>
                                        </li>
                                        <li class="centage">
                                            <%#(Convert.ToDouble(((DataRowView)Container.DataItem).Row["SpeedBL"]) * 100).ToString().Replace("-", "")%>%
                                        </li>
                                    </ul>
                                </dd>
                            </dl>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="shop_detail">
                            <h4>店铺信息</h4>
                            <dl>
                                <dt>店铺名称：</dt><dd><%#((DataRowView)Container.DataItem).Row["ShopName"]%></dd>
                                <dt>固定电话：</dt><dd><%# string.IsNullOrEmpty(((DataRowView)Container.DataItem).Row["Tel"].ToString()) == true ? "暂无" : ((DataRowView)Container.DataItem).Row["Tel"]%></dd>
                                <dt>手机号码：</dt><dd><%# string.IsNullOrEmpty(((DataRowView)Container.DataItem).Row["Phone"].ToString()) == true ? "暂无" : ((DataRowView)Container.DataItem).Row["Phone"]%></dd>
                                <dt>店铺地址：</dt><dd class="shop_addre"><%#((DataRowView)Container.DataItem).Row["Address"]%></dd>
                                <dt>店铺保障：</dt><dd><ShopNum1Shop:ShopEnsure ID="ShopEnsure1" runat="server" SkinFilename="ShopEnsure1.ascx" />
                                </dd>
                            </dl>
                        </div>
                    </td>
                </tr>
                <tr id="TRIdentity" runat="server">
                    <td>
                        <div class="shop_detail">
                            <dl>
                                <dt>认证信息：</dt>
                                <dd>
                                    <p>
                                        <a href="javascript:void(0)" title="实名认证">
                                            <asp:Image ID="ImageIdentity" ImageUrl="/Main/Themes/Skin_Default/Images/rz1-1.jpg" runat="server" /></a> 
                                        <a href="javascript:void(0)" title="公司认证">
                                            <asp:Image ID="ImageCompan" ImageUrl="/Main/Themes/Skin_Default/Images/rz2-2.jpg" runat="server" /></a>
                                    </p>                
                                </dd>                                
                            </dl>
                        </div>
                    </td>
                </tr>
                <asp:HiddenField ID="HiddenFieldLongitude" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["Longitude"]%>' />
                <asp:HiddenField ID="HiddenFieldLatitude" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["Latitude"]%>' />
             </table>
             </div>
              </div>
            </ItemTemplate>
        </asp:Repeater>
<div class="ks_panels">
    <ul>
        <li id="dz1" onmouseover="changes(1)" onmouseout="showsearch()" class="ncs_map"><a><span>店铺地图</span></a></li>
        <li id="dz2" onmouseover="changes(2)" onmouseout="showsearch()"  class="ncs_cord"><a><span>店铺二维码</span></a></li>        
    </ul>    
    <div class="ristn">
        <!--百度地图-->    
        <div id="map1" class="ncs_ctain" ></div>
        <!--手机扫描二维码--> 
        <div id="map2" class="ncs_ctain">
            <p style="text-align: center;"><img src="Themes/Skin_Default/Images/qrcode.png"/></p>
            <p class="ncs_cord_word">手机扫描二维码</p>
        </div>
    </div>    
</div>
<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.4"></script>
<script type="text/javascript" language="javascript">

$(".ks_panels").hover(function(){
$(this).children(".ristn").show();
},function(){
$(this).children(".ristn").hide();
});
</script>
<script type="text/javascript" language="javascript">

//百度地图和二维码切换
function changes(value){
    if(value=="1")
    {
        $("#map1").show();	$("#dz1").addClass("current");
        $("#map2").hide();	$("#dz2").removeClass("current");	
        var Longitude=$("#ShopInfo_ctl00_RepeaterShow_ctl00_HiddenFieldLongitude").val();
        var Latitude=$("#ShopInfo_ctl00_RepeaterShow_ctl00_HiddenFieldLatitude").val();
        var map = new BMap.Map("map1");
        var point = new BMap.Point(Longitude,Latitude);
        var marker  = new BMap.Marker(point);
        map.addOverlay(marker);
        
        
        map.centerAndZoom(new BMap.Point(Longitude,Latitude), 14);
        map.addControl(new BMap.NavigationControl());  //添加默认缩放平移控件
        map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_TOP_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL}));  //右上角，仅包含平移和缩放按钮
        map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_BOTTOM_LEFT, type: BMAP_NAVIGATION_CONTROL_PAN}));  //左下角，仅包含平移按钮
        map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_ZOOM}));  //右下角，仅包含缩放按钮
   }
   else
   {
         $("#map2").attr("style","height:255px");$("#map2").show();
         $("#dz2").addClass("current");
         $("#map1").hide(); $("#map1").attr("style","");
         $("#dz1").removeClass("current");	        
   }
}
</script>

