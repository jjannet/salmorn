

var STORAGE_KEY_TOKEN = 'salmorn-token';
var STORAGE_KEY_USER = "salmorn-user";

angular.module('shop-manage', ['ngFileUpload'])
    .factory('httpRequestInterceptor', function ($q, $location) {
        return {
            request: function (config) {
                
                return config;
            }, 'responseError': function (rejection) {
                // do something on error
                console.log('responseError', rejection);
                
                return $q.reject(rejection);
            }
        }
    })