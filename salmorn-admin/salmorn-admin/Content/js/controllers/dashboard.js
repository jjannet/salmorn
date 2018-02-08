
angular.module('shop-manage')
    .controller('DashboardController', ['$scope', '$http', function ($scope, $http) {
        $scope.greeting = 'Hola!';

        $scope.images = [
            { fileName: 'https://storage.googleapis.com/salmorn-dev-storage/0B7AP5SL6N3QJRHW2I4Z8G1OY8B9WR.jpg' },
            { fileName: 'https://storage.googleapis.com/salmorn-dev-storage/0B7AP5SL6N3QJRHW2I4Z8G1OY8B9WR.jpg' }
        ];


        $scope.cancle = function () {
            history.back();
        }

    }]);

