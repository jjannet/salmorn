
angular.module('shop-manage')
    .controller('PostController', ['$scope', '$http', function ($scope, $http) {
        $scope.greeting = 'Hola!';
        $scope.postTypes = [
            { id: 1, name: 'Post' },
            { id: 2, name: 'Activity' }
        ];
        var url = '';
        var postId = -1;
        $scope.postType = '-1';

        $scope.post = null;
       

        $scope.initialScreen = function (id, postsUrl) {
            postId = id;
            url = postsUrl;

            services.getPostTypes();
            if (id == -1) {
                services.getPostBlank();
            } else {
                services.getPost(id);
            }

        };

        $scope.save = function () {
            if (confirm('คุณต้องการบันทึก Post ใช่หรือไม่ ?')) {
                services.save();
            }
        }

        $scope.cancle = function () {
            if ('คุณต้องการยกเลิกการแก้ไขข้อมูลสินค้าใช่หรือไม่ ?') {
                window.location.href = url;
            }
        }
        var services = {
            getPostBlank: function () {
                $http.post('/Post/getPostBlank').then(function (resp) {

                    $scope.post = resp.data;
                    $scope.postType = $scope.post.typeId.toString();

                }, function (err) {
                    console.error(err);
                });
            },
            getPost: function (id) {

                $http.post('/Post/getPost', { id: id }).then(function (resp) {

                    $scope.post = resp.data;
                    $scope.postType = $scope.post.typeId.toString();
                    $('#detail').summernote('code', $scope.post.detail);

                }, function (err) {
                    console.error(err);
                });
            },
            getPostTypes: function () {
                $http.post('/Post/getPostTypes').then(function (resp) {

                    $scope.postTypes = resp.data;

                }, function (err) {
                    console.error(err);
                });
            },

            save: function () {
                var data = services.modelGenerate();
                if (services.validate(data)) {
                    if (data.id == -1) {
                        services.add(data);
                    } else {
                        services.update(data);
                    }
                }
            },
            add: function (data) {
                loading(true);
                $http.post('/Post/addPost', data).then(function (result) {
                    console.log('add', result.data);
                    alertSuccess('ผลการบันทึก', 'สร้างเอกสารสำเร็จ');
                    window.location.href = '../Post/Edit/' + result.data.id;
                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
                });

            },
            update: function (data) {
                loading(true);

                $http.post('/Post/updatePost', data).then(function (result) {
                    console.log('add', result.data);
                    alertSuccess('ผลการบันทึก', 'บันทึกเอกสารสำเร็จ');
                    loading(false);
                }, function (err) {
                    console.error(err);
                    loading(false);
                });
            },
            validate: function (data) {
                var txt = '<ul>';
                var isValid = true;

                if (!data.title) {
                    isValid = false;
                    txt += '<li>Title</li>';
                }
                if (data.detail === '<p><br></p>') {
                    isValid = false;
                    txt += '<li>รายละเอียด</li>';
                }

                txt += '</ul>';
                console.log(product.detail)
                if (!isValid) {
                    alertError('Validate result', txt);
                }
                return isValid;
            },

            modelGenerate: function () {
                var post = angular.copy($scope.post);
                post.detail = $('#detail').summernote('code');
                post.typeId = parseInt($scope.postType);
                return post;
            }
        };

    }]);


jQuery(document).ready(function () {
    $('.summernote').summernote({
        height: 350,                 // set editor height
        minHeight: null,             // set minimum height of editor
        maxHeight: null,             // set maximum height of editor
        focus: false                 // set focus to editable area after initializing summernote
    });

});