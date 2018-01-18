

var STORAGE_KEY_TOKEN = 'salmorn-token';
var STORAGE_KEY_USER = "salmorn-user";

console.log('app.js');
angular.module('shop-manage', ['angularImgFallback'])
    .run(function ($http) {
        $http.defaults.headers.common.Authorization = 'Bearer' + localStorage.getItem(STORAGE_KEY_TOKEN);
    })
    .factory('httpRequestInterceptor', function ($q, $location) {
        return {
            request: function (config) {
                // Get access token from local storage (this is obtained after login).
                token = window.localStorage.getItem(STORAGE_KEY_TOKEN);
                var usr = window.localStorage.getItem(STORAGE_KEY_USER);
                if (token && usr) {

                    if (usr.split('@').length == 2) {
                        var uc = usr.split('@')[0];
                        var cc = usr.split('@')[1];
                        if (uc.length >= 6 && cc.length == 4) {
                            // Always set authorization header with access token when make http request.
                            config.headers['Authorization'] = 'Bearer ' + token;
                        } else {
                            localStorage.removeItem(STORAGE_KEY_TOKEN);
                            localStorage.removeItem(STORAGE_KEY_USER);
                            window.location = MapUrl('/home/login');
                        }
                    }

                } else {
                    localStorage.removeItem(STORAGE_KEY_TOKEN);
                    localStorage.removeItem(STORAGE_KEY_USER);
                    window.location = MapUrl('/home/login');
                }
                return config;
            }, 'responseError': function (rejection) {
                // do something on error
                console.log('responseError', rejection);
                if (rejection.status == 401) {
                    localStorage.removeItem(STORAGE_KEY_TOKEN);
                    localStorage.removeItem(STORAGE_KEY_USER);
                    window.location = MapUrl('/home/login');
                }
                //if (rejection.status === 404) {
                //    $location.path('/404/');
                //}
                return $q.reject(rejection);
            }
        }
    })
    .config(function ($httpProvider) {
        $httpProvider.interceptors.push('httpRequestInterceptor');
    })
    // ขึ้น loading ทุกครั้งที่มีการ request ไปยัง backend
    .factory('httpInterceptor', ['$q', '$rootScope',
        function ($q, $rootScope) {
            var loadingCount = 0;

            return {
                request: function (config) {
                    if (++loadingCount === 1) {
                        var l = document.getElementById("loading-bg");
                        //l.style.display = 'block';
                        $rootScope.$broadcast('loading:progress');
                    }
                    return config || $q.when(config);
                },

                response: function (response) {
                    if (--loadingCount === 0) {
                        var l = document.getElementById("loading-bg");
                        //l.style.display = 'none';
                        $rootScope.$broadcast('loading:finish');
                    }
                    return response || $q.when(response);
                },

                responseError: function (response) {
                    if (--loadingCount === 0) {
                        var l = document.getElementById("loading-bg");
                        l.style.display = 'none';
                        $rootScope.$broadcast('loading:finish');
                    }
                    return $q.reject(response);
                }
            };
        }
    ])
    .config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('httpInterceptor');
    }]);
