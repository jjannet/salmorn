
var app = angular.module('appwar');
app.controller('ConfirmPaymentController', function ($scope, $http) {
    $scope.isRead = false;

    $scope.data = {
        orderNo: '',
        fileName: ''
    }

    $scope.init = function () {
        initDefaultValue();
    }

    $scope.submit = function (e) {

        if (!$('#slipImage').attr('src')) {
            alert('กรุณา upload slip');
        }
        if ($scope.confirmPaymentForm.$valid == true && $('#slipImage').attr('src')) {
            $scope.data.fileName = $('#slipImage').attr('src').replace('../Draft/', '');
            jQuery(".loader").fadeIn(800);

            $http({
                url: '/api/Order/ConfirmPayment',
                dataType: 'json',
                method: 'POST',
                data: $scope.data,
                headers: {
                    "Content-Type": "application/json"
                }

            })
                .then(function (response) {
                    console.log(response);
                    if (response.data.IsValid === true) {
                        $('#confirmPaymentModal').modal('show');
                        initDefaultValue();
                    } else {
                        alert(response.data.ErrorMessage);
                    }

                    jQuery(".loader").fadeOut(800);
                },
                    function (error) {
                        console.log(error);

                        jQuery(".loader").fadeOut(800);
                    });
        }
    }

    var initDefaultValue = function () {
        $scope.data = {
            orderNo: '',
            fileName: ''
        }

        $("#FileSlipUpload").val("");
        $('#slipImage').attr('src', '');
        $('#slipImageBox').hide();
    }

});


function uploadSlip() {
    var formData = new FormData();
    var totalFiles = document.getElementById("FileSlipUpload").files.length;
    console.log('total file', totalFiles);
    console.log('files', document.getElementById("FileSlipUpload").files);
    for (var i = 0; i < totalFiles; i++) {
        var file = document.getElementById("FileSlipUpload").files[i];

        formData.append("FileSlipUpload", file);
    }
    $.ajax({
        type: "POST",
        url: '/Home/uploadSlip',
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (response) {
        },
        error: function (error) {
            if (error.responseText && error.responseText != '') {
                $('#slipImage').attr('src', '../Draft/' + error.responseText);
                $('#slipImageBox').show();
            } else {
                alert('Upload error !')
            }
        }
    });
}