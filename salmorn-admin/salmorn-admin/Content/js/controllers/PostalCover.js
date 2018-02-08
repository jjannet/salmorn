
angular.module('shop-manage')
    .controller('PostalCoverController', ['$scope', '$http', function ($scope, $http) {
        var storageName = 'shipping-print-storage-salmorn';
        $scope.shippings = [];

        $scope.province = '-1';
        $scope.zipCode = '-1';
        $scope.product = '-1';

        $scope.selectAll = false;
        $scope.showOnlyPaymentSending = false;
        $scope.shippings = [];

        $scope.provinces = [];
        $scope.zipCodes = [];
        $scope.products = [];

        $scope.initialScreen = function () {
            services.getShippings();
        };

        var getSelectItems = function () {
            return $scope.shippings.filter((o) => { return o.select });
        }
        $scope.isCanPrint = function () {
            return getSelectItems().length > 0;
        }

        $scope.getRowActiveClass = function (selected) {
            if (selected) return 'active';
            else return '';
        }

        $scope.selectChange = function () {
            var selectAll = true;
            for (var i = 0; i < $scope.shippings.length; i++) {
                if (!$scope.shippings[i].select) {
                    selectAll = false;
                    break;
                }
            }
            $scope.selectAll = selectAll;
        }

        $scope.selectAllChange = function () {
            for (var i = 0; i < $scope.getShippingDatas().length; i++) {
                $scope.getShippingDatas()[i].select = $scope.selectAll;
            }
        }

        $scope.printSelect = function () {
            var datas = getSelectItems();
            services.setShippingsStorage(datas);

            window.open('../Shipping/PostalCoverPrint', '_blank');
        }

        $scope.getShippingDatas = function () {
            return $scope.shippings.filter((o) => {
                return ($scope.province == '-1' || o.province == $scope.province)
                    && ($scope.zipCode == '-1' || o.zipCode == $scope.zipCode)
                    && ($scope.product == '-1' || o.order.product.name == $scope.product)
            });
        }

        function ArrNoDupe(a) {
            var temp = {};
            for (var i = 0; i < a.length; i++)
                temp[a[i]] = true;
            var r = [];
            for (var k in temp)
                r.push(k);
            return r;
        }

        var services = {

            getShippings: function () {
                loading(true);
                $http.post('/Shipping/getShippingNoCompleteDatas').then(function (resp) {

                    $scope.shippings = resp.data;

                    $scope.provinces = [];
                    $scope.zipCodes = [];
                    $scope.products = [];
                    for (var i = 0; i < $scope.shippings.length; i++) {
                        $scope.provinces.push($scope.shippings[i].province);
                        $scope.zipCodes.push($scope.shippings[i].zipCode);
                        $scope.products.push($scope.shippings[i].order.product.name);
                    }

                    $scope.provinces = ArrNoDupe($scope.provinces);
                    $scope.zipCodes = ArrNoDupe($scope.zipCodes);
                    $scope.products = ArrNoDupe($scope.products);

                    //for (var i = 0; i < $scope.shippings.length; i++) {
                    //    $scope.shippings[i].orderDate = convertCTOJSDate($scope.shippings[i].orderDate);
                    //}

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

            setShippingsStorage: function (items) {
                var s = JSON.stringify(items);
                localStorage.setItem(storageName, s);
            },
            clearOrderStorage: function () {
                localStorage.setItem(storageName, null);
            }

        };

    }]);
