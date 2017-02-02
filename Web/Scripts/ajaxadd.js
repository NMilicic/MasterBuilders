$(function () {
    $(".wishlist-add").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'POST',
            url: '/Wishlist/AddAjax',
            data: { setId: $(this).attr("value") },
            dataType: 'json',
            cache: false,
            timeout: 7000,
            success: function (data) {
                location.reload();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    });
    $(".wishlist-remove").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'POST',
            url: '/Wishlist/RemoveAjax',
            data: { setId: $(this).attr("value") },
            dataType: 'json',
            cache: false,
            timeout: 7000,
            success: function (data) {
                location.reload();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    });
    $(".inventory-add").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'POST',
            url: '/Inventory/AddAjax',
            data: { setId: $(this).attr("value") },
            dataType: 'json',
            cache: false,
            timeout: 7000,
            success: function (data) {
                location.reload();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(message);
            }
        });
    });
    $(".inventory-remove").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'POST',
            url: '/Inventory/RemoveAjax',
            data: { setId: $(this).attr("value") },
            dataType: 'json',
            cache: false,
            timeout: 7000,
            success: function (data) {
                location.reload();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(message);
            }
        });
    });
    $(".built-add").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'POST',
            url: '/Inventory/BuiltAddAjax',
            data: { setId: $(this).attr("value") },
            dataType: 'json',
            cache: false,
            timeout: 7000,
            success: function (data) {
                location.reload();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(message);
            }
        });
    });
    $(".built-remove").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'POST',
            url: '/Inventory/BuiltRemoveAjax',
            data: { setId: $(this).attr("value") },
            dataType: 'json',
            cache: false,
            timeout: 7000,
            success: function (data) {
                location.reload();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(message);
            }
        });
    });
});