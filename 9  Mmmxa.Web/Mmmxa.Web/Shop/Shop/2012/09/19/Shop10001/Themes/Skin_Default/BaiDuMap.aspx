<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" EnableViewState="false"%>
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' /> 
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
        body, div, dl, dt, dd, ul, ol, li, h1, h2, h3, h4, h5, h6, form, fieldset, legend, input, textarea, select, button, th, td, p, hr, blockquote, pre, code {
            margin: 0;
            padding: 0;
        }

        .outlet {
            overflow: hidden;
            margin: 27px auto;
            width: 100%;
            height: 802px;
        }
        .warp{width: 100%}
            .outlet .outlet-left {
                position: relative;
                float: left;
                width: 401px;
                height: 100%;
                min-width: 392px;
                box-shadow: 1px 1px 8px rgba(0,0,0,.2);
            }

                .outlet .outlet-left .outlet-filter {
                    /*-moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;*/
                    border-color: #ededed #ededed;
                    border-image: none;
                    border-style: solid solid none;
                    border-width: 1px 1px medium;
                }

                .outlet .outlet-left .storelist {
                    height: 551px;
                    overflow-y: auto;
                }

            .outlet .outlet-right {
                padding-left: 414px;
                height: 100%;
            }


            .outlet .outlet-left .outlet-filter table {
                border-collapse: collapse;
                border-spacing: 0;
                width: 100%;
            }

            .outlet .outlet-left .outlet-filter th {
                border-bottom: 1px solid #ededed;
                color: #333;
                font-weight: 700;
                height: 53px;
                text-align: center;
                width: 32%;
            }

                .outlet .outlet-left .outlet-filter th em {
                    color: #ededed;
                    float: right;
                    margin-top: 8px;
                }

                .outlet .outlet-left .outlet-filter th h1, h2, h3, h4, h5, h6, strong, em, b {
                    font-size: 100%;
                    font-style: normal;
                    font-weight: bold;
                    vertical-align: middle;
                }

                .outlet .outlet-left .outlet-filter th h4 img {
                    margin-right: 4px;
                }

            .outlet .outlet-left .outlet-filter td {
                border-bottom: 1px solid #ededed;
                padding: 10px 5px;
                width: 68%;
            }

                .outlet .outlet-left .outlet-filter td span {
                    border: 1px solid #fff;
                    cursor: pointer;
                    display: inline-block;
                    margin-bottom: 2px;
                    margin-left: 5px;
                    margin-top: 2px;
                    padding: 3px 11px;
                    position: relative;
                }

                .outlet .outlet-left .outlet-filter td .list_tips {
                    background: rgba(0, 0, 0, 0) url("../images/current_31.png") no-repeat scroll 0 0;
                    display: none;
                    height: 16px;
                    position: absolute;
                    right: 0;
                    top: 0;
                    width: 15px;
                }

            .outlet .cond-bar {
                background: #efefef none repeat scroll 0 0;
                color: #333;
                font-size: 14px;
                padding: 7px 20px;
            }

        .areaSelect {
            left: 4px;
            position: relative;
            top: 1px;
        }

        li, ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
        }

        .areaSelect > li {
            display: inline-block;
            float: left;
            position: relative;
        }

        .areaSelect .selectItem {
            cursor: pointer;
        }

        .areaSelect .selectItem {
            /*-moz-border-bottom-colors: none;
    -moz-border-left-colors: none;
    -moz-border-right-colors: none;
    -moz-border-top-colors: none;*/
            background: #fff none repeat scroll 0 0;
            border-color: #cecbce #cecbce #cecbce;
            border-image: none;
            border-style: solid none solid solid;
            border-width: 1px 0 1px 1px;
            display: inline-block;
            font-size: 12px;
            height: 30px;
            line-height: 30px;
            margin-top: 1px;
            overflow: hidden;
            position: relative;
            text-align: center;
            width: 118px;
            z-index: 99;
        }

        .oyt-position {
            border: 1px solid #efefef;
            padding: 7px 20px;
        }

            .oyt-position .row {
                padding-left: 2px;
            }

        .outlet .outlet-left .storelist {
            height: 551px;
            overflow-y: auto;
        }

        .outlet .storelist li {
            padding: 8px 0 8px 10px;
        }

        .install-method-left .storelist li, .outlet .storelist li {
            /*-moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;*/
            border-color: #ededed #ededed;
            border-image: none;
            border-style: solid solid none none;
            border-width: 1px 1px 0 0;
            padding: 8px 20px;
            position: relative;
        }

        .outlet .storelist li {
            cursor: pointer;
        }

            .outlet .storelist li img {
                height: 70px;
                margin-top: 8px;
                width: 100px;
            }

            .install-method-left .storelist li img, .outlet .storelist li img {
                float: left;
            }

        img {
            border: 0 none;
            image-rendering: optimizequality;
            vertical-align: middle;
        }

        .outlet .store-info {
            padding-left: 110px;
        }

        .install-method-left .store-info, .outlet .store-info {
            line-height: 1.8em;
            padding-left: 110px;
            width: 242px;
        }

            .outlet .store-info .name {
                font-size: 12px;
                height: 25px;
                overflow: hidden;
                text-overflow: ellipsis;
            }

            .install-method-left .store-info .name, .outlet .store-info .name {
                color: #333;
                font-size: 16px;
                font-weight: 700;
            }


                .outlet .store-info .name a {
                    font-size: 12px;
                    color: #666666;
                    text-decoration: none;
                }

            .outlet .store-info .sco {
                padding: 0;
            }

            .install-method-left .store-info .sco, .outlet .store-info .sco {
                color: #ff9900;
                padding: 5px 0;
            }

                .install-method-left .store-info .sco span, .map-sw span, .outlet .store-info .sco span {
                    margin-right: 10px;
                    vertical-align: -2px;
                }

        .stroe-score10 {
            background: rgba(0, 0, 0, 0) url("/Shop/ShopAdmin/images/storestar_32.png") repeat scroll 0 0;
            display: inline-block;
            height: 15px;
            width: 95px;
        }

        .outlet .store-info .adrs {
            height: 20px;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .install-method-left .store-info .adrs, .install-method-left .store-info .tel, .outlet .store-info .adrs, .outlet .store-info .tel {
            color: #666;
            font-size: 12px;
        }

        .install-method-left .store-info .adrs, .install-method-left .store-info .tel, .outlet .store-info .adrs, .outlet .store-info .tel {
            color: #666;
            font-size: 12px;
        }

        #l-map {
            height: 80%;
            text-align: center;
            width: 100%
        }
    </style>
    <title>°Ù¶ÈµØÍ¼</title>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=Ysv2U4rRH9zYrFltfyl73WbB"></script>

</head>
<body>
    <form runat="server">
        <!--head Start-->
        <!-- #include file="AgentHead.aspx" -->
        <!--//head End-->
    
        <div id="content">
            <!-- #include file="head.aspx" -->
            <div class="warp" style="width: 100%">
                <ShopNum1ShopNew:BaiDuMap ID="BaiDuMap" runat="server" SkinFilename="BaiDuMap.ascx" />
            </div>   
        </div> 
        
        <div class="clearfix">
            <ShopNum1ShopNew:FootNew ID="Foot" runat="server" SkinFilename="FootNew.ascx" />
        </div>
        
    </form>
</body>
</html>
