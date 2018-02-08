
var fileControlId = '#file-control';
var fileControlDialogId = '#file-control-dialog';
var fileControlGetUrlId = '#file-control-get-url';
var fileControlImageListBoxId = '#file-control-image-list';


var FileControl = {
    uploads: [],
    categories: [],
    files: [],
    selectedFile: [],
    oldFiles: [],
    callBackFN: null,
}

var uploader = new Dropzone(fileControlId, {
    success: function (file, response) {
        console.log('uploader', response);
        if (response) {
            console.log('upload response!', response);
            if (response.type == 0) {
                FileControl.uploads.push(response.result);
            } else {
                alertError('Upload file result', response.message);
                this.removeFile(file);
            }
        } else {
            alertError('Upload file result', 'Upload รูปภาพล้มเหลว');
            this.removeFile(file);
        }
    }
});


var initial = function () {
    FileControl = {
        uploads: [],
        categories: [],
        files: [],
        selectedFile: [],
        oldFiles: [],
        callBackFN: null,
    }

    uploader.removeAllFiles();
    //loadFiles();
}


var openFileControlDialog = function (callBackFN) {
    initial();
    FileControl.callBackFN = callBackFN;
    $(fileControlDialogId).modal('show');
}


var fileControlSubmitImage = function () {
    FileControl.callBackFN(FileControl.uploads);

    $(fileControlDialogId).modal('hide');
}

