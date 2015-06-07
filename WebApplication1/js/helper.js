function Up() {
    $.post("/Handlers/GetItemHandler.ashx", { "id": curId, "action": "up" }, function (data) {
        if (data != "error") {
            if (data == null || data == "") {
                alert('已是第一个');
                return;
            } else {
                window.location.href = data;
            }
        } else {
            alert('已是第一个');
        }
    });
}
function Next() {
    $.post("/Handlers/GetItemHandler.ashx", { "id": curId, "action": "next" }, function (data) {
        if (data != "error") {
            if (data == null || data == "") {
                alert('已是最后一个');
                return;
            } else {
                window.location.href = data;
            }
        } else {
            alert('已是最后一个');
        }
    });
}

function AddFav() {
    $.post("/Handlers/AddFavHandler.ashx", { "id": curId }, function (data) {
        if (data == "error") {
            alert('发生错误，点赞失败！');
        } else {
            //Todo:点赞成功后操作
            alert('点赞成功');
        }
    });
}

function Init() {
    $.post("/Handlers/GetItemsHandler.ashx", { "id": curId }, function (data) {
        //alert(data);
        if (data != "error") {
            var items = JSON.parse(data);
            var imgs = '';
            for (var i = 0; i < items.length; i++) {
                imgs += '<div class="playBox"><div class="playBoxTop"><a href=' + items[i].ItemPath + '><img src="" alt="" class="imgBlock"><img src="/Upload/small/' + items[i].ItemImagePath + '" alt=""  height="auto"></a></div>\
				            <p>'+ items[i].ItemName + '<br/><span>' + items[i].ItemId + '</span></p></div>';
            }
            $("#imgPlay").html(imgs);
            //alert('success');
        }
        else {
            alert('加载图片失败');
        }
    });
}