
angular.module('shop-report', [])
    .controller('PostalCoverPrintController', ['$scope', '$http', function ($scope, $http) {
        var storageName = 'shipping-print-storage-salmorn';

        $scope.shippings = [];

        $scope.initialScreen = function () {
            services.setShippingDatas();
        }

        var services = {
            setShippingDatas: function () {
                $scope.shippings = angular.copy(JSON.parse(localStorage.getItem(storageName)));
                if ($scope.shippings == null) {
                    window.close();
                }
                window.print();  
                services.clearShippingStorage();
            },
            clearShippingStorage: function () {
                localStorage.setItem(storageName, null);
            }
        };

    }]);
