
angular.module('shop-manage')
    .controller('ShippingsController', ['$scope', '$http', function ($scope, $http) {
        $scope.greeting = 'Hola!';
        $scope.shippings = [
            { select: true, code: '201712100001', shippingDate: null, isShipping: false },
            { select: false, code: '201712100002', shippingDate: new Date(), isShipping: false }
        ];

        $scope.initialScreen = function () {
        };

        $scope.isCanPrint = function () {
            return $scope.shippings.filter((o) => { return o.select }).length > 0;
        }
        $scope.isCanUpdateShipping = function () {
            return $scope.shippings.filter((o) => { return o.select }).length > 0;
        }
        $scope.isCanCancelOrder = function () {
            return $scope.shippings.filter((o) => { return o.select }).length > 0;
        }

    }]);
