angular.module('answers').factory('data', ['$http', function ($http) {
    var dataService = {};
    dataService.loadAll = function () {
        return $http({ method: 'GET', url: '/home/loadAll' });
    };

    dataService.loadDetails = function (id) {
        return $http({ method: 'GET', url: '/home/loadPerson', params: { id: id } });
    }

    dataService.updateItem = function (item) {
        return $http({ method: 'POST', url: '/home/updatePerson', data: item });
    }
    return dataService;
}]);