
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

            $http.post('/api/Order/OrderSeat', $scope.orderForm.order)
                .then(
                function (res) {
                    console.log(res);
                },
                function (err) {
                    console.log(err);
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