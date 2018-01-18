
angular.module('shop-manage')
    .controller('ProductController', ['$scope', '$http', 'Upload', function ($scope, $http, Upload) {
        $scope.greeting = 'Hola!';

        $scope.productId = null;
        $scope.product = null;
        $scope.stockQty = 0;
        $scope.images = [];

        $scope.initialProduct = function (id) {
            if (id == -1) {
                services.genBlankProduct();
            } else {
                $scope.productId = id;
                services.genProductDatas(id);
            }
        }

        $scope.Image = {
            add: function (file) {
                $scope.images.push(file);
            },

            remove: function (image) {
                var index = $scope.images.indexOf(image);
                $scope.images.splice(index, 1);
            },

            openProductImageDialog: function () {
                openFileControlDialog(addProductImages, $scope.images);
            },


        }

        $scope.cancle = function () {
            console.log('Cancel')
            if ($scope.productId != null) {
                window.location.href = '../../ManageShop/Products';
            } else {
                window.location.href = '../ManageShop/Products';
            }
        }

        $scope.Save = function () {
            services.Save();
        }

        $scope.test = function () {
            var product = ModelGenerate.genProduct();



            JHttp.Post('/ProductServices/Test', product, function (resp) {
                loading(false);
            }, function (err) {
                console.log(err);
                loading(false);
            });
        }

        var services = {

            genBlankProduct: function () {
                loading(true);
                $http.get('/ProductServices/GetBlank').then(function (result) {
                    $scope.product = result.data.result.product;

                    loading(false);
                }, function (err) {
                    console.log(err);
                    loading(false);
                });

            },
            genProductDatas: function (id) {
                loading(true);
                $http.get('/ProductServices/GetProduct/' + id).then(function (result) {
                    $scope.product = result.data.result.product;
                    if ($scope.product.preStart)
                        $scope.product.preStart = new Date($scope.product.preStart);
                    if ($scope.product.preEnd)
                        $scope.product.preEnd = new Date($scope.product.preEnd);

                    $('#preStart').datepicker("setDate", $scope.product.preStart);
                    $('#preEnd').datepicker("setDate", $scope.product.preEnd);

                    $('#detail').summernote('code', $scope.product.detail);
                    $('#note').summernote('code', $scope.product.note);

                    console.log(result.data.result.images);

                    $scope.images = result.data.result.images;
                    $scope.stockQty = result.data.result.stockQTy;
                    console.log('$scope.stockQty', $scope.stockQty);

                    loading(false);
                }, function (err) {
                    console.log(err);
                    loading(false);
                });
            },

            Validate: function (product) {

                var txt = '<ul>';
                var isValid = true;

                if (!product.name) {
                    isValid = false;
                    txt += '<li>ชื่อสินค้า</li>';
                }

                if (!product.unitName) {
                    isValid = false;
                    txt += '<li>หน่วยสินค้า</li>';
                }
                if (product.weight <= 0) {
                    isValid = false;
                    txt += '<li>น้ำหนักต้องมากกว่า 0 กรัม</li>';
                }
                if (product.detail === '<p><br></p>') {
                    isValid = false;
                    txt += '<li>รายละเอียด</li>';
                }
                if (product.shippintPriceRate <= 0) {
                    isValid = false;
                    txt += '<li>ราคาขนส่งต้องมากกว่า 0 บาท</li>';
                }
                if (product.qtyShippingPriceCeiling <= 0) {
                    isValid = false;
                    txt += '<li>ราคาต่อจำนวนสินค้าต้องมากกว่า 0</li>';
                }


                txt += '</ul>';
                console.log(product.detail)
                if (!isValid) {
                    alertError('Validate result', txt);
                }
                return isValid;
            },

            Save: function () {
                var product = ModelGenerate.genProduct();

                if (!services.Validate(product)) return;

                var data = {
                    'product': product,
                    'images': $scope.images,
                    'stockQTy': $scope.stockQty
                };

                if (product.id == -1) {
                    services.Add(data);
                } else {
                    services.Update(data);
                }

            },
            Add: function (data) {
                loading(true);

                JHttp.Post('/ProductServices/AddProduct', data, function (resp) {
                    alertSuccess('ผลการบันทึก', 'สร้างเอกสารสำเร็จ');
                    window.location.href = '../ManageShop/ProductServices/' + resp;
                    loading(false);
                }, function (err) {
                    console.log(err);
                    loading(false);
                })

            },
            Update: function (data) {
                loading(true);

                JHttp.Post('/ProductServices/UpdateProduct', data, function (resp) {
                    alertSuccess('ผลการบันทึก', 'บันทึกเอกสารสำเร็จ');
                    loading(false);
                }, function (err) {
                    console.log(err);
                    loading(false);
                })

            }

        }

        ModelGenerate = {
            genProduct: function () {

                var prd = angular.copy($scope.product);
                prd.preStart = $('#preStart').datepicker("getDate");
                prd.preEnd = $('#preEnd').datepicker("getDate");
                prd.detail = $('#detail').summernote('code');
                prd.note = $('#note').summernote('code');

                return prd;
            }
        }

        var addProductImages = function (files) {
            if (files && files.length > 0) {
                for (let i = 0; i < files.length; i++) {
                    $scope.images.push(files[i]);
                }
            }
            console.log($scope.images);
            $scope.$apply();

            initImagePopup();
        }


    }]);

jQuery(document).ready(function () {
    $('.summernote').summernote({
        height: 350,                 // set editor height
        minHeight: null,             // set minimum height of editor
        maxHeight: null,             // set maximum height of editor
        focus: false                 // set focus to editable area after initializing summernote
    });

    $('.inline-editor').summernote({
        airMode: true
    });

    jQuery('.datepicker').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

    $("input.int-input").TouchSpin({
        buttondown_class: "btn btn-primary",
        buttonup_class: "btn btn-primary"
    });

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