
angular.module('shop-manage')
    .controller('OrdersController', ['$scope', '$http', function ($scope, $http) {
        $scope.orders = [];
        $scope.orderCode = '';

        $scope.initialScreen = function () {
            $scope.orders = [];
            $scope.orderCode = '';
            services.GetOrders();
        }

        $scope.searchOrders = function () {
            services.GetOrders();
        }

        $scope.onSelect = function(id) {
            console.log(id)
        }

        var services = {
            GetOrders: function () {
                loading(true);

                JHttp.Post('/Order/getOrders', $scope.orderCode, function (resp) {
                    console.log(resp.result);
                    $scope.orders = resp.result;
                    $scope.$apply();
                    console.log($scope.orders);
                    loading(false);
                }, function (err) {
                    console.log(err);
                    loading(false);
                })
            },
            createShippingFromList: function (orders) {
                loading(true);

                JHttp.Post('/Order/createShippingFromList', orders, function (resp) {
                    if (resp.result) {
                        alertSuccess('Message', 'สร้างรายการส่งของสำเร็จ');
                        loading(false);
                        services.GetOrders();
                    } else {
                        alertError('Message', 'สร้างรายการส่งของล้มเหลว');
                        loading(false);
                    }
                }, function (err) {
                    console.log(err);
                    loading(false);
                });
            }
        };

    }]);

jQuery(document).ready(function () {
  
    jQuery('.datepicker').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

});