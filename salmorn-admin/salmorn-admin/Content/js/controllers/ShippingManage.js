
angular.module('shop-manage')
    .controller('ShippingManageController', ['$scope', '$http', function ($scope, $http) {
        $scope.greeting = 'Hola!';
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

        $scope.isCanFinishShipping = function () {
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
            for (var i = 0; i < $scope.shippings.length; i++) {
                $scope.shippings[i].select = $scope.selectAll;
            }
        }

        $scope.finishShipping = function () {

            if (confirm('Confirm finish shipping order ?')) {
                services.finishShipping(getSelectItems());
            }

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
            finishShipping: function (datas) {
                loading(true);

                $http.post('/Shipping/finishShipping', datas).then(function (resp) {

                    if (resp.data) {
                        services.getShippings();
                        alertSuccess('Finish shipping order result.', 'Success !');
                    } else {
                        alertError('Finish shipping order result.', 'Error!');
                    }

                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
                });
            },

            setShippingsStorage: function (items) {
                var s = JSON.stringify(items);
                localStorage.setItem('shipping-print-storage-salmorn', s);
            },
            clearOrderStorage: function () {
                localStorage.setItem('shipping-print-storage-salmorn', null);
            }

        };

    }]);
