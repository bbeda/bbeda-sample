angular.module('answers').factory('events', ['$rootScope', function ($rootScope) {
    var result = {};

    result.publish = function (eventName, args) {
        $rootScope.$broadcast(eventName, args);
    }

    return result;
}]);