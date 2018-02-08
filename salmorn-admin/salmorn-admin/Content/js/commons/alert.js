

// #region  Alert message

var alertSuccess = function (title, message) {
    $.Notification.autoHideNotify('success', 'top right', title, message)
}

var alertInfo = function (title, message) {
    $.Notification.autoHideNotify('info', 'top right', title, message)
}

var alertWarning = function (title, message) {
    $.Notification.autoHideNotify('warning', 'top right', title, message)
}

var alertError = function (title, message) {
    $.Notification.autoHideNotify('error', 'top right', title, message)
}



//#region    Hide/Show loading screen
var loading = function (visible) {
    if (visible) {
        $('.loading-box').css('display', 'block');
    } else {
        $('.loading-box').css('display', 'none');
    }
}