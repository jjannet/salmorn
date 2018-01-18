
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
    getUrl: ''
}

var uploader = new Dropzone(fileControlId, {
    success: function (file, response) {
        console.log(response);
        if (response) {
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
        getUrl: ''
    }

    FileControl.getUrl = $(fileControlGetUrlId).val();
    uploader.removeAllFiles();
    //loadFiles();
}


var openFileControlDialog = function (callBackFN, oldFiles) {
    initial();
    FileControl.callBackFN = callBackFN;
    FileControl.oldFiles = oldFiles;
    $(fileControlDialogId).modal('show'); 
}



var loadFiles = function () {
    JHttp.Post(FileControl.getUrl, null, function (result) {
        if (result && result.result) {
            FileControl.files = result.result;
            initialImageList()
        }
    }, null, 'all-images');
}

var initialImageList = function () {

    $(fileControlImageListBoxId).html('');
    var html = '';

    if (FileControl.files && FileControl.files.length > 0) {
        for (var i = 0; i < FileControl.files.length; i++) {
            html += getImageItem(FileControl.files[i]);
        }
        $(fileControlImageListBoxId).html(html);
        $('.image-link').magnificPopup({
            type: 'image',
            mainClass: 'mfp-with-zoom', // this class is for CSS animation below

            zoom: {
                enabled: true, // By default it's false, so don't forget to enable it

                duration: 300, // duration of the effect, in milliseconds
                easing: 'ease-in-out', // CSS transition easing function
                opener: function (openerElement) {
                    return openerElement.is('img') ? openerElement : openerElement.find('img');
                }
            }

        });
    }
}

var fileControlSelected = function (e) {
    if ($(e).attr('data-selected') == '0') {
        $(e).addClass('selected');
        $(e).attr('data-selected', '1');
        FileControl.selectedFile.push(FileControl.files.find(m => m.id == $(e).attr('data-id')));
    } else {
        $(e).removeClass('selected');
        $(e).attr('data-selected', '0');

        let fs = [];

        for (var i = 0; i < FileControl.selectedFile.length; i++) {
            if (FileControl.selectedFile[i].id != $(e).attr('data-id')) {
                fs.push(FileControl.selectedFile[i]);
            }
        }

        FileControl.selectedFile = fs;
    }
}

var getImageItem = function (file) {
    let select = '';
    let isSelect = '0';

    if (FileControl.oldFiles.find(m => m.id == file.id)) {
        select = 'selected';
        isSelect = '1';
    }

    return `
        
        <div class="image-box ` + select + `" data-selected="` + isSelect + `" data-id="` + file.id + `" onclick="fileControlSelected(this)">
                <img src="` + file.fileName + `" />
                <i class="mdi mdi-bookmark-check"></i>
        </div>
        
    `;
}

var fileControlSubmitImage = function () {
    if ($('#upload').hasClass('active')) {
        FileControl.callBackFN(FileControl.uploads);
    } else {
        FileControl.callBackFN(FileControl.selectedFile);
    }

    $(fileControlDialogId).modal('hide'); 
}