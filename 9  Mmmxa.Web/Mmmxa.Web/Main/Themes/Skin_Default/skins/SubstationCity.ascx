<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!--省市-->
<style type="text/css">
    /*地区*/.hua_city
    {
        width: 1000px;
        margin-top: 10px;
    }
    .flw_city_head
    {
        border-bottom: 1px solid #DCDCDC;
        font-size: 14px;
        padding: 10px 0;
        width: 1000px;
    }
    .select_city
    {
        color: #000000;
        font-weight: bold;
        height: 25px;
        line-height: 25px;
        text-align: left;
        width: 1000px;
    }
    .select_city .selected
    {
        margin-right: 5px;
        vertical-align: middle;
        width: 120px;
    }
    .select_city .cityinto
    {
        height: 23px;
        vertical-align: middle;
        width: 75px;
        cursor: pointer;
    }
    .hua_city_txt
    {
        float: left;
        margin-top: 20px;
        padding-bottom: 10px;
        width: 1000px;
    }
    .hua_city_txt strong
    {
        background: url(      "Themes/Skin_Default/Images/txt_bg.png" ) no-repeat center bottom;
        color: #FFFFFF;
        float: left;
        font-size: 14px;
        height: 34px;
    }
    .hua_city_txt strong span
    {
        background: none repeat #C00000;
        display: inline-block;
        height: 30px;
        line-height: 30px;
        padding: 0 10px;
        text-align: center;
    }
    .hua_city_con
    {
        float: left;
        font-size: 14px;
        line-height: 24px;
        padding: 10px 0;
        width: 1000px;
        color: #000;
    }
    .hua_city_con dt
    {
        color: #CC0000;
        float: left;
        font-family: "微软雅黑";
        font-size: 18px;
        text-align: center;
        text-transform: uppercase;
        width: 40px;
    }
    .hua_city_con dt span
    {
        display: inline-block;
        width: 30px;
    }
    .hua_city_con dd
    {
        float: left;
        width: 960px;
    }
    .hua_city_con dd a
    {
        color: #333333;
        float: left;
        margin-right: 10px;
        white-space: nowrap;
    }
    .hua_city_con .cluetip
    {
        width: 180px;
        position: absolute;
        z-index: 97;
        margin-left: -80px;
        _margin-left: -130px;
        _margin-top: 10px;
    }
    * + html .hua_city_con .cluetip
    {
        margin-left: -130px;
        margin-top: 10px;
    }
    .hua_city_con .cluetip .city
    {
        height: auto;
        background: url(      "Themes/Skin_Default/Images/lmf_ditu2.png" ) repeat-y center center;
        padding: 6px 10px 6px 14px;
    }
    .hua_city_con .cluetip .city ul
    {
        overflow: hidden;
    }
    .hua_city_con .cluetip .city ul li
    {
        white-space: nowrap;
    }
    .hua_city_con .cluetip .city ul li a
    {
        white-space: nowrap;
        margin: 4px;
        color: #333333;
        font-size: 13px;
    }
    .hua_city_con .cluetip .city a:hover
    {
        color: #bf0000;
    }
    .hua_city_con .cluetip_arrows
    {
        width: 205px;
        height: 20px;
        background: url(      "Themes/Skin_Default/Images/lmf_ditu1.png" ) no-repeat center center;
    }
    .hua_city_con .cluetip
    {
        width: 205px;
    }
    .hua_city_con .cluetip_arrows1
    {
        width: 205px;
        height: 12px;
        background: url(      "Themes/Skin_Default/Images/lmf_ditu3.png" ) no-repeat center top;
    }
    .hua_city_con .cluetip .city ul li
    {
        float: left;
    }
</style>

<script language="javascript" type="text/javascript">
        function  BindDropDownShopCategory2(dlist)
        {
             var ccode = dlist.options[dlist.selectedIndex].value;
             params = {'cityid':ccode}; 
             $("#City_ctl00_dropdownlistCity").html("");    
            $("#City_ctl00_dropdownlistCity").append("<option value=\"-1\">-请选择-</option>")
            $("#City_ctl00_dropdownlistCity").hide();
            $("#City_ctl00_dropdownlistArea").hide();

             $.getJSON("/Main/Api/AddressOpreateJson.aspx",params,function(json)
                {
                      if(json==null || json =="")
                      {
                        alert("kong");
                        return;
                      }
             
                       $("#City_ctl00_dropdownlistCity").show();
                        $.each(json,function(i){$("#City_ctl00_dropdownlistCity").append($("<option></option>").val(json[i].Value).html(json[i].Name))});
                });          
            
         }
         
          function  BindDropDownShopCategory3(dlist)
        {
       
             var ccode = new String();
             
             var code =new Array();
             code =dlist.options[dlist.selectedIndex].value;
             ccode =code.split('/')[1];
             params = {'cityid':ccode}; 
             $("#City_ctl00_dropdownlistArea").html("");    
            $("#City_ctl00_dropdownlistArea").append("<option value=\"-1\">-请选择-</option>")
            $("#City_ctl00_dropdownlistArea").hide();

             $.getJSON("/Main/Api/AddressOpreateJson.aspx",params,function(json){
              if(json==null || json =="")
              {
              return;
              }
             $("#City_ctl00_dropdownlistArea").show();
            $.each(json,function(i){$("#City_ctl00_dropdownlistArea").append($("<option></option>").val(json[i].Value).html(json[i].Name))});
            });          
            
         }
         
         function  goToShop()
{


 
  var selectvalue= $("#<%=dropdownlistArea.ClientID %>").find(":selected").val();
var shopur  = new String();
 var addresscode=selectvalue.split('/')[0];
 
  //获取对应的市
             $.ajax({
             type:"GET",
             async:true,
             url: "/Main/Api/Address.ashx",
             data: "addresscode="+addresscode+"&type=addresscode",
                success: function(result)
                 {
              
                        if (result!= "")
                        {
                       
                         shopurl=result;
                         window.location.href=shopurl;
                        }
                       
                     
                }
            });
 


}


</script>

<script language="javascript" type="text/javascript">
function  chickCity()
{

var temp=false;
     var selectvalue= $("#<%=dropdownlistCity.ClientID %>").find(":selected").val();

    if(selectvalue!="-1")    
    {
    window.location.href="http://"+window.location.host+"/default.aspx?cityid="+selectvalue.substr(selectvalue.indexOf('/')+1)+"";
    temp= false ;
    }   
    if(selectvalue=="-1")
    {
        alert('请选择城市');
        temp=false;
    }
  
    return temp;
}
</script>
<!---->
<script type="text/javascript">
var lodding="<img  src='/Main/Themes/Skin_Default/Images/lodding.gif'/>";

$(document).ready
(
    function()
    {

        $(".cityod").hover
        (
            function()
            {       
                    var e=this;
                    var cityid=$(this).attr("cityid");//市
                    var cityul=$("#city"+cityid+"");
                    var _cityul=$("#_city"+cityid+"");
                  $(this).children("div").removeClass("hidden");
                  
                    if(cityul.html()=="")
                   {
                       _cityul.html(lodding); 
                       //获取对应的市
                         $.ajax
                         ({
                             type:"GET",
                             async:true,
                             url: "/Main/Api/Address.ashx",
                             data: "cityid="+cityid+"&type=SearchArea1",
                                success: function(result)
                                 {
                             
                                        if (result!= "")
                                        {
                                            cityul.html(result);
                                            $(this).children("div").addClass("cluetip  clearfix");
                                          
                                        }
                                       else
                                        {
                                            cityul.html("");
                                        }
                                            _cityul.html("");
                                 }
                        });
                    }
            },
            //鼠标移除时
            function()
            {
                $(this).children("div").addClass("hidden");
            }
        )

        
})



 function city1_hidden(element)
    {
        $(element).addClass("hidden");
    }
    function city2_show(e)
    {
        $(this).removeClass("hidden");
    }
    


</script>
<%--<style>
    
</style>--%>


<div class="moka_city clearfix">
    <div class="flw_city_head" style=" display:none">
        <div class="hot_city" style="display: none;">
            <span>热门城市：</span>
            <asp:Repeater ID="RepeaterHotCity" runat="server">
                <ItemTemplate>
                    <%#((DataRowView)Container.DataItem).Row["CityName"]%>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="select_city" style=" display:none">
            按省份选择:
            <asp:DropDownList ID="dropdownlistProvince" runat="server" onchange="document.getElementById('HiddenRegion1').value=this.options[this.selectedIndex].text;BindDropDownShopCategory2(this);"
                CssClass="selected">
                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="dropdownlistCity" runat="server" CssClass="selected" onchange="document.getElementById('HiddenRegion2').value=this.options

[this.selectedIndex].text;BindDropDownShopCategory3(this);">
                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="dropdownlistArea" runat="server" CssClass="selected" onchange="document.getElementById('HiddenRegion3').value=this.options[this.selectedIndex].text;">
                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="ButtonEnter" runat="server" Text="进入" />
            <%--<img src="Themes/Skin_Default/Images/lambert_bg.gif" class="cityinto"  style="width: 53px; height: 26px;" />--%>
        </div>
    </div>
    <div class="hua_city_txt">
        <strong><span>按拼音首字母选择</span></strong>
    </div>
    <asp:Repeater ID="RepeaterCityLetter" runat="server">
        <ItemTemplate>
            <dl class="hua_city_con">
                <asp:HiddenField ID="HiddenFieldLetter" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["Letter"] %>' />
                <dt><span>
                    <%#((DataRowView)Container.DataItem).Row["Letter"]%></span>|</dt>
                <dd>
                    <asp:Repeater ID="RepeaterCityLetterChild" runat="server">
                        <ItemTemplate>
                            <a href='http://<%#Eval("DomainName").ToString() + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."))%>'>
                                <asp:Panel ID="PanelCityName" runat="server" ToolTip='<%#Eval("CityName")%>'>
                                    <div>
                                        <div class="cityod" js="addshowevent" id="cityod" cityid='<%#Eval("Guid")%>'>
                                            <a href='http://<%#Eval("DomainName").ToString() + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."))%>' target="_blank"><%#((DataRowView)Container.DataItem).Row["Name"]%></a>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </dd>
            </dl>
        </ItemTemplate>
    </asp:Repeater>
</div>
<input id="hideCategory1" name="hideCategory1" type="hidden" />
<input id="hideCategory2" name="hideCategory2" type="hidden" />
<input id="hideCategory3" name="hideCategory3" type="hidden" />
<input id="HiddenRegion1" name="HiddenRegion1" type="hidden" />
<input id="HiddenRegion2" name="HiddenRegion2" type="hidden" />
<input id="HiddenRegion3" name="HiddenRegion3" type="hidden" />
<asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
<asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
<asp:HiddenField ID="HiddenFieldRegion" runat="server" Value="-1" />
