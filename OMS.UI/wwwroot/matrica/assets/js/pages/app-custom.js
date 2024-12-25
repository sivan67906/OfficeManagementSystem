$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    var PlaceHolderElement1 = $('#PlaceHolderHere1');

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        $("#divBlocker").removeClass("d-none").addClass("screenblocker");
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data, status) {
            PlaceHolderElement.html(data);
            $("#divBlocker").addClass("d-none").removeClass("screenblocker");
            PlaceHolderElement.parents('.modal').modal('show');
        })
    });

    $('button[data-toggle="ajax-modal1"]').click(function (event) {
        $("#divBlocker").removeClass("d-none").addClass("screenblocker");
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data, status) {
            PlaceHolderElement1.html(data);
            $("#divBlocker").addClass("d-none").removeClass("screenblocker");
            PlaceHolderElement1.parents('.modal').modal('show');
        })
    });

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        $("#divBlocker").removeClass("d-none").addClass("screenblocker");
        var form = $(this).parents('.modal').find('form');
        $('#PlaceHolderHere').find('input').attr('readonly', 'readonly');
        $('#PlaceHolderHere').find('button').attr('disabled', true);
        //$('#PlaceHolderHere option:not(:selected)').attr('disabled', true);
        $('option:not(:selected)').prop('disabled', true);

        var actionName = form.attr('action');
        var currentUrl = window.location.href;
        currentUrl = currentUrl.substring(0, currentUrl.lastIndexOf("/") + 1);
        var url = currentUrl + actionName;
        var sendData = form.serialize();
        $.post(url, sendData).done(function (data, status) {
            $("#divBlocker").addClass("d-none").removeClass("screenblocker");
            PlaceHolderElement.find('.modal').modal('hide');
            location.reload();
        })
    });

    PlaceHolderElement1.on('click', '[data-save="modal"]', function (event) {
        $("#divBlocker").removeClass("d-none").addClass("screenblocker");
        var form = $(this).parents('.modal').find('form');
        $('#PlaceHolderHere').find('input').attr('readonly', 'readonly');
        $('#PlaceHolderHere').find('button').attr('disabled', true);
        //$('#PlaceHolderHere option:not(:selected)').attr('disabled', true);
        $('option:not(:selected)').prop('disabled', true);

        var actionName = form.attr('action');
        var currentUrl = window.location.href;
        currentUrl = currentUrl.substring(0, currentUrl.lastIndexOf("/") + 1);
        var url = currentUrl + actionName;
        var sendData = form.serialize();
        $.post(url, sendData).done(function (data, status) {
            $("#divBlocker").addClass("d-none").removeClass("screenblocker");
            PlaceHolderElement1.find('.modal').modal('hide');
            location.reload();
        })
    });
});

