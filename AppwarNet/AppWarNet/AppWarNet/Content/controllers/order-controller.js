
var app = angular.module('appwar', []);
app.controller('OrderController', function ($scope, $http) {
    $scope.isRead = false;

    $scope.order = {
        orderNo: '',
        firstName: '',
        lastName: '',
        tel: '',
        email: '',
        numTicket: 1,
        identNo: '',
        createDate: null,
        isSendPaySlip: false,
        sendPaySlipDate: null,
        isApprovePayment: false,
        approvePaymentDate: null,
        approvePaymentBy: ''
    }

    $scope.init = function () {
        initDefaultValue();
    }

    $scope.submit = function (e) {
        if ($scope.orderForm.$valid == true) {


            jQuery(".loader").fadeIn(800);

            $http({
                url: '/api/Order/OrderSeat',
                dataType: 'json',
                method: 'POST',
                data: $scope.order,
                headers: {
                    "Content-Type": "application/json"
                }

            })
                .then(function (response) {
                    console.log(response);
                    if (response.data.IsValid === true) {
                        $('#ResultOrderNo').html(response.data.Result.orderNo);
                        $('#resultOrderModal').modal('show');
                        initDefaultValue();
                    } else {
                        alert(response.data.IsValid.ErrorMessage);
                    }

                    jQuery(".loader").fadeOut(800);
                },
                    function (error) {
                        console.log(error);

                        jQuery(".loader").fadeOut(800);
                    });

            var res = {
                ErrorMessage: '',
                IsValid: true,
                Result: angular.copy($scope.order)
            }
            res.Result.orderNo = '201806290456158';

            if (res.IsValid === true) {

                order = angular.copy(res.Result);

            }

        }
    }

    var initDefaultValue = function () {
        $scope.order = {
            orderNo: '',
            firstName: '',
            lastName: '',
            tel: '',
            email: '',
            numTicket: 1,
            identNo: '',
            createDate: null,
            isSendPaySlip: false,
            sendPaySlipDate: null,
            isApprovePayment: false,
            approvePaymentDate: null,
            approvePaymentBy: ''
        }
    }

});