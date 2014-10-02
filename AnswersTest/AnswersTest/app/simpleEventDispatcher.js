//simple factory which wraps $rootScope to enable event broadcasting between controllers
angular.module('answers').factory('events', ['$rootScope', function ($rootScope) {
    var result = {};

    result.publish = function (eventName, args) {
        $rootScope.$broadcast(eventName, args);
    }

    return result;
}]);