

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




// #endregion



var getFilesUplaod = function () {

    var fs = Dropzone.forElement("#file-control").files;
    console.log(fs);

}


// #endregion

