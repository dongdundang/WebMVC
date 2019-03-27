function ajaxGet(url, param) {
    return $.ajax({
        url: url,
        beforeSend: showLoader,
        complete: hideLoader,
        type: "GET",
        data: param,
        dataType: "json",
        contentType: "application/json; charset=utf-8"
    })
}

function ajaxPOST(url, data) {
    return $.ajax({
        url: url,
        beforeSend: showLoader,
        complete: hideLoader,
        type: "POST",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json; charset=utf-8"
    })
}

function ajaxPostWithFile(url, formData) {
    return $.ajax({
        url: url,
        beforeSend: showLoader,
        complete: hideLoader,
        type: "post",
        data: formData,
        cache: false,
        contentType: false,
        processData: false
    });
}

function isNullOrEmpty(value) {
    if (value == "" || value == null || value == undefined || value == "undefined" || value.length === 0)
        return true;
    return false;
}

function notify(message, type) {
    new Noty({
        type: type, /*alert, success, warning, error, info/information*/
        text: message,
        timeout: 2000,
        progressBar: true,
        layout: 'topRight',
        animation: {
            open: 'animated bounceInRight',
            close: 'animated bounceOutRight'
        }
    }).show();
}

function showLoader() {
    document.getElementById("Loader").style.display = "block";
}

function hideLoader() {
    document.getElementById("Loader").style.display = "none";
}