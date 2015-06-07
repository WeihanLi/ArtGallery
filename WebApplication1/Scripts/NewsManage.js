//通过ajax动态加载newsType列表，默认选中第一个
function InitNewsType() {
    $.post("SelectNewsTypeHandler.ashx", function (data) {
        if (data!="Fail") 
        {
            //alert(data);
            //alert(Array.isArray(eval(data)));
            //必须要eval，不然无法直接解析返回的json数据，不知道为什么。。。。。
            var types = eval(data);
            var select = document.getElementById("selectNewsType").innerHTML;
            //动态添加 下拉列表 数据        
            for (var i = 0; i < types.length; i++) {
                var html = '';
                if (i == 0) {
                    html = "<option value='" + types[i].CategoryId + "' selected='selected'>" + types[i].CategoryName + "</option>";
                }
                else{
                    html = "<option value='" + types[i].CategoryId + "'>" + types[i].CategoryName + "</option>";
                }
                select += html;
            }
            //设置下拉列表的 innerHTML
            $("#selectNewsType").html(select);
        }
    });
}
//通过ajax动态加载newsType列表，选中 type 项
function InitNewsTypeByType(type) {
    $.post("SelectNewsTypeHandler.ashx", function (data) {
        if (data != "Fail") {
            //alert(data);
            //alert(Array.isArray(eval(data)));
            //必须要eval，不然无法直接解析返回的json数据，不知道为什么。。。。。
            var types = eval(data);
            var select = document.getElementById("selectNewsType").innerHTML;
            //动态添加 下拉列表 数据        
            for (var i = 0; i < types.length; i++) {
                var html = '';
                if (types[i].CategoryId == type) {
                    html = "<option value='" + types[i].CategoryId + "' selected='selected'>" + types[i].CategoryName + "</option>";
                }
                else {
                    html = "<option value='" + types[i].CategoryId + "'>" + types[i].CategoryName + "</option>";
                }
                select += html;
            }
            //设置下拉列表的 innerHTML
            $("#selectNewsType").html(select);
        }
    });
}
//添加新闻
function AddNews(itemName,itemAuthor,itemDesc,itemImagePath,type) {
    $.post("AddNewsHandler.ashx", { "name": itemName, "desc": itemDesc, "type": type, "author":itemAuthor,"imagePath": itemImagePath}, function (data) {
        if (data == "true") {
            window.location.href = 'Default.aspx';
        }
        else {
            alert("发生异常，添加失败！");
        }
    });
}
//更新新闻
function UpdateNews(itemId, itemName, itemDesc, author, type, imagePath) {
    
    $.post("UpdateNewsHandler.ashx", { "id":itemId,"name": itemName, "desc": itemDesc, "type": type,"imagePath":imagePath,"author":author }, function (data) {
        if (data == "true") {
            window.location.href = 'Default.aspx';
        }
        else {
            alert("发生异常，更新失败！");
        }
    });
}
//初始化新闻内容
function InitNewsContent(newsId)
{
    if (newsId==null) {
        return;
    }
    $.post("SelectNewsByIdHandler.ashx", { "id": newsId }, function (data) {
        if (data != "error") {
            //alert(data);
            var item = JSON.parse(data);
            //alert(news);
            //Todo:修改前台 id
            $("#txtItemName").val(item.ItemName);
            $("#txtItemDesc").val(item.ItemDesc);
            $("#txtItemAuthor").val(item.ItemAuthor);
            //绑定类别
            InitNewsTypeByType(item.ItemTypeId);
            if (item.ItemImagePath!=null) {
                $("#imgPath").val(item.ItemImagePath);
            }
        }
        else {
            alert("发生异常，添加失败！");
        }
    });
}