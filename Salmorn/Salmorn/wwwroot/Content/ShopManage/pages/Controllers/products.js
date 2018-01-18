
angular.module('shop-manage')
    .controller('ProductsController', ['$scope', '$http', function ($scope, $http) {
        $scope.greeting = 'Hola!';
        $scope.products = [];

        $scope.initialScreen = function () {
            $scope.products = [];
            services.GetProducts();
        }

        $scope.numberWithCommas = function (x) {
            var parts = x.toString().split(".");
            parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            return parts.join(".");
        }

        $scope.createProduct = function () {
            window.location.href = '../Product/Product';
        }

        $scope.deleteProduct = function (id) {
            if (confirm('สินค้านี้จะหายไปถาวร คุณต้องการลบจริง ๆ ใช่หรือไม่')) {
                services.DeleteProduct(id);
            }
        }

        var services = {

            GetProducts: function () {
                loading(true);
                $http.get('/ProductServices/GetProductObjs').then(function (result) {

                    $scope.products = result.data.result;

                    loading(false);
                }, function (err) {
                    console.log(err);
                    loading(false);
                });
            },

            DeleteProduct: function (id) {
                loading(true);

                JHttp.Post('/ProductServices/DeleteProduct', id, function (resp) {
                    alertSuccess('ผลการลบ', 'ลบสินค้าสำเร็จ');
                    services.GetProducts();
                    loading(false);
                }, function (err) {
                    console.log(err);
                    loading(false);
                })
            }


        };
    }]);
