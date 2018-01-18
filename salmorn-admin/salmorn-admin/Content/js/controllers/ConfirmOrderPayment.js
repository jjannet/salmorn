
angular.module('shop-manage')
    .controller('ConfirmOrderPaymentController', ['$scope', '$http', function ($scope, $http) {
        $scope.products = [];
        $scope.orders = [];

        $scope.backUrl = '';

        $scope.initialScreen = function (backUrl) {
            $scope.backUrl = backUrl;
            services.getOrders();
        };

        $scope.confirmOrder = function (order) {
            if (confirm('คุณต้องการ ยืนยันการจ่ายเงินของ order ' +  order.code + ' ใช่หรือไม่')) {
                services.confirmOrder(order);
            }
        }

        $scope.cancelOrder = function (order) {
            if (confirm('คุณต้องการ ยกเลิก order ' + order.code + ' ใช่หรือไม่')) {
                services.cancelOrder(order);
            }
        }

        $scope.back = function () {
            services.clearOrderStorage();
            window.location = $scope.backUrl;
        }

        var services = {
            getOrders: function () {
                $scope.orders = angular.copy(JSON.parse(localStorage.getItem('orders-storage-salmorn')));
                if ($scope.orders == null) {
                    window.location = '../Order';
                }

                for (var i = 0; i < $scope.orders.length; i++) {
                    $scope.orders[i].payment.paymentDate = convertCTOJSDate($scope.orders[i].payment.paymentDate);
                }
            },
            confirmOrder: function (data) {
                loading(true);

                $http.post('/Order/confirmOrder', data).then(function (result) {
                    if (result.data) {
                        var index = $scope.orders.indexOf(data);
                        if (index !== -1) {
                            $scope.orders.splice(index, 1);
                            services.setOrdersStorage($scope.orders);
                        }
                        alertSuccess('Confirm payment result', 'Success !');

                    } else {
                        alertError('Confirm payment result', 'Fail !');
                    }
                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
                });
            },
            cancelOrder: function (data) {
                loading(true);

                data.isActive = false;

                $http.post('/Order/updateOrderActive', data).then(function (result) {
                    if (result.data) {
                        var index = $scope.orders.indexOf(data);
                        if (index !== -1) {
                            $scope.orders.splice(index, 1);
                            services.setOrdersStorage($scope.orders);
                        }
                        alertSuccess('Confirm payment result', 'Success !');
                    } else {
                        alertError('Confirm payment result', 'Fail !');
                    }
                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
                });
            },

            setOrdersStorage: function (items) {
                var s = JSON.stringify(items);
                localStorage.setItem('orders-storage-salmorn', s);
            },
            clearOrderStorage: function () {
                localStorage.setItem('orders-storage-salmorn', null);
            }
        };

        $scope.initImagePopup = function () {
            initImagePopup();
        }

        // #region  Test

        var initialTestDatas = function () {
            $scope.orders = [
                {
                    select: true, code: '201712100001', orderDate: null, payDate: null, isPay: false, isShipping: false, unitPrice: 150, qty: 10, totalPrice: 1500,
                    product: {
                        code: 'SALMORN1700001', price: 150, name: 'สายรัดข้อมือ'
                    },
                    payment: {
                        file: { fileName: 'https://storage.googleapis.com/salmorn-dev-storage/A4VECASBZLXQMTPB6X5IUZDEKMWNUD.jpg' }
                        , paymentDate: new Date(), money: 1000
                    }
                },
                {
                    select: false, code: '201712100002', orderDate: null, payDate: new Date(), isPay: true, isShipping: false, unitPrice: 150, qty: 20, totalPrice: 3000,
                    product: {
                        code: 'SALMORN1700001', price: 150, name: 'สายรัดข้อมือ'
                    },
                    payment: {
                        file: { fileName: 'https://storage.googleapis.com/salmorn-dev-storage/A4VECASBZLXQMTPB6X5IUZDEKMWNUD.jpg' }
                        , paymentDate: new Date(), money: 1000
                    }
                }
            ];
        }

        // #endregion

    }]);


var initImagePopup = function () {
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