
angular.module('shop-manage')
    .controller('PostsController', ['$scope', '$http', function ($scope, $http) {
        $scope.greeting = 'Hola!';
        $scope.postTypes = [];
        $scope.postType = '-1';
        $scope.posts = [
            { title: 'ควันหลงงานวันออดิชั่น รายการท่องเที่ยวญี่ปุ่น ครั้งที่ 2', createDate: new Date(), isActive: false, author: 'Jirawat Jannet', select: false, typeId: 1 },
            { title: 'ควันหลงงานวันออดิชั่น รายการท่องเที่ยวญี่ปุ่น ครั้งที่ 2', createDate: new Date(), isActive: true, author: 'Jirawat Jannet', select: true, typeId: 1 }
        ];

        $scope.initialScreen = function () {
            services.getPosts();
            services.getPostTypes();
        };

        $scope.searchItems = function () {
            console.log($scope.postType);
            if ($scope.postType == '-1') return $scope.posts;
            else {
                return $scope.posts.filter((o) => { return o.typeId == $scope.postType });
            }
        }

        $scope.newPost = function () {
            window.location = '/Post/New';
        }
        $scope.getRowActiveClass = function (selected) {
            if (selected) return 'active';
            else return '';
        }

        $scope.disableButton = {
            showFromList: function () {
                var datas = getSelectedItems();
                if (datas.length <= 0) return true;
                if (datas.filter((o) => { return o.isActive }).length > 0) return true;

                return false;
            },
            hideFromList: function () {
                var datas = getSelectedItems();
                if (datas.length <= 0) return true;
                if (datas.filter((o) => { return o.isActive == false }).length > 0) return true;

                return false;
            }
        };

        $scope.showPostFromList = function () {
            if (confirm('คุณต้องการ แสดง รายการที่เลือกจากหน้าเว็บ ใช่หรือไม่ ?')) {
                services.showPostFromList(getSelectedItems());
            }
        };


        $scope.hidePostFromList = function () {
            if (confirm('คุณต้องการ แสดง รายการที่เลือกจากหน้าเว็บ ใช่หรือไม่ ?')) {
                services.hidePostFromList(getSelectedItems());
            }
        };

        var getSelectedItems = function () {
            return $scope.posts.filter((o) => { return o.select });
        }

        var services = {

            getPosts: function () {
                $http.post('/Post/getPostList').then(function (resp) {

                    $scope.posts = resp.data;

                    for (var i = 0; i < $scope.posts.length; i++) {
                        console.log($scope.posts[i].createDate);
                        $scope.posts[i].createDate = convertCTOJSDate($scope.posts[i].createDate);
                    }

                }, function (err) {
                    console.error(err);
                });
            },
            showPostFromList: function (data) {
                $http.post('/Post/showPostFromList', data).then(function (resp) {

                    if (resp.data) {
                        alertSuccess('Updat result', 'Success');
                        services.getPosts();
                    } else {
                        alertSuccess('Updat result', 'Error');
                    }

                }, function (err) {
                    console.error(err);
                });
            },
            hidePostFromList: function (data) {
                $http.post('/Post/hidePostFromList', data).then(function (resp) {

                    if (resp.data) {
                        alertSuccess('Updat result', 'Success');
                        services.getPosts();
                    } else {
                        alertSuccess('Updat result', 'Error');
                    }

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
            }

        };

    }]);
