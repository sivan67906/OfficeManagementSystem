$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');

    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data, status) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.parents('.modal').modal('show');
            //PlaceHolderElement.find('#mdlBusinessLocationShow').modal({ backdrop: 'static', keyboard: false });
            //PlaceHolderElement.find('.modal-backdrop').remove();
        })
    });

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionName = form.attr('action');
        var currentUrl = window.location.href;
        currentUrl = currentUrl.substring(0, currentUrl.lastIndexOf("/") + 1);
        var url = currentUrl + actionName;
        var sendData = form.serialize();
        $.post(url, sendData).done(function (data, status) {
            PlaceHolderElement.find('.modal').modal('hide');
            location.reload();
        })
    });
});