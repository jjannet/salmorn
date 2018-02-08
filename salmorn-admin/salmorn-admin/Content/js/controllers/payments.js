
angular.module('shop-manage')
    .controller('PaymentsController', ['$scope', '$http', function ($scope, $http) {
        $scope.greeting = 'Hola!';

        $scope.payments = [
            {
                firstName: 'Jirawat', lastName: 'Jannet', orderCode: 'O20171210001', paymentDate: new Date(),
                paymentType: 'Transfer', isActive: true, isMapping: false, money: 10000,
                L_FileUpload: {
                    fileName: 'https://storage.googleapis.com/salmorn-dev-storage/0B7AP5SL6N3QJRHW2I4Z8G1OY8B9WR.jpg'
                }
            },
            {
                firstName: 'Jirawat', lastName: 'Jannet', orderCode: 'O20171210001', paymentDate: new Date(),
                paymentType: 'Transfer', isActive: true, isMapping: false, money: 2000,
                L_FileUpload: {
                    fileName: 'https://storage.googleapis.com/salmorn-dev-storage/17438914_1782957312031366_8728465519432171520_n.jpg'
                }
            }
        ];

        $scope.initialScreen = function () {
        };

        $scope.numberWithCommas = function (x) {
            var parts = x.toString().split(".");
            parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            return parts.join(".");
        }

        $scope.openOrderInfo = function (payment) {
            $('#order-info').modal('show');
            $('#order-info-loading').css('display', 'block');

            $http.post('/Order/getOrderByCode', { code: payment.orderCode }).then(function (res) {
                //res.data.header.orderDate = convertDate(res.data.header.orderDate);
                //res.data.header.createDate = convertDate(res.data.header.createDate);
                //res.data.header.updateDate = convertDate(res.data.header.updateDate);
                console.log(res.data);
                $('#order-info-loading').css('display', 'none');
            }, function (err) {
                console.error(err);
                $('#order-info-loading').css('display', 'none');
            });
        }

        var convertDate = function (data) {
            if (data) {

                var milli = data.replace(/\/Date\((-?\d+)\)\//, '$1');
                var d = new Date(parseInt(milli));
                return d;
            } else {
                return data;
            }
        }

    }]);

jQuery(document).ready(function () {
    initImagePopup();
});


var initImagePopup = function () {
    $('.image-link').magnificPopup({
        type: 'image',
        mainClass: 'mfp-with-zoom', // this class is for CSS animation below

        zoom: {
            enabled: true, // By default it's false, so don't forget to enable it

            duration: 300, // duration of the effect, in milliseconds
            easing: 'ease-in-out', // CSS transition easing function
            opener: function (openerElement) {
                return openerElement.is('img') ? openerElement : openerElement.find('img');
            }
        }

    });
}