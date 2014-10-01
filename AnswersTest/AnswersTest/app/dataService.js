angular.module('answers').factory('data', ['$http', function ($http) {
    var dataService = {};
    dataService.loadAll = function () {
        return $http({ method: 'GET', url: '/home/loadAll' });
    };

    dataService.setItem = function (item) {

    }
    return dataService;
}]);