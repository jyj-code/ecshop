<table border="0" cellspacing="0" cellpadding="0" class="tabbiao">
    <tr>
        <td width="130" style="padding-left: 40px;">
            鼠标点击获取经纬度：
        </td>
        <td>
            <asp:TextBox ID="TextBoxMapValue" runat="server" CssClass="textwb"></asp:TextBox>
            <span class="red" id="errMapValue">*</span>
        </td>
    </tr>
    <tr>
        <td width="130" style="padding-left: 40px;">
            <input  type="button" value="搜索"  class="baocbtn" id="btnSerch"/>
        </td>
        <td>
        <input type="text" id="txtSerchSite"  class="textwb"/>
            <span class="red" id="Span1">*</span>(请输入地区名称)
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div id="allmap" style="width: 750px; height: 500px; margin-left: 20px;">
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center; line-height: 46px; padding-top: 20px;">
            <asp:Button ID="ButtonSave" runat="server" Text="设置" CssClass="baocbtn" />
        </td>
    </tr>
</table>

    <div>
    <asp:HiddenField  ID="hdShopName" runat="server"/>
    <asp:HiddenField  ID="hdShopAdress" runat="server"/>
    </div>
<!--地理位置 start-->

<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=Ysv2U4rRH9zYrFltfyl73WbB"></script>

<script type="text/javascript">
var Result=$("#<%=TextBoxMapValue.ClientID %>").val();

var map = new BMap.Map("allmap");
map.centerAndZoom(new BMap.Point(Result.split(',')[0],Result.split(',')[1]), 14);

var point = new BMap.Point(Result.split(',')[0],Result.split(',')[1]);
var marker  = new BMap.Marker(point);
map.addOverlay(marker);


var opts = {
  width : 200,     // 信息窗口宽度
  height: 60,     // 信息窗口高度
  title : $("#<%=hdShopName.ClientID%>").val() , // 信息窗口标题
  enableMessage:true,//设置允许信息窗发送短息
  message:$("#<%=hdShopAdress.ClientID%>").val() 
}
var infoWindow = new BMap.InfoWindow($("#<%=hdShopAdress.ClientID%>").val() , opts);  // 创建信息窗口对象
map.openInfoWindow(infoWindow,point); //开启信息窗口



map.addEventListener("click",function(){
    
});


map.addControl(new BMap.NavigationControl());  //添加默认缩放平移控件
map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_TOP_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL}));  //右上角，仅包含平移和缩放按钮
map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_BOTTOM_LEFT, type: BMAP_NAVIGATION_CONTROL_PAN}));  //左下角，仅包含平移按钮
map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_ZOOM}));  //右下角，仅包含缩放按钮

//点击获取点击鼠标的经纬度
map.addEventListener("click", function(e){
    $("#<%=TextBoxMapValue.ClientID %>").val(e.point.lng + "," + e.point.lat) ;
//    this.openInfoWindow(infoWindow, map.getCenter());      // 打开信息窗口
});


// 创建地址解析器实例   
var myGeo = new BMap.Geocoder();  


window.onload=function(){

document.getElementById("btnSerch").onclick=function(){

var local = new BMap.LocalSearch(map, {
  renderOptions: {    
   map: map,    
   autoViewport: true,    
   selectFirstResult: true    
 },    
  pageCapacity: 1    
});
local.search($("#txtSerchSite").val());


// 将地址解析结果显示在地图上，并调整地图视野  
myGeo.getPoint(document.getElementById("txtSerchSite").value, function( pointRes ){    
 if (pointRes) {      
   $("#<%=TextBoxMapValue.ClientID%>").val(pointRes.lng+","+pointRes.lat);
 }    
}, map); 


};

};


</script>

<!--地理位置 End-->
