<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript" language="javascript">
    var BrandAjaxUrl="/Api/S_OpGoods1.ashx?type=0&brand_cid=<%=Request.QueryString["ctype"] %>";
</script>
<style type="text/css">
    .editbox 
    {
    display:inline;
    padding: 0px;
    width: 35px; line-height:25px; height:25px;
}
.hint {
    color: #BBBBBB;
    line-height: 20px;
}
input.spec_txt{border: 1px solid #A7A6AA;height: auto; margin: 0; width:100px;}
</style>
<%
    //这里是判断规格属性品牌如果没有绑定商品类型则更改显示方式
   // if (Common.ReqStr("pid").Length < 30 || Spec_show.InnerHtml.Length<50) { Spec_show.Visible = false; Prop_show.Visible = false; } %>
<asp:HiddenField ID="hidSetsp" runat="server" />
<input type="hidden" id="hidCategoryName" runat="server" />
<input type="hidden" id="hidEditBind" runat="server" />
               <dl class="tibxxbg" style="display:none">
                  <dt>宝贝类型：</dt>
                  <dd>
                       <input name="gType" type="radio" value="0" checked="checked" />全新
                       <input name="gType" type="radio" value="1" />二手
                   </dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>物品类型：</dt>
                  <dd>
                       <input name="IsReal" type="radio" value="1" checked="checked" />实际物品
                       <input name="IsReal" type="radio" value="0" />生活服务
                   </dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>主站商品分类：</dt>
                  <dd>
                     <div class="fudong" id="productCategoryName">&nbsp;</div>
                     <div class="fudong">
                         <a href='S_SellGoods_One.aspx?op=add&step=one&cid=<%=Request.QueryString["cid"] %>&pid=<%=Request.QueryString["pid"] %>' class="selpic"><span>编辑</span></a>
                     </div>
                  </dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>商品类别：</dt>
                  <dd>
                    <input name="pType" type="checkbox" id="isnew" value="0"/>新品
                    <input name="pType" type="checkbox" id="ishot" value="1" />热卖
                    <input name="pType" type="checkbox" id="ispromotion" value="2" />促销 
                    <input name="pType" type="checkbox" id="Isrecommend" value="3" />推荐</dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>商品名称：</dt>
                  <dd>
                      <input name="input" type="text" id="txtGoodsName" class="textwb" style="width:300px;" maxlength="50"/><span check="errorMsg"  style="color:Red; display:none">商品标题名称长度至少3个字符，最长50个汉字！</span><span style="color:Red;">*</span>
                      <br />
                      <span class="gray1">商品标题名称长度至少3个字符，最长50个汉字</span> 
                      </dd>
                </dl>
                <%if (Common.ReqStr("ctype") != "0")
                  { %>
                <dl class="tibxxbg" id="Spec_show" runat="server">
                  <dt>商品规格：</dt>
                  <dd>
                    <div class="yanskuang">
                         <%DataTable dt_specv=S_OpGoods1.dt_Specvalue;
                           if (dt_specv != null)
                           {
                               for (int i = 0; i < dt_specv.Rows.Count; i++)
                               {
                                   DataTable dt_subspec = S_OpGoods1.dt_SubSpecv(dt_specv.Rows[i]["id"].ToString());
                                   if (dt_subspec.Rows.Count > 0)
                                   {%>
                                        <div class="yansda" shop_Spec="Spec_group_<%=i%>">
                                        <div><input type="hidden" name="hidNewSpec" value="<%=dt_specv.Rows[i]["id"].ToString() %>"/> <%=dt_specv.Rows[i]["SpecName"]%>：</div>
                                        <ul class="spec">
                                        <% for (int j = 0; j < dt_subspec.Rows.Count; j++)
                                           {
                                               string strTcID = dt_subspec.Rows[j]["tc"].ToString();
                                               string strSpecIsCheck = strTcID != "" ? "checked='checked'" : ""; string strIsValue = dt_subspec.Rows[j]["tv"].ToString();
                                               strIsValue = strIsValue != "" ? strIsValue : dt_subspec.Rows[j]["name"].ToString();
                                               string strSpecTxtIsShow = strTcID != "" ? "" : "display:none";
                                               %>
                                           
                                              <!--规格详细数据--> 
                                              <li> 
                                                <span class="checkbox" spec_check="this_check">
                                                <input name='check_spec' vd='<%=strTcID %>' <%=strSpecIsCheck%> lang='<%=dt_specv.Rows[i]["id"]%>' spec_type='<%=dt_subspec.Rows[j]["id"] %>' type="checkbox" value='<%=dt_subspec.Rows[j]["name"]%>'/>
                                                </span> 
                                                <%if (dt_specv.Rows[i]["showtype"].ToString() == "1")
                                                  { %>
                                                <span class="img"><img src='<%=dt_subspec.Rows[j]["imagepath"] %>' width="16" height="16" /></span> 
                                                <%} %>
                                                <span style="vertical-align:2px;" class="default_txt"><%=dt_subspec.Rows[j]["tv"].ToString() != "" ?"" : dt_subspec.Rows[j]["name"].ToString()%></span>
                                                <span  class="pvname" style="<%=strSpecTxtIsShow%>">
                                                  <input id='j_<%=dt_subspec.Rows[j]["id"] %>' sepc='<%=strTcID %>:<%=dt_subspec.Rows[j]["id"]%>' sepc_value="this_name" spec_type='<%=dt_subspec.Rows[j]["id"] %>'  class="yanstex" type="text" name="specv" value='<%=strIsValue %>' maxlength="15">
                                                </span> 
                                               </li>
                                              <!--规格详细数据--> 
                                      <%}%>
                                        </ul>
                                        </div>
                    
                    <!--判断规格是否有图片，有图片则加上上传框-->             
                    <%if (dt_specv.Rows[i]["showtype"].ToString() == "1")
                      { %>
                            <table style="<%=Common.ReqStr("pid").Length<35?"display:none":"" %>" width="701px" border="0" cellspacing="1" cellpadding="0" class="ystctab" id='showUp_<%=dt_specv.Rows[i]["id"].ToString() %>'>
                            <tr>
                              <th scope="col" width="25%"><%=dt_specv.Rows[i]["SpecName"]%>：</th>
                              <th scope="col" width="75%">图片（无图片可不填）</th>
                            </tr>
                         <%for (int j = 0; j < dt_subspec.Rows.Count; j++)
                           {%>
                            <tr style="<%=dt_subspec.Rows[j]["tc"].ToString()!=""?"'":"display:none"%>" id="fileup_<%=dt_subspec.Rows[j]["id"] %>">
                              <td>
                                        <img src="<%=dt_subspec.Rows[j]["imagepath"] %>"  width="16" height="16" />
                                        <span style="vertical-align:2px;"><%=dt_subspec.Rows[j]["name"]%></span>
                              </td>
                              <td style="width:450px;">
                                    <span class="spflot">
                                    <input class="textwb" type="text" value="<%=dt_subspec.Rows[j]["tm"] %>"></span>
                                    <span class="spflot1"><input type="file" name="fileup" class="" onchange="SpecfileUpload(this,'')" style="width:70px;"/><input type="hidden" sepc_pic="filePath_<%=dt_subspec.Rows[j]["id"] %>" value="<%=dt_subspec.Rows[j]["tm"] %>"/><%--<img src="images/transparent.gif" style="height:30px; width:30px; border:0px;float:left;" alt="jy"/>--%></span>
                                    
                              </td>
                            </tr>
                           <%}
                      }%>
                         </table>
                    <!--判断规格是否有图片，有图片则加上上传框-->   
                    <div class="clearbot"></div>
                   <%}
                               }
                           }%>

                  
                      <div class="clearbot"></div>
                    
                      
                           <%if (dt_specv != null)
                             {%>
                             <table width="90%" border="0" cellspacing="1" cellpadding="0" style="<%=Common.ReqStr("pid").Length<30?"display:none":"" %>" class="ystctab" id="showSpecTab">
                                   <thead>
                                        <tr>
                                 <%for (int i = 0; i < dt_specv.Rows.Count; i++)
                                   {%>
                                          <th><%=dt_specv.Rows[i]["SpecName"]%></th>
                                 <%}%>
                                         <th><span style="color:#ff0000;">*</span>价格</th>
                                         <th><span style="color:#ff0000;">*</span>库存</th>
                                         <th>商品货号</th>
                                        </tr>
                                        </thead>
                                        <tbody id="Spec_body">
                                           <asp:Repeater ID="repStockSet" runat="server">
                                                <ItemTemplate>
                                                 <tr value="<%#Eval("SpecDetail")%>" SpecTotal="<%#Eval("spectotalid")%>" name="spec_Detail">
                                                     <td>
                            			                <input type="text" spec_type="<%#Eval("spectotalid")%>|price" value="<%#Eval("GoodsPrice")%>"  data_type="goods_price" maxlength="8" onblur="checkpriceTxt(this);onchangestock(this);" name="spec[<%#Eval("spectotalid")%>][price]" class="spec_txt"></td>    
                            			                <td><input type="text" spec_type="<%#Eval("spectotalid")%>|stock" maxlength="5" value="<%#Eval("GoodsStock")%>" data_type="goods_stock" name="spec[<%#Eval("spectotalid")%>][stock]" onblur="NumTxt_Int(this);onchangestock(this);" class="spec_txt"></td>
                            			                <td><input type="text" spec_type="<%#Eval("spectotalid")%>|sku" maxlength="8" value="<%#Eval("GoodsNumber")%>" data_type="goods_no" name="spec[<%#Eval("spectotalid")%>][sku]" class="spec_txt"></td>
                                                    </tr>
                                             </ItemTemplate>
                                         </asp:Repeater>
                                        </tbody>
                                      </table>
                             <%} %>
                    </div>
                    <div style="color:Red; display:none;" id="stockSpec">商品价格不能为0.00或空,商品库存不能为空！</div>
                  </dd>
                </dl>
                <%} %>
                 <dl class="tibxxbg">
                  <dt>商品库存：</dt>
                  <dd>
                    <input name="input" id="txtStock" type="text" class="textwb" onkeyup="NumTxt_Int(this)" maxlength="5" value="1"/><span check="errorMsg"  style="color:Red; display:none">商铺库存数量必须为1~1000000000之间的整数！</span><span style="color:Red;">*</span><br />
                    <span class="gray1">商铺库存数量必须为0~100000之间的整数</span> </dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>库存警告数量：</dt>
                  <dd>
                    <input name="input" id="txtRepertoryAlertCount" type="text" class="textwb" onkeyup="NumTxt_Int(this)" maxlength="5" value="1"/><span check="errorMsg"  style="color:Red; display:none">商铺库存警告数量必须为1~1000000000之间的整数！</span><span style="color:Red;">*</span><br />
                    <span class="gray1">商铺库存警告数量必须为1~100000之间的整数</span> </dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>商品价格：</dt>
                  <dd>
                    <input name="input" id="txtShopPrice" onblur="checkpriceTxt(this)" type="text"  maxlength="9" class="textwb" value=""  /><span check="errorMsg"  style="color:Red; display:none">商品价格必须是0.01~1000000之间的数字！</span><span style="color:Red;">*</span><br />
                    <input name="goods_price_sum" value="" type="hidden"  />
                    <span class="gray1">商品价格必须是0.01~1000000之间的数字</span> </dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>市场价格：</dt>
                  <dd>
                    <input name="input" id="txtMarketPrice" type="text" onblur="checkpriceTxt(this)" maxlength="9" class="textwb" value=""  /><span check="errorMsg"  style="color:Red; display:none">市场价格必须是0.01~1000000之间的数字！</span><span style="color:Red;">*</span><br />
                    <input name="goods_mprice_sum" value="" type="hidden"  />
                    <span class="gray1">市场价格必须是0.01~1000000之间的数字</span> </dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>商品货号：</dt>
                  <dd>
                    <input name="input" id="txtNumber" type="text" class="textwb" maxlength="20" />
                    <span class="gray1">最多可输入20个字符，支持输入中文、字母、数字、_、/、-和小数点</span> </dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>商品单位：</dt>
                  <dd>
                    <input name="input" id="txtUnitname" type="text" class="textwb"  />
                    <span class="gray1">&nbsp;</span> </dd>
                </dl>
                <dl class="tibxxbg" id="Prop_show" runat="server">
                  <dt>商品属性：</dt>
                  <dd>
                    <div class="yanskuang">
                        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="yanstab">
                      <tbody>
                       <%DataTable dt_Prop = S_OpGoods1.dt_Provalue;if (dt_Prop != null){for (int i = 0; i < dt_Prop.Rows.Count; i++){%>
                      <tr>
                        <td width="100%" align="left"><strong style="color:#666;"><%=dt_Prop.Rows[i]["PropName"]%>：</strong>
                         </td></tr>
                         <tr><td><ul class="clearfix">
                           <%DataTable dt_SubProp = S_OpGoods1.dt_SubPropv(dt_Prop.Rows[i]["id"].ToString());
                             for (int j = 0; j < dt_SubProp.Rows.Count; j++)
                             {%>
                              <% if (dt_Prop.Rows[i]["showtype"].ToString() == "0")
                                 { %>
                                 <!--文字输入-->
                                   <li> <span><%=dt_SubProp.Rows[j]["name"]%>:</span><input type="text" prop_type='0,<%=dt_Prop.Rows[i]["id"]%>,<%=dt_SubProp.Rows[j]["id"]%>' class="prop_txtinput_text"  name='prop_check_0' lang='<%=dt_Prop.Rows[i]["id"]%>' value="<%=dt_SubProp.Rows[j]["iv"]%>"></li>
                                <!--文字输入-->
                              <%}
                                 else if (dt_Prop.Rows[i]["showtype"].ToString() == "1")
                                 { %>
                                 <!--列表单选-->
                               <li>
                                <input type="radio" <%=dt_SubProp.Rows[j]["vcheck"].ToString()==""?"":"checked='checked'"%>  class="prop_radio_text" prop_type='1,<%=dt_Prop.Rows[i]["id"]%>,<%=dt_SubProp.Rows[j]["id"]%>,' value="<%=dt_SubProp.Rows[j]["id"] %>" name='prop_check_<%=dt_Prop.Rows[i]["id"]%>' lang='<%=dt_Prop.Rows[i]["id"]%>'>
                                <span style="vertical-align:2px;"><%=dt_SubProp.Rows[j]["name"]%></span>
                               </li>
                                <!--列表单选-->
                               <%}
                                 else if (dt_Prop.Rows[i]["showtype"].ToString() == "2")
                                 { %>
                                
                                     <%if (j == 0)
                                       { %>
                                         <!--下拉框选择-->
                                         <li><select name='prop_check_2' prop_type='2,<%=dt_Prop.Rows[i]["id"]%>'  class="prop_select_text"  lang='<%=dt_Prop.Rows[i]["id"]%>'>
                                         <option value="000">-请选择-</option>
                                        <%} %> 
                                            <option <%=dt_SubProp.Rows[j]["vcheck"].ToString()==""?"":"selected='selected'"%> value='<%=dt_SubProp.Rows[j]["id"]%>'><%=dt_SubProp.Rows[j]["Name"]%></option>
                                        <%if (j == dt_SubProp.Rows.Count)
                                          { %>
                                          </select> 
                                          </li>
                                           <!--下拉框选择-->
                                        <%} %>
                               <%}
                                 else if (dt_Prop.Rows[i]["showtype"].ToString() == "3")
                                 { %>
                                 <!--列表多选-->
                               <li>
                                <input type="checkbox" <%=dt_SubProp.Rows[j]["vcheck"].ToString()==""?"":"checked='checked'"%> class="prop_list_check" value="3,<%=dt_SubProp.Rows[j]["id"] %>" prop_type='3,<%=dt_Prop.Rows[i]["id"]%>,<%=dt_SubProp.Rows[j]["id"]%>'  lang='<%=dt_Prop.Rows[i]["id"]%>'>
                                <span style="vertical-align:2px;"><%=dt_SubProp.Rows[j]["name"]%></span>
                               </li>
                               <!--列表多选-->
                              <%}
                                 else if (dt_Prop.Rows[i]["showtype"].ToString() == "4")
                                 { %>
                                <li>                            
                                <div class="sxtitle">
                            <p style="border:none;">自定义属性</p>
                            <div class="sxtitle_nr">
                                 <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <th colspan="2" scope="col">
                                       <input type="button" id="addProp" class="btn_add" onclick="add_Prop(this)" value="新增属性" />
                                       <span check="errorMsg"  style="color:Red; display:none">最多添加30组自定义属性！</span>
                                    </th>
                                   </tr>
                                  <tr>
                                    <th colspan="2" scope="col">最多可添加30组自定义属性（非必填），如：镜头：15cm</th>
                                   </tr>
                                 <tbody class="prop_handinput_text"  lang='4,<%=dt_Prop.Rows[i]["id"]%>,<%=dt_SubProp.Rows[j]["id"]%>'>                        
                                 
                                  <%if(dt_SubProp.Rows[j]["iv"].ToString()!=""){
                                        string strInput=dt_SubProp.Rows[j]["iv"].ToString();
                                        if (strInput.IndexOf("*") != -1)
                                        {
                                            for (int v = 0; v < strInput.Split('*').Length; v++)
                                            {
                                                if (strInput.IndexOf("%") != -1)
                                                {
                                                    string[] TxtArray = strInput.Split('*')[v].Split('%');
                                                    if (TxtArray[0] != "")
                                                    {
                                                    %>
                                                    
                                    <!--循环自定义数据-->
                                    <tr>
                                        <td width="500" class="defined_Prop">
          <input type="text" class="textwb" name="input_defined_1" style="width:100px;" value="<%=TxtArray[0] %>"/>：<input type="text" class="textwb " style="width:200px;" name="input_defined_2" value="<%=TxtArray[1] %>"/>
                                        &nbsp;<span class="gray1 delprop">删除</span>&nbsp;<span class="gray1 clearprop">清空</span>
                                    </td>
                                  </tr>
                                   <!--循环自定义数据-->
                                            <%}
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string[] TxtArray = strInput.Split('%');
                                            %>
                                         <tr>
                                    <td width="500" class="defined_Prop">
          <input type="text" class="textwb" name="input_defined_1" style="width:100px;" value="<%=TxtArray[0] %>"/>：<input type="text" class="textwb " style="width:200px;" name="input_defined_2" value="<%=TxtArray[1] %>"/>
                                        &nbsp;<span class="gray1 delprop">删除</span>&nbsp;<span class="gray1 clearprop">清空</span>
                                    </td>
                                  </tr>
                                        
                                        <%}
                                    } %>
                                  </tbody>
                                </table>
                          </div>
                          </div>
                         </li>
                                <%}
                             }%>
                        </ul></tr>
                             <%}
     
                         } %>
                       
                    </tbody></table>
                    </div>
                  </dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>商品品牌：</dt>
                  <dd>
                     <select name="sel" size="1" class="select_Brand" id="selectbrand">
                        <option value="00000000-0000-0000-0000-000000000000">其它</option>
                      </select>
                      <span style="display:none;" id="OtherBrand">
                      <input type="text" id="txtPersonBrand" class="textwb" /></span> 
                   </dd>
                </dl>
                <dl class="tibxxbg">
                  <dt>商品图片：</dt>
                  <dd>
                  <div class="shappic">
                       <ul>
                         <li class="chali1" id="tabpic1" onclick="changTabPic('#tabpic2',this)">商品图片</li>
                         <li class="chali2" id="tabpic2" onclick="changTabPic('#tabpic1',this)">从用户相册中选择</li>
                       </ul>
                    <div style="clear:both;"></div>
                       <div  class="shappic_nr">
                           <div id="TabAlbum" style="display:none">
                           <table width="100%" border="0" cellspacing="3" cellpadding="0">
                              <tr>
                                <td>&nbsp;用户相册 > 全部图片</td>
                                <td>&nbsp;</td>
                                <td align="right">
                                  <input type="hidden" id="albumtype" value="0" />
                                  <select name="select_album" class="tselect" >
                                     <option value="0">-请选择-</option>
                                     <option value="1">默认相册</option>
                                  </select>
                                </td>
                              </tr>
                            </table>
                            <div id="albumlist">
                                <ul style="width:100%">
                                </ul>
                            </div>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td>&nbsp;</td>
                                <td width="465">
                                 <div class="fy">
                                        <span id="currentPage" style="width: 150px;">当前页<label id="lblpageIndex" style="width: 20px;">1</label>/<label id="lblpageCount"></label>页</span>
                                        <span id="OtherPageNum" class="num"></span>
                                        <span id="droplist"></span>一共<span class="lblNumCount"></span>条记录
                                    </div>
                                </td>
                              </tr>
                            </table>
                            </div>
                           <ul>
                             <li style="padding-top:10px;">
                                    <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img"  width="114" height="114" id="imgvj_1" onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'"/>
                             </li>
                             <li style="padding-left:20px;padding-top:5px; display:none;" id="file_0_del"><input type="button" value="删除图片" name="file_btn" class="selpic"/></li>
                             <li style="position: relative; padding-top: 40px;" id="file_0_upload">
                                  <div class="upload-btn">
                                      <span>
                                            <input type="file"  onchange="changfile(this,'#imgvj_1')" id="file_0" name="file_0" />
                                      </span>
                                      <div class="selpic">图片上传</div>
                                  </div>
                           </li>

                           </ul>
                          <ul>
                             <li style="padding-top:10px;"><img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img"  width="114" height="114" name="pro_img" id="imgvj_2" onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'"/></li>
                             <li style="padding-left:20px;padding-top:5px; display:none;" id="file_1_del"><input type="button" value="删除图片" name="file_btn" class="selpic"/></li>
                             <li style="position: relative; padding-top: 40px;" id="file_1_upload">
                                <div class="upload-btn">
                                      <span>                           
                                      <input type="file"  onchange="changfile(this,'#imgvj_2')" id="file_1" name="file_1" />
                                      </span>
                                      <div class="selpic">图片上传</div>
                                  </div>
                            </li>
                           </ul>
                        <ul>
                         <li style="padding-top:10px;"><img src="/ImgUpload/noimg.jpg_100x100.jpg"  name="pro_img" width="114" height="114"  id="imgvj_3" onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'"/></li>
                         <li style="padding-left:20px;padding-top:5px; display:none;" id="file_2_del"><input type="button" value="删除图片" name="file_btn" class="selpic"/></li>
                         <li style="position: relative; padding-top: 40px;"  id="file_2_upload">
                                <div class="upload-btn">
                                      <span>
                                      <input type="file" onchange="changfile(this,'#imgvj_3')" id="file_2" name="file_2" />
                                      </span>
                                      <div class="selpic">图片上传</div>
                                  </div>
                          </li>
                           </ul>
                           <ul>
                             <li style="padding-top:10px;"><img src="/ImgUpload/noimg.jpg_100x100.jpg"  name="pro_img" width="114" height="114"  id="imgvj_4"  onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'"/></li>
                              <li style="padding-left:20px;padding-top:5px; display:none;" id="file_3_del"><input type="button" value="删除图片" name="file_btn" class="selpic"/></li>
                             <li style="position: relative; padding-top: 40px;" id="file_3_upload">
                                    <div class="upload-btn">
                                      <span>
                                      <input type="file"  onchange="changfile(this,'#imgvj_4')"  id="file_3" name="file_3" />
                                      </span>
                                      <div class="selpic">图片上传</div>

                                  </div>
                          </li>
                           </ul>
                          <ul>
                             <li style="padding-top:10px;"><img src="/ImgUpload/noimg.jpg_100x100.jpg"  name="pro_img" width="114" height="114" id="imgvj_5"  onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'"/></li>
                              <li style="padding-left:20px;padding-top:5px; display:none;" id="file_4_del"><input type="button" value="删除图片" name="file_btn" class="selpic"/></li>
                             <li style="position: relative; padding-top: 40px;"  id="file_4_upload">
                                    <div class="upload-btn">
                                      <span>
                                      <input type="file" onchange="changfile(this,'#imgvj_5')" id="file_4" name="file_4">
                                      </span>
                                      <div class="selpic">图片上传</div>
                                     
                                  </div>
                          </li>
                           </ul>
                           <div style=" clear:both;"></div>
                           <h2 class="spth2">此处为您的商品图片，将显示在店铺图库里，图片大小不能超过1M。<span id="errpicmsg" style="color:Red; display:none"></span></h2>
                           <h3 class="spth3">建议使用宽300像素-高300像素内的Jpg图片</h3>
                           <h3 class="spth3"><span class="red" style="display:none;" id="showpic"> 至少上传一张图片！</span></h3>
                      </div>
                  </div>
                  </dd>
                </dl>
                