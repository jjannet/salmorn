

var app = angular.module('appwar', []);
app.controller('IndexController', function ($scope) {
    $scope.firstName = "John";
    $scope.lastName = "Doe";
});

//$(function () {

//    OrderSeat.btnSubmit.setEnable(false);

//});

//var OrderSeat = {
//    id: '#orderSeatForm',
//    btnSubmit: {
//        id: '#btnSubmitOrder',
//        setEnable: function (isEnable) {
//            $(OrderSeat.btnSubmit.id).prop('disabled', !isEnable);
//        }
//    },
//    get: function () {
//        return $(OrderSeat.id).serializeObject();
//    }
//}

//function orderSeatFormSubmit() {

//    console.log($("#orderSeatForm").serializeObject())
//}

//function cbOrderChange(element) {
//    OrderSeat.btnSubmit.setEnable(OrderSeat.get().isRead == 'on');
//}