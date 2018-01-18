
angular.module('shop-manage')
    .controller('ProductController', ['$scope', '$http', 'Upload', function ($scope, $http, Upload) {
        $scope.greeting = 'Hola!';

        $scope.images = [
            { fileName: 'https://storage.googleapis.com/salmorn-dev-storage/0B7AP5SL6N3QJRHW2I4Z8G1OY8B9WR.jpg' },
            { fileName: 'https://storage.googleapis.com/salmorn-dev-storage/0B7AP5SL6N3QJRHW2I4Z8G1OY8B9WR.jpg' }
        ];


        $scope.productId = null;
        $scope.product = null;
        $scope.stockQty = 0;
        $scope.images = [];
        var productsUrl = ''

        $scope.initialProduct = function (id, productsUrl) {
            if (id == -1) {
                services.getBlankProduct();
            } else {
                $scope.productId = id;
                services.getProductDatas(id);
            }
            this.productsUrl = productsUrl;
        }

        $scope.initialImagePopup = function (item) {
            initImagePopup();
        }

        $scope.cancle = function (url) {
            if ('คุณต้องการยกเลิกการแก้ไขข้อมูลสินค้าใช่หรือไม่ ?') {
                window.location.href = url;
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
                console.error(err);
                loading(false);
            });
        }

        $scope.Image = {
            add: function (file) {
                $scope.images.push(file);
            },

            remove: function (image) {
                var index = $scope.images.indexOf(image);
                $scope.images.splice(index, 1);
            },

            uploadImage: function (element) {
                if (element.files.length > 0) {
                    var file = element.files[0];

                    var index = $scope.images.length;
                    $scope.images.push({ fileName: '/Content/images/loading/loading-01.gif', id: null });
                    $('#uploadFileProgress').parent().css('disblock', 'block');

                    Upload.upload({
                        url: '/Product/uploadProductImage',
                        data: { file: file }
                    }).then(function (resp) {
                        $scope.images[index] = resp.data.file;
                        initImagePopup();
                    }, function (resp) {

                        $scope.images.remove(index);
                        $('#uploadFileProgress').parent().css('disblock', 'none');

                    }, function (evt) {
                        var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);

                        $('#uploadFileProgress').attr('aria-valuenow', progressPercentage);
                        $('#uploadFileProgress').css('width', progressPercentage + '%');

                    });
                }

            }
        }

        var services = {

            getBlankProduct: function () {
                loading(true);
                $http.post('/Product/getBlank').then(function (result) {
                    $scope.product = result.data;

                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
                });
            },
            getProductDatas: function (id) {
                loading(true);
                $http.post('/Product/getProduct', { id: id }).then(function (result) {
                    $scope.product = result.data;
                    $scope.images = result.data.images;

                    $scope.product.preStart = convertCTOJSDate($scope.product.preStart);
                    $scope.product.preEnd = convertCTOJSDate($scope.product.preEnd);

                    $('#preStart').datepicker("update", $scope.product.preStart);
                    $('#preEnd').datepicker("update", $scope.product.preEnd);

                    $('#detail').summernote('code', $scope.product.detail);
                    $('#note').summernote('code', $scope.product.note);

                    loading(false);
                }, function (err) {
                    console.error(err);
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

                if (product.isManualPickup) {
                    if (!product.pickupAt) {
                        isValid = false;
                        txt += '<li>สถานที่นัดรับสินค้า</li>';
                    }
                }
                if (product.isShipping) {
                    if (product.shippintPriceRate <= 0) {
                        isValid = false;
                        txt += '<li>ราคาขนส่งต้องมากกว่า 0 บาท</li>';
                    }
                    if (product.qtyShippingPriceCeiling <= 0) {
                        isValid = false;
                        txt += '<li>ราคาต่อจำนวนสินค้าต้องมากกว่า 0</li>';
                    }
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

                if (product.id == -1) {
                    services.Add(product);
                } else {
                    services.Update(product);
                }
            },
            Add: function (data) {
                loading(true);
                $http.post('/Product/addProduct', data).then(function (result) {
                    alertSuccess('ผลการบันทึก', 'สร้างเอกสารสำเร็จ');
                    window.location.href = '../Product/Edit/' + result.data.id;
                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
                });

            },
            Update: function (data) {
                loading(true);

                $http.post('/Product/editProduct', data).then(function (result) {
                    alertSuccess('ผลการบันทึก', 'บันทึกเอกสารสำเร็จ');
                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
                });
            }

        }

        ModelGenerate = {
            genProduct: function () {

                var prd = angular.copy($scope.product);
                prd.preStart = $('#preStart').datepicker("getDate");
                prd.preEnd = $('#preEnd').datepicker("getDate");
                prd.detail = $('#detail').summernote('code');
                prd.note = $('#note').summernote('code');
                prd.images = $scope.images;

                return prd;
            }
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

    //jQuery('.datepicker').datepicker({
    //    autoclose: true,
    //    todayHighlight: true,
    //    format: 'DD/MM/YYYY',
    //});

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