
angular.module('shop-manage')
    .controller('ProductsController', ['$scope', '$http', function ($scope, $http) {
        $scope.greeting = 'Hola!';
        $scope.products = [
            { name: 'ที่รัดข้อมือ', detail: 'ใส่ไปจับมืออรกันเถอะ' },
            { name: 'ที่รัดข้อมือ', detail: 'ใส่ไปจับมืออรกันเถอะ' },
            { name: 'ที่รัดข้อมือ', detail: 'ใส่ไปจับมืออรกันเถอะ' },
            { name: 'ที่รัดข้อมือ', detail: 'ใส่ไปจับมืออรกันเถอะ' },
            { name: 'ที่รัดข้อมือ', detail: 'ใส่ไปจับมืออรกันเถอะ' }
        ];

        $scope.initPage = function () {
            services.getProducts();
        }

        $scope.isThereOnSale = function (product) {
            var res = true;
            var currentDate = new Date();

            if (!product.isActive) res = false;
            //if (!product.isPreOrder) res = false;
            if (product.stockQty != null && product.stockQty <= 0) res = false;
            if (product.isPreOrder && product.preEnd != null && product.preEnd <= currentDate) res = false;

            return res;
        }

        $scope.delete = function (product) {
            if (confirm('Are you sure to remove product ' + product.name + ' ?')) {
                services.deleteProduct(product);
            }
        }

        var services = {

            getProducts: function () {
              
                $http.post('/Product/getProducts').then(function (resp) {
                    $scope.products = resp.data;
                }, function (err) {
                    console.error(err);
                });

            },
            deleteProduct: function (product) {

                $http.post('/Product/deleteProduct', product).then(function (resp) {

                    if (resp.data) {
                        alertSuccess('Delete product result', 'Delete product ' + product.name + ' success.');
                        var index = $scope.products.indexOf(product);
                        if (index !== -1) {
                            $scope.products.splice(index, 1);
                        }
                    } else {
                        alertError('Delete product result', 'Delete product ' + product.name + ' error.');
                    }

                }, function (err) {
                    console.error(err);
                });

            }

        };
    }]);
