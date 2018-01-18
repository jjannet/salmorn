
angular.module('shop-manage')
    .controller('OrdersController', ['$scope', '$http', '$timeout', function ($scope, $http, $timeout) {
        $scope.greeting = 'Hola!';
        $scope.products = [];
        $scope.orderCode = '';
        $scope.productId = '-1';
        $scope.selectAll = false;
        $scope.showOnlyPaymentSending = false;
        var filterTextTimeout = false;
        $scope.orders = [];

        $scope.initialScreen = function () {
            services.getProductsOfNotPayOrder();
            services.clearOrderStorage();
        };

        var getSelectItems = function () {
            return $scope.orders.filter((o) => { return o.select });
        }

        $scope.isCanStartConfirmOrder = function () {
            var isEnable = true;
            var datas = getSelectItems();
            if (datas.length > 0) {
                for (var i = 0; i < datas.length; i++) {
                    if (datas[i].payment == null) {
                        isEnable = false;
                        break;
                    }
                }
                return isEnable;
            } else {
                return false;
            }
        }

        $scope.isCanUpdatePay = function () {
            var datas = getSelectItems();
            if (datas && datas.length > 0)
                return !(datas.filter((o) => { return o.isPay }).length > 0);
            else return false;
        }

        $scope.isCanCancelOrder = function () {
            return $scope.orders.filter((o) => { return o.select }).length > 0;
        }

        $scope.getRowActiveClass = function (selected) {
            if (selected) return 'active';
            else return '';
        }

        $scope.selectChange = function () {
            var selectAll = true;
            for (var i = 0; i < $scope.orders.length; i++) {
                if (!$scope.orders[i].select) {
                    selectAll = false;
                    break;
                }
            }
            $scope.selectAll = selectAll;
        }

        $scope.selectAllChange = function () {
            for (var i = 0; i < $scope.orders.length; i++) {
                $scope.orders[i].select = $scope.selectAll;
            }
        }

        $scope.searchOrders = function (useDelay) {
            if (useDelay) {
                if (filterTextTimeout) $timeout.cancel(filterTextTimeout);

                filterTextTimeout = $timeout(function () {
                    services.searchOrder();
                }, 250); // delay 250 ms
            } else {
                services.searchOrder();
            }
        }

        $scope.cancelOrder = function () {
            if (confirm('คุณต้องการ Cancel order ที่เลือก ใช่หรือไม่ ?')) {
                var datas = getSelectItems();
                services.cancelOrder(datas);
            }
        }

        $scope.startConfirmOrder = function () {
            var items = getSelectItems();
            services.setOrdersStorage(items);
            window.location = '/Order/ConfirmOrderPayment';
        }

        var services = {

            searchOrder: function () {
                var data = {
                    orderCode: $scope.orderCode,
                    productId: parseInt($scope.productId),
                    showOnlyPaymentSending: $scope.showOnlyPaymentSending
                };
                services.getOrders(data);
            },
            getOrders: function (data) {
                loading(true);
                $http.post('/Order/getNotPayOrders', data).then(function (resp) {

                    $scope.orders = resp.data;

                    for (var i = 0; i < $scope.orders.length; i++) {
                        $scope.orders[i].orderDate = convertCTOJSDate($scope.orders[i].orderDate);
                    }

                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
                });
            },
            getProductsOfNotPayOrder: function () {
                $http.post('/Order/getProductsOfNotPayOrder').then(function (resp) {

                    $scope.products = resp.data;
                    services.searchOrder();

                }, function (err) {
                    console.error(err);
                });
            },
            cancelOrder: function (datas) {
                loading(true);

                for (var i = 0; i < datas.length; i++) {
                    datas[i].isActive = false;
                }

                $http.post('/Order/updateOrderActive', datas).then(function (resp) {

                    if (resp.data) {
                        services.searchOrder();
                        alertSuccess('Cancel order result.', 'Success !');
                    } else {
                        alertError('Cancel order result.', 'Error!');
                    }

                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
                });
            },

            setOrdersStorage: function (items) {
                var s = JSON.stringify(items);
                console.log(s);
                localStorage.setItem('orders-storage-salmorn', s);
            },
            clearOrderStorage: function () {
                localStorage.setItem('orders-storage-salmorn', null);
            }

        };

    }]);
