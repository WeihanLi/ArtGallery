<%@ Page Title="内容管理" Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ContentManage.aspx.cs" Inherits="WebApplication1.Admin.ContentManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="/Scripts/NewsManage.js"></script>
    <script src="/swfupload/swfupload.js"></script>
    <script src="/swfupload/js/handlers.js"></script>
    <script type="text/javascript">
        //注：div的id名称最好不要改，要改的话在handlers.js文件中也要进行修改，div的名称已经在handlers.js文件中写死
        var swfu;
        window.onload = function () {
            swfu = new SWFUpload({
                // 后台设置，设置处理上传的页面
                upload_url: "/Admin/UploadFileHandler.ashx",
                // 文件上传大小限制设置
                file_size_limit: "30 MB",
                //文件类型设置，多种格式以英文中的分号分开
                file_types: "*.jpg;*.png",
                //文件描述，与弹出的选择文件对话框相关
                file_types_description : "Images file",
                //设置上传文件数量限制
                file_upload_limit: "1",

                //事件处理程序，最好不要改，事件处理程序已在handlers.js文件中定义
                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                file_queue_error_handler : fileQueueError,
                file_dialog_complete_handler : fileDialogComplete,
                upload_progress_handler : uploadProgress,
                upload_error_handler : uploadError,
                upload_success_handler : uploadSuccess,
                upload_complete_handler : uploadComplete,

                // 上传按钮设置
                button_image_url : "/swfupload/images/XPButtonNoText_160x22.png",
                button_placeholder_id: "spanButtonPlaceholder",
                button_width: 160,
                button_height: 22,
                button_text : '上传图片 (最大30M)',
                button_text_style : '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,

                // swfupload.swf flash设置
                flash_url : "/swfupload/swfupload.swf",    
                //自定义的其他设置
                custom_settings : {
                    upload_target: "divFileProgressContainer"
                },
                // 是否开启调试模式，调试时可以设置为true，发布时设置为false
                debug: false
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content_hea">
        <div id="content_hea_o">
            内容管理 / 作品管理 
        </div>
        </div>
    <div id="addcontent">
            <div id="addcontent_hea">添加作品</div>
            <table id="addcolumn_tab">
                <tr>
                    <td class="addcolumn_left">作品名称</td>
                    <td class="addcolumn_right">
                            <input type="text" id="txtItemName" />
                    </td>
                </tr>
                <tr>
                    <td class="addcolumn_left">作品作者</td>
                    <td class="addcolumn_right">
                            <input type="text" id="txtItemAuthor" />
                    </td>
                </tr>
                <tr>
                    <td class="addcolumn_left">作家简介</td>
                    <td class="addcolumn_right">
                            <textarea id="txtItemDesc"  style="width:262px;height:100px;"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="addcolumn_left">作品类别</td>
                    <td class="addcolumn_right">
                            <select name="selectNewsType" id="selectNewsType">
                            </select>
                    </td>
                </tr>
                <tr>
                    <td class="addcolumn_left">
                        <div id="swfu_container" style="margin: 0px 10px;">
                            <div>
                                <span id="spanButtonPlaceholder"></span>
                            </div>
                            <div id="divFileProgressContainer" style="height: 75px;"></div>
                        </div>
                    </td>
                    <td class="addcolumn_right"><input id="imgPath" type="text" /></td>
                </tr>
            </table>
            <div class="addcolumn_button">
                <div class="addcolumn_but"><a href="javascript:void(0)" onclick="AddANews()"><img src="/images/cms_add.jpg" /></a></div>
                <div class="addcolumn_but"><a href="default.aspx"><img src="/images/cms_cancel.jpg" /></a></div>
            </div>
        </div>
    <script type="text/javascript">
        InitNewsType();
        //添加一个新闻
        function AddANews() {
            var name = $("#txtItemName").val();
            var desc = $("#txtItemDesc").val();
            var type = $("#selectNewsType").val();
            var imgPath = $("#imgPath").val();
            var author = $("#txtItemAuthor").val();
            if (author==null||author==""||name==""||name==null||type==null||type==""||imgPath==""||imgPath==null) {
                return;
            }
            //alert(name + desc+author + type + imgPath);
            AddNews(name,author,desc,imgPath,type);
        }
    </script>
</asp:Content>
