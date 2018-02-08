
angular.module('shop-manage')
    .controller('CloseOrderController', ['$scope', '$http', '$timeout', function ($scope, $http, $timeout) {
        $scope.products = [];
        $scope.orderCode = '';
        $scope.selectAll = false;
        $scope.productId = '-1';
        var filterTextTimeout = false;
        $scope.orders = [];

        $scope.initialScreen = function () {
            services.getProductsOfNotPayOrder();
        };

        var getSelectItems = function () {
            return $scope.orders.filter((o) => { return o.select });
        }
        $scope.isCanCancelOrder = function () {
            return $scope.orders.filter((o) => { return o.select }).length > 0;
        }
        $scope.isCanFinishOrder = function () {
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

        $scope.finishOrder = function () {
            if (confirm('คุณต้องการ Finish order ที่เลือก ใช่หรือไม่ ?')) {
                var datas = getSelectItems();
                services.finishOrders(datas);
            }
        }

        $scope.cancelOrder = function () {
            if (confirm('คุณต้องการ Cancel order ที่เลือก ใช่หรือไม่ ?')) {
                var datas = getSelectItems();
                services.cancelOrder(datas);
            }
        }

        var services = {


            searchOrder: function () {
                var data = {
                    orderCode: $scope.orderCode,
                    productId: parseInt($scope.productId)
                };
                services.getOrders(data);
            },
            getOrders: function (data) {
                $http.post('/Order/getConfirmOrders', data).then(function (resp) {

                    $scope.orders = resp.data;

                    for (var i = 0; i < $scope.orders.length; i++) {
                        $scope.orders[i].orderDate = convertCTOJSDate($scope.orders[i].orderDate);
                    }

                }, function (err) {
                    console.error(err);
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
            finishOrders: function (datas) {
                loading(true);

                $http.post('/Order/finishOrders', datas).then(function (resp) {

                    if (resp.data) {
                        services.searchOrder();
                        alertSuccess('Finish order result.', 'Success !');
                    } else {
                        alertError('Finish order result.', 'Error!');
                    }

                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
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

        var initTestData = function () {
            $scope.orders = [
                { select: true, code: '201712100001', orderDate: null, payDate: null, isPay: false, isShipping: false },
                { select: false, code: '201712100002', orderDate: null, payDate: new Date(), isPay: true, isShipping: false }
            ];
        }

    }]);
